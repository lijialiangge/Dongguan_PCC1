

// 设置时间
let setTime = function() {
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









const myChart1 = echarts.init(document.getElementById("serviceTimeChart"));
const myChart2 = echarts.init(document.getElementById("gradeRateChart"));
//const myChart3 = echarts.init(document.getElementById("mapChart"));
const myChart4 = echarts.init(document.getElementById("situationAnalysisChart"));
//const myChart5 = echarts.init(document.getElementById("distributeByStatusChart"));
const myChart6 = echarts.init(document.getElementById("distributeByServerChart"));
// Monthly output
let serviceTimeChart = function() {
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
      right:'2%',
        top:'15%'
        
    },
    legend: {
        data: ["Monthly Output", "Monthly NG"],
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
          data: ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"],
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
        splitLine:{
          lineStyle:{
            color:'#242847'
          }
        }
      },
      
    ],
    series: [
      {
          name: "Monthly Output",
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
          data: [146, 130, 106, 180, 107, 160, 150, 140, 160, 170, 180, 190]
        //data: [146, 130, 106, 180, 107, 160, 150, 140, 160, 170, 180, 190, 146, 130, 106, 180, 107, 160, 150, 140, 160, 170, 180, 190]
      },
      {
          name: 'Monthly NG',
          type: 'line',
          itemStyle: {
              color: '#ff00ff',
          },
          data: [10, 15, 34, 54, 12, 31, 12, 10, 41, 21, 22, 40]
      },






      //{
      //    name: "NG",
      //    type: "bar",
      //    itemStyle: {
      //        color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [
      //          {
      //              offset: 0,
      //              color: "#0182e8"
      //          },
      //          {
      //              offset: 1,
      //              color: "#021b4d"
      //          }
      //        ]),
      //        barBorderRadius: 5
      //    },
      //    barWidth: "10px",
      //    data: [46, 30, 16, 18, 17, 16, 50, 40, 60, 70, 18, 90]
      //    //data: [146, 130, 106, 180, 107, 160, 150, 140, 160, 170, 180, 190, 146, 130, 106, 180, 107, 160, 150, 140, 160, 170, 180, 190]
      //},
    ]
  };
  myChart1.setOption(option);
};
serviceTimeChart();

// Top 5 Type Ratio
let gradeRateChart = function() {
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
          text: [60000],
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
            value: 80000,
            name: "1A",
            itemStyle:{
                color: '#00ff21'
            }           
          },
          {
              value: 60000,
              name: "4A",
            itemStyle:{
                color: '#00FFFF'
            }  
          },
          {
              value: 20000,
              name: "5A",
            itemStyle:{
                color: '#ff0'
            } 
          },
          { value: 10000, name: "0.5A",
            itemStyle:{
                color: '#ff6a00'
            } 
          },
          { value: 8000, name: "3A",
            itemStyle:{
                color: '#ff0000'
            } 
         }
        ]
      }
    ]
  };
  myChart2.setOption(option);
};
gradeRateChart();

//map
//let mapChart = function() {
//  function randomData() {
//    return Math.round(Math.random() * 1000);
//  }
//  let option = {
//    tooltip: {
//      trigger: "item"
//    },
//    series: [
//      {
//        name: "Device",
//        type: "map",
//        mapType: "china",
//        roam: false,
//        label: {
//          normal: {
//            show: true
//          },
//          emphasis: {
//            show: true
//          }
//        },
        
//        itemStyle:{
//          areaColor:'#0347ad',
//          borderColor:"#0ec7ff",
//        },
//        data: [
//          { name: "北京", value: randomData() },
//          { name: "天津", value: randomData() },
//          { name: "上海", value: randomData() },
//          { name: "重庆", value: randomData() },
//          { name: "河北", value: randomData() },
//          { name: "河南", value: randomData() },
//          { name: "云南", value: randomData() },
//          { name: "江苏", value: randomData() },
//          { name: "深圳", value: randomData() },
//          { name: "辽宁", value: randomData() }
//        ]
//      },
//    ]
//  };


  

