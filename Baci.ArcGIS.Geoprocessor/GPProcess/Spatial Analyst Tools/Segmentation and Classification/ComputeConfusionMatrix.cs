using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Compute Confusion Matrix</para>
	/// <para>Compute Confusion Matrix</para>
	/// <para>Computes a confusion matrix with errors of omission and commission and derives a kappa index of agreement, Intersection over Union (IoU),  and an overall accuracy between the classified map and the reference data.</para>
	/// </summary>
	public class ComputeConfusionMatrix : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InAccuracyAssessmentPoints">
		/// <para>Input Accuracy Assessment Points</para>
		/// <para>The accuracy assessment point feature class created from the Create Accuracy Assessment Points tool, containing the Classified and GrndTruth fields. The Classified and GrndTruth fields are both long integer field types.</para>
		/// </param>
		/// <param name="OutConfusionMatrix">
		/// <para>Output Confusion Matrix</para>
		/// <para>The output file name of the confusion matrix in table format.</para>
		/// <para>The format of the table is determined by the output location and path. By default, the output will be a geodatabase table. If the path is not in a geodatabase, specify a .dbf extension to save it in dBASE format.</para>
		/// </param>
		public ComputeConfusionMatrix(object InAccuracyAssessmentPoints, object OutConfusionMatrix)
		{
			this.InAccuracyAssessmentPoints = InAccuracyAssessmentPoints;
			this.OutConfusionMatrix = OutConfusionMatrix;
		}

		/// <summary>
		/// <para>Tool Display Name : Compute Confusion Matrix</para>
		/// </summary>
		public override string DisplayName() => "Compute Confusion Matrix";

		/// <summary>
		/// <para>Tool Name : ComputeConfusionMatrix</para>
		/// </summary>
		public override string ToolName() => "ComputeConfusionMatrix";

		/// <summary>
		/// <para>Tool Excute Name : sa.ComputeConfusionMatrix</para>
		/// </summary>
		public override string ExcuteName() => "sa.ComputeConfusionMatrix";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InAccuracyAssessmentPoints, OutConfusionMatrix };

		/// <summary>
		/// <para>Input Accuracy Assessment Points</para>
		/// <para>The accuracy assessment point feature class created from the Create Accuracy Assessment Points tool, containing the Classified and GrndTruth fields. The Classified and GrndTruth fields are both long integer field types.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InAccuracyAssessmentPoints { get; set; }

		/// <summary>
		/// <para>Output Confusion Matrix</para>
		/// <para>The output file name of the confusion matrix in table format.</para>
		/// <para>The format of the table is determined by the output location and path. By default, the output will be a geodatabase table. If the path is not in a geodatabase, specify a .dbf extension to save it in dBASE format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutConfusionMatrix { get; set; }

	}
}
