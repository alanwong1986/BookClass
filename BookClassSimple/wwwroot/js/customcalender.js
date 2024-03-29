﻿$(document).ready(function () {
    var courseDate;

    const monthNames = ["January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    ];

    $(".schedule-picker").each(function () {
        var calender = $("<table class='calender-table'>");
        var timePicker = $("<div class='time-picker'>");
        $(this).append(calender);
        var today = new Date();
        loadCalender(calender, timePicker, today.getFullYear(), today.getMonth());
        $(this).append(timePicker);
    });

    function loadCalender(calender, timePicker, year, month) {
        var calender_id = $(calender).attr("id");
        $(timePicker).html('');
        courseDate = @Html.Raw(Json.Serialize(Model.CourseDate));

        var today = new Date();
        var daysInMonth = new Date(year, month + 1, 0).getDate();

        var headerRow = $("<thead class='calender-header'>");
        var headerCell = $("<td colspan='7'><span class='calender-left' name='" + calender_id + "'><</span><span style='width:80%;display:inline-block'>" + year + " " + monthNames[month] + "</span><span class='calender-right' name='" + calender_id + "'>></></td>")
        $(headerRow).append(headerCell);
        $(calender).append(headerRow);

        var weekRow = $("<tr>");
        $(weekRow).append($("<td class='calender-week'>Sun</td><td class='calender-week'>Mon</td><td class='calender-week'>Tue</td><td class='calender-week'>Wed</td><td class='calender-week'>Thu</td><td class='calender-week'>Fri</td><td class='calender-week'>Sat</td>"));
        $(calender).append(weekRow);

        var curRow;
        for (var day = 1; day <= daysInMonth; day++) {
            var date = new Date(year, month, day);
            if (day == 1 || date.getDay() == 0) {
                var curRow = $("<tr>");
                $(calender).append(curRow);
                if (day == 1) {
                    if (date.getDay() != 0) {
                        curRow.append($("<td class='calender-dummy' colspan='" + date.getDay() + "'>"));
                    }
                }
            }

            var isSelectable = false;
            for (var cd = 0; cd < courseDate.length; cd++) {
                var selectableDate = new Date(courseDate[cd].courseDate);
                if (selectableDate.getFullYear() == year && selectableDate.getMonth() == month && selectableDate.getDate() == day) {
                    isSelectable = true;
                }
            }

            if (isSelectable) {
                curRow.append($("<td class='calender-day calender-selectable' name='" + calender_id + "'>" + day + "</td>"));
            } else if (today.getFullYear() == year && today.getMonth() == month && today.getDate() == day) {
                curRow.append($("<td class='calender-day calender-today' name='" + calender_id + "'>" + day + "</td>"));
            } else {
                curRow.append($("<td class='calender-day' name='" + calender_id + "'>" + day + "</td>"));
            }

            if (day == daysInMonth) {
                if (date.getDay() != 6) {
                    curRow.append($("<td class='calender-dummy' colspan='" + (6 - date.getDay()) + "'>"));
                }
            }
        }

        $(".calender-left[name=" + calender_id + "]").click(function () {
            $(calender).html('');
            if (month == 0) {
                loadCalender(calender, timePicker, year - 1, 11);
            } else {
                loadCalender(calender, timePicker, year, month - 1);
            }
        });

        $(".calender-right[name=" + calender_id + "]").click(function () {
            $(calender).html('');
            if (month == 11) {
                loadCalender(calender, timePicker, year + 1, 1);
            } else {
                loadCalender(calender, timePicker, year, month + 1);
            }
        });

        $(".calender-selectable[name=" + calender_id + "]").click(function () {
            $(timePicker).html('');
            $(".calender-selectable[name=" + calender_id + "]").removeClass("calender-selected");
            $(this).addClass("calender-selected");

            for (var cd = 0; cd < courseDate.length; cd++) {
                var selectableDate = new Date(courseDate[cd].courseDate);
                if (selectableDate.getFullYear() == year && selectableDate.getMonth() == month && selectableDate.getDate() == $(this).html()) {
                    var timePanel = $("<div style='padding:15px'>");
                    $(timePicker).append(timePanel);
                    for (var ct = 0; ct < courseDate[cd].courseTimes.length; ct++) {
                        var time = courseDate[cd].courseTimes[ct];
                        $(timePanel).append($("<div><input type='radio' name='courseTime-" + calender_id + "' value='" + time.courseTimeId + "' " + (ct == 0 ? "checked" : "") + " ><label>" + time.courseTime + "</label></div>"))
                    }
                    var bookingBtn = $("<span class='btn btn-danger btn-course-book' style='width:100%; cursor:pointer'>Book Now</span>");
                    $(timePanel).append(bookingBtn);

                    $(bookingBtn).click(function () {
                        var radioName = "courseTime-" + calender_id;
                        var chosenTime = $("input[name=" + radioName + "]:checked").val();
                        $.post("/Course/BookCourse", { courseTimeId: chosenTime }, function (result) {
                            messageBox(result);
                        });
                    });
                }
            }
        });
    }
});