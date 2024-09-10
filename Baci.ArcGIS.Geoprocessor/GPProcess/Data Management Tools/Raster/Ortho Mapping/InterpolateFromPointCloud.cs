using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Interpolate From Point Cloud</para>
	/// <para>Interpolates a digital terrain model (DTM) or a digital surface model (DSM) from a point cloud using one of the interpolation methods provided.</para>
	/// </summary>
	public class InterpolateFromPointCloud : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InContainer">
		/// <para>Input LAS Folder or Point Table</para>
		/// <para>The path and name of the file, folder, or feature layer. The input can be a folder of LAS files or a solution point table from orthomapping tools.</para>
		/// <para>The LAS files can be the output from the Generate Point Cloud tool, in which LAS points are categorized as ground and above ground. The solution point table is output from either the Compute Block Adjustments tool or the Compute Camera Model tool.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>The output raster dataset location, name, and file extension.</para>
		/// <para>The output can be created in most writable raster formats, such as .tif, .crf, or .img.</para>
		/// </param>
		/// <param name="CellSize">
		/// <para>Cellsize</para>
		/// <para>The cell size of the output raster dataset.</para>
		/// </param>
		/// <param name="InterpolationMethod">
		/// <para>Interpolation Method</para>
		/// <para>Specifies the method used to interpolate the output raster dataset from the point cloud.</para>
		/// <para>TIN linear interpolation— This is also known as triangulated irregular network (TIN) linear interpolation and is designed for irregularly distributed sparse points, such as solution points from block adjustment computation.</para>
		/// <para>TIN natural neighbor interpolation—This is similar to triangulation but generates a smoother surface and is more computationally intensive.</para>
		/// <para>Inverse distance weighted average interpolation—This is used for regularly distributed dense points, such as point cloud LAS files from the Generate Point Cloud tool. The IDW search radius is automatically computed based on average point density.</para>
		/// <para><see cref="InterpolationMethodEnum"/></para>
		/// </param>
		/// <param name="SmoothMethod">
		/// <para>Smoothing Method</para>
		/// <para>Specifies the filter to smooth the output raster dataset.</para>
		/// <para>Gaussian 3 by 3—A Gaussian filter with a 3 by 3 window will be used.</para>
		/// <para>Gaussian 5 by 5—A Gaussian filter with a 5 by 5 window will be used.</para>
		/// <para>Gaussian 7 by 7—A Gaussian filter with a 7 by 7 window will be used.</para>
		/// <para>Gaussian 9 by 9—A Gaussian filter with a 9 by 9 window will be used.</para>
		/// <para>No smoothing—No smoothing filter will be used.</para>
		/// <para><see cref="SmoothMethodEnum"/></para>
		/// </param>
		public InterpolateFromPointCloud(object InContainer, object OutRaster, object CellSize, object InterpolationMethod, object SmoothMethod)
		{
			this.InContainer = InContainer;
			this.OutRaster = OutRaster;
			this.CellSize = CellSize;
			this.InterpolationMethod = InterpolationMethod;
			this.SmoothMethod = SmoothMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : Interpolate From Point Cloud</para>
		/// </summary>
		public override string DisplayName() => "Interpolate From Point Cloud";

		/// <summary>
		/// <para>Tool Name : InterpolateFromPointCloud</para>
		/// </summary>
		public override string ToolName() => "InterpolateFromPointCloud";

		/// <summary>
		/// <para>Tool Excute Name : management.InterpolateFromPointCloud</para>
		/// </summary>
		public override string ExcuteName() => "management.InterpolateFromPointCloud";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellAlignment", "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InContainer, OutRaster, CellSize, InterpolationMethod, SmoothMethod, SurfaceType, FillDem };

		/// <summary>
		/// <para>Input LAS Folder or Point Table</para>
		/// <para>The path and name of the file, folder, or feature layer. The input can be a folder of LAS files or a solution point table from orthomapping tools.</para>
		/// <para>The LAS files can be the output from the Generate Point Cloud tool, in which LAS points are categorized as ground and above ground. The solution point table is output from either the Compute Block Adjustments tool or the Compute Camera Model tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InContainer { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>The output raster dataset location, name, and file extension.</para>
		/// <para>The output can be created in most writable raster formats, such as .tif, .crf, or .img.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Cellsize</para>
		/// <para>The cell size of the output raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Interpolation Method</para>
		/// <para>Specifies the method used to interpolate the output raster dataset from the point cloud.</para>
		/// <para>TIN linear interpolation— This is also known as triangulated irregular network (TIN) linear interpolation and is designed for irregularly distributed sparse points, such as solution points from block adjustment computation.</para>
		/// <para>TIN natural neighbor interpolation—This is similar to triangulation but generates a smoother surface and is more computationally intensive.</para>
		/// <para>Inverse distance weighted average interpolation—This is used for regularly distributed dense points, such as point cloud LAS files from the Generate Point Cloud tool. The IDW search radius is automatically computed based on average point density.</para>
		/// <para><see cref="InterpolationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InterpolationMethod { get; set; } = "TRIANGULATION";

		/// <summary>
		/// <para>Smoothing Method</para>
		/// <para>Specifies the filter to smooth the output raster dataset.</para>
		/// <para>Gaussian 3 by 3—A Gaussian filter with a 3 by 3 window will be used.</para>
		/// <para>Gaussian 5 by 5—A Gaussian filter with a 5 by 5 window will be used.</para>
		/// <para>Gaussian 7 by 7—A Gaussian filter with a 7 by 7 window will be used.</para>
		/// <para>Gaussian 9 by 9—A Gaussian filter with a 9 by 9 window will be used.</para>
		/// <para>No smoothing—No smoothing filter will be used.</para>
		/// <para><see cref="SmoothMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SmoothMethod { get; set; } = "GAUSS5x5";

		/// <summary>
		/// <para>Surface Type</para>
		/// <para>Specifies whether a digital terrain model or a digital surface model will be created.</para>
		/// <para>Digital terrain model—A digital terrain model will be created by interpolating only the ground points.</para>
		/// <para>Digital surface model—A digital surface model will be created by interpolating all the points.</para>
		/// <para><see cref="SurfaceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SurfaceType { get; set; } = "DTM";

		/// <summary>
		/// <para>Input Fill DEM</para>
		/// <para>A DEM raster input that is used to fill NoData areas. Areas of NoData may exist where pixels do not have enough information from the input to generate any values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object FillDem { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public InterpolateFromPointCloud SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object pyramid = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Interpolation Method</para>
		/// </summary>
		public enum InterpolationMethodEnum 
		{
			/// <summary>
			/// <para>TIN linear interpolation— This is also known as triangulated irregular network (TIN) linear interpolation and is designed for irregularly distributed sparse points, such as solution points from block adjustment computation.</para>
			/// </summary>
			[GPValue("TRIANGULATION")]
			[Description("TIN linear interpolation")]
			TIN_linear_interpolation,

			/// <summary>
			/// <para>TIN natural neighbor interpolation—This is similar to triangulation but generates a smoother surface and is more computationally intensive.</para>
			/// </summary>
			[GPValue("NATURAL_NEIGHBOR")]
			[Description("TIN natural neighbor interpolation")]
			TIN_natural_neighbor_interpolation,

			/// <summary>
			/// <para>Inverse distance weighted average interpolation—This is used for regularly distributed dense points, such as point cloud LAS files from the Generate Point Cloud tool. The IDW search radius is automatically computed based on average point density.</para>
			/// </summary>
			[GPValue("IDW")]
			[Description("Inverse distance weighted average interpolation")]
			Inverse_distance_weighted_average_interpolation,

		}

		/// <summary>
		/// <para>Smoothing Method</para>
		/// </summary>
		public enum SmoothMethodEnum 
		{
			/// <summary>
			/// <para>Gaussian 3 by 3—A Gaussian filter with a 3 by 3 window will be used.</para>
			/// </summary>
			[GPValue("GAUSS3x3")]
			[Description("Gaussian 3 by 3")]
			Gaussian_3_by_3,

			/// <summary>
			/// <para>Gaussian 5 by 5—A Gaussian filter with a 5 by 5 window will be used.</para>
			/// </summary>
			[GPValue("GAUSS5x5")]
			[Description("Gaussian 5 by 5")]
			Gaussian_5_by_5,

			/// <summary>
			/// <para>Gaussian 7 by 7—A Gaussian filter with a 7 by 7 window will be used.</para>
			/// </summary>
			[GPValue("GAUSS7x7")]
			[Description("Gaussian 7 by 7")]
			Gaussian_7_by_7,

			/// <summary>
			/// <para>Gaussian 9 by 9—A Gaussian filter with a 9 by 9 window will be used.</para>
			/// </summary>
			[GPValue("GAUSS9x9")]
			[Description("Gaussian 9 by 9")]
			Gaussian_9_by_9,

			/// <summary>
			/// <para>No smoothing—No smoothing filter will be used.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("No smoothing")]
			No_smoothing,

		}

		/// <summary>
		/// <para>Surface Type</para>
		/// </summary>
		public enum SurfaceTypeEnum 
		{
			/// <summary>
			/// <para>Digital terrain model—A digital terrain model will be created by interpolating only the ground points.</para>
			/// </summary>
			[GPValue("DTM")]
			[Description("Digital terrain model")]
			Digital_terrain_model,

			/// <summary>
			/// <para>Digital surface model—A digital surface model will be created by interpolating all the points.</para>
			/// </summary>
			[GPValue("DSM")]
			[Description("Digital surface model")]
			Digital_surface_model,

		}

#endregion
	}
}
