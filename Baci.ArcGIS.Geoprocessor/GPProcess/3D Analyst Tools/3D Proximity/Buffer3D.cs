using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Buffer 3D</para>
	/// <para>3D 缓冲</para>
	/// <para>围绕点或线创建三维缓冲区以生成球形或圆柱形的多面体要素。</para>
	/// </summary>
	public class Buffer3D : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>待缓冲的线或点要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含 3D 缓冲区的输出多面体。</para>
		/// </param>
		/// <param name="BufferDistanceOrField">
		/// <para>Distance</para>
		/// <para>输入要素的缓冲距离，可以是线性距离或从输入要素属性表中的数值字段获取。如果已通过输入字段指定缓冲距离，则将通过要素空间参考获得其测量单位。如果已将线性距离指定为数值，则支持以下测量单位：</para>
		/// <para>未知—未知</para>
		/// <para>英寸—英寸</para>
		/// <para>英尺—英尺</para>
		/// <para>码—码</para>
		/// <para>英里—英里</para>
		/// <para>毫米—毫米</para>
		/// <para>厘米—厘米</para>
		/// <para>分米—分米</para>
		/// <para>米—米</para>
		/// <para>千米—千米</para>
		/// </param>
		public Buffer3D(object InFeatures, object OutFeatureClass, object BufferDistanceOrField)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.BufferDistanceOrField = BufferDistanceOrField;
		}

		/// <summary>
		/// <para>Tool Display Name : 3D 缓冲</para>
		/// </summary>
		public override string DisplayName() => "3D 缓冲";

		/// <summary>
		/// <para>Tool Name : Buffer3D</para>
		/// </summary>
		public override string ToolName() => "Buffer3D";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Buffer3D</para>
		/// </summary>
		public override string ExcuteName() => "3d.Buffer3D";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "ZDomain", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, BufferDistanceOrField, BufferJointType, BufferQuality, SimplificationTolerance };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>待缓冲的线或点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含 3D 缓冲区的输出多面体。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Distance</para>
		/// <para>输入要素的缓冲距离，可以是线性距离或从输入要素属性表中的数值字段获取。如果已通过输入字段指定缓冲距离，则将通过要素空间参考获得其测量单位。如果已将线性距离指定为数值，则支持以下测量单位：</para>
		/// <para>未知—未知</para>
		/// <para>英寸—英寸</para>
		/// <para>英尺—英尺</para>
		/// <para>码—码</para>
		/// <para>英里—英里</para>
		/// <para>毫米—毫米</para>
		/// <para>厘米—厘米</para>
		/// <para>分米—分米</para>
		/// <para>米—米</para>
		/// <para>千米—千米</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object BufferDistanceOrField { get; set; }

		/// <summary>
		/// <para>Joint Type</para>
		/// <para>线段折点之间的缓冲区形状。此参数只对线输入要素有效。</para>
		/// <para>平直—折点之间的连接线形状是平直的。这是默认设置。</para>
		/// <para>圆形—折点之间的连接线形状为圆形。</para>
		/// <para><see cref="BufferJointTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BufferJointType { get; set; } = "STRAIGHT";

		/// <summary>
		/// <para>Buffer Quality</para>
		/// <para>用于表示生成的多面体要素的线段数。默认为 20，但可输入 6 到 60 范围内的任何数字。缓冲质量值越高，生成的 3D 要素越平滑，但同时也会增加处理时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 6, Max = 60)]
		public object BufferQuality { get; set; } = "20";

		/// <summary>
		/// <para>Simplification (Maximum Allowable Offset)</para>
		/// <para>简化输入线，方法是保持它们在其原始形态的指定偏移范围内的形状。如果未指定值，则不会进行简化。支持以下测量单位：</para>
		/// <para>未知—未知</para>
		/// <para>英寸—英寸</para>
		/// <para>英尺—英尺</para>
		/// <para>码—码</para>
		/// <para>英里—英里</para>
		/// <para>毫米—毫米</para>
		/// <para>厘米—厘米</para>
		/// <para>分米—分米</para>
		/// <para>米—米</para>
		/// <para>千米—千米</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SimplificationTolerance { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Buffer3D SetEnviroment(object XYDomain = null, object ZDomain = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, ZDomain: ZDomain, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Joint Type</para>
		/// </summary>
		public enum BufferJointTypeEnum 
		{
			/// <summary>
			/// <para>平直—折点之间的连接线形状是平直的。这是默认设置。</para>
			/// </summary>
			[GPValue("STRAIGHT")]
			[Description("平直")]
			Straight,

			/// <summary>
			/// <para>圆形—折点之间的连接线形状为圆形。</para>
			/// </summary>
			[GPValue("ROUND")]
			[Description("圆形")]
			Round,

		}

#endregion
	}
}
