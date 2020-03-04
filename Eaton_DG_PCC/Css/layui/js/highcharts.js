$(function(){
	//设备使用率柱形图
	auto_column_shape_charts();
	// 报警并形图
	//ajax_pie_charts();
	
	
	// 驻点报警柱状图
	warning_column_shape_charts();
	// 时长异常数量柱状图
	column_time_difference_charts();
	
	
	// 报警饼状图
	var datas = [{name: 'A1', y: 30}, {name: 'A2', y: 20}, {name: 'A3', y: 15}, {name: 'A4', y: 25}, {name: 'A5', y: 10}]
	
	pie_charts('#warning-pie-charts', -80, 10, ['20%','50%', '50%', '80%'], datas);
	
	// 报警对比饼状图
	warning_compare_pie_charts();
	// 驻点设备页面报警对比饼状图
	warning1_pie_charts();
	
	/******当前页table设置*********/
	layui.use(['table', 'form', 'laydate'], function(){
	  var table = layui.table;
	  var form = layui.form;
	  var laydate = layui.laydate;
	  get_warning_count_tab_list(table);
	  get_overview_information_tab_list(table);
	  // 格式化时间
	  laydate.render({
		elem: '.layui-dateTime' //指定元素
		,format: 'yyyy-MM-dd HH:mm:ss'
		,type: 'datetime'
	  });
	  
	  /******单点设备页面*******/
	  //故障分类列表信息
	  get_error_info_tab_list(table);
	  //获取设备名
	  var device_name = $('#single-device-info select[name="device_name"]').val();
	  //获取按月查询还是按日查询的方式
	  var search_way = $('#single-device-info select[name="search_way"]').val();
	  //获取查询起始时间
	  var start_time = $('#single-device-info input[name="start_time"]').val();
	  //设备生产时长统计
	  get_product_length_time(table, 6, "", "", device_name, search_way, start_time);
	  
	  //监听单驻点设备页面【排查】按钮
	  form.on('submit(search-product-length-time)',function(data){
		  //获取设备名
		  var device_name = $('#single-device-info select[name="device_name"]').val();
		  //获取按月查询还是按日查询的方式
		  var search_way = $('#single-device-info select[name="search_way"]').val();
		  //获取查询起始时间
		  var start_time = $('#single-device-info input[name="start_time"]').val();
		  
		  var limit = 6;
		  var pre_hours = data.field.pre_hours;
		  var after_hours = data.field.after_hours;
		  get_product_length_time(table, limit, pre_hours, after_hours, device_name, search_way, start_time);
	  });
	  
	});
	
});



/***报警对比饼状图**/
function warning_compare_pie_charts(){
	var datas = [
				{name: '小米', y: 30}, 
				{name: '华为', y: 20}, 
				{name: 'OPPO', y: 15}, 
				{name: 'VIVO', y: 25}, 
				{name: 'APPLE', y: 10}];
	pie_charts('#warning-compare-pie-charts', 0, 12, ['25%','50%', '50%', '75%'], datas);
}

/**驻点设备页面报警对比饼状图**/
function warning1_pie_charts(){
	var datas = [
				{name: 'A1', y: 30}, 
				{name: 'A2', y: 20}, 
				{name: 'A3', y: 15}, 
				{name: 'A4', y: 25}, 
				{name: 'A5', y: 10}];
	pie_charts('#warning1-pie-charts', 0, 12, ['25%','50%', '50%', '75%'], datas);
}

/**时长异常数量**/
function column_time_difference_charts(){
	//驻点报警对比数量
	var xtext = ["驻点1","驻点2","驻点3","驻点4","驻点5","驻点6", "驻点7","驻点8","驻点9","驻点10","驻点11","驻点12"];
	var ydataYwc = [10, 2, 3, 5, 20, 30, 10, 2, 3, 5, 20, 30];
	
	column_shape_charts('#column_time_difference_charts', '时长异常数量', 'h/No.', '数量(h/No.)',xtext, ydataYwc);
}

function warning_column_shape_charts(){
	//驻点报警对比数量
	var xtext = ["驻点1","驻点2","驻点3","驻点4","驻点5","驻点6", "驻点7","驻点8","驻点9","驻点10","驻点11","驻点12"];
	var ydataYwc = [10, 2, 3, 5, 20, 30, 10, 2, 3, 5, 20, 30];
	
	column_shape_charts('#column_shape_warning_charts', '驻点报警对比', 'h/No.', '报警次数(h/No.)',xtext, ydataYwc);
}

/**自动使用获取[设备使用率]柱形图数据**/
function auto_column_shape_charts(){
	// 设备使用率第一次初始化柱形图数据
	var xtext = ["设备1","设备2","设备3","设备4","设备5","设备6", "设备7","设备8","设备9","设备10","设备11","设备12"];
	var ydataYwc = [10, 2, 3, 5, 20, 100, 10, 2, 3, 5, 20, 100];
	
	column_shape_charts('#column_shape_charts', '设备使用率', '次', '频率(次)',xtext, ydataYwc);
	/**
	setTimeout(function(){
		// 第二次ajax 数据
		ajax_column_shape_charts(auto_column_shape_charts);
	}, 5000);*/
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
			data: ydataYwc
		}]
	});
}

