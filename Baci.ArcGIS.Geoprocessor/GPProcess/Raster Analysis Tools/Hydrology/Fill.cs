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
	/// <para>Fill</para>
	/// <para>填洼</para>
	/// <para>通过填充表面栅格中的汇来移除数据中的小缺陷。</para>
	/// </summary>
	public class Fill : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputsurfaceraster">
		/// <para>Input Surface Raster</para>
		/// <para>输入栅格表示连续表面。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>输出填充栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。 如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </param>
		public Fill(object Inputsurfaceraster, object Outputname)
		{
			this.Inputsurfaceraster = Inputsurfaceraster;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : 填洼</para>
		/// </summary>
		public override string DisplayName() => "填洼";

		/// <summary>
		/// <para>Tool Name : 填洼</para>
		/// </summary>
		public override string ToolName() => "填洼";

		/// <summary>
		/// <para>Tool Excute Name : ra.Fill</para>
		/// </summary>
		public override string ExcuteName() => "ra.Fill";

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
		public override object[] Parameters() => new object[] { Inputsurfaceraster, Outputname, Zlimit!, Outputraster! };

		/// <summary>
		/// <para>Input Surface Raster</para>
		/// <para>输入栅格表示连续表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputsurfaceraster { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出填充栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。 如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Z Limit</para>
		/// <para>要填充的凹陷点与其倾泻点之间的最大高程差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Zlimit { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Fill SetEnviroment(object? cellSize = null, object? extent = null, object? mask = null, object? outputCoordinateSystem = null, object? pyramid = null, object? snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, snapRaster: snapRaster);
			return this;
		}

	}
}
