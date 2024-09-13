using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Create Color Composite</para>
	/// <para>创建彩色合成</para>
	/// <para>从多波段栅格数据集创建三波段栅格数据集。</para>
	/// </summary>
	public class CreateColorComposite : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>输入多波段栅格数据。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>输出三波段合成栅格。</para>
		/// </param>
		/// <param name="Method">
		/// <para>Method</para>
		/// <para>指定将用于提取波段的方法。</para>
		/// <para>波段名称—将使用表示电磁光谱（如红色、近红外或热红外）或偏振（如 VH、VV、HH 或 HV）上波长间隔的波段名称。 这是默认设置。</para>
		/// <para>波段 ID—将使用波段号（例如 B1、B2 或 B3）。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </param>
		/// <param name="RedExpression">
		/// <para>Red Expression</para>
		/// <para>分配给第一个波段的计算。</para>
		/// <para>波段名称、波段 ID 或使用波段的代数表达式。</para>
		/// <para>受支持的运算符为一元运算符：加号 (+)、减号 (-)、乘号 (*) 和除号 (/)。</para>
		/// </param>
		/// <param name="GreenExpression">
		/// <para>Green Expression</para>
		/// <para>分配给第二个波段的计算。</para>
		/// <para>波段名称、波段 ID 或使用波段的代数表达式。</para>
		/// <para>受支持的运算符为一元运算符：加号 (+)、减号 (-)、乘号 (*) 和除号 (/)。</para>
		/// </param>
		/// <param name="BlueExpression">
		/// <para>Blue Expression</para>
		/// <para>分配给第三个波段的计算。</para>
		/// <para>波段名称、波段 ID 或使用波段的代数表达式。</para>
		/// <para>受支持的运算符为一元运算符：加号 (+)、减号 (-)、乘号 (*) 和除号 (/)。</para>
		/// </param>
		public CreateColorComposite(object InRaster, object OutRaster, object Method, object RedExpression, object GreenExpression, object BlueExpression)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
			this.Method = Method;
			this.RedExpression = RedExpression;
			this.GreenExpression = GreenExpression;
			this.BlueExpression = BlueExpression;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建彩色合成</para>
		/// </summary>
		public override string DisplayName() => "创建彩色合成";

		/// <summary>
		/// <para>Tool Name : CreateColorComposite</para>
		/// </summary>
		public override string ToolName() => "CreateColorComposite";

		/// <summary>
		/// <para>Tool Excute Name : ia.CreateColorComposite</para>
		/// </summary>
		public override string ExcuteName() => "ia.CreateColorComposite";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellAlignment", "cellSize", "compression", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, Method, RedExpression, GreenExpression, BlueExpression };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>输入多波段栅格数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>输出三波段合成栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>指定将用于提取波段的方法。</para>
		/// <para>波段名称—将使用表示电磁光谱（如红色、近红外或热红外）或偏振（如 VH、VV、HH 或 HV）上波长间隔的波段名称。 这是默认设置。</para>
		/// <para>波段 ID—将使用波段号（例如 B1、B2 或 B3）。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "BAND_IDS";

		/// <summary>
		/// <para>Red Expression</para>
		/// <para>分配给第一个波段的计算。</para>
		/// <para>波段名称、波段 ID 或使用波段的代数表达式。</para>
		/// <para>受支持的运算符为一元运算符：加号 (+)、减号 (-)、乘号 (*) 和除号 (/)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object RedExpression { get; set; }

		/// <summary>
		/// <para>Green Expression</para>
		/// <para>分配给第二个波段的计算。</para>
		/// <para>波段名称、波段 ID 或使用波段的代数表达式。</para>
		/// <para>受支持的运算符为一元运算符：加号 (+)、减号 (-)、乘号 (*) 和除号 (/)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object GreenExpression { get; set; }

		/// <summary>
		/// <para>Blue Expression</para>
		/// <para>分配给第三个波段的计算。</para>
		/// <para>波段名称、波段 ID 或使用波段的代数表达式。</para>
		/// <para>受支持的运算符为一元运算符：加号 (+)、减号 (-)、乘号 (*) 和除号 (/)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object BlueExpression { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateColorComposite SetEnviroment(object? cellAlignment = null , object? cellSize = null , object? compression = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(cellAlignment: cellAlignment, cellSize: cellSize, compression: compression, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>波段名称—将使用表示电磁光谱（如红色、近红外或热红外）或偏振（如 VH、VV、HH 或 HV）上波长间隔的波段名称。 这是默认设置。</para>
			/// </summary>
			[GPValue("BAND_NAMES")]
			[Description("波段名称")]
			Band_names,

			/// <summary>
			/// <para>波段 ID—将使用波段号（例如 B1、B2 或 B3）。</para>
			/// </summary>
			[GPValue("BAND_IDS")]
			[Description("波段 ID")]
			Band_IDs,

		}

#endregion
	}
}
