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
	/// <para>TIN Triangle</para>
	/// <para>TIN 三角形</para>
	/// <para>将三角面从 TIN 数据集导出至面要素，并为每个三角提供坡度、坡向以及山体阴影和标签值的可选属性。</para>
	/// </summary>
	public class TinTriangle : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>待处理的 TIN 数据集。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </param>
		public TinTriangle(object InTin, object OutFeatureClass)
		{
			this.InTin = InTin;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : TIN 三角形</para>
		/// </summary>
		public override string DisplayName() => "TIN 三角形";

		/// <summary>
		/// <para>Tool Name : TinTriangle</para>
		/// </summary>
		public override string ToolName() => "TinTriangle";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TinTriangle</para>
		/// </summary>
		public override string ExcuteName() => "3d.TinTriangle";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTin, OutFeatureClass, Units!, ZFactor!, Hillshade!, TagField! };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>待处理的 TIN 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

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
		/// <para>Z Factor</para>
		/// <para>Z 值将乘上的系数。 此值通常用于转换 z 线性单位来匹配 x,y 线性单位。 默认值为 1，此时高程值保持不变。 如果输入表面的空间参考具有已指定线性单位的 z 基准，则此参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>HILLSHADE azimuth, altitude</para>
		/// <para>为要素图层输出应用山体阴影效果时指定光源的方位角和高度角。方位角的范围为 0 至 360 度，高度角的范围为 0 至 90。方位角为 45 度，高度角为 30 度的输入形式为“HILLSHADE 45,30”。</para>
		/// <para><see cref="HillshadeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Hillshade { get; set; }

		/// <summary>
		/// <para>Tag Value Field</para>
		/// <para>将存储三角形标签值的输出要素中的字段名称。该参数默认为空，将导致标签值无法写入输出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? TagField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TinTriangle SetEnviroment(object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, int? autoCommit = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
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

		/// <summary>
		/// <para>HILLSHADE azimuth, altitude</para>
		/// </summary>
		public enum HillshadeEnum 
		{
			/// <summary>
			/// <para>HILLSHADE azimuth, altitude</para>
			/// </summary>
			[GPValue("HILLSHADE")]
			[Description("HILLSHADE")]
			HILLSHADE,

		}

#endregion
	}
}
