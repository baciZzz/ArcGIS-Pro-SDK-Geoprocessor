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
	/// <para>Get Raster Properties</para>
	/// <para>Get Raster Properties</para>
	/// <para>Retrieves  information from the metadata and descriptive statistics about a raster dataset.</para>
	/// </summary>
	public class GetRasterProperties : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster containing the properties to retrieve.</para>
		/// </param>
		public GetRasterProperties(object InRaster)
		{
			this.InRaster = InRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Get Raster Properties</para>
		/// </summary>
		public override string DisplayName() => "Get Raster Properties";

		/// <summary>
		/// <para>Tool Name : GetRasterProperties</para>
		/// </summary>
		public override string ToolName() => "GetRasterProperties";

		/// <summary>
		/// <para>Tool Excute Name : management.GetRasterProperties</para>
		/// </summary>
		public override string ExcuteName() => "management.GetRasterProperties";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, PropertyType!, BandIndex!, Property! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster containing the properties to retrieve.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Property type</para>
		/// <para>The property to be obtained from the input raster.</para>
		/// <para>Minimum cell value—Smallest value of all cells in the input raster.</para>
		/// <para>Maximum cell value—Largest value of all cells in the input raster.</para>
		/// <para>Mean of all cells—Average of all cells in the input raster.</para>
		/// <para>Standard Deviation of all cells—Standard deviation of all cells in the input raster.</para>
		/// <para>Unique value count—Number of unique values in the input raster.</para>
		/// <para>Maximum Y coordinate (top)—Top (maximum y-coordinate) value of the extent.</para>
		/// <para>Minimum X coordinate (left)—Left (minimum x-coordinate) value of the extent.</para>
		/// <para>Maximum X coordinate (right)—Right (maximum x-coordinate) value of the extent.</para>
		/// <para>Minimum Y coordinate (bottom)—Bottom (minimum y-coordinate) value of the extent.</para>
		/// <para>Cell size x-direction—Cell size in the x-direction.</para>
		/// <para>Cell size y-direction—Cell size in the y-direction.</para>
		/// <para>Cell value type—Type of the cell value in the input raster.</para>
		/// <para>Number of columns—Number of columns in the input raster.</para>
		/// <para>Number of rows—Number of rows in the input raster.</para>
		/// <para>Number of bands—Number of bands in the input raster.</para>
		/// <para>Contains NoData cells—Returns whether there is NoData in the raster.</para>
		/// <para>All cells contain NoData—Returns whether all the pixels are NoData. This is also known as ISNULL.</para>
		/// <para>Sensor name—Name of the sensor.</para>
		/// <para>Product name—Product name related to the sensor.</para>
		/// <para>Acquisition date—Date that the data was captured.</para>
		/// <para>Source type—Source type.</para>
		/// <para>Cloud cover—Amount of cloud cover as a percentage.</para>
		/// <para>Sun azimuth—Sun azimuth, in degrees.</para>
		/// <para>Sun elevation—Sun elevation, in degrees.</para>
		/// <para>Sensor azimuth—Sensor azimuth, in degrees.</para>
		/// <para>Sensor elevation—Sensor elevation, in degrees.</para>
		/// <para>Off nadir—Off-nadir angle, in degrees.</para>
		/// <para>Wavelength—Wavelength range of the band, in nanometers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PropertyType { get; set; } = "MINIMUM";

		/// <summary>
		/// <para>Band Name</para>
		/// <para>Choose the band name from the drop-down box. If no band is chosen, then the first band will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? BandIndex { get; set; }

		/// <summary>
		/// <para>Property</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPVariant()]
		public object? Property { get; set; }

	}
}
