
//$(document).ready(function () {
//    var items = "<option value='0'>Выберите подноминацию</option>";
//    $('#SubnominationId').html(items);
//});

//$('#NominationId').change(function () {
//    var url = 'https://localhost:44394/' + "api/default/GetSubnominations";
//    var ddlsource = "#NominationId";
//    $.getJSON(url, { nominationId: $(ddlsource).val() }, function (data) {
//        var items = '';
//        $('#SubnominationId').empty();
//        $.each(data, function (i, subnomination) {
//            items += "<option value='" + subnomination.value + "'>" + subnomination.text + "</option>";
//        });
//        $('#SubnominationId').html(items);
//    });
//});

//$(function () {
//    $("#btnAddContest").click(function (e) {
//        var itemIndex = $("#container input.iHidden").length;
//        e.preventDefault();
//        var b = getNominations();
//        var newItem = $("<div><select>" + b + "</select></div>");
//        $("#container").append(newItem);
//    });
//})

//function getNominations() {
//    var url = 'https://localhost:44394/' + "api/default/GetNominations";
//    var items = '';
//    $.getJSON(url, function (data) {
//        for (var i = 0; i < data[0].length; i++) {
//            items += "<option value='" + data[0].[i].id + "'>" + data[0].[i].name + "</option>";
//        }
//        return items;
//    });
//}


//    //$.each(data, function (i, nomination) {
//    //    items += "<option value='" + nomination.value + "'>" + nomination.text + "</option>";
//    //});