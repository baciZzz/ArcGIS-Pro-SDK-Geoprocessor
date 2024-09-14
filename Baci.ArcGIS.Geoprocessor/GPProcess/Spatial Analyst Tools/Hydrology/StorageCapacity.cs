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
	/// <para>Storage Capacity</para>
	/// <para>存储容量</para>
	/// <para>将为输入表面栅格创建表格和高程图以及相应的存储容量。该工具将计算一系列高程增量处基础区域的表面面积和总体积。</para>
	/// </summary>
	public class StorageCapacity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurfaceRaster">
		/// <para>Input surface raster</para>
		/// <para>输入栅格表示连续的表面。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output table</para>
		/// <para>此输出表包含每个区域中每个高程增量的表面积和总体积。</para>
		/// </param>
		public StorageCapacity(object InSurfaceRaster, object OutTable)
		{
			this.InSurfaceRaster = InSurfaceRaster;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 存储容量</para>
		/// </summary>
		public override string DisplayName() => "存储容量";

		/// <summary>
		/// <para>Tool Name : StorageCapacity</para>
		/// </summary>
		public override string ToolName() => "StorageCapacity";

		/// <summary>
		/// <para>Tool Excute Name : sa.StorageCapacity</para>
		/// </summary>
		public override string ExcuteName() => "sa.StorageCapacity";

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
		public override object[] Parameters() => new object[] { InSurfaceRaster, OutTable, InZoneData, ZoneField, AnalysisType, MinElevation, MaxElevation, IncrementType, Increment, ZUnit, OutChart };

		/// <summary>
		/// <para>Input surface raster</para>
		/// <para>输入栅格表示连续的表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Output table</para>
		/// <para>此输出表包含每个区域中每个高程增量的表面积和总体积。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Input raster or feature zone data</para>
		/// <para>定义区域的数据集。</para>
		/// <para>可通过整型栅格或要素图层来定义区域。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object InZoneData { get; set; }

		/// <summary>
		/// <para>Zone field</para>
		/// <para>包含定义每个区域的值的字段。</para>
		/// <para>该字段可以是区域数据集的整型字段或字符串型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object ZoneField { get; set; }

		/// <summary>
		/// <para>Analysis type</para>
		/// <para>指定分析类型。</para>
		/// <para>面积和体积—将计算每个高程增量的表面积和总体积。这是默认设置。</para>
		/// <para>面积—将计算每个高程增量的表面积。</para>
		/// <para>体积—将计算每个高程增量的总体积。</para>
		/// <para><see cref="AnalysisTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AnalysisType { get; set; } = "AREA_VOLUME";

		/// <summary>
		/// <para>Minimum elevation</para>
		/// <para>评估存储容量基于的最小高程。</para>
		/// <para>默认情况下，该工具将每个区域中的最小表面栅格值用作该区域的最小高程。如果提供了一个值，将使用该值作为所有区域的最小高程。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MinElevation { get; set; }

		/// <summary>
		/// <para>Maximum elevation</para>
		/// <para>评估存储容量基于的最大高程。</para>
		/// <para>默认情况下，该工具将每个区域中的最大表面栅格值用作该区域的最大高程。如果提供了一个值，将使用该值作为所有区域的最大高程。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MaxElevation { get; set; }

		/// <summary>
		/// <para>Increment type</para>
		/// <para>指定计算最小和最大高程之间的高程增量时要使用的增量类型。</para>
		/// <para>增量数—将使用最小和最大高程之间的增量数。这是默认设置。</para>
		/// <para>增量值—将使用每个增量之间的高程差。</para>
		/// <para><see cref="IncrementTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object IncrementType { get; set; } = "NUMBER_OF_INCREMENTS";

		/// <summary>
		/// <para>Increment</para>
		/// <para>一个增量值，可以是增量数或增量之间的高程差。该值根据增量类型参数值进行确定。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Increment { get; set; }

		/// <summary>
		/// <para>Z unit</para>
		/// <para>垂直 z 值的线性单位。</para>
		/// <para>英寸—线性单位将为英寸。</para>
		/// <para>英尺—线性单位将为英尺。</para>
		/// <para>码—线性单位将为码。</para>
		/// <para>英里(美制)—线性单位将为英里。</para>
		/// <para>海里—线性单位将为海里。</para>
		/// <para>毫米—线性单位将为毫米。</para>
		/// <para>厘米—线性单位将为厘米。</para>
		/// <para>米—线性单位将为米。</para>
		/// <para>千米—线性单位将为公里。</para>
		/// <para>分米—线性单位将为分米。</para>
		/// <para><see cref="ZUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ZUnit { get; set; }

		/// <summary>
		/// <para>Output chart name</para>
		/// <para>用于显示的输出图表的名称。</para>
		/// <para>该图表将在内容窗格中的独立表下列出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object OutChart { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public StorageCapacity SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Analysis type</para>
		/// </summary>
		public enum AnalysisTypeEnum 
		{
			/// <summary>
			/// <para>面积和体积—将计算每个高程增量的表面积和总体积。这是默认设置。</para>
			/// </summary>
			[GPValue("AREA_VOLUME")]
			[Description("面积和体积")]
			Area_and_Volume,

			/// <summary>
			/// <para>面积和体积—将计算每个高程增量的表面积和总体积。这是默认设置。</para>
			/// </summary>
			[GPValue("AREA")]
			[Description("面积")]
			Area,

			/// <summary>
			/// <para>体积—将计算每个高程增量的总体积。</para>
			/// </summary>
			[GPValue("VOLUME")]
			[Description("体积")]
			Volume,

		}

		/// <summary>
		/// <para>Increment type</para>
		/// </summary>
		public enum IncrementTypeEnum 
		{
			/// <summary>
			/// <para>增量数—将使用最小和最大高程之间的增量数。这是默认设置。</para>
			/// </summary>
			[GPValue("NUMBER_OF_INCREMENTS")]
			[Description("增量数")]
			Number_of_Increments,

			/// <summary>
			/// <para>增量值—将使用每个增量之间的高程差。</para>
			/// </summary>
			[GPValue("VALUE_OF_INCREMENT")]
			[Description("增量值")]
			Value_of_Increment,

		}

		/// <summary>
		/// <para>Z unit</para>
		/// </summary>
		public enum ZUnitEnum 
		{
			/// <summary>
			/// <para>米—线性单位将为米。</para>
			/// </summary>
			[GPValue("METER")]
			[Description("米")]
			Meter,

			/// <summary>
			/// <para>英寸—线性单位将为英寸。</para>
			/// </summary>
			[GPValue("INCH")]
			[Description("英寸")]
			Inch,

			/// <summary>
			/// <para>英尺—线性单位将为英尺。</para>
			/// </summary>
			[GPValue("FOOT")]
			[Description("英尺")]
			Foot,

			/// <summary>
			/// <para>码—线性单位将为码。</para>
			/// </summary>
			[GPValue("YARD")]
			[Description("码")]
			Yard,

			/// <summary>
			/// <para>英里(美制)—线性单位将为英里。</para>
			/// </summary>
			[GPValue("MILE_US")]
			[Description("英里(美制)")]
			Mile_US,

			/// <summary>
			/// <para>海里—线性单位将为海里。</para>
			/// </summary>
			[GPValue("NAUTICAL_MILE")]
			[Description("海里")]
			Nautical_mile,

			/// <summary>
			/// <para>毫米—线性单位将为毫米。</para>
			/// </summary>
			[GPValue("MILLIMETER")]
			[Description("毫米")]
			Millimeter,

			/// <summary>
			/// <para>厘米—线性单位将为厘米。</para>
			/// </summary>
			[GPValue("CENTIMETER")]
			[Description("厘米")]
			Centimeter,

			/// <summary>
			/// <para>千米—线性单位将为公里。</para>
			/// </summary>
			[GPValue("KILOMETER")]
			[Description("千米")]
			Kilometer,

			/// <summary>
			/// <para>分米—线性单位将为分米。</para>
			/// </summary>
			[GPValue("DECIMETER")]
			[Description("分米")]
			Decimeter,

		}

#endregion
	}
}
