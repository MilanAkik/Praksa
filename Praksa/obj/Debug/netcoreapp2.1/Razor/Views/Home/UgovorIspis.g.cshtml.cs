#pragma checksum "C:\Users\Milan\source\repos\Praksa\Praksa\Views\Home\UgovorIspis.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa721735ad5669022cc28e3d82f612f0ff0c1e79"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_UgovorIspis), @"mvc.1.0.view", @"/Views/Home/UgovorIspis.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/UgovorIspis.cshtml", typeof(AspNetCore.Views_Home_UgovorIspis))]
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
#line 1 "C:\Users\Milan\source\repos\Praksa\Praksa\Views\_ViewImports.cshtml"
using Praksa;

#line default
#line hidden
#line 2 "C:\Users\Milan\source\repos\Praksa\Praksa\Views\_ViewImports.cshtml"
using Praksa.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa721735ad5669022cc28e3d82f612f0ff0c1e79", @"/Views/Home/UgovorIspis.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0062ce0cde3cb47d44a6a57e5e7b289132d064c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_UgovorIspis : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Praksa.Models.UgovorIspis>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(34, 109, true);
            WriteLiteral("\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th></th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(144, 38, false);
#line 8 "C:\Users\Milan\source\repos\Praksa\Praksa\Views\Home\UgovorIspis.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(182, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(238, 40, false);
#line 11 "C:\Users\Milan\source\repos\Praksa\Praksa\Views\Home\UgovorIspis.cshtml"
           Write(Html.DisplayNameFor(model => model.KIme));

#line default
#line hidden
            EndContext();
            BeginContext(278, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(334, 44, false);
#line 14 "C:\Users\Milan\source\repos\Praksa\Praksa\Views\Home\UgovorIspis.cshtml"
           Write(Html.DisplayNameFor(model => model.Trajanje));

#line default
#line hidden
            EndContext();
            BeginContext(378, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(434, 44, false);
#line 17 "C:\Users\Milan\source\repos\Praksa\Praksa\Views\Home\UgovorIspis.cshtml"
           Write(Html.DisplayNameFor(model => model.Kreirano));

#line default
#line hidden
            EndContext();
            BeginContext(478, 63, true);
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 22 "C:\Users\Milan\source\repos\Praksa\Praksa\Views\Home\UgovorIspis.cshtml"
 foreach (var item in ViewData["UgovoriFive"] as IList<UgovorIspis>) {

#line default
#line hidden
            BeginContext(613, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(662, 56, false);
#line 25 "C:\Users\Milan\source\repos\Praksa\Praksa\Views\Home\UgovorIspis.cshtml"
           Write(Html.ActionLink("Izmena", "UgovorEdit", new { item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(718, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(739, 62, false);
#line 26 "C:\Users\Milan\source\repos\Praksa\Praksa\Views\Home\UgovorIspis.cshtml"
           Write(Html.ActionLink("Brisanje", "UgovorBrisanje", new { item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(801, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(857, 37, false);
#line 29 "C:\Users\Milan\source\repos\Praksa\Praksa\Views\Home\UgovorIspis.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
            EndContext();
            BeginContext(894, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(950, 39, false);
#line 32 "C:\Users\Milan\source\repos\Praksa\Praksa\Views\Home\UgovorIspis.cshtml"
           Write(Html.DisplayFor(modelItem => item.KIme));

#line default
#line hidden
            EndContext();
            BeginContext(989, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1045, 43, false);
#line 35 "C:\Users\Milan\source\repos\Praksa\Praksa\Views\Home\UgovorIspis.cshtml"
           Write(Html.DisplayFor(modelItem => item.Trajanje));

#line default
#line hidden
            EndContext();
            BeginContext(1088, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1144, 43, false);
#line 38 "C:\Users\Milan\source\repos\Praksa\Praksa\Views\Home\UgovorIspis.cshtml"
           Write(Html.DisplayFor(modelItem => item.Kreirano));

#line default
#line hidden
            EndContext();
            BeginContext(1187, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 41 "C:\Users\Milan\source\repos\Praksa\Praksa\Views\Home\UgovorIspis.cshtml"
}

#line default
#line hidden
            BeginContext(1226, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Praksa.Models.UgovorIspis> Html { get; private set; }
    }
}
#pragma warning restore 1591