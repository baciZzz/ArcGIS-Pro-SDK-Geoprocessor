using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IndoorsTools
{
	/// <summary>
	/// <para>Import Floorplans To Indoors Geodatabase</para>
	/// <para>将楼层平面图导入 Indoors 地理数据库</para>
	/// <para>将楼层平面图从 CAD 文件导入到符合 ArcGIS Indoors 信息模型的 Indoors 工作空间中。 可使用该工具的输出创建楼层感知型地图和场景，以用于楼层感知型应用程序，以及生成用于路由的室内网络。</para>
	/// </summary>
	public class ImportFloorplansToIndoorsGDB : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetUnitFeatures">
		/// <para>Target Unit Features</para>
		/// <para>符合 ArcGIS Indoors 信息模型并与目标设施点、楼层和详细信息要素位于同一工作空间中的目标单元要素图层、要素类或要素服务。</para>
		/// </param>
		/// <param name="TargetDetailFeatures">
		/// <para>Target Detail Features</para>
		/// <para>符合 ArcGIS Indoors 信息模型并与目标设施点、楼层和单元要素位于同一工作空间中的目标详细信息要素图层、要素类或要素服务。</para>
		/// </param>
		/// <param name="TargetLevelFeatures">
		/// <para>Target Level Features</para>
		/// <para>符合 ArcGIS Indoors 信息模型并与目标设施点、单元和详细信息要素位于同一工作空间中的目标楼层要素图层、要素类或要素服务。</para>
		/// </param>
		/// <param name="TargetFacilityFeatures">
		/// <para>Target Facility Features</para>
		/// <para>符合 ArcGIS Indoors 信息模型并与目标楼层、单元和详细信息要素位于同一工作空间中的目标设施点要素图层、要素类或要素服务。</para>
		/// </param>
		/// <param name="InExcelTemplate">
		/// <para>Input Excel Template File</para>
		/// <para>包含输入和配置参数的 Excel 电子表格（.xls 或 .xlsx 文件）。</para>
		/// </param>
		/// <param name="UniqueidDelimiter">
		/// <para>Unique ID Delimiter</para>
		/// <para>指定将按 Indoors 模型等级分隔键值的分隔符。</para>
		/// <para>句点—该 ID 将包含以句点分隔的键值。 这是默认设置。</para>
		/// <para>连字符—该 ID 将包含以连字符分隔的键值。</para>
		/// <para>下划线—该 ID 将包含以下划线分隔的键值。</para>
		/// <para><see cref="UniqueidDelimiterEnum"/></para>
		/// </param>
		public ImportFloorplansToIndoorsGDB(object TargetUnitFeatures, object TargetDetailFeatures, object TargetLevelFeatures, object TargetFacilityFeatures, object InExcelTemplate, object UniqueidDelimiter)
		{
			this.TargetUnitFeatures = TargetUnitFeatures;
			this.TargetDetailFeatures = TargetDetailFeatures;
			this.TargetLevelFeatures = TargetLevelFeatures;
			this.TargetFacilityFeatures = TargetFacilityFeatures;
			this.InExcelTemplate = InExcelTemplate;
			this.UniqueidDelimiter = UniqueidDelimiter;
		}

		/// <summary>
		/// <para>Tool Display Name : 将楼层平面图导入 Indoors 地理数据库</para>
		/// </summary>
		public override string DisplayName() => "将楼层平面图导入 Indoors 地理数据库";

		/// <summary>
		/// <para>Tool Name : ImportFloorplansToIndoorsGDB</para>
		/// </summary>
		public override string ToolName() => "ImportFloorplansToIndoorsGDB";

		/// <summary>
		/// <para>Tool Excute Name : indoors.ImportFloorplansToIndoorsGDB</para>
		/// </summary>
		public override string ExcuteName() => "indoors.ImportFloorplansToIndoorsGDB";

		/// <summary>
		/// <para>Toolbox Display Name : Indoors Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Indoors Tools";

		/// <summary>
		/// <para>Toolbox Alise : indoors</para>
		/// </summary>
		public override string ToolboxAlise() => "indoors";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetUnitFeatures, TargetDetailFeatures, TargetLevelFeatures, TargetFacilityFeatures, InExcelTemplate, UniqueidDelimiter, SliverThreshold!, DoorCloseBuffer!, AreaUnitOfMeasure!, MeasurementMode!, TargetSectionFeatures!, TargetZoneFeatures!, UpdatedUnits! };

		/// <summary>
		/// <para>Target Unit Features</para>
		/// <para>符合 ArcGIS Indoors 信息模型并与目标设施点、楼层和详细信息要素位于同一工作空间中的目标单元要素图层、要素类或要素服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object TargetUnitFeatures { get; set; }

		/// <summary>
		/// <para>Target Detail Features</para>
		/// <para>符合 ArcGIS Indoors 信息模型并与目标设施点、楼层和单元要素位于同一工作空间中的目标详细信息要素图层、要素类或要素服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object TargetDetailFeatures { get; set; }

		/// <summary>
		/// <para>Target Level Features</para>
		/// <para>符合 ArcGIS Indoors 信息模型并与目标设施点、单元和详细信息要素位于同一工作空间中的目标楼层要素图层、要素类或要素服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object TargetLevelFeatures { get; set; }

		/// <summary>
		/// <para>Target Facility Features</para>
		/// <para>符合 ArcGIS Indoors 信息模型并与目标楼层、单元和详细信息要素位于同一工作空间中的目标设施点要素图层、要素类或要素服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object TargetFacilityFeatures { get; set; }

		/// <summary>
		/// <para>Input Excel Template File</para>
		/// <para>包含输入和配置参数的 Excel 电子表格（.xls 或 .xlsx 文件）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xls", "xlsx")]
		public object InExcelTemplate { get; set; }

		/// <summary>
		/// <para>Unique ID Delimiter</para>
		/// <para>指定将按 Indoors 模型等级分隔键值的分隔符。</para>
		/// <para>句点—该 ID 将包含以句点分隔的键值。 这是默认设置。</para>
		/// <para>连字符—该 ID 将包含以连字符分隔的键值。</para>
		/// <para>下划线—该 ID 将包含以下划线分隔的键值。</para>
		/// <para><see cref="UniqueidDelimiterEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object UniqueidDelimiter { get; set; } = "PERIOD";

		/// <summary>
		/// <para>Sliver Threshold</para>
		/// <para>定义狭长面的周长与面积之比。 可在导入单位面时使用，以提高导入数据的质量。 确定为狭长面的单位面将置于位于 ArcGIS Pro 工程的临时文件夹中的检查地理数据库中。 默认值为 2。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object? SliverThreshold { get; set; } = "2";

		/// <summary>
		/// <para>Door Close Buffer</para>
		/// <para>该工具以门为原点搜索的距离（以英寸为单位），以查找并捕捉到最近的墙壁。 当在输入 Excel 模板文件中将 CLOSE_DOORS 列设置为 Y 时，将使用此参数。 默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPCodedValueDomain()]
		public object? DoorCloseBuffer { get; set; } = "0";

		/// <summary>
		/// <para>Area Unit of Measure</para>
		/// <para>在导入楼层平面图时，指定将用于计算区域字段的面积的测量单位。</para>
		/// <para>平方英尺—将以平方英尺为单位来定义面积。 这是默认设置。</para>
		/// <para>平方米—将以平方米为单位来定义面积。</para>
		/// <para><see cref="AreaUnitOfMeasureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? AreaUnitOfMeasure { get; set; } = "SQUARE_FEET";

		/// <summary>
		/// <para>Measurement Mode</para>
		/// <para>在导入楼层平面图时，指定将用于计算面积字段的测量模式。</para>
		/// <para>测地线—将使用测地线距离计算面积。 测地线距离（即跨世界曲面的距离）在 3D 球空间中进行计算。 这是默认设置。</para>
		/// <para>平面—将使用平面距离计算面积。 平面距离为在 2D 笛卡尔坐标系中计算的直线欧氏距离。</para>
		/// <para><see cref="MeasurementModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MeasurementMode { get; set; } = "GEODESIC";

		/// <summary>
		/// <para>Target Section Features</para>
		/// <para>符合 ArcGIS Indoors 信息模型并与目标设施点、楼层、单元和详细信息要素位于同一工作空间中的目标地区要素图层、要素类或要素服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object? TargetSectionFeatures { get; set; }

		/// <summary>
		/// <para>Target Zone Features</para>
		/// <para>符合 ArcGIS Indoors 信息模型并与目标设施点、楼层、单元和详细信息要素位于同一工作空间中的目标区域要素图层、要素类或要素服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object? TargetZoneFeatures { get; set; }

		/// <summary>
		/// <para>Updated Units</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedUnits { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportFloorplansToIndoorsGDB SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Unique ID Delimiter</para>
		/// </summary>
		public enum UniqueidDelimiterEnum 
		{
			/// <summary>
			/// <para>句点—该 ID 将包含以句点分隔的键值。 这是默认设置。</para>
			/// </summary>
			[GPValue("PERIOD")]
			[Description("句点")]
			Period,

			/// <summary>
			/// <para>连字符—该 ID 将包含以连字符分隔的键值。</para>
			/// </summary>
			[GPValue("HYPHEN")]
			[Description("连字符")]
			Hyphen,

			/// <summary>
			/// <para>下划线—该 ID 将包含以下划线分隔的键值。</para>
			/// </summary>
			[GPValue("UNDERSCORE")]
			[Description("下划线")]
			Underscore,

		}

		/// <summary>
		/// <para>Area Unit of Measure</para>
		/// </summary>
		public enum AreaUnitOfMeasureEnum 
		{
			/// <summary>
			/// <para>平方英尺—将以平方英尺为单位来定义面积。 这是默认设置。</para>
			/// </summary>
			[GPValue("SQUARE_FEET")]
			[Description("平方英尺")]
			Square_Feet,

			/// <summary>
			/// <para>平方米—将以平方米为单位来定义面积。</para>
			/// </summary>
			[GPValue("SQUARE_METERS")]
			[Description("平方米")]
			Square_Meters,

		}

		/// <summary>
		/// <para>Measurement Mode</para>
		/// </summary>
		public enum MeasurementModeEnum 
		{
			/// <summary>
			/// <para>测地线—将使用测地线距离计算面积。 测地线距离（即跨世界曲面的距离）在 3D 球空间中进行计算。 这是默认设置。</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("测地线")]
			Geodesic,

			/// <summary>
			/// <para>平面—将使用平面距离计算面积。 平面距离为在 2D 笛卡尔坐标系中计算的直线欧氏距离。</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("平面")]
			Planar,

		}

#endregion
	}
}
