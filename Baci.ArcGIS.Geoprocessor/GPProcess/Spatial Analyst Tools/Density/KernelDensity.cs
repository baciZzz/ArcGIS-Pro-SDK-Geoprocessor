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
	/// <para>Kernel Density</para>
	/// <para>Kernel Density</para>
	/// <para>Calculates a magnitude-per-unit area from point or polyline features using a kernel function to fit a smoothly tapered surface to each point or polyline. A barrier can be used to alter the influence of a feature while calculating Kernel Density.</para>
	/// </summary>
	public class KernelDensity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input point or polyline features</para>
		/// <para>The input features (point or line) for which to calculate the density.</para>
		/// </param>
		/// <param name="PopulationField">
		/// <para>Population field</para>
		/// <para>The field denoting population values for each feature. The population field is the count or quantity to be spread across the landscape to create a continuous surface.</para>
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
		/// <para>The output kernel density raster.</para>
		/// <para>It is always a floating point raster.</para>
		/// </param>
		public KernelDensity(object InFeatures, object PopulationField, object OutRaster)
		{
			this.InFeatures = InFeatures;
			this.PopulationField = PopulationField;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Kernel Density</para>
		/// </summary>
		public override string DisplayName() => "Kernel Density";

		/// <summary>
		/// <para>Tool Name : KernelDensity</para>
		/// </summary>
		public override string ToolName() => "KernelDensity";

		/// <summary>
		/// <para>Tool Excute Name : sa.KernelDensity</para>
		/// </summary>
		public override string ExcuteName() => "sa.KernelDensity";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, PopulationField, OutRaster, CellSize, SearchRadius, AreaUnitScaleFactor, OutCellValues, Method, InBarriers };

		/// <summary>
		/// <para>Input point or polyline features</para>
		/// <para>The input features (point or line) for which to calculate the density.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Multipoint", "Polyline")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Population field</para>
		/// <para>The field denoting population values for each feature. The population field is the count or quantity to be spread across the landscape to create a continuous surface.</para>
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
		/// <para>The output kernel density raster.</para>
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
		/// <para>Search radius</para>
		/// <para>The search radius within which to calculate density. Units are based on the linear unit of the projection of the output spatial reference.</para>
		/// <para>For example, if the units are meters—to include all features within a one-mile neighborhood—set the search radius equal to 1609.344 (1 mile = 1609.344 meters).</para>
		/// <para>The default search radius is computed specifically for the input dataset using a spatial variant of Silverman&apos;s Rule of Thumb (Silverman, 1986) that is robust enough for spatial outliers (points that are far away from the rest of the points). See the usage tips for a description of the algorithm.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object SearchRadius { get; set; }

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
		/// <para>Output cell values</para>
		/// <para>Specifies what the values in the output raster represent.</para>
		/// <para>Densities—The output values represent the calculated density value per unit area for each cell. This is the default.</para>
		/// <para>Expected counts—The output values represent the calculated density value per cell area.</para>
		/// <para>Since the cell value is linked to the specified cell size, the resulting raster cannot be resampled to a different cell size.</para>
		/// <para><see cref="OutCellValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutCellValues { get; set; } = "DENSITIES";

		/// <summary>
		/// <para>Method</para>
		/// <para>Specifies whether the flat earth (planar) or the shortest path on a spheroid (geodesic) method will be used.</para>
		/// <para>Planar—The planar distance between features will be used. This is the default.</para>
		/// <para>Geodesic—The geodesic distance between features will be used.</para>
		/// <para>The geodesic method only supports points as input features.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Input barrier features</para>
		/// <para>The dataset that defines the barriers.</para>
		/// <para>The barriers can be a feature layer of polyline or polygon features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Polyline", "Polygon")]
		public object InBarriers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public KernelDensity SetEnviroment(int? autoCommit = null, object cellSize = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output cell values</para>
		/// </summary>
		public enum OutCellValuesEnum 
		{
			/// <summary>
			/// <para>Densities—The output values represent the calculated density value per unit area for each cell. This is the default.</para>
			/// </summary>
			[GPValue("DENSITIES")]
			[Description("Densities")]
			Densities,

			/// <summary>
			/// <para>Expected counts—The output values represent the calculated density value per cell area.</para>
			/// </summary>
			[GPValue("EXPECTED_COUNTS")]
			[Description("Expected counts")]
			Expected_counts,

		}

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Planar—The planar distance between features will be used. This is the default.</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("Planar")]
			Planar,

			/// <summary>
			/// <para>Geodesic—The geodesic distance between features will be used.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

		}

#endregion
	}
}
