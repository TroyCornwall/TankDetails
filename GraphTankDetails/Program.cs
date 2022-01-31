using GraphTankDetails.Models;
using Microsoft.FSharp.Collections;
using Newtonsoft.Json;
using Plotly.NET;
using Plotly.NET.ImageExport;
using Plotly.NET.LayoutObjects;


var content = File.ReadAllText("status.json");
var statuses = JsonConvert.DeserializeObject<List<ApexExtract>>(content);
statuses = statuses.TakeLast(100).ToList(); //reduce memory usage..


LinearAxis xAxis = new LinearAxis();
xAxis.SetValue("title", "Time");
xAxis.SetValue("zerolinecolor", "#ffff");
xAxis.SetValue("gridcolor", "#ffff");
xAxis.SetValue("showline", true);
xAxis.SetValue("zerolinewidth",2);

LinearAxis yAxis = new LinearAxis();
yAxis.SetValue("title", "Alk");
yAxis.SetValue("zerolinecolor", "#ffff");
yAxis.SetValue("gridcolor", "#ffff");
yAxis.SetValue("showline", true);
yAxis.SetValue("zerolinewidth",2);

Layout layout = new Layout();
layout.SetValue("xaxis", xAxis);
layout.SetValue("yaxis", yAxis);
layout.SetValue("title", "Tank Details");
layout.SetValue("plot_bgcolor", "#e5ecf6");
layout.SetValue("showlegend", true);

// Trace trace = new Trace("line");
// trace.SetValue("x", new []{1,2,3});
// trace.SetValue("y", new []{1,3,2});
var time = statuses.Select(x=> x.Timestamp).ToArray();
Trace alk = new Trace("line");
alk.SetValue("x", time);
alk.SetValue("y", statuses.Select(x=> x.Alk));



var fig = GenericChart.Figure.create(ListModule.OfSeq(new []{alk}), layout);
var poop = GenericChart.fromFigure(fig);


Trace calc = new Trace("line");
calc.SetValue("x", time);
calc.SetValue("y", statuses.Select(x=> x.Calc));

var calcFig = GenericChart.Figure.create(ListModule.OfSeq(new []{calc}), layout);
var calcChart = GenericChart.fromFigure(calcFig);
var combined = GenericChart.combine(new[] {poop, calcChart});

combined.SaveJPG("tank");