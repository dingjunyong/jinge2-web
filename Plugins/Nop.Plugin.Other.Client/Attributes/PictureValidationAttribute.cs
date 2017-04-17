﻿using Nop.Core.Infrastructure;
using Nop.Plugin.Other.Client.Dtos;
using Nop.Services.Media;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nop.Plugin.Other.Client.Attributes
{
    public class PictureValidationAttribute : BaseValidationAttribute
    {
        private Dictionary<string, string> _errors;
        private readonly IPictureService _pictureService;

        public PictureValidationAttribute()
        {
            _errors = new Dictionary<string, string>();
            _pictureService = EngineContext.Current.Resolve<IPictureService>();
        }

        public override void Validate(object instance)
        {
            PictureDto pictureDto = instance as PictureDto;

            bool imageSrcSet = pictureDto != null && !string.IsNullOrEmpty(pictureDto.Src);
            bool imageAttachmentSet = pictureDto != null && !string.IsNullOrEmpty(pictureDto.Attachment);

            if (imageSrcSet || imageAttachmentSet)
            {
                byte[] imageBytes = null;
                string mimeType = string.Empty;

                // Validation of the image object

                // We can't have both set.
                CheckIfBothImageSourceTypesAreSet(imageSrcSet, imageAttachmentSet);

                // Here we ensure that the validation to this point has passed 
                // and try to download the image or convert base64 format to byte array
                // depending on which format is passed. In both cases we should get a byte array and mime type.
                if (_errors.Count == 0)
                {
                    if (imageSrcSet)
                    {
                        DownloadFromSrc(pictureDto.Src, ref imageBytes, ref mimeType);
                    }
                    else if (imageAttachmentSet)
                    {
                        ValidateAttachmentFormat(pictureDto.Attachment);

                        if (_errors.Count == 0)
                        {
                            ConvertAttachmentToByteArray(pictureDto.Attachment, ref imageBytes,
                                ref mimeType);
                        }
                    }
                }

                // We need to check because some of the validation above may have render the models state invalid.
                if (_errors.Count == 0)
                {
                    // Here we handle the check if the file passed is actual image and if the image is valid according to the 
                    // restrictions set in the administration.
                    ValidatePictureBiteArray(imageBytes, mimeType);
                }

                pictureDto.Binary = imageBytes;
                pictureDto.MimeType = mimeType;
            }
        }

        public override Dictionary<string, string> GetErrors()
        {
            return _errors;
        }

        private void CheckIfBothImageSourceTypesAreSet(bool imageSrcSet, bool imageAttachmentSet)
        {
            if (imageSrcSet &&
                imageAttachmentSet)
            {
                var key = string.Format("{0} type", "image");
                _errors.Add(key, "Image src and Attachment are both set");
            }
        }

        private void DownloadFromSrc(string imageSrc, ref byte[] imageBytes, ref string mimeType)
        {
            var key = string.Format("{0} type", "image");
            // TODO: discuss if we need our own web client so we can set a custom tmeout - this one's timeout is 100 sec.
            var client = new WebClient();

            try
            {
                imageBytes = client.DownloadData(imageSrc);
                // This needs to be after the downloadData is called from client, otherwise there won't be any response headers.
                mimeType = client.ResponseHeaders["content-type"];

                if (imageBytes == null)
                {
                    _errors.Add(key, "src is invalid");
                }
            }
            catch (Exception ex)
            {
                string message = string.Format("{0} - {1}", "src is invalid", ex.Message);

                _errors.Add(key, message);
            }
        }

        private void ValidateAttachmentFormat(string attachment)
        {
            Regex validBase64Pattern =
                new Regex("^([A-Za-z0-9+/]{4})*([A-Za-z0-9+/]{4}|[A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{2}==)$");
            bool isMatch = validBase64Pattern.IsMatch(attachment);
            if (!isMatch)
            {
                var key = string.Format("{0} type", "image");
                _errors.Add(key, "attachment format is invalid");
            }
        }

        private void ConvertAttachmentToByteArray(string attachment, ref byte[] imageBytes, ref string mimeType)
        {
            imageBytes = Convert.FromBase64String(attachment);
            mimeType = GetMimeTypeFromByteArray(imageBytes);
        }

        private static string GetMimeTypeFromByteArray(byte[] imageBytes)
        {
            MemoryStream stream = new MemoryStream(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(stream, true);
            ImageFormat format = image.RawFormat;
            ImageCodecInfo codec = ImageCodecInfo.GetImageDecoders().First(c => c.FormatID == format.Guid);
            return codec.MimeType;
        }

        private void ValidatePictureBiteArray(byte[] imageBytes, string mimeType)
        {
            if (imageBytes != null)
            {
                try
                {
                    imageBytes = _pictureService.ValidatePicture(imageBytes, mimeType);
                }
                catch (Exception ex)
                {
                    var key = string.Format("{0} invalid", "image");
                    string message = string.Format("{0} - {1}", "source is invalid", ex.Message);

                    _errors.Add(key, message);
                }
            }

            if (imageBytes == null)
            {
                var key = string.Format("{0} invalid", "image");
                string message = "You have provided an invalid image source/attachment";

                _errors.Add(key, message);
            }
        }
    }
}
