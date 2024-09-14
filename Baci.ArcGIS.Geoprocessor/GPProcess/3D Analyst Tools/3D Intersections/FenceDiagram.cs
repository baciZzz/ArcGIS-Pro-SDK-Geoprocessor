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
	/// <para>Fence Diagram</para>
	/// <para>栅状图</para>
	/// <para>用于构建表面集合的垂直截面。</para>
	/// </summary>
	public class FenceDiagram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLineFeatures">
		/// <para>Input Line Features</para>
		/// <para>构建栅状图时使用的线要素。</para>
		/// </param>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>构建栅状图时使用的表面。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Multipatch Feature Class</para>
		/// <para>由用于描绘栅状图的垂直面组成的输出多面体。</para>
		/// </param>
		public FenceDiagram(object InLineFeatures, object InSurface, object OutFeatureClass)
		{
			this.InLineFeatures = InLineFeatures;
			this.InSurface = InSurface;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 栅状图</para>
		/// </summary>
		public override string DisplayName() => "栅状图";

		/// <summary>
		/// <para>Tool Name : FenceDiagram</para>
		/// </summary>
		public override string ToolName() => "FenceDiagram";

		/// <summary>
		/// <para>Tool Excute Name : 3d.FenceDiagram</para>
		/// </summary>
		public override string ExcuteName() => "3d.FenceDiagram";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "ZDomain", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLineFeatures, InSurface, OutFeatureClass, Method, FloorHeight, CeilingHeight, SampleDistance };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>构建栅状图时使用的线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLineFeatures { get; set; }

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>构建栅状图时使用的表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Multipatch Feature Class</para>
		/// <para>由用于描绘栅状图的垂直面组成的输出多面体。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Interpolation Method</para>
		/// <para>此插值法用于在构建栅状图时从 TIN 表面获取 z 值。该参数不适用于栅格表面。</para>
		/// <para>线性—将使用线性插值法。这是默认设置。</para>
		/// <para>自然邻域法—将使用自然邻域插值法。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Floor Height</para>
		/// <para>用于定义栅状图最低高度的恒定高度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Height Extensions")]
		public object FloorHeight { get; set; }

		/// <summary>
		/// <para>Ceiling Height</para>
		/// <para>用于定义栅状图最高高度的恒定高度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Height Extensions")]
		public object CeilingHeight { get; set; }

		/// <summary>
		/// <para>Sample Distance</para>
		/// <para>用于确定从底层表面插入高度测量值的位置的水平距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SampleDistance { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FenceDiagram SetEnviroment(object XYDomain = null, object ZDomain = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, ZDomain: ZDomain, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Interpolation Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>线性—将使用线性插值法。这是默认设置。</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("线性")]
			Linear,

			/// <summary>
			/// <para>自然邻域法—将使用自然邻域插值法。</para>
			/// </summary>
			[GPValue("NATURAL_NEIGHBORS")]
			[Description("自然邻域法")]
			Natural_Neighbors,

		}

#endregion
	}
}
