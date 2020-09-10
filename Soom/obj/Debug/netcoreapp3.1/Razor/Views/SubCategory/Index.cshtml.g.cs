#pragma checksum "E:\Work\Soom\Soom\Views\SubCategory\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7bf9a25048a1c51c8211d52b4d679e20f7799b2b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SubCategory_Index), @"mvc.1.0.view", @"/Views/SubCategory/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7bf9a25048a1c51c8211d52b4d679e20f7799b2b", @"/Views/SubCategory/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5238535008d422c1ab3b04925460e93cdb2be70f", @"/Views/_ViewImports.cshtml")]
    public class Views_SubCategory_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Work\Soom\Soom\Views\SubCategory\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-12"">
        <h3 class=""alert-success p-3 text-center"">All Sub Categories</h3>
    </div>
</div>
<br />
<div class=""row"">
    <div class=""container"">
        <div class=""row"">

            <table id=""SubCategoryData"" class=""table table-striped table-bordered"">
                <thead>
                    <tr>
                        <td>Name</td>
                        <td>Category</td>
                        <td>Description</td>
                        <td>Actions</td>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>


        </div>
    </div>
</div>

");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function () {
            var table = $(""#SubCategoryData"").DataTable({
                ""processing"": true,
                ""serverSide"": true,
                ""filter"": true,
                ""ajax"": {
                    ""url"": ""/SubCategoryApi"",
                    ""type"": ""POST"",
                    ""datatype"": ""json""
                },

                ""columns"": [

                    { ""data"": ""name"" },
                    { ""data"": ""categoryName"" },
                    { ""data"": ""desc""  },
                     {
                        data: ""id"",
                        render: function (data) {
                            return ""<a class='btn btn-primary' href='/SubCategory/Update/"" + data + ""'>Edit</a>"";
                        }
                    }
                ]
            });


        })



    </script>
");
            }
            );
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
