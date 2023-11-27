
function resetValidationSingle(event) {
    var id = event.target.id;
    if ($("#" + id).val() != null && $("#" + id).val() != "" && $("#" + id).val() != " ") {
        var replacedId = id.charAt(0).toUpperCase() + id.slice(1) //to uppercase first letter of input id to make it match the error class name
        $("#" + replacedId + "Err").html("");
    }
}

function SaveProductType(url) {
    if (document.getElementById("TypeName").value == "") {
        document.getElementById("TypeNameErr").innerHTML = "Type Name is required";
        return false;
    }
    else if ($("#UrlReferer").val() == "")
    {
        document.getElementById("UrlRefererErr").innerHTML = "UrlReferer is required";
        return false;
    }
    else if ($("#MetaInfo").val() == "") {
        document.getElementById("MetaInfoErr").innerHTML = "Meta Info is required";
        return false;
    }
    $.ajax({
        type: "GET",
        url: "/ProductType/AlreadyExists?ProductName=" + document.getElementById("TypeName").value + "&UrlReferer=" + document.getElementById("UrlReferer").value,
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            if (result.message == "Already exists") {
                toastr.error("Product type with same name or refferer already exists");
                document.getElementById('TypeNameErr').innerHTML = "Product type with same name or refferer already exists";
                return false;
            }
            if (document.getElementById('TypeNameErr').innerHTML != "") {
                document.getElementById('TypeNameErr').innerHTML = "";
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
                            if (document.getElementById('TypeNameErr').innerHTML != "") {
                                document.getElementById('TypeNameErr').innerHTML = "";
                            }
                            if ($('#active').is(":checked")) {
                                var statuss = "true";
                            } else { statuss = "false"; }
                            var ProductType = {
                                ProductName: document.getElementById("TypeName").value,
                                UrlReferer: document.getElementById("UrlReferer").value,
                                Status: statuss,
                                MetaInfo: $("#MetaInfo").val(),
                                MetaTitle: $("#MetaTitle").val(),
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

function Clear() {
    document.getElementById("UrlReferer").value = "";
    document.getElementById("MetaInfo").value = "";
    document.getElementById("TypeName").value = "";
    document.getElementById("TypeNameErr").innerHTML = "";
    if (!$('#active').is(":checked")) {
        $("#active").prop("checked", true);
    }    
    return false;
}
function Edit(url) {
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
function clearAddOrEditPartial() {
    $("#AddOrUpdate").load(location.href + " #AddOrUpdate");
    return false;
}
function Update(form) {
    if (document.getElementById("TypeName").value == "") {
        document.getElementById("TypeNameErr").innerHTML = "Type Name is required";
        return false;
    }
    if (document.getElementById("MetaInfo").value == "") {
        document.getElementById("MetaInfoErr").innerHTML = "Meta Info is required";
        return false;
    }
    if (document.getElementById('TypeNameErr').innerHTML != "") {
        document.getElementById('TypeNameErr').innerHTML = "";
    }
    if (document.getElementById('MetaInfoErr').innerHTML != "") {
        document.getElementById('MetaInfoErr').innerHTML = "";
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
                                if (res.isValid)
                                {
                                    $("#view-all").html(res.html);
                                    $("#AddOrUpdate").load(location.href + " #AddOrUpdate");
                                    toastr.success("Updated successfully");
                                }
                                else
                                {
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
Delete = (url, title) => {
    console.log("url");
    console.log(url);
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
                            debugger
                            console.log(res);
                            if (res.isValid) {

                                $("#view-all").empty();
                                $("#view-all").html(res.html);
                                toastr.success("Deleted successfully");
                                $("#AddOrUpdate").load(location.href + " #AddOrUpdate");
                            } else {
                                toastr.error(res.html);
                                return false;
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