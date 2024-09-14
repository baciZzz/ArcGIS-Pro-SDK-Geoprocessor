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
	/// <para>Add Rule To Relationship Class</para>
	/// <para>将规则添加到关系类</para>
	/// <para>将规则添加到关系类。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddRuleToRelationshipClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRelClass">
		/// <para>Input Relationship Class</para>
		/// <para>要添加规则的关系类。</para>
		/// </param>
		public AddRuleToRelationshipClass(object InRelClass)
		{
			this.InRelClass = InRelClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 将规则添加到关系类</para>
		/// </summary>
		public override string DisplayName() => "将规则添加到关系类";

		/// <summary>
		/// <para>Tool Name : AddRuleToRelationshipClass</para>
		/// </summary>
		public override string ToolName() => "AddRuleToRelationshipClass";

		/// <summary>
		/// <para>Tool Excute Name : management.AddRuleToRelationshipClass</para>
		/// </summary>
		public override string ExcuteName() => "management.AddRuleToRelationshipClass";

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
		public override object[] Parameters() => new object[] { InRelClass, OriginSubtype!, OriginMinimum!, OriginMaximum!, DestinationSubtype!, DestinationMinimum!, DestinationMaximum!, OutRelClass! };

		/// <summary>
		/// <para>Input Relationship Class</para>
		/// <para>要添加规则的关系类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERelationshipClass()]
		public object InRelClass { get; set; }

		/// <summary>
		/// <para>Origin Subtype</para>
		/// <para>指定源类的子类型。如果源类具有子类型，则选择要与关系规则进行关联的子类型。如果源类没有子类型，则关系规则会应用到所有要素中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OriginSubtype { get; set; }

		/// <summary>
		/// <para>Origin Minimum</para>
		/// <para>如果关系类为多对多，则需指定源类的最小范围基数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? OriginMinimum { get; set; }

		/// <summary>
		/// <para>Origin Maximum</para>
		/// <para>如果关系类为多对多或一对多，则需指定源类的最大范围基数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? OriginMaximum { get; set; }

		/// <summary>
		/// <para>Destination Subtype</para>
		/// <para>指定目标类的子类型。如果目标类具有子类型，则选择要与关系规则进行关联的子类型。如果目标类没有子类型，则关系规则会应用到所有要素中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DestinationSubtype { get; set; }

		/// <summary>
		/// <para>Destination Minimum</para>
		/// <para>如果关系类为多对多或一对多，则需指定目标类的最小范围基数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? DestinationMinimum { get; set; }

		/// <summary>
		/// <para>Destination Maximum</para>
		/// <para>如果关系类为多对多或一对多，则需指定目标类的最大范围基数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? DestinationMaximum { get; set; }

		/// <summary>
		/// <para>Updated Relationship Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERelationshipClass()]
		public object? OutRelClass { get; set; }

	}
}
