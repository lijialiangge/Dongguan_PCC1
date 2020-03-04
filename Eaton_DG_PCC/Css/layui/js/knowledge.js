// 知识库相关js

$(function(){
	/**异常页面编辑查询**/
	knowledge_title_edit_click();
	layui.use(['layer', 'form', 'table', 'layedit'], function(){
		var layer = layui.layer;
		var form = layui.form;
		var table = layui.table;
	});
	
	/**手册详情富文本插入到页面中**/
	//todo demo , knowledgeDetail 即加载以后的模板渲染
	var knowledgeDetail = '<div style="font-weight:bold;">测试模板渲染</div>'
        +'<div style="font-weight:bold;">测试模板渲染2</div>'
    +'<div style="font-weight:bold;">测试模板渲染3</div>'
    +'<div style="font-weight:bold;">测试模板渲染4</div>';
	$(".knowledge-content-detail").html(knowledgeDetail);
});


function knowledge_title_edit_click(){
    alert("knowledge_title_edit_click1");
	/**编辑查询**/
	$("#knowledge_title_edit").click('on', function(){
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
					  var DateTimeVal = $('input[name="DateTime"]').val();
					  var VersionVal = $('input[name="Version"]').val();
					  var DesignerVal = $('input[name="Designer"]').val();
					  var ApprovalVal = $('input[name="Approval"]').val();
					  tradeLimitsDom.text(TradeLimitsVal);
					  DateTimeDom.text(DateTimeVal);
					  VersionDom.text(VersionVal);
					  DesignerDom.text(DesignerVal);
					  ApprovalDom.text(ApprovalVal);
					  search_knowledge_list(TradeLimitsVal, DateTimeVal, VersionVal, DesignerVal, ApprovalVal);
				  }
				  ,content: 
				  	'<div class="layui-show">'
					+  '<div class="layui-col-sm12" style="padding: 12px 12px 6px 12px;">'
					+    '<div class="layui-show" style="height:28px;line-height:28px;">'
					+       '<div class="layui-col-sm4" style="padding-left: 46px;">使用范围</div>'
					+       '<div class="layui-col-sm8" style="width: 260px">'
					+			'<input text="text" class="layui-input" name="TradeLimits" value="'+tradeLimitsDom.text()+'">'
					+		'</div>'
					+    '</div>'
					+  '</div>'
					+  '<div class="layui-col-sm12" style="padding: 6px 12px;">'
					+    '<div class="layui-show" style="height:28px;line-height:28px;">'
					+       '<div class="layui-col-sm4" style="padding-left: 46px;">日期</div>'
					+       '<div class="layui-col-sm8" style="width: 260px">'
					+			'<input text="text" class="layui-input" name="TradeLimits" value="'+DateTimeDom.text()+'">'
					+		'</div>'
					+    '</div>'
					+   '</div>'
					+  '<div class="layui-col-sm12" style="padding: 6px 12px;">'
					+    '<div class="layui-show" style="height:28px;line-height:28px;">'
					+       '<div class="layui-col-sm4" style="padding-left: 46px;">Ver</div>'
					+       '<div class="layui-col-sm8" style="width: 260px">'
					+			'<input text="text" class="layui-input" name="Version" value="'+VersionDom.text()+'">'
					+		'</div>'
					+    '</div>'
					+   '</div>'
					+  '<div class="layui-col-sm12" style="padding: 6px 12px;">'
					+    '<div class="layui-show" style="height:28px;line-height:28px;">'
					+       '<div class="layui-col-sm4" style="padding-left: 46px;">设计</div>'
					+       '<div class="layui-col-sm8" style="width: 260px">'
					+			'<input text="text" class="layui-input" name="Designer" value="'+DesignerDom.text()+'">'
					+		'</div>'
					+    '</div>'
					+   '</div>'
					+  '<div class="layui-col-sm12" style="padding: 6px 12px;">'
					+    '<div class="layui-show" style="height:28px;line-height:28px;">'
					+       '<div class="layui-col-sm4" style="padding-left: 46px;">审批</div>'
					+       '<div class="layui-col-sm8" style="width: 260px">'
					+			'<input text="text" class="layui-input" name="Approval" value="'+ApprovalDom.text()+'">'
					+		'</div>'
					+    '</div>'
					+   '</div>'
					+'</div>'
			});
		});
	});
}

