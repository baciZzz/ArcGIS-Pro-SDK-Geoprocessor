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
	/// <para>Remove Overlap (multiple)</para>
	/// <para>移除重叠（多个）</para>
	/// <para>移除多个输入图层中包含的面之间的重叠。</para>
	/// </summary>
	public class RemoveOverlapMultiple : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>包含重叠面的输入要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含新面要素的要素类。</para>
		/// </param>
		public RemoveOverlapMultiple(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 移除重叠（多个）</para>
		/// </summary>
		public override string DisplayName() => "移除重叠（多个）";

		/// <summary>
		/// <para>Tool Name : RemoveOverlapMultiple</para>
		/// </summary>
		public override string ToolName() => "RemoveOverlapMultiple";

		/// <summary>
		/// <para>Tool Excute Name : analysis.RemoveOverlapMultiple</para>
		/// </summary>
		public override string ExcuteName() => "analysis.RemoveOverlapMultiple";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, Method!, JoinAttributes! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>包含重叠面的输入要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含新面要素的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>指定如何移除面之间的重叠。</para>
		/// <para>中心线—将通过创建在面之间均匀分布相交区域的边界移除重叠。这是默认设置。</para>
		/// <para>泰森多边形—重叠将通过使用直线划分相交区域进行移除。</para>
		/// <para>Grid—将通过创建用于定义面之间的自然划分的平行线格网移除重叠。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "CENTER_LINE";

		/// <summary>
		/// <para>Attributes To Join</para>
		/// <para>指定将复制到输出的输入图层的属性。</para>
		/// <para>所有属性—输入要素的所有属性都将传递到输出要素类。这是默认设置。</para>
		/// <para>除要素 ID 外的所有属性—输入要素的所有属性（FID 字段除外）都将传递到输出要素类。</para>
		/// <para>仅要素 ID—仅输入要素的 FID 字段将传递到输出要素类。</para>
		/// <para><see cref="JoinAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? JoinAttributes { get; set; } = "ALL";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveOverlapMultiple SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>中心线—将通过创建在面之间均匀分布相交区域的边界移除重叠。这是默认设置。</para>
			/// </summary>
			[GPValue("CENTER_LINE")]
			[Description("中心线")]
			Center_Line,

			/// <summary>
			/// <para>泰森多边形—重叠将通过使用直线划分相交区域进行移除。</para>
			/// </summary>
			[GPValue("THIESSEN")]
			[Description("泰森多边形")]
			Thiessen,

			/// <summary>
			/// <para>Grid—将通过创建用于定义面之间的自然划分的平行线格网移除重叠。</para>
			/// </summary>
			[GPValue("GRID")]
			[Description("Grid")]
			Grid,

		}

		/// <summary>
		/// <para>Attributes To Join</para>
		/// </summary>
		public enum JoinAttributesEnum 
		{
			/// <summary>
			/// <para>所有属性—输入要素的所有属性都将传递到输出要素类。这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有属性")]
			All_attributes,

			/// <summary>
			/// <para>除要素 ID 外的所有属性—输入要素的所有属性（FID 字段除外）都将传递到输出要素类。</para>
			/// </summary>
			[GPValue("NO_FID")]
			[Description("除要素 ID 外的所有属性")]
			All_attributes_except_feature_IDs,

			/// <summary>
			/// <para>仅要素 ID—仅输入要素的 FID 字段将传递到输出要素类。</para>
			/// </summary>
			[GPValue("ONLY_FID")]
			[Description("仅要素 ID")]
			Only_feature_IDs,

		}

#endregion
	}
}
