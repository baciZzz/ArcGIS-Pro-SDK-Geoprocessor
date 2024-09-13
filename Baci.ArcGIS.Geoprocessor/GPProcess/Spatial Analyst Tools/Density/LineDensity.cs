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
	/// <para>Line Density</para>
	/// <para>Line Density</para>
	/// <para>Calculates a magnitude-per-unit area from polyline features that fall within a radius around each cell.</para>
	/// </summary>
	public class LineDensity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPolylineFeatures">
		/// <para>Input polyline features</para>
		/// <para>The input line features for which to calculate the density.</para>
		/// </param>
		/// <param name="PopulationField">
		/// <para>Population field</para>
		/// <para>Numeric field denoting population values (the number of times the line should be counted) for each polyline.</para>
		/// <para>Values in the population field can be integer or floating point.</para>
		/// <para>The options and default behaviors for the field are listed below.</para>
		/// <para>Use None if no item or special value will be used and each feature will be counted once.</para>
		/// <para>You can use the Shape field if input features contain Z-values.</para>
		/// <para>Otherwise, the default field is POPULATION. The following conditions may also apply:</para>
		/// <para>If there is no POPULATION field, but there is a POPULATIONxxxx field, it will be used by default. The xxxx can be any valid characters, for example, POPULATION6, POPULATION1974, and POPULATIONROADTYPE.</para>
		/// <para>If there is no POPULATION field or POPULATIONxxxx field but there is a POP field, POP field will be used by default.</para>
		/// <para>If there is no POPULATION field, POPULATIONxxxx field, or POP field, but there is a POPxxxx field, POPxxxx field will be used by default.</para>
		/// <para>If there is no POPULATION field, POPULATIONxxxx field, POP field, or POPxxxx field, NONE will be used by default.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output line density raster.</para>
		/// <para>It is always a floating point raster.</para>
		/// </param>
		public LineDensity(object InPolylineFeatures, object PopulationField, object OutRaster)
		{
			this.InPolylineFeatures = InPolylineFeatures;
			this.PopulationField = PopulationField;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Line Density</para>
		/// </summary>
		public override string DisplayName() => "Line Density";

		/// <summary>
		/// <para>Tool Name : LineDensity</para>
		/// </summary>
		public override string ToolName() => "LineDensity";

		/// <summary>
		/// <para>Tool Excute Name : sa.LineDensity</para>
		/// </summary>
		public override string ExcuteName() => "sa.LineDensity";

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
		public override object[] Parameters() => new object[] { InPolylineFeatures, PopulationField, OutRaster, CellSize!, SearchRadius!, AreaUnitScaleFactor! };

		/// <summary>
		/// <para>Input polyline features</para>
		/// <para>The input line features for which to calculate the density.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer", "GPTableView", "DETextFile")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Polyline")]
		public object InPolylineFeatures { get; set; }

		/// <summary>
		/// <para>Population field</para>
		/// <para>Numeric field denoting population values (the number of times the line should be counted) for each polyline.</para>
		/// <para>Values in the population field can be integer or floating point.</para>
		/// <para>The options and default behaviors for the field are listed below.</para>
		/// <para>Use None if no item or special value will be used and each feature will be counted once.</para>
		/// <para>You can use the Shape field if input features contain Z-values.</para>
		/// <para>Otherwise, the default field is POPULATION. The following conditions may also apply:</para>
		/// <para>If there is no POPULATION field, but there is a POPULATIONxxxx field, it will be used by default. The xxxx can be any valid characters, for example, POPULATION6, POPULATION1974, and POPULATIONROADTYPE.</para>
		/// <para>If there is no POPULATION field or POPULATIONxxxx field but there is a POP field, POP field will be used by default.</para>
		/// <para>If there is no POPULATION field, POPULATIONxxxx field, or POP field, but there is a POPxxxx field, POPxxxx field will be used by default.</para>
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
		/// <para>The output line density raster.</para>
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
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Search radius</para>
		/// <para>The search radius within which density will be calculated. Units are based on the linear unit of the projection of the output spatial reference.</para>
		/// <para>For example, if the units are meters—to include all features within a one-mile neighborhood—set the search radius equal to 1609.344 (1 mile = 1609.344 meters).</para>
		/// <para>The default is the shortest of the width or height of the output extent in the output spatial reference, divided by 30.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? SearchRadius { get; set; }

		/// <summary>
		/// <para>Area units</para>
		/// <para>The area units of the output density values.</para>
		/// <para>A default unit is selected based on the linear unit of the output spatial reference. You can change this to the appropriate unit to convert the density output. Values for line density convert the units of both length and area.</para>
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
		public object? AreaUnitScaleFactor { get; set; } = "SQUARE_MAP_UNITS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LineDensity SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
