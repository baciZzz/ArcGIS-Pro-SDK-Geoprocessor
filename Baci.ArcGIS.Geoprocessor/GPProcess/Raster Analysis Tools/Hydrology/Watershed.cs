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
	/// <para>Watershed</para>
	/// <para>集水区</para>
	/// <para>确定栅格中一组像元之上的汇流区域。</para>
	/// </summary>
	public class Watershed : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputflowdirectionraster">
		/// <para>Input Flow Direction Raster</para>
		/// <para>根据每个像元来显示流向的输入栅格。</para>
		/// </param>
		/// <param name="Inpourpointrasterorfeatures">
		/// <para>Input Pour Point Raster or Features</para>
		/// <para>输入倾泻点位置。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>输出分水岭栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。 如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </param>
		public Watershed(object Inputflowdirectionraster, object Inpourpointrasterorfeatures, object Outputname)
		{
			this.Inputflowdirectionraster = Inputflowdirectionraster;
			this.Inpourpointrasterorfeatures = Inpourpointrasterorfeatures;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : 集水区</para>
		/// </summary>
		public override string DisplayName() => "集水区";

		/// <summary>
		/// <para>Tool Name : 集水区</para>
		/// </summary>
		public override string ToolName() => "集水区";

		/// <summary>
		/// <para>Tool Excute Name : ra.Watershed</para>
		/// </summary>
		public override string ExcuteName() => "ra.Watershed";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "pyramid", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputflowdirectionraster, Inpourpointrasterorfeatures, Outputname, Pourpointfield!, Outputraster! };

		/// <summary>
		/// <para>Input Flow Direction Raster</para>
		/// <para>根据每个像元来显示流向的输入栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputflowdirectionraster { get; set; }

		/// <summary>
		/// <para>Input Pour Point Raster or Features</para>
		/// <para>输入倾泻点位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inpourpointrasterorfeatures { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出分水岭栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。 如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Pour Point Field</para>
		/// <para>用于为倾泻点位置赋值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Pourpointfield { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Watershed SetEnviroment(object? cellSize = null , object? extent = null , object? mask = null , object? outputCoordinateSystem = null , object? pyramid = null , object? snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, snapRaster: snapRaster);
			return this;
		}

	}
}
