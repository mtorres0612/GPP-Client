$(function () {
    FillData();

    function FillData() {
        $.ajax(
        {
            url: '/Maintenance/GetMessagesByDefaultTradingPartner',
            type: 'GET',
            success: function (data) {
                $("#MessagesList").html("");
                $("#MessagesList").html(data);
            }
        });
    }
});