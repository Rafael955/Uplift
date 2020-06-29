#pragma checksum "C:\Users\user\source\repos\Uplift\src\Uplift.UI\Areas\Customer\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1dc3e2e668a2b989d20a74f77c6e9d85c12b4e14"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Customer/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\user\source\repos\Uplift\src\Uplift.UI\Areas\Customer\Views\_ViewImports.cshtml"
using Uplift.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\source\repos\Uplift\src\Uplift.UI\Areas\Customer\Views\_ViewImports.cshtml"
using Uplift.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1dc3e2e668a2b989d20a74f77c6e9d85c12b4e14", @"/Areas/Customer/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c25397835bd8b9031c8736d8e4cc27a69fc908ab", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    public class Areas_Customer_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Uplift.Models.ViewModels.HomeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\user\source\repos\Uplift\src\Uplift.UI\Areas\Customer\Views\Home\Index.cshtml"
 foreach(var category in Model.CategoryList.OrderBy(o => o.DisplayOrder))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\user\source\repos\Uplift\src\Uplift.UI\Areas\Customer\Views\Home\Index.cshtml"
     if(Model.ServiceList.Where(c => c.CategoryId == category.Id).Count() > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row container pb-3 backgroundWhite\">\r\n            <div class=\"col-12\">\r\n                <div class=\"row\">\r\n                    <h2 class=\"text-success\"><b>");
#nullable restore
#line 10 "C:\Users\user\source\repos\Uplift\src\Uplift.UI\Areas\Customer\Views\Home\Index.cshtml"
                                           Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></h2>\r\n                    <div class=\"col-12\">\r\n                        <div class=\"row my-3\">\r\n");
#nullable restore
#line 13 "C:\Users\user\source\repos\Uplift\src\Uplift.UI\Areas\Customer\Views\Home\Index.cshtml"
                             foreach(var service in Model.ServiceList.Where(c => c.CategoryId == category.Id))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""col-lg-4 col-xl-3 col-md-6 pb-4"">
                                    <div class=""card"" style=""border:2px solid #43ac6a; border-radius: 5px; background: url('/images/leafs.jpg')"">
                                        <div class=""pl-3 pt-1 text-center"">
                                            <h3 class=""card-title text-primary"">
                                                <b>");
#nullable restore
#line 19 "C:\Users\user\source\repos\Uplift\src\Uplift.UI\Areas\Customer\Views\Home\Index.cshtml"
                                              Write(service.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</b>
                                            </h3>
                                        </div>
                                        <div class=""d-flex justify-content-between"">
                                            <div class=""pl-3 text-muted"">Preço por Serviço</div>
                                            <div class=""pl-3 text-danger h5"">R$");
#nullable restore
#line 24 "C:\Users\user\source\repos\Uplift\src\Uplift.UI\Areas\Customer\Views\Home\Index.cshtml"
                                                                          Write(service.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 28 "C:\Users\user\source\repos\Uplift\src\Uplift.UI\Areas\Customer\Views\Home\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 34 "C:\Users\user\source\repos\Uplift\src\Uplift.UI\Areas\Customer\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\user\source\repos\Uplift\src\Uplift.UI\Areas\Customer\Views\Home\Index.cshtml"
     
}

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Uplift.Models.ViewModels.HomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
