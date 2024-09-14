using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.EditingTools
{
	/// <summary>
	/// <para>Rubbersheet Features</para>
	/// <para>橡皮页变换要素</para>
	/// <para>利用指定的橡皮页变换链接，通过橡皮页变换对输入要素进行空间调整修改，从而使输入要素更好地与所需目标要素对齐。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RubbersheetFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要调整的输入要素。可以为点、线、面或注记。</para>
		/// </param>
		/// <param name="InLinkFeatures">
		/// <para>Input Link Features</para>
		/// <para>表示橡皮页变换常规链接的输入线要素。</para>
		/// </param>
		public RubbersheetFeatures(object InFeatures, object InLinkFeatures)
		{
			this.InFeatures = InFeatures;
			this.InLinkFeatures = InLinkFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 橡皮页变换要素</para>
		/// </summary>
		public override string DisplayName() => "橡皮页变换要素";

		/// <summary>
		/// <para>Tool Name : RubbersheetFeatures</para>
		/// </summary>
		public override string ToolName() => "RubbersheetFeatures";

		/// <summary>
		/// <para>Tool Excute Name : edit.RubbersheetFeatures</para>
		/// </summary>
		public override string ExcuteName() => "edit.RubbersheetFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Editing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Editing Tools";

		/// <summary>
		/// <para>Toolbox Alise : edit</para>
		/// </summary>
		public override string ToolboxAlise() => "edit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, InLinkFeatures, InIdentityLinks, Method, OutFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要调整的输入要素。可以为点、线、面或注记。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "Annotation", "CoverageAnnotation")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Link Features</para>
		/// <para>表示橡皮页变换常规链接的输入线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLinkFeatures { get; set; }

		/// <summary>
		/// <para>Input Point Features As Identity Links</para>
		/// <para>表示橡皮页变换识别链接的输入点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InIdentityLinks { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>指定校正要素所用到的橡皮页变换法。</para>
		/// <para>线性—此方法稍快，并且当很多连接线均匀分布在校正的数据上时可以生成不错的结果。这是默认设置。</para>
		/// <para>自然邻域法—当存在一些间距很远的连接线时应使用该方法。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Modified Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RubbersheetFeatures SetEnviroment(object extent = null, object workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>线性—此方法稍快，并且当很多连接线均匀分布在校正的数据上时可以生成不错的结果。这是默认设置。</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("线性")]
			Linear,

			/// <summary>
			/// <para>自然邻域法—当存在一些间距很远的连接线时应使用该方法。</para>
			/// </summary>
			[GPValue("NATURAL_NEIGHBOR")]
			[Description("自然邻域法")]
			Natural_neighbor,

		}

#endregion
	}
}
