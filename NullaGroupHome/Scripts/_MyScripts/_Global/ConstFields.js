//引用后，将所有类为members-count的元素的值改为群成员人数
$.get("/Global/MembersCount", function (response) {
    $(".members-count").text(response);
});