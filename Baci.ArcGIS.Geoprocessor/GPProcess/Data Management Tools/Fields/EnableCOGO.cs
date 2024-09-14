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
	/// <para>Enable COGO</para>
	/// <para>Enable COGO</para>
	/// <para>Enables COGO on a line feature class and adds COGO fields and COGO-enabled labeling to a line feature class. COGO fields store  dimensions  that are used to create line features in relation to each other.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class EnableCOGO : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLineFeatures">
		/// <para>Input Line Features</para>
		/// <para>The line feature class that will be COGO enabled.</para>
		/// </param>
		public EnableCOGO(object InLineFeatures)
		{
			this.InLineFeatures = InLineFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Enable COGO</para>
		/// </summary>
		public override string DisplayName() => "Enable COGO";

		/// <summary>
		/// <para>Tool Name : EnableCOGO</para>
		/// </summary>
		public override string ToolName() => "EnableCOGO";

		/// <summary>
		/// <para>Tool Excute Name : management.EnableCOGO</para>
		/// </summary>
		public override string ExcuteName() => "management.EnableCOGO";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLineFeatures, UpdatedLineFeatures };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>The line feature class that will be COGO enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLineFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object UpdatedLineFeatures { get; set; }

	}
}