//  myChart3.setOption(option);
//};
//mapChart();
//Everyday Output & NG 
let situationAnalysisChart = function() {
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
        left: "8%",
        right: '2%',
      bottom: "10%"
    },
    legend: {
        data: ["Everyday Output", "Everyday NG"],
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
          //data: ["北京市", "天津市", "上海市", "广州市", "深圳市", "芜湖市", "郑州市", "南京市", "广西市", "西宁市", "西昌市", "洛阳市"],
        data: ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"],
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
        name: "Everyday Output",
        
        axisLabel: {
          formatter: "{value}"
        }
      }
    ],
    series: [
      {
          name: 'Everyday Output',
        type:'bar',
        barWidth : 10,
        stack: '数量',
        itemStyle:{
          color:'#0190fc',
        },
        data: [11000, 12000, 13000, 14000, 15000, 16000, 17000, 18000, 19000, 20000, 20001, 20002, 21000, 22000, 10002, 13000, 14000, 10005, 16000, 10007, 18000, 19000, 20000, 20001, 20002, 21000, 22000, 20001, 22000, 20001, 22000]
      },
      
      
      {
          name: 'Everyday NG',
        type:'line',
        itemStyle:{
          color:'#ff9f25',
        },
        data: [1000, 5008, 2100, 1200, 1400, 3800, 1200, 1000, 5004, 7008, 3002, 8700, 3002, 8007, 2003, 2003, 2004, 2005, 2006, 2700, 2800, 2009, 3000, 3100, 3200, 3001, 3002, 5008, 2001, 1002, 1004]
      },
    ]
  };
  myChart4.setOption(option);
};
situationAnalysisChart();

//故障状态分布
//let distributeByStatusChart = function() {
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
//          text: 141,
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
//          length:20,
//          length2:50,
//          lineStyle:{
//            color:'#15a7f1',
//          }
//        },
//        data: [
//          {
//            value: 50,
//            name: "待处理",
//            itemStyle:{
//              color:'#162959'
//            }
//          },
//          { value: 32, name: "已处理",
//            itemStyle:{
//              color:'#1ac2fa'
//            }
//          },
//          { value: 58, name: "处理中",
//            itemStyle:{
//              color:'#23548b'
//            }
//          }
//        ]
//      }
//    ]
//  };
//  myChart5.setOption(option);
//};
//distributeByStatusChart();
//保修服务分布
let distributeByServerChart = function() {
  let option = {
    tooltip: {},
    
    radar: [
        {
            indicator: [
                { text: 'CCD Scan', max: 50 },
                { text: 'Mark' ,max:50},
                { text: 'Loading', max: 50 },
                { text: 'Unloading', max: 50 },
                { text: 'Test station' ,max:50},
                { text: 'Laser  Mark', max: 50 },
                { text: 'Pack',max:50 }
            ],
                       
            startAngle: 30,
            splitNumber: 4,
            shape: 'circle',
            name: {
                formatter:'{value}',
                textStyle: {
                    color:'#1ab1ef'
                }
            },
            splitArea: {
                show:true,
                areaStyle: {
                    color: ['#051d64','#041d64', '#03185f','#021358'],
                    shadowColor: '#0f3ba8',
                    shadowBlur: 10
                }
            },
            axisLine: {
                lineStyle: {
                    color: '#2c8ebe',
                    type:'dashed'
                }
            },
            splitLine: {
                lineStyle: {
                    color: 'transparent'
                }
            }
        },
        
    ],
    series: [
        {
            name: 'Fault Point Distribution',
            type: 'radar',
            itemStyle: {
              color:'#1f9cf5',
            },
            label: {
              normal: {
                  show: true,
                  color:'white',
              }
            },
            areaStyle: {
              normal: {
                  opacity: 0.7,
                  color: new echarts.graphic.RadialGradient(0.5, 0.5, 1, [
                      {
                          color: '#093574',
                          offset: 0
                      },
                      {
                          color: '#093574',
                          offset: 1
                      }
                  ])
              }
            },
            data: [
                {
                    //value: [21, 31, 25, 34, 12,21],
                    value: [21, 31, 25, 24, 32, 34, 42],
                }
            ]
        },
        
    ]
  }
  myChart6.setOption(option);
};
distributeByServerChart();


//图例适应屏幕变化
let chartResize = function(){
  myChart1.resize();
  myChart2.resize();
  myChart3.resize();
  myChart4.resize();
  //myChart5.resize();
  myChart6.resize();
}
window.onresize = debounce(chartResize, 500);

