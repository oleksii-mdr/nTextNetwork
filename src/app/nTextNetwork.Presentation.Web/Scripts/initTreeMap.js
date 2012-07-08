var labelType, useGradients, nativeTextSupport, animate;

function getJsonResult(id) {
    $.ajax({
        url: "Home/GetFileById",
        data: { "fileId": id }
    }).done(function (xhr) {
        InitTreeMap(xhr);

        var hiddenField = document.getElementById('hiddenField');
      
        //getPunctuationLiterals(id);
    });
}

function getPunctuationLiterals(id) {
    $.ajax({
        url: "Home/GetPunctuationLiterals",
        data: { "fileId": id }
    }).done(function(xhr) {

    });
}

(function() {
        var ua = navigator.userAgent,
            iStuff = ua.match( /iPhone/i ) || ua.match( /iPad/i ),
            typeOfCanvas = typeof HTMLCanvasElement,
            nativeCanvasSupport = (typeOfCanvas == 'object' || typeOfCanvas == 'function'),
            textSupport = nativeCanvasSupport
                && (typeof document.createElement('canvas').getContext('2d').fillText == 'function');
        //I'm setting this based on the fact that ExCanvas provides text support for IE
        //and that as of today iPhone/iPad current text support is lame
        labelType = (!nativeCanvasSupport || (textSupport && !iStuff)) ? 'Native' : 'HTML';
        nativeTextSupport = labelType == 'Native';
        useGradients = nativeCanvasSupport;
        animate = !(iStuff || !nativeCanvasSupport);
    })();


    //init TreeMap

    function InitTreeMap(responce) {
        $('#infovis').empty();

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
                onClick: function(node) {
                    if (node) tm.enter(node);
                },
                onRightClick: function() {
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
                onShow: function(tip, node, isLeaf, domElement) {
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
            onCreateLabel: function(domElement, node) {
                domElement.innerHTML = node.name;
                var style = domElement.style;
                style.display = '';
                style.border = '1px solid transparent';
                domElement.onmouseover = function() {
                    style.border = '1px solid #9FD4FF';
                };
                domElement.onmouseout = function() {
                    style.border = '1px solid transparent';
                };
            }
        });

        json_data_object = (responce.indexOf("\"") == 0) ? JSON.parse(responce) : responce;

        tm.loadJSON(JSON.parse(json_data_object));
        tm.refresh();
        //end

    }
