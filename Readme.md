<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/134060134/14.1.8%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T191019)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Controllers/HomeController.vb))
* [NorthwindDataProvider.cs](./CS/Models/NorthwindDataProvider.cs) (VB: [NorthwindDataProvider.vb](./VB/Models/NorthwindDataProvider.vb))
* [Product.cs](./CS/Models/Product.cs) (VB: [Product.vb](./VB/Models/Product.vb))
* [EditFormPartial.cshtml](./CS/Views/Home/EditFormPartial.cshtml)
* [GridViewPartial.cshtml](./CS/Views/Home/GridViewPartial.cshtml)
* [Index.cshtml](./CS/Views/Home/Index.cshtml)
<!-- default file list end -->
# OBSOLETE - GridView - How to implement remote validation based on the unobtrusive JavaScript validation
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t191019)**
<!-- run online end -->


Starting with DevExpress 14.1, the ASP.NET MVC GridView extension fully supports the unobtrusive client validation for built-in edit forms. Refer to the <a href="https://www.devexpress.com/Support/Center/p/S173266">Support unobtrusive validation for the GridView's built-in edit form</a> thread to learn more.<br /><br /><strong>If you have version v14.1+ available, consider using the built-in functionality instead of the approach detailed below.</strong><br />If you need further clarification, create a new ticket in our Support Center.<br /><br />This example illustrates how to implement <a href="https://documentation.devexpress.com/#AspNet/CustomDocument17294">Remote Validation</a> in the context of the GridView's edit form. We use the approach illustrated in the <a href="https://www.devexpress.com/Support/Center/p/E3744">E3744 - OBSOLETE - How to enable unobtrusive validation for GridView using the EditForm template</a> code example as a starting point because it is necessary to process Update button click in a custom manner to handle remote validation correctly. Here is the major code part that accomplish this task:<br />


```js
    function UpdateGridView(s, e) {
        PrepareValidationScripts();

        var form = $('#frmProduct');
        var validator = $.data(form[0], 'validator');
        validator.form();

        var timer = window.setInterval(function () {
            if (form.data('validator').pendingRequest > 0)
                return;
            clearInterval(timer);
            if (validator.valid())
                GridView.UpdateEdit();
        }, 100);
    }
```



<br/>


