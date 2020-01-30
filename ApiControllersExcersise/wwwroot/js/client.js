$(document).ready(function () {
    $("from").submit(functio(e){
        e.preventDefault();
        $.ajax({
            url: "api/reservation",
            method: "POST",
            data: JSON.stringify({
                clientName: this.element["ClientName"].value,
                location: this.element["Location"].value
            }),
            success: function (data) {
                addTableRow(data);
            }
        })
    })
});

var addTableRow = function (reservation) {
    $("table tbody").append("<tr><td>" + reservation.reservationId + "</td><td>" + reservation.clientName + "</td><td>" + reservation.location + "</td></tr>");
}