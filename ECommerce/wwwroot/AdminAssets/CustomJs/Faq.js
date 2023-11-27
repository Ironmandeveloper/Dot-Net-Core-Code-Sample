function SaveFaq(url) {
    if (document.getElementById("Question").value == "") {
        document.getElementById("QuestionErr").innerHTML = "Question is required";
        document.getElementById("AnswerErr").innerHTML = "";
        return false;
    }
    if (document.getElementById("Answer").value == "") {
        document.getElementById("AnswerErr").innerHTML = "Answer is required";
        document.getElementById("QuestionErr").innerHTML = "";
        return false;
    }

    $.ajax({
        type: "GET",
        url: "/Faq/AlreadyExists?Question=" + document.getElementById("Question").value,
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            
            if (result.message == "Already exists") {
                document.getElementById('QuestionErr').innerHTML = "Question already exists";
                document.getElementById("AnswerErr").innerHTML = "";
                toastr.error("Question already exists");
                return false;
            }
           
            if (document.getElementById('QuestionErr').innerHTML != "") {
                document.getElementById('QuestionErr').innerHTML = "";
            }
            if (document.getElementById('AnswerErr').innerHTML != "") {
                document.getElementById('AnswerErr').innerHTML = "";
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
                          
                           
                            if ($('#active').is(":checked")) {
                                var statuss = "true";
                            } else { statuss = "false"; }
                            var Faq = {
                                Question: document.getElementById("Question").value,
                                Answer: $("#Answer").val(),
                                IsActive: statuss,
                            };
                            $.ajax({
                                type: "GET",
                                url: url,
                                dataType: "json",
                                data: Faq,
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
                                $("#AddOrUpdate").load(location.href + " #AddOrUpdate");
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
    if (document.getElementById("Question").value == "") {
        document.getElementById("QuestionErr").innerHTML = "Question is required";
        document.getElementById("AnswerErr").innerHTML = "";
        return false;
    }
    else if (document.getElementById("Answer").value == "") {
        document.getElementById("AnswerErr").innerHTML = "Answer is required";
        document.getElementById("QuestionErr").innerHTML = "";
            return false;
    }
    if (document.getElementById('AnswerErr').innerHTML != "") {
        document.getElementById('AnswerErr').innerHTML = "";
    }
    if (document.getElementById('QuestionErr').innerHTML != "") {
        document.getElementById('QuestionErr').innerHTML = "";
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
function Clear() {
    document.getElementById("Question").value = "";
    document.getElementById("Answer").value = "";
    document.getElementById("AnswerErr").innerHTML = "";
    document.getElementById("QuestionErr").innerHTML = "";
    if ($('#active').is(":checked")) {
        $("#active").prop("checked", false);
    }
    return false;
}