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
	/// <para>Update Occupant Features</para>
	/// <para>更新占用者要素</para>
	/// <para>更新符合 ArcGIS Indoors 信息模型的 Occupants 要素类。</para>
	/// </summary>
	public class UpdateOccupantFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetOccupantFeatures">
		/// <para>Target Occupant Features</para>
		/// <para>将添加、更新或删除占用者记录的目标要素图层、要素类或要素服务。 输入必须包含可标识每个占用者的唯一值，并且必须与 Indoors 模型中的 Occupants 要素类相符。</para>
		/// </param>
		public UpdateOccupantFeatures(object TargetOccupantFeatures)
		{
			this.TargetOccupantFeatures = TargetOccupantFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 更新占用者要素</para>
		/// </summary>
		public override string DisplayName() => "更新占用者要素";

		/// <summary>
		/// <para>Tool Name : UpdateOccupantFeatures</para>
		/// </summary>
		public override string ToolName() => "UpdateOccupantFeatures";

		/// <summary>
		/// <para>Tool Excute Name : indoors.UpdateOccupantFeatures</para>
		/// </summary>
		public override string ExcuteName() => "indoors.UpdateOccupantFeatures";

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
		public override object[] Parameters() => new object[] { TargetOccupantFeatures, InUnitFeatures!, InOccupantTable!, OccupantIdFromTargetOccupantFeatures!, OccupantIdFromInputTable!, UnitIdFromUnitsFeatures!, UnitIdFromInputTable!, OccupantAttributesMapping!, AllowInsert!, AllowDelete!, UpdatedOccupantFeatures! };

		/// <summary>
		/// <para>Target Occupant Features</para>
		/// <para>将添加、更新或删除占用者记录的目标要素图层、要素类或要素服务。 输入必须包含可标识每个占用者的唯一值，并且必须与 Indoors 模型中的 Occupants 要素类相符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object TargetOccupantFeatures { get; set; }

		/// <summary>
		/// <para>Input Unit Features</para>
		/// <para>输入面要素，表示可能被占用的建筑空间。 在 ArcGIS Indoors 信息模型中，此项将为 Units 图层。 每个空间的质心将用作一个或多个占用者的点位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object? InUnitFeatures { get; set; }

		/// <summary>
		/// <para>Input Occupant Table</para>
		/// <para>包含有关建筑占用者信息的输入表。</para>
		/// <para>信息可以存储在地理数据库表、Excel 工作簿中的工作表（.xls 或 .xlsx 文件）或 .csv 文件中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object? InOccupantTable { get; set; }

		/// <summary>
		/// <para>Occupant Identifier (Target Occupant Features)</para>
		/// <para>目标占用者要素参数值中的字段，将用作主键以将占用者与输入占用者表参数值相关联。 字段值必须唯一。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Long", "Short", "GUID", "Double")]
		public object? OccupantIdFromTargetOccupantFeatures { get; set; }

		/// <summary>
		/// <para>Occupant Identifier (Input Occupant Table)</para>
		/// <para>输入占用者表参数值中的字段，将用作主键以将占用者与目标占用者要素参数值相关联。 字段值必须唯一。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Long", "Short", "GUID", "Double")]
		public object? OccupantIdFromInputTable { get; set; }

		/// <summary>
		/// <para>Unit Identifier (Input Units Features)</para>
		/// <para>输入单元要素参数值中的字段，用于存储与输入占用者表参数值中的单元标识符相匹配的唯一空间标识信息。 字段值必须唯一。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Long", "Short", "GUID")]
		public object? UnitIdFromUnitsFeatures { get; set; }

		/// <summary>
		/// <para>Unit Identifier (Input Occupant Table)</para>
		/// <para>输入占用者表参数值中的字段，将用作主键以将占用者空间分配与输入单元要素参数值相关联。 如果字段值为空，则占用者将以未分配状态加载。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Text", "Long", "Short", "GUID")]
		public object? UnitIdFromInputTable { get; set; }

		/// <summary>
		/// <para>Occupant Attributes Mapping</para>
		/// <para>目标占用者要素参数中的属性字段，将使用输入占用者表参数值中的字段值填充。 在运行工具之前，这些字段必须存在于目标占用者要素参数值中。 建议您将输入占用者表参数值中的字段映射到目标占用者要素参数值中具有相同字段类型的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldMapping()]
		public object? OccupantAttributesMapping { get; set; }

		/// <summary>
		/// <para>Insert new occupants</para>
		/// <para>指定是否将向目标占用者要素图层添加输入占用者表参数值的唯一占用者记录。</para>
		/// <para>选中 - 不匹配的占用者记录将添加到目标占用者要素图层。 这是默认设置。</para>
		/// <para>未选中 - 不匹配的占用者记录不会添加到目标占用者要素图层。</para>
		/// <para><see cref="AllowInsertEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AllowInsert { get; set; } = "true";

		/// <summary>
		/// <para>Delete occupants not included in the Input Occupant Table</para>
		/// <para>指定是否将从目标占用者要素图层删除输入占用者表参数值的唯一占用者记录。</para>
		/// <para>选中 - 不匹配的占用者记录将从目标占用者要素图层中删除。 这是默认设置。</para>
		/// <para>未选中 - 不匹配的占用者记录不会从目标占用者要素图层中删除。</para>
		/// <para><see cref="AllowDeleteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AllowDelete { get; set; } = "true";

		/// <summary>
		/// <para>Updated Occupant Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedOccupantFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UpdateOccupantFeatures SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Insert new occupants</para>
		/// </summary>
		public enum AllowInsertEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INSERT_OCCUPANTS")]
			INSERT_OCCUPANTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_INSERT_OCCUPANTS")]
			NO_INSERT_OCCUPANTS,

		}

		/// <summary>
		/// <para>Delete occupants not included in the Input Occupant Table</para>
		/// </summary>
		public enum AllowDeleteEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_OCCUPANTS")]
			DELETE_OCCUPANTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_OCCUPANTS")]
			NO_DELETE_OCCUPANTS,

		}

#endregion
	}
}
