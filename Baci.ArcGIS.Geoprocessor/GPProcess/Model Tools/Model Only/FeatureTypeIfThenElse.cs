using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>If Feature Type Is</para>
	/// <para>如果要素类型为</para>
	/// <para>用于评估要素类是否为指定要素类型。</para>
	/// </summary>
	public class FeatureTypeIfThenElse : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要评估的输入要素图层。</para>
		/// </param>
		/// <param name="FeatureType">
		/// <para>Feature Type</para>
		/// <para>正在进行评估的要素类型。</para>
		/// <para>注记—评估输入要素是否为注记要素。</para>
		/// <para>尺寸—评估输入要素是否为尺寸要素。</para>
		/// <para>边—评估输入要素是否为边要素。</para>
		/// <para>交汇点—评估输入要素是否为交汇点要素。</para>
		/// <para>线— 评估输入要素是否为线要素。</para>
		/// <para>点—评估输入要素是否为点要素。</para>
		/// <para>面—评估输入要素是否为面要素。</para>
		/// <para>多面体—评估输入要素是否为多面体要素。</para>
		/// <para><see cref="FeatureTypeEnum"/></para>
		/// </param>
		public FeatureTypeIfThenElse(object InFeatures, object FeatureType)
		{
			this.InFeatures = InFeatures;
			this.FeatureType = FeatureType;
		}

		/// <summary>
		/// <para>Tool Display Name : 如果要素类型为</para>
		/// </summary>
		public override string DisplayName() => "如果要素类型为";

		/// <summary>
		/// <para>Tool Name : FeatureTypeIfThenElse</para>
		/// </summary>
		public override string ToolName() => "FeatureTypeIfThenElse";

		/// <summary>
		/// <para>Tool Excute Name : mb.FeatureTypeIfThenElse</para>
		/// </summary>
		public override string ExcuteName() => "mb.FeatureTypeIfThenElse";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise() => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, FeatureType, True!, False! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要评估的输入要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Feature Type</para>
		/// <para>正在进行评估的要素类型。</para>
		/// <para>注记—评估输入要素是否为注记要素。</para>
		/// <para>尺寸—评估输入要素是否为尺寸要素。</para>
		/// <para>边—评估输入要素是否为边要素。</para>
		/// <para>交汇点—评估输入要素是否为交汇点要素。</para>
		/// <para>线— 评估输入要素是否为线要素。</para>
		/// <para>点—评估输入要素是否为点要素。</para>
		/// <para>面—评估输入要素是否为面要素。</para>
		/// <para>多面体—评估输入要素是否为多面体要素。</para>
		/// <para><see cref="FeatureTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object FeatureType { get; set; }

		/// <summary>
		/// <para>True</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? True { get; set; } = "false";

		/// <summary>
		/// <para>False</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? False { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Feature Type</para>
		/// </summary>
		public enum FeatureTypeEnum 
		{
			/// <summary>
			/// <para>注记—评估输入要素是否为注记要素。</para>
			/// </summary>
			[GPValue("ANNOTATION")]
			[Description("注记")]
			Annotation,

			/// <summary>
			/// <para>尺寸—评估输入要素是否为尺寸要素。</para>
			/// </summary>
			[GPValue("DIMENSION")]
			[Description("尺寸")]
			Dimension,

			/// <summary>
			/// <para>边—评估输入要素是否为边要素。</para>
			/// </summary>
			[GPValue("EDGE")]
			[Description("边")]
			Edge,

			/// <summary>
			/// <para>交汇点—评估输入要素是否为交汇点要素。</para>
			/// </summary>
			[GPValue("JUNCTION")]
			[Description("交汇点")]
			Junction,

			/// <summary>
			/// <para>线— 评估输入要素是否为线要素。</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("线")]
			Line,

			/// <summary>
			/// <para>点—评估输入要素是否为点要素。</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点")]
			Point,

			/// <summary>
			/// <para>面—评估输入要素是否为面要素。</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("面")]
			Polygon,

			/// <summary>
			/// <para>多面体—评估输入要素是否为多面体要素。</para>
			/// </summary>
			[GPValue("MULTIPATCH")]
			[Description("多面体")]
			Multipatch,

		}

#endregion
	}
}
