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
	/// <para>Split</para>
	/// <para>分割</para>
	/// <para>分割具有叠加要素的输入以创建输出要素类的子集。</para>
	/// </summary>
	public class Split : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要分割的要素。</para>
		/// </param>
		/// <param name="SplitFeatures">
		/// <para>Split Features</para>
		/// <para>包含表格字段的面要素，其中表格字段的唯一值用于分割输入要素并提供输出要素类的名称。</para>
		/// </param>
		/// <param name="SplitField">
		/// <para>Split Field</para>
		/// <para>用于分割输入要素的字符字段。 此字段值可标识用于创建每个输出要素类的分割要素。 “分割字段”的唯一值用于生成输出要素类的名称。</para>
		/// </param>
		/// <param name="OutWorkspace">
		/// <para>Target Workspace</para>
		/// <para>用来存储输出要素类的现有工作空间。</para>
		/// </param>
		public Split(object InFeatures, object SplitFeatures, object SplitField, object OutWorkspace)
		{
			this.InFeatures = InFeatures;
			this.SplitFeatures = SplitFeatures;
			this.SplitField = SplitField;
			this.OutWorkspace = OutWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : 分割</para>
		/// </summary>
		public override string DisplayName() => "分割";

		/// <summary>
		/// <para>Tool Name : 分割</para>
		/// </summary>
		public override string ToolName() => "分割";

		/// <summary>
		/// <para>Tool Excute Name : analysis.Split</para>
		/// </summary>
		public override string ExcuteName() => "analysis.Split";

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
		public override object[] Parameters() => new object[] { InFeatures, SplitFeatures, SplitField, OutWorkspace, ClusterTolerance!, OutWorkspace2! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要分割的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Split Features</para>
		/// <para>包含表格字段的面要素，其中表格字段的唯一值用于分割输入要素并提供输出要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object SplitFeatures { get; set; }

		/// <summary>
		/// <para>Split Field</para>
		/// <para>用于分割输入要素的字符字段。 此字段值可标识用于创建每个输出要素类的分割要素。 “分割字段”的唯一值用于生成输出要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object SplitField { get; set; }

		/// <summary>
		/// <para>Target Workspace</para>
		/// <para>用来存储输出要素类的现有工作空间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>所有要素坐标（节点和折点）之间的最小距离以及坐标可以沿 x 和/或 y 方向移动的距离。 如果将此值设置的较高，则数据会具有较低的坐标精度；如果将此值设置的较低，则数据会具有较高的坐标精度。</para>
		/// <para>更改此参数的值可能会导致出现故障或意外结果。 建议不要修改此参数。 已将其从工具对话框的视图中移除。 默认情况下，将使用输入要素类的空间参考 x,y 容差属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? ClusterTolerance { get; set; }

		/// <summary>
		/// <para>Updated Target Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutWorkspace2 { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Split SetEnviroment(object? MDomain = null, double? MResolution = null, double? MTolerance = null, object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, object? configKeyword = null, object? extent = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, object? parallelProcessingFactor = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

	}
}
