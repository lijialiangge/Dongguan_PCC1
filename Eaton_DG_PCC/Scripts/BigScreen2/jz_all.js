//var doscroll = function () {
//    var $parent = $('.js-slide-list');
//    var $first = $parent.find('li:first');
//    var height = $first.height();
//    $first.animate({
//        marginTop: -height + 'px'  //或者改成： marginTop: -height + 'px'
//    }, 500, function () {// 动画结束后，把它插到最后，形成无缝
//        $first.css('marginTop', 0).appendTo($parent);
//        // $first.css('marginTop', 0).appendTo($parent);
//    });
//};

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



var doscroll_Maintenance = function () {
    var $parent = $('.js-slide-list-Maintenance');
    var $first = $parent.find('li:first');
    var height = $first.height();
    $first.animate({
        marginTop: -height + 'px'  //或者改成： marginTop: -height + 'px'
    }, 500, function () {// 动画结束后，把它插到最后，形成无缝
        $first.css('marginTop', 0).appendTo($parent);
        // $first.css('marginTop', 0).appendTo($parent);
    });
};

//setInterval(function () { doscroll() }, 2000);
setInterval(function () { doscroll_order() }, 33333);
setInterval(function () { doscroll_Maintenance() }, 6333);