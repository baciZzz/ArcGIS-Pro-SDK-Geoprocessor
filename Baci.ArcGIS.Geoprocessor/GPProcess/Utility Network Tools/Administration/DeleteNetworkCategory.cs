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
	/// <para>删除网络类别</para>
	/// <para>用于删除公共设施网络中的网络类别。</para>
	/// </summary>
	public class DeleteNetworkCategory : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>包含要删除的网络类别的公共设施网络。</para>
		/// </param>
		/// <param name="CategoryName">
		/// <para>Category Name</para>
		/// <para>要删除的网络类别的名称。</para>
		/// </param>
		public DeleteNetworkCategory(object InUtilityNetwork, object CategoryName)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.CategoryName = CategoryName;
		}

		/// <summary>
		/// <para>Tool Display Name : 删除网络类别</para>
		/// </summary>
		public override string DisplayName() => "删除网络类别";

		/// <summary>
		/// <para>Tool Name : DeleteNetworkCategory</para>
		/// </summary>
		public override string ToolName() => "DeleteNetworkCategory";

		/// <summary>
		/// <para>Tool Excute Name : un.DeleteNetworkCategory</para>
		/// </summary>
		public override string ExcuteName() => "un.DeleteNetworkCategory";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, CategoryName, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>包含要删除的网络类别的公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Category Name</para>
		/// <para>要删除的网络类别的名称。</para>
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
