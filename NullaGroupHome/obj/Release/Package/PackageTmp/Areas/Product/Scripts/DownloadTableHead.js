function writeTableHead(hasPreposition, element) {
    var tr = $("<tr></tr>");
    var th1 = $("<th></th>").text("类型");
    var th2 = $("<th></th>").text("文件名");
    var th3 = $("<th></th>").text("文件大小");
    var th4 = $("<th></th>").text("上传时间");
    var th5 = $("<th></th>").text("游戏版本");
    tr.append(th1, th2, th3, th4, th5);
    //若有前置
    if (hasPreposition) {
        var th6 = $("<th></th>").text("前置版本");
        tr.append(th6);
    }
    element.append(tr);
}
