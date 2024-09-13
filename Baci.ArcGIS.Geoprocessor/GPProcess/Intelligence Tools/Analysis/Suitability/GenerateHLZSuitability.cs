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
	/// <para>生成 HLZ 适宜性</para>
	/// <para>根据重分类坡度、重分类土地覆被和障碍物缓冲区创建直升机降落区 (HLZ) 适宜性栅格图层。</para>
	/// </summary>
	public class GenerateHLZSuitability : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSlopeRaster">
		/// <para>Input Slope Raster</para>
		/// <para>值为 1（可接受）和 2（可谨慎接受）的重分类坡度栅格。所有其他值将从分析中排除。</para>
		/// </param>
		/// <param name="InLandCoverRaster">
		/// <para>Input Land Cover Raster</para>
		/// <para>值为 1（可接受）和 2（可谨慎接受）的重分类土地覆被栅格。所有其他值将从分析中排除。</para>
		/// </param>
		/// <param name="InObstacleBufferFeatures">
		/// <para>Input Obstacle Buffer Features</para>
		/// <para>表示到达和离开障碍物周围安全缓冲区的障碍物区域要素。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>输出栅格数据集。</para>
		/// </param>
		public GenerateHLZSuitability(object InSlopeRaster, object InLandCoverRaster, object InObstacleBufferFeatures, object OutRaster)
		{
			this.InSlopeRaster = InSlopeRaster;
			this.InLandCoverRaster = InLandCoverRaster;
			this.InObstacleBufferFeatures = InObstacleBufferFeatures;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成 HLZ 适宜性</para>
		/// </summary>
		public override string DisplayName() => "生成 HLZ 适宜性";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSlopeRaster, InLandCoverRaster, InObstacleBufferFeatures, OutRaster };

		/// <summary>
		/// <para>Input Slope Raster</para>
		/// <para>值为 1（可接受）和 2（可谨慎接受）的重分类坡度栅格。所有其他值将从分析中排除。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InSlopeRaster { get; set; }

		/// <summary>
		/// <para>Input Land Cover Raster</para>
		/// <para>值为 1（可接受）和 2（可谨慎接受）的重分类土地覆被栅格。所有其他值将从分析中排除。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InLandCoverRaster { get; set; }

		/// <summary>
		/// <para>Input Obstacle Buffer Features</para>
		/// <para>表示到达和离开障碍物周围安全缓冲区的障碍物区域要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InObstacleBufferFeatures { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>输出栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

	}
}
