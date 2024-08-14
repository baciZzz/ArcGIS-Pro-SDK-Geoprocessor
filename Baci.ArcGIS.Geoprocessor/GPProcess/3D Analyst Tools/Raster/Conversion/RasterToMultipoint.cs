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
	/// <para>Raster To Multipoint</para>
	/// <para>Converts raster cell centers into 3D multipoint features whose Z values reflect the raster cell value.</para>
	/// </summary>
	public class RasterToMultipoint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster to process.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </param>
		public RasterToMultipoint(object InRaster, object OutFeatureClass)
		{
			this.InRaster = InRaster;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Raster To Multipoint</para>
		/// </summary>
		public override string DisplayName => "Raster To Multipoint";

		/// <summary>
		/// <para>Tool Name : RasterToMultipoint</para>
		/// </summary>
		public override string ToolName => "RasterToMultipoint";

		/// <summary>
		/// <para>Tool Excute Name : 3d.RasterToMultipoint</para>
		/// </summary>
		public override string ExcuteName => "3d.RasterToMultipoint";

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
		public override string[] ValidEnvironments => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, OutFeatureClass, OutVipTable, Method, KernelMethod, ZFactor, ThinningValue };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output VIP table</para>
		/// <para>The histogram table to be produced when VIP Histogram is specified for the Method parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutVipTable { get; set; }

		/// <summary>
		/// <para>Thinning Method</para>
		/// <para>The thinning method applied to the input raster to select a subset of cells that will be exported to the multipoint feature class.</para>
		/// <para>No Thinning—No thinning will be applied. This is the default.</para>
		/// <para>Z Tolerance—Only exports the cells that are required for maintaining a surface within a specified Z-range of the input raster.</para>
		/// <para>Kernel—Divides the raster into equal sized tiles based on the specified thinning value, then selects one or two cells which meet the criteria defined by the designated kernel method.</para>
		/// <para>VIP—Employs a roving 3 cell by 3 cell window that is used to create a 3-dimensional best fit plane. Each cell is given a significance score based on its absolute deviation from this plane. A histogram of these scores is then used to determine the cells that get exported based on the percentile designated in the Thinning Value parameter.</para>
		/// <para>VIP Histogram—Creates a table to view the actual significance values and the corresponding number of points associated with those values.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "NO_THIN";

		/// <summary>
		/// <para>Kernel Method</para>
		/// <para>The selection method used within each kernel neighborhood when kernel thinning is applied on the input raster.</para>
		/// <para>Minimum—A point is created at the cell with the smallest elevation value found in the kernel neighborhood. This is the default.</para>
		/// <para>Maximum—A point is created at the cell with the largest elevation value found in the kernel neighborhood.</para>
		/// <para>Minimum and Maximum—Two points are created at the cells with the smallest and largest Z values found in the kernel neighborhood.</para>
		/// <para>Closest to Mean—A point is created at the cell whose elevation value is closest to the average of the cells in the kernel neighborhood.</para>
		/// <para><see cref="KernelMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object KernelMethod { get; set; } = "MIN";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>The factor by which z-values will be multiplied. This is typically used to convert z linear units to match x,y linear units. The default is 1, which leaves elevation values unchanged. This parameter is not available if the spatial reference of the input surface has a z datum with a specified linear unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Thinning Value</para>
		/// <para>The meaning of this value will depend on the specified Thinning Method.</para>
		/// <para>Z Tolerance—The maximum allowable difference in z units between the input raster and the surface created from the output multipoint feature class. When selecting this method, the thinning value defaults to one tenth of the z range of the input raster.</para>
		/// <para>Kernel—The number of raster cells along the edge of each tile. This value defaults to 3, which means the raster would be divided into 3 cell by 3 cell windows.</para>
		/// <para>VIP—The percentile rank of the histogram of significance scores. This value defaults to 5.0, which means the cells whose score was within the top 5% of the histogram will be exported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ThinningValue { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterToMultipoint SetEnviroment(object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Thinning Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Z Tolerance—Only exports the cells that are required for maintaining a surface within a specified Z-range of the input raster.</para>
			/// </summary>
			[GPValue("ZTOLERANCE")]
			[Description("Z Tolerance")]
			Z_Tolerance,

			/// <summary>
			/// <para>Kernel—Divides the raster into equal sized tiles based on the specified thinning value, then selects one or two cells which meet the criteria defined by the designated kernel method.</para>
			/// </summary>
			[GPValue("KERNEL")]
			[Description("Kernel")]
			Kernel,

			/// <summary>
			/// <para>VIP Histogram—Creates a table to view the actual significance values and the corresponding number of points associated with those values.</para>
			/// </summary>
			[GPValue("VIP_HISTOGRAM")]
			[Description("VIP Histogram")]
			VIP_Histogram,

			/// <summary>
			/// <para>VIP—Employs a roving 3 cell by 3 cell window that is used to create a 3-dimensional best fit plane. Each cell is given a significance score based on its absolute deviation from this plane. A histogram of these scores is then used to determine the cells that get exported based on the percentile designated in the Thinning Value parameter.</para>
			/// </summary>
			[GPValue("VIP")]
			[Description("VIP")]
			VIP,

			/// <summary>
			/// <para>No Thinning—No thinning will be applied. This is the default.</para>
			/// </summary>
			[GPValue("NO_THIN")]
			[Description("No Thinning")]
			No_Thinning,

		}

		/// <summary>
		/// <para>Kernel Method</para>
		/// </summary>
		public enum KernelMethodEnum 
		{
			/// <summary>
			/// <para>Minimum—A point is created at the cell with the smallest elevation value found in the kernel neighborhood. This is the default.</para>
			/// </summary>
			[GPValue("MIN")]
			[Description("Minimum")]
			Minimum,

			/// <summary>
			/// <para>Maximum—A point is created at the cell with the largest elevation value found in the kernel neighborhood.</para>
			/// </summary>
			[GPValue("MAX")]
			[Description("Maximum")]
			Maximum,

			/// <summary>
			/// <para>Minimum and Maximum—Two points are created at the cells with the smallest and largest Z values found in the kernel neighborhood.</para>
			/// </summary>
			[GPValue("MINMAX")]
			[Description("Minimum and Maximum")]
			Minimum_and_Maximum,

			/// <summary>
			/// <para>Closest to Mean—A point is created at the cell whose elevation value is closest to the average of the cells in the kernel neighborhood.</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Closest to Mean")]
			Closest_to_Mean,

		}

#endregion
	}
}
