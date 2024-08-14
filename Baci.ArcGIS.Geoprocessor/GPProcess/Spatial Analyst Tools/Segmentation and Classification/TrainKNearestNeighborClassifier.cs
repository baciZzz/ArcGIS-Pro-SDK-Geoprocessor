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
	/// <para>Train K-Nearest Neighbor Classifier</para>
	/// <para>Generates an Esri classifier definition file (.ecd) using the K-Nearest Neighbor classification method.</para>
	/// </summary>
	public class TrainKNearestNeighborClassifier : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster dataset to classify.</para>
		/// <para>The single band raster or segmented raster, multiband raster, or a multidimensional raster to be classified.</para>
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
		/// <para>A JSON formatted .ecd file that contains attribute information, statistics, or other information for the classifier.</para>
		/// </param>
		public TrainKNearestNeighborClassifier(object InRaster, object InTrainingFeatures, object OutClassifierDefinition)
		{
			this.InRaster = InRaster;
			this.InTrainingFeatures = InTrainingFeatures;
			this.OutClassifierDefinition = OutClassifierDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : Train K-Nearest Neighbor Classifier</para>
		/// </summary>
		public override string DisplayName => "Train K-Nearest Neighbor Classifier";

		/// <summary>
		/// <para>Tool Name : TrainKNearestNeighborClassifier</para>
		/// </summary>
		public override string ToolName => "TrainKNearestNeighborClassifier";

		/// <summary>
		/// <para>Tool Excute Name : sa.TrainKNearestNeighborClassifier</para>
		/// </summary>
		public override string ExcuteName => "sa.TrainKNearestNeighborClassifier";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, InTrainingFeatures, OutClassifierDefinition, InAdditionalRaster!, Knn!, MaxSamplesPerClass!, UsedAttributes!, DimensionValueField };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster dataset to classify.</para>
		/// <para>The single band raster or segmented raster, multiband raster, or a multidimensional raster to be classified.</para>
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
		/// <para>A JSON formatted .ecd file that contains attribute information, statistics, or other information for the classifier.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object OutClassifierDefinition { get; set; }

		/// <summary>
		/// <para>Additional Input Raster</para>
		/// <para>Ancillary raster datasets, such as a multispectral image or a DEM, will be incorporated to generate attributes and other required information for classification. This parameter is optional.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? InAdditionalRaster { get; set; }

		/// <summary>
		/// <para>K Nearest Neighbors</para>
		/// <para>The number of neighbors that will be used in searching for each input pixel or segment. Increasing the number of neighbors will decrease the influence of individual neighbors on the outcome of the classification. The default value is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? Knn { get; set; } = "1";

		/// <summary>
		/// <para>Max Number of Samples Per Class</para>
		/// <para>The maximum number of training samples that will be used for each class. The default value of 1000 is recommended when the inputs are nonsegmented rasters. A value that is less than or equal to 0 means that the system will use all the samples from the training sites to train the classifier.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaxSamplesPerClass { get; set; } = "1000";

		/// <summary>
		/// <para>Segment Attributes</para>
		/// <para>Specifies the attributes that will be included in the attribute table associated with the output raster.</para>
		/// <para>Converged color—The RGB color values will be derived from the input raster on a per-segment basis. This is also known as average chromaticity color.</para>
		/// <para>Mean digital number—The average digital number (DN) will be derived from the optional pixel image on a per-segment basis.</para>
		/// <para>Standard deviation—The standard deviation will be derived from the optional pixel image on a per-segment basis.</para>
		/// <para>Count of pixels—The number of pixels composing the segment, on a per-segment basis.</para>
		/// <para>Compactness—The degree to which a segment is compact or circular, on a per-segment basis. The values range from 0 to 1, in which 1 is a circle.</para>
		/// <para>Rectangularity—The degree to which the segment is rectangular, on a per-segment basis. The values range from 0 to 1, in which 1 is a rectangle.</para>
		/// <para>This parameter is only active if the Segmented key property is set to true on the input raster. If the only input to the tool is a segmented image, the default attributes are Converged color, Count of pixels, Compactness, and Rectangularity. If an Additional Input Raster value is included as an input with a segmented image, Mean digital number and Standard deviation are also available attributes.</para>
		/// <para><see cref="UsedAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Segment Attributes")]
		public object? UsedAttributes { get; set; } = "COLOR;MEAN";

		/// <summary>
		/// <para>Dimension Value Field</para>
		/// <para>Contains dimension values in the input training sample feature class.</para>
		/// <para>This parameter is required to classify a time series of raster data using the change analysis raster output from the Analyze Changes Using CCDC tool in the Image Analyst toolbox.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? DimensionValueField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TrainKNearestNeighborClassifier SetEnviroment(object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Segment Attributes</para>
		/// </summary>
		public enum UsedAttributesEnum 
		{
			/// <summary>
			/// <para>Converged color—The RGB color values will be derived from the input raster on a per-segment basis. This is also known as average chromaticity color.</para>
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
