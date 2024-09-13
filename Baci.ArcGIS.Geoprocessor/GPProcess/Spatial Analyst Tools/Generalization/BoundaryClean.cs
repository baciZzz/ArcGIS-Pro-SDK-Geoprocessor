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
	/// <para>Boundary Clean</para>
	/// <para>边界清理</para>
	/// <para>平滑栅格中区域之间的边界。</para>
	/// </summary>
	public class BoundaryClean : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>将平滑区域之间边界的输入栅格。</para>
		/// <para>必须为整型。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出概化的栅格。</para>
		/// <para>将对输入中的区域间边界进行平滑处理。</para>
		/// <para>输出始终为整型。</para>
		/// </param>
		public BoundaryClean(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 边界清理</para>
		/// </summary>
		public override string DisplayName() => "边界清理";

		/// <summary>
		/// <para>Tool Name : BoundaryClean</para>
		/// </summary>
		public override string ToolName() => "BoundaryClean";

		/// <summary>
		/// <para>Tool Excute Name : sa.BoundaryClean</para>
		/// </summary>
		public override string ExcuteName() => "sa.BoundaryClean";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, SortType!, NumberOfRuns! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>将平滑区域之间边界的输入栅格。</para>
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
		/// <para>输出概化的栅格。</para>
		/// <para>将对输入中的区域间边界进行平滑处理。</para>
		/// <para>输出始终为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Sort type</para>
		/// <para>指定要在平滑处理中使用的排序类型。将由排序确定像元可扩展到相邻像元的优先级。</para>
		/// <para>排序可以基于区域值或区域大小。</para>
		/// <para>不排序—优先级将由区域值确定。不考虑区域的大小。值较大的区域优先级较高，可以扩展到平滑输出中值较小的区域中。这是默认设置。</para>
		/// <para>降序—区域按大小降序排列。总面积较大的区域具有较高的优先级，可以扩展到总面积较小的若干区域。此选项倾向于消除或减少平滑输出中较小区域的像元分布。</para>
		/// <para>升序—区域按大小升序排列。总面积较小的区域具有较高的优先级，可以扩展到总面积较大的若干区域。此选项倾向于保留或增加平滑输出中较小区域的像元分步。</para>
		/// <para><see cref="SortTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SortType { get; set; } = "NO_SORT";

		/// <summary>
		/// <para>Run expansion and shrinking twice</para>
		/// <para>指定平滑过程的执行次数：两次或一次。</para>
		/// <para>选中 - 扩展与收缩操作执行两次。第一次，将根据指定的排序类型执行操作。第二次，按照相反的优先级额外执行一次收缩和扩展操作。这是默认设置。</para>
		/// <para>未选中 - 将根据排序类型执行一次扩展和收缩操作。</para>
		/// <para><see cref="NumberOfRunsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? NumberOfRuns { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BoundaryClean SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Sort type</para>
		/// </summary>
		public enum SortTypeEnum 
		{
			/// <summary>
			/// <para>不排序—优先级将由区域值确定。不考虑区域的大小。值较大的区域优先级较高，可以扩展到平滑输出中值较小的区域中。这是默认设置。</para>
			/// </summary>
			[GPValue("NO_SORT")]
			[Description("不排序")]
			Do_not_sort,

			/// <summary>
			/// <para>降序—区域按大小降序排列。总面积较大的区域具有较高的优先级，可以扩展到总面积较小的若干区域。此选项倾向于消除或减少平滑输出中较小区域的像元分布。</para>
			/// </summary>
			[GPValue("DESCEND")]
			[Description("降序")]
			Descending,

			/// <summary>
			/// <para>升序—区域按大小升序排列。总面积较小的区域具有较高的优先级，可以扩展到总面积较大的若干区域。此选项倾向于保留或增加平滑输出中较小区域的像元分步。</para>
			/// </summary>
			[GPValue("ASCEND")]
			[Description("升序")]
			Ascending,

		}

		/// <summary>
		/// <para>Run expansion and shrinking twice</para>
		/// </summary>
		public enum NumberOfRunsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("TWO_WAY")]
			TWO_WAY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ONE_WAY")]
			ONE_WAY,

		}

#endregion
	}
}
