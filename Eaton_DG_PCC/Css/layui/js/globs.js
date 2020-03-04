
/**实时报警表格刷线数据函数**/
function get_current_warning_list(table, DeviceId){
	table.render({
		elem: '#current-warning'
		,cellMinWidth:'140'
		,height: 'full-180'
		,page: {
			layout: ['count', 'prev', 'page', 'next', 'skip'] //自定义分页布局
			,groups: 5 
			,first: '首页' //不显示首页
			,last : '尾页'
			,prev: '<em><<</em>'
    		,next: '<em>>></em>'
		} //开启分页
		, url: '/rj/Equipment_Component_Status_Alarm'  //使用url获取参数的话 可以配合limit限制行数
        ,limit:100
		,method:'post'
		//,where: {size:limit} // 传递的参数
		,where: {DeviceId: DeviceId}
		,parseData:function(res){ // 请求回传的参数
			var data = [];
			for(var index in res.data){
				var item = res.data[index];
				data.push({
				    "time": jsonDateFormat(item.BeginTime),
				    'variable': item.Variable_Address,
				    'current_value': item.Value,
				    'describe': item.AlarmName,
				});
			}
			return {
				  "code": 0, //解析接口状态
				  "msg": '', //解析提示文本
				  "count": res.count, //解析数据长度
				  "data": data //解析数据列表用于表格中展示 然后可以把下面,data:[{}]中死数据删除掉
				};
		}
		, cols: [[ //标题栏
            {field: 'time', title: '时间', align: 'left', minWidth: 240}
		  ,{field: 'variable', title: '变量', align: 'left', minWidth: 240, sort: true}
		  ,{field: 'current_value', title: '当前值', align: 'left', minWidth: 240, sort: true}
		  ,{field: 'describe', title: '描述', align: 'left', minWidth: 240}
		  //{field: 'id', title: '序列号', align: 'left', minWidth: 140}
		  //,{field: 'variable', title: '变量', align: 'left', minWidth: 140}
		  //,{field: 'start_time', title: '开始时间', align: 'left', minWidth: 140}
		  //,{field: 'end_time', title: '结束时间', align: 'left', minWidth: 140}
		  //,{field: 'exist_time', title: '存在时间', align: 'left', minWidth: 140}
		  //,{field: 'describe', title: '描述', align: 'left', minWidth: 140}
		]]
	});
}

/**获取历史报警列表**/
function get_history_warning_list(table,DeviceId, limit, start_time, end_time){
	
	table.render({
		elem: '#history-warning'
		,cellMinWidth:'240'
		,height: 'full-180'
		,page: {
			layout: ['count', 'prev', 'page', 'next', 'skip'] //自定义分页布局
			,groups: 5
			,first: '首页' //不显示首页
			,last : '尾页'
			,prev: '<em><<</em>'
    		,next: '<em>>></em>'
		} //开启分页
		, url: '/rj/Equipment_Component_Status_Alarm_History'  //使用url获取参数的话 可以配合limit限制行数
		, method: 'get'
        , limit: limit
		//,where: {size:limit, start_time:start_time, end_time:start_time} // 传递的参数
		, where: { DeviceId:DeviceId,limit: limit, start_time: start_time, end_time: end_time }
		//,contentType:'application/json' //如果你要发送 json 内容，可以设置：contentType: 'application/json
		,parseData:function(res){ // 请求回传的参数es
			//alert(JSON.stringify(res));
			var data = [];
			for(var index in res.data){
				var item = res.data[index];
				data.push({
				    "rownumber": item.rownumber,
				    'variable': item.Variable_Address,
				    "start_time": jsonDateFormat(item.BeginTime),
				    "end_time": jsonDateFormat(item.ResumeTime),
				    "exist_time": item.CountTime,
				    "describe": item.Value,

				    
				});
			}
			return {
				  "code": 0, //解析接口状态
				  "msg": '', //解析提示文本
				  "count": res.count, //解析数据长度
				  "data": data //解析数据列表用于表格中展示 然后可以把下面,data:[{}]中死数据删除掉
				};
		}
		,cols: [[ //标题栏
		  //{field: 'time', title: '时间', align: 'left', minWidth: 240}
		  //,{field: 'variable', title: '变量', align: 'left', minWidth: 240, sort: true}
		  //,{field: 'current_value', title: '当前值', align: 'left', minWidth: 240, sort: true}
		  //,{field: 'describe', title: '描述', align: 'left', minWidth: 240}
          { field: 'rownumber', title: '序列号', align: 'left', minWidth: 140 }
		  , { field: 'variable', title: '变量', align: 'left', minWidth: 140 }
		  , { field: 'start_time', title: '开始时间', align: 'left', minWidth: 140 }
		  , { field: 'end_time', title: '结束时间', align: 'left', minWidth: 140 }
		  , { field: 'exist_time', title: '存在时间', align: 'left', minWidth: 140 }
		  , { field: 'describe', title: '描述', align: 'left', minWidth: 140 }
		]]
	});
}

