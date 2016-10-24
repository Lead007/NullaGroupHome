function getMembers() {
    var members = new Array();
    members.push("小鸟小姐");
    members.push("小大圣");
    members.push("不穿女装的玛秾");
    members.push("女仆长的PAD");
    members.push("NavyFlash");
    members.push("SalimTerryLi");
    members.push("PrimeBlade");
    return members;
}

function memberUri(memberName) {
    return "<a href=\"/About/Administrator/Introduction.aspx?name=" + memberName + "\">" + memberName + "</a>";
}

function memberUriByIndex(memberIndex) {
    return memberUri(getMembers()[memberIndex]);
}

function writeMemberUri(name) {
    document.write(memberUri(name));
}

function writeMemberUriByIndex(index) {
    writeMemberUri(getMembers()[index]);
}