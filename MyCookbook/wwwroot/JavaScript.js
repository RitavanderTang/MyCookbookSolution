function GetDynamicTextbox(value) {

    return '<div class ="form-group">'
        '<h4>Ingredients</h4>'

            '<label asp-for="ingredient.Type" class="control-label"></label>'
            '<input asp-for="ingredient.Type" class="form-control" rows="5" />'
            '<span asp-validation-for="ingredient.Type" class="text-danger"></span>'

            '<label asp-for="ingredient.Quantity" class="control-label"></label>'
            '<input asp-for="ingredient.Quantity" class="form-control" rows="5" />'
            '<span asp-validation-for="ingredient.Quantity" class="text-danger"></span>'

            '<label asp-for="ingredient.Unit" class="control-label"></label>'
            '<input asp-for="ingredient.Unit" class="form-control" rows="5" />'
            '<span asp-validation-for="ingredient.Unit" class="text-danger"></span>< input type = "text" name = "txttest" style = "width:200px;" /> < input type="button" onclick="RemoveTextBox(this)" value="Remove" /></div >';

}

function AddTextBox() {

    var div = document.createElement('DIV');

    div.innerHTML = GetDynamicTextbox("");

    document.getElementById("divCont").appendChild(div);

}

function RemoveTextBox(div) {

    document.getElementById("divCont").removeChild(div.parentNode.parentNode);

}
