using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Feature To Line</para>
	/// <para>要素转线</para>
	/// <para>创建包含通过以下方式生成的线的要素类：将面边界转换为线，或者分割线、面或在两要素的相交处对两要素进行分割。</para>
	/// </summary>
	public class FeatureToLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入要素可以是线或面，或是两者兼而有之。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出线要素类。</para>
		/// </param>
		public FeatureToLine(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 要素转线</para>
		/// </summary>
		public override string DisplayName() => "要素转线";

		/// <summary>
		/// <para>Tool Name : FeatureToLine</para>
		/// </summary>
		public override string ToolName() => "FeatureToLine";

		/// <summary>
		/// <para>Tool Excute Name : management.FeatureToLine</para>
		/// </summary>
		public override string ExcuteName() => "management.FeatureToLine";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, ClusterTolerance, Attributes };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入要素可以是线或面，或是两者兼而有之。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出线要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>进行空间计算时所有要素坐标之间的最小距离以及坐标可以沿 X 和/或 Y 方向移动的距离。默认 XY 容差设定值为 0.001 米，或者为其等效值（以要素单位表示）。</para>
		/// <para>更改此参数的值可能会导致出现故障或意外结果。建议不要修改此参数。已将其从工具对话框的视图中移除。默认情况下，将使用输入要素类的空间参考 x,y 容差属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object ClusterTolerance { get; set; }

		/// <summary>
		/// <para>Preserve attributes</para>
		/// <para>指定是在输出要素类中保留还是忽略输入要素属性。</para>
		/// <para>选中 - 在输出要素中保留输入属性。这是默认设置。</para>
		/// <para>未选中 - 在输出要素中忽略输入属性。</para>
		/// <para><see cref="AttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Attributes { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeatureToLine SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , object extent = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Preserve attributes</para>
		/// </summary>
		public enum AttributesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ATTRIBUTES")]
			ATTRIBUTES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ATTRIBUTES")]
			NO_ATTRIBUTES,

		}

#endregion
	}
}
