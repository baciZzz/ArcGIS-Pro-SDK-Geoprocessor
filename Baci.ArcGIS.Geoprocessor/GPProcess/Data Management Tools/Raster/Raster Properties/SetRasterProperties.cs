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
	/// <para>Set Raster Properties</para>
	/// <para>Sets the data type, statistics, and NoData values on a raster or mosaic dataset.</para>
	/// </summary>
	public class SetRasterProperties : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster or mosaic dataset whose properties you want to set.</para>
		/// </param>
		public SetRasterProperties(object InRaster)
		{
			this.InRaster = InRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Raster Properties</para>
		/// </summary>
		public override string DisplayName => "Set Raster Properties";

		/// <summary>
		/// <para>Tool Name : SetRasterProperties</para>
		/// </summary>
		public override string ToolName => "SetRasterProperties";

		/// <summary>
		/// <para>Tool Excute Name : management.SetRasterProperties</para>
		/// </summary>
		public override string ExcuteName => "management.SetRasterProperties";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, DataType, Statistics, StatsFile, Nodata, KeyProperties, OutRaster };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster or mosaic dataset whose properties you want to set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Data Source Type</para>
		/// <para>The type of imagery in the mosaic dataset.</para>
		/// <para>Generic— The mosaic dataset does not have a specified data type.</para>
		/// <para>Elevation— The mosaic dataset contains elevation data.</para>
		/// <para>Thematic—Thematic data has discrete values, such as land cover.</para>
		/// <para>Processed—The mosaic dataset has been color balanced.</para>
		/// <para>Scientific—The data has scientific information, and will be displayed with the blue to red color ramp, by default.</para>
		/// <para>Vector UV—The data is a two band raster that contains a U and a V component of vector field data.</para>
		/// <para>Magnitude and Direction—The data is a two band raster that contains the magnitude and direction of vector field data.</para>
		/// <para><see cref="DataTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DataType { get; set; }

		/// <summary>
		/// <para>Statistics Per Band</para>
		/// <para>Specify the bands and values for the minimum, maximum, mean, and standard deviation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object Statistics { get; set; }

		/// <summary>
		/// <para>Import Statistics From File</para>
		/// <para>An .xml file that contains the statistics.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object StatsFile { get; set; }

		/// <summary>
		/// <para>Bands for NoData Value</para>
		/// <para>Specify the NoData value for each band. Each band can have a unique NoData value defined, or the same value can be specified for all bands.</para>
		/// <para>Choose the band from the NoData drop-down arrow and click the Add button to add this to the table. Then enter a value or multiple values. If you choose multiple NoData values, separate each value with a space.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object Nodata { get; set; }

		/// <summary>
		/// <para>Key Properties</para>
		/// <para>The natively supported properties are as follows. Your data may have additional properties not included in this list. All properties are case insensitive.</para>
		/// <para>AcquisitionDate</para>
		/// <para>BandName</para>
		/// <para>BlockName</para>
		/// <para>CloudCover</para>
		/// <para>DatasetTag</para>
		/// <para>Dimensions</para>
		/// <para>FlowDirection</para>
		/// <para>Footprint</para>
		/// <para>HighCellSize</para>
		/// <para>LowCellSize</para>
		/// <para>MinCellSize</para>
		/// <para>MaxCellSize</para>
		/// <para>OffNadir</para>
		/// <para>ParentRasterType</para>
		/// <para>ParentTemplate</para>
		/// <para>PerspectiveX</para>
		/// <para>PerspectiveY</para>
		/// <para>PerspectiveZ</para>
		/// <para>ProductName</para>
		/// <para>RadianceBias</para>
		/// <para>RadianceGain</para>
		/// <para>ReflectanceBias</para>
		/// <para>RefelctanceGain</para>
		/// <para>Segmented</para>
		/// <para>SensorAzimuth</para>
		/// <para>SensorElevation</para>
		/// <para>SensorName</para>
		/// <para>SolarIrradiance</para>
		/// <para>SourceBandIndex</para>
		/// <para>StdPressure</para>
		/// <para>StdPressure_Max</para>
		/// <para>StdTemperature</para>
		/// <para>StdTemperature_Max</para>
		/// <para>StdTime</para>
		/// <para>StdTime_Max</para>
		/// <para>StdZ</para>
		/// <para>StdZ_max</para>
		/// <para>SunAzimuth</para>
		/// <para>SunElevation</para>
		/// <para>ThermalConstant_K1</para>
		/// <para>ThermalConstant_K2</para>
		/// <para>Variable</para>
		/// <para>VerticalAccuracy</para>
		/// <para>WavelengthMin</para>
		/// <para>WavelengthMax</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object KeyProperties { get; set; }

		/// <summary>
		/// <para>Updated Raster Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetRasterProperties SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Data Source Type</para>
		/// </summary>
		public enum DataTypeEnum 
		{
			/// <summary>
			/// <para>Generic— The mosaic dataset does not have a specified data type.</para>
			/// </summary>
			[GPValue("GENERIC")]
			[Description("Generic")]
			Generic,

			/// <summary>
			/// <para>Elevation— The mosaic dataset contains elevation data.</para>
			/// </summary>
			[GPValue("ELEVATION")]
			[Description("Elevation")]
			Elevation,

			/// <summary>
			/// <para>Thematic—Thematic data has discrete values, such as land cover.</para>
			/// </summary>
			[GPValue("THEMATIC")]
			[Description("Thematic")]
			Thematic,

			/// <summary>
			/// <para>Processed—The mosaic dataset has been color balanced.</para>
			/// </summary>
			[GPValue("PROCESSED")]
			[Description("Processed")]
			Processed,

			/// <summary>
			/// <para>Scientific—The data has scientific information, and will be displayed with the blue to red color ramp, by default.</para>
			/// </summary>
			[GPValue("SCIENTIFIC")]
			[Description("Scientific")]
			Scientific,

			/// <summary>
			/// <para>Vector UV—The data is a two band raster that contains a U and a V component of vector field data.</para>
			/// </summary>
			[GPValue("VECTOR_UV")]
			[Description("Vector UV")]
			Vector_UV,

			/// <summary>
			/// <para>Magnitude and Direction—The data is a two band raster that contains the magnitude and direction of vector field data.</para>
			/// </summary>
			[GPValue("VECTOR_MAGDIR")]
			[Description("Magnitude and Direction")]
			Magnitude_and_Direction,

		}

#endregion
	}
}
