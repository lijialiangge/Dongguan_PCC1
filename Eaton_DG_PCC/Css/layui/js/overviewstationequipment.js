// JavaScript Document
$(function(){
		   
	// 驻点设备总览初始化六个图标接口
	//1、初始化驻点报警对比 饼图, 如果需要参数，自由添加参数
	warning_compare_pie_charts();
	
	//3、初始化驻点报警柱形图 如果需要参数，自由添加参数
	warning_column_shape_charts();
	//4、初始化报警饼状图 如果需要参数，自由添加参数
	warning1_pie_charts();
	//6、初始化时长异常数量柱形图 如果需要参数，自由添加参数
	column_time_difference_charts();
	layui.use(['table', 'form', 'laydate'], function(){
		  var table = layui.table;
		  var form = layui.form;
		  var laydate = layui.laydate;
		  //2、初始化 信息总览表格 如果需要参数，自由添加参数
		  get_overview_information_tab_list(table, 6, "day", "");
		  //5、初始化报警饼状图内置表格 如果需要参数，自由添加参数
		  get_warning_count_tab_list(table, 6, "day", "");
		  // 监控表单搜索按钮
		  
		  form.on('submit(search-devices-infomation)', function(data) {
			  var date_type = data.field.search_way;
			  var start_time = data.field.start_time;
			  //1、搜索查询驻点报警对比 饼图, 如果需要参数，自由添加参数
			  warning_compare_pie_charts(date_type, start_time);
			  //2、搜索查询 信息总览表格 如果需要参数，自由添加参数
		      get_overview_information_tab_list(table, 6, date_type, start_time);
			  //3、搜索查询 驻点报警柱形图 如果需要参数，自由添加参数
			  warning_column_shape_charts(date_type, start_time);
			  //4、搜索查询 报警饼状图 如果需要参数，自由添加参数
			  warning1_pie_charts(date_type, start_time);
			  //5、搜索查询 报警饼状图内置表格 如果需要参数，自由添加参数
		      get_warning_count_tab_list(table, 6, date_type, start_time);
			  //6、搜索查询 时长异常数量柱形图 如果需要参数，自由添加参数
			  column_time_difference_charts(date_type, start_time);
		  });
		  
		  
		  // 格式化时间
		  laydate.render({
			elem: '.layui-dateTime' //指定元素
			,format: 'yyyy-MM-dd HH:mm:ss'
			,type: 'datetime'
		  });
		  
	});
	

});

// 驻点报警对比 饼图

/***报警对比饼状图**/
// @parmas date_type 按月查询方式 day： 按天查询， month 按天查询
// @params start_time 搜索的查询条件 
function warning_compare_pie_charts(date_type, start_time){
	$.ajax({
		type:'get',
		url: '/rj/Overview_Device_All1', //请求数据的地址
		data: {date_type:date_type, start_time:start_time},
		success: function(res) {
			//res = {msg:"success"};
			if(res.msg == "success"){
				//var datas = [
				//	{name: '小米', y: 30}, 
				//	{name: '华为', y: 20}, 
				//	{name: 'OPPO', y: 15}, 
				//	{name: 'VIVO', y: 25}, 
			    //	{name: 'APPLE', y: 10}];

			    var datas = new Array();
			    for(var index in res.data){
			        var item = res.data[index];
			        var obj = new Object();
			        //alert(item.Address);

			        obj.name = item.Address;
			        obj.y=item.Alarm_Count;
			        datas.push(obj);
			    }
				pie_charts('#warning-compare-pie-charts', 0, 12, ['30%','50%', '50%', '70%'], datas, 1, '%');
			}
		}
	});
	
	
}

//信息总览表格 如果需要参数，自由添加参数
// @parmas date_type 按月查询方式 day： 按天查询， month 按天查询
// @params start_time 搜索的查询条件 
// @params limit 查询限制条数
function get_overview_information_tab_list(table, limit, date_type, start_time){
var field = [
		{field: 'DeviceName', title: '驻点名称', align: 'left', width:"25%"}
		,{field: 'DeviceNum', title: '驻点设备(台)', align: 'left', width:"25%"}
		,{field: 'AlarmPercent', title: '报警百分比', align: 'left', Width:"25%"}
		,{field: 'DeviceTime', title: '总生产时长', align: 'left', Width:"25%"}
	];
	
	table.render({
		elem: '#overview-information-tab-list'
		,cellMinWidth:'80'
		,height: '259'
		,size: 'sm'
		,page: {
			layout: ['count', 'prev', 'page', 'next'] //自定义分页布局
			,groups: 3
			,first: '首页' //不显示首页
			,last : '尾页'
			,prev: '<em><<</em>'
    		,next: '<em>>></em>'
			//,limits: [5,10,15,20]
		} //开启分页
		,url:'/rj/Overview_Device_All3'  //使用url获取参数的话 可以配合limit限制行数
		,method:'get'
		,limit: limit// TODO 修改
		,where: {date_type:date_type, start_time: start_time}// TODO 修改
		,parseData:function(res){ // 请求回传的参数es
			//alert(JSON.stringify(res));
			var data = [];
			for(var index in res.data){
				var item = res.data[index];
				data.push({
				    'DeviceName': item.Address
					,'DeviceNum': item.Count
					,'AlarmPercent': item.Alarm_Count_Result
					,'DeviceTime': item.CountTime
				});
			}
			return {
				  "code": 0, //解析接口状态
				  "msg": '', //解析提示文本
				  "count": res.count, //解析数据长度
				  "data": data //解析数据列表用于表格中展示 然后可以把下面,data:[{}]中死数据删除掉
				};
		}
		,cols: [field]
	});
}

