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
	/// <para>Set Feature Class Split Model</para>
	/// <para>Set Feature Class Split Model</para>
	/// <para>Defines the behavior of a split operation on a feature class.</para>
	/// </summary>
	public class SetFeatureClassSplitModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>The feature class on which the split model will be set.</para>
		/// </param>
		public SetFeatureClassSplitModel(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Feature Class Split Model</para>
		/// </summary>
		public override string DisplayName() => "Set Feature Class Split Model";

		/// <summary>
		/// <para>Tool Name : SetFeatureClassSplitModel</para>
		/// </summary>
		public override string ToolName() => "SetFeatureClassSplitModel";

		/// <summary>
		/// <para>Tool Excute Name : management.SetFeatureClassSplitModel</para>
		/// </summary>
		public override string ExcuteName() => "management.SetFeatureClassSplitModel";

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
		public override object[] Parameters() => new object[] { InFeatureClass, SplitModel, OutFeatureClass };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The feature class on which the split model will be set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline")]
		[FeatureType("Simple")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Split Model</para>
		/// <para>Specifies the split model to apply to the input feature class.</para>
		/// <para>Delete/Insert/Insert—The original feature will be deleted, and both parts of the split feature will be inserted as new features with two new rows in the table.</para>
		/// <para>Update/Insert—The original feature will be updated, becoming the largest feature, and the smaller feature will be inserted as a new row in the table. This is the default.</para>
		/// <para><see cref="SplitModelEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SplitModel { get; set; } = "UPDATE_INSERT";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutFeatureClass { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Split Model</para>
		/// </summary>
		public enum SplitModelEnum 
		{
			/// <summary>
			/// <para>Delete/Insert/Insert—The original feature will be deleted, and both parts of the split feature will be inserted as new features with two new rows in the table.</para>
			/// </summary>
			[GPValue("DELETE_INSERT_INSERT")]
			[Description("Delete/Insert/Insert")]
			DELETE_INSERT_INSERT,

			/// <summary>
			/// <para>Update/Insert—The original feature will be updated, becoming the largest feature, and the smaller feature will be inserted as a new row in the table. This is the default.</para>
			/// </summary>
			[GPValue("UPDATE_INSERT")]
			[Description("Update/Insert")]
			UPDATE_INSERT,

		}

#endregion
	}
}
