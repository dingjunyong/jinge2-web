using Nop.Plugin.Other.Client.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Other.Client.Attributes
{
    public class PictureCollectionValidationAttribute : BaseValidationAttribute
    {
        private Dictionary<string, string> _errors = new Dictionary<string, string>();

        public override void Validate(object instance)
        {
            // Images are not required so they could be null
            // and there is nothing to validate in this case
            if (instance == null)
                return;

            var imagesCollection = instance as ICollection<PictureDto>;

            foreach (var image in imagesCollection)
            {
                var imageValidationAttribute = new PictureValidationAttribute();

                imageValidationAttribute.Validate(image);

                Dictionary<string, string> errorsForImage = imageValidationAttribute.GetErrors();

                if (errorsForImage.Count > 0)
                {
                    _errors = errorsForImage;
                    break;
                }
            }
        }

        public override Dictionary<string, string> GetErrors()
        {
            return _errors;
        }
    }
}
