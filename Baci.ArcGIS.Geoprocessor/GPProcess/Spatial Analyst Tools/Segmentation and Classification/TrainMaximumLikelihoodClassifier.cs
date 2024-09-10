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
	/// <para>Train Maximum Likelihood Classifier</para>
	/// <para>Generates an Esri classifier definition file (.ecd) using the Maximum Likelihood Classifier (MLC) classification definition.</para>
	/// </summary>
	public class TrainMaximumLikelihoodClassifier : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster dataset to classify.</para>
		/// </param>
		/// <param name="InTrainingFeatures">
		/// <para>Input Training Sample File</para>
		/// <para>The training sample file or layer that delineates the training sites.</para>
		/// <para>These can be either shapefiles or feature classes that contain the training samples. The following field names are required in the training sample file:</para>
		/// <para>classname—A text field indicating the name of the class category</para>
		/// <para>classvalue—A long integer field containing the integer value for each class category</para>
		/// </param>
		/// <param name="OutClassifierDefinition">
		/// <para>Output Classifier Definition File</para>
		/// <para>The output JSON format file that will contain attribute information, statistics, hyperplane vectors, and other information for the classifier. An .ecd file will be created.</para>
		/// </param>
		public TrainMaximumLikelihoodClassifier(object InRaster, object InTrainingFeatures, object OutClassifierDefinition)
		{
			this.InRaster = InRaster;
			this.InTrainingFeatures = InTrainingFeatures;
			this.OutClassifierDefinition = OutClassifierDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : Train Maximum Likelihood Classifier</para>
		/// </summary>
		public override string DisplayName() => "Train Maximum Likelihood Classifier";

		/// <summary>
		/// <para>Tool Name : TrainMaximumLikelihoodClassifier</para>
		/// </summary>
		public override string ToolName() => "TrainMaximumLikelihoodClassifier";

		/// <summary>
		/// <para>Tool Excute Name : sa.TrainMaximumLikelihoodClassifier</para>
		/// </summary>
		public override string ExcuteName() => "sa.TrainMaximumLikelihoodClassifier";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, InTrainingFeatures, OutClassifierDefinition, InAdditionalRaster, UsedAttributes, DimensionValueField };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster dataset to classify.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Input Training Sample File</para>
		/// <para>The training sample file or layer that delineates the training sites.</para>
		/// <para>These can be either shapefiles or feature classes that contain the training samples. The following field names are required in the training sample file:</para>
		/// <para>classname—A text field indicating the name of the class category</para>
		/// <para>classvalue—A long integer field containing the integer value for each class category</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTrainingFeatures { get; set; }

		/// <summary>
		/// <para>Output Classifier Definition File</para>
		/// <para>The output JSON format file that will contain attribute information, statistics, hyperplane vectors, and other information for the classifier. An .ecd file will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object OutClassifierDefinition { get; set; }

		/// <summary>
		/// <para>Additional Input Raster</para>
		/// <para>Incorporates ancillary raster datasets, such as a segmented image or DEM. This parameter is optional.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object InAdditionalRaster { get; set; }

		/// <summary>
		/// <para>Segment Attributes Used</para>
		/// <para>Specifies the attributes that will be included in the attribute table associated with the output raster.</para>
		/// <para>Converged color—The RGB color values will be derived from the input raster on a per-segment basis.</para>
		/// <para>Mean digital number—The average digital number (DN) will be derived from the optional pixel image on a per-segment basis.</para>
		/// <para>Standard deviation—The standard deviation will be derived from the optional pixel image on a per-segment basis.</para>
		/// <para>Count of pixels—The number of pixels composing the segment, on a per-segment basis.</para>
		/// <para>Compactness—The degree to which a segment is compact or circular, on a per-segment basis. The values range from 0 to 1, in which 1 is a circle.</para>
		/// <para>Rectangularity—The degree to which the segment is rectangular, on a per-segment basis. The values range from 0 to 1, in which 1 is a rectangle.</para>
		/// <para>This parameter is only active if the Segmented key property is set to true on the input raster. If the only input to the tool is a segmented image, the default attributes are Average chromaticity color, Count of pixels, Compactness, and Rectangularity. If an Additional Input Raster value is included as an input with a segmented image, Mean digital number and Standard deviation are also available attributes.</para>
		/// <para><see cref="UsedAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Segment Attributes")]
		public object UsedAttributes { get; set; } = "COLOR;MEAN";

		/// <summary>
		/// <para>Dimension Value Field</para>
		/// <para>Contains dimension values in the input training sample feature class.</para>
		/// <para>This parameter is required to classify a time series of raster data using the change analysis raster output from the Analyze Changes Using CCDC tool in the Image Analyst toolbox.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Double", "Date")]
		public object DimensionValueField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TrainMaximumLikelihoodClassifier SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Segment Attributes Used</para>
		/// </summary>
		public enum UsedAttributesEnum 
		{
			/// <summary>
			/// <para>Converged color—The RGB color values will be derived from the input raster on a per-segment basis.</para>
			/// </summary>
			[GPValue("COLOR")]
			[Description("Converged color")]
			Converged_color,

			/// <summary>
			/// <para>Mean digital number—The average digital number (DN) will be derived from the optional pixel image on a per-segment basis.</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Mean digital number")]
			Mean_digital_number,

			/// <summary>
			/// <para>Standard deviation—The standard deviation will be derived from the optional pixel image on a per-segment basis.</para>
			/// </summary>
			[GPValue("STD")]
			[Description("Standard deviation")]
			Standard_deviation,

			/// <summary>
			/// <para>Count of pixels—The number of pixels composing the segment, on a per-segment basis.</para>
			/// </summary>
			[GPValue("COUNT")]
			[Description("Count of pixels")]
			Count_of_pixels,

			/// <summary>
			/// <para>Compactness—The degree to which a segment is compact or circular, on a per-segment basis. The values range from 0 to 1, in which 1 is a circle.</para>
			/// </summary>
			[GPValue("COMPACTNESS")]
			[Description("Compactness")]
			Compactness,

			/// <summary>
			/// <para>Rectangularity—The degree to which the segment is rectangular, on a per-segment basis. The values range from 0 to 1, in which 1 is a rectangle.</para>
			/// </summary>
			[GPValue("RECTANGULARITY")]
			[Description("Rectangularity")]
			Rectangularity,

		}

#endregion
	}
}
