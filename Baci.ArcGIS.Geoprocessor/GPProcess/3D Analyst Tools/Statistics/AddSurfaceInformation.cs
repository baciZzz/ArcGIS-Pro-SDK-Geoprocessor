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
	/// <para>Add Surface Information</para>
	/// <para>Add Surface Information</para>
	/// <para>Attributes features with statistics derived from a  surface.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddSurfaceInformation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Input Features</para>
		/// <para>The point, multipoint, polyline, or polygon features that define the locations for determining one or more surface properties.</para>
		/// </param>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>The LAS dataset, mosaic, raster, terrain, or TIN surface used for interpolating z-values.</para>
		/// </param>
		/// <param name="OutProperty">
		/// <para>Output Property</para>
		/// <para>Specifies the surface elevation properties that will be added to the attribute table of the input feature class.</para>
		/// <para>Z—The surface z-values interpolated for the x,y-location of each single-point feature will be added.</para>
		/// <para>Minimum Z—The lowest surface z-values in the area defined by the polygon, along the length of a line, or among the interpolated values for points in a multipoint record will be added.</para>
		/// <para>Maximum Z—The highest surface elevation in the area defined by the polygon, along the length of a line, or among the interpolated values for points in a multipoint record will be added.</para>
		/// <para>Mean Z—The average surface elevation of the area defined by the polygon, along the length of a line, or among the interpolated values for points in a multipoint record will be added.</para>
		/// <para>Surface Area—The 3D surface area for the region defined by each polygon will be added.</para>
		/// <para>Surface Length—The 3D distance of the line along the surface will be added.</para>
		/// <para>Minimum Slope—The slope value closest to zero along the line or within the area defined by the polygon will be added.</para>
		/// <para>Maximum Slope—The highest slope value along the line or within the area defined by the polygon will be added.</para>
		/// <para>Average Slope—The average slope value along the line or within the area defined by the polygon will be added.</para>
		/// <para><see cref="OutPropertyEnum"/></para>
		/// </param>
		public AddSurfaceInformation(object InFeatureClass, object InSurface, object OutProperty)
		{
			this.InFeatureClass = InFeatureClass;
			this.InSurface = InSurface;
			this.OutProperty = OutProperty;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Surface Information</para>
		/// </summary>
		public override string DisplayName() => "Add Surface Information";

		/// <summary>
		/// <para>Tool Name : AddSurfaceInformation</para>
		/// </summary>
		public override string ToolName() => "AddSurfaceInformation";

		/// <summary>
		/// <para>Tool Excute Name : 3d.AddSurfaceInformation</para>
		/// </summary>
		public override string ExcuteName() => "3d.AddSurfaceInformation";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "extent", "geographicTransformations", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, InSurface, OutProperty, Method!, SampleDistance!, ZFactor!, PyramidLevelResolution!, NoiseFiltering!, OutputFeatureClass! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The point, multipoint, polyline, or polygon features that define the locations for determining one or more surface properties.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon", "Point", "Multipoint")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>The LAS dataset, mosaic, raster, terrain, or TIN surface used for interpolating z-values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Property</para>
		/// <para>Specifies the surface elevation properties that will be added to the attribute table of the input feature class.</para>
		/// <para>Z—The surface z-values interpolated for the x,y-location of each single-point feature will be added.</para>
		/// <para>Minimum Z—The lowest surface z-values in the area defined by the polygon, along the length of a line, or among the interpolated values for points in a multipoint record will be added.</para>
		/// <para>Maximum Z—The highest surface elevation in the area defined by the polygon, along the length of a line, or among the interpolated values for points in a multipoint record will be added.</para>
		/// <para>Mean Z—The average surface elevation of the area defined by the polygon, along the length of a line, or among the interpolated values for points in a multipoint record will be added.</para>
		/// <para>Surface Area—The 3D surface area for the region defined by each polygon will be added.</para>
		/// <para>Surface Length—The 3D distance of the line along the surface will be added.</para>
		/// <para>Minimum Slope—The slope value closest to zero along the line or within the area defined by the polygon will be added.</para>
		/// <para>Maximum Slope—The highest slope value along the line or within the area defined by the polygon will be added.</para>
		/// <para>Average Slope—The average slope value along the line or within the area defined by the polygon will be added.</para>
		/// <para><see cref="OutPropertyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object OutProperty { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>Specifies the interpolation method that will be used to determine information about the surface.</para>
		/// <para>Bilinear—An interpolation method exclusive to the raster surface which determines cell values from the four nearest cells will be used. This is the only option available for a raster surface.</para>
		/// <para>Linear— Elevation will be obtained from the plane defined by the triangle that contains the x,y-location of a query point. This is the default interpolation method for TINs, terrains, and LAS datasets.</para>
		/// <para>Natural Neighbors—Elevation will be obtained by applying area-based weights to the natural neighbors of a query point.</para>
		/// <para>Conflate Minimum Z— Elevation will be obtained from the smallest z-value found among the natural neighbors of a query point.</para>
		/// <para>Conflate Maximum Z— Elevation will be obtained from the largest z-value found among the natural neighbors of a query point.</para>
		/// <para>Conflate Nearest Z— Elevation will be obtained from the nearest value among the natural neighbors of a query point.</para>
		/// <para>Conflate Z Closest To Mean— Elevation will be obtained from the z-value that is closest to the average of all the natural neighbors of a query point.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Sampling Distance</para>
		/// <para>The spacing at which z-values will be interpolated. By default, the raster cell size is used when the input surface is a raster, and the natural densification of the triangulated surface is used when the input is a terrain or TIN dataset.</para>
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
		/// <para>Pyramid Level Resolution</para>
		/// <para>The z-tolerance or window-size resolution of the terrain pyramid level that will be used. The default is 0, or full resolution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Noise Filtering</para>
		/// <para>Exclude portions of the surface that are potentially characterized by anomalous measurements from contributing to slope calculations. Other properties are not affected by this parameter.</para>
		/// <para>Line features offer a length filter in which line segments with 3D lengths that are shorter than the specified value will be excluded from slope calculations. Polygon features offer an area filter in which polygons covering a surface area smaller than the specified value will be excluded.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? NoiseFiltering { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddSurfaceInformation SetEnviroment(int? autoCommit = null, object? extent = null, object? geographicTransformations = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, extent: extent, geographicTransformations: geographicTransformations, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Property</para>
		/// </summary>
		public enum OutPropertyEnum 
		{
			/// <summary>
			/// <para>Z—The surface z-values interpolated for the x,y-location of each single-point feature will be added.</para>
			/// </summary>
			[GPValue("Z")]
			[Description("Z")]
			Z,

			/// <summary>
			/// <para>Minimum Z—The lowest surface z-values in the area defined by the polygon, along the length of a line, or among the interpolated values for points in a multipoint record will be added.</para>
			/// </summary>
			[GPValue("Z_MIN")]
			[Description("Minimum Z")]
			Minimum_Z,

			/// <summary>
			/// <para>Maximum Z—The highest surface elevation in the area defined by the polygon, along the length of a line, or among the interpolated values for points in a multipoint record will be added.</para>
			/// </summary>
			[GPValue("Z_MAX")]
			[Description("Maximum Z")]
			Maximum_Z,

			/// <summary>
			/// <para>Mean Z—The average surface elevation of the area defined by the polygon, along the length of a line, or among the interpolated values for points in a multipoint record will be added.</para>
			/// </summary>
			[GPValue("Z_MEAN")]
			[Description("Mean Z")]
			Mean_Z,

			/// <summary>
			/// <para>Surface Length—The 3D distance of the line along the surface will be added.</para>
			/// </summary>
			[GPValue("SURFACE_LENGTH")]
			[Description("Surface Length")]
			Surface_Length,

			/// <summary>
			/// <para>Surface Area—The 3D surface area for the region defined by each polygon will be added.</para>
			/// </summary>
			[GPValue("SURFACE_AREA")]
			[Description("Surface Area")]
			Surface_Area,

			/// <summary>
			/// <para>Minimum Slope—The slope value closest to zero along the line or within the area defined by the polygon will be added.</para>
			/// </summary>
			[GPValue("MIN_SLOPE")]
			[Description("Minimum Slope")]
			Minimum_Slope,

			/// <summary>
			/// <para>Maximum Slope—The highest slope value along the line or within the area defined by the polygon will be added.</para>
			/// </summary>
			[GPValue("MAX_SLOPE")]
			[Description("Maximum Slope")]
			Maximum_Slope,

			/// <summary>
			/// <para>Average Slope—The average slope value along the line or within the area defined by the polygon will be added.</para>
			/// </summary>
			[GPValue("AVG_SLOPE")]
			[Description("Average Slope")]
			Average_Slope,

		}

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Linear— Elevation will be obtained from the plane defined by the triangle that contains the x,y-location of a query point. This is the default interpolation method for TINs, terrains, and LAS datasets.</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("Linear")]
			Linear,

			/// <summary>
			/// <para>Natural Neighbors—Elevation will be obtained by applying area-based weights to the natural neighbors of a query point.</para>
			/// </summary>
			[GPValue("NATURAL_NEIGHBORS")]
			[Description("Natural Neighbors")]
			Natural_Neighbors,

			/// <summary>
			/// <para>Conflate Minimum Z— Elevation will be obtained from the smallest z-value found among the natural neighbors of a query point.</para>
			/// </summary>
			[GPValue("CONFLATE_ZMIN")]
			[Description("Conflate Minimum Z")]
			Conflate_Minimum_Z,

			/// <summary>
			/// <para>Conflate Maximum Z— Elevation will be obtained from the largest z-value found among the natural neighbors of a query point.</para>
			/// </summary>
			[GPValue("CONFLATE_ZMAX")]
			[Description("Conflate Maximum Z")]
			Conflate_Maximum_Z,

			/// <summary>
			/// <para>Conflate Nearest Z— Elevation will be obtained from the nearest value among the natural neighbors of a query point.</para>
			/// </summary>
			[GPValue("CONFLATE_NEAREST")]
			[Description("Conflate Nearest Z")]
			Conflate_Nearest_Z,

			/// <summary>
			/// <para>Conflate Z Closest To Mean— Elevation will be obtained from the z-value that is closest to the average of all the natural neighbors of a query point.</para>
			/// </summary>
			[GPValue("CONFLATE_CLOSEST_TO_MEAN")]
			[Description("Conflate Z Closest To Mean")]
			Conflate_Z_Closest_To_Mean,

			/// <summary>
			/// <para>Bilinear—An interpolation method exclusive to the raster surface which determines cell values from the four nearest cells will be used. This is the only option available for a raster surface.</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("Bilinear")]
			Bilinear,

		}

#endregion
	}
}
