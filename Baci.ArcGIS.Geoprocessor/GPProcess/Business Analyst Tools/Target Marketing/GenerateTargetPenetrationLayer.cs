using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.BusinessAnalystTools
{
	/// <summary>
	/// <para>Generate Target Penetration Layer</para>
	/// <para>Generates a layer based on the percent of penetration of selected segments, providing a detailed view of the concentrations of your target segments.</para>
	/// </summary>
	public class GenerateTargetPenetrationLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="GeographyLevel">
		/// <para>Geography Level</para>
		/// <para>The geography level that will be used to define the target layer.</para>
		/// </param>
		/// <param name="SegmentationBase">
		/// <para>Segmentation Base</para>
		/// <para>The segmentation base for the profile being created. Available options are provided by the segmentation dataset in use.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class for the target layer.</para>
		/// </param>
		/// <param name="InputType">
		/// <para>Target Input Type</para>
		/// <para>The geographic layer containing the segmentation data or the target group.</para>
		/// <para>Use Target Group—A target group will be used as the input type.</para>
		/// <para>Select Segments—Selected segments will be used as the input type. One or more segments can compose a target. This is the default.</para>
		/// <para><see cref="InputTypeEnum"/></para>
		/// </param>
		public GenerateTargetPenetrationLayer(object GeographyLevel, object SegmentationBase, object OutFeatureClass, object InputType)
		{
			this.GeographyLevel = GeographyLevel;
			this.SegmentationBase = SegmentationBase;
			this.OutFeatureClass = OutFeatureClass;
			this.InputType = InputType;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Target Penetration Layer</para>
		/// </summary>
		public override string DisplayName() => "Generate Target Penetration Layer";

		/// <summary>
		/// <para>Tool Name : GenerateTargetPenetrationLayer</para>
		/// </summary>
		public override string ToolName() => "GenerateTargetPenetrationLayer";

		/// <summary>
		/// <para>Tool Excute Name : ba.GenerateTargetPenetrationLayer</para>
		/// </summary>
		public override string ExcuteName() => "ba.GenerateTargetPenetrationLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise() => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "baDataSource", "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { GeographyLevel, SegmentationBase, OutFeatureClass, InputType, TargetGroup, Target, Segments, BoundaryLayer };

		/// <summary>
		/// <para>Geography Level</para>
		/// <para>The geography level that will be used to define the target layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object GeographyLevel { get; set; }

		/// <summary>
		/// <para>Segmentation Base</para>
		/// <para>The segmentation base for the profile being created. Available options are provided by the segmentation dataset in use.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SegmentationBase { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class for the target layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Target Input Type</para>
		/// <para>The geographic layer containing the segmentation data or the target group.</para>
		/// <para>Use Target Group—A target group will be used as the input type.</para>
		/// <para>Select Segments—Selected segments will be used as the input type. One or more segments can compose a target. This is the default.</para>
		/// <para><see cref="InputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InputType { get; set; } = "SELECT_SEGMENTS";

		/// <summary>
		/// <para>Target Group</para>
		/// <para>A user-created group of targets. This parameter is used when the dataset supports target groups.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sgtargetgroup")]
		public object TargetGroup { get; set; }

		/// <summary>
		/// <para>Target</para>
		/// <para>A target from the selected Target Group.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Target { get; set; }

		/// <summary>
		/// <para>Segments</para>
		/// <para>Segments from the provided dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Segments { get; set; }

		/// <summary>
		/// <para>Boundary Layer</para>
		/// <para>The boundary that determines the extent of the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object BoundaryLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateTargetPenetrationLayer SetEnviroment(object extent = null , object workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Target Input Type</para>
		/// </summary>
		public enum InputTypeEnum 
		{
			/// <summary>
			/// <para>Use Target Group—A target group will be used as the input type.</para>
			/// </summary>
			[GPValue("USE_TARGET_GROUP")]
			[Description("Use Target Group")]
			Use_Target_Group,

			/// <summary>
			/// <para>Select Segments—Selected segments will be used as the input type. One or more segments can compose a target. This is the default.</para>
			/// </summary>
			[GPValue("SELECT_SEGMENTS")]
			[Description("Select Segments")]
			Select_Segments,

		}

#endregion
	}
}
