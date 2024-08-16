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
	/// <para>Append Annotation Feature Classes</para>
	/// <para>Creates a geodatabase annotation feature class or appends to an existing annotation feature class by combining annotation from multiple input geodatabase annotation feature classes into a single feature class with annotation classes.</para>
	/// </summary>
	public class AppendAnnotation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input features</para>
		/// <para>The input annotation features that will form an annotation class in the output feature class.</para>
		/// </param>
		/// <param name="OutputFeatureclass">
		/// <para>Output feature class</para>
		/// <para>A new annotation feature class that will contain an annotation class for each input annotation feature class.</para>
		/// </param>
		/// <param name="ReferenceScale">
		/// <para>Reference scale</para>
		/// <para>The reference scale set in the output feature class. Input features created at a different reference scale will be transformed to match this output reference scale.</para>
		/// </param>
		public AppendAnnotation(object InputFeatures, object OutputFeatureclass, object ReferenceScale)
		{
			this.InputFeatures = InputFeatures;
			this.OutputFeatureclass = OutputFeatureclass;
			this.ReferenceScale = ReferenceScale;
		}

		/// <summary>
		/// <para>Tool Display Name : Append Annotation Feature Classes</para>
		/// </summary>
		public override string DisplayName => "Append Annotation Feature Classes";

		/// <summary>
		/// <para>Tool Name : AppendAnnotation</para>
		/// </summary>
		public override string ToolName => "AppendAnnotation";

		/// <summary>
		/// <para>Tool Excute Name : management.AppendAnnotation</para>
		/// </summary>
		public override string ExcuteName => "management.AppendAnnotation";

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
		public override string[] ValidEnvironments => new string[] { "autoCommit", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputFeatures, OutputFeatureclass, ReferenceScale, CreateSingleClass, RequireSymbolFromTable, CreateAnnotationWhenFeatureAdded, UpdateAnnotationWhenFeatureModified };

		/// <summary>
		/// <para>Input features</para>
		/// <para>The input annotation features that will form an annotation class in the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[FeatureType("Annotation")]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Output feature class</para>
		/// <para>A new annotation feature class that will contain an annotation class for each input annotation feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureclass { get; set; }

		/// <summary>
		/// <para>Reference scale</para>
		/// <para>The reference scale set in the output feature class. Input features created at a different reference scale will be transformed to match this output reference scale.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object ReferenceScale { get; set; }

		/// <summary>
		/// <para>Create a single annotation class</para>
		/// <para>Specifies how annotation features will be added to the output feature class.</para>
		/// <para>Checked—All annotation features will be aggregated into one annotation class in the output feature class.</para>
		/// <para>Unchecked—Separate annotation classes will be created for each input annotation class in the output feature class unless the classes are named the same and have the same properties. In this case, they will be merged. This is the default.</para>
		/// <para><see cref="CreateSingleClassEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CreateSingleClass { get; set; } = "false";

		/// <summary>
		/// <para>Require symbols to be selected from the symbol table</para>
		/// <para>Specifies how symbols can be selected for newly created annotation features.</para>
		/// <para>Checked—Restricts the creation of annotation features to the list of symbols in the symbol collection of the output feature class.</para>
		/// <para>Unchecked—Allows annotation features to be created with any symbology. This is the default.</para>
		/// <para><see cref="RequireSymbolFromTableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RequireSymbolFromTable { get; set; } = "false";

		/// <summary>
		/// <para>Create annotation when new features are added (Feature-linked only)</para>
		/// <para>This parameter is only available with ArcGIS Desktop Standard and ArcGIS Desktop Advanced licenses.</para>
		/// <para>Specifies whether feature-linked annotation will be created when a feature is added.</para>
		/// <para>Checked—Feature-linked annotation will be created using the label engine when a linked feature is created. This is the default.</para>
		/// <para>Unchecked—Feature-linked annotation will not be created when a feature is created.</para>
		/// <para><see cref="CreateAnnotationWhenFeatureAddedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CreateAnnotationWhenFeatureAdded { get; set; } = "true";

		/// <summary>
		/// <para>Update annotation when the shape of the linked feature is modified (Feature-linked only)</para>
		/// <para>This parameter is only available with ArcGIS Desktop Standard and ArcGIS Desktop Advanced licenses.</para>
		/// <para>Specifies whether feature-linked annotation is updated when a linked feature changes.</para>
		/// <para>Checked—Feature-linked annotation will be updated using the label engine when a linked feature changes. This is the default.</para>
		/// <para>Unchecked—Feature-linked annotation will not be updated when a linked feature changes.</para>
		/// <para><see cref="UpdateAnnotationWhenFeatureModifiedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UpdateAnnotationWhenFeatureModified { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AppendAnnotation SetEnviroment(int? autoCommit = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Create a single annotation class</para>
		/// </summary>
		public enum CreateSingleClassEnum 
		{
			/// <summary>
			/// <para>Checked—All annotation features will be aggregated into one annotation class in the output feature class.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ONE_CLASS_ONLY")]
			ONE_CLASS_ONLY,

			/// <summary>
			/// <para>Unchecked—Separate annotation classes will be created for each input annotation class in the output feature class unless the classes are named the same and have the same properties. In this case, they will be merged. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("CREATE_CLASSES")]
			CREATE_CLASSES,

		}

		/// <summary>
		/// <para>Require symbols to be selected from the symbol table</para>
		/// </summary>
		public enum RequireSymbolFromTableEnum 
		{
			/// <summary>
			/// <para>Checked—Restricts the creation of annotation features to the list of symbols in the symbol collection of the output feature class.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REQUIRE_SYMBOL")]
			REQUIRE_SYMBOL,

			/// <summary>
			/// <para>Unchecked—Allows annotation features to be created with any symbology. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SYMBOL_REQUIRED")]
			NO_SYMBOL_REQUIRED,

		}

		/// <summary>
		/// <para>Create annotation when new features are added (Feature-linked only)</para>
		/// </summary>
		public enum CreateAnnotationWhenFeatureAddedEnum 
		{
			/// <summary>
			/// <para>Checked—Feature-linked annotation will be created using the label engine when a linked feature is created. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("AUTO_CREATE")]
			AUTO_CREATE,

			/// <summary>
			/// <para>Unchecked—Feature-linked annotation will not be created when a feature is created.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_AUTO_CREATE")]
			NO_AUTO_CREATE,

		}

		/// <summary>
		/// <para>Update annotation when the shape of the linked feature is modified (Feature-linked only)</para>
		/// </summary>
		public enum UpdateAnnotationWhenFeatureModifiedEnum 
		{
			/// <summary>
			/// <para>Checked—Feature-linked annotation will be updated using the label engine when a linked feature changes. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("AUTO_UPDATE")]
			AUTO_UPDATE,

			/// <summary>
			/// <para>Unchecked—Feature-linked annotation will not be updated when a linked feature changes.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_AUTO_UPDATE")]
			NO_AUTO_UPDATE,

		}

#endregion
	}
}
