using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.RasterAnalysisTools
{
	/// <summary>
	/// <para>Convert Feature To Raster</para>
	/// <para>要素转栅格</para>
	/// <para>将要素转换为栅格数据集。</para>
	/// </summary>
	public class ConvertFeatureToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputfeatures">
		/// <para>Input Features</para>
		/// <para>输入要素图层。</para>
		/// </param>
		/// <param name="Valuefield">
		/// <para>Value field</para>
		/// <para>选择用于向输出栅格分配值的字段。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>输出栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。 如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </param>
		public ConvertFeatureToRaster(object Inputfeatures, object Valuefield, object Outputname)
		{
			this.Inputfeatures = Inputfeatures;
			this.Valuefield = Valuefield;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : 要素转栅格</para>
		/// </summary>
		public override string DisplayName() => "要素转栅格";

		/// <summary>
		/// <para>Tool Name : ConvertFeatureToRaster</para>
		/// </summary>
		public override string ToolName() => "ConvertFeatureToRaster";

		/// <summary>
		/// <para>Tool Excute Name : ra.ConvertFeatureToRaster</para>
		/// </summary>
		public override string ExcuteName() => "ra.ConvertFeatureToRaster";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise() => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "outputCoordinateSystem", "pyramid", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputfeatures, Valuefield, Outputname, Outputcellsize!, Outputraster! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Inputfeatures { get; set; }

		/// <summary>
		/// <para>Value field</para>
		/// <para>选择用于向输出栅格分配值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object Valuefield { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。 如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Output Cell Size</para>
		/// <para>输入输出栅格的像元大小和单位。</para>
		/// <para>单位可以是千米、米、英里或英尺。</para>
		/// <para>默认单位是米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? Outputcellsize { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConvertFeatureToRaster SetEnviroment(object? cellSize = null, object? extent = null, object? outputCoordinateSystem = null, object? pyramid = null, object? snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, snapRaster: snapRaster);
			return this;
		}

	}
}
