


// 设置时间
let setTime = function () {
  let res = getCurrentTime();
  $(".currentTime").text(res.currentTime);
  $(".currentDate").text(res.currentDate);
  $(".currentWeek").text(res.currentWeek);
};
setTime();

// 定时更新时间
let timing = function() {
  setInterval(function() {
    setTime();
  }, 1000);
};
timing();





const myChart1 = echarts.init(document.getElementById("ContrastMonthlyOutputChart"));

//const myChart2 = echarts.init(document.getElementById("gradeRateChart"));
//const myChart3 = echarts.init(document.getElementById("topNGChart"));

const myChart4 = echarts.init(document.getElementById("Top5AlarmTimesChart"));
var jz_top6_zhe = echarts.init(document.getElementById('jz_top6_zhe'), 'dark');

var myChart6 = echarts.init(document.getElementById('main6'));
Top5NGRatio();


//const myChart5 = echarts.init(document.getElementById("distributeByStatusChart"));
//const myChart6 = echarts.init(document.getElementById("distributeByServerChart"));
// Monthly output
let ContrastMonthlyOutputChart = function () {
    let option = {
        tooltip: {
            trigger: "axis",
            axisPointer: {
                type: "cross",
                crossStyle: {
                    color: "white"
                }
            }
        },
        textStyle: {
            color: "#a0a8b9"
        },
        grid: {
            left: "10%",
            bottom: "16%",
            right: '2%',
            top: '15%'

        },
        legend: {
            data: ["Output", "NG"],
            textStyle: {
                color: "#929aad"
            },
            right: "2%",
            top: "0%"
        },
        xAxis: [
          {
              type: "category",
              name: "",
              //data: ["政治", "语文", "数学", "思想课", "地理", "化学", "物理", "生物", "自然", "体育", "美术", "音乐"],
              data: ["PCTron", "DRAQ75", "DRAQ1278", "DRAQ1276", "DRAQ1243", "DRAQ1251", "DRAQ1261", "DRAQ128", "DRAQ129", "DRAQ126"],
              //data: ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"],
              axisPointer: {
                  type: "shadow"
              },
              axisLabel: {
                  formatter: "{value}"
              }
          }
        ],
        yAxis: [
          {
              type: "value",
              name: "Monthly Output",
              min: 0,
              max: 250,
              interval: 50,
              axisLabel: {
                  formatter: "{value} K"
              },
              splitLine: {
                  lineStyle: {
                      color: '#242847'
                  }
              }
          },

        ],
        series: [
          {
              name: "Output",
              type: "bar",
              itemStyle: {
                  color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [
                    {
                        offset: 0,
                        color: "#0182e8"
                    },
                    {
                        offset: 1,
                        color: "#021b4d"
                    }
                  ]),
                  barBorderRadius: 5
              },
              barWidth: "10px",
              data: [146, 130, 106, 180, 107, 160, 150, 140, 160, 170]
              //data: [146, 130, 106, 180, 107, 160, 150, 140, 160, 170, 180, 190, 146, 130, 106, 180, 107, 160, 150, 140, 160, 170, 180, 190]
          },
          {
              name: 'NG',
              type: 'line',
              itemStyle: {
                  color: '#ff00ff',
              },
              data: [10, 15, 34, 54, 12, 31, 12, 10, 41, 21]
          },




        ]
    };
    myChart1.setOption(option);
};
ContrastMonthlyOutputChart();


// Top 5 Type Ratio
//let gradeRateChart = function() {
//  let option = {
//    tooltip: {
//      trigger: 'item',
//      formatter: "{a} <br/>{b}: {c} ({d}%)"
//    },
//    graphic:{
//      type: 'text',
//      left: 'center', // 相对父元素居中
//      top: 'middle',  // 相对父元素居中
//      style: {
//          fill: 'white',
//          text: [60000],
//          fontSize: '28',        
//      }
//    },
//    series: [
//      {
//        name: "",
//        type: "pie",
//        hoverAnimation: true,
//        radius: ["50%", "70%"],
//        avoidLabelOverlap: false,
//        label: {
//          formatter:'{a|{d}%}\n{b}',
//          show: true,
//          position: "outside",
//          color:'#15a7f1',
//          verticalAlign:'top',
//          rich:{
//            a:{
//              color: 'white',
//              lineHeight: 22,
//              align: 'left',
//            },
            
