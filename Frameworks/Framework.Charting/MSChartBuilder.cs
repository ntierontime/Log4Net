using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization.Charting;

namespace Framework.Charting
{
    /// <summary>
    /// Developer should implement CreatePoint(T item) method in concrete class with code snippet:
    /// 
    /// </summary>
    public abstract class MSChartBuilder<TCollection, T>
        where TCollection : IList<T>, new()
    {
        #region properties
        
        public Framework.Charting.MSChartConfiguration ChartConfiguration { get; set; }

        #endregion properties

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MSChartBuilder{TCollection, T}"/> class.
        /// </summary>
        public MSChartBuilder()
        {
        }

		/// <summary>
        /// Initializes a new instance of the <see cref="MSChartBuilder{TCollection, T}"/> class.
        /// </summary>
        public MSChartBuilder(MSChartConfiguration msChartConfiguration)
        {
            this.ChartConfiguration = msChartConfiguration;
        }

        #endregion constructors

        #region Build(IList<TCollection> input)

        public virtual Chart Build(IList<TCollection> input)
        {
            #region 1. Basic Chart info

            Chart chart = CreateChart();

            #endregion 1. Basic Chart info

            #region 2. Titles

            Title title = CreateChartTitle();
            CustomizeChartTitle(title);
            chart.Titles.Add(title);

            #endregion 2. Titles

            #region 3. Legends

            Legend legend = CreateChartLegend();
            CustomizeChartLegend(legend);
            chart.Legends.Add(legend);

            #endregion 3. Legends

            #region 4. Series

            IList<Series> seriesList = CreateChartSeries(input);
            foreach (var series in seriesList)
            {
                chart.Series.Add(series);
            }

            #endregion 4. Series

            #region 5. Chart Area

            ChartArea chartArea = CreateChartArea();
            CustomizeChartArea(chartArea);

            #endregion 5. Chart Area

            return chart;
        }

        #endregion

        #region BuildAndGetStream(IList<TCollection> input)

        public virtual Stream BuildAndGetStream(IList<TCollection> input)
        {
            Chart chart = Build(input);

            if (chart != null)
            {
                MemoryStream ms = new MemoryStream();
                chart.SaveImage(ms);
                return ms;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region 1. Creates the chart.

        /// <summary>
        /// 1. Creates the chart.
        /// </summary>
        /// <returns>the chart with basic configuration</returns>
        protected virtual Chart CreateChart()
        {
            Chart chart = new Chart();
            chart.Width = 700;
            chart.Height = 300;
            chart.BackColor = Color.FromArgb(211, 223, 240);
            chart.BorderlineDashStyle = ChartDashStyle.Solid;
            chart.BackSecondaryColor = Color.White;
            chart.BackGradientStyle = GradientStyle.TopBottom;
            chart.BorderlineWidth = 1;
            chart.Palette = ChartColorPalette.BrightPastel;
            chart.BorderlineColor = Color.FromArgb(26, 59, 105);
            chart.RenderType = RenderType.BinaryStreaming;
            chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            chart.AntiAliasing = AntiAliasingStyles.All;
            chart.TextAntiAliasingQuality = TextAntiAliasingQuality.Normal;
            return chart;
        }
        
        #endregion

        #region 2. Creates the chart title.

        /// <summary>
        /// 2. Creates the chart title.
        /// </summary>
        /// <returns>the title with basic configuration</returns>
        protected virtual Title CreateChartTitle()
        {
            Title title = new Title
                {
                    Docking = Docking.Top,
                    Font = new Font("Trebuchet MS", 18.0f, FontStyle.Bold),
                };
            title.Text = this.ChartConfiguration.Title;
            return title;
        }

        /// <summary>
        /// 2.1. Customizes the chart title.
        /// </summary>
        /// <param name="title">The title.</param>
        protected virtual void CustomizeChartTitle(Title title)
        {
        }

        #endregion

        #region 3. Creates the chart legend.

        /// <summary>
        /// 3. Creates the chart legend.
        /// </summary>
        /// <returns></returns>
        protected virtual Legend CreateChartLegend()
        {
            Legend legend = new Legend()
            {
                Alignment = StringAlignment.Near,
                Docking = Docking.Right
            };

            return legend;
        }

        /// <summary>
        /// 3.1. Customizes the chart legend.
        /// </summary>
        /// <param name="legend">The legend.</param>
        protected virtual void CustomizeChartLegend(Legend legend)
        {
        }

        #endregion
		
        #region 4. Creates the chart series.

        /// <summary>
        /// 4. Creates the chart series.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        protected virtual IList<Series> CreateChartSeries(IList<TCollection> input)
        {

            List<Series> seriesList = new List<Series>();
            foreach (var itemList in input)
            {
                Series series = new Series();
                series.Name = this.ChartConfiguration.Title;
                series.ChartType = this.ChartConfiguration.ChartType;
                series.BorderWidth = 5;
                series.Palette = ChartColorPalette.None;

                foreach (var item in itemList)
                    series.Points.AddXY(BuildXAxis(item), BuildYAxis(item));

                seriesList.Add(series);
            }

            return seriesList;
        }

        #endregion 4. Creates the chart series.

        #region 4.1. To implement: Build X axis

        /// <summary>
        /// Builds the x Axis.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        protected abstract object BuildXAxis(T item);

        #endregion 4.1. To implement: Build X axis

        #region 4.2. To implement: Build Y axis

        /// <summary>
        /// Builds the y Axis.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        protected abstract double BuildYAxis(T item);

        #endregion 4.2. To implement: Build Y axis

        #region 5. Creates the chart area.

        /// <summary>
        /// 5. Creates the chart area.
        /// </summary>
        /// <returns></returns>
        protected virtual ChartArea CreateChartArea()
        {
            ChartArea area = new ChartArea()
            {
                BackColor = Color.BlanchedAlmond,
                BackSecondaryColor = Color.Black,
                BackGradientStyle = GradientStyle.TopBottom
            };
            area.Area3DStyle.Enable3D = true;
            area.Area3DStyle.LightStyle = LightStyle.Realistic;

            return area;
        }
        
        /// <summary>
        /// 5.1. Customizes the chart area.
        /// </summary>
        /// <param name="chartArea">The chart area.</param>
        protected virtual void CustomizeChartArea(ChartArea chartArea)
        {
        }

        #endregion methods to build a chart
    }
}