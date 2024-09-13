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
	/// <para>Generate Facility Entryways</para>
	/// <para>生成设施点入口</para>
	/// <para>用于创建或更新表示建筑物入口或出口位置的点。</para>
	/// </summary>
	public class GenerateFacilityEntryways : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLevelFeatures">
		/// <para>Input Level Features</para>
		/// <para>输入面要素，表示一个或多个设施点中的一个或多个楼层。 在 Indoors 模型中，此项将为 Levels 图层。 该工具将仅处理这些要素表示的楼层。</para>
		/// </param>
		/// <param name="InUnitFeatures">
		/// <para>Input Unit Features</para>
		/// <para>表示建筑物空间的输入面要素。 在 Indoors 模型中，此项将为 Units 图层。 在标识设施点的外部边时，该工具将使用这些要素。</para>
		/// </param>
		/// <param name="InDoorFeatures">
		/// <para>Input Door Features</para>
		/// <para>表示门的输入折线要素。 在 Indoors 模型中，这将为 Details 图层中的要素子集。 在标识沿设施点外部的入口时，该工具将使用这些要素。图层必须选择一个或多个门要素才能运行该工具。 可以使用按属性选择图层工具进行选择。</para>
		/// </param>
		/// <param name="TargetEntryways">
		/// <para>Target Entryways</para>
		/// <para>将写入生成的入口点的要素类或要素图层。</para>
		/// </param>
		public GenerateFacilityEntryways(object InLevelFeatures, object InUnitFeatures, object InDoorFeatures, object TargetEntryways)
		{
			this.InLevelFeatures = InLevelFeatures;
			this.InUnitFeatures = InUnitFeatures;
			this.InDoorFeatures = InDoorFeatures;
			this.TargetEntryways = TargetEntryways;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成设施点入口</para>
		/// </summary>
		public override string DisplayName() => "生成设施点入口";

		/// <summary>
		/// <para>Tool Name : GenerateFacilityEntryways</para>
		/// </summary>
		public override string ToolName() => "GenerateFacilityEntryways";

		/// <summary>
		/// <para>Tool Excute Name : indoors.GenerateFacilityEntryways</para>
		/// </summary>
		public override string ExcuteName() => "indoors.GenerateFacilityEntryways";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLevelFeatures, InUnitFeatures, InDoorFeatures, TargetEntryways, BufferSize!, EntrywayUseType!, ExteriorUnitExp!, DeleteExistingEntryways!, UpdatedEntryways!, LevelIdField!, UseTypeField! };

		/// <summary>
		/// <para>Input Level Features</para>
		/// <para>输入面要素，表示一个或多个设施点中的一个或多个楼层。 在 Indoors 模型中，此项将为 Levels 图层。 该工具将仅处理这些要素表示的楼层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InLevelFeatures { get; set; }

		/// <summary>
		/// <para>Input Unit Features</para>
		/// <para>表示建筑物空间的输入面要素。 在 Indoors 模型中，此项将为 Units 图层。 在标识设施点的外部边时，该工具将使用这些要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InUnitFeatures { get; set; }

		/// <summary>
		/// <para>Input Door Features</para>
		/// <para>表示门的输入折线要素。 在 Indoors 模型中，这将为 Details 图层中的要素子集。 在标识沿设施点外部的入口时，该工具将使用这些要素。图层必须选择一个或多个门要素才能运行该工具。 可以使用按属性选择图层工具进行选择。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InDoorFeatures { get; set; }

		/// <summary>
		/// <para>Target Entryways</para>
		/// <para>将写入生成的入口点的要素类或要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object TargetEntryways { get; set; }

		/// <summary>
		/// <para>Buffer Size</para>
		/// <para>该工具将从设施点的外部边向内和向外进行搜索以标识潜在入口的距离，以米为单位。 默认值为 0.5，且必须大于 0 且小于 10。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 10)]
		public object? BufferSize { get; set; } = "0.5";

		/// <summary>
		/// <para>Entryway Use Type</para>
		/// <para>用于计算新入口点的 USE_TYPE 字段的值。 默认值为 Entry。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? EntrywayUseType { get; set; } = "Entry";

		/// <summary>
		/// <para>Exterior Unit Expression</para>
		/// <para>一个 SQL 表达式，用于定义表示设施点外部空间的输入单元要素值，例如露台或逃生通道。 在入口生成过程中，匹配此表达式的空间将被视为外部要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? ExteriorUnitExp { get; set; }

		/// <summary>
		/// <para>Delete Existing Entryways</para>
		/// <para>指定在创建新的入口点之前，是否将删除 USE_TYPE 字段值匹配入口使用类型参数值的现有入口要素。 在删除现有入口时，该工具将仅标识输入楼层要素参数中包含的楼层上的入口。</para>
		/// <para>选中 - 将删除现有要素。</para>
		/// <para>未选中 - 将不删除现有要素。 这是默认设置。</para>
		/// <para><see cref="DeleteExistingEntrywaysEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeleteExistingEntryways { get; set; } = "false";

		/// <summary>
		/// <para>Updated Entryways</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? UpdatedEntryways { get; set; }

		/// <summary>
		/// <para>Level ID Field</para>
		/// <para>将使用新入口要素的关联楼层 ID 进行更新的字段。 如果输入楼层要素参数值是楼层感知型图层，则此参数将默认为该图层的已配置楼层字段值。 否则，该参数将默认为 LEVEL_ID 字段。 如果目标入口要素图层中不存在已定义字段，则系统将创建一个具有所提供名称的新字段，并使用楼层 ID 字段值对其进行填充。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object? LevelIdField { get; set; } = "LEVEL_ID";

		/// <summary>
		/// <para>Use Type Field</para>
		/// <para>将使用新入口要素的入口使用类型值进行更新的字段。 其默认设置为 USE_TYPE 字段。 如果目标入口要素图层中不存在已定义字段，则系统将创建一个具有所提供名称的字段，并使用入口使用类型值对其进行填充。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object? UseTypeField { get; set; } = "USE_TYPE";

		#region InnerClass

		/// <summary>
		/// <para>Delete Existing Entryways</para>
		/// </summary>
		public enum DeleteExistingEntrywaysEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_FEATURES")]
			DELETE_FEATURES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_FEATURES")]
			NO_DELETE_FEATURES,

		}

#endregion
	}
}
