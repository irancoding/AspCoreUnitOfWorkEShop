#pragma checksum "D:\IranCoding\Projects\ASP Core\Project\AspCoreUnitOfWorkEShop\AspCoreUnitOfWorkEShop\WebUI\Views\Shared\EditorTemplates\Time.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f33ca9dde8902e382316ee6e814a5c263cb1aed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_EditorTemplates_Time), @"mvc.1.0.view", @"/Views/Shared/EditorTemplates/Time.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\IranCoding\Projects\ASP Core\Project\AspCoreUnitOfWorkEShop\AspCoreUnitOfWorkEShop\WebUI\Views\_ViewImports.cshtml"
using WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\IranCoding\Projects\ASP Core\Project\AspCoreUnitOfWorkEShop\AspCoreUnitOfWorkEShop\WebUI\Views\_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\IranCoding\Projects\ASP Core\Project\AspCoreUnitOfWorkEShop\AspCoreUnitOfWorkEShop\WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f33ca9dde8902e382316ee6e814a5c263cb1aed", @"/Views/Shared/EditorTemplates/Time.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f047802d4e4541034881b5113d6b9a9923968ea3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_EditorTemplates_Time : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DateTime?>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "D:\IranCoding\Projects\ASP Core\Project\AspCoreUnitOfWorkEShop\AspCoreUnitOfWorkEShop\WebUI\Views\Shared\EditorTemplates\Time.cshtml"
Write(Html.Kendo().TimePickerFor(m => m).HtmlAttributes(new {title = Html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName("")}));

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DateTime?> Html { get; private set; }
    }
}
#pragma warning restore 1591
