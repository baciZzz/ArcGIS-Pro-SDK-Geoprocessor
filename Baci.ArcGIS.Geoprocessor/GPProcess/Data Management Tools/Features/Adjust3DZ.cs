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
	/// <para>Adjust 3D Z</para>
	/// <para>调整 3D Z 值</para>
	/// <para>修改 3D 要素的 z 值。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class Adjust3DZ : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>z 值将被修改的 3D 要素。</para>
		/// </param>
		public Adjust3DZ(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 调整 3D Z 值</para>
		/// </summary>
		public override string DisplayName() => "调整 3D Z 值";

		/// <summary>
		/// <para>Tool Name : Adjust3DZ</para>
		/// </summary>
		public override string ToolName() => "Adjust3DZ";

		/// <summary>
		/// <para>Tool Excute Name : management.Adjust3DZ</para>
		/// </summary>
		public override string ExcuteName() => "management.Adjust3DZ";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ReverseSign!, AdjustValue!, FromUnits!, ToUnits!, OutFeatureClass! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>z 值将被修改的 3D 要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Reverse Sign of Z Values</para>
		/// <para>指定要素是否沿 z 轴反转。</para>
		/// <para>反转 Z 方向—反转 z 值符号将导致要素上下翻转。</para>
		/// <para>保持 Z 方向—z 值符号不会被翻转，其将保持不变。 这是默认设置。</para>
		/// <para><see cref="ReverseSignEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ReverseSign { get; set; } = "NO_REVERSE";

		/// <summary>
		/// <para>Adjust Z Value</para>
		/// <para>可用输入要素中的数值或字段来调整输入要素中每个折点的 z 值。 正值可使要素沿 z 轴向较高的位置移动，而负数将使要素沿 z 轴向较低的位置移动。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? AdjustValue { get; set; } = "0";

		/// <summary>
		/// <para>Convert From Units</para>
		/// <para>指定现有的 z 值单位。 此参数与转换至单位参数结合使用。</para>
		/// <para>毫米—将以毫米为单位。</para>
		/// <para>厘米—将以厘米为单位。</para>
		/// <para>米—单位将为米。</para>
		/// <para>英寸—将以英寸为单位。</para>
		/// <para>英尺—单位将为英尺。</para>
		/// <para>码—将以码为单位。</para>
		/// <para>英寻—将以英寻为单位。</para>
		/// <para><see cref="FromUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FromUnits { get; set; }

		/// <summary>
		/// <para>Convert To Units</para>
		/// <para>指定现有 z 值将转换成的单位。</para>
		/// <para>毫米—将以毫米为单位。</para>
		/// <para>厘米—将以厘米为单位。</para>
		/// <para>米—单位将为米。</para>
		/// <para>英寸—将以英寸为单位。</para>
		/// <para>英尺—单位将为英尺。</para>
		/// <para>码—将以码为单位。</para>
		/// <para>英寻—将以英寻为单位。</para>
		/// <para><see cref="ToUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ToUnits { get; set; }

		/// <summary>
		/// <para>Updated Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Adjust3DZ SetEnviroment(object? extent = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Reverse Sign of Z Values</para>
		/// </summary>
		public enum ReverseSignEnum 
		{
			/// <summary>
			/// <para>保持 Z 方向—z 值符号不会被翻转，其将保持不变。 这是默认设置。</para>
			/// </summary>
			[GPValue("NO_REVERSE")]
			[Description("保持 Z 方向")]
			Maintain_Z_Orientation,

			/// <summary>
			/// <para>反转 Z 方向—反转 z 值符号将导致要素上下翻转。</para>
			/// </summary>
			[GPValue("REVERSE")]
			[Description("反转 Z 方向")]
			Reverse_Z_Orientation,

		}

		/// <summary>
		/// <para>Convert From Units</para>
		/// </summary>
		public enum FromUnitsEnum 
		{
			/// <summary>
			/// <para>毫米—将以毫米为单位。</para>
			/// </summary>
			[GPValue("MILLIMETERS")]
			[Description("毫米")]
			Millimeters,

			/// <summary>
			/// <para>厘米—将以厘米为单位。</para>
			/// </summary>
			[GPValue("CENTIMETERS")]
			[Description("厘米")]
			Centimeters,

			/// <summary>
			/// <para>米—单位将为米。</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>英寸—将以英寸为单位。</para>
			/// </summary>
			[GPValue("INCHES")]
			[Description("英寸")]
			Inches,

			/// <summary>
			/// <para>英尺—单位将为英尺。</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("英尺")]
			Feet,

			/// <summary>
			/// <para>码—将以码为单位。</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("码")]
			Yards,

			/// <summary>
			/// <para>英寻—将以英寻为单位。</para>
			/// </summary>
			[GPValue("FATHOMS")]
			[Description("英寻")]
			Fathoms,

		}

		/// <summary>
		/// <para>Convert To Units</para>
		/// </summary>
		public enum ToUnitsEnum 
		{
			/// <summary>
			/// <para>毫米—将以毫米为单位。</para>
			/// </summary>
			[GPValue("MILLIMETERS")]
			[Description("毫米")]
			Millimeters,

			/// <summary>
			/// <para>厘米—将以厘米为单位。</para>
			/// </summary>
			[GPValue("CENTIMETERS")]
			[Description("厘米")]
			Centimeters,

			/// <summary>
			/// <para>米—单位将为米。</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>英寸—将以英寸为单位。</para>
			/// </summary>
			[GPValue("INCHES")]
			[Description("英寸")]
			Inches,

			/// <summary>
			/// <para>英尺—单位将为英尺。</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("英尺")]
			Feet,

			/// <summary>
			/// <para>码—将以码为单位。</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("码")]
			Yards,

			/// <summary>
			/// <para>英寻—将以英寻为单位。</para>
			/// </summary>
			[GPValue("FATHOMS")]
			[Description("英寻")]
			Fathoms,

		}

#endregion
	}
}