//          }
//        },
//        labelLine: {
//          show: true,
//          length:10,
//          length2:50,
//          lineStyle:{
//            color:'#15a7f1',
//          }
//        },
//        data: [
//          {
//            value: 80000,
//            name: "1A",
//            itemStyle:{
//                color: '#00ff21'
//            }           
//          },
//          {
//              value: 60000,
//              name: "4A",
//            itemStyle:{
//                color: '#00FFFF'
//            }  
//          },
//          {
//              value: 20000,
//              name: "5A",
//            itemStyle:{
//                color: '#ff0'
//            } 
//          },
//          { value: 10000, name: "0.5A",
//            itemStyle:{
//                color: '#ff6a00'
//            } 
//          },
//          { value: 8000, name: "3A",
//            itemStyle:{
//                color: '#ff0000'
//            } 
//         }
//        ]
//      }
//    ]
//  };
//  myChart2.setOption(option);
//};
//gradeRateChart();

// top5NGChart
//let topNGChart = function () {
//    let option = {
//        tooltip: {
//            trigger: 'item',
//            formatter: "{a} <br/>{b}: {c} ({d}%)"
//        },
//        graphic:{
//            type: 'text',
//            left: 'center', // 相对父元素居中
//            top: 'middle',  // 相对父元素居中
//            style: {
//                fill: 'white',
//                text: [80000],
//                fontSize: '28',        
//            }
//        },
//        series: [
//          {
//              name: "",
//              type: "pie",
//              hoverAnimation: true,
//              radius: ["50%", "70%"],
//              avoidLabelOverlap: false,
//              label: {
//                  formatter:'{a|{d}%}\n{b}',
//                  show: true,
//                  position: "outside",
//                  color:'#15a7f1',
//                  verticalAlign:'top',
//                  rich:{
//                      a:{
//                          color: 'white',
//                          lineHeight: 22,
//                          align: 'left',
//                      },
            
//                  }
//              },
//              labelLine: {
//                  show: true,
//                  length:10,
//                  length2:50,
//                  lineStyle:{
//                      color:'#15a7f1',
//                  }
//              },
//              data: [
//                {
//                    value: 80000,
//                    name: "PCTron",
//                    itemStyle:{
//                        color: '#00ff21'
//                    }           
//                },
//                {
//                    value: 60000,
//                    name: "DRAQ75",
//                    itemStyle:{
//                        color: '#00FFFF'
//                    }  
//                },
//                {
//                    value: 20000,
//                    name: "DRAQ127",
//                    itemStyle:{
//                        color: '#ff0'
//                    } 
//                },
//                { value: 10000, name: "DRAQ124",
//                    itemStyle:{
//                        color: '#ff6a00'
//                    } 
//                },
//                { value: 8000, name: "DRAQ126",
//                    itemStyle:{
//                        color: '#ff0000'
//                    } 
//                }
//              ]
//          }
//        ]
//    };
//    myChart3.setOption(option);
//};
//topNGChart();

// Top5AlarmTimesChart
let Top5AlarmTimesChart = function () {

    let option = {
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b}: {c} ({d}%)"
        },
        graphic:{
            type: 'text',
            left: 'center', // 相对父元素居中
            top: 'middle',  // 相对父元素居中
            style: {
                fill: 'white',
                text: [256],
                fontSize: '28',        
            }
        },
        series: [
          {
              name: "",
              type: "pie",
              hoverAnimation: true,
              radius: ["50%", "70%"],
              avoidLabelOverlap: false,
              label: {
                  formatter:'{a|{d}%}\n{b}',
                  show: true,
                  position: "outside",
                  color:'#15a7f1',
                  verticalAlign:'top',
                  rich:{
                      a:{
                          color: 'white',
                          lineHeight: 22,
                          align: 'left',
                      },
            
                  }
              },
              labelLine: {
                  show: true,
                  length:10,
                  length2:50,
                  lineStyle:{
                      color:'#15a7f1',
                  }
              },
              data: [
                {
                    value: 500,
                    name: "PCTron",
                    itemStyle:{
                        color: '#00ff21'
                    }           
                },
                {
                    value: 188,
                    name: "DRAQ75",
                    itemStyle:{
                        color: '#00FFFF'
                    }  
                },
                {
                    value: 146,
                    name: "DRAQ127",
                    itemStyle:{
                        color: '#ff0'
                    } 
                },
                { value: 89, name: "DRAQ125",
                    itemStyle:{
                        color: '#ff6a00'
                    } 
                },
                { value: 88, name: "DRAQ126",
                    itemStyle:{
                        color: '#ff0000'
                    } 
                }
              ]
          }
        ]
    };
    myChart4.setOption(option);
};
Top5AlarmTimesChart();



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
        data: ['Run', 'Alarm'],
        textStyle: {
            color: '#fff',
        }
    },
    toolbox: {
        //是否显示侧边工具栏
        //show:true,
        show: false,
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
        data: ["PCTron", "DRAQ75", "DRAQ1278", "DRAQ1276", "DRAQ1243", "DRAQ1251", "DRAQ1261", "DRAQ128", "DRAQ129", "DRAQ126"],

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
                fontSize: 12,
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
        name: 'Run',
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
        data: [2000, 122, 3121, 54, 60, 2630, 1150, 2442, 1292, 122]
    }, {
        name: 'Alarm',
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
                    color: 'rgba(255, 255, 0, 0.9)'
                }, {
                    offset: 0.8,
                    color: 'rgba(255, 255, 0, 0.4)'
                }], false),
                shadowColor: 'rgba(0, 0, 0, 0.9)',
                shadowBlur: 10
            }
        },
        itemStyle: {
            normal: {
                color: 'rgb(255,255,0)'

            }
        },
        data: [1130, 812, 1134, 2361, 413, 1330, 1301, 594, 1230, 2361]
    },

    ] //series结束
}; // option结束
//------------------------------------------------

