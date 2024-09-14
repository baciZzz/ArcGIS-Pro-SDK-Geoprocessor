using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Clip</para>
	/// <para>裁剪</para>
	/// <para>提取与裁剪要素相重叠的输入要素。</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.AnalysisTools.PairwiseClip"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.AnalysisTools.PairwiseClip))]
	public class Clip : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features or Dataset</para>
		/// <para>要裁剪的要素。</para>
		/// </param>
		/// <param name="ClipFeatures">
		/// <para>Clip Features</para>
		/// <para>用于裁剪输入要素的要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Features or Dataset</para>
		/// <para>要创建的数据集。</para>
		/// </param>
		public Clip(object InFeatures, object ClipFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.ClipFeatures = ClipFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 裁剪</para>
		/// </summary>
		public override string DisplayName() => "裁剪";

		/// <summary>
		/// <para>Tool Name : 裁剪</para>
		/// </summary>
		public override string ToolName() => "裁剪";

		/// <summary>
		/// <para>Tool Excute Name : analysis.Clip</para>
		/// </summary>
		public override string ExcuteName() => "analysis.Clip";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "configKeyword", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ClipFeatures, OutFeatureClass, ClusterTolerance };

		/// <summary>
		/// <para>Input Features or Dataset</para>
		/// <para>要裁剪的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Clip Features</para>
		/// <para>用于裁剪输入要素的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline", "Point", "Multipoint")]
		public object ClipFeatures { get; set; }

		/// <summary>
		/// <para>Output Features or Dataset</para>
		/// <para>要创建的数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>所有要素坐标之间的最小距离以及坐标可以沿 x 或 y 方向移动的距离。 如果数据的坐标精度较低，则设置较高的值；如果数据的坐标精度较高，则设置较低的值。</para>
		/// <para>更改此参数的值可能会导致出现故障或意外结果。建议不要修改此参数。已将其从工具对话框的视图中移除。默认情况下，将使用输入要素类的空间参考 x,y 容差属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object ClusterTolerance { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Clip SetEnviroment(object MDomain = null, object MResolution = null, object MTolerance = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, object configKeyword = null, object extent = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, object parallelProcessingFactor = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

	}
}
