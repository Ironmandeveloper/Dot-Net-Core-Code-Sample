function SaveReview(url) {
    debugger
    if (document.getElementById("FirstName").value == "") {
        document.getElementById("FirstNameErr").innerHTML = "First Name is required";
        return false;
    }
    else if ($("#LastName").val() == "") {
        document.getElementById("LastNameErr").innerHTML = "Last Name is required";
        return false;
    }
    else if ($("#Email").val() == "") {
        document.getElementById("EmailErr").innerHTML = "Email is required";
        return false;
    }
    else if ($("#Rating").val() == "") {
        document.getElementById("RatingErr").innerHTML = "Rating is required";
        return false;
    } else if ($("#Reviews").val() == "") {
        document.getElementById("ReviewsErr").innerHTML = "Reviews is required";
        return false;
    }
    $.ajax({
        //type: "GET",
        //url: "/ProductType/AlreadyExists?ProductName=" + document.getElementById("TypeName").value + "&UrlReferer=" + document.getElementById("UrlReferer").value,
        //data: "{}",
        //contentType: "application/json; charset=utf-8",
        //dataType: "json",
        success: function (result) {
            //if (result.message == "Already exists") {
            //    toastr.error("Product type with same name or refferer already exists");
            //    document.getElementById('TypeNameErr').innerHTML = "Product type with same name or refferer already exists";
            //    return false;
            //}
            if (document.getElementById('FirstNameErr').innerHTML != "") {
                document.getElementById('FirstNameErr').innerHTML = "";
            }
            $.confirm({
                title: 'Are you sure to add?',
                content: '',
                type: 'green',
                typeAnimated: true,
                buttons: {
                    Yes: {
                        text: '',
                        btnClass: 'btn-green',
                        action: function () {
                            if (document.getElementById('FirstNameErr').innerHTML != "") {
                                document.getElementById('FirstNameErr').innerHTML = "";
                            }
                            if ($('#active').is(":checked")) {
                                var statuss = "true";
                            } else { statuss = "false"; }
                            var Review = {
                                FirstName: document.getElementById("FirstName").value,
                                LastName: document.getElementById("LastName").value,
                                Email: document.getElementById("Email").value,
                                Rating: document.getElementById("Rating").value,
                                Reviews: document.getElementById("Reviews").value,
                                Status: statuss,
                            };
                            $.ajax({
                                type: "GET",
                                url: url,
                                dataType: "json",
                                data: ProductType,
                                success: function (res) {
                                    console.log(res);
                                    if (res.isValid) {
                                        $("#view-all").html(res.html);
                                        toastr.success("Added Successfully");
                                        Clear();
                                    }
                                }, error: function (err) { console.error(err); }
                            });
                        }
                    },
                    close: function () {
                    }
                }
            });
        }
    });
}




function Update(form) {
    if (document.getElementById("FirstName").value == "") {
        document.getElementById("FirstNameErr").innerHTML = "First Name is required";
        return false;
    }
    else if ($("#LastName").val() == "") {
        document.getElementById("LastNameErr").innerHTML = "Last Name is required";
        return false;
    }
    else if ($("#Email").val() == "") {
        document.getElementById("EmailErr").innerHTML = "Email is required";
        return false;
    }
    else if ($("#Rating").val() == "") {
        document.getElementById("RatingErr").innerHTML = "Rating is required";
        return false;
    } else if ($("#Reviews").val() == "") {
        document.getElementById("ReviewsErr").innerHTML = "Reviews is required";
        return false;
    }
    $.confirm({
        title: 'Are you sure to update?',
        content: '',
        type: 'green',
        typeAnimated: true,
        buttons: {
            Yes: {
                text: '',
                btnClass: 'btn-green',
                action: function () {

                    try {
                        $.ajax({
                            type: 'POST',
                            url: form.action,
                            data: new FormData(form),
                            cache: false,
                            contentType: false,
                            processData: false,
                            success: function (res) {
                                if (res.isValid) {
                                    $("#view-all").html(res.html);
                                    $("#AddOrUpdate").load(location.href + " #AddOrUpdate");
                                    toastr.success("Updated successfully");
                                }
                                else {
                                    toastr.error(res.message);
                                    return false;
                                }
                            },
                            error: function (err) {

                            }
                        })

                    } catch (e) {
                        console.log(e);
                    }

                }
            },
            close: function () {
            }
        }
    });
}



function clearAddOrEditPartial() {
    $("#AddOrUpdate").load(location.href + " #AddOrUpdate");
    return false;
}


function Edit(url) {
    debugger
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {

            if (res.isValid) {
                $("#AddOrUpdate").empty();
                $("#AddOrUpdate").html(res.html);
            }
        }
    });
}


Delete = (url, title) => {
    $.confirm({
        title: 'Are you sure to delete?',
        content: '',
        type: 'red',
        typeAnimated: true,
        buttons: {
            Yes: {
                text: '',
                btnClass: 'btn-red',
                action: function () {

                    $.ajax({
                        type: "POST",
                        url: url,
                        success: function (res) {

                            if (res.isValid) {
                               
                                $("#view-all").empty();
                                $("#view-all").html(res.html);
                                toastr.success("Deleted successfully");

                            } else {

                            }
                        }
                    })
                }
            },
            close: function () {
            }
        }
    });
}
