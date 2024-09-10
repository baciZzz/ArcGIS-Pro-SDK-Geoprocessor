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
	/// <para>Sort Coded Value Domain</para>
	/// <para>Sorts the code or description of a coded value domain in either ascending or descending order.</para>
	/// </summary>
	public class SortCodedValueDomain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>The geodatabase containing the domain to be sorted.</para>
		/// </param>
		/// <param name="DomainName">
		/// <para>Domain Name</para>
		/// <para>The name of the coded value domain to be sorted.</para>
		/// </param>
		/// <param name="SortBy">
		/// <para>Sort By</para>
		/// <para>Specifies whether the code or description will be used to sort the domain.</para>
		/// <para>Code—Records are sorted based on the code value for the domain.</para>
		/// <para>Description—Records are sorted based on the description value for the domain.</para>
		/// <para><see cref="SortByEnum"/></para>
		/// </param>
		/// <param name="SortOrder">
		/// <para>Sort Order</para>
		/// <para>Specifies the direction the records will be sorted.</para>
		/// <para>Ascending—Records are sorted from low value to high value.</para>
		/// <para>Descending—Records are sorted from high value to low value.</para>
		/// <para><see cref="SortOrderEnum"/></para>
		/// </param>
		public SortCodedValueDomain(object InWorkspace, object DomainName, object SortBy, object SortOrder)
		{
			this.InWorkspace = InWorkspace;
			this.DomainName = DomainName;
			this.SortBy = SortBy;
			this.SortOrder = SortOrder;
		}

		/// <summary>
		/// <para>Tool Display Name : Sort Coded Value Domain</para>
		/// </summary>
		public override string DisplayName() => "Sort Coded Value Domain";

		/// <summary>
		/// <para>Tool Name : SortCodedValueDomain</para>
		/// </summary>
		public override string ToolName() => "SortCodedValueDomain";

		/// <summary>
		/// <para>Tool Excute Name : management.SortCodedValueDomain</para>
		/// </summary>
		public override string ExcuteName() => "management.SortCodedValueDomain";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, DomainName, SortBy, SortOrder, OutWorkspace };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The geodatabase containing the domain to be sorted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Domain Name</para>
		/// <para>The name of the coded value domain to be sorted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainName { get; set; }

		/// <summary>
		/// <para>Sort By</para>
		/// <para>Specifies whether the code or description will be used to sort the domain.</para>
		/// <para>Code—Records are sorted based on the code value for the domain.</para>
		/// <para>Description—Records are sorted based on the description value for the domain.</para>
		/// <para><see cref="SortByEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SortBy { get; set; } = "CODE";

		/// <summary>
		/// <para>Sort Order</para>
		/// <para>Specifies the direction the records will be sorted.</para>
		/// <para>Ascending—Records are sorted from low value to high value.</para>
		/// <para>Descending—Records are sorted from high value to low value.</para>
		/// <para><see cref="SortOrderEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SortOrder { get; set; } = "ASCENDING";

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SortCodedValueDomain SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Sort By</para>
		/// </summary>
		public enum SortByEnum 
		{
			/// <summary>
			/// <para>Code—Records are sorted based on the code value for the domain.</para>
			/// </summary>
			[GPValue("CODE")]
			[Description("Code")]
			Code,

			/// <summary>
			/// <para>Description—Records are sorted based on the description value for the domain.</para>
			/// </summary>
			[GPValue("DESCRIPTION")]
			[Description("Description")]
			Description,

		}

		/// <summary>
		/// <para>Sort Order</para>
		/// </summary>
		public enum SortOrderEnum 
		{
			/// <summary>
			/// <para>Ascending—Records are sorted from low value to high value.</para>
			/// </summary>
			[GPValue("ASCENDING")]
			[Description("Ascending")]
			Ascending,

			/// <summary>
			/// <para>Descending—Records are sorted from high value to low value.</para>
			/// </summary>
			[GPValue("DESCENDING")]
			[Description("Descending")]
			Descending,

		}

#endregion
	}
}
