using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpaceTimePatternMiningTools
{
	/// <summary>
	/// <para>Create Space Time Cube From Multidimensional Raster Layer</para>
	/// <para>Creates a space-time cube from a  multidimensional raster layer and structures the data into space-time bins for efficient space-time analysis and visualization.</para>
	/// </summary>
	public class CreateSpaceTimeCubeMDRasterLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMdRaster">
		/// <para>Input Multidimensional Raster Layer</para>
		/// <para>The input multidimensional raster layer that will be converted into a space-time cube.</para>
		/// </param>
		/// <param name="OutputCube">
		/// <para>Output Space Time Cube</para>
		/// <para>The output netCDF data cube that will be created.</para>
		/// </param>
		public CreateSpaceTimeCubeMDRasterLayer(object InMdRaster, object OutputCube)
		{
			this.InMdRaster = InMdRaster;
			this.OutputCube = OutputCube;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Space Time Cube From Multidimensional Raster Layer</para>
		/// </summary>
		public override string DisplayName => "Create Space Time Cube From Multidimensional Raster Layer";

		/// <summary>
		/// <para>Tool Name : CreateSpaceTimeCubeMDRasterLayer</para>
		/// </summary>
		public override string ToolName => "CreateSpaceTimeCubeMDRasterLayer";

		/// <summary>
		/// <para>Tool Excute Name : stpm.CreateSpaceTimeCubeMDRasterLayer</para>
		/// </summary>
		public override string ExcuteName => "stpm.CreateSpaceTimeCubeMDRasterLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Space Time Pattern Mining Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Space Time Pattern Mining Tools";

		/// <summary>
		/// <para>Toolbox Alise : stpm</para>
		/// </summary>
		public override string ToolboxAlise => "stpm";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InMdRaster, OutputCube, FillEmptyBins };

		/// <summary>
		/// <para>Input Multidimensional Raster Layer</para>
		/// <para>The input multidimensional raster layer that will be converted into a space-time cube.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InMdRaster { get; set; }

		/// <summary>
		/// <para>Output Space Time Cube</para>
		/// <para>The output netCDF data cube that will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutputCube { get; set; }

		/// <summary>
		/// <para>Fill Empty Bins Method</para>
		/// <para>Specifies how missing values in the output space-time cube will be filled. Each space-time bin in the output must have a value, so you must choose how to fill in values for raster cells with NoData values.</para>
		/// <para>Zeros—Empty bins with be filled with zeros. This is the default.</para>
		/// <para>Spatial neighbors—Empty bins will be filled with the average value of spatial neighbors.</para>
		/// <para>Space-time neighbors—Empty bins will be filled with the average value of space-time neighbors.</para>
		/// <para>Temporal trend—Empty bins will be filled using an interpolated univariate spline algorithm.</para>
		/// <para><see cref="FillEmptyBinsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FillEmptyBins { get; set; } = "ZEROS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateSpaceTimeCubeMDRasterLayer SetEnviroment(object extent = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Fill Empty Bins Method</para>
		/// </summary>
		public enum FillEmptyBinsEnum 
		{
			/// <summary>
			/// <para>Zeros—Empty bins with be filled with zeros. This is the default.</para>
			/// </summary>
			[GPValue("ZEROS")]
			[Description("Zeros")]
			Zeros,

			/// <summary>
			/// <para>Spatial neighbors—Empty bins will be filled with the average value of spatial neighbors.</para>
			/// </summary>
			[GPValue("SPATIAL_NEIGHBORS")]
			[Description("Spatial neighbors")]
			Spatial_neighbors,

			/// <summary>
			/// <para>Space-time neighbors—Empty bins will be filled with the average value of space-time neighbors.</para>
			/// </summary>
			[GPValue("SPACE_TIME_NEIGHBORS")]
			[Description("Space-time neighbors")]
			SPACE_TIME_NEIGHBORS,

			/// <summary>
			/// <para>Temporal trend—Empty bins will be filled using an interpolated univariate spline algorithm.</para>
			/// </summary>
			[GPValue("TEMPORAL_TREND")]
			[Description("Temporal trend")]
			Temporal_trend,

		}

#endregion
	}
}
