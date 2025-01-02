let calendar_Update = new $("#Calendar_Update");

calendar_Update.find("button[name='save']").on("click", function () {

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
            if (result) {
                $("#LargeModal").modal("hide");
                if (window.calendar) {
                    window.calendar.refetchEvents();
                } else {
                    console.error("Calendar instance not found!");
                }
                alert("更新成功！");
            } else {
                // 顯示失敗通知
                alert("更新失敗，請檢查資料是否正確。");
            }
        },
        error: function (xhr, status, error) {
            console.error("Error: " + error);
        }
    });
});