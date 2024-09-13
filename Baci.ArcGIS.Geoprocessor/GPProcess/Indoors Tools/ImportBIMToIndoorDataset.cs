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
	/// <para>将要素从 BIM 文件导入室内数据集。</para>
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
		/// <param name="TargetIndoorDataset">
		/// <para>Target Indoor Dataset</para>
		/// <para>符合 ArcGIS Indoors 信息模型且包含“设施点”、“楼层”、“单元”和“细节”要素类的目标室内数据集。</para>
		/// </param>
		/// <param name="GroundFloorName">
		/// <para>Ground Floor Name</para>
		/// <para>建筑物的一楼。 楼层的垂直顺序派生自此输入。 将向高程小于指定的一楼的任何楼层分配负垂直顺序。</para>
		/// </param>
		public ImportBIMToIndoorDataset(object InBimFloorplanLayer, object TargetIndoorDataset, object GroundFloorName)
		{
			this.InBimFloorplanLayer = InBimFloorplanLayer;
			this.TargetIndoorDataset = TargetIndoorDataset;
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
		public override object[] Parameters() => new object[] { InBimFloorplanLayer, TargetIndoorDataset, GroundFloorName, BuildingName, RoomCategoryField, FloorsToImport, AreaUnitOfMeasure, UpdatedIndoorDataset };

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
		/// <para>Target Indoor Dataset</para>
		/// <para>符合 ArcGIS Indoors 信息模型且包含“设施点”、“楼层”、“单元”和“细节”要素类的目标室内数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object TargetIndoorDataset { get; set; }

		/// <summary>
		/// <para>Ground Floor Name</para>
		/// <para>建筑物的一楼。 楼层的垂直顺序派生自此输入。 将向高程小于指定的一楼的任何楼层分配负垂直顺序。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object GroundFloorName { get; set; }

		/// <summary>
		/// <para>Building Name</para>
		/// <para>将分配给输出 Indoors 要素的唯一建筑物名称。 默认值为输入 BIM 文件中的 Bldg_Name 字段值。 如果该字段为 null 或为空，则将使用输入源文件的名称填充此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object BuildingName { get; set; }

		/// <summary>
		/// <para>Room Category Field</para>
		/// <para>Floorplan_Polygon 要素图层中的字段，将用于填充目标室内数据集中“单元”要素类的 USE_TYPE 字段。 如果未提供任何字段，则将使用 Floorplan_Polygon 图层中的 RoomName 字段值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object RoomCategoryField { get; set; }

		/// <summary>
		/// <para>Floors To Import</para>
		/// <para>输入 BIM 文件中将导入目标室内数据集的楼层。 如果未提供楼层，则将导入所有楼层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object FloorsToImport { get; set; }

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
		public object AreaUnitOfMeasure { get; set; } = "SQUARE_FEET";

		/// <summary>
		/// <para>Updated Indoor Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureDataset()]
		public object UpdatedIndoorDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportBIMToIndoorDataset SetEnviroment(object workspace = null )
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

#endregion
	}
}
