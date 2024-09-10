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
	/// <para>Point Density</para>
	/// <para>Calculates a magnitude-per-unit area from point features that fall within a neighborhood around each cell.</para>
	/// </summary>
	public class PointDensity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input point features</para>
		/// <para>The input point features for which to calculate the density.</para>
		/// </param>
		/// <param name="PopulationField">
		/// <para>Population field</para>
		/// <para>Field denoting population values for each point. The population field is the count or quantity to be used in the calculation of a continuous surface.</para>
		/// <para>Values in the population field can be integer or floating point.</para>
		/// <para>The options and default behaviors for the field are listed below.</para>
		/// <para>Use None if no item or special value will be used and each feature will be counted once.</para>
		/// <para>You can use the Shape field if input features contain Z.</para>
		/// <para>Otherwise, the default field is POPULATION. The following conditions may also apply:</para>
		/// <para>If there is no POPULATION field, but there is a POPULATIONxxxx field, it will be used by default. The xxxx can be any valid characters, for example, POPULATION6, POPULATION1974, and POPULATIONROADTYPE.</para>
		/// <para>If there is no POPULATION field or POPULATIONxxxx field, but there is a POP field, it will be used by default.</para>
		/// <para>If there is no POPULATION field, POPULATIONxxxx field, or POP field, but there is a POPxxxx field, it will be used by default.</para>
		/// <para>If there is no POPULATION field, POPULATIONxxxx field, POP field, or POPxxxx field, NONE will be used by default.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output point density raster.</para>
		/// <para>It is always a floating point raster.</para>
		/// </param>
		public PointDensity(object InPointFeatures, object PopulationField, object OutRaster)
		{
			this.InPointFeatures = InPointFeatures;
			this.PopulationField = PopulationField;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Point Density</para>
		/// </summary>
		public override string DisplayName() => "Point Density";

		/// <summary>
		/// <para>Tool Name : PointDensity</para>
		/// </summary>
		public override string ToolName() => "PointDensity";

		/// <summary>
		/// <para>Tool Excute Name : sa.PointDensity</para>
		/// </summary>
		public override string ExcuteName() => "sa.PointDensity";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointFeatures, PopulationField, OutRaster, CellSize, Neighborhood, AreaUnitScaleFactor };

		/// <summary>
		/// <para>Input point features</para>
		/// <para>The input point features for which to calculate the density.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer")]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		[GeometryType("Point", "Multipoint")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Population field</para>
		/// <para>Field denoting population values for each point. The population field is the count or quantity to be used in the calculation of a continuous surface.</para>
		/// <para>Values in the population field can be integer or floating point.</para>
		/// <para>The options and default behaviors for the field are listed below.</para>
		/// <para>Use None if no item or special value will be used and each feature will be counted once.</para>
		/// <para>You can use the Shape field if input features contain Z.</para>
		/// <para>Otherwise, the default field is POPULATION. The following conditions may also apply:</para>
		/// <para>If there is no POPULATION field, but there is a POPULATIONxxxx field, it will be used by default. The xxxx can be any valid characters, for example, POPULATION6, POPULATION1974, and POPULATIONROADTYPE.</para>
		/// <para>If there is no POPULATION field or POPULATIONxxxx field, but there is a POP field, it will be used by default.</para>
		/// <para>If there is no POPULATION field, POPULATIONxxxx field, or POP field, but there is a POPxxxx field, it will be used by default.</para>
		/// <para>If there is no POPULATION field, POPULATIONxxxx field, POP field, or POPxxxx field, NONE will be used by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		[KeyField("NONE")]
		public object PopulationField { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output point density raster.</para>
		/// <para>It is always a floating point raster.</para>
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
		/// <para>Neighborhood</para>
		/// <para>Dictates the shape of the area around each cell that is used to calculate the density value.</para>
		/// <para>Annulus—A torus (donut shaped) neighborhood defined by an inner and outer radius.</para>
		/// <para>Circle—A circular neighborhood with the given radius. This is default where the radius is the shortest of the width or height of the extent of the input point features, in the output spatial reference, divided by 30.</para>
		/// <para>Rectangle—A rectangular neighborhood with the given height and width.</para>
		/// <para>Wedge—A wedge-shaped neighborhood. A wedge is specified by a start angle, an end angle and a radius. The wedge extends counterclockwise from the starting angle to the ending angle. Angles are specified in arithmetic degrees (counterclockwise from the positive x-axis). Negative angles may be used.</para>
		/// <para>Cell | Map—Defines the units of the selected neighborhood measurements in either cells or map units (based on the linear unit of the projection of the output spatial reference).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSANeighborhood()]
		[GPSANeighborhoodDomain()]
		[NeighbourType("Rectangle", "Circle", "Annulus", "Wedge")]
		public object Neighborhood { get; set; } = "Circle 0 MAP";

		/// <summary>
		/// <para>Area units</para>
		/// <para>The area units of the output density values.</para>
		/// <para>A default unit is selected based on the linear unit of the output spatial reference. You can change this to the appropriate unit if you want to convert the density output. Values for line density convert the units of both length and area.</para>
		/// <para>If no output spatial reference is specified, the output spatial reference will be the same as the input feature class. The default output density units are determined by the linear units of the output spatial reference as follows. If the output linear units are meters, the output area density units will be set to Square kilometers, outputting square kilometers for point features or kilometers per square kilometers for polyline features. If the output linear units are feet, the output area density units will be set to Square miles.</para>
		/// <para>If the output units is anything other than feet or meters, the output area density units will be set to Square map units. That is, the output density units will be the square of the linear units of the output spatial reference. For example, if the output linear units are centimeters, the output area density units will be Square map units, which will result in square centimeters. If the output linear units are kilometers, the output area density units will be Square map units, which will result in square kilometers.</para>
		/// <para>The available options and their corresponding output density units are the following:</para>
		/// <para>Square map units—For the square of the linear units of the output spatial reference.</para>
		/// <para>Square miles—For miles (U.S.).</para>
		/// <para>Square kilometers—For kilometers.</para>
		/// <para>Acres—For acres (U.S.).</para>
		/// <para>Hectares—For hectares.</para>
		/// <para>Square yards—For yards (U.S.).</para>
		/// <para>Square feet—For feet (U.S.).</para>
		/// <para>Square inches—For inches (U.S.).</para>
		/// <para>Square meters—For meters.</para>
		/// <para>Square centimeters—For centimeters.</para>
		/// <para>Square millimeters—For millimeters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AreaUnitScaleFactor { get; set; } = "SQUARE_MAP_UNITS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PointDensity SetEnviroment(int? autoCommit = null , object cellSize = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
