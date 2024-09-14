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
	/// <para>排序编码值属性域</para>
	/// <para>以升序或降序方式排列编码值属性域的编码或描述。</para>
	/// </summary>
	public class SortCodedValueDomain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>包含要排序的属性域的地理数据库。</para>
		/// </param>
		/// <param name="DomainName">
		/// <para>Domain Name</para>
		/// <para>要排序的编码值属性域的名称。</para>
		/// </param>
		/// <param name="SortBy">
		/// <para>Sort By</para>
		/// <para>指定是使用编码还是描述排序属性域。</para>
		/// <para>代码—根据属性域的编码值对记录进行排序。</para>
		/// <para>描述—根据属性域的描述值对记录进行排序。</para>
		/// <para><see cref="SortByEnum"/></para>
		/// </param>
		/// <param name="SortOrder">
		/// <para>Sort Order</para>
		/// <para>指定记录排序方向。</para>
		/// <para>升序—按照值从低到高的顺序对记录进行排序。</para>
		/// <para>降序—按照值从高到低的顺序对记录进行排序。</para>
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
		/// <para>Tool Display Name : 排序编码值属性域</para>
		/// </summary>
		public override string DisplayName() => "排序编码值属性域";

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
		public override object[] Parameters() => new object[] { InWorkspace, DomainName, SortBy, SortOrder, OutWorkspace! };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>包含要排序的属性域的地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Domain Name</para>
		/// <para>要排序的编码值属性域的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainName { get; set; }

		/// <summary>
		/// <para>Sort By</para>
		/// <para>指定是使用编码还是描述排序属性域。</para>
		/// <para>代码—根据属性域的编码值对记录进行排序。</para>
		/// <para>描述—根据属性域的描述值对记录进行排序。</para>
		/// <para><see cref="SortByEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SortBy { get; set; } = "CODE";

		/// <summary>
		/// <para>Sort Order</para>
		/// <para>指定记录排序方向。</para>
		/// <para>升序—按照值从低到高的顺序对记录进行排序。</para>
		/// <para>降序—按照值从高到低的顺序对记录进行排序。</para>
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
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SortCodedValueDomain SetEnviroment(object? workspace = null)
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
			/// <para>代码—根据属性域的编码值对记录进行排序。</para>
			/// </summary>
			[GPValue("CODE")]
			[Description("代码")]
			Code,

			/// <summary>
			/// <para>描述—根据属性域的描述值对记录进行排序。</para>
			/// </summary>
			[GPValue("DESCRIPTION")]
			[Description("描述")]
			Description,

		}

		/// <summary>
		/// <para>Sort Order</para>
		/// </summary>
		public enum SortOrderEnum 
		{
			/// <summary>
			/// <para>升序—按照值从低到高的顺序对记录进行排序。</para>
			/// </summary>
			[GPValue("ASCENDING")]
			[Description("升序")]
			Ascending,

			/// <summary>
			/// <para>降序—按照值从高到低的顺序对记录进行排序。</para>
			/// </summary>
			[GPValue("DESCENDING")]
			[Description("降序")]
			Descending,

		}

#endregion
	}
}