function Top5NGRatio() {
var schoolName = ['PCTron', 'DRAQ75', 'DRAQ127', 'DRAQ124-100R', 'DRAQ124-200R'], resourceCnt = [44, 20,50,17, 80],  max = 100;
var maxData = [max, max, max, max, max];
option6 = {
    grid: {
        left: '30',
        top: '0',
        right: '0',
        bottom: '0',
        containLabel: true
    },
    xAxis: [{
        show: false,
                
    }],
    yAxis: [{
        splitLine: { show: false },
        axisLine: {
            show: false,
            lineStyle: {
                color: '#1798cf'
            }
        },
        axisLabel: {
            fontSize: '16'

        },
        axisTick: {
            show: false
        },
        offset: 20,
        data: schoolName
    }, {
        splitLine: { show: false },
        axisLine: {
            show: false,
            lineStyle: {
                color: '#fff'
            }
        },
        axisLabel: {
            fontSize: '24',
            fontFamily: 'myFirstFont',
            formatter: "{value}  %"
                    
        },
        axisTick: {
            show: false
        },
        offset: 50,
        data: resourceCnt
    }, {
        name: '',
        nameGap: '50',
        nameTextStyle: {
            color: '#ffffff',
            fontSize: '24'
        },
        axisLine: {
            lineStyle: {
                color: 'rgba(0,0,0,0)'
            }
        },
        data: []
    }],
    series: [{
        name: '条',
        type: 'bar',
        yAxisIndex: 0,
        data: resourceCnt,
        label: {
            normal: {
                show: false,
                position: 'right',
                formatter: function (param) {
                    // return param.value + '%';
                    return param.value;
                },
                textStyle: {
                    color: '#fff',
                    fontSize: '16'
                }
            }
        },
        barWidth: 6,
        itemStyle: {
            normal: {
                barBorderRadius: 6,
                color: new echarts.graphic.LinearGradient(0, 0, 1, 0, [{
                    offset: 0,
                    color: '#1d6bf1'
                }, {
                    offset: 1,
                    color: '#1ad0fc'
                }])
            }
        },
        z: 2
    }, {
        name: '白框',
        type: 'bar',
        yAxisIndex: 1,
        barGap: '-100%',
        data: maxData,
        barWidth: 10,
        itemStyle: {
            normal: {
                color: '#0a182e',
                barBorderRadius: 10
            }
        },
        z: 1
    }, {
        name: '外框',
        type: 'bar',
        yAxisIndex: 2,
        barGap: '-100%',
        data: maxData,
        barWidth: 12,
        itemStyle: {
            normal: {
                color: "#4e6a8c",
                borderColor: '#4e6a8c',
                barBorderRadius: 12
            }
        },
        z: 0
    }, {
        name: '内圆',
        type: 'scatter',
        hoverAnimation: false,
        data: [0, 0, 0, 0, 0],
        yAxisIndex: 2,
        symbolSize: 14,
        itemStyle: {
            normal: {
                color: '#1367fb',
                opacity: 1
            }
        },
        z: 3
    }, {
        name: '外圆',
        type: 'scatter',
        hoverAnimation: true,
        data: [0, 0, 0, 0, 0],
        yAxisIndex: 2,
        symbolSize: 20,
        itemStyle: {
            normal: {
                color: '#0a182e',
                borderColor: '#4e6a8c',
                opacity: 1
            }
        },
        z: 0
    }]
};
var option6Index = -1;
myChart6.setOption(option6);
}

//------------------------------------------------








// 使用刚指定的配置项和数据显示图表。

jz_top6_zhe.setOption(option_jz_top6_zhe);


//图例适应屏幕变化
let chartResize = function(){
  myChart1.resize();
  //myChart2.resize();
  myChart3.resize();
  myChart4.resize();
}
window.onresize = debounce(chartResize, 500);

