#pragma checksum "D:\CHI_Software\MyProjects\OnlineStore\Views\Account\AllUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dfaa893ac548ecf4ecefa3f6c534e47f3ebf8115"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_AllUsers), @"mvc.1.0.view", @"/Views/Account/AllUsers.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/AllUsers.cshtml", typeof(AspNetCore.Views_Account_AllUsers))]
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
#line 1 "D:\CHI_Software\MyProjects\OnlineStore\Views\_ViewImports.cshtml"
using OnlineStore;

#line default
#line hidden
#line 2 "D:\CHI_Software\MyProjects\OnlineStore\Views\_ViewImports.cshtml"
using OnlineStore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dfaa893ac548ecf4ecefa3f6c534e47f3ebf8115", @"/Views/Account/AllUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a85bb3a1f5b42cee7936e01fe8aebb63edeff1ce", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_AllUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OnlineStore.Models.Data.User>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(50, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\CHI_Software\MyProjects\OnlineStore\Views\Account\AllUsers.cshtml"
  
	ViewData["Title"] = "AllUsers";

#line default
#line hidden
            BeginContext(93, 249, true);
            WriteLiteral("\r\n<h2>AllUsers</h2>\r\n\r\n<div class=\"container-fluid\">\r\n\t<h4 class=\"bg-primary p-3 text-white\">Products</h4>\r\n\t<table class=\"table table-striped\">\r\n\t\t<thead>\r\n\t\t\t<tr>\r\n\t\t\t\t<th>User login</th>\r\n\t\t\t\t<th>Nickname</th>  \r\n\t\t\t</tr>\r\n\t\t</thead>\r\n\t\t<tbody>\r\n");
            EndContext();
#line 19 "D:\CHI_Software\MyProjects\OnlineStore\Views\Account\AllUsers.cshtml"
             foreach (var item in Model)
			{

#line default
#line hidden
            BeginContext(381, 27, true);
            WriteLiteral("\t\t\t\t<tr>\r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
            EndContext();
            BeginContext(409, 40, false);
#line 23 "D:\CHI_Software\MyProjects\OnlineStore\Views\Account\AllUsers.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Login));

#line default
#line hidden
            EndContext();
            BeginContext(449, 31, true);
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
            EndContext();
            BeginContext(481, 43, false);
#line 26 "D:\CHI_Software\MyProjects\OnlineStore\Views\Account\AllUsers.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Nickname));

#line default
#line hidden
            EndContext();
            BeginContext(524, 32, true);
            WriteLiteral("\r\n\t\t\t\t\t</td> \r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
            EndContext();
            BeginContext(556, 74, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c24b8a10beef4db7b910e920dd92b477", async() => {
                BeginContext(606, 20, true);
                WriteLiteral("Back to registration");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(630, 25, true);
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t</tr>\r\n");
            EndContext();
#line 32 "D:\CHI_Software\MyProjects\OnlineStore\Views\Account\AllUsers.cshtml"
			}

#line default
#line hidden
            BeginContext(661, 33, true);
            WriteLiteral("\t\t</tbody>\r\n\t</table>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OnlineStore.Models.Data.User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
