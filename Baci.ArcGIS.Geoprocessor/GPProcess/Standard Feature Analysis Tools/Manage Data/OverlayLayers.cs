using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.StandardFeatureAnalysisTools
{
	/// <summary>
	/// <para>Overlay Layers</para>
	/// <para>叠加图层</para>
	/// <para>将多个图层中的几何叠加到一个图层中。叠加可用于合并、擦除、修改或更新空间要素。叠加操作不仅仅是合并几何，还会将参与叠加的要素的所有属性传递到结果中。</para>
	/// </summary>
	public class OverlayLayers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputlayer">
		/// <para>Input Layer</para>
		/// <para>将与叠加图层重叠的点、线或面要素。</para>
		/// </param>
		/// <param name="Overlaylayer">
		/// <para>Overlay Layer</para>
		/// <para>将与输入图层要素重叠的要素。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>要在门户中创建的输出图层的名称。</para>
		/// </param>
		public OverlayLayers(object Inputlayer, object Overlaylayer, object Outputname)
		{
			this.Inputlayer = Inputlayer;
			this.Overlaylayer = Overlaylayer;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : 叠加图层</para>
		/// </summary>
		public override string DisplayName() => "叠加图层";

		/// <summary>
		/// <para>Tool Name : OverlayLayers</para>
		/// </summary>
		public override string ToolName() => "OverlayLayers";

		/// <summary>
		/// <para>Tool Excute Name : sfa.OverlayLayers</para>
		/// </summary>
		public override string ExcuteName() => "sfa.OverlayLayers";

		/// <summary>
		/// <para>Toolbox Display Name : Standard Feature Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Standard Feature Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : sfa</para>
		/// </summary>
		public override string ToolboxAlise() => "sfa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputlayer, Overlaylayer, Outputname, Overlaytype, Outputtype, Snaptoinput, Tolerance, Output };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>将与叠加图层重叠的点、线或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Inputlayer { get; set; }

		/// <summary>
		/// <para>Overlay Layer</para>
		/// <para>将与输入图层要素重叠的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Overlaylayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>要在门户中创建的输出图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Overlay Type</para>
		/// <para>要执行的叠加的类型。</para>
		/// <para>相交—计算输入图层的几何交集。输入图层和叠加图层中相叠置的要素或要素的各部分将被写入到输出图层中。这是默认设置。</para>
		/// <para>联合—计算输入图层的几何并集。将所有要素及其属性都写入输出图层。只有当输入图层和叠加图层中均包含面要素时，此选项才可用。</para>
		/// <para>擦除—只有输入图层中的要素范围之外的叠加图层要素或要素部分将被写入到输出图层中。</para>
		/// <para><see cref="OverlaytypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Overlaytype { get; set; } = "INTERSECT";

		/// <summary>
		/// <para>Output Type</para>
		/// <para>您希望查找的相交类型。此参数只有在叠加类型为相交时才有效。</para>
		/// <para>输入—所返回的要素的几何类型将与具有最低维度几何的输入图层或叠加图层的几何类型相同。如果所有输入都是面，则输出将包含面。如果一个或多个输入是线但不包含点，则输出是线。如果一个或多个输入是点，则输出将包含点。这是默认设置。</para>
		/// <para>折线— 将返回线相交。仅当输入中不包含点时，此选项才有效。</para>
		/// <para>点— 将返回点相交。如果输入是线或面，则输出将是多点图层。</para>
		/// <para><see cref="OutputtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Outputtype { get; set; } = "INPUT";

		/// <summary>
		/// <para>Snap To Input</para>
		/// <para>指定是否允许移动输入图层中的要素折点。默认情况下该项处于未选中状态，这意味着如果要素间距小于容差值，则可移动两个图层中的所有要素，以便彼此之间进行捕捉。选中此选项时，仅可移动叠加图层中的要素，以捕捉到输入图层要素。</para>
		/// <para>未选中 - 允许两个图层中的要素将所含的折点捕捉到对方。这是默认设置。</para>
		/// <para>选中 - 仅允许叠加图层中的要素移动折点，以捕捉到输入图层。</para>
		/// <para><see cref="SnaptoinputEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Snaptoinput { get; set; } = "false";

		/// <summary>
		/// <para>Tolerance</para>
		/// <para>所有要素坐标之间的最小距离以及坐标可以沿 X 和/或 Y 方向移动的距离的双精度值。容差的单位与输入图层坐标系的单位相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Tolerance { get; set; }

		/// <summary>
		/// <para>Output</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public OverlayLayers SetEnviroment(object extent = null )
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Overlay Type</para>
		/// </summary>
		public enum OverlaytypeEnum 
		{
			/// <summary>
			/// <para>相交—计算输入图层的几何交集。输入图层和叠加图层中相叠置的要素或要素的各部分将被写入到输出图层中。这是默认设置。</para>
			/// </summary>
			[GPValue("INTERSECT")]
			[Description("相交")]
			Intersect,

			/// <summary>
			/// <para>联合—计算输入图层的几何并集。将所有要素及其属性都写入输出图层。只有当输入图层和叠加图层中均包含面要素时，此选项才可用。</para>
			/// </summary>
			[GPValue("UNION")]
			[Description("联合")]
			Union,

			/// <summary>
			/// <para>擦除—只有输入图层中的要素范围之外的叠加图层要素或要素部分将被写入到输出图层中。</para>
			/// </summary>
			[GPValue("ERASE")]
			[Description("擦除")]
			Erase,

		}

		/// <summary>
		/// <para>Output Type</para>
		/// </summary>
		public enum OutputtypeEnum 
		{
			/// <summary>
			/// <para>输入—所返回的要素的几何类型将与具有最低维度几何的输入图层或叠加图层的几何类型相同。如果所有输入都是面，则输出将包含面。如果一个或多个输入是线但不包含点，则输出是线。如果一个或多个输入是点，则输出将包含点。这是默认设置。</para>
			/// </summary>
			[GPValue("INPUT")]
			[Description("输入")]
			Input,

			/// <summary>
			/// <para>折线— 将返回线相交。仅当输入中不包含点时，此选项才有效。</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("折线")]
			Line,

			/// <summary>
			/// <para>点— 将返回点相交。如果输入是线或面，则输出将是多点图层。</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点")]
			Point,

		}

		/// <summary>
		/// <para>Snap To Input</para>
		/// </summary>
		public enum SnaptoinputEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SNAP")]
			SNAP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SNAP")]
			NO_SNAP,

		}

#endregion
	}
}
