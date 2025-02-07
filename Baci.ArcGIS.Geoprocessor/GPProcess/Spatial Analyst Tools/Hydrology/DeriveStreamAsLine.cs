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
	/// <para>Derive Stream As Line</para>
	/// <para>Derive Stream As Line</para>
	/// <para>Generates stream line features from an input surface raster with no prior sink or depression filling required.</para>
	/// </summary>
	public class DeriveStreamAsLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurfaceRaster">
		/// <para>Input surface raster</para>
		/// <para>The input surface raster.</para>
		/// </param>
		/// <param name="OutStreamFeatures">
		/// <para>Output polyline features</para>
		/// <para>The output feature class that will contain the identified streams.</para>
		/// </param>
		public DeriveStreamAsLine(object InSurfaceRaster, object OutStreamFeatures)
		{
			this.InSurfaceRaster = InSurfaceRaster;
			this.OutStreamFeatures = OutStreamFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Derive Stream As Line</para>
		/// </summary>
		public override string DisplayName() => "Derive Stream As Line";

		/// <summary>
		/// <para>Tool Name : DeriveStreamAsLine</para>
		/// </summary>
		public override string ToolName() => "DeriveStreamAsLine";

		/// <summary>
		/// <para>Tool Excute Name : sa.DeriveStreamAsLine</para>
		/// </summary>
		public override string ExcuteName() => "sa.DeriveStreamAsLine";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurfaceRaster, OutStreamFeatures, InDepressionsData!, InWeightRaster!, AccumulationThreshold!, StreamDesignationMethod!, Simplify! };

		/// <summary>
		/// <para>Input surface raster</para>
		/// <para>The input surface raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Output polyline features</para>
		/// <para>The output feature class that will contain the identified streams.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutStreamFeatures { get; set; }

		/// <summary>
		/// <para>Input raster or feature depressions data</para>
		/// <para>An optional dataset that defines real depressions.</para>
		/// <para>The depressions can be defined either through a raster or a feature layer.</para>
		/// <para>If input is a raster, the depression cells must take a valid value, including zero, and the areas that are not depressions must be NoData.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? InDepressionsData { get; set; }

		/// <summary>
		/// <para>Input accumulation weight raster</para>
		/// <para>An optional input raster dataset that defines the fraction of flow that contributes to flow accumulation at each cell.</para>
		/// <para>The weight is only applied to the accumulation of flow.</para>
		/// <para>If no accumulation weight raster is specified, a default weight of 1 will be applied to each cell.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? InWeightRaster { get; set; }

		/// <summary>
		/// <para>Accumulation threshold</para>
		/// <para>The threshold for determining whether a given cell is part of a stream in terms of the total area that flows into such cell.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object? AccumulationThreshold { get; set; }

		/// <summary>
		/// <para>Stream designation method</para>
		/// <para>Specifies the unique value or order of the streams in the output attribute table.</para>
		/// <para>Constant—The output stream segments will all equal 1. This is the default.</para>
		/// <para>Unique—Each stream will have a unique ID between intersections in the output.</para>
		/// <para>Strahler—The Strahler method, in which stream order only increases when streams of the same order intersect, will be used. The intersection of a first-order and second-order link will remain a second-order link, rather than creating a third-order link.</para>
		/// <para>Shreve—The Shreve method, in which stream order is assigned by magnitude, will be used. All links with no tributaries are assigned a magnitude (order) of one. Magnitudes are additive downslope. When two links intersect, their magnitudes are added and assigned to the downslope link.</para>
		/// <para>Hack— The Hack method, in which each stream segment is assigned an order greater than the stream or river to which it discharges, will be used. For example, the main river channel is assigned an order of 1, all stream segments discharging to it are assigned an order of 2, any stream discharging to an order 2 stream is assigned an order of 3, and so on.</para>
		/// <para>All—The output attribute table will show each stream segment designation based on all methods.</para>
		/// <para><see cref="StreamDesignationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StreamDesignationMethod { get; set; } = "CONSTANT";

		/// <summary>
		/// <para>Simplify features</para>
		/// <para>Specifies whether the output stream lines will be smoothed into simpler shapes.</para>
		/// <para>Unchecked—The stream feature lines will not be smoothed.</para>
		/// <para>Checked—The stream feature lines will be smoothed. This is the default.</para>
		/// <para><see cref="SimplifyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Simplify { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeriveStreamAsLine SetEnviroment(int? autoCommit = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Stream designation method</para>
		/// </summary>
		public enum StreamDesignationMethodEnum 
		{
			/// <summary>
			/// <para>Constant—The output stream segments will all equal 1. This is the default.</para>
			/// </summary>
			[GPValue("CONSTANT")]
			[Description("Constant")]
			Constant,

			/// <summary>
			/// <para>Unique—Each stream will have a unique ID between intersections in the output.</para>
			/// </summary>
			[GPValue("UNIQUE")]
			[Description("Unique")]
			Unique,

			/// <summary>
			/// <para>Strahler—The Strahler method, in which stream order only increases when streams of the same order intersect, will be used. The intersection of a first-order and second-order link will remain a second-order link, rather than creating a third-order link.</para>
			/// </summary>
			[GPValue("STRAHLER")]
			[Description("Strahler")]
			Strahler,

			/// <summary>
			/// <para>Shreve—The Shreve method, in which stream order is assigned by magnitude, will be used. All links with no tributaries are assigned a magnitude (order) of one. Magnitudes are additive downslope. When two links intersect, their magnitudes are added and assigned to the downslope link.</para>
			/// </summary>
			[GPValue("SHREVE")]
			[Description("Shreve")]
			Shreve,

			/// <summary>
			/// <para>Hack— The Hack method, in which each stream segment is assigned an order greater than the stream or river to which it discharges, will be used. For example, the main river channel is assigned an order of 1, all stream segments discharging to it are assigned an order of 2, any stream discharging to an order 2 stream is assigned an order of 3, and so on.</para>
			/// </summary>
			[GPValue("HACK")]
			[Description("Hack")]
			Hack,

			/// <summary>
			/// <para>All—The output attribute table will show each stream segment designation based on all methods.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

		}

		/// <summary>
		/// <para>Simplify features</para>
		/// </summary>
		public enum SimplifyEnum 
		{
			/// <summary>
			/// <para>Checked—The stream feature lines will be smoothed. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SIMPLIFY")]
			SIMPLIFY,

			/// <summary>
			/// <para>Unchecked—The stream feature lines will not be smoothed.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SIMPLIFY")]
			NO_SIMPLIFY,

		}

#endregion
	}
}
