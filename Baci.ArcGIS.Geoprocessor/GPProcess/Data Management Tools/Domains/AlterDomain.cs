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
	/// <para>Alter Domain</para>
	/// <para>更改属性域</para>
	/// <para>更改工作空间中现有属性域的属性。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AlterDomain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>包含要更改的属性域的地理数据库。</para>
		/// </param>
		/// <param name="DomainName">
		/// <para>Domain Name</para>
		/// <para>要更改的属性域的名称。</para>
		/// </param>
		public AlterDomain(object InWorkspace, object DomainName)
		{
			this.InWorkspace = InWorkspace;
			this.DomainName = DomainName;
		}

		/// <summary>
		/// <para>Tool Display Name : 更改属性域</para>
		/// </summary>
		public override string DisplayName() => "更改属性域";

		/// <summary>
		/// <para>Tool Name : AlterDomain</para>
		/// </summary>
		public override string ToolName() => "AlterDomain";

		/// <summary>
		/// <para>Tool Excute Name : management.AlterDomain</para>
		/// </summary>
		public override string ExcuteName() => "management.AlterDomain";

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
		public override object[] Parameters() => new object[] { InWorkspace, DomainName, NewDomainName, NewDomainDescription, SplitPolicy, MergePolicy, OutWorkspace };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>包含要更改的属性域的地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Domain Name</para>
		/// <para>要更改的属性域的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainName { get; set; }

		/// <summary>
		/// <para>New Domain Name</para>
		/// <para>属性域的新名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object NewDomainName { get; set; }

		/// <summary>
		/// <para>New Domain Description</para>
		/// <para>属性域的新描述。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object NewDomainDescription { get; set; }

		/// <summary>
		/// <para>New Split Policy</para>
		/// <para>属性域的分割策略。分割要素时，属性值的行为受控于它的分割策略。</para>
		/// <para>使用属性的默认值—两个所生成要素的属性使用给定要素类或子类型的默认属性值。</para>
		/// <para>复制属性值—两个所生成要素的属性使用原始对象的属性值副本。</para>
		/// <para>使用几何比—两个所生成要素的属性是原始要素值的比率。该比率取决于原始几何的分割比例。如果几何被分割成相等的两部分，则每个新要素的属性值将是原始对象属性值的一半。几何比策略仅适用于范围属性域。</para>
		/// <para><see cref="SplitPolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SplitPolicy { get; set; } = "DEFAULT";

		/// <summary>
		/// <para>New Merge Policy</para>
		/// <para>属性域的合并策略。在将两个要素合并为一个要素时，合并策略控制着新要素的属性值。由于编码值属性域可能仅使用默认合并策略，因此对此属性的更改仅会应用到范围属性域。</para>
		/// <para>使用属性的默认值—所生成要素的属性使用给定要素类或子类型的默认属性值。这是唯一适用于非数字字段和编码值属性域的合并策略。</para>
		/// <para>值的总和—所生成要素的属性使用原始要素属性值的总和。总和值策略仅适用于范围属性域。</para>
		/// <para>面积加权平均值—所生成要素的属性使用原始要素属性值的加权平均值。此平均值取决于原始要素的几何。加权面积策略仅适用于范围属性域。</para>
		/// <para><see cref="MergePolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MergePolicy { get; set; } = "DEFAULT";

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AlterDomain SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>New Split Policy</para>
		/// </summary>
		public enum SplitPolicyEnum 
		{
			/// <summary>
			/// <para>使用属性的默认值—两个所生成要素的属性使用给定要素类或子类型的默认属性值。</para>
			/// </summary>
			[GPValue("DEFAULT")]
			[Description("使用属性的默认值")]
			DEFAULT,

			/// <summary>
			/// <para>复制属性值—两个所生成要素的属性使用原始对象的属性值副本。</para>
			/// </summary>
			[GPValue("DUPLICATE")]
			[Description("复制属性值")]
			Duplicate_attribute_values,

			/// <summary>
			/// <para>使用几何比—两个所生成要素的属性是原始要素值的比率。该比率取决于原始几何的分割比例。如果几何被分割成相等的两部分，则每个新要素的属性值将是原始对象属性值的一半。几何比策略仅适用于范围属性域。</para>
			/// </summary>
			[GPValue("GEOMETRY_RATIO")]
			[Description("使用几何比")]
			Use_geometric_ratio,

		}

		/// <summary>
		/// <para>New Merge Policy</para>
		/// </summary>
		public enum MergePolicyEnum 
		{
			/// <summary>
			/// <para>使用属性的默认值—所生成要素的属性使用给定要素类或子类型的默认属性值。这是唯一适用于非数字字段和编码值属性域的合并策略。</para>
			/// </summary>
			[GPValue("DEFAULT")]
			[Description("使用属性的默认值")]
			DEFAULT,

			/// <summary>
			/// <para>值的总和—所生成要素的属性使用原始要素属性值的总和。总和值策略仅适用于范围属性域。</para>
			/// </summary>
			[GPValue("SUM_VALUES")]
			[Description("值的总和")]
			Sum_of_the_values,

			/// <summary>
			/// <para>面积加权平均值—所生成要素的属性使用原始要素属性值的加权平均值。此平均值取决于原始要素的几何。加权面积策略仅适用于范围属性域。</para>
			/// </summary>
			[GPValue("AREA_WEIGHTED")]
			[Description("面积加权平均值")]
			Area_weighted_average,

		}

#endregion
	}
}
