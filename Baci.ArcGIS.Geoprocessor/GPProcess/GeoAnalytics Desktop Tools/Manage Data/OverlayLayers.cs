using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Overlay Layers</para>
	/// <para>叠加图层</para>
	/// <para>将多个图层中的几何叠加到一个图层中。叠加可用于合并、擦除、修改或更新空间要素。</para>
	/// </summary>
	public class OverlayLayers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>将与叠加图层重叠的点、线或面要素。</para>
		/// </param>
		/// <param name="OverlayLayer">
		/// <para>Overlay Layer</para>
		/// <para>将与输入图层要素重叠的要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含叠加要素的新要素类。</para>
		/// </param>
		/// <param name="OverlayType">
		/// <para>Overlay Type</para>
		/// <para>指定要执行的叠加的类型。</para>
		/// <para>相交—计算输入图层的几何交集。输入图层和叠加图层中相叠置的要素或要素的各部分将被写入到输出图层中。这是默认设置。</para>
		/// <para>擦除—只有输入图层中的要素范围之外的叠加图层要素或要素部分将被写入到输出图层中。</para>
		/// <para>联合— 计算输入图层和叠加图层的几何并集。将所有要素及其属性都写入图层。</para>
		/// <para>标识— 计算输入要素和标识要素的几何交集。输入图层和叠加图层中相叠置的要素或要素的各部分将被写入到输出图层中。</para>
		/// <para>交集取反— 输入图层和叠加图层中不叠置的要素或要素的各部分将被写入到输出图层。</para>
		/// <para><see cref="OverlayTypeEnum"/></para>
		/// </param>
		public OverlayLayers(object InputLayer, object OverlayLayer, object OutFeatureClass, object OverlayType)
		{
			this.InputLayer = InputLayer;
			this.OverlayLayer = OverlayLayer;
			this.OutFeatureClass = OutFeatureClass;
			this.OverlayType = OverlayType;
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
		/// <para>Tool Excute Name : gapro.OverlayLayers</para>
		/// </summary>
		public override string ExcuteName() => "gapro.OverlayLayers";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise() => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, OverlayLayer, OutFeatureClass, OverlayType };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>将与叠加图层重叠的点、线或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon", "Polyline")]
		[FeatureType("Simple")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Overlay Layer</para>
		/// <para>将与输入图层要素重叠的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object OverlayLayer { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含叠加要素的新要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Overlay Type</para>
		/// <para>指定要执行的叠加的类型。</para>
		/// <para>相交—计算输入图层的几何交集。输入图层和叠加图层中相叠置的要素或要素的各部分将被写入到输出图层中。这是默认设置。</para>
		/// <para>擦除—只有输入图层中的要素范围之外的叠加图层要素或要素部分将被写入到输出图层中。</para>
		/// <para>联合— 计算输入图层和叠加图层的几何并集。将所有要素及其属性都写入图层。</para>
		/// <para>标识— 计算输入要素和标识要素的几何交集。输入图层和叠加图层中相叠置的要素或要素的各部分将被写入到输出图层中。</para>
		/// <para>交集取反— 输入图层和叠加图层中不叠置的要素或要素的各部分将被写入到输出图层。</para>
		/// <para><see cref="OverlayTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OverlayType { get; set; } = "INTERSECT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public OverlayLayers SetEnviroment(object extent = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Overlay Type</para>
		/// </summary>
		public enum OverlayTypeEnum 
		{
			/// <summary>
			/// <para>相交—计算输入图层的几何交集。输入图层和叠加图层中相叠置的要素或要素的各部分将被写入到输出图层中。这是默认设置。</para>
			/// </summary>
			[GPValue("INTERSECT")]
			[Description("相交")]
			Intersect,

			/// <summary>
			/// <para>擦除—只有输入图层中的要素范围之外的叠加图层要素或要素部分将被写入到输出图层中。</para>
			/// </summary>
			[GPValue("ERASE")]
			[Description("擦除")]
			Erase,

			/// <summary>
			/// <para>标识— 计算输入要素和标识要素的几何交集。输入图层和叠加图层中相叠置的要素或要素的各部分将被写入到输出图层中。</para>
			/// </summary>
			[GPValue("IDENTITY")]
			[Description("标识")]
			Identity,

			/// <summary>
			/// <para>联合— 计算输入图层和叠加图层的几何并集。将所有要素及其属性都写入图层。</para>
			/// </summary>
			[GPValue("UNION")]
			[Description("联合")]
			Union,

			/// <summary>
			/// <para>交集取反— 输入图层和叠加图层中不叠置的要素或要素的各部分将被写入到输出图层。</para>
			/// </summary>
			[GPValue("SYMMETRICAL_DIFFERENCE")]
			[Description("交集取反")]
			Symmetrical_Difference,

		}

#endregion
	}
}
