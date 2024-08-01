let form = $("#Calendar_Update");

form.find("button[name='save']").on("click", function () {

    let Data = {
        groupId: $("#groupId").val(),
        title: $("#title").val(),
        start: $("#start").val(),
        end: $("#end").val(),
        color: $("#color").val(),
        textColor: $("#textColor").val()
    };
    console.log(Data);
    $.ajax({
        url: "UpdateAsync",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(Data),
        success: function (result) {
            $("#result").html(result);
        },
        error: function (xhr, status, error) {
            console.error("Error: " + error);
        }
    });
});