$(document).ready(function () {
    let calendarEl = document.getElementById('calendar');
    let calendar = new FullCalendar.Calendar(calendarEl, {
        headerToolbar: {
            start: 'dayGridMonth,timeGridWeek,timeGridDay',
            center: 'title',
            end: 'prevYear,prev,next,nextYear'
        },
        initialView: 'dayGridMonth',
        events: [
            {
                title: 'All Day Event',
                start: '2024-07-01',
                end: '2024-07-01'
            },
            {
                title: 'Long Event',
                start: '2024-07-07',
                end: '2024-07-10'
            },
            {
                groupId: '999',
                title: 'Repeating Event',
                start: '2024-07-09T16:00:00'
            },
            {
                groupId: '999',
                title: 'Repeating Event',
                start: '2024-07-16T16:00:00'
            },
            {
                title: 'Conference',
                start: '2024-07-11',
                end: '2024-07-13'
            },
            {
                title: 'Meeting',
                start: '2024-07-12T10:30:00',
                end: '2024-07-12T12:30:00'
            },
            {
                title: 'Lunch',
                start: '2024-07-12T12:00:00'
            },
            {
                title: 'Meeting',
                start: '2024-07-12T14:30:00'
            },
            {
                title: 'Birthday Party',
                start: '2024-07-13T07:00:00'
            },
            {
                title: 'Click for Google',
                url: 'https://google.com/',
                start: '2024-07-28',
                color: 'yellow',   // an option!
                textColor: '#000000', // an option!
            },
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
            $("#LargeModal").find('.modal-body').load('/Calendar/Update');
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