// 初始化驻点报警柱形图
// @parmas date_type 按月查询方式 day： 按天查询， month 按天查询
// @params start_time 搜索的查询条件 
function warning_column_shape_charts(date_type, start_time){
	$.ajax({
		type:'get',
		url: '/rj/Overview_Device_All1', //请求数据的地址
		data: {date_type:date_type, start_time:start_time},
		success: function(res) {
		    //res = {msg:"success"};
		    if(res.msg == "success"){
		        var xtext = new Array();
		        var ydataYwc = new Array();
		        for(var index in res.data){
		            var item = res.data[index];
		            xtext.push(item.Address);
		            ydataYwc.push(item.Alarm_Count);
		        }
		        //for(var index2 in xtext){
		        //    alert(xtext[index2]);
		        //}
		        column_shape_charts('#column_shape_warning_charts', '驻点报警对比', '%', '报警次数(h/No.)',xtext, ydataYwc);
		    }
			//if(res.msg == "success"){
			    //alert("in");
				//var xtext = ["驻点1","驻点2","驻点3","驻点4","驻点5","驻点6", "驻点7","驻点8","驻点9","驻点10","驻点11","驻点12"];
				//var ydataYwc = [10, 2, 3, 5, 20, 30, 10, 2, 3, 5, 20, 30];

			    //var datas = new Array();
			    //for(var index in data.data){
			    //    var item = data.data[index];
			    //    var obj = new Object();
			    //    //alert(item.DeviceId);

			    //    obj.name = item.DeviceId;
			    //    obj.y=item.Num;
			    //    datas.push(obj);
			    //}
			    
				
			//}
		}
	});
	
}

/**驻点设备页面报警对比饼状图**/
// @parmas date_type 按月查询方式 day： 按天查询， month 按天查询
// @params start_time 搜索的查询条件 
function warning1_pie_charts(date_type, start_time){
	$.ajax({
		type:'get',
		url: '/rj/Overview_Device_All2', //请求数据的地址
		data: {date_type:date_type, start_time:start_time},
		success: function(res) {
			//res = {msg:"success"};
			if(res.msg == "success"){
				//var datas = [
				//{name: 'A1', y: 30}, 
				//{name: 'A2', y: 20}, 
				//{name: 'A3', y: 15}, 
				//{name: 'A4', y: 25}, 
				//{name: 'A5', y: 10}];

                var datas = new Array();
                for(var index in res.data){
                    var item = res.data[index];
                    var obj = new Object();
                    //alert(item.Address);

                    obj.name = item.Alarm_Name;
                    obj.y=item.Alarm_Count;
                    datas.push(obj);
                }

				pie_charts('#warning1-pie-charts', 0, 12, ['30%','50%', '50%', '70%'], datas, 1, '%');
			}
		}
	});
}

//初始化报警饼状图内置表格
// @parmas date_type 按月查询方式 day： 按天查询， month 按天查询
// @params start_time 搜索的查询条件 
// @params limit 查询限制条数
function get_warning_count_tab_list(table, limit, date_type, start_time){
	var field = [
		{field: 'AlarmName', title: '故障名称', align: 'left', width:"33%"}
		,{field: 'AlarmPoint', title: '故障驻点', align: 'left', width:"33%"}
		,{field: 'AlarmNum', title: '故障次数', align: 'left', Width:"35%"}
	];
	
	table.render({
		elem: '#warning-count-tab-list'
		,cellMinWidth:'80'
		,size: 'sm'
		,height: '254'
		
		,page: {
			layout: ['count', 'prev', 'page', 'next'] //自定义分页布局
			,groups: 3
			,first: '首页' //不显示首页
			,last : '尾页'
			,prev: '<em><<</em>'
    		,next: '<em>>></em>'
			//,limits: [5,10,15,20]
		} //开启分页
		,url:'/rj/Overview_Device_All4'  //使用url获取参数的话 可以配合limit限制行数
		,method:'get'
		,limit:limit// TODO 修改
		,where: {date_type:date_type, start_time: start_time}// TODO 修改
		,parseData:function(res){ // 请求回传的参数
			var data = [];
			for(var index in res.data){
				var item = res.data[index];
				data.push({
				    'AlarmName': item.Alarm_Name
					,'AlarmPoint': item.Address
					,'AlarmNum': item.Alarm_Count
				});
			}
			return {
				  "code": 0, //解析接口状态
				  "msg": '', //解析提示文本
				  "count": res.count, //解析数据长度
				  "data": data //解析数据列表用于表格中展示 然后可以把下面,data:[{}]中死数据删除掉
				};
		}
		,cols: [field]
	});
}


