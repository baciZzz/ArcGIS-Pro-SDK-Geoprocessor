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
	/// <para>Remove Rule From Relationship Class</para>
	/// <para>从关系类中移除规则</para>
	/// <para>从关系类中移除规则。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RemoveRuleFromRelationshipClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRelClass">
		/// <para>Input Relationship Class</para>
		/// <para>移除规则的关系类</para>
		/// </param>
		public RemoveRuleFromRelationshipClass(object InRelClass)
		{
			this.InRelClass = InRelClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 从关系类中移除规则</para>
		/// </summary>
		public override string DisplayName() => "从关系类中移除规则";

		/// <summary>
		/// <para>Tool Name : RemoveRuleFromRelationshipClass</para>
		/// </summary>
		public override string ToolName() => "RemoveRuleFromRelationshipClass";

		/// <summary>
		/// <para>Tool Excute Name : management.RemoveRuleFromRelationshipClass</para>
		/// </summary>
		public override string ExcuteName() => "management.RemoveRuleFromRelationshipClass";

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
		public override object[] Parameters() => new object[] { InRelClass, OriginSubtype!, DestinationSubtype!, RemoveAll!, OutRelClass! };

		/// <summary>
		/// <para>Input Relationship Class</para>
		/// <para>移除规则的关系类</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERelationshipClass()]
		public object InRelClass { get; set; }

		/// <summary>
		/// <para>Origin Subtype</para>
		/// <para>如果源类具有子类型，则需要删除与关系类规则相关联的子类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OriginSubtype { get; set; }

		/// <summary>
		/// <para>Destination Subtype</para>
		/// <para>如果目标类具有子类型，则需要删除与关系类规则相关联的子类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DestinationSubtype { get; set; }

		/// <summary>
		/// <para>Remove All</para>
		/// <para>指定要从关系类中移除的关系规则。</para>
		/// <para>选中 - 所有关系规则都将被从输入关系类中移除。</para>
		/// <para>未选中 - 仅移除指定的源子类型和目标子类型的规则。这是默认设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		public object? RemoveAll { get; set; }

		/// <summary>
		/// <para>Updated Relationship Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERelationshipClass()]
		public object? OutRelClass { get; set; }

	}
}
