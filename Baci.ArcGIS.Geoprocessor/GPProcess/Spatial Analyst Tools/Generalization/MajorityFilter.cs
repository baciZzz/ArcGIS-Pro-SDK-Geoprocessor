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
	/// <para>Majority Filter</para>
	/// <para>众数滤波</para>
	/// <para>根据相邻像元数据值的众数替换栅格中的像元。</para>
	/// </summary>
	public class MajorityFilter : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>要根据相邻像元数据值的众数进行过滤的输入栅格。</para>
		/// <para>必须为整型。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>过滤后的输出栅格。</para>
		/// <para>输出始终为整型。</para>
		/// </param>
		public MajorityFilter(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 众数滤波</para>
		/// </summary>
		public override string DisplayName() => "众数滤波";

		/// <summary>
		/// <para>Tool Name : MajorityFilter</para>
		/// </summary>
		public override string ToolName() => "MajorityFilter";

		/// <summary>
		/// <para>Tool Excute Name : sa.MajorityFilter</para>
		/// </summary>
		public override string ExcuteName() => "sa.MajorityFilter";

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
		public override object[] Parameters() => new object[] { InRaster, OutRaster, NumberNeighbors, MajorityDefinition };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>要根据相邻像元数据值的众数进行过滤的输入栅格。</para>
		/// <para>必须为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>过滤后的输出栅格。</para>
		/// <para>输出始终为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Number of neighbors to use</para>
		/// <para>确定在滤波器内核中使用的相邻像元数。</para>
		/// <para>四— 滤波器内核将是与当前像元直接相邻（正交）的四个像元。这是默认设置。</para>
		/// <para>八— 滤波器内核将是距当前像元最近的 8 个相邻像元（3 × 3 窗口）。</para>
		/// <para><see cref="NumberNeighborsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object NumberNeighbors { get; set; } = "FOUR";

		/// <summary>
		/// <para>Replacement threshold</para>
		/// <para>在进行替换之前指定必须具有相同值的相邻（空间连接）像元数。</para>
		/// <para>众数— 多数像元必须具有相同值并且相邻。四分之三或八分之五的已连接像元必须具有相同值。</para>
		/// <para>半数— 半数像元必须具有相同值并且相邻。四分之二或八分之四的已连接像元必须具有相同值。使用此选项可获得比其他选项更平滑的效果。</para>
		/// <para><see cref="MajorityDefinitionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MajorityDefinition { get; set; } = "MAJORITY";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MajorityFilter SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Number of neighbors to use</para>
		/// </summary>
		public enum NumberNeighborsEnum 
		{
			/// <summary>
			/// <para>四— 滤波器内核将是与当前像元直接相邻（正交）的四个像元。这是默认设置。</para>
			/// </summary>
			[GPValue("FOUR")]
			[Description("四")]
			Four,

			/// <summary>
			/// <para>八— 滤波器内核将是距当前像元最近的 8 个相邻像元（3 × 3 窗口）。</para>
			/// </summary>
			[GPValue("EIGHT")]
			[Description("八")]
			Eight,

		}

		/// <summary>
		/// <para>Replacement threshold</para>
		/// </summary>
		public enum MajorityDefinitionEnum 
		{
			/// <summary>
			/// <para>众数— 多数像元必须具有相同值并且相邻。四分之三或八分之五的已连接像元必须具有相同值。</para>
			/// </summary>
			[GPValue("MAJORITY")]
			[Description("众数")]
			Majority,

			/// <summary>
			/// <para>半数— 半数像元必须具有相同值并且相邻。四分之二或八分之四的已连接像元必须具有相同值。使用此选项可获得比其他选项更平滑的效果。</para>
			/// </summary>
			[GPValue("HALF")]
			[Description("半数")]
			Half,

		}

#endregion
	}
}
