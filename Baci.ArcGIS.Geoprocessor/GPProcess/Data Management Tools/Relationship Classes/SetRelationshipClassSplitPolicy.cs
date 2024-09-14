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
	/// <para>Set Relationship Class Split Policy</para>
	/// <para>设置关系类分割策略</para>
	/// <para>用于定义相关要素的分割策略。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class SetRelationshipClassSplitPolicy : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRelClass">
		/// <para>Input Relationship Class</para>
		/// <para>将在其上设置分割策略的关系类。原始要素类必须为折线或面要素类，而目标必须为非空间表。</para>
		/// </param>
		/// <param name="SplitPolicy">
		/// <para>Split Policy</para>
		/// <para>指定要应用于关系类的分割策略。</para>
		/// <para>默认（复合）— 如果要素类分割模型为“删除/插入/插入”，则将删除关系和部件对象。如果要素类分割模型为“更新/插入”，则将保留最大生成要素上的关系。这是复合关系类的默认分割策略。</para>
		/// <para>默认（简单）— 将保留最大生成要素上的关系。这是简单关系类的默认分割策略。</para>
		/// <para>复制相关对象—将生成相关对象的副本并将其分配给生成的两个部件。关系类必须基于全局 ID，才能使用此分割策略。</para>
		/// <para><see cref="SplitPolicyEnum"/></para>
		/// </param>
		public SetRelationshipClassSplitPolicy(object InRelClass, object SplitPolicy)
		{
			this.InRelClass = InRelClass;
			this.SplitPolicy = SplitPolicy;
		}

		/// <summary>
		/// <para>Tool Display Name : 设置关系类分割策略</para>
		/// </summary>
		public override string DisplayName() => "设置关系类分割策略";

		/// <summary>
		/// <para>Tool Name : SetRelationshipClassSplitPolicy</para>
		/// </summary>
		public override string ToolName() => "SetRelationshipClassSplitPolicy";

		/// <summary>
		/// <para>Tool Excute Name : management.SetRelationshipClassSplitPolicy</para>
		/// </summary>
		public override string ExcuteName() => "management.SetRelationshipClassSplitPolicy";

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
		public override object[] Parameters() => new object[] { InRelClass, SplitPolicy, OutRelClass! };

		/// <summary>
		/// <para>Input Relationship Class</para>
		/// <para>将在其上设置分割策略的关系类。原始要素类必须为折线或面要素类，而目标必须为非空间表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERelationshipClass()]
		public object InRelClass { get; set; }

		/// <summary>
		/// <para>Split Policy</para>
		/// <para>指定要应用于关系类的分割策略。</para>
		/// <para>默认（复合）— 如果要素类分割模型为“删除/插入/插入”，则将删除关系和部件对象。如果要素类分割模型为“更新/插入”，则将保留最大生成要素上的关系。这是复合关系类的默认分割策略。</para>
		/// <para>默认（简单）— 将保留最大生成要素上的关系。这是简单关系类的默认分割策略。</para>
		/// <para>复制相关对象—将生成相关对象的副本并将其分配给生成的两个部件。关系类必须基于全局 ID，才能使用此分割策略。</para>
		/// <para><see cref="SplitPolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SplitPolicy { get; set; }

		/// <summary>
		/// <para>Output Relationship Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERelationshipClass()]
		public object? OutRelClass { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Split Policy</para>
		/// </summary>
		public enum SplitPolicyEnum 
		{
			/// <summary>
			/// <para>复制相关对象—将生成相关对象的副本并将其分配给生成的两个部件。关系类必须基于全局 ID，才能使用此分割策略。</para>
			/// </summary>
			[GPValue("DUPLICATE_RELATED_OBJECTS")]
			[Description("复制相关对象")]
			Duplicate_related_objects,

			/// <summary>
			/// <para>默认（简单）— 将保留最大生成要素上的关系。这是简单关系类的默认分割策略。</para>
			/// </summary>
			[GPValue("DEFAULT_SIMPLE")]
			[Description("默认（简单）")]
			DEFAULT_SIMPLE,

			/// <summary>
			/// <para>默认（复合）— 如果要素类分割模型为“删除/插入/插入”，则将删除关系和部件对象。如果要素类分割模型为“更新/插入”，则将保留最大生成要素上的关系。这是复合关系类的默认分割策略。</para>
			/// </summary>
			[GPValue("DEFAULT_COMPOSITE")]
			[Description("默认（复合）")]
			DEFAULT_COMPOSITE,

		}

#endregion
	}
}