/**设备使用率*/
function ajax_column_shape_charts(cb){
	var ydataYwc = new Array(); //数值
	var xtext = new Array(); //X轴TEXT
	$.ajax({
		type:'get',
		url: 'https://demo.demohuo.top/jquery/44/4440/demo/highcharts/highcharts.json', //请求数据的地址
		success: function(data) {
			var json = data;
			for(var key in json.list){
				ydataYwc.push(parseFloat(json.list[key].sum)); //数值
				xtext.push(json.list[key].type); //给X轴TEXT赋值
			}
			console.log(xtext);
			console.log(ydataYwc);
			column_shape_charts(xtext, ydataYwc);
			//统计图表结束
		}
	});
	cb();
};

/**饼形图**/
function pie_charts(domId, legend_x, legend_itemMarginTop, pie_center, datas){
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
					return this.name + '  <b>' + this.y + '%</b>';
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
				pointFormat: '{series.name}: <b>{point.y:2f} %</b>'
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
					innerSize: '45%'
				}
			},
			series: [{
				data: datas
			}]
	});
}

//饼状图
function ajax_pie_charts(){
	$.ajax({
		type:'get',
		url:'https://demo.demohuo.top/jquery/44/4440/demo/highcharts/highcharts_B.json', //请求数据的地址
		success:function(data){
			var dataVice = data.list;
			var datas = new Array();
			for(var i=0;i<dataVice.length;i++){
				var obj = new Object();
				obj.name = dataVice[i].type;
				obj.y=dataVice[i].sum;
				datas.push(obj);
			}
			
			pie_charts('#warning-pie-charts', -80, 10, ['20%','50%', '50%', '80%'], datas);
		}
	});
	
};

/***单设备信息生产时长列表***/
function get_product_length_time(table, limit=6, pre_hours="", after_hours="", device_name="", search_way="", start_time=""){
	var field = [
		{field: 'DeviceName', title: '设备名称', align: 'left', width:"25%"}
		,{field: 'StartTime', title: '开始时间', align: 'left', width:"25%"}
		,{field: 'EndTime', title: '结束时间', align: 'left', Width:"25%"}
		,{field: 'DeviceLengthTime', title: '设备生产时长', align: 'left', Width:"25%"}
	];
	
	table.render({
		elem: '#product-length-time-tab-list'
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
		,url:'https://www.layui.com/demo/table/user/'  //使用url获取参数的话 可以配合limit限制行数
		,method:'get'
		,where: {
			limit: limit // 查询条数
			,pre_hours: pre_hours // 查询筛选小时起始小时数
			,after_hours: after_hours // 查询每天结束小时数
			,device_name: device_name //设备名称
			,search_way: search_way // 按月查询或者按日查询
			,start_time: start_time // 查询的起止时间 可以不填写
		}
		,parseData:function(res){ // 请求回传的参数es
			//alert(JSON.stringify(res));
			var data = [];
			for(var index in res.data){
				var item = res.data[index];
				data.push({
					'DeviceName': item.id
					,'StartTime': item.username
					,'EndTime': item.sign
					,'DeviceLengthTime': item.id
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

/***单设备信息故障统计列表***/
function get_error_info_tab_list(table, limit=6, start_time=""){
	var field = [
		{field: 'FaultName', title: '故障名称', align: 'left', width:"33%"}
		,{field: 'AlarmDevice', title: '报警设备', align: 'left', width:"33%"}
		,{field: 'AlarmNum', title: '报警次数', align: 'left', Width:"34%"}
	];
	
	table.render({
		elem: '#error-info-tab-list'
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
		,url:'https://www.layui.com/demo/table/user/'  //使用url获取参数的话 可以配合limit限制行数
		,method:'get'
		,where: {limit: limit, start_time: start_time}
		,parseData:function(res){ // 请求回传的参数es
			//alert(JSON.stringify(res));
			var data = [];
			for(var index in res.data){
				var item = res.data[index];
				data.push({
					'FaultName': item.id
					,'AlarmDevice': item.username
					,'AlarmNum': item.sign
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

/**设备总览信息**/
function get_overview_information_tab_list(table, limit=6, start_time=""){
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
		,url:'https://www.layui.com/demo/table/user/'  //使用url获取参数的话 可以配合limit限制行数
		,method:'get'
		,where: {limit: limit, start_time: start_time}
		,parseData:function(res){ // 请求回传的参数es
			//alert(JSON.stringify(res));
			var data = [];
			for(var index in res.data){
				var item = res.data[index];
				data.push({
					'DeviceName': item.id
					,'DeviceNum': item.username
					,'AlarmPercent': item.sign
					,'DeviceTime': item.id
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

/***报警次数列表***/
function get_warning_count_tab_list(table, limit=6, start_time=""){
	
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
		,url:'https://www.layui.com/demo/table/user/'  //使用url获取参数的话 可以配合limit限制行数
		,method:'get'
		,where: {limit: limit, start_time: start_time}
		,parseData:function(res){ // 请求回传的参数es
			//alert(JSON.stringify(res));
			var data = [];
			for(var index in res.data){
				var item = res.data[index];
				data.push({
					'AlarmName': item.id
					,'AlarmPoint': item.username
					,'AlarmNum': item.sign
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