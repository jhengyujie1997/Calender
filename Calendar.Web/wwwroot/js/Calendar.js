$(document).ready(function () {
    let calendarEl = document.getElementById('calendar'); 

    let calendar = new FullCalendar.Calendar(calendarEl, {
        headerToolbar: {
            start: 'dayGridMonth,timeGridWeek,timeGridDay',
            center: 'title',
            end: 'prevYear,prev,next,nextYear'
        },
        initialView: 'dayGridMonth',
        eventSources: [
            'GetListAsync'
        ],
        locale: 'en',
        editable: true,
        eventClick: function (info) {
            alert('Event: ' + info.event.title);
            alert('Coordinates: ' + info.jsEvent.pageX + ',' + info.jsEvent.pageY);
            alert('View: ' + info.view.type);

            // change the border color just for fun
            info.el.style.borderColor = 'red';
            $("#LargeModal").find('.modal-body').html("");
            $("#LargeModal").find('.modal-body').load('/Calendar/Update', { "groupId": info.event.groupId });
            $("#LargeModal").modal("show");
        },
        eventDrop: function (info) {
            alert(info.event.title + " was dropped on " + info.event.start.toISOString());
            console.log(info);
            if (!confirm("Are you sure about this change?")) {
                info.revert();
            }
        },
        eventResize: function (info) {
            alert(info.event.title + " end is now " + info.event.end.toISOString());

            if (!confirm("is this okay?")) {
                info.revert();
            }
        }
    });
    calendar.render();

    calendar.on('dateClick', function (info) {
        console.log(info);
        console.log('clicked on ' + info.dateStr);
        $("#LargeModal").find('.modal-body').html("");
        $("#LargeModal").find('.modal-body').load('/Calendar/Create');
        $("#LargeModal").modal("show");
    });
});