/***配方画面1**/
function get_formula_one_list(table){
	table.render({
		elem: '#formula-Frame-one-list'
		,cellMinWidth:'100'
		,height: 'full-180'
		,page: {
			layout: ['limit', 'count', 'prev', 'page', 'next', 'skip'] //自定义分页布局
			,groups: 5
			,first: '首页' //不显示首页
			,last : '尾页'
			,prev: '<em><<</em>'
    		,next: '<em>>></em>'
			,limits: [5,10,15,20]
		} //开启分页
		,url:'https://www.layui.com/demo/table/user/'  //使用url获取参数的话 可以配合limit限制行数
		,method:'get'
		,parseData:function(res){ // 请求回传的参数es
			//alert(JSON.stringify(res));
			var data = [];
			for(var index in res.data){
				var item = res.data[index];
				data.push({
					'formula1': item.username,
					'formula2': item.sign,
					'formula3': item.wealth,
					'formula4': item.classify,
					'formula5': item.wealth,
					'formula6': item.classify
				});
			}
			return {
				  "code": 0, //解析接口状态
				  "msg": '', //解析提示文本
				  "count": res.count, //解析数据长度
				  "data": data //解析数据列表用于表格中展示 然后可以把下面,data:[{}]中死数据删除掉
				};
		}
		,cols: [[ //标题栏
		  {field: 'formula1', title: '配方1', align: 'left', minWidth: 100}
		  ,{field: 'formula2', title: '配方2', align: 'left', minWidth: 100}
		  ,{field: 'formula3', title: '配方3', align: 'left', minWidth: 100}
		  ,{field: 'formula4', title: '配方4', align: 'left', minWidth: 100}
		  ,{field: 'formula5', title: '配方5', align: 'left', minWidth: 100}
		  ,{field: 'formula6', title: '配方6', align: 'left', minWidth: 100}
		]]
	});
}

/***配方画面2**/
function get_formula_two_list(table){
	table.render({
		elem: '#formula-Frame-two-list'
		,cellMinWidth:'240'
		,height: 'full-180'
		,page: {
			layout: ['limit', 'count', 'prev', 'page', 'next', 'skip'] //自定义分页布局
			,groups: 5
			,first: '首页' //不显示首页
			,last : '尾页'
			,prev: '<em><<</em>'
    		,next: '<em>>></em>'
			,limits: [5,10,15,20]
		} //开启分页
		,url:'https://www.layui.com/demo/table/user/'  //使用url获取参数的话 可以配合limit限制行数
		,method:'get'
		,parseData:function(res){ // 请求回传的参数es
			//alert(JSON.stringify(res));
			var data = [];
			for(var index in res.data){
				var item = res.data[index];
				data.push({
					'formula1': item.username,
					'formula2': item.sign,
					'formula3': item.wealth
				});
			}
			return {
				  "code": 0, //解析接口状态
				  "msg": '', //解析提示文本
				  "count": res.count, //解析数据长度
				  "data": data //解析数据列表用于表格中展示 然后可以把下面,data:[{}]中死数据删除掉
				};
		}
		,cols: [[ //标题栏
		  {field: 'formula1', title: '配方1', align: 'left', minWidth: 240}
		  ,{field: 'formula2', title: '配方2', align: 'left', minWidth: 240}
		  ,{field: 'formula3', title: '配方3', align: 'left', minWidth: 240}
		]]
	});
}

