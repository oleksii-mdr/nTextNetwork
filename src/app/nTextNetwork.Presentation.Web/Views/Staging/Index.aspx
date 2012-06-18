
<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Staging</title>
    <link href="../../Styles/base.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/Treemap.css" rel="stylesheet" type="text/css" />
    <script src="../../Skripts/jit.js" type="text/javascript"></script>
    <script src="../../Skripts/WordsTree.Sample.js" type="text/javascript"></script>
    <script>

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
                        var html = "<div class=\"tip-title\">" + node.name
          + "</div><div class=\"tip-text\">";
                        var data = node.data;
                        if (data.playcount) {
                            html += "play count: " + data.playcount;
                        }
                        if (data.image) {
                            html += "<img src=\"" + data.image + "\" class=\"album\" />";
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
<body  onload="init();">
    
    <div>
        <form action="" method="post" enctype="multipart/form-data">
        <label for="file">
            Filename:</label>
        <input type="file" name="file" id="file" />
        <input type="submit" />
        </form>
    </div>

     <div id="container">
        <div id="left-container">
            <div class="text">
                <h4>
                    Animated Squarified, SliceAndDice and Strip TreeMaps
                </h4>
                In this example a static JSON tree is loaded into a Squarified Treemap.<br />
                <br />
                <b>Left click</b> to set a node as root for the visualization.<br />
                <br />
                <b>Right click</b> to set the parent node as root for the visualization.<br />
                <br />
                You can <b>choose a different tiling algorithm</b> below:
            </div>
            <div id="id-list">
                <table>
                    <tr>
                        <td>
                            <label for="r-sq">
                                Squarified
                            </label>
                        </td>
                        <td>
                            <input type="radio" id="r-sq" name="layout" checked="checked" value="left" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="r-st">
                                Strip
                            </label>
                        </td>
                        <td>
                            <input type="radio" id="r-st" name="layout" value="top" />
                        </td>
                        <tr>
                            <td>
                                <label for="r-sd">
                                    SliceAndDice
                                </label>
                            </td>
                            <td>
                                <input type="radio" id="r-sd" name="layout" value="bottom" />
                            </td>
                        </tr>
                </table>
            </div>
            <a id="back" href="#" class="theme button white">Go to Parent</a>
            <div style="text-align: center;">
                <a href="../Staging/example1.js">See the Example Code</a></div>
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