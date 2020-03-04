// JavaScript Document
$(function(){
	/**异常页面编辑查询**/
	exception_title_edit_click();
	layui.use(['layer', 'form', 'table'], function(){
		var layer = layui.layer;
		var form = layui.form;
		var table = layui.table;
		//初始化异常报警列表
		search_exception_handler_list(table);
		//监听列表编辑操作
		listen_exception_handler_table_op(table, layer);
		
	});
});

function exception_title_edit_click(){
	/**异常页面编辑查询**/
	$("#exception_title_edit").click('on', function(){
		var tradeLimitsDom = $('.TradeLimits');
		var DateTimeDom = $('.DateTime');
		var VersionDom = $('.Version');
		var DesignerDom = $('.Designer');
		var ApprovalDom = $('.Approval');


		layui.use(['layer', 'form', 'table'], function(){
			var layer = layui.layer;
			var form = layui.form;
			var table = layui.table;
			layer.open({
				  skin: 'layui-layer-rim'
				  ,type: 1 //Page层类型
				  ,fixed: false
				  ,scrollbar: false
				  ,offset: 'auto'
				  ,area: ['460px']
				  ,title: '编辑'
				  ,shade: 0.6 //遮罩透明度
				  ,btn: ['取消','确认']
				  ,yes: function(index, layero){
				      //do something
                      
					layer.close(index); //如果设定了yes回调，需进行手工关闭
				  }
				  ,btn2: function(index, layero){
				      //标题赋值
					  var TradeLimitsVal = $('input[name="TradeLimits"]').val();
					  var DateTimeVal =    $('input[name="DateTime"]').val();
					  var VersionVal = $('input[name="Version"]').val();
					  var DesignerVal = $('input[name="Designer"]').val();
					  var ApprovalVal = $('input[name="Approval"]').val();

					  
					  tradeLimitsDom.text(TradeLimitsVal);
					  DateTimeDom.text(DateTimeVal);
					  VersionDom.text(VersionVal);
					  DesignerDom.text(DesignerVal);
					  ApprovalDom.text(ApprovalVal);

					  search_exception_handler_list(table, TradeLimitsVal, DateTimeVal, VersionVal, DesignerVal, ApprovalVal);
					  var Edit=[];
					  Edit.push("Exception_Handling");
					  Edit.push(TradeLimitsVal);
					  Edit.push(DateTimeVal);
					  Edit.push(VersionVal);
					  Edit.push(DesignerVal);
					  Edit.push(ApprovalVal);
					  $.ajax({
					      url: '/rj/New_Edit_Excel_Ver' ,
					      type: 'POST',
					      dataType:"json",
					      data: {Edit},
					      success: function(res){
					          if(res.msg == 'success'){
					              alert("更新成功");
					          }else{
					              alert('编辑失败');
					          }
					      }
					  });

				  }
				  ,content: 
				  	'<div class="layui-show">'
					+  '<div class="layui-col-sm12" style="padding: 12px 12px 6px 12px;">'
					+    '<div class="layui-show" style="height:28px;line-height:28px;">'
					+       '<div class="layui-col-sm4" style="padding-left: 46px;">使用范围</div>'
					+       '<div class="layui-col-sm8" style="width: 260px">'
					+			'<input type="text" class="layui-input" name="TradeLimits" value="'+tradeLimitsDom.text()+'">'
					+		'</div>'
					+    '</div>'
					+  '</div>'
					+  '<div class="layui-col-sm12" style="padding: 6px 12px;">'
					+    '<div class="layui-show" style="height:28px;line-height:28px;">'
					+       '<div class="layui-col-sm4" style="padding-left: 46px;">日期</div>'
					+       '<div class="layui-col-sm8" style="width: 260px">'
					+			'<input type="text" class="layui-input" name="DateTime" value="'+DateTimeDom.text()+'">'
					+		'</div>'
					+    '</div>'
					+   '</div>'
					+  '<div class="layui-col-sm12" style="padding: 6px 12px;">'
					+    '<div class="layui-show" style="height:28px;line-height:28px;">'
					+       '<div class="layui-col-sm4" style="padding-left: 46px;">Ver</div>'
					+       '<div class="layui-col-sm8" style="width: 260px">'
					+			'<input type="text" class="layui-input" name="Version" value="'+VersionDom.text()+'">'
					+		'</div>'
					+    '</div>'
					+   '</div>'
					+  '<div class="layui-col-sm12" style="padding: 6px 12px;">'
					+    '<div class="layui-show" style="height:28px;line-height:28px;">'
					+       '<div class="layui-col-sm4" style="padding-left: 46px;">设计</div>'
					+       '<div class="layui-col-sm8" style="width: 260px">'
					+			'<input type="text" class="layui-input" name="Designer" value="'+DesignerDom.text()+'">'
					+		'</div>'
					+    '</div>'
					+   '</div>'
					+  '<div class="layui-col-sm12" style="padding: 6px 12px;">'
					+    '<div class="layui-show" style="height:28px;line-height:28px;">'
					+       '<div class="layui-col-sm4" style="padding-left: 46px;">审批</div>'
					+       '<div class="layui-col-sm8" style="width: 260px">'
					+			'<input type="text" class="layui-input" name="Approval" value="'+ApprovalDom.text()+'">'
					+		'</div>'
					+    '</div>'
					+   '</div>'
					+'</div>'
			});
		});
	});
}

