using CentralDasOngs.Exceptions.Exceptions.ValidationError;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CentralDasOngs.Presentation.TagHelpers
{
    public class ValidationTagHelper : TagHelper
    {
        public List<ValidationError> ErrorList { get; set; }
        public string PropertyName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ErrorList == null) return;

            var error = ErrorList.FirstOrDefault(e => e.PropertyName == PropertyName);
            if (error != null)
            {
                output.TagName = "span";
                output.Attributes.Add("class", "text-danger");
                output.Content.SetContent(error.ErrorMessage);
            }
            else
            {
                output.SuppressOutput();
            }
        }
    }
}
