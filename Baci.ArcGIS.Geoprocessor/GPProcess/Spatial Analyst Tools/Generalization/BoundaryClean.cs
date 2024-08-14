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
	/// <para>Boundary Clean</para>
	/// <para>Smooths the boundary between zones in a raster.</para>
	/// </summary>
	public class BoundaryClean : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster for which the boundary between zones will be smoothed.</para>
		/// <para>It must be of integer type.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output generalized raster.</para>
		/// <para>The boundaries between zones in the input will be smoothed.</para>
		/// <para>The output is always of integer type.</para>
		/// </param>
		public BoundaryClean(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Boundary Clean</para>
		/// </summary>
		public override string DisplayName => "Boundary Clean";

		/// <summary>
		/// <para>Tool Name : BoundaryClean</para>
		/// </summary>
		public override string ToolName => "BoundaryClean";

		/// <summary>
		/// <para>Tool Excute Name : sa.BoundaryClean</para>
		/// </summary>
		public override string ExcuteName => "sa.BoundaryClean";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, OutRaster, SortType!, NumberOfRuns! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster for which the boundary between zones will be smoothed.</para>
		/// <para>It must be of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output generalized raster.</para>
		/// <para>The boundaries between zones in the input will be smoothed.</para>
		/// <para>The output is always of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Sort type</para>
		/// <para>Specifies the type of sorting to use in the smoothing process. The sorting determines the priority by which cells can expand into their neighbors.</para>
		/// <para>The sorting can be based on zone value or zone size.</para>
		/// <para>Do not sort—The priority is determined by zone value. The size of the zones is not considered. Zones with larger values will have a higher priority to expand into zones with smaller values in the smoothed output. This is the default.</para>
		/// <para>Descending—Zones are sorted in descending order by size. Zones with larger total areas have a higher priority to expand into zones with smaller total areas. This option tends to eliminate or reduce the prevalence of cells from smaller zones in the smoothed output.</para>
		/// <para>Ascending—Zones are sorted in ascending order by size. Zones with smaller total areas have a higher priority to expand into zones with larger total areas. This option tends to preserve or increase the prevalence of cells from smaller zones in the smoothed output.</para>
		/// <para><see cref="SortTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SortType { get; set; } = "NO_SORT";

		/// <summary>
		/// <para>Run expansion and shrinking twice</para>
		/// <para>Specifies the number of times the smoothing process will occur, twice or once.</para>
		/// <para>Checked—The expansion and shrinking operation is performed twice. The first time, the operation is performed according to the specified sort type. The second time, an additional expansion and shrinking operation is performed with the priority reversed. This is the default.</para>
		/// <para>Unchecked—The expansion and shrinking operation is performed once according to the sort type.</para>
		/// <para><see cref="NumberOfRunsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? NumberOfRuns { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BoundaryClean SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Sort type</para>
		/// </summary>
		public enum SortTypeEnum 
		{
			/// <summary>
			/// <para>Do not sort—The priority is determined by zone value. The size of the zones is not considered. Zones with larger values will have a higher priority to expand into zones with smaller values in the smoothed output. This is the default.</para>
			/// </summary>
			[GPValue("NO_SORT")]
			[Description("Do not sort")]
			Do_not_sort,

			/// <summary>
			/// <para>Descending—Zones are sorted in descending order by size. Zones with larger total areas have a higher priority to expand into zones with smaller total areas. This option tends to eliminate or reduce the prevalence of cells from smaller zones in the smoothed output.</para>
			/// </summary>
			[GPValue("DESCEND")]
			[Description("Descending")]
			Descending,

			/// <summary>
			/// <para>Ascending—Zones are sorted in ascending order by size. Zones with smaller total areas have a higher priority to expand into zones with larger total areas. This option tends to preserve or increase the prevalence of cells from smaller zones in the smoothed output.</para>
			/// </summary>
			[GPValue("ASCEND")]
			[Description("Ascending")]
			Ascending,

		}

		/// <summary>
		/// <para>Run expansion and shrinking twice</para>
		/// </summary>
		public enum NumberOfRunsEnum 
		{
			/// <summary>
			/// <para>Checked—The expansion and shrinking operation is performed twice. The first time, the operation is performed according to the specified sort type. The second time, an additional expansion and shrinking operation is performed with the priority reversed. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TWO_WAY")]
			TWO_WAY,

			/// <summary>
			/// <para>Unchecked—The expansion and shrinking operation is performed once according to the sort type.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ONE_WAY")]
			ONE_WAY,

		}

#endregion
	}
}