/**编辑异常报表的行操作**/
function listen_exception_handler_table_op(table, layer){
	table.on('tool(exception-handler-table)',function(obj){
		var eventStr = obj.event;
		switch(eventStr){
			case 'edit':
				editEvent(obj);
				
				break;
			case 'del':
			    delEvent(obj);
			    
				break;
			default:
				break;
		}
		
		
	});
    // 行编辑事件
	var editEvent = function(obj){
	    var data = obj.data;
	    layer.open({
	        skin: 'layui-layer-rim'
				  ,type: 1 //Page层类型
				  ,fixed: false
				  ,scrollbar: false
				  ,offset: 'auto'
				  ,area: ['580px']
				  ,title: '编辑'
				  ,shade: 0.6 //遮罩透明度
				  ,btn: ['取消','确认']
				  ,yes: function(index, layero){
				      //do something
				      layer.close(index); //如果设定了yes回调，需进行手工关闭
				  }
				  ,btn2: function(index, layero){
				      var formArray = $('#except_line_edit').serializeArray();
				      var formData = {};
				      $.each(formArray, function() {
				          formData[this.name] = this.value;
				      });
					  


				      //标题赋值
				      var ID = $('input[name="ID"]').val();
				      var AlarmInfo =    $('input[name="AlarmInfo"]').val();
				      var AlarmReason = $('input[name="AlarmReason"]').val();
				      var AlarmDeal = $('textarea[name="AlarmDeal"]').val();
				      var Status = $('input[name="Status"]').val();
				      var Version =    $('input[name="Version"]').val();
				      var DealMatter = $('input[name="DealMatter"]').val();
				      var Dealer = $('input[name="Dealer"]').val();
				      var Remakes = $('input[name="Remakes"]').val();

				     

				      //tradeLimitsDom.text(ID);
				      //DateTimeDom.text(AlarmInfo);
				      //VersionDom.text(AlarmReason);
				      //DesignerDom.text(AlarmDeal);
				      //ApprovalDom.text(Status);

				      //search_exception_handler_list(table, ID, AlarmInfo, AlarmReason, AlarmDeal, Status);
				      var Edit=[];
				      Edit.push(ID);
				      Edit.push(AlarmInfo);
				      Edit.push(AlarmReason);
				      Edit.push(AlarmDeal);
				      Edit.push(Status);
				     
				      Edit.push(Version);
				      Edit.push(DealMatter);
				      Edit.push(Dealer);
				      Edit.push(Remakes);

				      // todo 编辑行请求 套用js 的时候可以把这个地方打开
				      $.ajax({
				          url: '/rj/New_Edit_Exception_Handling' ,
				          type: 'POST',
				          dataType:"json",
				          data: {Edit},
				          success: function(res){
				              if(res.msg == 'success'){
				                  layer.msg("保存成功!",{ icon: 1, time: 1500 });
				                  obj.update(formData);
				              }else{
				                  layer.msg("保存失败!",{ icon: 2, time: 1500 });
				              }
				          }
				      });
				  }
				  ,content: 
				  	'<form id="except_line_edit"><div class="layui-show">'
					+  '<div class="layui-col-sm12" style="padding: 12px 12px 6px 12px;">'
					+    '<div class="layui-show" style="height:28px;line-height:28px;">'
					+       '<div class="layui-col-sm4" style="padding-left: 46px;">报警信息</div>'
					+       '<div class="layui-col-sm8" style="width: 360px">'
					+			'<input type="hidden" name="ID" value="'+data.Real_id+'">'
					+			'<input type="text" class="layui-input" name="AlarmInfo" value="'+data.AlarmInfo+'">'
					+		'</div>'
					+    '</div>'
					+  '</div>'
					+  '<div class="layui-col-sm12" style="padding: 6px 12px;">'
					+    '<div class="layui-show" style="height:28px;line-height:28px;">'
					+       '<div class="layui-col-sm4" style="padding-left: 46px;">报警原因</div>'
					+       '<div class="layui-col-sm8" style="width: 360px">'
					+			'<input type="text" class="layui-input" name="AlarmReason" value="'+data.AlarmReason+'">'
					+		'</div>'
					+    '</div>'
					+   '</div>'
					+  '<div class="layui-col-sm12" style="padding: 6px 12px;">'
					+    '<div class="layui-show" style="height:28px;line-height:28px;">'
					+       '<div class="layui-col-sm4" style="padding-left: 46px;">故障分析及处理对策</div>'
					+       '<div class="layui-col-sm8" style="width: 360px">'
					+			'<textarea id="AlarmDeal" class="layui-textarea" name="AlarmDeal">'+data.AlarmDeal+'</textarea>'
					+		'</div>'
					+    '</div>'
					+   '</div>'
					+  '<div class="layui-col-sm12" style="padding: 6px 12px;">'
					+    '<div class="layui-show" style="height:28px;line-height:28px;">'
					+       '<div class="layui-col-sm4" style="padding-left: 46px;">状态</div>'
					+       '<div class="layui-col-sm8" style="width: 360px">'
					+			'<input type="text" class="layui-input" name="Status" value="'+data.Status+'">'
					+		'</div>'
					+    '</div>'
					+   '</div>'
					+  '<div class="layui-col-sm12" style="padding: 6px 12px;">'
					+    '<div class="layui-show" style="height:28px;line-height:28px;">'
					+       '<div class="layui-col-sm4" style="padding-left: 46px;">版本维护</div>'
					+       '<div class="layui-col-sm8" style="width: 360px">'
					+			'<input type="text" class="layui-input" name="Version" value="'+data.Version+'">'
					+		'</div>'
					+    '</div>'
					+   '</div>'
					+  '<div class="layui-col-sm12" style="padding: 6px 12px;">'
					+    '<div class="layui-show" style="height:28px;line-height:28px;">'
					+       '<div class="layui-col-sm4" style="padding-left: 46px;">维护事项</div>'
					+       '<div class="layui-col-sm8" style="width: 360px">'
					+			'<input type="text" class="layui-input" name="DealMatter" value="'+data.DealMatter+'">'
					+		'</div>'
					+    '</div>'
					+   '</div>'
					+  '<div class="layui-col-sm12" style="padding: 6px 12px;">'
					+    '<div class="layui-show" style="height:28px;line-height:28px;">'
					+       '<div class="layui-col-sm4" style="padding-left: 46px;">维护人</div>'
					+       '<div class="layui-col-sm8" style="width: 360px">'
					+			'<input type="text" class="layui-input" name="Dealer" value="'+data.Dealer+'">'
					+		'</div>'
					+    '</div>'
					+   '</div>'
					+  '<div class="layui-col-sm12" style="padding: 6px 12px;">'
					+    '<div class="layui-show" style="height:28px;line-height:28px;">'
					+       '<div class="layui-col-sm4" style="padding-left: 46px;">备注</div>'
					+       '<div class="layui-col-sm8" style="width: 360px">'
					+			'<input type="text" class="layui-input" name="Remakes" value="'+data.Remakes+'">'
					+		'</div>'
					+    '</div>'
					+   '</div>'
					+'</div></form>'
	    });
	}
	// 行删除事件
	var delEvent = function(obj){
	    //标题赋值
	    var data = obj.data;
	    layer.confirm('是否要删除信息!', {
	        btn: ['确定', '取消']
	    }, function (index, layero) {

	    //alert(data.Real_id);
		$.ajax({
		    url:  '/rj/Exception_Handling_Delete',
		  type: 'POST',
		  dataType:"json",
		  data: {ID:data.Real_id},
		  success: function(res){
			if(res.msg == 'success'){
				alert("删除成功");
				obj.del();
				layer.close(index);
			}else{
				alert('失败');
			}
		  }
		});
	});
	}





}



