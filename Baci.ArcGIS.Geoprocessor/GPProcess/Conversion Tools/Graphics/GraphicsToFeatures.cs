using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Graphics To Features</para>
	/// <para>图形转要素</para>
	/// <para>根据输入图形图层的元素将图形图层转换为具有几何图形的要素图层。</para>
	/// </summary>
	public class GraphicsToFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayer">
		/// <para>Input Graphics</para>
		/// <para>包含将转换为要素的源图形元素的图形图层。</para>
		/// </param>
		/// <param name="GraphicsType">
		/// <para>Graphics Type</para>
		/// <para>指定将转换的图形元素的类型。</para>
		/// <para>点—将转换点图形元素。</para>
		/// <para>折线—将转换折线图形元素。</para>
		/// <para>面—将转换面图形元素。</para>
		/// <para>多点—将转换多点图形元素。</para>
		/// <para>注记—将转换注记和文本图形元素。</para>
		/// <para><see cref="GraphicsTypeEnum"/></para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将包含转换后的图形元素的输出要素图层。</para>
		/// </param>
		public GraphicsToFeatures(object InLayer, object GraphicsType, object OutFeatureClass)
		{
			this.InLayer = InLayer;
			this.GraphicsType = GraphicsType;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 图形转要素</para>
		/// </summary>
		public override string DisplayName() => "图形转要素";

		/// <summary>
		/// <para>Tool Name : GraphicsToFeatures</para>
		/// </summary>
		public override string ToolName() => "GraphicsToFeatures";

		/// <summary>
		/// <para>Tool Excute Name : conversion.GraphicsToFeatures</para>
		/// </summary>
		public override string ExcuteName() => "conversion.GraphicsToFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLayer, GraphicsType, OutFeatureClass, DeleteGraphics!, ReferenceScale!, UpdatedLayer! };

		/// <summary>
		/// <para>Input Graphics</para>
		/// <para>包含将转换为要素的源图形元素的图形图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGraphicsLayer()]
		public object InLayer { get; set; }

		/// <summary>
		/// <para>Graphics Type</para>
		/// <para>指定将转换的图形元素的类型。</para>
		/// <para>点—将转换点图形元素。</para>
		/// <para>折线—将转换折线图形元素。</para>
		/// <para>面—将转换面图形元素。</para>
		/// <para>多点—将转换多点图形元素。</para>
		/// <para>注记—将转换注记和文本图形元素。</para>
		/// <para><see cref="GraphicsTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GraphicsType { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将包含转换后的图形元素的输出要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Delete graphics after conversion</para>
		/// <para>指定转换后是否删除来自输入图形参数的转换图形元素。</para>
		/// <para>选中 - 图形元素将被删除。 这是默认设置。</para>
		/// <para>未选中 - 不删除图形元素，其将被保留。</para>
		/// <para><see cref="DeleteGraphicsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeleteGraphics { get; set; } = "true";

		/// <summary>
		/// <para>Reference Scale</para>
		/// <para>用于将文本元素转换为注记要素的参考比例。 当图形类型参数设置为注记时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ReferenceScale { get; set; }

		/// <summary>
		/// <para>Updated layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLayer()]
		public object? UpdatedLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GraphicsToFeatures SetEnviroment(object? geographicTransformations = null, object? outputCoordinateSystem = null)
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Graphics Type</para>
		/// </summary>
		public enum GraphicsTypeEnum 
		{
			/// <summary>
			/// <para>点—将转换点图形元素。</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点")]
			Point,

			/// <summary>
			/// <para>折线—将转换折线图形元素。</para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("折线")]
			Polyline,

			/// <summary>
			/// <para>面—将转换面图形元素。</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("面")]
			Polygon,

			/// <summary>
			/// <para>多点—将转换多点图形元素。</para>
			/// </summary>
			[GPValue("MULTIPOINT")]
			[Description("多点")]
			Multipoint,

			/// <summary>
			/// <para>注记—将转换注记和文本图形元素。</para>
			/// </summary>
			[GPValue("ANNOTATION")]
			[Description("注记")]
			Annotation,

		}

		/// <summary>
		/// <para>Delete graphics after conversion</para>
		/// </summary>
		public enum DeleteGraphicsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_GRAPHICS")]
			DELETE_GRAPHICS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_GRAPHICS")]
			KEEP_GRAPHICS,

		}

#endregion
	}
}