function search_knowledge_list(TradeLimitsVal='', DateTimeVal='', VersionVal='', DesignerVal='', ApprovalVal=''){
    alert("search_knowledge_list2");
	$.ajax({
	    //url: 'https://www.layui.com/demo/table/user/',
	    url: '/rj/test',
		type: 'get',
		data: {
			TradeLimitsVal: TradeLimitsVal, 
			DateTimeVal: DateTimeVal, 
			VersionVal: VersionVal, 
			DesignerVal: DesignerVal, 
			ApprovalVal: ApprovalVal},
		//dataType:"json",
		success: function(res){
			// 测试数据
			var data = [
				{'ID': 1, 'Title': '一、真空抽不下去了', 'DataTime': '2019/07/1'}
				,{'ID': 2, 'Title': '二、设备温度报警', 'DataTime': '2019/07/2'}
				,{'ID': 3, 'Title': '三、温度故障处理', 'DataTime': '2019/07/3'}
				,{'ID': 4, 'Title': '四、漏电处理', 'DataTime': '2019/07/4'}
				,{'ID': 5, 'Title': '五、伺服电机升降问题', 'DataTime': '2019/07/5'}
				,{'ID': 6, 'Title': '六、CDG显示数据不稳定', 'DataTime': '2019/07/6'}
				,{'ID': 7, 'Title': '七、触摸屏上显示出现异常', 'DataTime': '2019/07/7'}
				,{'ID': 8, 'Title': '八、匹配器匹配不上', 'DataTime': '2019/07/8'}
			];
			var res={msg: 'success', data: data};
			//var data=res.data;
			//示例
			
			if(res.msg=="success"){
				var htmlLoad = '';
				for(var i in res.data){
					var dataItem = res.data[i];
					htmlLoad += '<li>'
								+'	<div class="layui-block">'
								+'		<div class="layui-block-item-title layui-row">'
								+'			<div class="pb17">'+dataItem.Title+'</div>'
								+'		</div>'
								+'		<div class="layui-block-item-content layui-row">'
								+'			<div class="layui-col-sm12 pl16 devices-item-td">编辑时间:'+dataItem.DataTime+'</div>'
								+'		</div>'
								+'		<div class="layui-block-item-footer layui-row">'
								+'			<div class="layui-col-sm12" style="padding: 12px 3px; float:right;">'
								+'				<button type="button" class="layui-btn layui-btn-primary layui-btn-sm" onclick="knowledgeEdit(this, '+dataItem.ID+')">编辑X</button>'
								+'				<button type="button" class="layui-btn layui-btn-primary layui-btn-sm" onclick="knowledgeDel(this, '+dataItem.ID+')">删除Y</button>'
								+'			</div> '
								+'		</div>'
								+'	</div>'
								+'</li>';
				}
				
				$('.knowledge-list-ul').html(htmlLoad);
			}
		}	
	});
}

/****保存用户维护手册*****/
    function save_knowledage(params){
        alert("save_knowledage");
	$.ajax({
		url: 'https://www.layui.com/demo/table/user/',
		type: 'get',
		data: params,
		//dataType:"json",
		success: function(res){
			// demo
			var res={'msg': 'success', data: {ID:"12", UpDateTime: '2019/07/13 20:10'}};
			if(res.msg == 'success'){
				var alertTitle = params.type=="add" ? '新增成功' : '编辑成功';
				alert(alertTitle);
				if(params.type == 'add'){
					var addHtml = '<li>'
								+'	<div class="layui-block">'
								+'		<div class="layui-block-item-title layui-row">'
								+'			<div class="pb17">'+params.title+'</div>'
								+'		</div>'
								+'		<div class="layui-block-item-content layui-row">'
								+'			<div class="layui-col-sm12 pl16 devices-item-td">编辑时间:'+res.data.UpDateTime+'</div>'
								+'		</div>'
								+'		<div class="layui-block-item-footer layui-row">'
								+'			<div class="layui-col-sm12" style="padding: 12px 3px; float:right;">'
								+'				<button type="button" class="layui-btn layui-btn-primary layui-btn-sm" onclick="knowledgeEdit(this, '+res.data.ID+')">编辑</button>'
								+'				<button type="button" class="layui-btn layui-btn-primary layui-btn-sm" onclick="knowledgeDel(this, '+res.data.ID+')">删除</button>'
								+'			</div> '
								+'		</div>'
								+'	</div>'
								+'</li>';
					$(".knowledge-list-ul").append(addHtml);
				}else{
					var content = params.title_content;
					//编辑页面弹层
					$(".knowledge-content-detail").html(content);
					$(".knowledge-content-title").text(params.title);
					$(".knowledge-content-DateTime").text(res.data.UpDateTime);
				}
			}else{
				alert('保存失败');
			}
		}
	});
}

/***删除手册***/
// fromPage 0 在列表也删除 1 在详情页删除

function knowledgeDel(self, ID, fromPage=0){
    alert("knowledgeDel——edit4");
	layer.confirm('确认删除？', {
	  btn: ['取消', '确认'] //可以无限个按钮
	  ,btn2: function(index, layero){
			$.ajax({
			url: 'https://www.layui.com/demo/table/user/',
			type: 'get',
			data: {ID: ID},
			//dataType:"json",
			success: function(res){
				// demo
				var res={'msg': 'success', data: {ID: ID, title: '测试标题', content: '测试内容'}};
				if(res.msg == 'success'){
					alert('删除成功');
					if(fromPage==0){
						//成功后删除节点
						$(self).parent('div').parent('div.layui-block-item-footer').parent('.layui-block').parent('li').remove();
					}else{
						// 在编辑页删除需要跳转到列表页
						location.href = 'knowledge.html';
					}
					
				}else{
					alert('删除失败');
				}
			}
	});
	  }
	}, function(index, layero){
	  //按钮【按钮一】的回调
	  layer.close(index);
	});
}

