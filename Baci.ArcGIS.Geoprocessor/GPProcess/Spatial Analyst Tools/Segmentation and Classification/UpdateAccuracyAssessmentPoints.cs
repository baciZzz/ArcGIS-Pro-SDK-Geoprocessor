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
	/// <para>Update Accuracy Assessment Points</para>
	/// <para>Update Accuracy Assessment Points</para>
	/// <para>Updates the Target field in the attribute table to compare reference points to the classified image.</para>
	/// </summary>
	public class UpdateAccuracyAssessmentPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InClassData">
		/// <para>Input Raster or Feature Class Data</para>
		/// <para>The input classification image or other thematic GIS reference data. The input can be a raster or feature class.</para>
		/// <para>Typical data is a classification image of a single band, integer data type.</para>
		/// <para>If using polygons as input, only use those that are not used as training samples. You can also use land-cover data in shapefile or feature class format.</para>
		/// </param>
		/// <param name="InPoints">
		/// <para>Input Accuracy Assessment Points</para>
		/// <para>The point feature class providing the accuracy assessment points to be updated.</para>
		/// <para>All points from this input will be copied to the updated output feature class, and the Target Field parameter value will be updated from the input raster or feature class data.</para>
		/// </param>
		/// <param name="OutPoints">
		/// <para>Output Accuracy Assessment Points</para>
		/// <para>The output point feature class that contains the updated random point field for accuracy assessment purposes.</para>
		/// </param>
		public UpdateAccuracyAssessmentPoints(object InClassData, object InPoints, object OutPoints)
		{
			this.InClassData = InClassData;
			this.InPoints = InPoints;
			this.OutPoints = OutPoints;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Accuracy Assessment Points</para>
		/// </summary>
		public override string DisplayName() => "Update Accuracy Assessment Points";

		/// <summary>
		/// <para>Tool Name : UpdateAccuracyAssessmentPoints</para>
		/// </summary>
		public override string ToolName() => "UpdateAccuracyAssessmentPoints";

		/// <summary>
		/// <para>Tool Excute Name : sa.UpdateAccuracyAssessmentPoints</para>
		/// </summary>
		public override string ExcuteName() => "sa.UpdateAccuracyAssessmentPoints";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InClassData, InPoints, OutPoints, TargetField!, PolygonDimensionField!, PointDimensionField! };

		/// <summary>
		/// <para>Input Raster or Feature Class Data</para>
		/// <para>The input classification image or other thematic GIS reference data. The input can be a raster or feature class.</para>
		/// <para>Typical data is a classification image of a single band, integer data type.</para>
		/// <para>If using polygons as input, only use those that are not used as training samples. You can also use land-cover data in shapefile or feature class format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InClassData { get; set; }

		/// <summary>
		/// <para>Input Accuracy Assessment Points</para>
		/// <para>The point feature class providing the accuracy assessment points to be updated.</para>
		/// <para>All points from this input will be copied to the updated output feature class, and the Target Field parameter value will be updated from the input raster or feature class data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InPoints { get; set; }

		/// <summary>
		/// <para>Output Accuracy Assessment Points</para>
		/// <para>The output point feature class that contains the updated random point field for accuracy assessment purposes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPoints { get; set; }

		/// <summary>
		/// <para>Target Field</para>
		/// <para>Specifies whether the input data is a classified image or ground truth data.</para>
		/// <para>Classified—The input is a classified image. This is the default.</para>
		/// <para>Ground truth—The input is reference data.</para>
		/// <para><see cref="TargetFieldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TargetField { get; set; } = "CLASSIFIED";

		/// <summary>
		/// <para>Dimension Field for Feature Class</para>
		/// <para>The dimension field for the Input Accuracy Assessment Points parameter value. The assessment points will be updated based on the matching dimension values with this field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object? PolygonDimensionField { get; set; }

		/// <summary>
		/// <para>Dimension Field for Test Points</para>
		/// <para>The dimension field in the Input Accuracy Assessment Points parameter value. Input data with identical dimension values will be used to update corresponding points.</para>
		/// <para>When the Input Raster or Feature Class Data parameter value is a multidimensional raster, rasters with dimension values that match the dimension field in the test points will be used in updating. The multidimensional raster is expected to have one time dimension (StdTime). Otherwise, the first dimension will be used to match the dimension field of the test points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object? PointDimensionField { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Target Field</para>
		/// </summary>
		public enum TargetFieldEnum 
		{
			/// <summary>
			/// <para>Classified—The input is a classified image. This is the default.</para>
			/// </summary>
			[GPValue("CLASSIFIED")]
			[Description("Classified")]
			Classified,

			/// <summary>
			/// <para>Ground truth—The input is reference data.</para>
			/// </summary>
			[GPValue("GROUND_TRUTH")]
			[Description("Ground truth")]
			Ground_truth,

		}

#endregion
	}
}
