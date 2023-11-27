var _validFileExtensions = [".jpg", ".jpeg", ".bmp", ".gif", ".png"];
function ValidateImageExtension(oInput) {
    if (oInput.type == "file") {
        var sFileName = oInput.value;
        if (sFileName.length > 0) {
            var blnValid = false;
            for (var j = 0; j < _validFileExtensions.length; j++) {
                var sCurExtension = _validFileExtensions[j];
                if (sFileName.substr(sFileName.length - sCurExtension.length, sCurExtension.length).toLowerCase() == sCurExtension.toLowerCase()) {
                    blnValid = true;
                    break;
                }
            }

            if (!blnValid) {
                document.getElementById("ProductImageErr").innerHTML = "Sorry, " + sFileName + " is invalid, allowed extensions are: " + _validFileExtensions.join(", ");
                oInput.value = "";
                return false;
            } else {
                document.getElementById("ProductImageErr").innerHTML = "";
            }
        }
    }
    return true;
}

function resetValidationSingle(event) {
    var id = event.target.id;
    if ($("#" + id).val() != null && $("#" + id).val() != "" && $("#" + id).val() != " " ) {
        var replacedId = id.charAt(0).toUpperCase() + id.slice(1) //to uppercase first letter of input id to make it match the error class name
        $("#" + replacedId + "Err").html("");
    }
}

function removeErrMsgEditor() {
    document.getElementById("ProductDescriptionErr").innerHTML = "";
}


