
/**实时报警表格刷线数据函数**/
function get_current_warning_list(table, DeviceId) {
    //alert("in");
	table.render({
		elem: '#current-warning'
		,cellMinWidth:'140'
		,height: 'full-180'
		,page: {
		    //layout: ['count', 'prev', 'page', 'next', 'skip'] //自定义分页布局
		    layout: ['count', 'prev', 'page', 'next'] //自定义分页布局
			,groups: 5 
			,first: '首页' //不显示首页
			,last : '尾页'
			,prev: '<em><<</em>'
    		,next: '<em>>></em>'
		} //开启分页
		, url: '/DRAQ127/Alarm_Real_Time'  //使用url获取参数的话 可以配合limit限制行数
        ,limit:100
		,method:'post'
		//,where: {size:limit} // 传递的参数
		,where: {DeviceId: DeviceId}
		,parseData:function(res){ // 请求回传的参数
			var data = [];
			for(var index in res.data){
				var item = res.data[index];
				data.push({
				    "ID": item.ID,
				    "Time": jsonDateFormat(item.Time),
				    'Description': item.Description,
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
            { field: 'ID', title: 'ID', align: 'left', minWidth: 240 }
            ,{ field: 'Time', title: 'Time', align: 'left', minWidth: 240 }
		  //,{field: 'variable', title: '变量', align: 'left', minWidth: 240, sort: true}
		  //,{field: 'current_value', title: '当前值', align: 'left', minWidth: 240, sort: true}
		  , { field: 'Description', title: 'Description', align: 'left', minWidth: 240 }
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
		, height: 'full-180'
		,page: {
		    //layout: ['count', 'prev', 'page', 'next', 'skip'] //自定义分页布局
		    layout: ['count', 'prev', 'page', 'next'] //自定义分页布局
			,groups: 5
			,first: '首页' //不显示首页
			,last : '尾页'
			,prev: '<em><<</em>'
    		, next: '<em>>></em>'
		} //开启分页
		, url: '/DRAQ127/Alarm_History'  //使用url获取参数的话 可以配合limit限制行数
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
				    "ID": item.rownumber,
				    "Time": jsonDateFormat(item.Time),
				    'Description': item.Description,
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
		  { field: 'ID', title: 'ID', align: 'left', minWidth: 240 }
         , { field: 'Time', title: 'Time', align: 'left', minWidth: 240 }
         , { field: 'Description', title: 'Description', align: 'left', minWidth: 240 }
		]]
	});
}




/***每盘测试结果报表***/
function get_oee_list(table, DeviceId, limit, start_time, end_time, Model, Product_ID) {
	var scos = [];
	var field = [
		{field: 'ID', title: 'ID', align: 'left', minWidth: 70}
		, { field: 'LineID', title: 'Line ID', align: 'left', minWidth: 180 }
		, { field: 'ProductID', title: 'Batch No.', align: 'left', minWidth: 100 }
		, { field: 'InputTime', title: 'Input Time', align: 'left', minWidth: 180 }
		, { field: 'DutMode', title: 'Model', align: 'left', minWidth: 120 }
		, { field: 'TraySN', title: 'Tray SN', align: 'left', minWidth: 100 }
		, { field: 'DutTotalNum', title: 'Plan Output', align: 'left', minWidth: 120 }
		, { field: 'DutPassNum', title: 'Output', align: 'left', minWidth: 100 }
		, { field: 'DutFailNum', title: 'NG', align: 'left', minWidth: 80 }
		, { field: 'cap', title: 'CAP NG', align: 'left', minWidth: 100 }
		, { field: 'ESR', title: 'ESR NG', align: 'left', minWidth: 100 }
		, { field: 'Voltage', title: 'Voltage NG', align: 'left', minWidth: 100 }
	];
	

	table.render({
		elem: '#oee-fomdata-list'
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
		,url: '/DRAQ127/OEE'  //使用url获取参数的话 可以配合limit限制行数
		,method:'get'
        ,limit:limit
		, where: { DeviceId: DeviceId, limit: limit, start_time: start_time, end_time: end_time, Model: Model, Product_ID:Product_ID}
		,parseData:function(res){ // 请求回传的参数es
			//alert(JSON.stringify(res));
			var data = [];
			for(var index in res.data){
				var item = res.data[index];
				data.push({
				    'ID': item.rownumber,
				    'LineID': item.LineID,
				    'ProductID': item.ProductID,
				    'InputTime': jsonDateFormat(item.InputTime),
				    'DutMode': item.DutMode,
				    'TraySN': item.TraySN,
				    'DutTotalNum': item.DutTotalNum,
				    'DutPassNum': item.DutPassNum,
				    'DutFailNum': item.DutFailNum,
				    'cap': item.cap,
				    'ESR': item.ESR,
				    'Voltage': item.Voltage
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

/***报警信息报表***/
function get_po_fomdata_list(table,DeviceId, limit, start_time, end_time){
	var scos = [];
	var field = [
		{ field: 'ID', title: 'ID', align: 'left', minWidth: 70 }
        //, { field: 'DeviceId', title: 'DeviceId', align: 'left', minWidth: 120 }
		, { field: 'LineID', title: 'Line ID', align: 'left', minWidth: 100 }
		, { field: 'StationID', title: 'StationID', align: 'left', minWidth: 100 }
		, { field: 'WarnTime', title: 'Begin Time', align: 'left', minWidth: 100 }
        , { field: 'NormalTime', title: 'End Time', align: 'left', minWidth: 100 }
        , { field: 'WarnExplain', title: 'Warn Description', align: 'left', minWidth: 300 }
        , { field: 'Duration', title: 'Duration', align: 'left', minWidth: 110 }
		, { field: 'IfCure', title: 'Is Resumed', align: 'left', minWidth: 80 }
	];
	
	table.render({
		elem: '#po-fomdata-list'
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
		,url: '/DRAQ127/PO'  //使用url获取参数的话 可以配合limit限制行数
		,method:'get'
        ,limit:limit
		,where: {DeviceId:DeviceId,limit: limit, start_time: start_time, end_time: end_time}
		,parseData:function(res){ // 请求回传的参数es
			//alert(JSON.stringify(res));
			var data = [];
			for(var index in res.data){
				var item = res.data[index];
				data.push({
				    'ID': item.rownumber
                    , 'LineID': item.LineID
					, 'StationID': item.StationID
					, 'WarnTime': jsonDateFormat(item.WarnTime)
					, 'NormalTime': jsonDateFormat(item.NormalTime)
					, 'WarnExplain': item.WarnExplain
					, 'Duration': item.Duration
					, 'IfCure': item.IfCure
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

/***每日产量报表***/
function get_daily_output_fomdata_list(table, DeviceId,limit, start_time, end_time){
	var scos = [];
	var field = [
		{ field: 'rownumber', title: 'ID', align: 'left', minWidth: 50 }
		, { field: 'LineID', title: 'Line ID', align: 'left', minWidth: 80 }
		, { field: 'RecordTime', title: 'Date', align: 'left', minWidth: 160 }
        , { field: 'ProductID', title: 'Batch ID', align: 'left', minWidth: 110 }
		, { field: 'DutMode', title: 'Model', align: 'left', minWidth: 110 }
        , { field: 'DutTotalNum', title: 'Plan Output', align: 'left', minWidth: 110 }
		, { field: 'DutPassNum', title: 'Output', align: 'left', minWidth: 90 }
        , { field: 'DutFailNum', title: 'NG', align: 'left', minWidth: 50 }
		, { field: 'DutFailRate', title: 'NG Rate', align: 'left', minWidth: 80 }
        , { field: 'cap', title: 'CAP NG', align: 'left', minWidth: 80 }
		, { field: 'ESR', title: 'ESR NG', align: 'left', minWidth: 80 }
        , { field: 'Voltage', title: 'Voltage NG', align: 'left', minWidth: 120 }
		, { field: 'HaltNum', title: 'Halt Num', align: 'left', minWidth: 80 }
        , { field: 'HaltTime', title: 'Halt Time', align: 'left', minWidth: 80 }
		, { field: 'DeviceUseRate', title: 'Equipment utilization', align: 'left', minWidth: 160 }



	];
	//alert(DeviceId+"\r\n"+limit+"\r\n"+start_time+"\r\n"+end_time);
	table.render({
	    elem: '#daily-ouput-fomdata-list'
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
        //,url: '/DRAQ127/PO'  //使用url获取参数的话 可以配合limit限制行数
		,url: '/DRAQ127/DailyOutput'  //使用url获取参数的话 可以配合limit限制行数
		,method:'get'
        ,limit:limit
		,where: {DeviceId:DeviceId,limit: limit, start_time: start_time, end_time: end_time}
		,parseData:function(res){ // 请求回传的参数es
			//alert(JSON.stringify(res));
			var data = [];
			for(var index in res.data){
				var item = res.data[index];
				data.push({
				    'rownumber': item.rownumber
					, 'LineID': item.LineID
					, 'RecordTime': jsonDateFormat(item.RecordTime)
					, 'ProductID': item.ProductID
					, 'DutMode': item.DutMode
					, 'DutTotalNum': item.DutTotalNum
					, 'DutPassNum': item.DutPassNum
					, 'DutFailNum': item.DutFailNum
					, 'DutFailRate': item.DutFailRate
					, 'cap': item.cap
                    , 'ESR': item.ESR
                     , 'Voltage': item.Voltage
                    , 'HaltNum': item.HaltNum
                     , 'HaltTime': item.HaltTime
                    , 'DeviceUseRate': item.DeviceUseRate
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

/***每月产量报表***/
function get_monthly_output_fomdata_list(table, DeviceId, limit, start_time, end_time) {
    var scos = [];
    var field = [
		{ field: 'rownumber', title: 'ID', align: 'left', minWidth: 70 }
        , { field: 'LineID', title: 'Line ID', align: 'left', minWidth: 80 }
		, { field: 'UpdateTime', title: 'Date', align: 'left', minWidth: 180 }
        , { field: 'ProductID', title: 'Batch ID', align: 'left', minWidth: 130 }
		, { field: 'DutMode', title: 'Model', align: 'left', minWidth: 100 }
        , { field: 'DutTotalNum', title: 'Plan Output', align: 'left', minWidth: 130 }
		, { field: 'DutPassNum', title: 'Output', align: 'left', minWidth: 100 }
        , { field: 'DutFailNum', title: 'NG', align: 'left', minWidth: 130 }
		, { field: 'DutFailRate', title: 'NG Rate', align: 'left', minWidth: 100 }
        , { field: 'cap', title: 'CAP NG', align: 'left', minWidth: 130 }
		, { field: 'ESR', title: 'ESR NG', align: 'left', minWidth: 100 }
        , { field: 'Voltage', title: 'Voltage NG', align: 'left', minWidth: 130 }
    ];

    table.render({
        elem: '#monthly-ouput-fomdata-list'
		, cellMinWidth: '240'
		, height: 'full-180'
		, defaultToolbar: ['filter', 'exports']
		, toolbar: '#layui-table-tool'
		, page: {
		    //layout: ['limit', 'count', 'prev', 'page', 'next', 'skip'] //自定义分页布局
		    layout: ['count', 'prev', 'page', 'next'] //自定义分页布局
			, groups: 5
			, first: '首页' //不显示首页
			, last: '尾页'
			, prev: '<em><<</em>'
    		, next: '<em>>></em>'
			, limits: [5, 10, 15, 20]
		} //开启分页

		, url: '/DRAQ127/MonthlyOutput'  //使用url获取参数的话 可以配合limit限制行数
		, method: 'get'
        , limit: limit
		, where: { DeviceId: DeviceId, limit: limit, start_time: start_time, end_time: end_time }
		, parseData: function (res) { // 请求回传的参数es
		    //alert(JSON.stringify(res));
		    var data = [];
		    for (var index in res.data) {
		        var item = res.data[index];
		        data.push({
		            'rownumber': item.rownumber
					, 'LineID': item.LineID
					, 'UpdateTime': jsonDateFormat(item.UpdateTime)
					, 'ProductID': item.ProductID
					, 'DutMode': item.DutMode
					, 'DutTotalNum': item.DutTotalNum
					, 'DutPassNum': item.DutPassNum
					, 'DutFailNum': item.DutFailNum
					, 'DutFailRate': item.DutFailRate
					, 'cap': item.cap
                    , 'ESR': item.ESR
                     , 'Voltage': item.Voltage

		        });
		    }
		    return {
		        "code": 0, //解析接口状态
		        "msg": '', //解析提示文本
		        "count": res.count, //解析数据长度
		        "data": data //解析数据列表用于表格中展示 然后可以把下面,data:[{}]中死数据删除掉
		    };
		}
		, cols: [field]
    });
}

/***Cap报表***/
function get_Cap_output_fomdata_list(table, DeviceId, limit, start_time, end_time) {
	var scos = [];
	var field = [
		{ field: 'ID', title: 'ID', align: 'left', minWidth: 80 }
		, { field: 'InputTime', title: 'Input Time', align: 'left', minWidth: 180 }
		, { field: 'ProductID', title: 'Product ID', align: 'left', minWidth: 100 }
		, { field: 'DutMode', title: 'Dut Mode', align: 'left', minWidth: 100 }
		, { field: 'TraySN', title: 'Tray SN', align: 'left', minWidth: 100 }
		, { field: 'Position', title: 'Position', align: 'left', minWidth: 100 }
		, { field: 'State', title: 'State', align: 'left', minWidth: 100 }
		, { field: 'CapValue', title: 'Cap Value', align: 'left', minWidth: 100 }
		, { field: 'ResValue', title: 'Res Value', align: 'left', minWidth: 100 }
		, { field: 'OutputTime', title: 'Output Time', align: 'left', minWidth: 180 }
	];

	table.render({
		elem: '#Cap-fomdata-list'
		, cellMinWidth: '240'
		, height: 'full-180'
		, defaultToolbar: ['filter', 'exports']
		, toolbar: '#layui-table-tool'
		, page: {
			//layout: ['limit', 'count', 'prev', 'page', 'next', 'skip'] //自定义分页布局
			layout: ['count', 'prev', 'page', 'next'] //自定义分页布局
			, groups: 5
			, first: '首页' //不显示首页
			, last: '尾页'
			, prev: '<em><<</em>'
			, next: '<em>>></em>'
			, limits: [5, 10, 15, 20]
		} //开启分页

		, url: '/DRAQ127/CapOutput'  //使用url获取参数的话 可以配合limit限制行数
		, method: 'get'
		, limit: limit
		, where: { DeviceId: DeviceId,limit: limit, start_time: start_time, end_time: end_time }
		, parseData: function (res) { // 请求回传的参数es
			//alert(JSON.stringify(res));
			var data = [];
			for (var index in res.data) {
				var item = res.data[index];
				data.push({
					'ID': item.rownumber
					, 'InputTime': jsonDateFormat(item.InputTime)
					, 'ProductID': item.ProductID
					, 'DutMode': item.DutMode
					, 'TraySN': item.TraySN
					, 'Position': item.Position
					, 'State': item.State
					, 'CapValue': item.CapValue
					, 'ResValue': item.ResValue
					, 'OutputTime': jsonDateFormat(item.OutputTime)

				});
			}
			return {
				"code": 0, //解析接口状态
				"msg": '', //解析提示文本
				"count": res.count, //解析数据长度
				"data": data //解析数据列表用于表格中展示 然后可以把下面,data:[{}]中死数据删除掉
			};
		}
		, cols: [field]
	});
}

/***ESR报表***/
function get_ESR_output_fomdata_list(table, DeviceId, limit, start_time, end_time) {
	var scos = [];
	var field = [
		{ field: 'ID', title: 'ID', align: 'left', minWidth: 80 }
		, { field: 'InputTime', title: 'Input Time', align: 'left', minWidth: 180 }
		, { field: 'ProductID', title: 'Product ID', align: 'left', minWidth: 100 }
		, { field: 'DutMode', title: 'Dut Mode', align: 'left', minWidth: 100 }
		, { field: 'TraySN', title: 'Tray SN', align: 'left', minWidth: 100 }
		, { field: 'Position', title: 'Position', align: 'left', minWidth: 100 }
		, { field: 'State', title: 'State', align: 'left', minWidth: 100 }
		, { field: 'EqualRes', title: 'Equal Res', align: 'left', minWidth: 100 }
		, { field: 'OutputTime', title: 'Output Time', align: 'left', minWidth: 180 }
	];

	table.render({
		elem: '#ESR-fomdata-list'
		, cellMinWidth: '240'
		, height: 'full-180'
		, defaultToolbar: ['filter', 'exports']
		, toolbar: '#layui-table-tool'
		, page: {
			//layout: ['limit', 'count', 'prev', 'page', 'next', 'skip'] //自定义分页布局
			layout: ['count', 'prev', 'page', 'next'] //自定义分页布局
			, groups: 5
			, first: '首页' //不显示首页
			, last: '尾页'
			, prev: '<em><<</em>'
			, next: '<em>>></em>'
			, limits: [5, 10, 15, 20]
		} //开启分页

		, url: '/DRAQ127/ESROutput'  //使用url获取参数的话 可以配合limit限制行数
		, method: 'get'
		, limit: limit
		, where: { DeviceId: DeviceId, limit: limit, start_time: start_time, end_time: end_time }
		, parseData: function (res) { // 请求回传的参数es
			//alert(JSON.stringify(res));
			var data = [];
			for (var index in res.data) {
				var item = res.data[index];
				data.push({
					'ID': item.rownumber
					, 'InputTime': jsonDateFormat(item.InputTime)
					, 'ProductID': item.ProductID
					, 'DutMode': item.DutMode
					, 'TraySN': item.TraySN
					, 'Position': item.Position
					, 'State': item.State
					, 'EqualRes': item.EqualRes
					, 'OutputTime': jsonDateFormat(item.OutputTime)

				});
			}
			return {
				"code": 0, //解析接口状态
				"msg": '', //解析提示文本
				"count": res.count, //解析数据长度
				"data": data //解析数据列表用于表格中展示 然后可以把下面,data:[{}]中死数据删除掉
			};
		}
		, cols: [field]
	});
}


/***Voltage报表***/
function get_Voltage_output_fomdata_list(table, DeviceId, limit, start_time, end_time) {
	var scos = [];
	var field = [
		{ field: 'ID', title: 'ID', align: 'left', minWidth: 80 }
		, { field: 'InputTime', title: 'Input Time', align: 'left', minWidth: 180 }
		, { field: 'ProductID', title: 'Product ID', align: 'left', minWidth: 100 }
		, { field: 'DutMode', title: 'Dut Mode', align: 'left', minWidth: 100 }
		, { field: 'TraySN', title: 'Tray SN', align: 'left', minWidth: 100 }
		, { field: 'Position', title: 'Position', align: 'left', minWidth: 100 }
		, { field: 'State', title: 'State', align: 'left', minWidth: 100 }
		, { field: 'ResidueVol', title: 'Residue Vol', align: 'left', minWidth: 100 }
		, { field: 'EndVol', title: 'End Vol', align: 'left', minWidth: 100 }
		, { field: 'OutputTime', title: 'Output Time', align: 'left', minWidth: 180 }
	];

	table.render({
		elem: '#Voltage-fomdata-list'
		, cellMinWidth: '240'
		, height: 'full-180'
		, defaultToolbar: ['filter', 'exports']
		, toolbar: '#layui-table-tool'
		, page: {
			//layout: ['limit', 'count', 'prev', 'page', 'next', 'skip'] //自定义分页布局
			layout: ['count', 'prev', 'page', 'next'] //自定义分页布局
			, groups: 5
			, first: '首页' //不显示首页
			, last: '尾页'
			, prev: '<em><<</em>'
			, next: '<em>>></em>'
			, limits: [5, 10, 15, 20]
		} //开启分页

		, url: '/DRAQ127/VoltageOutput'  //使用url获取参数的话 可以配合limit限制行数
		, method: 'get'
		, limit: limit
		, where: { DeviceId: DeviceId, limit: limit, start_time: start_time, end_time: end_time }
		, parseData: function (res) { // 请求回传的参数es
			//alert(JSON.stringify(res));
			var data = [];
			for (var index in res.data) {
				var item = res.data[index];
				data.push({
					'ID': item.rownumber
					, 'InputTime': jsonDateFormat(item.InputTime)
					, 'ProductID': item.ProductID
					, 'DutMode': item.DutMode
					, 'TraySN': item.TraySN
					, 'Position': item.Position
					, 'State': item.State
					, 'ResidueVol': item.ResidueVol
					, 'EndVol': item.EndVol
					, 'OutputTime': jsonDateFormat(item.OutputTime)

				});
			}
			return {
				"code": 0, //解析接口状态
				"msg": '', //解析提示文本
				"count": res.count, //解析数据长度
				"data": data //解析数据列表用于表格中展示 然后可以把下面,data:[{}]中死数据删除掉
			};
		}
		, cols: [field]
	});
}


;!function(){
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
	      var DeviceId = data.DeviceId;


	      //alert(limit);
	      //get_current_warning_list(table, DeviceId);
	  });
	  
	  form.on('select(warning-input-limit2)', function (data) {

	      var Model = data.value;
	      var DeviceId = data.DeviceId;
	      //var DeviceId = $('input[name="DeviceId2"]').val(); 

	      //get_current_warning_list(table, DeviceId);
	  });
	    /**********历史警告相关查询*************/
	  var DeviceId = $('input[name="DeviceId2"]').val();
	  //get_history_warning_list(table, DeviceId);
	  //实时监听历史报警表格数据
	  form.on('submit(search-history-warning)',function(data){
		  var limit = data.field.limit;
		  var start_time = data.field.start_time;
		  var end_time = data.field.end_time;
		  var DeviceId = data.field.DeviceId;
		  get_history_warning_list(table,DeviceId, limit, start_time, end_time);
	  });
	  
	  /*************搜索OEE报表**************/
	  
	  form.on('submit(search-oee-fomdata)',function(data){
		  var limit = data.field.limit;
		  var start_time = data.field.start_time;
		  var end_time = data.field.end_time;
		  var DeviceId = data.field.DeviceId;
		  var Model = data.field.Model;
		  var Product_ID = data.field.Product_ID;
		  get_oee_list(table, DeviceId, limit, start_time, end_time, Model, Product_ID);
	  });
	  
	  /***** 搜索PO报表****************/
	  form.on('submit(search-po-fomdata)',function(data){
		  var limit = data.field.limit;
		  var start_time = data.field.start_time;
		  var end_time = data.field.end_time;
		  var DeviceId = data.field.DeviceId;
		  get_po_fomdata_list(table,DeviceId, limit, start_time, end_time);
	  });
	  
	  /***** 搜索每日产量报表****************/
	  form.on('submit(search-daily-ouput-fomdata)', function (data) {
		  var limit = data.field.limit;
		  var start_time = data.field.start_time;
		  var end_time = data.field.end_time;
		  var DeviceId = data.field.DeviceId;
		  get_daily_output_fomdata_list(table,DeviceId, limit, start_time, end_time);
	  });

	  /***** 搜索每月产量报表****************/
	  form.on('submit(search-monthlyouput-fomdata)', function (data) {
	      var limit = data.field.limit;
	      var start_time = data.field.start_time;
	      var end_time = data.field.end_time;
	      var DeviceId = data.field.DeviceId;
	      get_monthly_output_fomdata_list(table, DeviceId, limit, start_time, end_time);
	  });

		/***** 搜索Cap报表****************/
		form.on('submit(search-Cap-fomdata)', function (data) {
			var limit = data.field.limit;
			var start_time = data.field.start_time;
			var end_time = data.field.end_time;
			var DeviceId = data.field.DeviceId;
			get_Cap_output_fomdata_list(table, DeviceId, limit, start_time, end_time);
		});

		/***** 搜索ESR报表****************/
		form.on('submit(search-ESR-fomdata)', function (data) {
			var limit = data.field.limit;
			var start_time = data.field.start_time;
			var end_time = data.field.end_time;
			var DeviceId = data.field.DeviceId;
			get_ESR_output_fomdata_list(table, DeviceId, limit, start_time, end_time);
		});

		/***** 搜索Voltage报表****************/
		form.on('submit(search-Voltage-fomdata)', function (data) {
			var limit = data.field.limit;
			var start_time = data.field.start_time;
			var end_time = data.field.end_time;
			var DeviceId = data.field.DeviceId;
			get_Voltage_output_fomdata_list(table, DeviceId, limit, start_time, end_time);
		});
	  
	  /**********配方画面相关查询*************/
	  /*************报表相关***********************/
	  get_oee_list(table);
	  get_po_fomdata_list(table);
	  get_daily_output_fomdata_list(table);
		get_monthly_output_fomdata_list(table);
		get_Cap_output_fomdata_list(table);
		get_ESR_output_fomdata_list(table);
		get_Voltage_output_fomdata_list(table);

	  for(var i=1; i<=14 ; i++){
	      var elem = '#dateTime'+i;  
	      //引入时间选择样式
	      laydate.render({
	          elem: elem //指定元素
			,format: 'yyyy-MM-dd HH:mm:ss'
			,type: 'datetime'
	      });
	  }
	  
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