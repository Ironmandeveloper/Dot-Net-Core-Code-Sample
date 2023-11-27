function removeFromCart(url, cartCount) {
    AmagiLoader.show();
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            if (res.isValid) {
                AmagiLoader.hide();
                $("#view-all").html(res.html);
                toastr.success("Product has been removed from cart", "Success");
                document.getElementById("cartCountSpan").innerHTML = "";
                $("#cartCountSpan").append(parseInt(cartCount - 1));
            }
            else
            {

            }
        }
    });
} 

function updateCart(url) {
    AmagiLoader.show();
    var cartArray = [];
    $('.myCls').each(
        function (index) {
            var input = $(this);
            cartArray.push({ 'CartId': input.attr('name'), 'Quantity': input.val() });
        }
    );
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(cartArray),
        contentType: 'application/json; charset=utf-8',
        success: function (res) {
            if (res.isValid) {
                AmagiLoader.hide();
                $("#view-all").html(res.html);
                toastr.success("Cart has been updated successfully", "Success");
            }
            else {

            }
        }
    });
}
function AddtoCart(id) {

    $.ajax({
        type: "GET",
        url: 'cart/AddToCart?Id='+id+"&qty="+$("#"+id).val(),
        success: function (res) {
            debugger
            console.log(res);
            toastr.success("Product has been added into cart", "Success");
            window.location.href = "/Cart/Index";
        },
        error: function (request, status, error) {
            console.log(request.responseText);
            toastr.success("Product has been added into cart", "Success");
        }
    });
}
//var count = 0;
//function incrementHandler(id,quantityTxtBoxId ,price) {
//    debugger
//    count = count + 1;
//    var qty = parseInt(document.getElementById('' + quantityTxtBoxId).value) + parseInt(count);
//    var Total = parseInt(price) * parseInt(qty);
//    document.getElementById("" + id).innerHTML = "$ " + Total;
//    return false;
//}
