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
	/// <para>Generate Occupant Features</para>
	/// <para>Creates or updates employee or occupant point data that conforms to the ArcGIS Indoors Information Model.</para>
	/// </summary>
	[Obsolete()]
	public class GenerateOccupantFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUnitFeatures">
		/// <para>Input Unit Features</para>
		/// <para>The input polygon features representing building spaces that may be occupied. In the ArcGIS Indoors Information Model, this is the Units layer. The centroid of each space will be used as the point location of the occupant or occupants.</para>
		/// </param>
		/// <param name="UnitIdField">
		/// <para>Unit Identifier Field</para>
		/// <para>The field in the Input Unit Features parameter values that will be used as the primary key to associate building spaces with records in the Input Occupant Table parameter value.</para>
		/// </param>
		/// <param name="InOccupantTable">
		/// <para>Input Occupant Table</para>
		/// <para>The input table that contains information about building occupants.</para>
		/// <para>The information can be stored in a geodatabase table, a sheet in an Excel workbook (.xls or .xlsx file), or a .csv file.</para>
		/// </param>
		/// <param name="OccupantIdField">
		/// <para>Occupant Unit Identifier Field</para>
		/// <para>The field in the Input Occupant Table parameter value that will be used as the primary key to associate occupants with Input Unit Features parameter values.</para>
		/// </param>
		/// <param name="OutOccupantFeatureClass">
		/// <para>Output Occupant Feature Class</para>
		/// <para>The output feature class created from joining the Input Unit Features and Input Occupant Table parameter values.</para>
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
		/// <para>Tool Display Name : Generate Occupant Features</para>
		/// </summary>
		public override string DisplayName() => "Generate Occupant Features";

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
		/// <para>The input polygon features representing building spaces that may be occupied. In the ArcGIS Indoors Information Model, this is the Units layer. The centroid of each space will be used as the point location of the occupant or occupants.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InUnitFeatures { get; set; }

		/// <summary>
		/// <para>Unit Identifier Field</para>
		/// <para>The field in the Input Unit Features parameter values that will be used as the primary key to associate building spaces with records in the Input Occupant Table parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object UnitIdField { get; set; }

		/// <summary>
		/// <para>Input Occupant Table</para>
		/// <para>The input table that contains information about building occupants.</para>
		/// <para>The information can be stored in a geodatabase table, a sheet in an Excel workbook (.xls or .xlsx file), or a .csv file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InOccupantTable { get; set; }

		/// <summary>
		/// <para>Occupant Unit Identifier Field</para>
		/// <para>The field in the Input Occupant Table parameter value that will be used as the primary key to associate occupants with Input Unit Features parameter values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object OccupantIdField { get; set; }

		/// <summary>
		/// <para>Output Occupant Feature Class</para>
		/// <para>The output feature class created from joining the Input Unit Features and Input Occupant Table parameter values.</para>
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
