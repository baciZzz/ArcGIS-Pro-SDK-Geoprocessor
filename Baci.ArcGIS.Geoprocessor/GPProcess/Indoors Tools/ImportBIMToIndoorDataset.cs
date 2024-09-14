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
	/// <para>Import BIM To Indoor Dataset</para>
	/// <para>将 BIM 导入室内数据集</para>
	/// <para>将要素从 BIM 文件导入符合 ArcGIS Indoors 信息模型的室内数据集。 可使用该工具的输出创建楼层感知型地图和场景，以用于楼层感知型应用程序，以及生成用于路由的室内网络。</para>
	/// </summary>
	public class ImportBIMToIndoorDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBimFloorplanLayer">
		/// <para>Input BIM Floorplan Polygon Layer</para>
		/// <para>源 BIM 文件中已添加到当前地图的 Floorplan_Polygon 要素图层。</para>
		/// </param>
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
		/// <param name="FacilityId">
		/// <para>Facility ID</para>
		/// <para>将分配给输出 Indoors 要素的唯一设施点 ID。 设施点 ID 不能包含空格。</para>
		/// </param>
		/// <param name="FacilityName">
		/// <para>Facility Name</para>
		/// <para>建筑物常用名称。</para>
		/// </param>
		/// <param name="GroundFloorName">
		/// <para>Ground Floor Name</para>
		/// <para>建筑物的一楼。 楼层的垂直顺序派生自此输入。 将向高程小于指定的一楼的任何楼层分配负垂直顺序。</para>
		/// </param>
		public ImportBIMToIndoorDataset(object InBimFloorplanLayer, object TargetUnitFeatures, object TargetDetailFeatures, object TargetLevelFeatures, object TargetFacilityFeatures, object FacilityId, object FacilityName, object GroundFloorName)
		{
			this.InBimFloorplanLayer = InBimFloorplanLayer;
			this.TargetUnitFeatures = TargetUnitFeatures;
			this.TargetDetailFeatures = TargetDetailFeatures;
			this.TargetLevelFeatures = TargetLevelFeatures;
			this.TargetFacilityFeatures = TargetFacilityFeatures;
			this.FacilityId = FacilityId;
			this.FacilityName = FacilityName;
			this.GroundFloorName = GroundFloorName;
		}

		/// <summary>
		/// <para>Tool Display Name : 将 BIM 导入室内数据集</para>
		/// </summary>
		public override string DisplayName() => "将 BIM 导入室内数据集";

		/// <summary>
		/// <para>Tool Name : ImportBIMToIndoorDataset</para>
		/// </summary>
		public override string ToolName() => "ImportBIMToIndoorDataset";

		/// <summary>
		/// <para>Tool Excute Name : indoors.ImportBIMToIndoorDataset</para>
		/// </summary>
		public override string ExcuteName() => "indoors.ImportBIMToIndoorDataset";

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
		public override object[] Parameters() => new object[] { InBimFloorplanLayer, TargetUnitFeatures, TargetDetailFeatures, TargetLevelFeatures, TargetFacilityFeatures, FacilityId, FacilityName, GroundFloorName, FloorplanPolygonUseTypeField!, FloorsToImport!, AreaUnitOfMeasure!, InBimRoomsLayer!, RoomPropertiesMapping!, AllowInsertNewFacility!, UpdatedUnits! };

		/// <summary>
		/// <para>Input BIM Floorplan Polygon Layer</para>
		/// <para>源 BIM 文件中已添加到当前地图的 Floorplan_Polygon 要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InBimFloorplanLayer { get; set; }

		/// <summary>
		/// <para>Target Unit Features</para>
		/// <para>符合 ArcGIS Indoors 信息模型并与目标设施点、楼层和详细信息要素位于同一工作空间中的目标单元要素图层、要素类或要素服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object TargetUnitFeatures { get; set; }

		/// <summary>
		/// <para>Target Detail Features</para>
		/// <para>符合 ArcGIS Indoors 信息模型并与目标设施点、楼层和单元要素位于同一工作空间中的目标详细信息要素图层、要素类或要素服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object TargetDetailFeatures { get; set; }

		/// <summary>
		/// <para>Target Level Features</para>
		/// <para>符合 ArcGIS Indoors 信息模型并与目标设施点、单元和详细信息要素位于同一工作空间中的目标楼层要素图层、要素类或要素服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object TargetLevelFeatures { get; set; }

		/// <summary>
		/// <para>Target Facility Features</para>
		/// <para>符合 ArcGIS Indoors 信息模型并与目标楼层、单元和详细信息要素位于同一工作空间中的目标设施点要素图层、要素类或要素服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object TargetFacilityFeatures { get; set; }

		/// <summary>
		/// <para>Facility ID</para>
		/// <para>将分配给输出 Indoors 要素的唯一设施点 ID。 设施点 ID 不能包含空格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FacilityId { get; set; }

		/// <summary>
		/// <para>Facility Name</para>
		/// <para>建筑物常用名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FacilityName { get; set; }

		/// <summary>
		/// <para>Ground Floor Name</para>
		/// <para>建筑物的一楼。 楼层的垂直顺序派生自此输入。 将向高程小于指定的一楼的任何楼层分配负垂直顺序。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object GroundFloorName { get; set; }

		/// <summary>
		/// <para>Floorplan Polygon Use Type Field</para>
		/// <para>Floorplan_Polygon 要素图层中的字段，将用于填充目标单元要素的 USE_TYPE 字段。 如果未提供任何字段，则将使用 Floorplan_Polygon 图层中的 RoomName 字段值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? FloorplanPolygonUseTypeField { get; set; }

		/// <summary>
		/// <para>Floors To Import</para>
		/// <para>输入 BIM 文件中将导入目标要素的楼层。 如果未提供楼层，则将导入所有楼层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? FloorsToImport { get; set; }

		/// <summary>
		/// <para>Area Unit of Measure</para>
		/// <para>指定将用于楼层和单元要素类中的面积字段的测量单位。</para>
		/// <para>平方米—面积单位将为平方米。</para>
		/// <para>平方英尺—面积单位将为平方英尺。 这是默认设置。</para>
		/// <para><see cref="AreaUnitOfMeasureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? AreaUnitOfMeasure { get; set; } = "SQUARE_FEET";

		/// <summary>
		/// <para>Input BIM Rooms Layer</para>
		/// <para>来自输入 BIM 文件的建筑数据集的房间图层。 该图层将用于获取扩展字段值，这些值可以使用房间属性映射参数映射到 Units 要素类中的现有字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object? InBimRoomsLayer { get; set; }

		/// <summary>
		/// <para>Room Properties Mapping</para>
		/// <para>控制将使用来自输入 BIM 房间图层的字段值填充 Units 要素类中的哪些属性字段。 运行该工具之前，字段必须存在。 建议将输入 BIM 房间图层中的字段映射到具有相同字段类型的 Units 要素类中的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldMapping()]
		public object? RoomPropertiesMapping { get; set; }

		/// <summary>
		/// <para>Allow insert of new overlapping facility</para>
		/// <para>指定如果在建筑物的楼层平面图和目标设施点要素中的现有设施点要素之间检测到相交，是否将导入来自输入 BIM 文件的建筑物。</para>
		/// <para>未选中 - 该工具将测试输入 BIM 楼层平面图面是否与目标要素中的任何现有设施点面相交。 如果检测到相交，该工具将检查指定的设施点 ID 和设施点名称参数值是否与相交设施点要素的 FACILITY_ID 和 NAME 字段值匹配。 如果值匹配，该工具将更新现有设施点。 如果值不匹配，该工具将发出消息并停止运行。 这是默认设置。</para>
		/// <para>选中此 - 该工具将不会测试输入 BIM 楼层平面图面是否与目标设施点要素中的任何现有设施点面相交。 可以使用此选项导入与现有设施点重叠或接触的建筑物。</para>
		/// <para><see cref="AllowInsertNewFacilityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AllowInsertNewFacility { get; set; } = "false";

		/// <summary>
		/// <para>Updated Units</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedUnits { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportBIMToIndoorDataset SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Area Unit of Measure</para>
		/// </summary>
		public enum AreaUnitOfMeasureEnum 
		{
			/// <summary>
			/// <para>平方米—面积单位将为平方米。</para>
			/// </summary>
			[GPValue("SQUARE_METERS")]
			[Description("平方米")]
			Square_Meters,

			/// <summary>
			/// <para>平方英尺—面积单位将为平方英尺。 这是默认设置。</para>
			/// </summary>
			[GPValue("SQUARE_FEET")]
			[Description("平方英尺")]
			Square_Feet,

		}

		/// <summary>
		/// <para>Allow insert of new overlapping facility</para>
		/// </summary>
		public enum AllowInsertNewFacilityEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ALLOW_INSERT_NEW_FACILITY")]
			NO_ALLOW_INSERT_NEW_FACILITY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ALLOW_INSERT_NEW_FACILITY")]
			ALLOW_INSERT_NEW_FACILITY,

		}

#endregion
	}
}
