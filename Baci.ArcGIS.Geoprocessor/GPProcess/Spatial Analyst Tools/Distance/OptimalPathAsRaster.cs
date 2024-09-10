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
	/// <para>Optimal Path As Raster</para>
	/// <para>Calculates the optimal path from a source to a destination as a raster.</para>
	/// </summary>
	public class OptimalPathAsRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDestinationData">
		/// <para>Input raster or feature destination data</para>
		/// <para>An integer raster or feature dataset that identifies locations from which the optimal path is determined to the least costly source.</para>
		/// <para>If the input is a raster, it must consist of cells that have valid values for the destinations, and the remaining cells must be assigned NoData. Zero is a valid value.</para>
		/// </param>
		/// <param name="InDistanceAccumulationRaster">
		/// <para>Input distance accumulation raster</para>
		/// <para>The distance accumulation raster is used to determine the optimal path from the sources to the destinations.</para>
		/// <para>The distance accumulation raster is usually created with the Distance Accumulation or Distance Allocation tools. Each cell in the distance accumulation raster represents the minimum accumulative cost distance over a surface from each cell to a set of source cells.</para>
		/// </param>
		/// <param name="InBackDirectionRaster">
		/// <para>Input back direction or flow direction raster</para>
		/// <para>The back direction raster contains calculated directions in degrees. The direction identifies the next cell along the optimal path back to the least accumulative cost source while avoiding barriers.</para>
		/// <para>The range of values is from 0 degrees to 360 degrees, with 0 reserved for the source cells. Due east (right) is 90, and the values increase clockwise (180 is south, 270 is west, and 360 is north).</para>
		/// </param>
		/// <param name="OutPathAccumulationRaster">
		/// <para>Output optimal accumulation path</para>
		/// <para>The output raster.</para>
		/// </param>
		public OptimalPathAsRaster(object InDestinationData, object InDistanceAccumulationRaster, object InBackDirectionRaster, object OutPathAccumulationRaster)
		{
			this.InDestinationData = InDestinationData;
			this.InDistanceAccumulationRaster = InDistanceAccumulationRaster;
			this.InBackDirectionRaster = InBackDirectionRaster;
			this.OutPathAccumulationRaster = OutPathAccumulationRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Optimal Path As Raster</para>
		/// </summary>
		public override string DisplayName() => "Optimal Path As Raster";

		/// <summary>
		/// <para>Tool Name : OptimalPathAsRaster</para>
		/// </summary>
		public override string ToolName() => "OptimalPathAsRaster";

		/// <summary>
		/// <para>Tool Excute Name : sa.OptimalPathAsRaster</para>
		/// </summary>
		public override string ExcuteName() => "sa.OptimalPathAsRaster";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "compression", "configKeyword", "scratchWorkspace", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDestinationData, InDistanceAccumulationRaster, InBackDirectionRaster, OutPathAccumulationRaster, DestinationField, PathType };

		/// <summary>
		/// <para>Input raster or feature destination data</para>
		/// <para>An integer raster or feature dataset that identifies locations from which the optimal path is determined to the least costly source.</para>
		/// <para>If the input is a raster, it must consist of cells that have valid values for the destinations, and the remaining cells must be assigned NoData. Zero is a valid value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InDestinationData { get; set; }

		/// <summary>
		/// <para>Input distance accumulation raster</para>
		/// <para>The distance accumulation raster is used to determine the optimal path from the sources to the destinations.</para>
		/// <para>The distance accumulation raster is usually created with the Distance Accumulation or Distance Allocation tools. Each cell in the distance accumulation raster represents the minimum accumulative cost distance over a surface from each cell to a set of source cells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InDistanceAccumulationRaster { get; set; }

		/// <summary>
		/// <para>Input back direction or flow direction raster</para>
		/// <para>The back direction raster contains calculated directions in degrees. The direction identifies the next cell along the optimal path back to the least accumulative cost source while avoiding barriers.</para>
		/// <para>The range of values is from 0 degrees to 360 degrees, with 0 reserved for the source cells. Due east (right) is 90, and the values increase clockwise (180 is south, 270 is west, and 360 is north).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InBackDirectionRaster { get; set; }

		/// <summary>
		/// <para>Output optimal accumulation path</para>
		/// <para>The output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutPathAccumulationRaster { get; set; }

		/// <summary>
		/// <para>Destination field</para>
		/// <para>The field to be used to obtain values for the destination locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long")]
		public object DestinationField { get; set; }

		/// <summary>
		/// <para>Path type</para>
		/// <para>Specifies a keyword defining the manner in which the values and zones on the input destination data will be interpreted in the cost path calculations.</para>
		/// <para>Each zone—For each zone on the input destination data, a least-cost path is determined and saved on the output raster. With this option, the least-cost path for each zone begins at the cell with the lowest cost distance weighting in the zone.</para>
		/// <para>Best single—For all cells on the input destination data, the least-cost path is derived from the cell with the minimum of the least-cost paths to source cells.</para>
		/// <para>Each cell—For each cell with valid values on the input destination data, a least-cost path is determined and saved on the output raster. With this option, each cell of the input destination data is treated separately, and a least-cost path is determined for each cell.</para>
		/// <para><see cref="PathTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PathType { get; set; } = "EACH_ZONE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public OptimalPathAsRaster SetEnviroment(int? autoCommit = null , object compression = null , object configKeyword = null , object scratchWorkspace = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, compression: compression, configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Path type</para>
		/// </summary>
		public enum PathTypeEnum 
		{
			/// <summary>
			/// <para>Each cell—For each cell with valid values on the input destination data, a least-cost path is determined and saved on the output raster. With this option, each cell of the input destination data is treated separately, and a least-cost path is determined for each cell.</para>
			/// </summary>
			[GPValue("EACH_CELL")]
			[Description("Each cell")]
			Each_cell,

			/// <summary>
			/// <para>Each zone—For each zone on the input destination data, a least-cost path is determined and saved on the output raster. With this option, the least-cost path for each zone begins at the cell with the lowest cost distance weighting in the zone.</para>
			/// </summary>
			[GPValue("EACH_ZONE")]
			[Description("Each zone")]
			Each_zone,

			/// <summary>
			/// <para>Best single—For all cells on the input destination data, the least-cost path is derived from the cell with the minimum of the least-cost paths to source cells.</para>
			/// </summary>
			[GPValue("BEST_SINGLE")]
			[Description("Best single")]
			Best_single,

		}

#endregion
	}
}
