using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCCoreTagHelpers1.TagHelper1
{
    public class EmailTagHelper:TagHelper
    {
        public string? MailTo { get; set; }
        public string? InnerHtml { get; set; }
        public string? DomainName { get; set; }
        public string? TargetAddress { get; set; }

        public override void Process(TagHelperContext context,TagHelperOutput output)
        {
            output.TagName = "a";

            if(!string.IsNullOrEmpty(TargetAddress))
                output.Attributes.SetAttribute("href",$"MailTo:{TargetAddress}");
            else
                output.Attributes.SetAttribute("href", $"mailto:{MailTo}@{DomainName}");
            if (!String.IsNullOrEmpty(InnerHtml))
                output.Content.SetContent(InnerHtml);
            else if (!String.IsNullOrEmpty(TargetAddress))
                output.Content.SetContent(TargetAddress);
            else
                output.Content.SetContent($"{MailTo}@{DomainName}");


        }

    }
}
