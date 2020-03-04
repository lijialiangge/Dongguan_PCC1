var doscroll = function () {
    var $parent = $('.js-slide-list');
    var $first = $parent.find('li:first');
    var height = $first.height();
    $first.animate({
        marginTop: -height + 'px'  //或者改成： marginTop: -height + 'px'
    }, 500, function () {// 动画结束后，把它插到最后，形成无缝
        $first.css('marginTop', 0).appendTo($parent);
        // $first.css('marginTop', 0).appendTo($parent);
    });
};

setInterval(function () { doscroll() }, 2000);

var top3_center_tu = echarts.init(document.getElementById('top3_center_tu'), 'dark');
var jz_left_top5 = echarts.init(document.getElementById('jz_left_top5'), 'dark');
var jz_top6_zhe = echarts.init(document.getElementById('jz_top6_zhe'), 'dark');
// var jz_content_top = echarts.init(document.getElementById('jz_content_top'), 'dark');
// var jz_right_top = echarts.init(document.getElementById('jz_right_top'), 'dark');
// var jz_right_center = echarts.init(document.getElementById('jz_right_center'), 'dark');
// var jz_right_center2 = echarts.init(document.getElementById('jz_right_center2'), 'dark');
// var jz_right_center3 = echarts.init(document.getElementById('jz_right_center3'), 'dark');


option_top3_center_tu = {
    color: ['#00ffff', '#00ffa2', '#f0e750'],
    tooltip: {
        trigger: 'axis',
        textStyle: {
            fontSize: 15,
            color: "#fff",
        }
    },
    legend: {
        orient: 'horizontal',
        right: "4%",
        itemGap: 20,
        //itemWidth:16,
        //itemHeight:12,
        data: ['高危'],
        textStyle: {
            color: '#fff',
        }
    },
    toolbox: {
        show: false,
        orient: 'vertical',
        right: 'right',
        top: '20%',
        itemGap: 20,
        feature: {
            magicType: {
                show: false,
                type: ['line', 'bar']
            },
            restore: {
                show: false
            },
            saveAsImage: {
                show: false
            }
        },
        iconStyle: {
            normal: {
                color: '#0390e9'
            }
        }
    },
    grid: {
        show: true,
        left: 60,
        top: 34,
        right: 44,
        bottom: 42,
        borderWidth: 1,
        borderColor: 'rgba(170,172,178,0.33)',
        backgroundColor: 'rgba(17, 34, 69, 0.24)',
    },
    calculable: true,
    xAxis: [{
        type: 'category',
        boundaryGap: false,
        //在（type: 'category'）中设置data有效
        data: ['00:00:00', '03:00:00', '06:00:00', '09:00:00', '12:00:00',
            '15:00:00', '18:00:00', '21:00:00', '00:00:00'
        ],

        splitLine: { //坐标轴在 grid 区域中的分隔线；
            show: true,
            lineStyle: { //分割线颜色，可设单个，也可以设置数组。
                color: 'rgba(170,172,178,0.33)'
            }
        },
        axisLine: { //坐标轴轴线相关设置。就是数学上的x轴
            show: true,
            lineStyle: {
                color: 'rgba(170,172,178,0.53)'
            },
        },
        axisLabel: {
            textStyle: {
                color: 'rgba(255,255,255,0.83)',
                fontSize: 15,
            },
        },
    }],
    yAxis: [{
        type: 'value',
        min: 0,
        max: 30,
        splitLine: {
            show: true,
            lineStyle: {
                color: 'rgba(170,172,178,0.33)'
            }
        },
        axisLine: { //坐标轴轴线相关设置。就是数学上的y轴
            show: true,
            lineStyle: {
                color: 'rgba(170,172,178,0.53)'
            },
        },
        axisLabel: {
            textStyle: {
                color: 'rgba(255,255,255,0.83)',
                fontSize: 12,
            },
        },
        splitArea: {
            show: true,
            areaStyle: {
                color: ['#112245', 'rgba(34,50,82,0.4)']
            }
        }
    }],
    series: [{
        name: '高危',
        type: 'line',
        smooth: true, //是否平滑曲线显示
        lineStyle: { //线条样式
            normal: {
                width: 1
            }
        },
        areaStyle: { //区域填充样式
            normal: {
                //线性渐变，前4个参数分别是x0,y0,x2,y2(范围0~1);相当于图形包围盒中的百分比。如果最后一个参数是‘true’，则该四个值是绝对像素位置。
                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                    offset: 0,
                    color: 'rgba(0, 255, 255, 0.9)'
                }, {
                    offset: 0.7,
                    color: 'rgba(0, 255, 255, 0.6)'
                }], false),

                shadowColor: 'rgba(0, 0, 0, 0.9)', //阴影颜色
                shadowBlur: 10 //shadowBlur设图形阴影的模糊大小。配合shadowColor,shadowOffsetX/Y, 设置图形的阴影效果。
            }
        },
        itemStyle: { //折现拐点标志的样式
            normal: {
                color: 'rgb(0,255,255)'
            }
        },
        data: [2, 12, 3, 5, 6, 2, 11, 24, 12]
    }

    ] //series结束
}; // option结束