/**时长异常数量柱形图**/
// @parmas date_type 按月查询方式 day： 按天查询， month 按天查询
// @params start_time 搜索的查询条件
function column_time_difference_charts(date_type="day", start_time=""){
	$.ajax({
		type:'get',
		url: 'https://demo.demohuo.top/jquery/44/4440/demo/highcharts/highcharts_B.json', //请求数据的地址
		data: {date_type:date_type, start_time:start_time},
		success: function(res) {
			res = {msg:"success"};
			if(res.msg == "success"){
				//驻点报警对比数量
				var xtext = ["驻点1","驻点2","驻点3","驻点4","驻点5","驻点6", "驻点7","驻点8","驻点9","驻点10","驻点11","驻点12"];
				var ydataYwc = [10, 2, 3, 5, 20, 30, 10, 2, 3, 5, 20, 30];
				
				column_shape_charts('#column_time_difference_charts', '时长异常数量', 'h/No.', '数量(h/No.)',xtext, ydataYwc);
			}
		}
	});
}







/**生成生成柱形图**/
function column_shape_charts(domId, title, unitStr, yTitle, xtext, ydataYwc){
	var color_val = '#007AFF';
	var colors = new Array();
	for(var i in xtext){
		colors.push(color_val);
	}
	var myWidth = $(domId).width();
	$(domId).highcharts({
		credits: {
			enabled: false
		},
		exporting: {
			enabled: false
		},
		chart: {
			backgroundColor: 'rgba(0,0,0,0)',
			type: 'column',
			width: myWidth
		},
		legend: {
			enabled: false,//影藏图例
		},
		colors: colors,
		
		title: {
			//text: title,
			text: null,
			style: { "color": "#333333", "fontSize": "12px" }
		},
		subtitle: {
			text: ''
		},
		xAxis: {
			categories: xtext,
			crosshair: true,
			title:{
				style: {
					color: '#333333',
					fontSize: '12px'
				}
			}
		},
		yAxis: {
			allowDecimals:false,
			min: 0,
			tickInterval: 5,
			title: {
				text: false,
			},
			lineWidth: 1,
			lineColor: '#CCC',
			labels: {
				style: {
					color: '#666',
				}
			},
		},
		tooltip: {
			headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
			pointFormat: '<tr><td style="padding:0">{series.name}: </td>' +
			'<td style="padding:0"><b>{point.y:.0f} '+unitStr+'</b></td></tr>',
			footerFormat: '</table>',
		},
		plotOptions: {
			column: {
				borderWidth: 0,
				colorByPoint:true,
			}
		},
		series: [{
			data: ydataYwc,
			//【TODO V6】 版本新增maxPointWidth
			maxPointWidth: 10 
		}]
	});
}

    //@params legend_unit 图例单位 % | 次 | 个数 任意字符
    //@params format_data_type 控制饼形图是按照datas原样输出，还是需要计算百分占比 0： 原样输出 1： 计算百分比
function pie_charts(domId, legend_x, legend_itemMarginTop, pie_center, datas, format_data_type, legend_unit){
    var format_data = [];
    if (format_data_type == 0){
        format_data = datas;
    }else{
        var total_num = 0;
        for (var i = 0; i < datas.length; i++) {
            total_num += parseInt(datas[i]['y']);
        }	
        for (var i = 0; i < datas.length; i++) {
            var p = Math.round(100*100*(parseInt(datas[i]['y'])/total_num))/100;
            format_data.push({name: datas[i]['name'], y: p});
        }	
    }
    $(domId).highcharts({
        credits: {
            enabled: false
        },
        exporting: {
            enabled: false
        },
			
        legend:{
            align: 'right',
            layout: 'vertical',
            verticalAlign: 'middle',
            floating: true,
            itemStyle:{
                color:'#797979',
            },
            labelFormatter: function () {
                return this.name + '  <b>' + this.y + legend_unit +'</b>';
            },
            x: legend_x,
            itemMarginTop: legend_itemMarginTop
        },
        chart: {
            backgroundColor: 'rgba(0,0,0,0)',
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            type: 'pie'
        },
        title: {
            text: '',
            style: {
                "fontSize": "14px",
                color: '#797979',
            }
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.y:2f} '+legend_unit+'</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: false
                },
                center: pie_center,
                showInLegend: true,
                innerSize: '45%',
                /**【TODO V6】 版本新增size**/
                size: 180 
            }
        },
        series: [{
            data: format_data
        }]
    });
}