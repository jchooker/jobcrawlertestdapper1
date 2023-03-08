$(document).ready(function () {
    GetAjax("platforms").done(function (d) {
        //var data = JSON.parse(d);
        var ct = 0;
        $.each(d, function (i, o) {
            $('<option />').text(d[i]).val(ct.toString()).appendTo('#job-platform');
            ct++;
        });
    });
});

function GetAjax(whichSrc) {
    var settings = {
        "url": "../data/" + whichSrc + ".json",
        "method": "GET"
    }
    return $.ajax(settings);
}
