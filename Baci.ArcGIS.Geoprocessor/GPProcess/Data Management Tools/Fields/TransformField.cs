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
	/// <para>Transform Field</para>
	/// <para>转换字段</para>
	/// <para>通过对每个值应用数学函数并更改分布的形状来变换一个或多个字段中的连续值。该工具中的变换方法包括对数、平方根、Box-Cox 变换、倒数、平方、指数和逆 Box-Cox 变换。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class TransformField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含待变换字段的输入表或要素类。新变换的字段将添加到输入表中。</para>
		/// </param>
		/// <param name="Fields">
		/// <para>Field to Transform</para>
		/// <para>包含要变换的值的字段。对于每个字段，可以指定输出字段名称。如果未提供输出字段名称，则该工具将使用字段名称和变换方法来创建输出字段名称。</para>
		/// </param>
		public TransformField(object InTable, object Fields)
		{
			this.InTable = InTable;
			this.Fields = Fields;
		}

		/// <summary>
		/// <para>Tool Display Name : 转换字段</para>
		/// </summary>
		public override string DisplayName() => "转换字段";

		/// <summary>
		/// <para>Tool Name : TransformField</para>
		/// </summary>
		public override string ToolName() => "TransformField";

		/// <summary>
		/// <para>Tool Excute Name : management.TransformField</para>
		/// </summary>
		public override string ExcuteName() => "management.TransformField";

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
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, Fields, Method, Power, Shift, UpdatedTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含待变换字段的输入表或要素类。新变换的字段将添加到输入表中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field to Transform</para>
		/// <para>包含要变换的值的字段。对于每个字段，可以指定输出字段名称。如果未提供输出字段名称，则该工具将使用字段名称和变换方法来创建输出字段名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Transformation Method</para>
		/// <para>指定用于变换指定字段中包含的值的方法。</para>
		/// <para>倒数—将倒数 (1/x) 方法应用于所选字段中的原始值 (x)。</para>
		/// <para>平方根—将平方根方法应用于所选字段中的原始值。</para>
		/// <para>日志—将自然对数函数 log(x) 应用于所选字段中的原始值 (x)。</para>
		/// <para>Box-Cox—将应用 Box-Cox 幂函数以使所选字段中的原始值正态分布。这是默认设置。</para>
		/// <para>逆 Box-Cox—将 Box-Cox 变换的逆变换应用于所选字段中的原始值。</para>
		/// <para>平方（平方根的逆变换）—将平方方法应用于所选字段中的原始值。此变换是平方根的逆变换。</para>
		/// <para>指数（对数的逆变换）—将指数函数 exp(x) 应用于所选字段中的原始值 (x)。此变换是对数变换的逆变换。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "BOX-COX";

		/// <summary>
		/// <para>Power</para>
		/// <para>Box-Cox 变换的幂参数 (λ1)。如果未提供任何值，则将使用最大似然估计 (MLE) 来确定最佳值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = -5, Max = 5)]
		public object Power { get; set; }

		/// <summary>
		/// <para>Shift</para>
		/// <para>对所有数据进行偏移（添加一个常数值）的值。如果指定 0，则不会应用任何偏移。</para>
		/// <para>对于对数、Box-Cox 和平方根变换，如果存在负值或零值，则将在变换之前添加默认偏移值。</para>
		/// <para>对于指数（逆对数）、逆 Box-Cox 和平方（逆平方根）变换，则默认不会应用任何偏移。如果提供了偏移值，则将在应用变换后减去该值。由此可以针对变换及其相关的逆变换使用相同的偏移值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Shift { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object UpdatedTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TransformField SetEnviroment(object extent = null )
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Transformation Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>倒数—将倒数 (1/x) 方法应用于所选字段中的原始值 (x)。</para>
			/// </summary>
			[GPValue("INVX")]
			[Description("倒数")]
			Multiplicative_Inverse,

			/// <summary>
			/// <para>平方根—将平方根方法应用于所选字段中的原始值。</para>
			/// </summary>
			[GPValue("SQRT")]
			[Description("平方根")]
			Square_root,

			/// <summary>
			/// <para>日志—将自然对数函数 log(x) 应用于所选字段中的原始值 (x)。</para>
			/// </summary>
			[GPValue("LOG")]
			[Description("日志")]
			Log,

			/// <summary>
			/// <para>Box-Cox—将应用 Box-Cox 幂函数以使所选字段中的原始值正态分布。这是默认设置。</para>
			/// </summary>
			[GPValue("BOX-COX")]
			[Description("Box-Cox")]
			BOX_COX,

			/// <summary>
			/// <para>平方（平方根的逆变换）—将平方方法应用于所选字段中的原始值。此变换是平方根的逆变换。</para>
			/// </summary>
			[GPValue("INV_SQRT")]
			[Description("平方（平方根的逆变换）")]
			INV_SQRT,

			/// <summary>
			/// <para>指数（对数的逆变换）—将指数函数 exp(x) 应用于所选字段中的原始值 (x)。此变换是对数变换的逆变换。</para>
			/// </summary>
			[GPValue("INV_LOG")]
			[Description("指数（对数的逆变换）")]
			INV_LOG,

			/// <summary>
			/// <para>逆 Box-Cox—将 Box-Cox 变换的逆变换应用于所选字段中的原始值。</para>
			/// </summary>
			[GPValue("INV_BOX-COX")]
			[Description("逆 Box-Cox")]
			INV_BOX_COX,

		}

#endregion
	}
}
