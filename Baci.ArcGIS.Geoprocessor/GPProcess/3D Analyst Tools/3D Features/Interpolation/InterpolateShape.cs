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
	/// <para>Interpolate Shape</para>
	/// <para>Interpolate Shape</para>
	/// <para>Creates 3D features by interpolating z-values from a surface.</para>
	/// </summary>
	public class InterpolateShape : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>The surface to use for interpolating z-values.</para>
		/// </param>
		/// <param name="InFeatureClass">
		/// <para>Input Features</para>
		/// <para>The input features to process.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </param>
		public InterpolateShape(object InSurface, object InFeatureClass, object OutFeatureClass)
		{
			this.InSurface = InSurface;
			this.InFeatureClass = InFeatureClass;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Interpolate Shape</para>
		/// </summary>
		public override string DisplayName() => "Interpolate Shape";

		/// <summary>
		/// <para>Tool Name : InterpolateShape</para>
		/// </summary>
		public override string ToolName() => "InterpolateShape";

		/// <summary>
		/// <para>Tool Excute Name : 3d.InterpolateShape</para>
		/// </summary>
		public override string ExcuteName() => "3d.InterpolateShape";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurface, InFeatureClass, OutFeatureClass, SampleDistance!, ZFactor!, Method!, VerticesOnly!, PyramidLevelResolution!, PreserveFeatures! };

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>The surface to use for interpolating z-values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon", "Point", "Multipoint")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Sampling Distance</para>
		/// <para>The spacing at which z-values will be interpolated. By default, this is a raster dataset's cell size or a triangulated surface's natural densification.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SampleDistance { get; set; }

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>The factor by which z-values will be multiplied. This is typically used to convert z linear units to match x,y linear units. The default is 1, which leaves elevation values unchanged. This parameter is not available if the spatial reference of the input surface has a z datum with a specified linear unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Method</para>
		/// <para>Interpolation method used to determine elevation values for the output features. The available options depend on the surface type being used.</para>
		/// <para>Bilinear—Determines the value of the query point using bilinear interpolation. This is the default when the input is a raster surface.</para>
		/// <para>Nearest Neighbor—Determines the value of the query point using nearest neighbor interpolation. When this method is used, surface values will only be interpolated for the input feature&apos;s vertices. This option is only available for a raster surface.</para>
		/// <para>Linear— Default interpolation method for TIN, terrain, and LAS dataset. It obtains elevation from the plane defined by the triangle that contains the XY location of a query point.</para>
		/// <para>Natural Neighbors— Obtains elevation by applying area-based weights to the natural neighbors of a query point.</para>
		/// <para>Conflate Minimum Z— Obtains elevation from the smallest z-value found among the natural neighbors of a query point.</para>
		/// <para>Conflate Maximum Z— Obtains elevation from the largest z-value found among the natural neighbors of a query point.</para>
		/// <para>Conflate Nearest Z— Obtains elevation from the nearest value among the natural neighbors of a query point.</para>
		/// <para>Conflate Z Closest To Mean— Obtains elevation from the z-value that is closest to the average of all the natural neighbors of a query point.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Interpolate Vertices Only</para>
		/// <para>Specifies whether the interpolation will only occur along the vertices of an input feature, thereby ignoring the sample distance option. When the input surface is a raster and nearest neighbor interpolation method is selected, the z-values can only be interpolated at the feature vertices.</para>
		/// <para>Checked—Interpolates along the vertices.</para>
		/// <para>Unchecked—Interpolates using the sampling distance. This is the default.</para>
		/// <para><see cref="VerticesOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? VerticesOnly { get; set; } = "false";

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>The z-tolerance or window-size resolution of the terrain pyramid level that will be used. The default is 0, or full resolution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Preserve features partially outside surface</para>
		/// <para>Specifies whether features with one or more vertices that fall outside the raster&apos;s data area will be retained in the output. This parameter is only available when the input surface is a raster and the nearest neighbor interpolation method is used.</para>
		/// <para>Checked—Each vertex that falls outside the raster surface will have its z-value derived from the trend of z-values calculated for the vertices within the raster surface.</para>
		/// <para>Unchecked—Features with at least one vertex that falls outside the raster surface will be skipped in the output. This is the default.</para>
		/// <para><see cref="PreserveFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? PreserveFeatures { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public InterpolateShape SetEnviroment(object? XYResolution = null , object? XYTolerance = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Linear— Default interpolation method for TIN, terrain, and LAS dataset. It obtains elevation from the plane defined by the triangle that contains the XY location of a query point.</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("Linear")]
			Linear,

			/// <summary>
			/// <para>Natural Neighbors— Obtains elevation by applying area-based weights to the natural neighbors of a query point.</para>
			/// </summary>
			[GPValue("NATURAL_NEIGHBORS")]
			[Description("Natural Neighbors")]
			Natural_Neighbors,

			/// <summary>
			/// <para>Conflate Minimum Z— Obtains elevation from the smallest z-value found among the natural neighbors of a query point.</para>
			/// </summary>
			[GPValue("CONFLATE_ZMIN")]
			[Description("Conflate Minimum Z")]
			Conflate_Minimum_Z,

			/// <summary>
			/// <para>Conflate Maximum Z— Obtains elevation from the largest z-value found among the natural neighbors of a query point.</para>
			/// </summary>
			[GPValue("CONFLATE_ZMAX")]
			[Description("Conflate Maximum Z")]
			Conflate_Maximum_Z,

			/// <summary>
			/// <para>Conflate Nearest Z— Obtains elevation from the nearest value among the natural neighbors of a query point.</para>
			/// </summary>
			[GPValue("CONFLATE_NEAREST")]
			[Description("Conflate Nearest Z")]
			Conflate_Nearest_Z,

			/// <summary>
			/// <para>Conflate Z Closest To Mean— Obtains elevation from the z-value that is closest to the average of all the natural neighbors of a query point.</para>
			/// </summary>
			[GPValue("CONFLATE_CLOSEST_TO_MEAN")]
			[Description("Conflate Z Closest To Mean")]
			Conflate_Z_Closest_To_Mean,

			/// <summary>
			/// <para>Bilinear—Determines the value of the query point using bilinear interpolation. This is the default when the input is a raster surface.</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("Bilinear")]
			Bilinear,

			/// <summary>
			/// <para>Nearest Neighbor—Determines the value of the query point using nearest neighbor interpolation. When this method is used, surface values will only be interpolated for the input feature&apos;s vertices. This option is only available for a raster surface.</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("Nearest Neighbor")]
			Nearest_Neighbor,

		}

		/// <summary>
		/// <para>Interpolate Vertices Only</para>
		/// </summary>
		public enum VerticesOnlyEnum 
		{
			/// <summary>
			/// <para>Checked—Interpolates along the vertices.</para>
			/// </summary>
			[GPValue("true")]
			[Description("VERTICES_ONLY")]
			VERTICES_ONLY,

			/// <summary>
			/// <para>Unchecked—Interpolates using the sampling distance. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DENSIFY")]
			DENSIFY,

		}

		/// <summary>
		/// <para>Preserve features partially outside surface</para>
		/// </summary>
		public enum PreserveFeaturesEnum 
		{
			/// <summary>
			/// <para>Checked—Each vertex that falls outside the raster surface will have its z-value derived from the trend of z-values calculated for the vertices within the raster surface.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE")]
			PRESERVE,

			/// <summary>
			/// <para>Unchecked—Features with at least one vertex that falls outside the raster surface will be skipped in the output. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE")]
			EXCLUDE,

		}

#endregion
	}
}
