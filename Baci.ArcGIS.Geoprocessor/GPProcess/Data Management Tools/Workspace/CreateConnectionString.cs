using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Create Connection String</para>
	/// <para>Create a connection string</para>
	/// </summary>
	[Obsolete()]
	public class CreateConnectionString : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input Data Element</para>
		/// </param>
		public CreateConnectionString(object InData)
		{
			this.InData = InData;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Connection String</para>
		/// </summary>
		public override string DisplayName => "Create Connection String";

		/// <summary>
		/// <para>Tool Name : CreateConnectionString</para>
		/// </summary>
		public override string ToolName => "CreateConnectionString";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateConnectionString</para>
		/// </summary>
		public override string ExcuteName => "management.CreateConnectionString";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InData, DataType, OutConnectionString };

		/// <summary>
		/// <para>Input Data Element</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Data Type</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DataType { get; set; }

		/// <summary>
		/// <para>CIMDATA Connection String</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutConnectionString { get; set; }

	}
}
