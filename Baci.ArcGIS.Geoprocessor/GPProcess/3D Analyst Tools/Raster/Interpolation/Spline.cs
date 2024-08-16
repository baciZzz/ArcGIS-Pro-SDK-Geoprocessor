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
	/// <para>Spline</para>
	/// <para>Interpolates a raster surface from points using a two-dimensional minimum curvature spline technique.</para>
	/// </summary>
	public class Spline : AbstractGPProcess
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
		public Spline(object InPointFeatures, object ZField, object OutRaster)
		{
			this.InPointFeatures = InPointFeatures;
			this.ZField = ZField;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Spline</para>
		/// </summary>
		public override string DisplayName => "Spline";

		/// <summary>
		/// <para>Tool Name : Spline</para>
		/// </summary>
		public override string ToolName => "Spline";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Spline</para>
		/// </summary>
		public override string ExcuteName => "3d.Spline";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InPointFeatures, ZField, OutRaster, CellSize, SplineType, Weight, NumberPoints };

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
		/// <para>Spline type</para>
		/// <para>The type of spline to be used.</para>
		/// <para>Regularized—Yields a smooth surface and smooth first derivatives.</para>
		/// <para>Tension—Tunes the stiffness of the interpolant according to the character of the modeled phenomenon.</para>
		/// <para><see cref="SplineTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SplineType { get; set; } = "REGULARIZED";

		/// <summary>
		/// <para>Weight</para>
		/// <para>Parameter influencing the character of the surface interpolation.</para>
		/// <para>When the Regularized option is used, it defines the weight of the third derivatives of the surface in the curvature minimization expression. If the Tension option is used, it defines the weight of tension.</para>
		/// <para>The default weight is 0.1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object Weight { get; set; } = "0.1";

		/// <summary>
		/// <para>Number of points</para>
		/// <para>The number of points per region used for local approximation.</para>
		/// <para>The default is 12.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object NumberPoints { get; set; } = "12";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Spline SetEnviroment(int? autoCommit = null , object cellSize = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Spline type</para>
		/// </summary>
		public enum SplineTypeEnum 
		{
			/// <summary>
			/// <para>Regularized—Yields a smooth surface and smooth first derivatives.</para>
			/// </summary>
			[GPValue("REGULARIZED")]
			[Description("Regularized")]
			Regularized,

			/// <summary>
			/// <para>Tension—Tunes the stiffness of the interpolant according to the character of the modeled phenomenon.</para>
			/// </summary>
			[GPValue("TENSION")]
			[Description("Tension")]
			Tension,

		}

#endregion
	}
}
