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
	/// <para>Disable COGO</para>
	/// <para>Disable COGO</para>
	/// <para>Disables COGO  on a line feature class and removes COGO fields and COGO-enabled labeling and symbology. COGO fields can be deleted.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class DisableCOGO : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLineFeatures">
		/// <para>Input Line Features</para>
		/// <para>The line feature class that will have COGO disabled.</para>
		/// </param>
		public DisableCOGO(object InLineFeatures)
		{
			this.InLineFeatures = InLineFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Disable COGO</para>
		/// </summary>
		public override string DisplayName() => "Disable COGO";

		/// <summary>
		/// <para>Tool Name : DisableCOGO</para>
		/// </summary>
		public override string ToolName() => "DisableCOGO";

		/// <summary>
		/// <para>Tool Excute Name : management.DisableCOGO</para>
		/// </summary>
		public override string ExcuteName() => "management.DisableCOGO";

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
		/// <para>The line feature class that will have COGO disabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLineFeatures { get; set; }

		/// <summary>
		/// <para>Updated Input Line features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object UpdatedLineFeatures { get; set; }

	}
}
