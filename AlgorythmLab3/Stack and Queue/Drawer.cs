using ScottPlot;
using ScottPlot.DataSources;
using ScottPlot.Plottables;
using System.Reflection;
using System.Reflection.Emit;
namespace AlgorythmLab3.Stack_and_Queue
{
    public class Drawer
    {
        public static void Draw(string plotName, string pathPNG, List<Data> data, string XLabel)
        {
            Plot plot = new();
            plot.Title(plotName);

            foreach (Data e in data)
            {
                plot.XLabel(XLabel);
                plot.YLabel("время, тики");

                Scatter scatter = plot.Add.Scatter(e.XValues, e.YValues, GetRandomColor());
                scatter.Label = e.Name;
                plot.Legend();
            }

            plot.SavePng($"{pathPNG}\\{plotName}Measures.png", 1000, 1000);
        }

        private static Color GetRandomColor()
        {
            Random rnd = new();
            return new Color(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
        }
    }
}
