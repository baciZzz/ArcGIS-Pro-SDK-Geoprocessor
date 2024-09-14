using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Non Maximum Suppression</para>
	/// <para>Non Maximum Suppression</para>
	/// <para>Identifies duplicate features from the output of the Detect Objects Using Deep Learning tool as a postprocessing step and creates a new output with no duplicate features. The Detect Objects Using Deep Learning tool can return more than one bounding box or polygon for the same object, especially as a tiling side effect. If two features overlap more than a given maximum ratio, the feature with the lower confidence value will be removed.</para>
	/// </summary>
	public class NonMaximumSuppression : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureclass">
		/// <para>Input Feature Class</para>
		/// <para>The input feature class or feature layer containing overlapping or duplicate features.</para>
		/// </param>
		/// <param name="ConfidenceScoreField">
		/// <para>Confidence Score Field</para>
		/// <para>The field in the feature class that contains the confidence scores as output by the object detection method.</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class with the duplicate features removed.</para>
		/// </param>
		public NonMaximumSuppression(object InFeatureclass, object ConfidenceScoreField, object OutFeatureclass)
		{
			this.InFeatureclass = InFeatureclass;
			this.ConfidenceScoreField = ConfidenceScoreField;
			this.OutFeatureclass = OutFeatureclass;
		}

		/// <summary>
		/// <para>Tool Display Name : Non Maximum Suppression</para>
		/// </summary>
		public override string DisplayName() => "Non Maximum Suppression";

		/// <summary>
		/// <para>Tool Name : NonMaximumSuppression</para>
		/// </summary>
		public override string ToolName() => "NonMaximumSuppression";

		/// <summary>
		/// <para>Tool Excute Name : ia.NonMaximumSuppression</para>
		/// </summary>
		public override string ExcuteName() => "ia.NonMaximumSuppression";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureclass, ConfidenceScoreField, OutFeatureclass, ClassValueField, MaxOverlapRatio };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The input feature class or feature layer containing overlapping or duplicate features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InFeatureclass { get; set; }

		/// <summary>
		/// <para>Confidence Score Field</para>
		/// <para>The field in the feature class that contains the confidence scores as output by the object detection method.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		public object ConfidenceScoreField { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class with the duplicate features removed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>Class Value Field</para>
		/// <para>The class value field in the input feature class. If not specified, the tool will use the standard class value fields Classvalue and Value. If these fields do not exist, all features will be treated as the same object class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object ClassValueField { get; set; }

		/// <summary>
		/// <para>Max Overlap Ratio</para>
		/// <para>The maximum overlap ratio for two overlapping features. This is defined as the ratio of intersection area over union area. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MaxOverlapRatio { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public NonMaximumSuppression SetEnviroment(object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