function SaveProduct(url) {
    var validationError = false;
    if ($("#productName").val() == "") {
        document.getElementById("ProductNameErr").innerHTML = "Product name is required";
        validationError = true;
    }
    if ($("#ProductPrice").val() == "") {
        document.getElementById("ProductPriceErr").innerHTML = "Product price is required";
        validationError = true;
    }
    if ($("#ProductImage").val() == "") {
        document.getElementById("ProductImageErr").innerHTML = "Product image is required";
        validationError = true;
    }
    if ($("#ProductType option:selected").text() == "---Select Product Type---") {
        document.getElementById("ProductTypeErr").innerHTML = "Product type is required";
        validationError = true;
    }
    if ($("#MetaTitle").val() == "") {
        document.getElementById("MetaTitleErr").innerHTML = "Meta Title is required";
        validationError = true;
    }
    if ($("#MetaInfo").val() == "") {
        document.getElementById("MetaInfoErr").innerHTML = "Meta Info is required";
        validationError = true;
    }
    if ($("#UrlReferer").val() == "") {
        document.getElementById("MetaInfoErr").innerHTML = "Url Referer is required";
        validationError = true;
    }
    if ($('.ql-editor').html() == "<p><br></p>") {
        document.getElementById("ProductDescriptionErr").innerHTML = "Product Desription is required";
        validationError = true;
    }

    if (validationError == true) {
        return false;
    }
    else {
        $.ajax({
            type: "GET",
            url: "/Products/AlreadyExists?ProductName=" + document.getElementById("productName").value,
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                console.log(result);
                if (result.message == "Already exists") {
                    toastr.error("Product with same name already exists");
                    document.getElementById('productNameErr').innerHTML = result.message;
                    return false;
                }
                if (document.getElementById('ProductTypeErr').innerHTML != "") {
                    document.getElementById('ProductTypeErr').innerHTML = "";
                }
                if (document.getElementById('ProductPriceErr').innerHTML != "") {
                    document.getElementById('ProductPriceErr').innerHTML = "";
                }
                if (document.getElementById('ProductNameErr').innerHTML != "") {
                    document.getElementById('ProductNameErr').innerHTML = "";
                }
                if (document.getElementById('ProductImageErr').innerHTML != "") {
                    document.getElementById('ProductImageErr').innerHTML = "";
                }
                if (document.getElementById('ProductDescriptionErr').innerHTML != "") {
                    document.getElementById('ProductDescriptionErr').innerHTML = "";
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
                                if (document.getElementById("ProductDescriptionErr").innerHTML != "") {
                                    document.getElementById("ProductDescriptionErr").innerHTML = "";
                                }
                                if ($('#active').is(":checked")) {
                                    var statuss = "true";
                                } else { statuss = "false"; }
                                if (document.getElementById("ProductDescriptionErr").innerHTML != "") {
                                    document.getElementById("ProductDescriptionErr").innerHTML = "";
                                }
                                var formData = new FormData();
                                formData.append("Id", "0");
                                formData.append("Name", $("#productName").val());
                                formData.append("Status", statuss);
                                formData.append("Price", $("#ProductPrice").val());
                                formData.append("ProductTypeId", $("#ProductType").val());
                                formData.append("MetaTitle", $("#MetaTitle").val());
                                formData.append("MetaInfo", $("#MetaInfo").val());
                                formData.append("UrlReferer", $("#UrlReferer").val());
                                formData.append("ProductDescription", $('.ql-editor').html());
                                var inp = document.getElementById("ProductImage");
                                if (inp.files.length > 0) {
                                    for (var i = 0; i < inp.files.length; i++) {
                                        formData.append('Image', inp.files[i]);
                                        break;
                                    }
                                }
                                $.ajax({
                                    type: "POST",
                                    url: url,
                                    data: formData,
                                    async: false,
                                    cache: false,
                                    processData: false,
                                    contentType: false,
                                    success: function (res) {

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
}

function Edit(id) {
    $.ajax({
        type: "POST",
        url: "/Products/AddOrEdit?Id=" + id,
        success: function (res) {

            if (res.isValid) {

                $("#AddOrUpdate").empty();
                $("#AddOrUpdate").html(res.html);
                $('.ql-editor').html($("#Description").val());
            }
        }
    });
}
function Update(form) {
    if ($("#productName").val() == "") {
        document.getElementById("ProductNameErr").innerHTML = "Product name is required";
        document.getElementById("ProductImageErr").innerHTML = "";
        document.getElementById("ProductPriceErr").innerHTML = "";
        document.getElementById("ProductDescriptionErr").innerHTML = "";
        return false;
    }
    else if ($("#ProductPrice").val() == "") {
        document.getElementById("ProductPriceErr").innerHTML = "Product price is required";
        document.getElementById("ProductNameErr").innerHTML = "";
        document.getElementById("ProductImageErr").innerHTML = "";
        document.getElementById("ProductDescriptionErr").innerHTML = "";
        return false;
    }
    else if ($("#ProductType option:selected").text() == "---Select Product Type---") {
        document.getElementById("ProductTypeErr").innerHTML = "Product type is required";
        document.getElementById("ProductImageErr").innerHTML = "";
        document.getElementById("ProductNameErr").innerHTML = "";
        document.getElementById("ProductPriceErr").innerHTML = "";
        document.getElementById("ProductDescriptionErr").innerHTML = "";
        return false;
    }
    else if ($('.ql-editor').html() == "<p><br></p>") {
        document.getElementById("ProductDescriptionErr").innerHTML = "Product Desription is required";
        document.getElementById("ProductImageErr").innerHTML = "";
        document.getElementById("ProductNameErr").innerHTML = "";
        document.getElementById("ProductPriceErr").innerHTML = "";
        document.getElementById("ProductTypeErr").innerHTML = "";
        return false;
    }
    if (document.getElementById('ProductTypeErr').innerHTML != "") {
        document.getElementById('ProductTypeErr').innerHTML = "";
    }
    if (document.getElementById('ProductPriceErr').innerHTML != "") {
        document.getElementById('ProductPriceErr').innerHTML = "";
    }
    if (document.getElementById('ProductNameErr').innerHTML != "") {
        document.getElementById('ProductNameErr').innerHTML = "";
    }
    if (document.getElementById('ProductImageErr').innerHTML != "") {
        document.getElementById('ProductImageErr').innerHTML = "";
    }
    if (document.getElementById('ProductDescriptionErr').innerHTML != "") {
        document.getElementById('ProductDescriptionErr').innerHTML = "";
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
                        document.getElementById("Description").value = $('.ql-editor').html();
                        $.ajax({
                            type: 'POST',
                            url: form.action,
                            data: new FormData(form),
                            async: false,
                            cache: false,
                            processData: false,
                            contentType: false,
                            success: function (res) {
                                if (res.isValid) {

                                    $("#view-all").empty();
                                    $("#view-all").html(res.html);
                                    $("#AddOrUpdate").empty();
                                    $("#AddOrUpdate").html(res.htmll);
                                    toastr.success("Updated successfully");
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
                                $("#AddOrUpdate").empty();
                                $("#AddOrUpdate").html(res.htmll);
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
function Clear() {
    document.getElementById("productName").value = "";
    document.getElementById("ProductPrice").value = "";
    document.getElementById("ProductImage").value = "";
    $("#ProductType").val("0").change();

    document.getElementById("ProductNameErr").innerHTML = "";
    document.getElementById("ProductPriceErr").innerHTML = "";
    document.getElementById("ProductImageErr").innerHTML = "";
    document.getElementById("ProductPriceErr").innerHTML = "";
    document.getElementById("ProductTypeErr").innerHTML = "";
    document.getElementById("ProductDescriptionErr").innerHTML = "";
    if (!$('#active').is(":checked")) {
        $("#active").prop("checked", true);
    }
    $('.ql-editor').html("");
    return false;
}


function clearAddOrEditPartial() {
    $.ajax({
        type: 'GET',
        url: '/Products/ResetHandler',
        data: {},
        success: function (res) {
            if (res.isValid) {
                $("#AddOrUpdate").empty();
                $("#AddOrUpdate").html(res.html);
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
}

