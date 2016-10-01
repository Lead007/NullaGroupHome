//extension是数组或字符串
function JudgeFileExtension(extension) {
    var fileName;
    var fileType;
    if (arguments[1] === undefined) {
        fileName = $(":file").val();
        fileType = fileName.substring(fileName.lastIndexOf(".") + 1);
    } else {
        fileName = arguments[1].val();
        fileType = fileName.substring(fileName.lastIndexOf(".") + 1);
    }
    if (typeof extension === "string") {
        return fileType === extension;
    } else {
        for (var i = 0; i < extension.length; i++) {
            if (fileType === extension[i]) return true;
        }
        return false;
    }

}