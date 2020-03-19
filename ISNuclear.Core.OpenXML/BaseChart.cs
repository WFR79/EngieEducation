using System;
using System.Collections.Generic;
using System.Linq;
using ISNuclear.Data.Interfaces;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing;

namespace ISNuclear.OpenXML
{
    public abstract class BaseChart<Y>
    {
        #region "Fields"
        DocumentFormat.OpenXml.Drawing.Charts.Chart _chart;
        ChartPart _chartPart;
        protected IEnumerable<DataLabel> _dataLabels = new List<DataLabel>();
        DrawingsPart _drawingsPart;
        readonly IGlobal<Y> _global;
        #endregion

        #region "Properties"
        protected DocumentFormat.OpenXml.Drawing.Charts.Chart Chart => _chart
            ?? (_chart = ChartSpace.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Chart(new Legend(new LegendPosition { Val = LegendPositionValues.Top },
                                                                                                           new Layout(), new Overlay { Val = false }),
                                                                                                           new PlotVisibleOnly { Val = true },
                                                                                                           new DisplayBlanksAs { Val = DisplayBlanksAsValues.Span })));

        protected ChartPart ChartPart => _chartPart ?? (_chartPart = _drawingsPart.AddNewPart<ChartPart>());
        protected ChartSpace ChartSpace => ChartPart.ChartSpace ?? (ChartPart.ChartSpace = new ChartSpace(new EditingLanguage { Val = "en-US" }, new RoundedCorners { Val = false }));
        protected IGlobal<Y> Global => _global;
        protected PlotArea PlotArea => Chart.PlotArea ?? (Chart.PlotArea = new PlotArea(new Layout()));
        public string Id =>_drawingsPart.GetIdOfPart(_chartPart);
        #endregion

        #region "Constructors"
        public BaseChart(IGlobal<Y> global, DrawingsPart drawingsPart)
        {
            _drawingsPart = drawingsPart;
            _global = global ?? throw new ArgumentNullException(nameof(global));
        }
        #endregion

        #region "Methods"
        protected IEnumerable<DataLabel> AddDataLabels(LineChartSeries series, int start, int end)
        {
            var returnList = new List<DataLabel>();
            if (start > -1)
            {
                if (end > -1 && start > end)
                {
                    var tmp = start;
                    start = end;
                    end = start;
                }
                else if (start == end) { start = end - 1; }

                var numberFormat = new NumberingFormat { FormatCode = "#,##0", SourceLinked = false };
                var dataLabels = series.AppendChild(
                    new DataLabels(numberFormat, new DataLabelPosition { Val = DataLabelPositionValues.Top }, 
                                   new ShowLegendKey { Val = false }, new ShowValue { Val = false }, 
                                   new ShowCategoryName { Val = false }, new ShowSeriesName { Val = false },
                                   new ShowPercent { Val = false }, new ShowBubbleSize { Val = false }, 
                                   new ShowLeaderLines { Val = false }));

                while (start < end)
                {
                    var label = new DataLabel(new Index { Val = (uint)start }, new Layout(),
                                              new NumberingFormat 
                                              { 
                                                  FormatCode = "#,##0", 
                                                  SourceLinked = false 
                                              }, new Separator(), 
                                              new TextProperties(
                                                  new BodyProperties(), new ListStyle(), 
                                                  new Paragraph(new ParagraphProperties(new DefaultRunProperties { Bold = true }), new EndParagraphRunProperties { Language = "en-US" })),
                                              new DataLabelPosition { Val = DataLabelPositionValues.Top },
                                              new ShowLegendKey { Val = false }, 
                                              new ShowValue { Val = true },
                                              new ShowCategoryName { Val = false },
                                              new ShowSeriesName { Val = false }, 
                                              new ShowPercent { Val = false },
                                              new ShowBubbleSize { Val = false },
                                              new ShowLeaderLines { Val = false });
                    dataLabels.InsertBefore(label, numberFormat);
                    returnList.Add(label);
                    start++;
                }
            }
            return returnList;
        }

        protected void CheckDataLabels()
        {
            var grouped = _dataLabels.GroupBy(d => d.Index.Val.Value);

            foreach (var group in grouped)
            {
                if (group.Count() > 1)
                {
                    var sorted = group.Select(d => new KeyValuePair<double, DataLabel>(
                        double.Parse(((d.Parent.Parent as LineChartSeries).Elements<Values>().First()
                                                                          .NumberLiteral
                                                                          .Elements<NumericPoint>()
                                                                          .FirstOrDefault(n => n.Index.Value == d.Index.Val.Value) ?? new NumericPoint(new NumericValue { Text = "0" })).NumericValue.Text.Replace(".", ",")), d)).OrderBy(k => k.Key);
                    
                    // Find the lowest label and move to bottom
                    if (sorted.First().Key != 0)
                    {
                        sorted.First().Value.Elements<DataLabelPosition>().First().Val = DataLabelPositionValues.Bottom;
                    }
                    // If there are 3 labels for an index, move the middle label to right
                    if (group.Count() == 3)
                    {
                        sorted.ElementAt(1).Value.Elements<DataLabelPosition>().First().Val = DataLabelPositionValues.Right;
                    }
                    // Leave the highest label on top
                }
            }
        }
        #endregion
    }
}
