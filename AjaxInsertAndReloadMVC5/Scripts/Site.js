var OpenDialog = function (url) {
    //var url = "/Home/ReloadStudentDetails?StudentId=" + studentId;

    $("#mymodelbody").load(url, function () {
        $("#mymodel").modal("show");
    })
}