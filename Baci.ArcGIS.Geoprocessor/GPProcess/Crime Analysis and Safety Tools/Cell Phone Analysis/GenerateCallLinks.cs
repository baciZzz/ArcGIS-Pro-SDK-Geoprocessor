using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CrimeAnalysisandSafetyTools
{
	/// <summary>
	/// <para>Generate Call Links</para>
	/// <para>Creates line features that represent the call links between phones, using cell site points or cell site antenna sectors, based on the start date and time of the call.</para>
	/// </summary>
	public class GenerateCallLinks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPrimaryFeatures">
		/// <para>Input Primary Phone Record Site Points or Sectors</para>
		/// <para>The point feature class for the primary phone or sector derived from the Cell Phone Records To Feature Class tool.</para>
		/// </param>
		/// <param name="InSecondaryFeatures">
		/// <para>Input Secondary Phone Record Site Points or Sectors</para>
		/// <para>The point feature class for the secondary phone or sector derived from the Cell Phone Records To Feature Class tool.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Call Link Lines</para>
		/// <para>The output line features representing the call links between two phones at various locations.</para>
		/// </param>
		public GenerateCallLinks(object InPrimaryFeatures, object InSecondaryFeatures, object OutFeatureClass)
		{
			this.InPrimaryFeatures = InPrimaryFeatures;
			this.InSecondaryFeatures = InSecondaryFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Call Links</para>
		/// </summary>
		public override string DisplayName => "Generate Call Links";

		/// <summary>
		/// <para>Tool Name : GenerateCallLinks</para>
		/// </summary>
		public override string ToolName => "GenerateCallLinks";

		/// <summary>
		/// <para>Tool Excute Name : ca.GenerateCallLinks</para>
		/// </summary>
		public override string ExcuteName => "ca.GenerateCallLinks";

		/// <summary>
		/// <para>Toolbox Display Name : Crime Analysis and Safety Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Crime Analysis and Safety Tools";

		/// <summary>
		/// <para>Toolbox Alise : ca</para>
		/// </summary>
		public override string ToolboxAlise => "ca";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "maintainAttachments", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InPrimaryFeatures, InSecondaryFeatures, OutFeatureClass, OutputType, PrimarySubscriberField, PrimaryDestinationField, PrimaryStartTimeField, SecondarySubscriberField, SecondaryDestinationField, SecondaryStartTimeField };

		/// <summary>
		/// <para>Input Primary Phone Record Site Points or Sectors</para>
		/// <para>The point feature class for the primary phone or sector derived from the Cell Phone Records To Feature Class tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object InPrimaryFeatures { get; set; }

		/// <summary>
		/// <para>Input Secondary Phone Record Site Points or Sectors</para>
		/// <para>The point feature class for the secondary phone or sector derived from the Cell Phone Records To Feature Class tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object InSecondaryFeatures { get; set; }

		/// <summary>
		/// <para>Output Call Link Lines</para>
		/// <para>The output line features representing the call links between two phones at various locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Type</para>
		/// <para>Specifies how the relationship of calls between two phones will be analyzed and symbolized.</para>
		/// <para>Summary—A summary record of the total number of calls between two phones at various locations will be created. This is the default.</para>
		/// <para>Detail—An individual record of each call between two phones at various locations will be created.</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputType { get; set; } = "SUMMARY";

		/// <summary>
		/// <para>Primary Phone Subscriber ID Field</para>
		/// <para>The unique ID field for the primary phone subscriber, usually a phone number.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object PrimarySubscriberField { get; set; }

		/// <summary>
		/// <para>Primary Phone Call Destination Field</para>
		/// <para>The field containing the phone number of the secondary phone.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object PrimaryDestinationField { get; set; }

		/// <summary>
		/// <para>Primary Phone Call Start Date and Time Field</para>
		/// <para>The start date and time field of the primary phone records.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object PrimaryStartTimeField { get; set; }

		/// <summary>
		/// <para>Secondary Phone Subscriber ID Field</para>
		/// <para>The unique ID field for the secondary phone subscriber, usually a phone number.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object SecondarySubscriberField { get; set; }

		/// <summary>
		/// <para>Secondary Phone Destination Field</para>
		/// <para>The field containing the phone number of the primary phone.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object SecondaryDestinationField { get; set; }

		/// <summary>
		/// <para>Secondary Phone Call Start Date and Time Field</para>
		/// <para>The start date and time field of the secondary phone records.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object SecondaryStartTimeField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateCallLinks SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , bool? qualifiedFieldNames = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>Summary—A summary record of the total number of calls between two phones at various locations will be created. This is the default.</para>
			/// </summary>
			[GPValue("SUMMARY")]
			[Description("Summary")]
			Summary,

			/// <summary>
			/// <para>Detail—An individual record of each call between two phones at various locations will be created.</para>
			/// </summary>
			[GPValue("DETAIL")]
			[Description("Detail")]
			Detail,

		}

#endregion
	}
}
