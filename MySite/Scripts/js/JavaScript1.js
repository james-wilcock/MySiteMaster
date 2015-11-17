function pathToFile(str) {
    var nOffset = Math.max(0, Math.max(str.lastIndexOf('\\'), str.lastIndexOf('/')));
    var eOffset = str.lastIndexOf('.');
    if (eOffset < 0) {
        eOffset = str.length;
    }
    return {
        isDirectory: eOffset == str.length,
        path: str.substring(0, nOffset),
        name: str.substring(nOffset > 0 ? nOffset + 1 : nOffset, eOffset),
        extension: str.substring(eOffset > 0 ? eOffset + 1 : eOffset, str.length)
    };
}
