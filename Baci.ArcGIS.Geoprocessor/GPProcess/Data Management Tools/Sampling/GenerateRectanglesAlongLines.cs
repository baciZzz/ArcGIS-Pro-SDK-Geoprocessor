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
	/// <para>Generate Rectangles Along Lines</para>
	/// <para>沿线生成矩形</para>
	/// <para>该工具可根据单个线状要素或一组线状要素创建一系列矩形面。</para>
	/// </summary>
	public class GenerateRectanglesAlongLines : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Line Features</para>
		/// <para>定义要素路径的输入折线要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出面要素类。</para>
		/// </param>
		public GenerateRectanglesAlongLines(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 沿线生成矩形</para>
		/// </summary>
		public override string DisplayName() => "沿线生成矩形";

		/// <summary>
		/// <para>Tool Name : GenerateRectanglesAlongLines</para>
		/// </summary>
		public override string ToolName() => "GenerateRectanglesAlongLines";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateRectanglesAlongLines</para>
		/// </summary>
		public override string ExcuteName() => "management.GenerateRectanglesAlongLines";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, LengthAlongLine!, LengthPerpendicularToLine!, SpatialSortMethod! };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>定义要素路径的输入折线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Length Along the Line</para>
		/// <para>沿输入线要素的输出面要素的长度。默认值由输入线要素的空间参考决定。该值为 x 轴方向上输入要素类范围的 1/100。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? LengthAlongLine { get; set; } = "2 DecimalDegrees";

		/// <summary>
		/// <para>Length Perpendicular to the Line</para>
		/// <para>垂直于输入线要素的输出面要素的长度。默认值由输入线要素的空间参考决定。该值为沿线方向要素长度的一半。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? LengthPerpendicularToLine { get; set; } = "1 DecimalDegrees";

		/// <summary>
		/// <para>Spatial Sort Method</para>
		/// <para>输出要素将按照一定的顺序创建并需要一个空间起点。将方向类型设置为右上方将启动各输入要素右上方的输出要素。</para>
		/// <para>右上角—要素起自右上角。这是默认设置。</para>
		/// <para>左上角—要素起自左上角。</para>
		/// <para>右下角—要素起自右下角。</para>
		/// <para>左下角—要素起自左下角。</para>
		/// <para><see cref="SpatialSortMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SpatialSortMethod { get; set; } = "UL";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateRectanglesAlongLines SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Spatial Sort Method</para>
		/// </summary>
		public enum SpatialSortMethodEnum 
		{
			/// <summary>
			/// <para>左上角—要素起自左上角。</para>
			/// </summary>
			[GPValue("UL")]
			[Description("左上角")]
			Upper_left,

			/// <summary>
			/// <para>右上角—要素起自右上角。这是默认设置。</para>
			/// </summary>
			[GPValue("UR")]
			[Description("右上角")]
			Upper_right,

			/// <summary>
			/// <para>左下角—要素起自左下角。</para>
			/// </summary>
			[GPValue("LL")]
			[Description("左下角")]
			Lower_left,

			/// <summary>
			/// <para>右下角—要素起自右下角。</para>
			/// </summary>
			[GPValue("LR")]
			[Description("右下角")]
			Lower_right,

		}

#endregion
	}
}
