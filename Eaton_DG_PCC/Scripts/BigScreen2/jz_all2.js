

var doscroll_order = function () {
    var $parent = $('.js-slide-list-order');
    var $first = $parent.find('li:first');
    var height = $first.height();
    $first.animate({
        marginTop: -height + 'px'  //或者改成： marginTop: -height + 'px'
    }, 500, function () {// 动画结束后，把它插到最后，形成无缝
        $first.css('marginTop', 0).appendTo($parent);
        // $first.css('marginTop', 0).appendTo($parent);
    });
};

var doscroll_order2 = function () {
    var $parent = $('.js-slide-list-order2');
    var $first = $parent.find('li:first');
    var height = $first.height();
    $first.animate({
        marginTop: -height + 'px'  //或者改成： marginTop: -height + 'px'
    }, 500, function () {// 动画结束后，把它插到最后，形成无缝
        $first.css('marginTop', 0).appendTo($parent);
        // $first.css('marginTop', 0).appendTo($parent);
    });
};

var doscroll_order3 = function () {
    var $parent = $('.js-slide-list-order3');
    var $first = $parent.find('li:first');
    var height = $first.height();
    $first.animate({
        marginTop: -height + 'px'  //或者改成： marginTop: -height + 'px'
    }, 500, function () {// 动画结束后，把它插到最后，形成无缝
        $first.css('marginTop', 0).appendTo($parent);
        // $first.css('marginTop', 0).appendTo($parent);
    });
};

//----------加1--------------------------------------
var i = 0;
var Days = function add() {
    i++;
    alert(i);
}


setInterval(function () { doscroll_order() }, 2000);
setInterval(function () { doscroll_order2() }, 2000);
setInterval(function () { doscroll_order3() }, 2000);
//setInterval(function () { Days() }, 5000);

//------------------------------------------------


    

