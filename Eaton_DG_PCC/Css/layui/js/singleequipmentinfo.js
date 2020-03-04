// JavaScript Document
$(function(){
		   
	// 单驻点设备信四个图标接口
	//1、初始设备使用率柱形图, 如果需要参数，自由添加参数
	devices_rate_column_shape_charts();
	
	//3、报警饼状图 如果需要参数，自由添加参数
	warning_pie_charts();
	
	layui.use(['table', 'form', 'laydate'], function(){
		  var table = layui.table;
		  var form = layui.form;
		  var laydate = layui.laydate;
		  //2、初始化 生产时长异常查询 如果需要参数，自由添加参数
		  get_product_length_time(table);
		  //4、初始化报警饼状图内置表格 如果需要参数，自由添加参数
		  get_error_info_tab_list(table);
		  // 监控表单搜索按钮
		  form.on('submit(search-single-devices)', function(data) {
			  var device_name = data.field.device_name;
			  var search_way = data.field.search_way;
			  var start_time = data.field.start_time;
			  // 搜索相关查询
			  devices_rate_column_shape_charts(device_name, search_way, start_time);
			  warning_pie_charts(device_name, search_way, start_time);
			  get_product_length_time(table, 6, device_name, search_way, start_time);
		      //table,limit,device_name, search_way, start_time, start_hours, end_hours
			  get_error_info_tab_list(table, 6, device_name, search_way, start_time);
		  });
		  
		  // 监控排查按钮
		  form.on('submit(search-product-length-time)', function(data) {
			  // 筛选输入小时的起始小时数
			  var start_hours = data.field.start_hours;
			  // 筛选输入小时的结束小时数
			  var end_hours = data.field.end_hours;
			  var search_form_data = {};
			  var search_form_list = $('#single-device-info').serializeArray();
			  $.each(search_form_list, function() {
				  search_form_data[this.name] = this.value;
			  });
			  var device_name = search_form_data['device_name'];
			  var search_way = search_form_data['search_way'];
			  var start_time = search_form_data['start_time'];

			  get_product_length_time(table, 6, device_name, search_way, start_time, start_hours, end_hours);

		      //device_name, search_way, start_time, start_hours, end_hours
		  });
		  
		  // 格式化时间
		  laydate.render({
			elem: '.layui-dateTime' //指定元素
			,format: 'yyyy-MM-dd HH:mm:ss'
			,type: 'datetime'
		  });
		  
	});
	

});

// 设备使用率柱形图柱形图
// @parmas device_name 驻点设备名
// @parmas search_way 按月查询方式 day： 按天查询， month 按天查询
// @params start_time 搜索的查询条件 
function devices_rate_column_shape_charts(device_name, search_way, start_time){

	$.ajax({
		type:'get',
		url: '/rj/Detailed_Equipment_utilization_rate', //请求数据的地址
		data: {device_name: device_name, search_way:search_way, start_time:start_time},
		success: function(data) {
		    //data = {msg:"success"};
		    //if(data.msg == "success"){
				//var xtext = ["设备1","设备2","设备3","设备4","设备5","设备6", "设备7","设备8","设备9","设备10","设备11","设备12"];
				//var ydataYwc = [10, 2, 3, 5, 20, 100, 10, 2, 3, 5, 20, 100];
				
			    //column_shape_charts('#column_shape_charts', '设备使用率', '次', '频率(次)',xtext, ydataYwc);

			    

		    //}

		    var datas = new Array();
		    for(var index in data.data){
		        var item = data.data[index];
		        var obj = new Object();
		        //alert(item.DeviceId);

		        obj.name = item.DeviceId;
		        obj.y=item.Num;
		        datas.push(obj);
		    }
			
		    pie_charts2('#column_shape_charts', -80, 10, ['20%','50%', '50%', '80%'], datas,1,'%');
		}
	});
	
}

/***单设备信息生产时长列表-排查66***/
//function get_product_length_time(table, limit=6, device_name="HUAWEI", search_way="day", start_time="", start_hours="", end_hours=""){
//	var field = [
//		{field: 'DeviceName', title: '设备名称', align: 'left', width:"25%"}
//		,{field: 'StartTime', title: '开始时间', align: 'left', width:"25%"}
//		,{field: 'EndTime', title: '结束时间', align: 'left', Width:"25%"}
//		,{field: 'DeviceLengthTime', title: '设备生产时长', align: 'left', Width:"25%"}
//	];
	
