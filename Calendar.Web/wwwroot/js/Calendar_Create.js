let Calendar_Create = $("#Calendar_Create");

Calendar_Create.find("button[name='save']").on("click", function () {

    let Data = {
        groupId: $("#groupId").val(),
        title: $("#title").val(),
        start: $("#start").val(),
        end: $("#end").val(),
        color: $("#color").val(),
        textColor: $("#textColor").val(),
        CreateDate: '2024-08-01 22:59:50.210',
        CreateUser: '110055',
        LogDate: '2024-08-01 22:59:50.210',
        LogUser: '110055'
    };
    console.log(Data);
    $.ajax({
        url: "AddAsync",
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