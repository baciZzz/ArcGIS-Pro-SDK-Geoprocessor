using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CrimeAnalysisandSafetyTools
{
	/// <summary>
	/// <para>Add Date Attributes</para>
	/// <para>Adds fields containing date or time properties from an input date field, for example, day full name, day of the month, month, and year.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddDateAttributes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The layer or table that contains the field with the date values that need to be extracted.</para>
		/// </param>
		/// <param name="DateField">
		/// <para>Date Field</para>
		/// <para>The date field from which data and time properties will be extracted to populate the new field values.</para>
		/// </param>
		public AddDateAttributes(object InTable, object DateField)
		{
			this.InTable = InTable;
			this.DateField = DateField;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Date Attributes</para>
		/// </summary>
		public override string DisplayName => "Add Date Attributes";

		/// <summary>
		/// <para>Tool Name : AddDateAttributes</para>
		/// </summary>
		public override string ToolName => "AddDateAttributes";

		/// <summary>
		/// <para>Tool Excute Name : ca.AddDateAttributes</para>
		/// </summary>
		public override string ExcuteName => "ca.AddDateAttributes";

		/// <summary>
		/// <para>Toolbox Display Name : Crime Analysis and Safety Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Crime Analysis and Safety Tools";

		/// <summary>
		/// <para>Toolbox Alise : ca</para>
		/// </summary>
		public override string ToolboxAlise => "ca";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, DateField, DateAttributes, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The layer or table that contains the field with the date values that need to be extracted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Date Field</para>
		/// <para>The date field from which data and time properties will be extracted to populate the new field values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object DateField { get; set; }

		/// <summary>
		/// <para>Date Attributes</para>
		/// <para>Specifies the date and time properties and fields that will be added to the input table.</para>
		/// <para>Output Time Format—The date or time property to be added to the Output Field Name.</para>
		/// <para>Output Field Name—The name of the field that will be added to the input table.</para>
		/// <para>Output Time Format options are as follows:</para>
		/// <para>Hour—The hour value between 0 and 23.</para>
		/// <para>Day Full Name—The full name of the day of the week, for example, Wednesday.</para>
		/// <para>Month—The month value between 1 and 12.</para>
		/// <para>Day of the Month—The day of the month value between 1 and 31.</para>
		/// <para>Year——The year value in yyyy format, for example, 1983.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object DateAttributes { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddDateAttributes SetEnviroment(object extent = null , object workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

	}
}
