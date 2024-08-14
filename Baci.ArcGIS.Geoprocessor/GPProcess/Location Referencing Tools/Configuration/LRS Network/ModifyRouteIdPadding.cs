using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Modify Route ID Padding</para>
	/// <para>Modifies the padding, null, and length properties for fields that are part of a multifield route ID.</para>
	/// </summary>
	public class ModifyRouteIdPadding : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>LRS Network Feature Class</para>
		/// <para>The input multifield route ID network layer that contains fields for padding, null, and length values that need to be modified.</para>
		/// </param>
		/// <param name="RouteIdPadding">
		/// <para>Route ID Padding</para>
		/// <para>A table of values that specifies the field to be modified and its corresponding padding, null, and length values.</para>
		/// <para>Field—The field to be modified.</para>
		/// <para>Length—The length value of the field to be modified. The field length should be between 1 and the length of the database field.</para>
		/// <para>Variable Length—Specifies if the Length value is a variable value or a fixed value.</para>
		/// <para>Enable Padding—Specifies if the field supports padding.</para>
		/// <para>Padding Character—The padding character for the field. The default is a space.</para>
		/// <para>Padding Location—Specifies where the padding should be applied to the field value.</para>
		/// <para>Left—Adds the padding characters to the left of the value in the field. This is the default.</para>
		/// <para>Right—Adds the padding characters to the right of the value in the field.</para>
		/// <para>Left and Right—Adds the padding characters to the left and right of the value in the field.</para>
		/// <para>Pad if Null—Specifies if the padding characters are added when the field has a null value.</para>
		/// <para>Allow Null Values—Specifies if the field supports null values.</para>
		/// </param>
		public ModifyRouteIdPadding(object InFeatureClass, object RouteIdPadding)
		{
			this.InFeatureClass = InFeatureClass;
			this.RouteIdPadding = RouteIdPadding;
		}

		/// <summary>
		/// <para>Tool Display Name : Modify Route ID Padding</para>
		/// </summary>
		public override string DisplayName => "Modify Route ID Padding";

		/// <summary>
		/// <para>Tool Name : ModifyRouteIdPadding</para>
		/// </summary>
		public override string ToolName => "ModifyRouteIdPadding";

		/// <summary>
		/// <para>Tool Excute Name : locref.ModifyRouteIdPadding</para>
		/// </summary>
		public override string ExcuteName => "locref.ModifyRouteIdPadding";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatureClass, RouteIdPadding, OutFeatureClass };

		/// <summary>
		/// <para>LRS Network Feature Class</para>
		/// <para>The input multifield route ID network layer that contains fields for padding, null, and length values that need to be modified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Route ID Padding</para>
		/// <para>A table of values that specifies the field to be modified and its corresponding padding, null, and length values.</para>
		/// <para>Field—The field to be modified.</para>
		/// <para>Length—The length value of the field to be modified. The field length should be between 1 and the length of the database field.</para>
		/// <para>Variable Length—Specifies if the Length value is a variable value or a fixed value.</para>
		/// <para>Enable Padding—Specifies if the field supports padding.</para>
		/// <para>Padding Character—The padding character for the field. The default is a space.</para>
		/// <para>Padding Location—Specifies where the padding should be applied to the field value.</para>
		/// <para>Left—Adds the padding characters to the left of the value in the field. This is the default.</para>
		/// <para>Right—Adds the padding characters to the right of the value in the field.</para>
		/// <para>Left and Right—Adds the padding characters to the left and right of the value in the field.</para>
		/// <para>Pad if Null—Specifies if the padding characters are added when the field has a null value.</para>
		/// <para>Allow Null Values—Specifies if the field supports null values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object RouteIdPadding { get; set; }

		/// <summary>
		/// <para>Output Network Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ModifyRouteIdPadding SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
