//===New Arrivals====//
function GetNewArrivals() {
    $.ajax({
        type: "GET",
        url: "/Home/GetNewArrivals",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data);
            data.forEach(
                res => {
                    const appendData = `<div class="single_arrivel_item weidth_3  mix shoes">
                        <img src="/File/DownloadDocument?Filename=${res.productFile[0].fileUniqueName}" height = "450" width = "45" />
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


//===Random Products====//
function GetRandomProducts() {
    $.ajax({
        type: "GET",
        url: "/Home/GetRandomProducts",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data);
            data.forEach(
                res => {
                    console.log(res.id)
                    const appendData =
                        ` <div class="single_instgram_photo">
                        <imgsrc="/File/DownloadDocument?Filename=${res.productFile[0].fileUniqueName}" alt="">
                        <a  href="/Shop/ProductDetails?ProductId=${res.productId}"><i class="ti-instagram"></i></a>
                    </div>`;
                    $('#RandomProducts').append(appendData);
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

//===== Windows Load =====//
//$(window).on("load", function () {
//    console.log("window loaded");
//    GetNewArraivals();
//    GetRandomProducts();
//});

window.addEventListener('load', (event) => {
    console.log('page is fully loaded');
    GetNewArrivals();
    GetRandomProducts();
});