var ClsSettings = {
    GetAll: function () {
        Helper.AjaxCallGet("https://localhost:7191/api/Setting", {}, "json",
            function (data) {
                console.log(data);
                $("#lnkFacebook").attr("href", data.facebookLink);
            }, function () { });
    }
}

ClsSettings.GetAll();