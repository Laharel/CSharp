#pragma checksum "/media/laharel/Laharel's/oldies/coding/CodingDojo/VS Code/C#/ASP.NetCore/ASP.MVC.I/ViewModelFun/Views/Home/OneUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "889be65e1a9f58483a10ae99a2a76e4842332774"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_OneUser), @"mvc.1.0.view", @"/Views/Home/OneUser.cshtml")]
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
#line 1 "/media/laharel/Laharel's/oldies/coding/CodingDojo/VS Code/C#/ASP.NetCore/ASP.MVC.I/ViewModelFun/Views/_ViewImports.cshtml"
using ViewModelFun;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/media/laharel/Laharel's/oldies/coding/CodingDojo/VS Code/C#/ASP.NetCore/ASP.MVC.I/ViewModelFun/Views/_ViewImports.cshtml"
using ViewModelFun.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"889be65e1a9f58483a10ae99a2a76e4842332774", @"/Views/Home/OneUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7312364e6c23e4cb7805f9e5f986831fce186000", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_OneUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ViewModelFun.Models.User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<div class=\"text-center\">\n    <h5>Here is a User!</h5>\n    <h1 class=\"display-4\">");
#nullable restore
#line 5 "/media/laharel/Laharel's/oldies/coding/CodingDojo/VS Code/C#/ASP.NetCore/ASP.MVC.I/ViewModelFun/Views/Home/OneUser.cshtml"
                     Write(Model.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 5 "/media/laharel/Laharel's/oldies/coding/CodingDojo/VS Code/C#/ASP.NetCore/ASP.MVC.I/ViewModelFun/Views/Home/OneUser.cshtml"
                                      Write(Model.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ViewModelFun.Models.User> Html { get; private set; }
    }
}
#pragma warning restore 1591