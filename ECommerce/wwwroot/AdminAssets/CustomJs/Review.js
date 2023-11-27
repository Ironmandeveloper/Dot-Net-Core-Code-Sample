
function AddReview(url) {
    console.log(document.querySelector('input[name="rating"]:checked'));
    if (document.getElementById("c_fname").value == "") {
        document.getElementById("c_fnameErr").innerHTML = "First Name is required";
        return false;
    }
    else if ($("#c_lname").val() == "") {
        document.getElementById("c_lnameErr").innerHTML = "Last Name is required";
        return false;
    }
    else if ($("#c_email_address").val() == "") {
        document.getElementById("c_email_addressErr").innerHTML = "Email is required";
        return false;
    }
    else if ($("#c_order_notes").val() == "") {
        document.getElementById("c_order_notesErr").innerHTML = "Review is required";
        return false;
    }

    var Review = {
        FirstName: document.getElementById("c_fname").value,
        LastName: document.getElementById("c_lname").value,
        Email: document.getElementById("c_email_address").value,
        Reviews: $("#c_order_notes").val(),
        Rating: document.querySelector('input[name="rating"]:checked'),
        Reviewid=0,
    };
    $.ajax({
        type: "POST",
        url: url,
        dataType: "json",
        data: Review,
        success: function (res) {
            console.log(res);
            toastr.success("Review has been added successfully");
            
        }, error: function (err) { console.error(err); }
    });
}
