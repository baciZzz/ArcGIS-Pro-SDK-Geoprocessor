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
	/// <para>Generate Occupant Features</para>
	/// <para>生成占用者要素</para>
	/// <para>创建或更新符合 ArcGIS Indoors 信息模型的员工或占用者点数据。</para>
	/// </summary>
	[Obsolete()]
	public class GenerateOccupantFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUnitFeatures">
		/// <para>Input Unit Features</para>
		/// <para>输入面要素，表示可能被占用的建筑空间。 在 ArcGIS Indoors 信息模型中，此项将为 Units 图层。 每个空间的质心将用作一个或多个占用者的点位置。</para>
		/// </param>
		/// <param name="UnitIdField">
		/// <para>Unit Identifier Field</para>
		/// <para>输入单元要素参数值中的字段，将用作主键以将建筑空间与输入占用者表参数值中的记录相关联。</para>
		/// </param>
		/// <param name="InOccupantTable">
		/// <para>Input Occupant Table</para>
		/// <para>包含有关建筑占用者信息的输入表。</para>
		/// <para>信息可以存储在地理数据库表、Excel 工作簿中的工作表（.xls 或 .xlsx 文件）或 .csv 文件中。</para>
		/// </param>
		/// <param name="OccupantIdField">
		/// <para>Occupant Unit Identifier Field</para>
		/// <para>输入占用者表参数值中的字段，将用作主键以将占用者与输入单元要素参数值相关联。</para>
		/// </param>
		/// <param name="OutOccupantFeatureClass">
		/// <para>Output Occupant Feature Class</para>
		/// <para>通过连接输入单元要素和输入占用者表参数值创建的输出要素类。</para>
		/// </param>
		public GenerateOccupantFeatures(object InUnitFeatures, object UnitIdField, object InOccupantTable, object OccupantIdField, object OutOccupantFeatureClass)
		{
			this.InUnitFeatures = InUnitFeatures;
			this.UnitIdField = UnitIdField;
			this.InOccupantTable = InOccupantTable;
			this.OccupantIdField = OccupantIdField;
			this.OutOccupantFeatureClass = OutOccupantFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成占用者要素</para>
		/// </summary>
		public override string DisplayName() => "生成占用者要素";

		/// <summary>
		/// <para>Tool Name : GenerateOccupantFeatures</para>
		/// </summary>
		public override string ToolName() => "GenerateOccupantFeatures";

		/// <summary>
		/// <para>Tool Excute Name : indoors.GenerateOccupantFeatures</para>
		/// </summary>
		public override string ExcuteName() => "indoors.GenerateOccupantFeatures";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUnitFeatures, UnitIdField, InOccupantTable, OccupantIdField, OutOccupantFeatureClass, UpdatedUnitFeatureClass! };

		/// <summary>
		/// <para>Input Unit Features</para>
		/// <para>输入面要素，表示可能被占用的建筑空间。 在 ArcGIS Indoors 信息模型中，此项将为 Units 图层。 每个空间的质心将用作一个或多个占用者的点位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InUnitFeatures { get; set; }

		/// <summary>
		/// <para>Unit Identifier Field</para>
		/// <para>输入单元要素参数值中的字段，将用作主键以将建筑空间与输入占用者表参数值中的记录相关联。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object UnitIdField { get; set; }

		/// <summary>
		/// <para>Input Occupant Table</para>
		/// <para>包含有关建筑占用者信息的输入表。</para>
		/// <para>信息可以存储在地理数据库表、Excel 工作簿中的工作表（.xls 或 .xlsx 文件）或 .csv 文件中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InOccupantTable { get; set; }

		/// <summary>
		/// <para>Occupant Unit Identifier Field</para>
		/// <para>输入占用者表参数值中的字段，将用作主键以将占用者与输入单元要素参数值相关联。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object OccupantIdField { get; set; }

		/// <summary>
		/// <para>Output Occupant Feature Class</para>
		/// <para>通过连接输入单元要素和输入占用者表参数值创建的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutOccupantFeatureClass { get; set; }

		/// <summary>
		/// <para>Updated Unit Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? UpdatedUnitFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateOccupantFeatures SetEnviroment(object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

	}
}
