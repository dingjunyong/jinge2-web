using Nop.Plugin.Other.Client.Infrastructure.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace Nop.Plugin.Other.Client.Infrastructure
{
    public class ParametersBinder<T> : IModelBinder where T : class, new()
    {
        private readonly IObjectConverter _objectConverter;

        public ParametersBinder(IObjectConverter objectConverter)
        {
            _objectConverter = objectConverter;
        }

        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            // MS_QueryNameValuePairs contains key value pair representation of the query parameters passed to in the request.
            if (actionContext.Request.Properties.ContainsKey("MS_QueryNameValuePairs"))
            {
                bindingContext.Model = _objectConverter.ToObject<T>(
                    (ICollection<KeyValuePair<string, string>>)actionContext.Request.Properties["MS_QueryNameValuePairs"]);
            }
            else
            {
                bindingContext.Model = new T();
            }

            // This should be true otherwise the model will be null.
            return true;
        }
    }
}
