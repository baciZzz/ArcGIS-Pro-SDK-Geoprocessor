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
	/// <para>Drop Zone Suitability</para>
	/// <para>降落区适宜性</para>
	/// <para>根据给定坡度和植被数据在指定感兴趣区域中表示适宜空降设备或跳伞人员降落的降落区位置。</para>
	/// </summary>
	public class DropZones : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSlopeRaster">
		/// <para>Input Percent Slope Raster</para>
		/// <para>用于确定降落区适宜性坡度分量的斜坡栅格百分比。</para>
		/// </param>
		/// <param name="InVegetationFeatures">
		/// <para>Input Combined Vegetation Features</para>
		/// <para>定义组合植被和土地覆盖类型的要素。这些要素用于查找降落区覆盖有适宜植被的区域。</para>
		/// </param>
		/// <param name="ClipFeatures">
		/// <para>Clip Features</para>
		/// <para>在其中找到适宜降落区的区域。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>显示降落区 terrain 适宜性的输出要素类。</para>
		/// </param>
		public DropZones(object InSlopeRaster, object InVegetationFeatures, object ClipFeatures, object OutFeatureClass)
		{
			this.InSlopeRaster = InSlopeRaster;
			this.InVegetationFeatures = InVegetationFeatures;
			this.ClipFeatures = ClipFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 降落区适宜性</para>
		/// </summary>
		public override string DisplayName() => "降落区适宜性";

		/// <summary>
		/// <para>Tool Name : DropZones</para>
		/// </summary>
		public override string ToolName() => "DropZones";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.DropZones</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.DropZones";

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
		public override object[] Parameters() => new object[] { InSlopeRaster, InVegetationFeatures, ClipFeatures, OutFeatureClass };

		/// <summary>
		/// <para>Input Percent Slope Raster</para>
		/// <para>用于确定降落区适宜性坡度分量的斜坡栅格百分比。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InSlopeRaster { get; set; }

		/// <summary>
		/// <para>Input Combined Vegetation Features</para>
		/// <para>定义组合植被和土地覆盖类型的要素。这些要素用于查找降落区覆盖有适宜植被的区域。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InVegetationFeatures { get; set; }

		/// <summary>
		/// <para>Clip Features</para>
		/// <para>在其中找到适宜降落区的区域。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object ClipFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>显示降落区 terrain 适宜性的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

	}
}
