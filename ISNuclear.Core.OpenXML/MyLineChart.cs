using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml.Packaging;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml;
using d=DocumentFormat.OpenXml.Drawing;

namespace ISNuclear.OpenXML
{
    public static class MyLineChart
    {
        public static LineChartSeries CreateLineChartSeries(this LineChart lineChart, string text, UInt32Value index)
        {
            return lineChart.AppendChild(new LineChartSeries(new Index() { Val = index }, new Order() { Val = index },
                                                             new SeriesText(new NumericValue(text)), new Smooth() { Val = false }));
        }

        public static LineChartSeries CreateLineChartSeries(this LineChart lineChart, string text, UInt32Value index, string outLineColor, string markerColor, MarkerStyleValues symbol, d::PresetLineDashValues dashed = d::PresetLineDashValues.Solid, byte size = 7, d::Outline markerOutLine = null)
        {
            var series = lineChart.CreateLineChartSeries(text, index);
            var properties = series.InsertAfter(new ChartShapeProperties(new d::Outline(new d::SolidFill(new d::RgbColorModelHex() { Val = new HexBinaryValue(outLineColor) }), new d::PresetDash() { Val = dashed })), series.SeriesText);
            series.InsertAfter(new Marker(new Symbol() { Val = symbol }, new Size() { Val = size }, new ChartShapeProperties(new d::SolidFill(new d::RgbColorModelHex() { Val = new HexBinaryValue(markerColor) }), markerOutLine)), properties);
            return series;
        }

        public static LineChartSeries CreateLineChartSeries(this LineChart lineChart, string text, UInt32Value index, string color, MarkerStyleValues symbol, d::PresetLineDashValues dashed = d::PresetLineDashValues.Solid, byte size = 7, d::Outline markerOutLine = null)
        {
            return lineChart.CreateLineChartSeries(text, index, color, color, symbol, dashed, size);
        }
    }
}
