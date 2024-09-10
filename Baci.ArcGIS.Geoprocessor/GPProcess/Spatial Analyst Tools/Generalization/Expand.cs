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
	/// <para>Expand</para>
	/// <para>Expands specified zones of a raster by a specified number of cells.</para>
	/// </summary>
	public class Expand : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster for which the identified zones are to be expanded</para>
		/// <para>It must be of integer type.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output generalized raster.</para>
		/// <para>The specified zones of the input raster will be expanded by the specified number of cells.</para>
		/// <para>The output is always of integer type.</para>
		/// </param>
		/// <param name="NumberCells">
		/// <para>Number of cells</para>
		/// <para>The number of cells to expand each specified zone by.</para>
		/// <para>The value must be an integer greater than 1.</para>
		/// </param>
		/// <param name="ZoneValues">
		/// <para>Zone values</para>
		/// <para>The list of zone values to expand.</para>
		/// <para>The zone values must be integers. They can be in any order.</para>
		/// </param>
		public Expand(object InRaster, object OutRaster, object NumberCells, object ZoneValues)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
			this.NumberCells = NumberCells;
			this.ZoneValues = ZoneValues;
		}

		/// <summary>
		/// <para>Tool Display Name : Expand</para>
		/// </summary>
		public override string DisplayName() => "Expand";

		/// <summary>
		/// <para>Tool Name : Expand</para>
		/// </summary>
		public override string ToolName() => "Expand";

		/// <summary>
		/// <para>Tool Excute Name : sa.Expand</para>
		/// </summary>
		public override string ExcuteName() => "sa.Expand";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, NumberCells, ZoneValues, ExpandMethod };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster for which the identified zones are to be expanded</para>
		/// <para>It must be of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output generalized raster.</para>
		/// <para>The specified zones of the input raster will be expanded by the specified number of cells.</para>
		/// <para>The output is always of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Number of cells</para>
		/// <para>The number of cells to expand each specified zone by.</para>
		/// <para>The value must be an integer greater than 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPNumericDomain()]
		public object NumberCells { get; set; }

		/// <summary>
		/// <para>Zone values</para>
		/// <para>The list of zone values to expand.</para>
		/// <para>The zone values must be integers. They can be in any order.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object ZoneValues { get; set; }

		/// <summary>
		/// <para>Expand method</para>
		/// <para>The method used to expand the selected zones.</para>
		/// <para>Morphological—Uses a mathematical morphology method to expand the zones. This is the default.</para>
		/// <para>Distance—Uses a distance-based method to expand the zones.</para>
		/// <para>The Distance option supports parallelization, and can be controlled with the Parallel Processing Factor environment setting.</para>
		/// <para><see cref="ExpandMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ExpandMethod { get; set; } = "MORPHOLOGICAL";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Expand SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Expand method</para>
		/// </summary>
		public enum ExpandMethodEnum 
		{
			/// <summary>
			/// <para>Morphological—Uses a mathematical morphology method to expand the zones. This is the default.</para>
			/// </summary>
			[GPValue("MORPHOLOGICAL")]
			[Description("Morphological")]
			Morphological,

			/// <summary>
			/// <para>Distance—Uses a distance-based method to expand the zones.</para>
			/// </summary>
			[GPValue("DISTANCE")]
			[Description("Distance")]
			Distance,

		}

#endregion
	}
}
