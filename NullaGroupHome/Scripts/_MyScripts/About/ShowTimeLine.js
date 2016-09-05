//读取json并显示在时间线上
$.ajax({
    type: "GET",
    url: "/App_Data/About/TimeLine.json",
    dataType: "json",
    success: function (data) {
        var events = data.Events;
        for (var i = 0; i < events.length; i++) {
            var block = $("<div></div>");
            block.addClass("cd-timeline-block");
            var cdimg = $("<div></div>");
            cdimg.addClass("cd-timeline-img cd-picture");
            var img = $("<img/>");
            img.attr("src", "/About/_Images/TimelineNodes/Node" + (i & 1) + ".jpg");
            img.attr("alt", "时间线");
            img.attr("height", "24px");
            img.attr("width", "24px");
            cdimg.append(img);
            block.append(cdimg);
            var content = $("<div></div>");
            content.addClass("cd-timeline-content");
            var members = getMembers();
            for (var j = 0; j < members.length; j++) {
                events[i].Event = events[i].Event.replace(members[j], memberUriByIndex(j));
            }
            var p = $("<p></p>").html(events[i].Event);
            var span = $("<span></span>").text(events[i].Date);
            span.addClass("cd-date");
            content.append(p, span);
            block.append(content);
            $("#cd-timeline").append(block);
        }
    },
});