option_jz_left_top6 = {
    title: {
        text: ''
    },
      textStyle: {
        color: "#ffffff"
    },
    tooltip: {
        trigger: 'axis',
        axisPointer: { // 坐标轴指示器，坐标轴触发有效
            type: 'shadow' // 默认为直线，可选为：'line' | 'shadow'
        }
    },
    legend: {
        data: ['包租费', '装修费', '保洁费', '物业费'],
        align: 'right',
        right: 10
    },
    grid: {
        left: '3%',
        right: '4%',
        bottom: '3%',
        containLabel: true
    },
    xAxis: [{
        type: 'category',
        data: ['PCTron', 'DRAQ75', 'DRAQ127', 'PM-10000', 'PM-20000']
    }],
    yAxis: [{
        type: 'value',
        name: '总价(万元)',
        axisLabel: {
            formatter: '{value}'
        }
    }],
    series: [{
        name: '包租费',
        type: 'bar',
        data: [20, 12, 31, 34, 31],
       itemStyle: {
                normal: {
                    color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                        offset: 0,
                        color: 'rgba(207, 8,255, 1)'
                    }, {
                        offset: 1,
                        color: 'rgba(17, 99,198, 0.4)'
                    }]),
                    shadowColor: 'rgba(0, 0, 0, 0.1)',
                    shadowBlur: 10
                },

            }
    }, {
        name: '装修费',
        type: 'bar',
        data: [10, 20, 5, 9, 3],
         itemStyle: {
                normal: {
                    color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                        offset: 0,
                        color: 'rgba(0, 215,252, 1)'
                    }, {
                        offset: 1,
                        color: 'rgba(0, 215,252, 0.4)'
                    }]),
                    shadowColor: 'rgba(0, 0, 0, 0.6)',
                    shadowBlur: 10
                },

            }
    }, ]
   
};




