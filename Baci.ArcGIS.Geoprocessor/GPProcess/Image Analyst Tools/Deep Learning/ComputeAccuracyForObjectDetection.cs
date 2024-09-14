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
	/// <para>Compute Accuracy For Object Detection</para>
	/// <para>Compute Accuracy For Object Detection</para>
	/// <para>Calculates the accuracy of a deep learning model by comparing the detected objects from the Detect Objects Using Deep Learning tool to ground truth data.</para>
	/// </summary>
	public class ComputeAccuracyForObjectDetection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="DetectedFeatures">
		/// <para>Detected Features</para>
		/// <para>The polygon feature class containing the objects detected from the Detect Objects Using Deep Learning tool.</para>
		/// </param>
		/// <param name="GroundTruthFeatures">
		/// <para>Ground Truth Features</para>
		/// <para>The polygon feature class containing ground truth data.</para>
		/// </param>
		/// <param name="OutAccuracyTable">
		/// <para>Output Accuracy Table</para>
		/// <para>The output accuracy table.</para>
		/// </param>
		public ComputeAccuracyForObjectDetection(object DetectedFeatures, object GroundTruthFeatures, object OutAccuracyTable)
		{
			this.DetectedFeatures = DetectedFeatures;
			this.GroundTruthFeatures = GroundTruthFeatures;
			this.OutAccuracyTable = OutAccuracyTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Compute Accuracy For Object Detection</para>
		/// </summary>
		public override string DisplayName() => "Compute Accuracy For Object Detection";

		/// <summary>
		/// <para>Tool Name : ComputeAccuracyForObjectDetection</para>
		/// </summary>
		public override string ToolName() => "ComputeAccuracyForObjectDetection";

		/// <summary>
		/// <para>Tool Excute Name : ia.ComputeAccuracyForObjectDetection</para>
		/// </summary>
		public override string ExcuteName() => "ia.ComputeAccuracyForObjectDetection";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { DetectedFeatures, GroundTruthFeatures, OutAccuracyTable, OutAccuracyReport, DetectedClassValueField, GroundTruthClassValueField, MinIou, MaskFeatures };

		/// <summary>
		/// <para>Detected Features</para>
		/// <para>The polygon feature class containing the objects detected from the Detect Objects Using Deep Learning tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object DetectedFeatures { get; set; }

		/// <summary>
		/// <para>Ground Truth Features</para>
		/// <para>The polygon feature class containing ground truth data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object GroundTruthFeatures { get; set; }

		/// <summary>
		/// <para>Output Accuracy Table</para>
		/// <para>The output accuracy table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutAccuracyTable { get; set; }

		/// <summary>
		/// <para>Output Accuracy Report</para>
		/// <para>The name of the output accuracy report. The report is a PDF document containing accuracy metrics and charts.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPCompositeDomain()]
		public object OutAccuracyReport { get; set; }

		/// <summary>
		/// <para>Detected Class Value Field</para>
		/// <para>The field in the detected objects feature class that contains the class values or class names.</para>
		/// <para>If a field name is not specified, a Classvalue or Value field will be used. If these fields do not exist, all records will be identified as belonging to one class.</para>
		/// <para>The class values or class names must match those in the ground reference feature class exactly.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object DetectedClassValueField { get; set; }

		/// <summary>
		/// <para>Ground Truth Class Value Field</para>
		/// <para>The field in the ground truth feature class that contains the class values.</para>
		/// <para>If a field name is not specified, a Classvalue or Value field will be used. If these fields do not exist, all records will be identified as belonging to one class.</para>
		/// <para>The class values or class names must match those in the detected objects feature class exactly.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object GroundTruthClassValueField { get; set; }

		/// <summary>
		/// <para>Minimum Intersection Over Union (IoU)</para>
		/// <para>The IoU ratio to use as a threshold to evaluate the accuracy of the object-detection model. The numerator is the area of overlap between the predicted bounding box and the ground reference bounding box. The denominator is the area of union or the area encompassed by both bounding boxes. The IoU ranges from 0 to 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MinIou { get; set; } = "0.5";

		/// <summary>
		/// <para>Mask Features</para>
		/// <para>A polygon feature class that delineates the area or areas where accuracy will be computed. Only the features that intersect the mask will be assessed for accuracy.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object MaskFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ComputeAccuracyForObjectDetection SetEnviroment(object extent = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
