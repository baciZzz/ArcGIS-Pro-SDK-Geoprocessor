using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Generate HLZ Suitability</para>
	/// <para>Generate HLZ Suitability</para>
	/// <para>Creates a helicopter landing zone (HLZ) suitability raster layer from reclassified slope, reclassified land cover, and obstacle buffers.</para>
	/// </summary>
	public class GenerateHLZSuitability : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSlopeRaster">
		/// <para>Input Slope Raster</para>
		/// <para>The reclassified slope raster with values 1 (acceptable) and 2 (acceptable with caution). All other values will be excluded from the analysis.</para>
		/// </param>
		/// <param name="InLandCoverRaster">
		/// <para>Input Land Cover Raster</para>
		/// <para>The reclassified land cover raster with values 1 (acceptable) and 2 (acceptable with caution). All other values will be excluded from the analysis.</para>
		/// </param>
		/// <param name="InObstacleBufferFeatures">
		/// <para>Input Obstacle Buffer Features</para>
		/// <para>Obstacle area features representing approach and departure safety buffers around obstacles.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>The output raster dataset.</para>
		/// </param>
		public GenerateHLZSuitability(object InSlopeRaster, object InLandCoverRaster, object InObstacleBufferFeatures, object OutRaster)
		{
			this.InSlopeRaster = InSlopeRaster;
			this.InLandCoverRaster = InLandCoverRaster;
			this.InObstacleBufferFeatures = InObstacleBufferFeatures;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate HLZ Suitability</para>
		/// </summary>
		public override string DisplayName() => "Generate HLZ Suitability";

		/// <summary>
		/// <para>Tool Name : GenerateHLZSuitability</para>
		/// </summary>
		public override string ToolName() => "GenerateHLZSuitability";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.GenerateHLZSuitability</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.GenerateHLZSuitability";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise() => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSlopeRaster, InLandCoverRaster, InObstacleBufferFeatures, OutRaster };

		/// <summary>
		/// <para>Input Slope Raster</para>
		/// <para>The reclassified slope raster with values 1 (acceptable) and 2 (acceptable with caution). All other values will be excluded from the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InSlopeRaster { get; set; }

		/// <summary>
		/// <para>Input Land Cover Raster</para>
		/// <para>The reclassified land cover raster with values 1 (acceptable) and 2 (acceptable with caution). All other values will be excluded from the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InLandCoverRaster { get; set; }

		/// <summary>
		/// <para>Input Obstacle Buffer Features</para>
		/// <para>Obstacle area features representing approach and departure safety buffers around obstacles.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InObstacleBufferFeatures { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>The output raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

	}
}
