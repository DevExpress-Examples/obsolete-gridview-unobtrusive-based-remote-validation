# OBSOLETE - GridView - How to implement remote validation based on the unobtrusive JavaScript validation


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


