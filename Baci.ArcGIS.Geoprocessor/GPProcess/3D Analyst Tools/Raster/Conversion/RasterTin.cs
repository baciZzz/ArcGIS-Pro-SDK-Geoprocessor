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
	/// <para>Raster To TIN</para>
	/// <para>栅格转 TIN</para>
	/// <para>将栅格转换为不规则三角网 (TIN) 数据集。</para>
	/// </summary>
	public class RasterTin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>待处理的栅格。</para>
		/// </param>
		/// <param name="OutTin">
		/// <para>Output TIN</para>
		/// <para>将要生成的 TIN 数据集。</para>
		/// </param>
		public RasterTin(object InRaster, object OutTin)
		{
			this.InRaster = InRaster;
			this.OutTin = OutTin;
		}

		/// <summary>
		/// <para>Tool Display Name : 栅格转 TIN</para>
		/// </summary>
		public override string DisplayName() => "栅格转 TIN";

		/// <summary>
		/// <para>Tool Name : RasterTin</para>
		/// </summary>
		public override string ToolName() => "RasterTin";

		/// <summary>
		/// <para>Tool Excute Name : 3d.RasterTin</para>
		/// </summary>
		public override string ExcuteName() => "3d.RasterTin";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "tinSaveVersion", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutTin, ZTolerance!, MaxPoints!, ZFactor! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>待处理的栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output TIN</para>
		/// <para>将要生成的 TIN 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETin()]
		public object OutTin { get; set; }

		/// <summary>
		/// <para>Z Tolerance</para>
		/// <para>输入栅格与输出 TIN 之间所允许的最大高度差（z 单位）。默认情况下，z 容差是输入栅格 z 范围的 1/10。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZTolerance { get; set; }

		/// <summary>
		/// <para>Maximum Number of Points</para>
		/// <para>将在处理过程终止前添加到 TIN 的最大点数。默认情况下，该过程将一直持续到所有点被添加完。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaxPoints { get; set; } = "1500000";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>在生成的 TIN 数据集中与栅格的高度值相乘的因子。此值通常用于转换 Z 单位来匹配 XY 单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterTin SetEnviroment(object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? tinSaveVersion = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, tinSaveVersion: tinSaveVersion, workspace: workspace);
			return this;
		}

	}
}
