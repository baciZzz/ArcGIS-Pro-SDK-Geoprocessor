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
	/// <para>Generate Raster Collection</para>
	/// <para>Performs batch analysis or processing on image collections contained in a mosaic dataset. The images in the input mosaic dataset can be processed individually or as groups.</para>
	/// </summary>
	public class GenerateRasterCollection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutRasterCollection">
		/// <para>Output Raster Collection</para>
		/// <para>The full path of the mosaic dataset to be created. The mosaic dataset must be stored in a geodatabase.</para>
		/// </param>
		/// <param name="CollectionBuilder">
		/// <para>Collection Builder</para>
		/// <para>The input image collection. It can be seen as a template that contains arguments such as the source mosaic dataset path, filters to extract a subset from the input data source, and so on.</para>
		/// <para>Currently, this tool only supports Simple Collection, which allows you to define a single data source and a query filter, for the data source.</para>
		/// <para>Simple collection—Allows you to define a data source and a query filter.</para>
		/// <para><see cref="CollectionBuilderEnum"/></para>
		/// </param>
		/// <param name="CollectionBuilderArguments">
		/// <para>Collection Builder Arguments</para>
		/// <para>The list of arguments to create a subset collection of the mosaic dataset.</para>
		/// <para>This tool only supports the data source and filter to subset the mosaic dataset. The Data Source and Where Clause values must be completed, otherwise the tool cannot be executed.</para>
		/// <para>Data Source—The path of the data source.</para>
		/// <para>Where Clause—The filter used to subset the mosaic dataset.</para>
		/// </param>
		public GenerateRasterCollection(object OutRasterCollection, object CollectionBuilder, object CollectionBuilderArguments)
		{
			this.OutRasterCollection = OutRasterCollection;
			this.CollectionBuilder = CollectionBuilder;
			this.CollectionBuilderArguments = CollectionBuilderArguments;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Raster Collection</para>
		/// </summary>
		public override string DisplayName() => "Generate Raster Collection";

		/// <summary>
		/// <para>Tool Name : GenerateRasterCollection</para>
		/// </summary>
		public override string ToolName() => "GenerateRasterCollection";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateRasterCollection</para>
		/// </summary>
		public override string ExcuteName() => "management.GenerateRasterCollection";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor", "pyramid", "rasterStatistics" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutRasterCollection, CollectionBuilder, CollectionBuilderArguments, RasterFunction, RasterFunctionArguments, CollectionProperties, GenerateRasters, OutWorkspace, Format, OutBaseName };

		/// <summary>
		/// <para>Output Raster Collection</para>
		/// <para>The full path of the mosaic dataset to be created. The mosaic dataset must be stored in a geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEMosaicDataset()]
		public object OutRasterCollection { get; set; }

		/// <summary>
		/// <para>Collection Builder</para>
		/// <para>The input image collection. It can be seen as a template that contains arguments such as the source mosaic dataset path, filters to extract a subset from the input data source, and so on.</para>
		/// <para>Currently, this tool only supports Simple Collection, which allows you to define a single data source and a query filter, for the data source.</para>
		/// <para>Simple collection—Allows you to define a data source and a query filter.</para>
		/// <para><see cref="CollectionBuilderEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CollectionBuilder { get; set; }

		/// <summary>
		/// <para>Collection Builder Arguments</para>
		/// <para>The list of arguments to create a subset collection of the mosaic dataset.</para>
		/// <para>This tool only supports the data source and filter to subset the mosaic dataset. The Data Source and Where Clause values must be completed, otherwise the tool cannot be executed.</para>
		/// <para>Data Source—The path of the data source.</para>
		/// <para>Where Clause—The filter used to subset the mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object CollectionBuilderArguments { get; set; }

		/// <summary>
		/// <para>Input Raster Function</para>
		/// <para>The path to a raster function template file (.rft.xml or .rft.json). The raster function template will be applied to every item in the input mosaic dataset. The Function Editor can be used to create the template. If no RFT is defined, this tool will create the output mosaic based on the Collection Builder Arguments parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object RasterFunction { get; set; }

		/// <summary>
		/// <para>Raster Function Arguments</para>
		/// <para>The parameters associated with the function chain.</para>
		/// <para>For example, if the function chain applies the NDVI function, set the visible and infrared IDs. The raster variable name of the RFT should be the Tag field value in the input data source.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object RasterFunctionArguments { get; set; }

		/// <summary>
		/// <para>Raster Collection Properties</para>
		/// <para>The output mosaic dataset key properties.</para>
		/// <para>The key metadata properties that are available is based on the type of sensor that captured the imagery. Some examples of key metadata properties include the following:</para>
		/// <para>SensorName</para>
		/// <para>ProductName</para>
		/// <para>AcquisitionDate</para>
		/// <para>CloudCover</para>
		/// <para>SunAzimuth</para>
		/// <para>SunElevation</para>
		/// <para>SensorAzimuth</para>
		/// <para>SensorElevation</para>
		/// <para>Off-nadirAngle</para>
		/// <para>BandName</para>
		/// <para>MinimumWavelength</para>
		/// <para>MaximumWavelength</para>
		/// <para>RadianceGain</para>
		/// <para>RadianceBias</para>
		/// <para>SolarIrradiance</para>
		/// <para>ReflectanceGain</para>
		/// <para>ReflectanceBias</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Output Collection Options")]
		public object CollectionProperties { get; set; }

		/// <summary>
		/// <para>Generate Rasters</para>
		/// <para>Generate raster dataset files of the mosaic dataset items, after the application of the RFT.</para>
		/// <para>Unchecked—The processing defined by the raster function template will be appended to the image items from the input data source to produce an image item in the output mosaic dataset. This is the default.</para>
		/// <para>Checked—Create raster datasets on disk. You will also need to specify the Output Raster Workspace and Format.</para>
		/// <para><see cref="GenerateRastersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Output Collection Options")]
		public object GenerateRasters { get; set; } = "false";

		/// <summary>
		/// <para>Output Raster Workspace</para>
		/// <para>Defines the output location for the persisted raster datasets, if the Generate Rasters parameter is checked on.</para>
		/// <para>The naming convention for the output raster files is oid_&lt;oid#&gt;_&lt;Unique_GUID&gt;.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[Category("Output Collection Options")]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Format</para>
		/// <para>The format type of the raster to be generated.</para>
		/// <para>Tiff—Tagged Image File Format (TIFF)</para>
		/// <para>ERDAS IMAGINE—ERDAS IMAGINE file</para>
		/// <para>CRF—Cloud Raster Format. This is the default.</para>
		/// <para>MRF—Meta Raster Format</para>
		/// <para><see cref="FormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Collection Options")]
		public object Format { get; set; } = "CRF";

		/// <summary>
		/// <para>Output Base Name</para>
		/// <para>Defines the output base name of the persisted raster datasets, if the Generate Rasters parameter is checked on. Multiple raster dataset outputs will have a number alias appended to their base name.</para>
		/// <para>The resulting mosaic dataset will reference the CRF directly without maintaining the raster function chain.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Output Collection Options")]
		public object OutBaseName { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateRasterCollection SetEnviroment(object parallelProcessingFactor = null , object pyramid = null , object rasterStatistics = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Collection Builder</para>
		/// </summary>
		public enum CollectionBuilderEnum 
		{
			/// <summary>
			/// <para>Simple collection—Allows you to define a data source and a query filter.</para>
			/// </summary>
			[GPValue("SIMPLE_COLLECTION")]
			[Description("Simple collection")]
			Simple_collection,

		}

		/// <summary>
		/// <para>Generate Rasters</para>
		/// </summary>
		public enum GenerateRastersEnum 
		{
			/// <summary>
			/// <para>Checked—Create raster datasets on disk. You will also need to specify the Output Raster Workspace and Format.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_RASTERS")]
			GENERATE_RASTERS,

			/// <summary>
			/// <para>Unchecked—The processing defined by the raster function template will be appended to the image items from the input data source to produce an image item in the output mosaic dataset. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_GENERATE_RASTERS")]
			NO_GENERATE_RASTERS,

		}

		/// <summary>
		/// <para>Format</para>
		/// </summary>
		public enum FormatEnum 
		{
			/// <summary>
			/// <para>Tiff—Tagged Image File Format (TIFF)</para>
			/// </summary>
			[GPValue("TIFF")]
			[Description("Tiff")]
			Tiff,

			/// <summary>
			/// <para>ERDAS IMAGINE—ERDAS IMAGINE file</para>
			/// </summary>
			[GPValue("IMAGINE Image")]
			[Description("ERDAS IMAGINE")]
			ERDAS_IMAGINE,

			/// <summary>
			/// <para>CRF—Cloud Raster Format. This is the default.</para>
			/// </summary>
			[GPValue("CRF")]
			[Description("CRF")]
			CRF,

			/// <summary>
			/// <para>MRF—Meta Raster Format</para>
			/// </summary>
			[GPValue("MRF")]
			[Description("MRF")]
			MRF,

		}

#endregion
	}
}
