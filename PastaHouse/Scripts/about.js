$('.photo-restaurant').backgroundMove();

$('.photo-restaurant').backgroundMove({
    movementStrength: '40'
});


var items_right = document.querySelectorAll(".right");
var items_left = document.querySelectorAll(".left");
var img_box = document.querySelectorAll(".img-box");


function isElementInViewport(el) {
    var rect = el.getBoundingClientRect();
    return (
        rect.top >= 0 &&
        rect.left >= 0 &&
        rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
        rect.right <= (window.innerWidth || document.documentElement.clientWidth)
    );
}

function callbackFunc() {
    for (var i = 0; i < items_right.length; i++) {
        if (isElementInViewport(items_right[i])) {
            items_right[i].classList.add("in-view");
            items_right[i].classList.add("animated");
            items_right[i].classList.add("fadeInRight");
        }

        if (isElementInViewport(items_left[i])) {
            items_left[i].classList.add("in-view");
            items_left[i].classList.add("animated");
            items_left[i].classList.add("fadeInLeft");
        }
    }

    for (var i = 0; i < img_box.length; i++) {
        if (isElementInViewport(img_box[i])) {
            img_box[i].classList.add("in-view");
            img_box[i].classList.add("animated");
            img_box[i].classList.add("fadeInLeft");
        }
    }
}

window.addEventListener("load", callbackFunc);
window.addEventListener("scroll", callbackFunc);