//	table.render({
//		elem: '#product-length-time-tab-list'
//		,cellMinWidth:'80'
//		,height: '259'
//		,size: 'sm'
//		,page: {
//			layout: ['count', 'prev', 'page', 'next'] //自定义分页布局
//			,groups: 3
//			,first: '首页' //不显示首页
//			,last : '尾页'
//			,prev: '<em><<</em>'
//    		,next: '<em>>></em>'
//			//,limits: [5,10,15,20]
//		} //开启分页
//		,url:'https://www.layui.com/demo/table/user/'  //使用url获取参数的话 可以配合limit限制行数
//		,method:'get'
//		,limit: limit// TODO 修改
//		,where: {
//			//limit: limit // 查询条数// TODO 修改
//			start_hours: start_hours // 查询筛选小时起始小时数
//			,end_hours: end_hours // 查询每天结束小时数
//			,device_name: device_name //设备名称
//			,search_way: search_way // 按月查询或者按日查询
//			,start_time: start_time // 查询的起止时间 可以不填写
//		}
//		,parseData:function(res){ // 请求回传的参数es
//			//alert(JSON.stringify(res));
//			var data = [];
//			for(var index in res.data){
//				var item = res.data[index];
//				data.push({
//					'DeviceName': item.id
//					,'StartTime': item.username
//					,'EndTime': item.sign
//					,'DeviceLengthTime': item.id
//				});
//			}
//			return {
//				  "code": 0, //解析接口状态
//				  "msg": '', //解析提示文本
//				  "count": res.count, //解析数据长度
//				  "data": data //解析数据列表用于表格中展示 然后可以把下面,data:[{}]中死数据删除掉
//				};
//		}
//		,cols: [field]
//	});
    //}

    function get_product_length_time(table,limit,device_name, search_way, start_time, start_hours, end_hours){

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
            ,url: '/rj/Ajax_Single_Station_Device_Info'//使用url获取参数的话 可以配合limit限制行数
            ,method:'get'
            ,limit: limit// TODO 修改
            ,where: {
                limit: limit ,// 查询条数// TODO 修改
                start_hours: start_hours // 查询筛选小时起始小时数
                ,end_hours: end_hours // 查询每天结束小时数
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
                        'DeviceName': item.DeviceId
					,'StartTime': jsonDateFormat(item.BeginTime)
					,'EndTime': jsonDateFormat(item.Endtime)
					,'DeviceLengthTime': item.CountTime
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

/***报警饼状图**/
// @parmas device_name 驻点设备名
// @parmas search_way 按月查询方式 day： 按天查询， month 按天查询
// @params start_time 搜索的查询条件 
function warning_pie_charts(device_name, search_way, start_time){
	$.ajax({
		type:'get',
		url: '/rj/rj_Alarm_Overview', //请求数据的地址
		data: {
			start_time: start_time,
			device_name: device_name,
			search_way: search_way
		},
		success:function(data){
		    //var dataVice = data.list;
		    var datas = new Array();

		    for(var index in data.data){
		        var item = data.data[index];
				var obj = new Object();
				obj.name = item.AlarmName;
				obj.y=item.AlarmCount;
				datas.push(obj);
			}


			//var data = [];
			//for(var index in res.data){
			//    var item = res.data[index];
			//    var obj = new Object();
			//    obj.name = data[i].AlarmName;
			//    obj.y=data[i].AlarmCount;
			//    datas.push(obj);
			//}
			
		    pie_charts('#warning-pie-charts', -80, 10, ['20%','50%', '50%', '80%'], datas,1,'%');
		}
	});
}

/***单设备信息故障统计列表***/
function get_error_info_tab_list(table, limit, device_name, search_way, start_time){
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
		, url: '/rj/Detailed_Alarm'  //使用url获取参数的话 可以配合limit限制行数
		,method:'get'
		,limit: limit// TODO 修改
		,where: {
			start_time: start_time,
			device_name: device_name,
			search_way: search_way
		}// TODO 修改
		,parseData:function(res){ // 请求回传的参数es
			//alert(JSON.stringify(res));
			var data = [];
			for(var index in res.data){
				var item = res.data[index];
				data.push({
				    'FaultName': item.Alarm_Code
					, 'AlarmDevice': item.DeviceId
					, 'AlarmNum': item.AlarmCount
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
    };

    //@params legend_unit 图例单位 % | 次 | 个数 任意字符
    //@params format_data_type 控制饼形图是按照datas原样输出，还是需要计算百分占比 0： 原样输出 1： 计算百分比
    function pie_charts(domId, legend_x, legend_itemMarginTop, pie_center, datas, format_data_type=0, legend_unit="%"){
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
    };

//@params legend_unit 图例单位 % | 次 | 个数 任意字符
//@params format_data_type 控制饼形图是按照datas原样输出，还是需要计算百分占比 0： 原样输出 1： 计算百分比
function pie_charts2(domId, legend_x, legend_itemMarginTop, pie_center, datas, format_data_type=0, legend_unit="%"){
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
};

function jsonDateFormat(jsonDate) {//json日期格式转换为正常格式
    if (jsonDate != null) {
        try {
            var date = new Date(parseInt(jsonDate.replace("/Date(", "").replace(")/", ""), 10));
            var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
            var day = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
            var hours = date.getHours();
            var minutes = date.getMinutes();
            var seconds = date.getSeconds();
            var milliseconds = date.getMilliseconds();
            return date.getFullYear() + "-" + month + "-" + day + " " + hours + ":" + minutes + ":" + seconds + "." + milliseconds;
        } catch (ex) {
            return "";
        }
    }
    return "";
};