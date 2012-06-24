<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>nTextNetwork - Home</title>
	<link href="../../Styles/base.css" rel="stylesheet" type="text/css" />
	<link href="../../Styles/Treemap.css" rel="stylesheet" type="text/css" />
	<script src="../../Skripts/jit.js" type="text/javascript"></script>
	<script type="text/javascript">
		var labelType, useGradients, nativeTextSupport, animate;

		(function() {
		  var ua = navigator.userAgent,
			  iStuff = ua.match(/iPhone/i) || ua.match(/iPad/i),
			  typeOfCanvas = typeof HTMLCanvasElement,
			  nativeCanvasSupport = (typeOfCanvas == 'object' || typeOfCanvas == 'function'),
			  textSupport = nativeCanvasSupport
				&& (typeof document.createElement('canvas').getContext('2d').fillText == 'function');
		  //I'm setting this based on the fact that ExCanvas provides text support for IE
		  //and that as of today iPhone/iPad current text support is lame
		  labelType = (!nativeCanvasSupport || (textSupport && !iStuff))? 'Native' : 'HTML';
		  nativeTextSupport = labelType == 'Native';
		  useGradients = nativeCanvasSupport;
		  animate = !(iStuff || !nativeCanvasSupport);
		})();


		function init() {

		//init TreeMap
		var tm = new $jit.TM.Squarified({
			//where to inject the visualization
			injectInto: 'infovis',
			//parent box title heights
			titleHeight: 15,
			//enable animations
			animate: animate,
			//box offsets
			offset: 1,
			//Attach left and right click events
			Events: {
				enable: true,
				onClick: function (node) {
					if (node) tm.enter(node);
				},
				onRightClick: function () {
					tm.out();
				}
			},
			duration: 1000,
			//Enable tips
			Tips: {
				enable: true,
				//add positioning offsets
				offsetX: 20,
				offsetY: 20,
				//implement the onShow method to
				//add content to the tooltip when a node
				//is hovered
				onShow: function (tip, node, isLeaf, domElement) {
					var html = "<div class=\"tip-title\">" + node.name +
								"</div><div class=\"tip-text\">";
					var data = node.data;
					if (data.count) {
						html += "count: " + data.count;
					}
					tip.innerHTML = html;
				}
			},
			//Add the name of the node in the correponding label
			//This method is called once, on label creation.
			onCreateLabel: function (domElement, node) {
				domElement.innerHTML = node.name;
				var style = domElement.style;
				style.display = '';
				style.border = '1px solid transparent';
				domElement.onmouseover = function () {
					style.border = '1px solid #9FD4FF';
				};
				domElement.onmouseout = function () {
					style.border = '1px solid transparent';
				};
			}
		});
		tm.loadJSON(<%= ViewData["json"] as string %>);
		tm.refresh();
		//end
		//add events to radio buttons
		var sq = $jit.id('r-sq'),
	st = $jit.id('r-st'),
	sd = $jit.id('r-sd');
		var util = $jit.util;
		util.addEvent(sq, 'change', function () {
			if (!sq.checked) return;
			util.extend(tm, new $jit.Layouts.TM.Squarified);
			tm.refresh();
		});
		util.addEvent(st, 'change', function () {
			if (!st.checked) return;
			util.extend(tm, new $jit.Layouts.TM.Strip);
			tm.layout.orientation = "v";
			tm.refresh();
		});
		util.addEvent(sd, 'change', function () {
			if (!sd.checked) return;
			util.extend(tm, new $jit.Layouts.TM.SliceAndDice);
			tm.layout.orientation = "v";
			tm.refresh();
		});
		//add event to the back button
		var back = $jit.id('back');
		$jit.util.addEvent(back, 'click', function () {
			tm.out();
		});
	}

	</script>
</head>
<body onload="init();">
	<div style="margin-bottom: 10px; margin-top: 10px;">
		<form action="" method="post" enctype="multipart/form-data">
		<label for="file">
			Filename:</label>
		<input type="file" name="file" id="file" />
		<input type="submit" value="Upload" />
		</form>
	</div>
	<div id="container">
		<div id="left-container">
			<div class="text">
				<h4><a href="https://github.com/oleksii-mdr/nTextNetwork">nTextNetwork</a></h4>
				
			This demo shows the top 50 most frequently used words in a text file. Follow these steps to see it working
			<ol>
				<li>Browse for a .txt file</li>
				<li>Click upload</li>				
			</ol> 

			In a few seconds you should see an image similar to <a href="http://i.imgur.com/yewgu.png">this</a>.
			</div>

		</div>
		<div id="center-container">
			<div id="infovis">
			</div>
		</div>
		<div id="right-container">
			<div id="inner-details">
			</div>
		</div>
		<div id="log">
		</div>
	</div>
</body>
</html>