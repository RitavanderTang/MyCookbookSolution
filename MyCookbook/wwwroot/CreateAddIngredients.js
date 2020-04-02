function GetDynamicTextbox(value) {

    return '<div><input type="text" name="txttest" style="width:200px;" /><input type="button" onclick="RemoveTextBox(this)" value="Remove" /></div>';

}
//https://tutorialslink.com/Articles/How-to-add-control-dynamically-in-Aspnet-MVC-using-Javascript/64

function AddTextBox() {

    var div = document.createElement('DIV');

    div.innerHTML = GetDynamicTextbox("");

    document.getElementById("divCont").appendChild(div);

}

function RemoveTextBox(div) {

    document.getElementById("divCont").removeChild(div.parentNode.parentNode);

}