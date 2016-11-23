$(function () {

    if ($("#Mode").val() == "Create") {

        $("#ERP").on("change", function () {
            PopulatePrincipal($(this).val());
        });

        function PopulatePrincipal(erp) {
            $.ajax({
                url: '/Maintenance/PopulatePrincipal',
                type: "GET",
                dataType: "JSON",
                data: { 'erp': erp },
                success: function (principalList) {
                    $("#Principal").html("");
                    $("#Principal").append($('<option></option>').val("").html("Select Principal"));

                    $.each(principalList, function (i, item) {
                        $("#Principal").append(
                            $('<option></option>').val(item.Value).html(item.Text));
                    });
                }
            });
        }
    }

    else if ($("#Mode").val() == "Edit") {
        PopulatePrincipal($("#ERP").val(), $("#PrincipalCode").val());

        $("#ERP").on("change", function () {
            PopulatePrincipal($(this).val(),'');
        });

        function PopulatePrincipal(erp, principal) {
            $.ajax({
                url: '/Maintenance/PopulatePrincipal',
                type: "GET",
                dataType: "JSON",
                data: { 'erp': erp },
                success: function (principalList) {
                    $("#Principal").html("");
                    $("#Principal").append($('<option></option>').val("").html("Select Principal"));

                    $.each(principalList, function (i, item) {
                        if (item.Value.trim() == principal.trim()) {
                            $("#Principal").append(
                            $('<option selected></option>').val(item.Value).html(item.Text));
                        }
                        else {
                            $("#Principal").append(
                            $('<option></option>').val(item.Value).html(item.Text));
                        }

                    });
                }
            });
        }
    }
    
});