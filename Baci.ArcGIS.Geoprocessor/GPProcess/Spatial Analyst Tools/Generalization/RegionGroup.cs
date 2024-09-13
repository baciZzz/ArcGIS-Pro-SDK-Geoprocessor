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
	/// <para>Region Group</para>
	/// <para>区域分组</para>
	/// <para>记录输出中每个像元所属的连接区域的标识。系统将会为每个区域分配唯一编号。</para>
	/// </summary>
	public class RegionGroup : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>将标识唯一连接像元区域的输入栅格。</para>
		/// <para>必须为整型。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出区域分组栅格。</para>
		/// <para>输出始终为整型。</para>
		/// </param>
		public RegionGroup(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 区域分组</para>
		/// </summary>
		public override string DisplayName() => "区域分组";

		/// <summary>
		/// <para>Tool Name : RegionGroup</para>
		/// </summary>
		public override string ToolName() => "RegionGroup";

		/// <summary>
		/// <para>Tool Excute Name : sa.RegionGroup</para>
		/// </summary>
		public override string ExcuteName() => "sa.RegionGroup";

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
		public override object[] Parameters() => new object[] { InRaster, OutRaster, NumberNeighbors!, ZoneConnectivity!, AddLink!, ExcludedValue! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>将标识唯一连接像元区域的输入栅格。</para>
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
		/// <para>输出区域分组栅格。</para>
		/// <para>输出始终为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Number of neighbors to use</para>
		/// <para>指定评估定义区域的像元间的连通性时使用的相邻像元数。</para>
		/// <para>四—评估每个输入像元中四个最近（正交）相邻像元的连通性。只有具有相同值且至少共享一侧的像元才会组成单个区域。如果两个具有相同值的像元彼此只是对角线连接，则其不会被视为相连接。这是默认设置。</para>
		/// <para>八—评估每个输入像元中八个最近相邻像元（正交和对角线）的连通性。沿公共边或角相互连接的具有相同值的像元将构成单个区域。</para>
		/// <para><see cref="NumberNeighborsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? NumberNeighbors { get; set; } = "FOUR";

		/// <summary>
		/// <para>Zone grouping method</para>
		/// <para>定义在进行连通性测试时应考虑的像元值。</para>
		/// <para>位于—将针对部分同一区域（像元值）的输入像元评估区域的连通性。只能对满足空间连通性要求（由四向或八向要使用的相邻数参数指定）的同一区域中的像元进行分组。这是默认设置。</para>
		/// <para>交叉—评估任何值的像元间区域的连通性（不包括由排除值参数排除的区域像元），并遵守由要使用的相邻数参数指定的空间要求。输入中通过 NoData 像元的缓冲区独立于其他分组的区域分组将彼此独立地进行处理。</para>
		/// <para><see cref="ZoneConnectivityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ZoneConnectivity { get; set; } = "WITHIN";

		/// <summary>
		/// <para>Add link field to output</para>
		/// <para>指定将区域分组方法参数设置为 Within 时是否向输出表添加链接字段。如果将该参数设置为 Cross，则将忽略此参数。</para>
		/// <para>选中 - 将 LINK 字段添加到输出栅格的表中。根据要使用的相邻数参数中定义的连通性规则，该字段将存储输出中每个区域的像元所属区域的值。这是默认设置。</para>
		/// <para>未选中 - 将不添加 LINK 字段。输出栅格的属性表仅包含 Value 和 Count 字段。</para>
		/// <para><see cref="AddLinkEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AddLink { get; set; } = "true";

		/// <summary>
		/// <para>Excluded value</para>
		/// <para>从连通性评估中排除该区域所有像元的值。如果像元位置包含该值，则不管将邻近像元数指定为多少，都不会评估空间连通性。</para>
		/// <para>具有排除值的像元与 NoData 像元将以相似的方式进行处理，且在运算中不在考量范围内。在输出栅格上，包含排除的值的输入像元将接收 0。排除的值类似于背景值的概念。</para>
		/// <para>默认情况下，此参数未定义任何值，这表示在运算中将考虑所有输入像元。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? ExcludedValue { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RegionGroup SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Number of neighbors to use</para>
		/// </summary>
		public enum NumberNeighborsEnum 
		{
			/// <summary>
			/// <para>四—评估每个输入像元中四个最近（正交）相邻像元的连通性。只有具有相同值且至少共享一侧的像元才会组成单个区域。如果两个具有相同值的像元彼此只是对角线连接，则其不会被视为相连接。这是默认设置。</para>
			/// </summary>
			[GPValue("FOUR")]
			[Description("四")]
			Four,

			/// <summary>
			/// <para>八—评估每个输入像元中八个最近相邻像元（正交和对角线）的连通性。沿公共边或角相互连接的具有相同值的像元将构成单个区域。</para>
			/// </summary>
			[GPValue("EIGHT")]
			[Description("八")]
			Eight,

		}

		/// <summary>
		/// <para>Zone grouping method</para>
		/// </summary>
		public enum ZoneConnectivityEnum 
		{
			/// <summary>
			/// <para>位于—将针对部分同一区域（像元值）的输入像元评估区域的连通性。只能对满足空间连通性要求（由四向或八向要使用的相邻数参数指定）的同一区域中的像元进行分组。这是默认设置。</para>
			/// </summary>
			[GPValue("WITHIN")]
			[Description("位于")]
			Within,

			/// <summary>
			/// <para>交叉—评估任何值的像元间区域的连通性（不包括由排除值参数排除的区域像元），并遵守由要使用的相邻数参数指定的空间要求。输入中通过 NoData 像元的缓冲区独立于其他分组的区域分组将彼此独立地进行处理。</para>
			/// </summary>
			[GPValue("CROSS")]
			[Description("交叉")]
			Cross,

		}

		/// <summary>
		/// <para>Add link field to output</para>
		/// </summary>
		public enum AddLinkEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_LINK")]
			ADD_LINK,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_LINK")]
			NO_LINK,

		}

#endregion
	}
}
