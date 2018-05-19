@Code
    ViewBag.Title = "Home Page"
End Code

<script type="text/javascript">
    function PrepareValidationScripts() {
        var form = $('#frmProduct');
        if (form.executed)
            return;

        form.removeData("validator");
        $.validator.unobtrusive.parse(document);
        form.executed = true;
    }
    
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
</script>

@Html.Action("GridViewPartial")