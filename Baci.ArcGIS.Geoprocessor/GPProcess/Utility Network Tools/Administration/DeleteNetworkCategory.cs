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
	/// <para>Delete Network Category</para>
	/// <para>Deletes a network category in a utility network.</para>
	/// </summary>
	public class DeleteNetworkCategory : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the network category to be deleted.</para>
		/// </param>
		/// <param name="CategoryName">
		/// <para>Category Name</para>
		/// <para>The name of the network category to delete.</para>
		/// </param>
		public DeleteNetworkCategory(object InUtilityNetwork, object CategoryName)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.CategoryName = CategoryName;
		}

		/// <summary>
		/// <para>Tool Display Name : Delete Network Category</para>
		/// </summary>
		public override string DisplayName => "Delete Network Category";

		/// <summary>
		/// <para>Tool Name : DeleteNetworkCategory</para>
		/// </summary>
		public override string ToolName => "DeleteNetworkCategory";

		/// <summary>
		/// <para>Tool Excute Name : un.DeleteNetworkCategory</para>
		/// </summary>
		public override string ExcuteName => "un.DeleteNetworkCategory";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InUtilityNetwork, CategoryName, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the network category to be deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Category Name</para>
		/// <para>The name of the network category to delete.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object CategoryName { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

	}
}
