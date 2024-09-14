using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Annotate Selected Features</para>
	/// <para>注记所选要素</para>
	/// <para>用于为图层的所选要素创建注记。将使用在指定相关注记要素类的注记类属性中定义的标注属性。</para>
	/// </summary>
	public class AnnotateSelectedFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input Map</para>
		/// <para>输入地图。</para>
		/// </param>
		/// <param name="InLayer">
		/// <para>Input Features</para>
		/// <para>所选要素将为其创建注记的图层。</para>
		/// </param>
		/// <param name="AnnoLayers">
		/// <para>Annotation Layers</para>
		/// <para>将注记转换到其中的关联要素的注记图层和指定的子图层。</para>
		/// </param>
		public AnnotateSelectedFeatures(object InMap, object InLayer, object AnnoLayers)
		{
			this.InMap = InMap;
			this.InLayer = InLayer;
			this.AnnoLayers = AnnoLayers;
		}

		/// <summary>
		/// <para>Tool Display Name : 注记所选要素</para>
		/// </summary>
		public override string DisplayName() => "注记所选要素";

		/// <summary>
		/// <para>Tool Name : AnnotateSelectedFeatures</para>
		/// </summary>
		public override string ToolName() => "AnnotateSelectedFeatures";

		/// <summary>
		/// <para>Tool Excute Name : cartography.AnnotateSelectedFeatures</para>
		/// </summary>
		public override string ExcuteName() => "cartography.AnnotateSelectedFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise() => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMap, InLayer, AnnoLayers, GenerateUnplaced, OutAnnoLayers };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>输入地图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Input Features</para>
		/// <para>所选要素将为其创建注记的图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		public object InLayer { get; set; }

		/// <summary>
		/// <para>Annotation Layers</para>
		/// <para>将注记转换到其中的关联要素的注记图层和指定的子图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object AnnoLayers { get; set; }

		/// <summary>
		/// <para>Convert unplaced labels to unplaced annotation</para>
		/// <para>指定否根据未放置的标注创建未放置的注记。</para>
		/// <para>取消选中 - 仅为当前已标注的要素创建注记。这是默认设置。</para>
		/// <para>选中 - 未放置的注记将存储到注记要素类中。这些注记的状态字段将设置为“未放置”。</para>
		/// <para><see cref="GenerateUnplacedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object GenerateUnplaced { get; set; } = "false";

		/// <summary>
		/// <para>Output Annotation Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutAnnoLayers { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Convert unplaced labels to unplaced annotation</para>
		/// </summary>
		public enum GenerateUnplacedEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_UNPLACED")]
			GENERATE_UNPLACED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ONLY_PLACED")]
			ONLY_PLACED,

		}

#endregion
	}
}