/***温度报表***/
function get_temperature_list(table,DeviceId, limit, start_time, end_time){
	var scos = [];
	var field = [
		{field: 'ID', title: 'ID', align: 'left', minWidth: 80}
		,{field: 'Ts', title: '日期', align: 'left', minWidth: 80}
		,{field: 'Cylinder_temperature_1', title: '筒体1', align: 'left', minWidth: 80}
		,{field: 'Cylinder_temperature_2', title: '筒体2', align: 'left', minWidth: 80}
		,{field: 'Cylinder_temperature_3', title: '筒体3', align: 'left', minWidth: 80}
		,{field: 'Cylinder_temperature_4', title: '筒体4', align: 'left', minWidth: 80}
		,{field: 'Bottom_temperature', title: '筒底', align: 'left', minWidth: 80}
		,{field: 'Horizontal_channel', title: '水平管道', align: 'left', minWidth: 80}
		,{field: 'Lower_channel', title: '下管道', align: 'left', minWidth: 80}
		,{field: 'Temperature_v1_1', title: '进料1', align: 'left', minWidth: 80}
		,{field: 'Temperature_v2_1', title: '进料2', align: 'left', minWidth: 80}
		,{field: 'Temperature_v3_1', title: '进料3', align: 'left', minWidth: 80}
		,{field: 'Temperature_v4_1', title: '进料4', align: 'left', minWidth: 80}
		,{field: 'Temperature_v5_1', title: '进料5', align: 'left', minWidth: 80}
		,{field: 'Temperature_v6_1', title: '进料6', align: 'left', minWidth: 80}
		,{field: 'Temperature_v7_1', title: '进料7', align: 'left', minWidth: 80}
		,{field: 'Temperature_v8_1', title: '进料8', align: 'left', minWidth: 80}
		,{field: 'Device_angle_valve', title: '角阀', align: 'left', minWidth: 80}
		,{field: 'Post_pumping_temperature', title: '泵后', align: 'left', minWidth: 80}
		,{field: 'Vacuum_gauge', title: '真空计', align: 'left', minWidth: 80}
	];
	
	table.render({
		elem: '#temperature-fomdata-list'
		,cellMinWidth:'240'
		,height: 'full-180'
		,defaultToolbar:['filter', 'exports']
		,toolbar: '#layui-table-tool'
		,page: {
		    //layout: ['limit', 'count', 'prev', 'page', 'next', 'skip'] //自定义分页布局
		    layout: ['count', 'prev', 'page', 'next'] //自定义分页布局
			,groups: 5
			,first: '首页' //不显示首页
			,last : '尾页'
			,prev: '<em><<</em>'
    		,next: '<em>>></em>'
			//,limits: [5,10,15,20]
		} //开启分页
		,url: '/rj/Equipment_Component_Status_Report'  //使用url获取参数的话 可以配合limit限制行数
		,method:'post'
        ,limit:limit
		,where: {DeviceId:DeviceId,limit: limit, start_time: start_time, end_time: end_time}
		,parseData:function(res){ // 请求回传的参数es
			//alert(JSON.stringify(res));
			var data = [];
			for(var index in res.data){
				var item = res.data[index];
				data.push({
				    'ID': item.ID,
				    'Ts': jsonDateFormat(item.Ts),
				    'Cylinder_temperature_1': item.Cylinder_temperature_1,
				    'Cylinder_temperature_2': item.Cylinder_temperature_2,
				    'Cylinder_temperature_3': item.Cylinder_temperature_3,
				    'Cylinder_temperature_4': item.Cylinder_temperature_4,
				    'Bottom_temperature': item.Bottom_temperature,
				    'Horizontal_channel': item.Horizontal_channel,
				    'Lower_channel': item.Lower_channel,
				    'Temperature_v1_1': item.Temperature_v1_1,
				    'Temperature_v2_1': item.Temperature_v2_1,
				    'Temperature_v3_1': item.Temperature_v3_1,
				    'Temperature_v4_1': item.Temperature_v4_1,
				    'Temperature_v5_1': item.Temperature_v5_1,
				    'Temperature_v6_1': item.Temperature_v6_1,
				    'Temperature_v7_1': item.Temperature_v7_1,
				    'Temperature_v8_1': item.Temperature_v8_1,
				    'Device_angle_valve': item.Device_angle_valve,
				    'Post_pumping_temperature': item.Post_pumping_temperature,
				    'Vacuum_gauge': item.Vacuum_gauge
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

/***工艺报表***/
function get_technique_fomdata_list(table,DeviceId, limit, start_time, end_time){
	var scos = [];
	var field = [
		{field: 'ID', title: 'ID', align: 'left', minWidth: 120}
		,{field: 'BeginTime', title: '开始时间', align: 'left', minWidth: 120}
		,{field: 'Endtime', title: '结束时间', align: 'left', minWidth: 120}
		,{field: 'Min', title: 'Min', align: 'left', minWidth: 120}
		,{field: 'Display_Vacuum_Time', title: '时间', align: 'left', minWidth: 120}
		,{field: 'SET_CW1_Power', title: 'PP1/w', align: 'left', minWidth: 120}
		,{field: 'SET_PW1_Power', title: 'CP1/w', align: 'left', minWidth: 120}
		,{field: 'SET_CW1_Flow', title: 'PF1/ul/min', align: 'left', minWidth: 120}
		,{field: 'SET_PW1_Flow', title: 'CF1/ul/min', align: 'left', minWidth: 120}
		,{field: 'SET_CW1_Time', title: 'PT1/s', align: 'left', minWidth: 120}
		,{field: 'SET_PW1_Time', title: 'CT1/s', align: 'left', minWidth: 120}
		,{field: 'SET_PW1_Hz', title: 'JBL1', align: 'left', minWidth: 120}
		,{field: 'SET_PW1_Duty', title: 'WT1/.', align: 'left', minWidth: 120}
		,{field: 'SET_PW1_Reso', title: 'RE1/.', align: 'left', minWidth: 120}
		,{field: 'SET_CW1_He', title: 'He1/sccm', align: 'left', minWidth: 120}
		,{field: 'SET_PW1_He', title: 'He2/sccm', align: 'left', minWidth: 120}
		,{field: 'SET_V5_Pro_Temp', title: 'Templ/.C', align: 'left', minWidth: 120}
		,{field: 'SET_Tube1_Temp', title: 'Temp/.C', align: 'left', minWidth: 120}
		,{field: 'SET_CW1_Press', title: 'PR1/mToor', align: 'left', minWidth: 120}
		,{field: 'SET_PW1_Press', title: 'CR1/mToor', align: 'left', minWidth: 120}
        ,{field: 'SET_Rotate_Frequ', title: 'RS/Hz', align: 'left', minWidth: 120}
        ,{field: 'SET_Volatil_Rate', title: 'VT', align: 'left', minWidth: 120}
        ,{field: 'SET_CW2_Power', title: 'PP2/w', align: 'left', minWidth: 120}
        ,{field: 'SET_PW2_Power', title: 'CP2/w', align: 'left', minWidth: 120}
        ,{field: 'SET_CW2_1_Flow', title: 'PF2-1/ul/min', align: 'left', minWidth: 120}
        ,{field: 'SET_CW2_2_Flow', title: 'PF2-2/ul/min', align: 'left', minWidth: 120}
        ,{field: 'SET_CW2_3_Flow', title: 'PF2-3/ul/min', align: 'left', minWidth: 120}
        ,{field: 'SET_CW2_4_Flow', title: 'PF2-4/ul/min', align: 'left', minWidth: 120}
        ,{field: 'SET_PW2_1_Flow', title: 'CF2-1/ul/min', align: 'left', minWidth: 120}
        ,{field: 'SET_PW2_2_Flow', title: 'CF2-2/ul/min', align: 'left', minWidth: 120}
        ,{field: 'SET_PW2_3_Flow', title: 'CF2-3/ul/min', align: 'left', minWidth: 120}
        ,{field: 'SET_PW2_4_Flow', title: 'CF2-4/ul/min', align: 'left', minWidth: 120}
        ,{field: 'SET_CW2_Time', title: 'PT2/s', align: 'left', minWidth: 120}
        ,{field: 'SET_PW2_Time', title: 'CT2/s', align: 'left', minWidth: 120}
        ,{field: 'SET_PW2_Hz', title: 'JB2L', align: 'left', minWidth: 120}
        ,{field: 'SET_PW2_Duty', title: 'WT2/.', align: 'left', minWidth: 120}
        ,{field: 'SET_PW2_Reso', title: 'RE2/.', align: 'left', minWidth: 120}
        ,{field: 'SET_CW2_He', title: 'He3/sccm', align: 'left', minWidth: 120}
        ,{field: 'SET_PW2_He', title: 'He4/sccm', align: 'left', minWidth: 120}
        ,{field: 'SET_V4_Pro_Temp', title: 'Temp2/.C', align: 'left', minWidth: 120}
        ,{field: 'SET_CW3_Power', title: 'PP3/w', align: 'left', minWidth: 120}
        ,{field: 'SET_PW3_Power', title: 'CP3/w', align: 'left', minWidth: 120}
        ,{field: 'SET_CW3_Flow', title: 'PF3/ul/min', align: 'left', minWidth: 120}
        ,{field: 'SET_PW3_Flow', title: 'CF3/ul/min', align: 'left', minWidth: 120}
        ,{field: 'SET_CW3_Time', title: 'PT3/s', align: 'left', minWidth: 120}
        ,{field: 'SET_PW3_Time', title: 'CT3/s', align: 'left', minWidth: 120}
        ,{field: 'SET_PW3_Hz', title: 'JB3L', align: 'left', minWidth: 120}
        ,{field: 'SET_PW3_Duty', title: 'WT3/.', align: 'left', minWidth: 120}
        ,{field: 'SET_PW3_Reso', title: 'RE3/.', align: 'left', minWidth: 120}
        ,{field: 'SET_CW3_He', title: 'He5/sccm', align: 'left', minWidth: 120}
        ,{field: 'SET_PW3_He', title: 'He6/sccm', align: 'left', minWidth: 120}
        ,{field: 'SET_V8_Pro_Temp', title: 'Temp3/.C', align: 'left', minWidth: 120}
	];
	
	table.render({
		elem: '#technique-fomdata-list'
		,cellMinWidth:'240'
		,height: 'full-180'
		,defaultToolbar:['filter', 'exports']
		,toolbar: '#layui-table-tool'
		,page: {
		    //layout: ['limit', 'count', 'prev', 'page', 'next', 'skip'] //自定义分页布局
		    layout: ['count', 'prev', 'page', 'next'] //自定义分页布局
			,groups: 5
			,first: '首页' //不显示首页
			,last : '尾页'
			,prev: '<em><<</em>'
    		,next: '<em>>></em>'
			//,limits: [5,10,15,20]
		} //开启分页
		,url: '/rj/Process_Report'  //使用url获取参数的话 可以配合limit限制行数
		,method:'get'
        ,limit:limit
		,where: {DeviceId:DeviceId,limit: limit, start_time: start_time, end_time: end_time}
		,parseData:function(res){ // 请求回传的参数es
			//alert(JSON.stringify(res));
			var data = [];
			for(var index in res.data){
				var item = res.data[index];
				data.push({
				    'ID': item.ID
					,'BeginTime': jsonDateFormat(item.BeginTime)
					,'Endtime': jsonDateFormat(item.Endtime)
					,'Min': item.Min
					,'Display_Vacuum_Time': item.Display_Vacuum_Time
					,'SET_CW1_Power': item.SET_CW1_Power
					,'SET_PW1_Power': item.SET_PW1_Power
					,'SET_CW1_Flow': item.SET_CW1_Flow
					,'SET_PW1_Flow': item.SET_PW1_Flow
					,'SET_CW1_Time': item.SET_CW1_Time
					,'SET_PW1_Time': item.SET_PW1_Time
					,'SET_PW1_Hz': item.SET_PW1_Hz
					,'SET_PW1_Duty': item.SET_PW1_Duty
					,'SET_PW1_Reso': item.SET_PW1_Reso
					,'SET_CW1_He': item.SET_CW1_He
					,'SET_PW1_He': item.SET_PW1_He
					,'SET_V5_Pro_Temp': item.SET_V5_Pro_Temp
					,'SET_Tube1_Temp': item.SET_Tube1_Temp
					,'SET_CW1_Press': item.SET_CW1_Press
					,'SET_PW1_Press': item.SET_PW1_Press
                ,'SET_Rotate_Frequ': item.SET_Rotate_Frequ
                ,'SET_Volatil_Rate': item.SET_Volatil_Rate
                ,'SET_CW2_Power': item.SET_CW2_Power
                ,'SET_PW2_Power': item.SET_PW2_Power
                ,'SET_CW2_1_Flow': item.SET_CW2_1_Flow
                ,'SET_CW2_2_Flow': item.SET_CW2_2_Flow
                ,'SET_CW2_3_Flow': item.SET_CW2_3_Flow
                ,'SET_CW2_4_Flow': item.SET_CW2_4_Flow
                ,'SET_PW2_1_Flow': item.SET_PW2_1_Flow
                ,'SET_PW2_2_Flow': item.SET_PW2_2_Flow
                ,'SET_PW2_3_Flow': item.SET_PW2_3_Flow
                ,'SET_PW2_4_Flow': item.SET_PW2_4_Flow
                ,'SET_CW2_Time': item.SET_CW2_Time
                ,'SET_PW2_Time': item.SET_PW2_Time
                ,'SET_PW2_Hz': item.SET_PW2_Hz
                ,'SET_PW2_Duty': item.SET_PW2_Duty
                ,'SET_PW2_Reso': item.SET_PW2_Reso
                ,'SET_CW2_He': item.SET_CW2_He
                ,'SET_PW2_He': item.SET_PW2_He
                ,'SET_V4_Pro_Temp': item.SET_V4_Pro_Temp
                ,'SET_CW3_Power': item.SET_CW3_Power
                ,'SET_PW3_Power': item.SET_PW3_Power
                ,'SET_CW3_Flow': item.SET_CW3_Flow
                ,'SET_PW3_Flow': item.SET_PW3_Flow
                ,'SET_CW3_Time': item.SET_CW3_Time
                ,'SET_PW3_Time': item.SET_PW3_Time
                ,'SET_PW3_Hz': item.SET_PW3_Hz
                ,'SET_PW3_Duty': item.SET_PW3_Duty
                ,'SET_PW3_Reso': item.SET_PW3_Reso
                ,'SET_CW3_He': item.SET_CW3_He
                ,'SET_PW3_He': item.SET_PW3_He
                ,'SET_V8_Pro_Temp': item.SET_V8_Pro_Temp
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


/***其他报表***/
function get_others_fomdata_list(table, DeviceId,limit, start_time, end_time){
	var scos = [];
	var field = [
		{field: 'ID', title: 'ID', align: 'left', minWidth: 120}
		,{field: 'Ts', title: '日期', align: 'left', minWidth: 120}
		,{field: 'Display_CDG_pressure', title: '高真空', align: 'left', minWidth: 120}
		,{field: 'Display_Flow_He_MFC1', title: '氦气流量', align: 'left', minWidth: 120}
		,{field: 'Display_ATS6_Load_Pos', title: 'C_load', align: 'left', minWidth: 120}
		,{field: 'Display_ATS6_Tune_Pos', title: 'C_Tune', align: 'left', minWidth: 120}
		,{field: 'Display_HR601_FwdPwr', title: '发射功率', align: 'left', minWidth: 120}
		,{field: 'Display_Process_Time', title: '工序时间', align: 'left', minWidth: 120}
		,{field: 'Display_process_No', title: '工序批次', align: 'left', minWidth: 120}
		,{field: 'Rotate_PV2', title: '旋转频率', align: 'left', minWidth: 120}
	];
	
	table.render({
		elem: '#others-fomdata-list'
		,cellMinWidth:'240'
		,height: 'full-180'
		,defaultToolbar:['filter', 'exports']
		,toolbar: '#layui-table-tool'
		,page: {
		    //layout: ['limit', 'count', 'prev', 'page', 'next', 'skip'] //自定义分页布局
		    layout: ['count', 'prev', 'page', 'next'] //自定义分页布局
			,groups: 5
			,first: '首页' //不显示首页
			,last : '尾页'
			,prev: '<em><<</em>'
    		,next: '<em>>></em>'
			,limits: [5,10,15,20]
		} //开启分页
		,url: '/rj/Other_Report'  //使用url获取参数的话 可以配合limit限制行数
		,method:'get'
        ,limit:limit
		,where: {DeviceId:DeviceId,limit: limit, start_time: start_time, end_time: end_time}
		,parseData:function(res){ // 请求回传的参数es
			//alert(JSON.stringify(res));
			var data = [];
			for(var index in res.data){
				var item = res.data[index];
				data.push({
				    'ID': item.ID
					,'Ts': jsonDateFormat(item.Ts)
					,'Display_CDG_pressure': item.Display_CDG_pressure
					,'Display_Flow_He_MFC1': item.Display_Flow_He_MFC1
					,'Display_ATS6_Load_Pos': item.Display_ATS6_Load_Pos
					,'Display_ATS6_Tune_Pos': item.Display_ATS6_Tune_Pos
					,'Display_HR601_FwdPwr': item.Display_HR601_FwdPwr
					,'Display_Process_Time': item.Display_Process_Time
					,'Display_process_No': item.Display_process_No
					,'Rotate_PV2': item.Rotate_PV2
				
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


/**监听页面导航栏button按钮事件**/
function listenButtonTabEvent(){
	$('.layui-equipment-btn').click('on',function() {
		var self = this;
		var url = $(self).attr("data-url");
		console.log(url);
		location.href = url;
	});
}

//检测进度条
function load_progress_list(element){
	$.ajax({
		type:'get',
		url: 'https://demo.demohuo.top/jquery/44/4440/demo/highcharts/highcharts.json', //请求数据的地址
		success: function(res) {
			//测试demo
			res = {msg: 'success', data: {
				Vacuum_pumping: 100, // 对应的百分值
				Preprocessing1: 100,
				Coating1: 100,
				Preprocessing2: 80,
				Coating2: 0,
				Preprocessing3: 0,
				Coating3: 0,
				Exhaust: 0,
				Open_door: 0,
				Done: 0
			}}
			var data = res.data;
			
			if(res.msg == "success"){
				for(var key in data){
					element.progress(key, data[key]+'%');
				}
				var donePercent = data.Done;
				// 如果状态完成，则跳出递归
				if(donePercent == 100){
					return true;
				}else{
					// 如果状态没有完成，则每5秒加载一次
					setTimeout(function(){
						load_progress_list(element);
					}, 5000);
				}
			}
			
		}
	});
}

;!function(){
	/**设置样式**/
	var finishBarWidth = $(".layui-progress-end").width();
	
	if(finishBarWidth > 42){
		$("#layui-progress-end").addClass("layui-progress-end")
	} 
	
	listenButtonTabEvent();
  	/***********左边栏收缩*************/	  	
   	var i = 0;
	$('#close').click(function() {
		//这里定义一个全局变量来方便判断动画收缩的效果,也就是放在最外面
		if(i == 0) {
			$(".layui-side").animate({
				width: 'toggle'
			});
			$(".layui-tab-title").animate({
				height: 'toggle'
			});
			$(".layui-right-user").animate({
				height: 'toggle'
			});
			$(".layui-body").animate({
				left: '0px'
			});
			$(".layui-tab-title").animate({
				top: '0px'
			});
			$(".layui-right-user").animate({
				top: '0px'
			});
			$("#close > i").removeClass('layui-icon-shrink-right').addClass('layui-icon-spread-left');
			
			i++;
		} else {
			$(".layui-side").animate({
				width: 'toggle'
			});
			$(".layui-tab-title").animate({
				height: 'toggle'
			});
			$(".layui-right-user").animate({
				height: 'toggle'
			});
			$(".layui-body").animate({
				left: '160px'
			});
			$(".layui-tab-title").animate({
				top: '0'
			});
			$(".layui-right-user").animate({
				top: '0px'
			});
			$("#close > i").removeClass('layui-icon-spread-left').addClass('layui-icon-shrink-right');
			
			i--;
		}
	});
	
	//左侧导航栏收缩提示
	$('#close').hover(function() {
		var isClose = $('#close .layui-icon').hasClass("layui-icon-shrink-right");
		var isOpen  = $('#close .layui-icon').hasClass("layui-icon-spread-left");
		console.log(isClose, isOpen);
		var tip = (isClose && !isOpen) ? '收缩菜单' : ((!isClose && isOpen) ? '展开菜单': '');
		layer.tips(tip, '#close', {
			tips: [4, '#FF8000'],
			time: 0
		});
	}, function() {
		layer.closeAll('tips');
	});
	
	
	//右侧顶部users信息
	$('.layui-right-user .layui-user-name').click(function() {
		var d = $(this).find('.layui-icon-triangle-d');
		var next = $(this).next();
		if(d.hasClass('up')) {
			d.removeClass('up');
			next.hide()
		} else {
			d.addClass('up');
			next.show()
		}
	});

	layui.use(['table', 'form', 'laydate', 'element'], function () {

	  var table = layui.table;
	  var form = layui.form;
	  var laydate = layui.laydate;
	  var element = layui.element;
	  /***********当前警告相关js****************/
	    //初始化刷新实时报警表格数据
	  var DeviceId = $('input[name="DeviceId2"]').val();
	  get_current_warning_list(table, DeviceId);
	  //实时监听实时报警表格数据
	  form.on('select(warning-input-limit)', function (data) {
	      
	      var limit = data.value;
	      //alert(limit);

	      var DeviceId = data.DeviceId;

	      get_current_warning_list(table, DeviceId);
	  });
	  
	  form.on('select(warning-input-limit2)', function (data) {

	      var limit = data.value;
	      var DeviceId = $('input[name="DeviceId2"]').val(); 

	      get_current_warning_list(table, DeviceId);
	  });
	  /**********历史警告相关查询*************/
	  get_history_warning_list(table);
	  //实时监听历史报警表格数据
	  form.on('submit(search-history-warning)',function(data){
		  var limit = data.field.limit;
		  var start_time = data.field.start_time;
		  var end_time = data.field.end_time;
		  var DeviceId = data.field.DeviceId;
		  get_history_warning_list(table,DeviceId, limit, start_time, end_time);
	  });
	  
	  /*************温度搜索报表**************/
	  
	  form.on('submit(search-temperature-fomdata)',function(data){
		  var limit = data.field.limit;
		  var start_time = data.field.start_time;
		  var end_time = data.field.end_time;
		  var DeviceId = data.field.DeviceId;
		  get_temperature_list(table, DeviceId,limit, start_time, end_time);
	  });
	  
	  /***** 搜索工艺报表****************/
	  form.on('submit(search-technique-fomdata)',function(data){
		  var limit = data.field.limit;
		  var start_time = data.field.start_time;
		  var end_time = data.field.end_time;
		  var DeviceId = data.field.DeviceId;
		  get_technique_fomdata_list(table,DeviceId, limit, start_time, end_time);
	  });
	  
	  /***** 搜索其他报表****************/
	  form.on('submit(search-others-fomdata)',function(data){
		  var limit = data.field.limit;
		  var start_time = data.field.start_time;
		  var end_time = data.field.end_time;
		  var DeviceId = data.field.DeviceId;
		  get_others_fomdata_list(table,DeviceId, limit, start_time, end_time);
	  });
	  
	  /**********配方画面相关查询*************/
	  //配方画面1
	  get_formula_one_list(table);
	  //配方画面2
	  get_formula_two_list(table);
	  /*************报表相关***********************/
	  //温度报表
	  get_temperature_list(table);
	  get_technique_fomdata_list(table);
	  get_others_fomdata_list(table);
	  
	  for(var i=1; i<=8 ; i++){
	      var elem = '#dateTime'+i;  
	      //引入时间选择样式
	      laydate.render({
	          elem: elem //指定元素
			,format: 'yyyy-MM-dd HH:mm:ss'
			,type: 'datetime'
	      });
	  }
	  
	  // 设置进度条
	  load_progress_list(element);
	  
   });
}();
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