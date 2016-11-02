$(document).ready(function () {
    $("#dvEmailDistList").on("shown.bs.modal", function (e) {
        $("#LastEmailDate, #LastEmailShortDate").datepicker();

        $('#ulEmailAddrFrom').tagit({
            singleField: true,
            singleFieldNode: $('#EmailAddrFrom')
        });

        $('#ulEmailAddrTo').tagit({
            singleField: true,
            singleFieldNode: $('#EmailAddrTo')
        });

        $('#ulEmailAddrCC').tagit({
            singleField: true,
            singleFieldNode: $('#EmailAddrCC')
        });

        $('#ulEmailAddrBCC').tagit({
            singleField: true,
            singleFieldNode: $('#EmailAddrBCC')
        });

        $('#ulExtEmailAddrTo').tagit({
            singleField: true,
            singleFieldNode: $('#ExtEmailAddrTo')
        });

        $('#ulExtEmailAddrCC').tagit({
            singleField: true,
            singleFieldNode: $('#ExtEmailAddrCC')
        });
    })

    
});

