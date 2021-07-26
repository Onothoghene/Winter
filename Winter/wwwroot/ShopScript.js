//===Cart Count====//
function GetCartCount() {
    $.ajax({
        type: "GET",
        url: "/Home/GetNewArrivals/",
        data: { userId: e.target.value },
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data);
            data.forEach(
                res => {
                    const appendData = `<div class="single_arrivel_item weidth_3  mix shoes">
                        <img src="/Admin/DownloadDocument?Filename=${res.productFile[0].fileUniqueName}" height = "450" width = "45" />
                            <div class="hover_text">
                                <p>${res.category}</p>
                            <a href="/Shop/ProductDetails?ProductId=${res.productId}">
                                    <h3>${res.productName}</h3></a>
                                <h5>${res.unitPrice}</h5>
                                <div class="social_icon">
                                    <a href="#"><i class="ti-heart"></i></a>
                                    <a href="#"><i class="ti-shopping-cart-full"></i></a>
                                </div>
                            </div>
                            </div >`;
                    $('#NewArrivals').append(appendData);
                }
            )
        }, //End of AJAX Success function
        failure: function (data) {
            console.log(data)
        }, //End of AJAX failure function
        error: function (data) {
            console.log(data)
        } //End of AJAX error function
    });
}

function GetCartCount() {
    $.ajax({
        type: "GET",
        url: "/Shop/GetCartCount/",
        data: { userId: e.target.value },
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data);
            getNotificationMessages();
            $('#notificationCount').text(data);
            document.getElementById('notificationCount').textContent = data;
            if (data > 0) {
                $("#notificationBell").addClass("notificationBell")
            }
        }, //End of AJAX Success function
        failure: function (data) {
            console.log(data)
        }, //End of AJAX failure function
        error: function (data) {
            console.log(data)
        } //End of AJAX error function
    });
}

//===WishList Count====//
function GetWishListCount() {
    $.ajax({
        type: "GET",
        url: "/Home/GetNewArrivals",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data);
            data.forEach(
                res => {
                    const appendData = `<div class="single_arrivel_item weidth_3  mix shoes">
                        <img src="/Admin/DownloadDocument?Filename=${res.productFile[0].fileUniqueName}" height = "450" width = "45" />
                            <div class="hover_text">
                                <p>${res.category}</p>
                            <a href="/Shop/ProductDetails?ProductId=${res.productId}">
                                    <h3>${res.productName}</h3></a>
                                <h5>${res.unitPrice}</h5>
                                <div class="social_icon">
                                    <a href="#"><i class="ti-heart"></i></a>
                                    <a href="#"><i class="ti-shopping-cart-full"></i></a>
                                </div>
                            </div>
                            </div >`;
                    $('#NewArrivals').append(appendData);
                }
            )
        }, //End of AJAX Success function
        failure: function (data) {
            console.log(data)
        }, //End of AJAX failure function
        error: function (data) {
            console.log(data)
        } //End of AJAX error function
    });
}

window.addEventListener('load', (event) => {
    console.log('page is fully loaded');
    GetWishListCount();
    GetCartCount();
});