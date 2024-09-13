using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>Radial Basis Functions</para>
	/// <para>Radial Basis Functions</para>
	/// <para>Uses one of five basis functions to interpolate a surfaces that passes through the input points exactly.</para>
	/// </summary>
	public class RadialBasisFunctions : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input features</para>
		/// <para>The input point features containing the z-values to be interpolated.</para>
		/// </param>
		/// <param name="ZField">
		/// <para>Z value field</para>
		/// <para>Field that holds a height or magnitude value for each point. This can be a numeric field or the Shape field if the input features contain z-values or m-values.</para>
		/// </param>
		public RadialBasisFunctions(object InFeatures, object ZField)
		{
			this.InFeatures = InFeatures;
			this.ZField = ZField;
		}

		/// <summary>
		/// <para>Tool Display Name : Radial Basis Functions</para>
		/// </summary>
		public override string DisplayName() => "Radial Basis Functions";

		/// <summary>
		/// <para>Tool Name : RadialBasisFunctions</para>
		/// </summary>
		public override string ToolName() => "RadialBasisFunctions";

		/// <summary>
		/// <para>Tool Excute Name : ga.RadialBasisFunctions</para>
		/// </summary>
		public override string ExcuteName() => "ga.RadialBasisFunctions";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise() => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "coincidentPoints", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ZField, OutGaLayer!, OutRaster!, CellSize!, SearchNeighborhood!, Radial_Basis_Functions!, SmallScaleParameter! };

		/// <summary>
		/// <para>Input features</para>
		/// <para>The input point features containing the z-values to be interpolated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Z value field</para>
		/// <para>Field that holds a height or magnitude value for each point. This can be a numeric field or the Shape field if the input features contain z-values or m-values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ZField { get; set; }

		/// <summary>
		/// <para>Output geostatistical layer</para>
		/// <para>The geostatistical layer produced. This layer is required output only if no output raster is requested.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGALayer()]
		public object? OutGaLayer { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster. This raster is required output only if no output geostatistical layer is requested.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object? OutRaster { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>The cell size at which the output raster will be created.</para>
		/// <para>This value can be explicitly set in the Environments by the Cell Size parameter.</para>
		/// <para>If not set, it is the shorter of the width or the height of the extent of the input point features, in the input spatial reference, divided by 250.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Search neighborhood</para>
		/// <para>Defines which surrounding points will be used to control the output. Standard is the default.</para>
		/// <para>Standard</para>
		/// <para>Major semiaxis—The major semiaxis value of the searching neighborhood.</para>
		/// <para>Minor semiaxis—The minor semiaxis value of the searching neighborhood.</para>
		/// <para>Angle—The angle of rotation for the axis (circle) or semimajor axis (ellipse) of the moving window.</para>
		/// <para>Max neighbors—The maximum number of neighbors that will be used to estimate the value at the unknown location.</para>
		/// <para>Min neighbors—The minimum number of neighbors that will be used to estimate the value at the unknown location.</para>
		/// <para>Sector Type—The geometry of the neighborhood.</para>
		/// <para>One sector—Single ellipse.</para>
		/// <para>Four sectors—Ellipse divided into four sectors.</para>
		/// <para>Four sectors shifted—Ellipse divided into four sectors and shifted 45 degrees.</para>
		/// <para>Eight sectors—Ellipse divided into eight sectors.</para>
		/// <para>Standard Circular</para>
		/// <para>Radius—The length of the radius of the search circle.</para>
		/// <para>Angle—The angle of rotation for the axis (circle) or semimajor axis (ellipse) of the moving window.</para>
		/// <para>Max neighbors—The maximum number of neighbors that will be used to estimate the value at the unknown location.</para>
		/// <para>Min neighbors—The minimum number of neighbors that will be used to estimate the value at the unknown location.</para>
		/// <para>Sector Type—The geometry of the neighborhood.</para>
		/// <para>One sector—Single ellipse.</para>
		/// <para>Four sectors—Ellipse divided into four sectors.</para>
		/// <para>Four sectors shifted—Ellipse divided into four sectors and shifted 45 degrees.</para>
		/// <para>Eight sectors—Ellipse divided into eight sectors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGASearchNeighborhood()]
		[GPGASearchNeighborhoodDomain()]
		[NeighbourType("Standard", "Smooth", "StandardCircular", "SmoothCircular")]
		public object? SearchNeighborhood { get; set; } = "NBRTYPE=Standard S_MAJOR=nan S_MINOR=nan ANGLE=0 NBR_MAX=15 NBR_MIN=10 SECTOR_TYPE=ONE_SECTOR";

		/// <summary>
		/// <para>Radial basis function</para>
		/// <para>There are five radial basis functions available.</para>
		/// <para>Thin plate spline—Thin-plate spline function</para>
		/// <para>Spline with tension— Spline with tension function</para>
		/// <para>Completely regularized spline— Completely regularized spline function</para>
		/// <para>Multiquadric— Multiquadric spline function</para>
		/// <para>Inverse multiquadric—Inverse multiquadric spline function</para>
		/// <para><see cref="Radial_Basis_FunctionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Radial_Basis_Functions { get; set; } = "COMPLETELY_REGULARIZED_SPLINE";

		/// <summary>
		/// <para>Small scale parameter</para>
		/// <para>Used to calculate the weights assigned to the points located in the moving window. Each of the radial basis functions has a parameter that controls the degree of small-scale variation of the surface. The (optimal) parameter is determined by finding the value that minimizes the root mean square prediction error (RMSPE).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 2.2250738585072014e-308, Max = 1.7976931348623157e+308)]
		public object? SmallScaleParameter { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RadialBasisFunctions SetEnviroment(object? cellSize = null , object? coincidentPoints = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? snapRaster = null , object? workspace = null )
		{
			base.SetEnv(cellSize: cellSize, coincidentPoints: coincidentPoints, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Radial basis function</para>
		/// </summary>
		public enum Radial_Basis_FunctionsEnum 
		{
			/// <summary>
			/// <para>Completely regularized spline— Completely regularized spline function</para>
			/// </summary>
			[GPValue("COMPLETELY_REGULARIZED_SPLINE")]
			[Description("Completely regularized spline")]
			Completely_regularized_spline,

			/// <summary>
			/// <para>Spline with tension— Spline with tension function</para>
			/// </summary>
			[GPValue("SPLINE_WITH_TENSION")]
			[Description("Spline with tension")]
			Spline_with_tension,

			/// <summary>
			/// <para>Multiquadric— Multiquadric spline function</para>
			/// </summary>
			[GPValue("MULTIQUADRIC_FUNCTION")]
			[Description("Multiquadric")]
			Multiquadric,

			/// <summary>
			/// <para>Inverse multiquadric—Inverse multiquadric spline function</para>
			/// </summary>
			[GPValue("INVERSE_MULTIQUADRIC_FUNCTION")]
			[Description("Inverse multiquadric")]
			Inverse_multiquadric,

			/// <summary>
			/// <para>Thin plate spline—Thin-plate spline function</para>
			/// </summary>
			[GPValue("THIN_PLATE_SPLINE")]
			[Description("Thin plate spline")]
			Thin_plate_spline,

		}

#endregion
	}
}
