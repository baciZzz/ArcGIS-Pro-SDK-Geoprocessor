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
	/// <para>Surface Volume</para>
	/// <para>表面体积</para>
	/// <para>计算表面和参考平面之间区域的面积和体积。</para>
	/// </summary>
	public class SurfaceVolume : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>待处理的栅格、TIN 或 terrain 表面。</para>
		/// </param>
		public SurfaceVolume(object InSurface)
		{
			this.InSurface = InSurface;
		}

		/// <summary>
		/// <para>Tool Display Name : 表面体积</para>
		/// </summary>
		public override string DisplayName() => "表面体积";

		/// <summary>
		/// <para>Tool Name : SurfaceVolume</para>
		/// </summary>
		public override string ToolName() => "SurfaceVolume";

		/// <summary>
		/// <para>Tool Excute Name : 3d.SurfaceVolume</para>
		/// </summary>
		public override string ExcuteName() => "3d.SurfaceVolume";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurface, OutTextFile, ReferencePlane, BaseZ, ZFactor, PyramidLevelResolution };

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>待处理的栅格、TIN 或 terrain 表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Text File</para>
		/// <para>包含面积和体积计算的以逗号分隔的 ASCII 文本文件。如果该文件已经存在，新结果将会追加至该文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object OutTextFile { get; set; }

		/// <summary>
		/// <para>Reference Plane</para>
		/// <para>要为之计算结果的参考平面的方向。</para>
		/// <para>平面上方—体积和面积计算将表示指定平面高度和位于该平面上方的部分表面之间的空间区域。这是默认设置。</para>
		/// <para>平面下方—体积和面积计算将表示指定平面高度和位于该平面下方的部分表面之间的空间区域。</para>
		/// <para><see cref="ReferencePlaneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ReferencePlane { get; set; } = "ABOVE";

		/// <summary>
		/// <para>Plane Height</para>
		/// <para>将用于计算面积和体积的平面的 Z 值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object BaseZ { get; set; }

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>Z 值将乘上的系数。 此值通常用于转换 z 线性单位来匹配 x,y 线性单位。 默认值为 1，此时高程值保持不变。 如果输入表面的空间参考具有已指定线性单位的 z 基准，则此参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>将使用 terrain 金字塔等级的 z 容差或窗口大小分辨率。 默认值为 0，或全分辨率。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SurfaceVolume SetEnviroment(object extent = null, object workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Reference Plane</para>
		/// </summary>
		public enum ReferencePlaneEnum 
		{
			/// <summary>
			/// <para>平面上方—体积和面积计算将表示指定平面高度和位于该平面上方的部分表面之间的空间区域。这是默认设置。</para>
			/// </summary>
			[GPValue("ABOVE")]
			[Description("平面上方")]
			Above_the_Plane,

			/// <summary>
			/// <para>平面下方—体积和面积计算将表示指定平面高度和位于该平面下方的部分表面之间的空间区域。</para>
			/// </summary>
			[GPValue("BELOW")]
			[Description("平面下方")]
			Below_the_Plane,

		}

#endregion
	}
}
