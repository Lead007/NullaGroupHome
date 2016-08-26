$.get("/Global/MembersCount", function (response) {
    $(".members-count").text(response);
});