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
	/// <para>Surface Slope</para>
	/// <para>表面坡度</para>
	/// <para>创建表示不规则表面的坡度值范围的面要素。</para>
	/// </summary>
	public class SurfaceSlope : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>TIN、terrain 或 LAS 数据集，其坡度测量值将写入输出面要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </param>
		public SurfaceSlope(object InSurface, object OutFeatureClass)
		{
			this.InSurface = InSurface;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 表面坡度</para>
		/// </summary>
		public override string DisplayName() => "表面坡度";

		/// <summary>
		/// <para>Tool Name : SurfaceSlope</para>
		/// </summary>
		public override string ToolName() => "SurfaceSlope";

		/// <summary>
		/// <para>Tool Excute Name : 3d.SurfaceSlope</para>
		/// </summary>
		public override string ExcuteName() => "3d.SurfaceSlope";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "terrainMemoryUsage", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurface, OutFeatureClass, Units!, ClassBreaksTable!, SlopeField!, ZFactor!, PyramidLevelResolution! };

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>TIN、terrain 或 LAS 数据集，其坡度测量值将写入输出面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Slope Units</para>
		/// <para>在计算坡度中所用的测量单位。</para>
		/// <para>百分比—坡度以百分比值形式表示。这是默认设置。</para>
		/// <para>度—坡度以相对于水平面的倾角形式表示。</para>
		/// <para><see cref="UnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Units { get; set; } = "PERCENT";

		/// <summary>
		/// <para>Class Breaks Table</para>
		/// <para>包含分类间隔的表，将用于分组输出要素。此表格的第一列指示中断点，而第二列提供分类代码。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? ClassBreaksTable { get; set; }

		/// <summary>
		/// <para>Slope Field</para>
		/// <para>包含坡度值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? SlopeField { get; set; } = "SlopeCode";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>Z 值将乘上的系数。 此值通常用于转换 z 线性单位来匹配 x,y 线性单位。 默认值为 1，此时高程值保持不变。 如果输入表面的空间参考具有已指定线性单位的 z 基准，则此参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>将使用 terrain 金字塔等级的 z 容差或窗口大小分辨率。 默认值为 0，或全分辨率。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SurfaceSlope SetEnviroment(object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, int? autoCommit = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, bool? terrainMemoryUsage = null, object? workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, terrainMemoryUsage: terrainMemoryUsage, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Slope Units</para>
		/// </summary>
		public enum UnitsEnum 
		{
			/// <summary>
			/// <para>百分比—坡度以百分比值形式表示。这是默认设置。</para>
			/// </summary>
			[GPValue("PERCENT")]
			[Description("百分比")]
			Percent,

			/// <summary>
			/// <para>度—坡度以相对于水平面的倾角形式表示。</para>
			/// </summary>
			[GPValue("DEGREE")]
			[Description("度")]
			Degree,

		}

#endregion
	}
}
