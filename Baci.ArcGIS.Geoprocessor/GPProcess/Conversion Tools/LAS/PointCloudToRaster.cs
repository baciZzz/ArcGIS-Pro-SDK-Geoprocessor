using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Point Cloud To Raster</para>
	/// <para>Point Cloud To Raster</para>
	/// <para>Creates a raster surface from height values in a point cloud scene layer package file (*.slpk).</para>
	/// </summary>
	public class PointCloudToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointCloud">
		/// <para>Input Point Cloud</para>
		/// <para>The point cloud scene layer package file (*.slpk) that will be processed</para>
		/// </param>
		/// <param name="CellSize">
		/// <para>Cell Size</para>
		/// <para>The length and width of each cell in the output raster.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>The location and name of the output raster. When storing a raster dataset in a geodatabase or in a folder such as an Esri Grid, do not add a file extension to the name of the raster dataset. A file extension can be provided to define the raster&apos;s format when storing it in a folder, such as .tif to generate a GeoTIFF or .img to generate an ERDAS IMAGINE format file.</para>
		/// <para>If the raster is stored as a TIFF file or in a geodatabase, its raster compression type and quality can be specified using geoprocessing environment settings.</para>
		/// </param>
		public PointCloudToRaster(object InPointCloud, object CellSize, object OutRaster)
		{
			this.InPointCloud = InPointCloud;
			this.CellSize = CellSize;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Point Cloud To Raster</para>
		/// </summary>
		public override string DisplayName() => "Point Cloud To Raster";

		/// <summary>
		/// <para>Tool Name : PointCloudToRaster</para>
		/// </summary>
		public override string ToolName() => "PointCloudToRaster";

		/// <summary>
		/// <para>Tool Excute Name : conversion.PointCloudToRaster</para>
		/// </summary>
		public override string ExcuteName() => "conversion.PointCloudToRaster";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "compression", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "pyramid", "rasterStatistics", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointCloud, CellSize, OutRaster, CellAssignment!, VoidFill!, ZFactor! };

		/// <summary>
		/// <para>Input Point Cloud</para>
		/// <para>The point cloud scene layer package file (*.slpk) that will be processed</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InPointCloud { get; set; }

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>The length and width of each cell in the output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>The location and name of the output raster. When storing a raster dataset in a geodatabase or in a folder such as an Esri Grid, do not add a file extension to the name of the raster dataset. A file extension can be provided to define the raster&apos;s format when storing it in a folder, such as .tif to generate a GeoTIFF or .img to generate an ERDAS IMAGINE format file.</para>
		/// <para>If the raster is stored as a TIFF file or in a geodatabase, its raster compression type and quality can be specified using geoprocessing environment settings.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Cell Assignment Type</para>
		/// <para>Specifies the method that will be used for assigning values to cells containing points.</para>
		/// <para>Average Height—The cell value will be defined by the average of the z-values for all points in the cell. This is the default.</para>
		/// <para>Minimum Height—The cell value will be defined by the lowest z-value from the points in the cell.</para>
		/// <para>Maximum Height—The cell value will be defined by the highest z-value from the points in the cell.</para>
		/// <para>Inverse Distance Weighted—The cell value will be interpolated at the cell center using the inverse distance weighted method, which applies a linear weight to each LAS point in the neighborhood of a given cell based on its distance from the cell center.</para>
		/// <para>Nearest Neighbor—The cell value will be assigned based on the height of the point closest to the cell center.</para>
		/// <para><see cref="CellAssignmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CellAssignment { get; set; } = "AVERAGE";

		/// <summary>
		/// <para>Void Fill Method</para>
		/// <para>Specifies the method that will be used for interpolating the values of cells within the interpolation zone that do not contain points.</para>
		/// <para>None—No value will be assigned to raster cells that do not contain points.</para>
		/// <para>Simple—The z-value of points located in the cells that immediately surround the empty cell will be averaged to eliminate small voids.</para>
		/// <para>Linear—Void areas will be triangulated and linear interpolation will be used to assign the cell value. This is the default.</para>
		/// <para>Natural Neighbor—Natural neighbor interpolation will be used to determine the cell value.</para>
		/// <para><see cref="VoidFillEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? VoidFill { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>The factor by which z-values will be multiplied. This is typically used to convert z linear units to match x,y linear units. The default is 1, which leaves the z-values unchanged.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PointCloudToRaster SetEnviroment(object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? pyramid = null, object? rasterStatistics = null, object? scratchWorkspace = null, object? snapRaster = null, object? workspace = null)
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, rasterStatistics: rasterStatistics, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Cell Assignment Type</para>
		/// </summary>
		public enum CellAssignmentEnum 
		{
			/// <summary>
			/// <para>Average Height—The cell value will be defined by the average of the z-values for all points in the cell. This is the default.</para>
			/// </summary>
			[GPValue("AVERAGE")]
			[Description("Average Height")]
			Average_Height,

			/// <summary>
			/// <para>Minimum Height—The cell value will be defined by the lowest z-value from the points in the cell.</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("Minimum Height")]
			Minimum_Height,

			/// <summary>
			/// <para>Maximum Height—The cell value will be defined by the highest z-value from the points in the cell.</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("Maximum Height")]
			Maximum_Height,

			/// <summary>
			/// <para>Nearest Neighbor—The cell value will be assigned based on the height of the point closest to the cell center.</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("Nearest Neighbor")]
			Nearest_Neighbor,

		}

		/// <summary>
		/// <para>Void Fill Method</para>
		/// </summary>
		public enum VoidFillEnum 
		{
			/// <summary>
			/// <para>None—No value will be assigned to raster cells that do not contain points.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Simple—The z-value of points located in the cells that immediately surround the empty cell will be averaged to eliminate small voids.</para>
			/// </summary>
			[GPValue("SIMPLE")]
			[Description("Simple")]
			Simple,

			/// <summary>
			/// <para>Linear—Void areas will be triangulated and linear interpolation will be used to assign the cell value. This is the default.</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("Linear")]
			Linear,

			/// <summary>
			/// <para>Natural Neighbor—Natural neighbor interpolation will be used to determine the cell value.</para>
			/// </summary>
			[GPValue("NATURAL_NEIGHBOR")]
			[Description("Natural Neighbor")]
			Natural_Neighbor,

		}

#endregion
	}
}
