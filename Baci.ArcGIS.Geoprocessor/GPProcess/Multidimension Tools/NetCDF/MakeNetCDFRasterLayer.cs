using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MultidimensionTools
{
	/// <summary>
	/// <para>Make NetCDF Raster Layer</para>
	/// <para>创建 NetCDF 栅格图层</para>
	/// <para>根据 NetCDF 文件创建栅格图层。</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.MultidimensionTools.MakeMultidimensionalRasterLayer"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.MultidimensionTools.MakeMultidimensionalRasterLayer))]
	public class MakeNetCDFRasterLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetcdfFile">
		/// <para>Input netCDF File</para>
		/// <para>输入的 NetCDF 文件。</para>
		/// </param>
		/// <param name="Variable">
		/// <para>Variable</para>
		/// <para>向输出栅格分配单元值时使用的 netCDF 文件的变量。 这是将会显示出来的变量，如温度或降雨量。</para>
		/// </param>
		/// <param name="XDimension">
		/// <para>X Dimension</para>
		/// <para>定义输出图层的 x 坐标或经度坐标时使用的 netCDF 维度。</para>
		/// </param>
		/// <param name="YDimension">
		/// <para>Y Dimension</para>
		/// <para>定义输出图层的 y 坐标或纬度坐标时使用的 netCDF 维度。</para>
		/// </param>
		/// <param name="OutRasterLayer">
		/// <para>Output Raster Layer</para>
		/// <para>输出栅格图层的名称。</para>
		/// </param>
		public MakeNetCDFRasterLayer(object InNetcdfFile, object Variable, object XDimension, object YDimension, object OutRasterLayer)
		{
			this.InNetcdfFile = InNetcdfFile;
			this.Variable = Variable;
			this.XDimension = XDimension;
			this.YDimension = YDimension;
			this.OutRasterLayer = OutRasterLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 NetCDF 栅格图层</para>
		/// </summary>
		public override string DisplayName() => "创建 NetCDF 栅格图层";

		/// <summary>
		/// <para>Tool Name : MakeNetCDFRasterLayer</para>
		/// </summary>
		public override string ToolName() => "MakeNetCDFRasterLayer";

		/// <summary>
		/// <para>Tool Excute Name : md.MakeNetCDFRasterLayer</para>
		/// </summary>
		public override string ExcuteName() => "md.MakeNetCDFRasterLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Multidimension Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Multidimension Tools";

		/// <summary>
		/// <para>Toolbox Alise : md</para>
		/// </summary>
		public override string ToolboxAlise() => "md";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InNetcdfFile, Variable, XDimension, YDimension, OutRasterLayer, BandDimension, DimensionValues, ValueSelectionMethod, CellRegistration };

		/// <summary>
		/// <para>Input netCDF File</para>
		/// <para>输入的 NetCDF 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc", "nc4")]
		public object InNetcdfFile { get; set; }

		/// <summary>
		/// <para>Variable</para>
		/// <para>向输出栅格分配单元值时使用的 netCDF 文件的变量。 这是将会显示出来的变量，如温度或降雨量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Variable { get; set; }

		/// <summary>
		/// <para>X Dimension</para>
		/// <para>定义输出图层的 x 坐标或经度坐标时使用的 netCDF 维度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object XDimension { get; set; }

		/// <summary>
		/// <para>Y Dimension</para>
		/// <para>定义输出图层的 y 坐标或纬度坐标时使用的 netCDF 维度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object YDimension { get; set; }

		/// <summary>
		/// <para>Output Raster Layer</para>
		/// <para>输出栅格图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object OutRasterLayer { get; set; }

		/// <summary>
		/// <para>Band Dimension</para>
		/// <para>在输出栅格中创建波段时所使用的 netCDF 维度。 如果需要多波段栅格图层，则请设置此维度值。 例如，可将高度设置为波段维度，从而使创建的多波段栅格中的每个波段都表示该高度上的温度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object BandDimension { get; set; }

		/// <summary>
		/// <para>Dimension Values</para>
		/// <para>在输出图层中显示变量时要使用的维度（如时间）的值（如 01/30/05）。 默认情况下，将使用维度的第一个值。</para>
		/// <para>维度 - netCDF 维度。</para>
		/// <para>值 - 可用的维度值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object DimensionValues { get; set; }

		/// <summary>
		/// <para>Value Selection Method</para>
		/// <para>指定将使用的维度值选择方法。</para>
		/// <para>按值—输入值与实际维度值匹配。</para>
		/// <para>按索引—输入值与维度值的位置或索引匹配。 索引的第一个值为 0；即位置从 0 开始。</para>
		/// <para><see cref="ValueSelectionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ValueSelectionMethod { get; set; } = "BY_VALUE";

		/// <summary>
		/// <para>Cell Registration</para>
		/// <para>指定像元配准的位置。</para>
		/// <para>居中—在像元中心进行像元配准。 这是默认设置。</para>
		/// <para>左下角—在像元左下角进行像元配准。</para>
		/// <para>左上角—在像元左上角进行像元配准。</para>
		/// <para><see cref="CellRegistrationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CellRegistration { get; set; } = "CENTER";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeNetCDFRasterLayer SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Value Selection Method</para>
		/// </summary>
		public enum ValueSelectionMethodEnum 
		{
			/// <summary>
			/// <para>按索引—输入值与维度值的位置或索引匹配。 索引的第一个值为 0；即位置从 0 开始。</para>
			/// </summary>
			[GPValue("BY_INDEX")]
			[Description("按索引")]
			By_index,

			/// <summary>
			/// <para>按值—输入值与实际维度值匹配。</para>
			/// </summary>
			[GPValue("BY_VALUE")]
			[Description("按值")]
			By_value,

		}

		/// <summary>
		/// <para>Cell Registration</para>
		/// </summary>
		public enum CellRegistrationEnum 
		{
			/// <summary>
			/// <para>居中—在像元中心进行像元配准。 这是默认设置。</para>
			/// </summary>
			[GPValue("CENTER")]
			[Description("居中")]
			Center,

			/// <summary>
			/// <para>左下角—在像元左下角进行像元配准。</para>
			/// </summary>
			[GPValue("LOWER_LEFT")]
			[Description("左下角")]
			Lower_Left,

			/// <summary>
			/// <para>左上角—在像元左上角进行像元配准。</para>
			/// </summary>
			[GPValue("UPPER_LEFT")]
			[Description("左上角")]
			Upper_Left,

		}

#endregion
	}
}
