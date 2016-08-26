//把整数转化为汉字数字
function ConvertIntToString(i) {
    switch (i) {
        case 1:
            return "一";
        case 2:
            return "两";
        case 3:
            return "三";
        case 4:
            return "四";
        case 5:
            return "五";
        case 6:
            return "六";
        case 7:
            return "七";
        case 8:
            return "八";
        case 9:
            return "九";
    }
}
//获取建立时间
function Time() {
    var date = new Date();
    var month = date.getMonth();
    if (month === 12 && date.getDay() >= 14) return ConvertIntToString(date.getYear() - 114) + "年多";
    if ((month === 9 && date.getDay() < 14) || month < 9) return ConvertIntToString(date.getYear() - 115) + "年多";
    return "近" + (ConvertIntToString(date.getYear() - 114)) + "年";
}
