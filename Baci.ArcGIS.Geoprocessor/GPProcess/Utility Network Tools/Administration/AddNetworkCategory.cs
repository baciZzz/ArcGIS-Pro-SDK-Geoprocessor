using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.UtilityNetworkTools
{
	/// <summary>
	/// <para>Add Network Category</para>
	/// <para>Add Network Category</para>
	/// <para>Adds a network category to an existing utility network.</para>
	/// </summary>
	public class AddNetworkCategory : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The input utility network where the network category will be added.</para>
		/// </param>
		/// <param name="CategoryName">
		/// <para>Category Name</para>
		/// <para>The name of the category to be created.</para>
		/// </param>
		public AddNetworkCategory(object InUtilityNetwork, object CategoryName)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.CategoryName = CategoryName;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Network Category</para>
		/// </summary>
		public override string DisplayName() => "Add Network Category";

		/// <summary>
		/// <para>Tool Name : AddNetworkCategory</para>
		/// </summary>
		public override string ToolName() => "AddNetworkCategory";

		/// <summary>
		/// <para>Tool Excute Name : un.AddNetworkCategory</para>
		/// </summary>
		public override string ExcuteName() => "un.AddNetworkCategory";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise() => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, CategoryName, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The input utility network where the network category will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Category Name</para>
		/// <para>The name of the category to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object CategoryName { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

	}
}
