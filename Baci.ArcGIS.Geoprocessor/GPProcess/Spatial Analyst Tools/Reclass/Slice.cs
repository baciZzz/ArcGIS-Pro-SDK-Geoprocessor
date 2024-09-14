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
	/// <para>Slice</para>
	/// <para>分割</para>
	/// <para>按照相等间隔区域，或者相等面积或自然间断点分级法分割或重分类输入像元值的范围。</para>
	/// </summary>
	public class Slice : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>要进行重分类的输入栅格。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出重分类栅格。</para>
		/// <para>输出将始终为整型。</para>
		/// </param>
		/// <param name="NumberZones">
		/// <para>Number of output zones</para>
		/// <para>将输入栅格重分类的区域数量。</para>
		/// <para>分割方法为等积时，输出栅格需要定义区域数量，并且每个区域中的像元数应相同。</para>
		/// <para>使用相等间隔时，输出栅格需要定义区域数量，每个区域在输出栅格中生成的值范围应相同。</para>
		/// <para>使用自然间断点时，输出栅格需要定义区域数量，每个区域中的像元数将由分类间隔决定。</para>
		/// </param>
		public Slice(object InRaster, object OutRaster, object NumberZones)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
			this.NumberZones = NumberZones;
		}

		/// <summary>
		/// <para>Tool Display Name : 分割</para>
		/// </summary>
		public override string DisplayName() => "分割";

		/// <summary>
		/// <para>Tool Name : 分割</para>
		/// </summary>
		public override string ToolName() => "分割";

		/// <summary>
		/// <para>Tool Excute Name : sa.Slice</para>
		/// </summary>
		public override string ExcuteName() => "sa.Slice";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, NumberZones, SliceType, BaseOutputZone };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>要进行重分类的输入栅格。</para>
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
		/// <para>输出重分类栅格。</para>
		/// <para>输出将始终为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Number of output zones</para>
		/// <para>将输入栅格重分类的区域数量。</para>
		/// <para>分割方法为等积时，输出栅格需要定义区域数量，并且每个区域中的像元数应相同。</para>
		/// <para>使用相等间隔时，输出栅格需要定义区域数量，每个区域在输出栅格中生成的值范围应相同。</para>
		/// <para>使用自然间断点时，输出栅格需要定义区域数量，每个区域中的像元数将由分类间隔决定。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPNumericDomain()]
		public object NumberZones { get; set; }

		/// <summary>
		/// <para>Slice method</para>
		/// <para>输入栅格中值的分割方式。</para>
		/// <para>相等间隔—确定输入值的范围然后将该范围分割为指定数量的输出区域。分割后输出栅格中每个区域的输入像元值都可能与极值范围相同。这是默认设置。</para>
		/// <para>相等面积—指定输入值将被划分为指定数量的输出区域，且每个区域的像元数相同。每个区域所代表的面积大小相等。</para>
		/// <para>自然间断点—指定各类将基于数据中固有的自然分组。中断点将通过选择分类间隔识别，这些分类间隔可对相似值进行最恰当地分组并使各类之间的差异最大化。像元值将被划分到各个类，如果数据值中出现相对较大的跳跃性，可为这些类设置界限。</para>
		/// <para><see cref="SliceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SliceType { get; set; } = "EQUAL_INTERVAL";

		/// <summary>
		/// <para>Base zone for output</para>
		/// <para>定义输出栅格数据集中最低区域的值。</para>
		/// <para>默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object BaseOutputZone { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Slice SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Slice method</para>
		/// </summary>
		public enum SliceTypeEnum 
		{
			/// <summary>
			/// <para>相等间隔—确定输入值的范围然后将该范围分割为指定数量的输出区域。分割后输出栅格中每个区域的输入像元值都可能与极值范围相同。这是默认设置。</para>
			/// </summary>
			[GPValue("EQUAL_INTERVAL")]
			[Description("相等间隔")]
			Equal_interval,

			/// <summary>
			/// <para>相等面积—指定输入值将被划分为指定数量的输出区域，且每个区域的像元数相同。每个区域所代表的面积大小相等。</para>
			/// </summary>
			[GPValue("EQUAL_AREA")]
			[Description("相等面积")]
			Equal_area,

			/// <summary>
			/// <para>自然间断点—指定各类将基于数据中固有的自然分组。中断点将通过选择分类间隔识别，这些分类间隔可对相似值进行最恰当地分组并使各类之间的差异最大化。像元值将被划分到各个类，如果数据值中出现相对较大的跳跃性，可为这些类设置界限。</para>
			/// </summary>
			[GPValue("NATURAL_BREAKS")]
			[Description("自然间断点")]
			Natural_breaks,

		}

#endregion
	}
}
