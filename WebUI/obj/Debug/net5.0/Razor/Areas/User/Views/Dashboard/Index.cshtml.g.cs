#pragma checksum "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Areas\User\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1d5733db42269bde4a2cd067e4beb57892d511a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_Dashboard_Index), @"mvc.1.0.view", @"/Areas/User/Views/Dashboard/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1d5733db42269bde4a2cd067e4beb57892d511a", @"/Areas/User/Views/Dashboard/Index.cshtml")]
    public class Areas_User_Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Areas\User\Views\Dashboard\Index.cshtml"
  
    ViewData["Title"] = "داشبورد";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .quick-access .quick-access-body {
        display: flex;
        flex-wrap: wrap;
        gap: 10px;
        padding: 20px;
        border-radius: 20px;
    }
</style>
<div class=""status-box-dashboard"">
</div>
<div class=""quick-access dashboard"">
    <div class=""quick-access-header"">
        <h4>Menu</h4>
    </div>
    <div class=""quick-access-body"">
        <a");
            BeginWriteAttribute("href", " href=\"", 436, "\"", 496, 1);
#nullable restore
#line 20 "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Areas\User\Views\Dashboard\Index.cshtml"
WriteAttributeValue("", 443, Url.Action("Index", "TaxRate", new { Area = "Tax" }), 443, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""quick-access-item primary"">
            <span class=""quick-access-item-inner primary"">
                <span class=""icon-container"">
                    <svg height=""30"" fill=""#ffffff"" viewBox=""0 0 32 32"" version=""1.1"" xmlns=""http://www.w3.org/2000/svg"" stroke=""#ffffff""><g id=""SVGRepo_bgCarrier"" stroke-width=""0""></g><g id=""SVGRepo_tracerCarrier"" stroke-linecap=""round"" stroke-linejoin=""round""></g><g id=""SVGRepo_iconCarrier""> <title>book</title> <path d=""M27.75 2c-0-0.414-0.336-0.75-0.75-0.75h-19.8c-0.028-0.001-0.061-0.002-0.094-0.002-1.541 0-2.797 1.22-2.856 2.746l-0 0.005v24.389c0.113 1.331 1.221 2.367 2.572 2.367 0.063 0 0.125-0.002 0.187-0.007l-0.008 0h20c0.414 0 0.75-0.336 0.75-0.75s-0.336-0.75-0.75-0.75v0h-19.8c-0.023 0.001-0.050 0.002-0.077 0.002-0.717 0-1.306-0.547-1.373-1.247l-0-0.006v-1.223c0-0.459 0.584-0.861 1.248-0.861l20.002 0.057c0 0 0.001 0 0.001 0 0.207 0 0.394-0.084 0.529-0.22l0-0c0.017-0.017 0.025-0.041 0.040-0.060 0.047-0.051 0.087-0.11 0.118-0.173l0.002-0.004c0.016-0.049 0.029-0.");
            WriteLiteral(@"105 0.034-0.164l0-0.003c0.011-0.035 0.020-0.077 0.025-0.121l0-0.003v-0.002zM26.25 24.471l-15.5-0.044v-21.677h15.5zM5.75 24.686v-20.686c0.067-0.705 0.657-1.252 1.374-1.252 0.027 0 0.054 0.001 0.080 0.002l-0.004-0h2.050v21.672l-2.25-0.006c-0.453 0.002-0.883 0.101-1.269 0.278l0.019-0.008zM14 7.75h9c0.414 0 0.75-0.336 0.75-0.75s-0.336-0.75-0.75-0.75v0h-9c-0.414 0-0.75 0.336-0.75 0.75s0.336 0.75 0.75 0.75v0zM23 10.25h-9c-0.414 0-0.75 0.336-0.75 0.75s0.336 0.75 0.75 0.75v0h9c0.414 0 0.75-0.336 0.75-0.75s-0.336-0.75-0.75-0.75v0z""></path> </g></svg>
                </span>
            </span>
            <span class=""quick-access-item-title"">Tax Rate</span>
        </a>
        <a");
            BeginWriteAttribute("href", " href=\"", 2207, "\"", 2269, 1);
#nullable restore
#line 28 "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Areas\User\Views\Dashboard\Index.cshtml"
WriteAttributeValue("", 2214, Url.Action("Index", "TaxExempt", new { Area = "Tax" }), 2214, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""quick-access-item"">
            <span class=""quick-access-item-inner primary"">
                <span class=""icon-container"">
                    <svg height=""30"" fill=""#ffffff"" viewBox=""0 0 32 32"" version=""1.1"" xmlns=""http://www.w3.org/2000/svg"" stroke=""#ffffff""><g id=""SVGRepo_bgCarrier"" stroke-width=""0""></g><g id=""SVGRepo_tracerCarrier"" stroke-linecap=""round"" stroke-linejoin=""round""></g><g id=""SVGRepo_iconCarrier""> <title>apps</title> <path d=""M12 1.25h-8c-1.518 0.002-2.748 1.232-2.75 2.75v8c0.002 1.518 1.232 2.748 2.75 2.75h8c1.518-0.002 2.748-1.232 2.75-2.75v-8c-0.002-1.518-1.232-2.748-2.75-2.75h-0zM13.25 12c-0.001 0.69-0.56 1.249-1.25 1.25h-8c-0.69-0.001-1.249-0.56-1.25-1.25v-8c0.001-0.69 0.56-1.249 1.25-1.25h8c0.69 0.001 1.249 0.56 1.25 1.25v0zM12 17.25h-8c-1.518 0.002-2.748 1.232-2.75 2.75v8c0.002 1.518 1.232 2.748 2.75 2.75h8c1.518-0.002 2.748-1.232 2.75-2.75v-8c-0.002-1.518-1.232-2.748-2.75-2.75h-0zM13.25 28c-0.001 0.69-0.56 1.249-1.25 1.25h-8c-0.69-0.001-1.249-0.56-1.25-1.25v-8c0.001-0.69 ");
            WriteLiteral(@"0.56-1.249 1.25-1.25h8c0.69 0.001 1.249 0.56 1.25 1.25v0zM28 1.25h-8c-1.518 0.002-2.748 1.232-2.75 2.75v8c0.002 1.518 1.232 2.748 2.75 2.75h8c1.518-0.002 2.748-1.232 2.75-2.75v-8c-0.002-1.518-1.232-2.748-2.75-2.75h-0zM29.25 12c-0.001 0.69-0.56 1.249-1.25 1.25h-8c-0.69-0.001-1.249-0.56-1.25-1.25v-8c0.001-0.69 0.56-1.249 1.25-1.25h8c0.69 0.001 1.249 0.56 1.25 1.25v0zM28 17.25h-8c-1.518 0.002-2.748 1.232-2.75 2.75v8c0.002 1.518 1.232 2.748 2.75 2.75h8c1.518-0.002 2.748-1.232 2.75-2.75v-8c-0.002-1.518-1.232-2.748-2.75-2.75h-0zM29.25 28c-0.001 0.69-0.56 1.249-1.25 1.25h-8c-0.69-0.001-1.249-0.56-1.25-1.25v-8c0.001-0.69 0.56-1.249 1.25-1.25h8c0.69 0.001 1.249 0.56 1.25 1.25v0z""></path> </g></svg>
                </span>
            </span>
            <span class=""quick-access-item-title"">Tax Exempt</span>
        </a>
        <a");
            BeginWriteAttribute("href", " href=\"", 4133, "\"", 4190, 1);
#nullable restore
#line 36 "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Areas\User\Views\Dashboard\Index.cshtml"
WriteAttributeValue("", 4140, Url.Action("Index", "List", new { Area = "Tax" }), 4140, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""quick-access-item primary"">
            <span class=""quick-access-item-inner primary"">
                <span class=""icon-container"">
                    <svg height=""25"" viewBox=""-4 0 32 32"" version=""1.1"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" xmlns:sketch=""http://www.bohemiancoding.com/sketch/ns"" fill=""#fff""><g id=""SVGRepo_bgCarrier"" stroke-width=""0""></g><g id=""SVGRepo_tracerCarrier"" stroke-linecap=""round"" stroke-linejoin=""round""></g><g id=""SVGRepo_iconCarrier""> <title>location</title> <desc>Created with Sketch Beta.</desc> <defs> </defs> <g id=""Page-1"" stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"" sketch:type=""MSPage""> <g id=""Icon-Set-Filled"" sketch:type=""MSLayerGroup"" transform=""translate(-106.000000, -413.000000)"" fill=""#fff""> <path d=""M118,422 C116.343,422 115,423.343 115,425 C115,426.657 116.343,428 118,428 C119.657,428 121,426.657 121,425 C121,423.343 119.657,422 118,422 L118,422 Z M118,430 C115.239,430 113,427.762 113,425 C113,422.238 ");
            WriteLiteral(@"115.239,420 118,420 C120.761,420 123,422.238 123,425 C123,427.762 120.761,430 118,430 L118,430 Z M118,413 C111.373,413 106,418.373 106,425 C106,430.018 116.005,445.011 118,445 C119.964,445.011 130,429.95 130,425 C130,418.373 124.627,413 118,413 L118,413 Z"" id=""location"" sketch:type=""MSShapeGroup""> </path> </g> </g> </g></svg>
                </span>
            </span>
            <span class=""quick-access-item-title"">Tax</span>
        </a>
        <a");
            BeginWriteAttribute("href", " href=\"", 5676, "\"", 5744, 1);
#nullable restore
#line 44 "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Areas\User\Views\Dashboard\Index.cshtml"
WriteAttributeValue("", 5683, Url.Action("Index", "VehicleType", new { Area = "Vehicle" }), 5683, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""quick-access-item primary"">
            <span class=""quick-access-item-inner primary"">
                <span class=""icon-container"">
                    <svg height=""25"" viewBox=""-4 0 32 32"" version=""1.1"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" xmlns:sketch=""http://www.bohemiancoding.com/sketch/ns"" fill=""#fff""><g id=""SVGRepo_bgCarrier"" stroke-width=""0""></g><g id=""SVGRepo_tracerCarrier"" stroke-linecap=""round"" stroke-linejoin=""round""></g><g id=""SVGRepo_iconCarrier""> <title>location</title> <desc>Created with Sketch Beta.</desc> <defs> </defs> <g id=""Page-1"" stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"" sketch:type=""MSPage""> <g id=""Icon-Set-Filled"" sketch:type=""MSLayerGroup"" transform=""translate(-106.000000, -413.000000)"" fill=""#fff""> <path d=""M118,422 C116.343,422 115,423.343 115,425 C115,426.657 116.343,428 118,428 C119.657,428 121,426.657 121,425 C121,423.343 119.657,422 118,422 L118,422 Z M118,430 C115.239,430 113,427.762 113,425 C113,422.238 ");
            WriteLiteral(@"115.239,420 118,420 C120.761,420 123,422.238 123,425 C123,427.762 120.761,430 118,430 L118,430 Z M118,413 C111.373,413 106,418.373 106,425 C106,430.018 116.005,445.011 118,445 C119.964,445.011 130,429.95 130,425 C130,418.373 124.627,413 118,413 L118,413 Z"" id=""location"" sketch:type=""MSShapeGroup""> </path> </g> </g> </g></svg>
                </span>
            </span>
            <span class=""quick-access-item-title"">Vehicle Type</span>
        </a>
        <a");
            BeginWriteAttribute("href", " href=\"", 7239, "\"", 7300, 1);
#nullable restore
#line 52 "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Areas\User\Views\Dashboard\Index.cshtml"
WriteAttributeValue("", 7246, Url.Action("Index", "List", new { Area = "Vehicle" }), 7246, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""quick-access-item primary"">
            <span class=""quick-access-item-inner primary"">
                <span class=""icon-container"">
                    <svg height=""25"" viewBox=""-4 0 32 32"" version=""1.1"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" xmlns:sketch=""http://www.bohemiancoding.com/sketch/ns"" fill=""#fff""><g id=""SVGRepo_bgCarrier"" stroke-width=""0""></g><g id=""SVGRepo_tracerCarrier"" stroke-linecap=""round"" stroke-linejoin=""round""></g><g id=""SVGRepo_iconCarrier""> <title>location</title> <desc>Created with Sketch Beta.</desc> <defs> </defs> <g id=""Page-1"" stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"" sketch:type=""MSPage""> <g id=""Icon-Set-Filled"" sketch:type=""MSLayerGroup"" transform=""translate(-106.000000, -413.000000)"" fill=""#fff""> <path d=""M118,422 C116.343,422 115,423.343 115,425 C115,426.657 116.343,428 118,428 C119.657,428 121,426.657 121,425 C121,423.343 119.657,422 118,422 L118,422 Z M118,430 C115.239,430 113,427.762 113,425 C113,422.238 ");
            WriteLiteral(@"115.239,420 118,420 C120.761,420 123,422.238 123,425 C123,427.762 120.761,430 118,430 L118,430 Z M118,413 C111.373,413 106,418.373 106,425 C106,430.018 116.005,445.011 118,445 C119.964,445.011 130,429.95 130,425 C130,418.373 124.627,413 118,413 L118,413 Z"" id=""location"" sketch:type=""MSShapeGroup""> </path> </g> </g> </g></svg>
                </span>
            </span>
            <span class=""quick-access-item-title"">Vehicles</span>
        </a>
        <a");
            BeginWriteAttribute("href", " href=\"", 8791, "\"", 8855, 1);
#nullable restore
#line 60 "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Areas\User\Views\Dashboard\Index.cshtml"
WriteAttributeValue("", 8798, Url.Action("Index", "Location", new { Area = "Common" }), 8798, 57, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""quick-access-item primary"">
            <span class=""quick-access-item-inner primary"">
                <span class=""icon-container"">
                    <svg height=""25"" viewBox=""-4 0 32 32"" version=""1.1"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" xmlns:sketch=""http://www.bohemiancoding.com/sketch/ns"" fill=""#fff""><g id=""SVGRepo_bgCarrier"" stroke-width=""0""></g><g id=""SVGRepo_tracerCarrier"" stroke-linecap=""round"" stroke-linejoin=""round""></g><g id=""SVGRepo_iconCarrier""> <title>location</title> <desc>Created with Sketch Beta.</desc> <defs> </defs> <g id=""Page-1"" stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"" sketch:type=""MSPage""> <g id=""Icon-Set-Filled"" sketch:type=""MSLayerGroup"" transform=""translate(-106.000000, -413.000000)"" fill=""#fff""> <path d=""M118,422 C116.343,422 115,423.343 115,425 C115,426.657 116.343,428 118,428 C119.657,428 121,426.657 121,425 C121,423.343 119.657,422 118,422 L118,422 Z M118,430 C115.239,430 113,427.762 113,425 C113,422.238 ");
            WriteLiteral(@"115.239,420 118,420 C120.761,420 123,422.238 123,425 C123,427.762 120.761,430 118,430 L118,430 Z M118,413 C111.373,413 106,418.373 106,425 C106,430.018 116.005,445.011 118,445 C119.964,445.011 130,429.95 130,425 C130,418.373 124.627,413 118,413 L118,413 Z"" id=""location"" sketch:type=""MSShapeGroup""> </path> </g> </g> </g></svg>
                </span>
            </span>
            <span class=""quick-access-item-title"">Location</span>
        </a>
    </div>
</div>
<div class=""quick-access dashboard"">
    <div class=""quick-access-header"">
        <h4>ETC</h4>
    </div>
    <div class=""quick-access-body"">
        <a");
            BeginWriteAttribute("href", " href=\"", 10514, "\"", 10568, 1);
#nullable restore
#line 75 "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Areas\User\Views\Dashboard\Index.cshtml"
WriteAttributeValue("", 10521, Url.Action("Index","List",new { Area="User" }), 10521, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""quick-access-item light"">
            <span class=""quick-access-item-inner"">
                <span class=""icon-container"">
                    <i class=""fa fa-play""></i>
                </span>
            </span>
            <span class=""quick-access-item-title"">کاربران</span>
        </a>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591