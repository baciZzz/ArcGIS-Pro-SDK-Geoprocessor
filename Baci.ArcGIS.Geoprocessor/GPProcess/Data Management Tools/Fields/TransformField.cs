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
	/// <para>Transforms continuous values in one or more fields by applying mathematical functions to each value and</para>
	/// <para>changing the shape of the distribution. The transformation methods</para>
	/// <para>in the tool include log, square root, Box-Cox, multiplicative</para>
	/// <para>inverse, square, exponential, and inverse Box-Cox.</para>
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
		/// <para>The input table or feature class containing the fields to be transformed. The newly transformed fields are added to the input table.</para>
		/// </param>
		/// <param name="Fields">
		/// <para>Field to Transform</para>
		/// <para>The fields containing the values to be transformed. For each field, an output field name can be specified. If an output field name is not provided, the tool creates an output field name using the field name and transformation method.</para>
		/// </param>
		public TransformField(object InTable, object Fields)
		{
			this.InTable = InTable;
			this.Fields = Fields;
		}

		/// <summary>
		/// <para>Tool Display Name : Transform Field</para>
		/// </summary>
		public override string DisplayName() => "Transform Field";

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
		/// <para>The input table or feature class containing the fields to be transformed. The newly transformed fields are added to the input table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field to Transform</para>
		/// <para>The fields containing the values to be transformed. For each field, an output field name can be specified. If an output field name is not provided, the tool creates an output field name using the field name and transformation method.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Transformation Method</para>
		/// <para>Specifies the method that is used to transform the values contained in the specified fields.</para>
		/// <para>Multiplicative Inverse—The multiplicative inverse (1/x) method is applied to the original value (x) in the selected fields.</para>
		/// <para>Square root—The square root method is applied to the original value in the selected fields.</para>
		/// <para>Log—The natural logarithmic function, log(x), is applied to the original value (x) in the selected fields.</para>
		/// <para>Box-Cox—The Box-Cox power function is applied to normally distribute the original values in the selected fields. This is the default.</para>
		/// <para>Inverse Box-Cox—The inverse of the Box-Cox transformation is applied to the original values in the selected fields.</para>
		/// <para>Square (inverse square root)—The square method is applied to the original values in the selected fields. This transformation is the inverse of square root.</para>
		/// <para>Exponential (inverse log)—The exponential function, exp(x), is applied to the original value (x) in the selected fields. This transformation is the inverse of log.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "BOX-COX";

		/// <summary>
		/// <para>Power</para>
		/// <para>The power parameter ( λ1) of the Box-Cox transformation. If no value is provided, an optimal value is determined using maximum likelihood estimation (MLE).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = -5, Max = 5)]
		public object Power { get; set; }

		/// <summary>
		/// <para>Shift</para>
		/// <para>The value by which all the data is shifted (adding a constant value). No shift is applied if 0 is specified.</para>
		/// <para>For log, Box-Cox and square root transformations, a default shift value is added prior to the transformation if there are negative or zero values.</para>
		/// <para>For exponential (inverse log), inverse Box-Cox, and square (inverse square root) transformations, no shift is applied by default. If a shift value is provided, the value is subtracted after the transformation is applied. This allows you to use the same shift value for transformations and their associated inverses.</para>
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
			/// <para>Multiplicative Inverse—The multiplicative inverse (1/x) method is applied to the original value (x) in the selected fields.</para>
			/// </summary>
			[GPValue("INVX")]
			[Description("Multiplicative Inverse")]
			Multiplicative_Inverse,

			/// <summary>
			/// <para>Square root—The square root method is applied to the original value in the selected fields.</para>
			/// </summary>
			[GPValue("SQRT")]
			[Description("Square root")]
			Square_root,

			/// <summary>
			/// <para>Log—The natural logarithmic function, log(x), is applied to the original value (x) in the selected fields.</para>
			/// </summary>
			[GPValue("LOG")]
			[Description("Log")]
			Log,

			/// <summary>
			/// <para>Box-Cox—The Box-Cox power function is applied to normally distribute the original values in the selected fields. This is the default.</para>
			/// </summary>
			[GPValue("BOX-COX")]
			[Description("Box-Cox")]
			BOX_COX,

			/// <summary>
			/// <para>Square (inverse square root)—The square method is applied to the original values in the selected fields. This transformation is the inverse of square root.</para>
			/// </summary>
			[GPValue("INV_SQRT")]
			[Description("Square (inverse square root)")]
			INV_SQRT,

			/// <summary>
			/// <para>Exponential (inverse log)—The exponential function, exp(x), is applied to the original value (x) in the selected fields. This transformation is the inverse of log.</para>
			/// </summary>
			[GPValue("INV_LOG")]
			[Description("Exponential (inverse log)")]
			INV_LOG,

			/// <summary>
			/// <para>Inverse Box-Cox—The inverse of the Box-Cox transformation is applied to the original values in the selected fields.</para>
			/// </summary>
			[GPValue("INV_BOX-COX")]
			[Description("Inverse Box-Cox")]
			INV_BOX_COX,

		}

#endregion
	}
}
