using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Contour Annotation</para>
	/// <para>Contour Annotation</para>
	/// <para>Creates annotation for contour features.</para>
	/// </summary>
	public class ContourAnnotation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The contour line feature class for which the annotation will be created.</para>
		/// </param>
		/// <param name="OutGeodatabase">
		/// <para>Output Geodatabase</para>
		/// <para>The workspace where the output feature classes will be saved. The workspace can be an existing geodatabase or an existing feature dataset.</para>
		/// </param>
		/// <param name="ContourLabelField">
		/// <para>Contour Label Field</para>
		/// <para>The field in the input layer attribute table on which the annotation text will be based.</para>
		/// </param>
		/// <param name="ReferenceScaleValue">
		/// <para>Reference Scale</para>
		/// <para>The scale that will be used as a reference for the annotation. This sets the scale on which all symbol and text sizes in the annotation will be based.</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Layer Name</para>
		/// <para>The group layer that will contain the contour layer, the annotation, and the mask layer. When working in the Catalog pane, you can use the Save To Layer File tool to write the output group layer to a layer file. When using ArcGIS Pro, the tool adds the group layer to the display if the Add output datasets to an open map option is checked on the Geoprocessing tab on the Options dialog box. The group layer that is created is temporary and will not persist after the session ends unless the document is saved.</para>
		/// </param>
		/// <param name="ContourColor">
		/// <para>Contour and Label Color</para>
		/// <para>Specifies the color of the output contour layer and annotation features.</para>
		/// <para>Black—The output contour layer and annotation features will be drawn in black. This is the default.</para>
		/// <para>Brown—The output contour layer and annotation features will be drawn in brown.</para>
		/// <para>Blue—The output contour layer and annotation features will be drawn in blue.</para>
		/// <para><see cref="ContourColorEnum"/></para>
		/// </param>
		public ContourAnnotation(object InFeatures, object OutGeodatabase, object ContourLabelField, object ReferenceScaleValue, object OutLayer, object ContourColor)
		{
			this.InFeatures = InFeatures;
			this.OutGeodatabase = OutGeodatabase;
			this.ContourLabelField = ContourLabelField;
			this.ReferenceScaleValue = ReferenceScaleValue;
			this.OutLayer = OutLayer;
			this.ContourColor = ContourColor;
		}

		/// <summary>
		/// <para>Tool Display Name : Contour Annotation</para>
		/// </summary>
		public override string DisplayName() => "Contour Annotation";

		/// <summary>
		/// <para>Tool Name : ContourAnnotation</para>
		/// </summary>
		public override string ToolName() => "ContourAnnotation";

		/// <summary>
		/// <para>Tool Excute Name : cartography.ContourAnnotation</para>
		/// </summary>
		public override string ExcuteName() => "cartography.ContourAnnotation";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise() => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "annotationTextStringFieldLength", "outputCoordinateSystem", "referenceScale" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutGeodatabase, ContourLabelField, ReferenceScaleValue, OutLayer, ContourColor, ContourTypeField!, ContourAlignment!, EnableLaddering!, OutGeodatabase2! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The contour line feature class for which the annotation will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// <para>The workspace where the output feature classes will be saved. The workspace can be an existing geodatabase or an existing feature dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutGeodatabase { get; set; }

		/// <summary>
		/// <para>Contour Label Field</para>
		/// <para>The field in the input layer attribute table on which the annotation text will be based.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object ContourLabelField { get; set; }

		/// <summary>
		/// <para>Reference Scale</para>
		/// <para>The scale that will be used as a reference for the annotation. This sets the scale on which all symbol and text sizes in the annotation will be based.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object ReferenceScaleValue { get; set; }

		/// <summary>
		/// <para>Output Layer Name</para>
		/// <para>The group layer that will contain the contour layer, the annotation, and the mask layer. When working in the Catalog pane, you can use the Save To Layer File tool to write the output group layer to a layer file. When using ArcGIS Pro, the tool adds the group layer to the display if the Add output datasets to an open map option is checked on the Geoprocessing tab on the Options dialog box. The group layer that is created is temporary and will not persist after the session ends unless the document is saved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGroupLayer()]
		public object OutLayer { get; set; } = "Contours";

		/// <summary>
		/// <para>Contour and Label Color</para>
		/// <para>Specifies the color of the output contour layer and annotation features.</para>
		/// <para>Black—The output contour layer and annotation features will be drawn in black. This is the default.</para>
		/// <para>Brown—The output contour layer and annotation features will be drawn in brown.</para>
		/// <para>Blue—The output contour layer and annotation features will be drawn in blue.</para>
		/// <para><see cref="ContourColorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ContourColor { get; set; } = "BLACK";

		/// <summary>
		/// <para>Contour Type Field</para>
		/// <para>The field in the input layer attribute table containing a value for the type of contour feature. An annotation class will be created for each type value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? ContourTypeField { get; set; }

		/// <summary>
		/// <para>Contour Alignment</para>
		/// <para>Specifies how the annotation will be aligned to contour elevations. The annotation can be aligned to the contour elevations so that the top of the text is always placed uphill or downhill. These options allow the annotation to be placed upside down. The contour annotation can also be aligned to the page, ensuring that the text is never placed upside down.</para>
		/// <para>Align top of text to top of page— The annotation will be aligned to the page, ensuring that the text is never placed upside down. This is the default.</para>
		/// <para>Align top of text uphill—The annotation will be aligned to the contour elevations so that the top of the text is always placed uphill. This option allows the annotation to be placed upside down.</para>
		/// <para>Align top of text downhill—The annotation will be aligned to the contour elevations so that the top of the text is always placed downhill. This option allows the annotation to be placed upside down.</para>
		/// <para><see cref="ContourAlignmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ContourAlignment { get; set; } = "PAGE";

		/// <summary>
		/// <para>Enable Laddering</para>
		/// <para>Specifies whether annotation will be placed in ladders. Placing annotation in ladders will place the text so it appears to step up and step down the contours in a straight path. These ladders will run from the top of a hill to the bottom, will not cross each other, will belong to a single slope, and will not cross any other slope.</para>
		/// <para>Checked—Annotation will step up and down the contours in a straight path.</para>
		/// <para>Unchecked—Annotation will not be placed up and down the contours in a straight path. This is the default.</para>
		/// <para><see cref="EnableLadderingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EnableLaddering { get; set; } = "false";

		/// <summary>
		/// <para>Output Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutGeodatabase2 { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ContourAnnotation SetEnviroment(int? annotationTextStringFieldLength = null, object? outputCoordinateSystem = null, double? referenceScale = null)
		{
			base.SetEnv(annotationTextStringFieldLength: annotationTextStringFieldLength, outputCoordinateSystem: outputCoordinateSystem, referenceScale: referenceScale);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Contour and Label Color</para>
		/// </summary>
		public enum ContourColorEnum 
		{
			/// <summary>
			/// <para>Black—The output contour layer and annotation features will be drawn in black. This is the default.</para>
			/// </summary>
			[GPValue("BLACK")]
			[Description("Black")]
			Black,

			/// <summary>
			/// <para>Brown—The output contour layer and annotation features will be drawn in brown.</para>
			/// </summary>
			[GPValue("BROWN")]
			[Description("Brown")]
			Brown,

			/// <summary>
			/// <para>Blue—The output contour layer and annotation features will be drawn in blue.</para>
			/// </summary>
			[GPValue("BLUE")]
			[Description("Blue")]
			Blue,

		}

		/// <summary>
		/// <para>Contour Alignment</para>
		/// </summary>
		public enum ContourAlignmentEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PAGE")]
			[Description("Align top of text  to top of page")]
			Align_top_of_text__to_top_of_page,

			/// <summary>
			/// <para>Align top of text uphill—The annotation will be aligned to the contour elevations so that the top of the text is always placed uphill. This option allows the annotation to be placed upside down.</para>
			/// </summary>
			[GPValue("UPHILL")]
			[Description("Align top of text uphill")]
			Align_top_of_text_uphill,

			/// <summary>
			/// <para>Align top of text downhill—The annotation will be aligned to the contour elevations so that the top of the text is always placed downhill. This option allows the annotation to be placed upside down.</para>
			/// </summary>
			[GPValue("DOWNHILL")]
			[Description("Align top of text downhill")]
			Align_top_of_text_downhill,

		}

		/// <summary>
		/// <para>Enable Laddering</para>
		/// </summary>
		public enum EnableLadderingEnum 
		{
			/// <summary>
			/// <para>Checked—Annotation will step up and down the contours in a straight path.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ENABLE_LADDERING")]
			ENABLE_LADDERING,

			/// <summary>
			/// <para>Unchecked—Annotation will not be placed up and down the contours in a straight path. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_ENABLE_LADDERING")]
			NOT_ENABLE_LADDERING,

		}

#endregion
	}
}
