$(document).ready(function () {
    var today = new Date();
    $('#datacontent_datepicker').datepicker({
        uiLibrary: 'bootstrap',
        format: 'mm-dd-yyyy',
        autoclose: true,
        endDate: "today",
        maxDate: today
    });
});
$('#imageUpload').change(function () {
    readImgUrlAndPreview(this);
    function readImgUrlAndPreview(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#imagePreview').attr('src', e.target.result);
            }
        };
        reader.readAsDataURL(input.files[0]);
    }
});

function closefunction() {
    $('#alertmsgbox').slideUp();
    //document.getElementById("alertmsgbox").style.display = "none";
}