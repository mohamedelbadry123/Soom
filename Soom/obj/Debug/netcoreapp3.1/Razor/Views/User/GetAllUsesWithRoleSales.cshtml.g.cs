#pragma checksum "D:\Works\35- Echo\Soom\Soom\Views\User\GetAllUsesWithRoleSales.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c632badd4f0355bec2d0af08b61bbe17c2fc9437"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_GetAllUsesWithRoleSales), @"mvc.1.0.view", @"/Views/User/GetAllUsesWithRoleSales.cshtml")]
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
#line 1 "D:\Works\35- Echo\Soom\Soom\Views\_ViewImports.cshtml"
using Soom;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Works\35- Echo\Soom\Soom\Views\_ViewImports.cshtml"
using Soom.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c632badd4f0355bec2d0af08b61bbe17c2fc9437", @"/Views/User/GetAllUsesWithRoleSales.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5238535008d422c1ab3b04925460e93cdb2be70f", @"/Views/_ViewImports.cshtml")]
    public class Views_User_GetAllUsesWithRoleSales : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Works\35- Echo\Soom\Soom\Views\User\GetAllUsesWithRoleSales.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-12"">
        <h3 class=""alert-success p-3 text-center"">جميع البائعين </h3>
    </div>
</div>
<br />
<div class=""row"">
    <div class=""container"">
        <div class=""row"">

            <table id=""ads"" class=""table table-striped table-bordered"">
                <thead>
                    <tr>
                        <td>اسم المستخدم</td>
                        <td>الأسم</td>
                        <td>البريد الألكترونى</td>
");
            WriteLiteral("                    </tr>\r\n                </thead>\r\n                <tbody></tbody>\r\n            </table>\r\n\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function () {
            var table = $(""#ads"").DataTable({
                ajax: {
                    url: ""/userApi/salesRole"",
                    dataSrc: """",
                },
                columns: [
                    {
                        data: ""userName""
                    },
                    {
                        data: ""name""
                    },
                    {
                        data: ""email""
                    }
                    //{
                    //    data: ""id"",
                    //    render: function (data) {
                    //        return ""<a class='btn btn-primary' href='/Elevator/Update/"" + data + ""'>تعديل</a><button data-ads-id="" + data + ""  class='js-delete btn btn-danger mr-2'>حذف</button>"";
                    //    }
                    //}
                ]
            });

            // $('#example').DataTable();

            $(""#ads"").on(""clic");
                WriteLiteral(@"k"", "".js-delete"", function () {
                var button = $(this);
                bootbox.confirm(""هل انت متأكد من حذف هذا المصعد"", function (result) {
                    if (result) {
                        $.ajax({
                            url: ""/elvatorApi/Delete"",
                            method: ""GET"",
                            data: {
                                id: button.attr(""data-ads-id"")
                            },
                            success: function () {
                                table.row(button.parents(""tr"")).remove().draw();
                            }
                        });
                    }
                });

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