// -----------------------折线图--------------------------
option_jz_top6_zhe = {
    color: ['#00ffff', '#00ffa2', '#f0e750'],
    tooltip: {
        trigger: 'axis',
        textStyle: {
            fontSize: 15,
            color: "#fff",
        }
    },
    legend: {
        orient: 'horizontal',
        right: "4%",
        itemGap: 20,
        //itemWidth:16,
        //itemHeight:12,
        data: ['订单量', '提货量'],
        textStyle: {
            color: '#fff',
        }
    },
    toolbox: {
        show: true,
        orient: 'vertical',
        right: 'right',
        top: '20%',
        itemGap: 20,
        feature: {
            magicType: {
                show: true,
                type: ['line', 'bar']
            },
            restore: {
                show: true
            },
            saveAsImage: {
                show: true
            }
        },
        iconStyle: {
            normal: {
                color: '#0390e9'
            }
        }
    },
    grid: {
        show: true,
        left: 60,
        top: 34,
        right: 44,
        bottom: 42,
        borderWidth: 1,
        borderColor: 'rgba(170,172,178,0.33)',
        backgroundColor: 'rgba(17, 34, 69, 0.24)',
    },
    calculable: true,
    xAxis: [{
        type: 'category',
        boundaryGap: false,
        //在（type: 'category'）中设置data有效
        data: ['00:00:00', '03:00:00', '06:00:00', '09:00:00', '12:00:00',
            '15:00:00', '18:00:00', '21:00:00', '00:00:00'
        ],

        splitLine: { //坐标轴在 grid 区域中的分隔线；
            show: true,
            lineStyle: { //分割线颜色，可设单个，也可以设置数组。
                color: 'rgba(170,172,178,0.33)'
            }
        },
        axisLine: { //坐标轴轴线相关设置。就是数学上的x轴
            show: true,
            lineStyle: {
                color: 'rgba(170,172,178,0.53)'
            },
        },
        axisLabel: {
            textStyle: {
                color: 'rgba(255,255,255,0.83)',
                fontSize: 15,
            },
        },
    }],
    yAxis: [{
        type: 'value',
        min: 0,
        max: 4000,
        splitLine: {
            show: true,
            lineStyle: {
                color: 'rgba(170,172,178,0.33)'
            }
        },
        axisLine: { //坐标轴轴线相关设置。就是数学上的y轴
            show: true,
            lineStyle: {
                color: 'rgba(170,172,178,0.53)'
            },
        },
        axisLabel: {
            textStyle: {
                color: 'rgba(255,255,255,0.83)',
                fontSize: 12,
            },
        },
        splitArea: {
            show: true,
            areaStyle: {
                color: ['#112245', 'rgba(34,50,82,0.4)']
            }
        }
    }],
    series: [{
                name: '订单量',
                type: 'line',
                smooth: true, //是否平滑曲线显示
                lineStyle: { //线条样式
                    normal: {
                        width: 1
                    }
                },
                areaStyle: { //区域填充样式
                    normal: {
                        //线性渐变，前4个参数分别是x0,y0,x2,y2(范围0~1);相当于图形包围盒中的百分比。如果最后一个参数是‘true’，则该四个值是绝对像素位置。
                        color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                            offset: 0,
                            color: 'rgba(0, 255, 255, 0.9)'
                        }, {
                            offset: 0.7,
                            color: 'rgba(0, 255, 255, 0.6)'
                        }], false),

                        shadowColor: 'rgba(0, 0, 0, 0.9)', //阴影颜色
                        shadowBlur: 10 //shadowBlur设图形阴影的模糊大小。配合shadowColor,shadowOffsetX/Y, 设置图形的阴影效果。
                    }
                },
                itemStyle: { //折现拐点标志的样式
                    normal: {
                        color: 'rgb(0,255,255)'
                    }
                },
                data: [2000, 122, 3121, 54, 60, 2630, 1150, 2442, 1292]
            }, {
                name: '提货量',
                type: 'line',
                smooth: true,
                lineStyle: {
                    normal: {
                        width: 1
                    }
                },
                areaStyle: {
                    normal: {
                        color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                            offset: 0,
                            color: 'rgba(240, 231, 80, 0.9)'
                        }, {
                            offset: 0.8,
                            color: 'rgba(240, 231, 80, 0.4)'
                        }], false),
                        shadowColor: 'rgba(0, 0, 0, 0.9)',
                        shadowBlur: 10
                    }
                },
                itemStyle: {
                    normal: {
                        color: 'rgb(240,231,80)'

                    }
                },
                data: [1130, 812, 1134, 2361, 413, 1330, 1301, 594, 1230]
            },

        ] //series结束
}; // option结束
//------------------------------------------------

// 使用刚指定的配置项和数据显示图表。
top3_center_tu.setOption(option_top3_center_tu);
jz_left_top5.setOption(option_jz_left_top6);
jz_top6_zhe.setOption(option_jz_top6_zhe);
// jz_content_top.setOption(option_jz_content_top);
// jz_right_top.setOption(option_jz_right_top);
// jz_right_center.setOption(option_jz_right_center);
// jz_right_center2.setOption(option_jz_right_center2);
// jz_right_center3.setOption(option_jz_right_center3);
