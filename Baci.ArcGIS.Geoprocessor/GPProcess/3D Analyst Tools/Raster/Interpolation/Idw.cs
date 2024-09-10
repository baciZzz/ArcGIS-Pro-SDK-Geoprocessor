using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>IDW</para>
	/// <para>Interpolates a raster surface from points using an inverse distance weighted (IDW) technique.</para>
	/// </summary>
	public class Idw : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input point features</para>
		/// <para>The input point features containing the z-values to be interpolated into a surface raster.</para>
		/// </param>
		/// <param name="ZField">
		/// <para>Z value field</para>
		/// <para>The field that holds a height or magnitude value for each point.</para>
		/// <para>This can be a numeric field or the Shape field if the input point features contain z-values.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output interpolated surface raster.</para>
		/// <para>It is always a floating-point raster.</para>
		/// </param>
		public Idw(object InPointFeatures, object ZField, object OutRaster)
		{
			this.InPointFeatures = InPointFeatures;
			this.ZField = ZField;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : IDW</para>
		/// </summary>
		public override string DisplayName() => "IDW";

		/// <summary>
		/// <para>Tool Name : Idw</para>
		/// </summary>
		public override string ToolName() => "Idw";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Idw</para>
		/// </summary>
		public override string ExcuteName() => "3d.Idw";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointFeatures, ZField, OutRaster, CellSize, Power, SearchRadius, InBarrierPolylineFeatures };

		/// <summary>
		/// <para>Input point features</para>
		/// <para>The input point features containing the z-values to be interpolated into a surface raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer")]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		[GeometryType("Point", "Multipoint")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Z value field</para>
		/// <para>The field that holds a height or magnitude value for each point.</para>
		/// <para>This can be a numeric field or the Shape field if the input point features contain z-values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		public object ZField { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output interpolated surface raster.</para>
		/// <para>It is always a floating-point raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>The cell size of the output raster that will be created.</para>
		/// <para>This parameter can be defined by a numeric value or obtained from an existing raster dataset. If the cell size hasn&apos;t been explicitly specified as the parameter value, the environment cell size value will be used if specified; otherwise, additional rules will be used to calculate it from the other inputs. See the usage section for more detail.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Power</para>
		/// <para>The exponent of distance.</para>
		/// <para>Controls the significance of surrounding points on the interpolated value. A higher power results in less influence from distant points. It can be any real number greater than 0, but the most reasonable results will be obtained using values from 0.5 to 3. The default is 2.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object Power { get; set; } = "2";

		/// <summary>
		/// <para>Search radius</para>
		/// <para>Defines which of the input points will be used to interpolate the value for each cell in the output raster.</para>
		/// <para>There are two options: Variable and Fixed. Variable is the default.</para>
		/// <para>VariableUses a variable search radius in order to find a specified number of input sample points for the interpolation.</para>
		/// <para>Number of points—An integer value specifying the number of nearest input sample points to be used to perform interpolation. The default is 12 points.</para>
		/// <para>Maximum distance—Specifies the distance, in map units, by which to limit the search for the nearest input sample points. The default value is the length of the extent&apos;s diagonal.</para>
		/// <para>FixedUses a specified fixed distance within which all input points will be used for the interpolation.</para>
		/// <para>Distance—Specifies the distance as a radius within which input sample points will be used to perform the interpolation.The value of the radius is expressed in map units. The default radius is five times the cell size of the output raster.</para>
		/// <para>Minimum number of points—An integer defining the minimum number of points to be used for interpolation. The default value is 0.If the required number of points is not found within the specified distance, the search distance will be increased until the specified minimum number of points is found.</para>
		/// <para>When the search radius needs to be increased it is done so until the Minimum number of points fall within that radius, or the extent of the radius crosses the lower (southern) and/or upper (northern) extent of the output raster. NoData is assigned to all locations that do not satisfy the above condition.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSARadius()]
		public object SearchRadius { get; set; } = "VARIABLE 12";

		/// <summary>
		/// <para>Input barrier polyline features</para>
		/// <para>Polyline features to be used as a break or limit in searching for the input sample points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Polyline")]
		public object InBarrierPolylineFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Idw SetEnviroment(int? autoCommit = null , object cellSize = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