/****新建维护手册***********/
    function knowledge_add(){
        alert("knowledge_add");
	knowledge_layer();
}

function knowledgeEdit(self, ID){
    //跳转到详情页@Url.Action("Edit_Faq","PCTron", new { ID=@item.ID ,DeviceId =@item.DeviceId })
    //location.href = 'knowledge_detail.html?ID='+ID;
    //alert(ID);
    location.href = '/rj/New_FAQ2_Detailed/?ID='+11111;
    //alert("out");
    
}

/***编辑维护手册**/
function knowledgeDetailEdit(ID){
    alert("knowledgeDetailEdit3");
	$.ajax({
		url: 'https://www.layui.com/demo/table/user/',
		type: 'get',
		data: {ID: ID},
		//dataType:"json",
		success: function(res){
			// demo
			var res={'msg': 'success', data: {ID: ID, title: '测试标题', content: '测试内容'}};
			if(res.msg == 'success'){
				// 跳转页面
				//location.href = '';
				knowledge_layer(ID, res.data.title, res.data.content, 'edit');
			}
		}
	});
}



/***维护手册弹层***/
function knowledge_layer(id="", title='', title_content='', type='add'){
    alert("knowledge_layer");
	var layer_title = type=='add' ? '新增': '编辑';
	layui.use(['layer', 'form', 'table', 'layedit'], function(){
		var layer = layui.layer;
		var form = layui.form;
		var table = layui.table;
		var layedit = layui.layedit;
		var layeditBuildIndex = null;
		layer.open({
			  skin: 'layui-layer-rim'
			  ,type: 1 //Page层类型
			  ,fixed: false
			  ,scrollbar: false
			  ,offset: 'auto'
			  ,area: ['520px', '580px']
			  ,title: layer_title
			  ,shade: 0.6 //遮罩透明度
			  ,btn: ['取消','确认']
			  ,yes: function(index, layero){
				//do something
				layer.close(index); //如果设定了yes回调，需进行手工关闭
			  }
			  ,btn2: function(index, layero){
				  var content = layedit.getContent(layeditBuildIndex);
				  var title = $('input[name="title"]').val();
				  var Id = $('input[name="ID"]').val();
				  var params = {
					  Id: id
					  ,type: type
					  ,title: title
					  ,title_content: content
				  }
				  if(type=="add"){
					  var TradeLimitsVal = $('input[name="TradeLimits"]').val();
					  var DateTimeVal = $('input[name="DateTime"]').val();
					  var VersionVal = $('input[name="Version"]').val();
					  var DesignerVal = $('input[name="Designer"]').val();
					  var ApprovalVal = $('input[name="Approval"]').val();
					  params['TradeLimitsVal'] = TradeLimitsVal;
					  params['DateTimeVal'] = DateTimeVal;
					  params['VersionVal'] = VersionVal;
					  params['DesignerVal'] = DesignerVal;
					  params['ApprovalVal'] = ApprovalVal;
				  }
				  //标题赋值
				  save_knowledage(params);
			  }
			  ,content: 
				'<div class="layui-show">'
				+  '<div class="layui-col-sm12" style="padding: 12px 12px 6px 12px;">'
				+    '<div class="layui-show" style="height:28px;line-height:28px;">'
				+       '<div class="layui-col-sm12" style="padding: 0 2%; font-weight: bold;">标题</div>'
				+    '</div>'
				+    '<div class="layui-show" style="height:28px;line-height:28px;">'
				+       '<div class="layui-col-sm12" style="width: 100%;padding: 0 2%;">'
				+		 	'<input type="hidden" name="ID" value="'+id+'">'
				+			'<input type="text" class="layui-input" name="title" value="'+title+'">'
				+		'</div>'
				+    '</div>'
				+  '</div>'
				+  '<div class="layui-col-sm12" style="padding: 12px 12px 6px 12px;">'
				+    '<div class="layui-show" style="height:28px;line-height:28px;">'
				+       '<div class="layui-col-sm12" style="padding: 0 2%; font-weight: bold;">内容</div>'
				+    '</div>'
				+    '<div class="layui-show" style="height:28px;line-height:28px;">'
				+       '<div class="layui-col-sm12" style="width: 100%;padding: 0 2%;">'
				+			'<textarea id="knowledge_text" class="layui-textarea" lay-verify="content" style="display: none" name="title_content">'+title_content+'</textarea>'
				+		'</div>'
				+    '</div>'
				+  '</div>'
				+'</div>'
		});
		layeditBuildIndex = layedit.build('knowledge_text', {
			height: 300
			,tool: [
				'strong' //加粗
  				,'italic' //斜体
				,'underline' //下划线
				,'left' //左对齐
				,'center' //居中对齐
				,'right' //右对齐
			]	
		});
		layedit.setContent(layeditBuildIndex, title_content);
	});
}
