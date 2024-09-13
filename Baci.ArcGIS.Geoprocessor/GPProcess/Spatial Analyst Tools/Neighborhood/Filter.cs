using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Filter</para>
	/// <para>滤波器</para>
	/// <para>对栅格执行平滑（低通）滤波器或边缘增强（高通）滤波器。</para>
	/// </summary>
	public class Filter : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>要执行滤波运算的输入栅格。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>过滤后的输出栅格。</para>
		/// <para>输出栅格始终为浮点型。</para>
		/// </param>
		public Filter(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 滤波器</para>
		/// </summary>
		public override string DisplayName() => "滤波器";

		/// <summary>
		/// <para>Tool Name : 滤波器</para>
		/// </summary>
		public override string ToolName() => "滤波器";

		/// <summary>
		/// <para>Tool Excute Name : sa.Filter</para>
		/// </summary>
		public override string ExcuteName() => "sa.Filter";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, FilterType!, IgnoreNodata! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>要执行滤波运算的输入栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>过滤后的输出栅格。</para>
		/// <para>输出栅格始终为浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Filter type</para>
		/// <para>要执行的滤波运算类型。</para>
		/// <para>低通—在栅格上横跨一个 3 x 3 低通滤波器。 该选项可平滑整个输入栅格，并降低异常像元的显著性。 这是默认设置。</para>
		/// <para>高通—在栅格上横跨一个 3 x 3 高通滤波器。 此选项可增强栅格中弱化要素的边缘。</para>
		/// <para><see cref="FilterTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FilterType { get; set; } = "LOW";

		/// <summary>
		/// <para>Ignore NoData in calculations</para>
		/// <para>指示在进行滤波计算时是否忽略 NoData 值。</para>
		/// <para>选中 - 当滤波器中存在 NoData 值时，忽略此 NoData 值。 将仅使用滤波器中具有数据值的像元来确定输出。 这是默认设置。</para>
		/// <para>未选中 - 当滤波器中存在 NoData 值时，相应待处理像元的输出将为 NoData。 使用此选项时，存在 NoData 值表明确定邻域的统计值所需要的信息不足。</para>
		/// <para><see cref="IgnoreNodataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreNodata { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Filter SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Filter type</para>
		/// </summary>
		public enum FilterTypeEnum 
		{
			/// <summary>
			/// <para>低通—在栅格上横跨一个 3 x 3 低通滤波器。 该选项可平滑整个输入栅格，并降低异常像元的显著性。 这是默认设置。</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("低通")]
			Low_pass,

			/// <summary>
			/// <para>高通—在栅格上横跨一个 3 x 3 高通滤波器。 此选项可增强栅格中弱化要素的边缘。</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("高通")]
			High_pass,

		}

		/// <summary>
		/// <para>Ignore NoData in calculations</para>
		/// </summary>
		public enum IgnoreNodataEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DATA")]
			DATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NODATA")]
			NODATA,

		}

#endregion
	}
}
