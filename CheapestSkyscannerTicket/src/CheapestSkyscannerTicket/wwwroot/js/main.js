$(function () {
    $("#outboundDate").datepicker();
    $("#inboundDate").datepicker();
    $("#outboundDate,#inboundDate").datepicker("option", "dateFormat", "yy-mm-dd");
    
});