/**查询异常报表**/
function search_exception_handler_list(table, TradeLimitsVal="", DateTimeVal="", VersionVal="", DesignerVal="", ApprovalVal=""){
	
	var field = [
		{field: 'ID', title: '序列号', align: 'left'}
		,{field: 'AlarmInfo', title: '报警信息', align: 'left', width: 180}
		,{field: 'AlarmReason', title: '报警原因', align: 'left', width: 240 }
		,{field: 'AlarmDeal', title: '故障分析及处理对策', align: 'left', width: 360}
		,{field: 'Status', title: '状态', align: 'left'}
		,{field: 'Version', title: '维护版本', align: 'left' }
		,{field: 'DealMatter', title: '维护事项', align: 'left'}
		,{field: 'Dealer', title: '维护人', align: 'left'}
		,{field: 'Remakes', title: '备注', align: 'left'}
		,{fixed: 'right', title: '操作', toolbar:"#exception-line-operation", width: 120}
	];
	
	table.render({
		elem: '#exception-handler-list'
		,cellMinWidth:'80'
		,size: 'sm'
		,page: {
		    layout: ['limit', 'count', 'prev', 'page', 'next'] //自定义分页布局
		    //layout: [ 'count', 'prev', 'page', 'next'] //自定义分页布局
			,groups: 5
			,first: '首页' //不显示首页
			,last : '尾页'
			,prev: '<em><<</em>'
    		,next: '<em>>></em>'
			//,limits: [5,10,15,20]
		} //开启分页
		,limits: [1,3,6,10]
		,url:'/rj/New_Exception_Handling_Index_Info'   //使用url获取参数的话 可以配合limit限制行数
		,method:'get'
		,where: {}
		,parseData:function(res){ // 请求回传的参数es
			//alert(JSON.stringify(res));
			var data = [];
			for(var index in res.data){
				var item = res.data[index];
				data.push({
				    'ID': item.ID
                    ,'Real_id': item.Real_id
					,'AlarmInfo': item.Alarm_Info
					,'AlarmReason': item.Alarm_Cause
					,'AlarmDeal': item.Fault_Analysis
					,'Status': item.Status
					,'Version': item.Ver
					,'DealMatter': item.Maintenance_Matters
					,'Dealer': item.Maintenance_Owner
					,'Remakes': item.Mark
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

