#pragma checksum "E:\Work\Soom\Soom\Views\SubCategory\SubCategoryForm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff782b7e16b8d33ce17056111a850348aa22ac1a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SubCategory_SubCategoryForm), @"mvc.1.0.view", @"/Views/SubCategory/SubCategoryForm.cshtml")]
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
#line 1 "E:\Work\Soom\Soom\Views\_ViewImports.cshtml"
using Soom;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Work\Soom\Soom\Views\_ViewImports.cshtml"
using Soom.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff782b7e16b8d33ce17056111a850348aa22ac1a", @"/Views/SubCategory/SubCategoryForm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5238535008d422c1ab3b04925460e93cdb2be70f", @"/Views/_ViewImports.cshtml")]
    public class Views_SubCategory_SubCategoryForm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Interfaces.ViewModel.SubCategoryViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-12\">\r\n");
#nullable restore
#line 4 "E:\Work\Soom\Soom\Views\SubCategory\SubCategoryForm.cshtml"
         if (Model.SubCategory.Id == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h3 class=\"alert-success p-3 text-center\">Add Sub Category </h3>\r\n");
#nullable restore
#line 7 "E:\Work\Soom\Soom\Views\SubCategory\SubCategoryForm.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h3 class=\"alert-success p-3 text-center\">Edit Sub Category </h3>\r\n");
#nullable restore
#line 11 "E:\Work\Soom\Soom\Views\SubCategory\SubCategoryForm.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
#nullable restore
#line 14 "E:\Work\Soom\Soom\Views\SubCategory\SubCategoryForm.cshtml"
 using (Html.BeginForm("Save", "SubCategory", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "E:\Work\Soom\Soom\Views\SubCategory\SubCategoryForm.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "E:\Work\Soom\Soom\Views\SubCategory\SubCategoryForm.cshtml"
Write(Html.HiddenFor(c => c.SubCategory.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-sm-3\">\r\n            <div class=\"form-group\">\r\n                <label>Sub Category Name</label>\r\n                ");
#nullable restore
#line 22 "E:\Work\Soom\Soom\Views\SubCategory\SubCategoryForm.cshtml"
           Write(Html.TextBoxFor(c => c.SubCategory.Name, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 23 "E:\Work\Soom\Soom\Views\SubCategory\SubCategoryForm.cshtml"
           Write(Html.ValidationMessageFor(c => c.SubCategory.Name, "", new { @class = "alert-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n\r\n        <div class=\"col-sm-3\">\r\n            <div class=\"form-group\">\r\n                <label class=\"custom-font\">Category</label>\r\n                ");
#nullable restore
#line 31 "E:\Work\Soom\Soom\Views\SubCategory\SubCategoryForm.cshtml"
           Write(Html.DropDownListFor(c => c.SubCategory.CategoryId, new SelectList(Model.Categories, "Id", "Name"), "Please choose Category ...", new { @class = "form-control js-dropdown" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 32 "E:\Work\Soom\Soom\Views\SubCategory\SubCategoryForm.cshtml"
           Write(Html.ValidationMessageFor(c => c.SubCategory.CategoryId, "", new { @class = "alert-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"col-sm-6\">\r\n            <div class=\"form-group\">\r\n                <label>Description</label>\r\n                ");
#nullable restore
#line 38 "E:\Work\Soom\Soom\Views\SubCategory\SubCategoryForm.cshtml"
           Write(Html.TextAreaFor(c => c.SubCategory.Desc, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 39 "E:\Work\Soom\Soom\Views\SubCategory\SubCategoryForm.cshtml"
           Write(Html.ValidationMessageFor(c => c.SubCategory.Desc, "", new { @class = "alert-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"row\">\r\n        <button type=\"submit\" class=\"btn btn-success mr-3\">Save</button>\r\n    </div>\r\n");
#nullable restore
#line 48 "E:\Work\Soom\Soom\Views\SubCategory\SubCategoryForm.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Interfaces.ViewModel.SubCategoryViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591