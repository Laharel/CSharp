#pragma checksum "/media/laharel/Laharel's/oldies/coding/CodingDojo/VS Code/C#/ASP.NetCore/ASP.MVC.I/ViewModelFun/Views/Home/Users.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9ab10e4a4026f94ab24d92668021bec6e4feb535"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Users), @"mvc.1.0.view", @"/Views/Home/Users.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ab10e4a4026f94ab24d92668021bec6e4feb535", @"/Views/Home/Users.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7312364e6c23e4cb7805f9e5f986831fce186000", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Users : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<div class=\"text-center\">\n    <h2>Here are some users!</h2>\n");
#nullable restore
#line 5 "/media/laharel/Laharel's/oldies/coding/CodingDojo/VS Code/C#/ASP.NetCore/ASP.MVC.I/ViewModelFun/Views/Home/Users.cshtml"
     foreach(User item in Model){

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>");
#nullable restore
#line 6 "/media/laharel/Laharel's/oldies/coding/CodingDojo/VS Code/C#/ASP.NetCore/ASP.MVC.I/ViewModelFun/Views/Home/Users.cshtml"
      Write(item.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 6 "/media/laharel/Laharel's/oldies/coding/CodingDojo/VS Code/C#/ASP.NetCore/ASP.MVC.I/ViewModelFun/Views/Home/Users.cshtml"
                            if(item.LastName!=null){

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/media/laharel/Laharel's/oldies/coding/CodingDojo/VS Code/C#/ASP.NetCore/ASP.MVC.I/ViewModelFun/Views/Home/Users.cshtml"
                                               Write(item.LastName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/media/laharel/Laharel's/oldies/coding/CodingDojo/VS Code/C#/ASP.NetCore/ASP.MVC.I/ViewModelFun/Views/Home/Users.cshtml"
                                                                  }

#line default
#line hidden
#nullable disable
            WriteLiteral("             </p>\n");
#nullable restore
#line 8 "/media/laharel/Laharel's/oldies/coding/CodingDojo/VS Code/C#/ASP.NetCore/ASP.MVC.I/ViewModelFun/Views/Home/Users.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<User>> Html { get; private set; }
    }
}
#pragma warning restore 1591