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
	/// <para>Defines the split policy for related features.</para>
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
		/// <para>The relationship class on which the split policy will be set. The origin feature class must be a polyline or polygon feature class and the destination must be a nonspatial table.</para>
		/// </param>
		/// <param name="SplitPolicy">
		/// <para>Split Policy</para>
		/// <para>Specifies the split policy to apply to the relationship class.</para>
		/// <para>Default (composite)— If the feature class split model is Delete/Insert/Insert, the relationships and the part objects will be deleted. If the feature class split model is Update/Insert, the relationships on the largest resulting feature will be preserved. This is the default split policy for composite relationship classes.</para>
		/// <para>Default (simple)— The relationships on the largest resulting feature will be preserved. This is the default split policy for simple relationship classes.</para>
		/// <para>Duplicate related objects—Copies of the related objects will be generated and assigned to both resulting parts. The relationship class must be Global ID based to use this split policy.</para>
		/// <para><see cref="SplitPolicyEnum"/></para>
		/// </param>
		public SetRelationshipClassSplitPolicy(object InRelClass, object SplitPolicy)
		{
			this.InRelClass = InRelClass;
			this.SplitPolicy = SplitPolicy;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Relationship Class Split Policy</para>
		/// </summary>
		public override string DisplayName => "Set Relationship Class Split Policy";

		/// <summary>
		/// <para>Tool Name : SetRelationshipClassSplitPolicy</para>
		/// </summary>
		public override string ToolName => "SetRelationshipClassSplitPolicy";

		/// <summary>
		/// <para>Tool Excute Name : management.SetRelationshipClassSplitPolicy</para>
		/// </summary>
		public override string ExcuteName => "management.SetRelationshipClassSplitPolicy";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRelClass, SplitPolicy, OutRelClass! };

		/// <summary>
		/// <para>Input Relationship Class</para>
		/// <para>The relationship class on which the split policy will be set. The origin feature class must be a polyline or polygon feature class and the destination must be a nonspatial table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERelationshipClass()]
		public object InRelClass { get; set; }

		/// <summary>
		/// <para>Split Policy</para>
		/// <para>Specifies the split policy to apply to the relationship class.</para>
		/// <para>Default (composite)— If the feature class split model is Delete/Insert/Insert, the relationships and the part objects will be deleted. If the feature class split model is Update/Insert, the relationships on the largest resulting feature will be preserved. This is the default split policy for composite relationship classes.</para>
		/// <para>Default (simple)— The relationships on the largest resulting feature will be preserved. This is the default split policy for simple relationship classes.</para>
		/// <para>Duplicate related objects—Copies of the related objects will be generated and assigned to both resulting parts. The relationship class must be Global ID based to use this split policy.</para>
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
			/// <para>Duplicate related objects—Copies of the related objects will be generated and assigned to both resulting parts. The relationship class must be Global ID based to use this split policy.</para>
			/// </summary>
			[GPValue("DUPLICATE_RELATED_OBJECTS")]
			[Description("Duplicate related objects")]
			Duplicate_related_objects,

			/// <summary>
			/// <para>Default (simple)— The relationships on the largest resulting feature will be preserved. This is the default split policy for simple relationship classes.</para>
			/// </summary>
			[GPValue("DEFAULT_SIMPLE")]
			[Description("Default (simple)")]
			DEFAULT_SIMPLE,

			/// <summary>
			/// <para>Default (composite)— If the feature class split model is Delete/Insert/Insert, the relationships and the part objects will be deleted. If the feature class split model is Update/Insert, the relationships on the largest resulting feature will be preserved. This is the default split policy for composite relationship classes.</para>
			/// </summary>
			[GPValue("DEFAULT_COMPOSITE")]
			[Description("Default (composite)")]
			DEFAULT_COMPOSITE,

		}

#endregion
	}
}
