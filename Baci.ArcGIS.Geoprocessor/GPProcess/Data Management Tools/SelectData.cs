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
	/// <para>Select Data</para>
	/// <para>Select Data</para>
	/// <para>The Select Data tool selects data in a parent data element such as a folder, geodatabase, feature dataset, or coverage.</para>
	/// </summary>
	[Obsolete()]
	public class SelectData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataelement">
		/// <para>Input Data Element</para>
		/// <para>The input data element can be a folder, geodatabase, or feature dataset.</para>
		/// </param>
		public SelectData(object InDataelement)
		{
			this.InDataelement = InDataelement;
		}

		/// <summary>
		/// <para>Tool Display Name : Select Data</para>
		/// </summary>
		public override string DisplayName() => "Select Data";

		/// <summary>
		/// <para>Tool Name : SelectData</para>
		/// </summary>
		public override string ToolName() => "SelectData";

		/// <summary>
		/// <para>Tool Excute Name : management.SelectData</para>
		/// </summary>
		public override string ExcuteName() => "management.SelectData";

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
		public override object[] Parameters() => new object[] { InDataelement, OutDataelement, OutDataelementDerived };

		/// <summary>
		/// <para>Input Data Element</para>
		/// <para>The input data element can be a folder, geodatabase, or feature dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataelement { get; set; }

		/// <summary>
		/// <para>Child Data Element</para>
		/// <para>The child data element is contained by the input data element. Once the input data element is specified, the child data element control contains a drop-down list of the data elements contained in the input data element. For example, if the input is a feature dataset, all the feature classes within the feature dataset are included in the drop-down list. A single element is selected from this list.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object OutDataelement { get; set; }

		/// <summary>
		/// <para>Child  Data Element</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutDataelementDerived { get; set; }

	}
}
