
$("#editPlayer").on("show.bs.modal", function (event) {

    let button = event.relatedTarget;

    let id = button.getAttribute("data-id");
    let name = button.getAttribute("data-name");

    $("#editPlayerModalLabel").html("Add winnings for - " + name);

    $("#playerId").val(id);

})

