///id>component id si
///data>component içine yazılacak model içerisindeki data
///type>'data' verisinin tipi > int / string
function Validation(id, data, type) {
    debugger;
    if (data == null) {
        debugger;
        document.getElementById(id).style.display = "block";
    }
    else if (data == "" && type == "String") {
        debugger;
        document.getElementById(id).style.display = "block";
    }
    else if (data == "0" && type == "Int32") {
        debugger;
        document.getElementById(id).style.display = "block";
    }
    else if (data == "00000000-0000-0000-0000-000000000000" && type == "Guid") {
        debugger;
        document.getElementById(id).style.display = "block";
    }
    else {
        debugger;
        document.getElementById(id).style.display = "none";
    }
}