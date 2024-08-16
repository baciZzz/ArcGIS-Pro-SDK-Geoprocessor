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
	/// <para>Fuzzy Overlay</para>
	/// <para>Combine fuzzy membership rasters data together, based on selected overlay type.</para>
	/// </summary>
	public class FuzzyOverlay : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasters">
		/// <para>Input rasters</para>
		/// <para>A list of input membership rasters to be combined in the overlay.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster which is the result of applying the fuzzy operator.</para>
		/// <para>This output will always have a value between 0 and 1.</para>
		/// </param>
		public FuzzyOverlay(object InRasters, object OutRaster)
		{
			this.InRasters = InRasters;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Fuzzy Overlay</para>
		/// </summary>
		public override string DisplayName => "Fuzzy Overlay";

		/// <summary>
		/// <para>Tool Name : FuzzyOverlay</para>
		/// </summary>
		public override string ToolName => "FuzzyOverlay";

		/// <summary>
		/// <para>Tool Excute Name : sa.FuzzyOverlay</para>
		/// </summary>
		public override string ExcuteName => "sa.FuzzyOverlay";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRasters, OutRaster, OverlayType, Gamma };

		/// <summary>
		/// <para>Input rasters</para>
		/// <para>A list of input membership rasters to be combined in the overlay.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasters { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster which is the result of applying the fuzzy operator.</para>
		/// <para>This output will always have a value between 0 and 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Overlay type</para>
		/// <para>Specifies the method used to combine two or more membership data.</para>
		/// <para>And—The minimum of the fuzzy memberships from the input fuzzy rasters.</para>
		/// <para>Or—The maximum of the fuzzy memberships from the input rasters.</para>
		/// <para>Product—A decreasive function. Use this when the combination of multiple evidence is less important or smaller than any of the inputs alone.</para>
		/// <para>Sum—An increasive function. Use this when the combination of multiple evidence is more important or larger than any of the inputs alone.</para>
		/// <para>Gamma—The algebraic product of the fuzzy Sum and fuzzy Product, both raised to the power of gamma.</para>
		/// <para><see cref="OverlayTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OverlayType { get; set; } = "AND";

		/// <summary>
		/// <para>Gamma</para>
		/// <para>The gamma value to be used. This is only available when the Overlay type is set to Gamma.</para>
		/// <para>Default value is 0.9.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 1)]
		public object Gamma { get; set; } = "0.9";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FuzzyOverlay SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Overlay type</para>
		/// </summary>
		public enum OverlayTypeEnum 
		{
			/// <summary>
			/// <para>And—The minimum of the fuzzy memberships from the input fuzzy rasters.</para>
			/// </summary>
			[GPValue("AND")]
			[Description("And")]
			And,

			/// <summary>
			/// <para>Or—The maximum of the fuzzy memberships from the input rasters.</para>
			/// </summary>
			[GPValue("OR")]
			[Description("Or")]
			Or,

			/// <summary>
			/// <para>Sum—An increasive function. Use this when the combination of multiple evidence is more important or larger than any of the inputs alone.</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("Sum")]
			Sum,

			/// <summary>
			/// <para>Product—A decreasive function. Use this when the combination of multiple evidence is less important or smaller than any of the inputs alone.</para>
			/// </summary>
			[GPValue("PRODUCT")]
			[Description("Product")]
			Product,

			/// <summary>
			/// <para>Gamma—The algebraic product of the fuzzy Sum and fuzzy Product, both raised to the power of gamma.</para>
			/// </summary>
			[GPValue("GAMMA")]
			[Description("Gamma")]
			Gamma,

		}

#endregion
	}
}
