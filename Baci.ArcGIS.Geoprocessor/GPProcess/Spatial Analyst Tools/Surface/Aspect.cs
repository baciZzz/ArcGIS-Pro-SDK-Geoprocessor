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
	/// <para>Aspect</para>
	/// <para>Aspect</para>
	/// <para>Derives the aspect from each cell of a raster surface.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.SurfaceParameters"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.SurfaceParameters))]
	public class Aspect : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input surface raster.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output aspect raster.</para>
		/// <para>It will be floating-point type.</para>
		/// </param>
		public Aspect(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Aspect</para>
		/// </summary>
		public override string DisplayName() => "Aspect";

		/// <summary>
		/// <para>Tool Name : Aspect</para>
		/// </summary>
		public override string ToolName() => "Aspect";

		/// <summary>
		/// <para>Tool Excute Name : sa.Aspect</para>
		/// </summary>
		public override string ExcuteName() => "sa.Aspect";

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
		public override object[] Parameters() => new object[] { InRaster, OutRaster, Method!, ZUnit!, ProjectGeodesicAzimuths! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input surface raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = true)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output aspect raster.</para>
		/// <para>It will be floating-point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>Specifies whether the calculation will be based on a planar (flat earth) or a geodesic (ellipsoid) method.</para>
		/// <para>Planar—The calculation will be performed on a projected flat plane using a 2D Cartesian coordinate system. This is the default method.</para>
		/// <para>Geodesic—The calculation will be performed in a 3D Cartesian coordinate system by considering the shape of the earth as an ellipsoid.</para>
		/// <para>The planar method is appropriate to use on local areas in a projection that maintains correct distance and area. It is suitable for analyses that cover areas such cities, counties, or smaller states in area. The geodesic method produces a more accurate result, at the potential cost of an increase in processing time.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Z unit</para>
		/// <para>The linear unit of vertical z-values.</para>
		/// <para>It is defined by a vertical coordinate system if it exists. If a vertical coordinate system does not exist, the z-unit should be defined from the unit list to ensure correct geodesic computation. The default is meter.</para>
		/// <para>Inch—The linear unit will be inches.</para>
		/// <para>Foot—The linear unit will be feet.</para>
		/// <para>Yard—The linear unit will be yards.</para>
		/// <para>Mile US—The linear unit will be miles.</para>
		/// <para>Nautical mile—The linear unit will be nautical miles.</para>
		/// <para>Millimeter—The linear unit will be millimeters.</para>
		/// <para>Centimeter—The linear unit will be centimeters.</para>
		/// <para>Meter—The linear unit will be meters.</para>
		/// <para>Kilometer—The linear unit will be kilometers.</para>
		/// <para>Decimeter—The linear unit will be decimeters.</para>
		/// <para><see cref="ZUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ZUnit { get; set; } = "METER";

		/// <summary>
		/// <para>Project geodesic azimuths</para>
		/// <para>Specifies whether geodesic azimuths will be projected to correct the angle distortion caused by the output spatial reference.</para>
		/// <para>Unchecked—Geodesic azimuths will not be projected. This is the default.</para>
		/// <para>Checked—Geodesic azimuths will be projected.</para>
		/// <para><see cref="ProjectGeodesicAzimuthsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ProjectGeodesicAzimuths { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Aspect SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Planar—The calculation will be performed on a projected flat plane using a 2D Cartesian coordinate system. This is the default method.</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("Planar")]
			Planar,

			/// <summary>
			/// <para>Geodesic—The calculation will be performed in a 3D Cartesian coordinate system by considering the shape of the earth as an ellipsoid.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

		}

		/// <summary>
		/// <para>Z unit</para>
		/// </summary>
		public enum ZUnitEnum 
		{
			/// <summary>
			/// <para>Inch—The linear unit will be inches.</para>
			/// </summary>
			[GPValue("INCH")]
			[Description("Inch")]
			Inch,

			/// <summary>
			/// <para>Foot—The linear unit will be feet.</para>
			/// </summary>
			[GPValue("FOOT")]
			[Description("Foot")]
			Foot,

			/// <summary>
			/// <para>Yard—The linear unit will be yards.</para>
			/// </summary>
			[GPValue("YARD")]
			[Description("Yard")]
			Yard,

			/// <summary>
			/// <para>Mile US—The linear unit will be miles.</para>
			/// </summary>
			[GPValue("MILE_US")]
			[Description("Mile US")]
			Mile_US,

			/// <summary>
			/// <para>Nautical mile—The linear unit will be nautical miles.</para>
			/// </summary>
			[GPValue("NAUTICAL_MILE")]
			[Description("Nautical mile")]
			Nautical_mile,

			/// <summary>
			/// <para>Millimeter—The linear unit will be millimeters.</para>
			/// </summary>
			[GPValue("MILLIMETER")]
			[Description("Millimeter")]
			Millimeter,

			/// <summary>
			/// <para>Centimeter—The linear unit will be centimeters.</para>
			/// </summary>
			[GPValue("CENTIMETER")]
			[Description("Centimeter")]
			Centimeter,

			/// <summary>
			/// <para>Meter—The linear unit will be meters.</para>
			/// </summary>
			[GPValue("METER")]
			[Description("Meter")]
			Meter,

			/// <summary>
			/// <para>Kilometer—The linear unit will be kilometers.</para>
			/// </summary>
			[GPValue("KILOMETER")]
			[Description("Kilometer")]
			Kilometer,

			/// <summary>
			/// <para>Decimeter—The linear unit will be decimeters.</para>
			/// </summary>
			[GPValue("DECIMETER")]
			[Description("Decimeter")]
			Decimeter,

		}

		/// <summary>
		/// <para>Project geodesic azimuths</para>
		/// </summary>
		public enum ProjectGeodesicAzimuthsEnum 
		{
			/// <summary>
			/// <para>Unchecked—Geodesic azimuths will not be projected. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("GEODESIC_AZIMUTHS")]
			GEODESIC_AZIMUTHS,

			/// <summary>
			/// <para>Checked—Geodesic azimuths will be projected.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PROJECT_GEODESIC_AZIMUTHS")]
			PROJECT_GEODESIC_AZIMUTHS,

		}

#endregion
	}
}
