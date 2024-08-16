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
	/// <para>Surface Difference</para>
	/// <para>Calculate the displacement between two surfaces to determine where one is above, below or the same as the other surface.</para>
	/// </summary>
	public class SurfaceDifference : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>The triangulated surface whose relative displacement is being evaluated from the reference surface.</para>
		/// </param>
		/// <param name="InReferenceSurface">
		/// <para>Reference Surface</para>
		/// <para>The triangulated surface that will be used as the baseline for determining the relative displacement of the input surface.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing contiguous triangles and triangle parts that have the same classification grouped into polygons. The volume enclosed by each region of difference is listed in the attribute table.</para>
		/// </param>
		public SurfaceDifference(object InSurface, object InReferenceSurface, object OutFeatureClass)
		{
			this.InSurface = InSurface;
			this.InReferenceSurface = InReferenceSurface;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Surface Difference</para>
		/// </summary>
		public override string DisplayName => "Surface Difference";

		/// <summary>
		/// <para>Tool Name : SurfaceDifference</para>
		/// </summary>
		public override string ToolName => "SurfaceDifference";

		/// <summary>
		/// <para>Tool Excute Name : 3d.SurfaceDifference</para>
		/// </summary>
		public override string ExcuteName => "3d.SurfaceDifference";

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
		public override string[] ValidEnvironments => new string[] { "XYDomain", "XYResolution", "XYTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "terrainMemoryUsage", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InSurface, InReferenceSurface, OutFeatureClass, PyramidLevelResolution, ReferencePyramidLevelResolution, OutRaster, RasterCellSize, OutTinFolder, OutTinBasename, Method, ReferenceMethod, Extent, Boundary };

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>The triangulated surface whose relative displacement is being evaluated from the reference surface.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Reference Surface</para>
		/// <para>The triangulated surface that will be used as the baseline for determining the relative displacement of the input surface.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InReferenceSurface { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing contiguous triangles and triangle parts that have the same classification grouped into polygons. The volume enclosed by each region of difference is listed in the attribute table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Analysis Resolution</para>
		/// <para>The resolution that will be used to generate the input surface. For a terrain dataset, this will correspond to its pyramid-level definitions, where the default of 0 represents full resolution. For a LAS dataset, this value represents the length of each side of the square area that will be used to thin the LAS point returns.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Reference Analysis Resolution</para>
		/// <para>The resolution that will be used to generate the reference surface. For a terrain dataset, this will correspond to its pyramid-level definitions, where the default of 0 represents full resolution. For a LAS dataset, this value represents the length of each side of the square area that will be used to thin the LAS points returns.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ReferencePyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>The output raster surface whose values represent the input surface normalized against the reference surface. Positive values reflect areas where the input surface is above the reference surface, whereas negative values indicate the areas where the input surface is below the reference surface. The raster's values are derived from a TIN using linear interpolation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Raster Options")]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Raster Cell Size</para>
		/// <para>The cell size of the output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 9.9999999999999995e-08)]
		[Category("Raster Options")]
		public object RasterCellSize { get; set; } = "10";

		/// <summary>
		/// <para>Output TIN Folder</para>
		/// <para>The folder location for storing one or more TIN surfaces whose values represent the difference between the input and reference surface.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		[Category("TIN Options")]
		public object OutTinFolder { get; set; }

		/// <summary>
		/// <para>Output TIN Base Name</para>
		/// <para>The base name given to each output TIN surface. If one TIN dataset is not sufficient to represent the data, multiple TINs will be created with the same base name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("TIN Options")]
		public object OutTinBasename { get; set; }

		/// <summary>
		/// <para>LAS Thinning Method</para>
		/// <para>The method used to select a LAS point in each analysis window when applying an analysis resolution to thin the input LAS dataset surface. The resulting points will be used to construct a triangulated surface.</para>
		/// <para>Closest to mean—The LAS point whose value is closest to the mean of all LAS points in the analysis window will be used. This is the default.</para>
		/// <para>Minimum—The LAS point with the smallest z-value among all the LAS points in the analysis window.</para>
		/// <para>Maximum—The LAS point with the highest z-value among all the LAS points in the analysis window.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "CLOSEST_TO_MEAN";

		/// <summary>
		/// <para>Reference LAS Thinning Method</para>
		/// <para>The method used to select a LAS point in each analysis window when applying an analysis resolution to thin the input LAS dataset surface. The resulting points will be used to construct a triangulated surface.</para>
		/// <para>Closest to mean—The LAS point whose value is closest to the mean of all LAS points in the analysis window will be used. This is the default.</para>
		/// <para>Minimum—The LAS point with the smallest z-value among all the LAS points in the analysis window.</para>
		/// <para>Maximum—The LAS point with the highest z-value among all the LAS points in the analysis window.</para>
		/// <para><see cref="ReferenceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ReferenceMethod { get; set; } = "CLOSEST_TO_MEAN";

		/// <summary>
		/// <para>Processing Extent</para>
		/// <para>The extent of the data that will be evaluated.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Union of Inputs—The extent will be based on the maximum extent of all inputs.</para>
		/// <para>Intersection of Inputs—The extent will be based on the minimum area common to all inputs.</para>
		/// <para>Current Display Extent—The extent is equal to the visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Processing Extent")]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Processing Boundary</para>
		/// <para>A polygon feature that defines the area of interest to be processed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[Category("Processing Extent")]
		public object Boundary { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SurfaceDifference SetEnviroment(object XYDomain = null , object XYResolution = null , object XYTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object terrainMemoryUsage = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, terrainMemoryUsage: terrainMemoryUsage, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>LAS Thinning Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Minimum—The LAS point with the smallest z-value among all the LAS points in the analysis window.</para>
			/// </summary>
			[GPValue("MIN")]
			[Description("Minimum")]
			Minimum,

			/// <summary>
			/// <para>Maximum—The LAS point with the highest z-value among all the LAS points in the analysis window.</para>
			/// </summary>
			[GPValue("MAX")]
			[Description("Maximum")]
			Maximum,

			/// <summary>
			/// <para>Closest to mean—The LAS point whose value is closest to the mean of all LAS points in the analysis window will be used. This is the default.</para>
			/// </summary>
			[GPValue("CLOSEST_TO_MEAN")]
			[Description("Closest to mean")]
			Closest_to_mean,

		}

		/// <summary>
		/// <para>Reference LAS Thinning Method</para>
		/// </summary>
		public enum ReferenceMethodEnum 
		{
			/// <summary>
			/// <para>Minimum—The LAS point with the smallest z-value among all the LAS points in the analysis window.</para>
			/// </summary>
			[GPValue("MIN")]
			[Description("Minimum")]
			Minimum,

			/// <summary>
			/// <para>Maximum—The LAS point with the highest z-value among all the LAS points in the analysis window.</para>
			/// </summary>
			[GPValue("MAX")]
			[Description("Maximum")]
			Maximum,

			/// <summary>
			/// <para>Closest to mean—The LAS point whose value is closest to the mean of all LAS points in the analysis window will be used. This is the default.</para>
			/// </summary>
			[GPValue("CLOSEST_TO_MEAN")]
			[Description("Closest to mean")]
			Closest_to_mean,

		}

#endregion
	}
}
