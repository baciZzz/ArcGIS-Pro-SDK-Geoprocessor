using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.BusinessAnalystTools
{
	/// <summary>
	/// <para>Generate Threshold Rings</para>
	/// <para>Creates a feature class of ring trade areas that expand around point features until the threshold value is reached.</para>
	/// </summary>
	public class GenerateThresholdRingTradeArea : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input point feature layer.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class.</para>
		/// </param>
		/// <param name="ThresholdVariable">
		/// <para>Threshold Variable</para>
		/// <para>The selected Business Analyst dataset variable to which the threshold value will be applied.</para>
		/// </param>
		public GenerateThresholdRingTradeArea(object InFeatures, object OutFeatureClass, object ThresholdVariable)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.ThresholdVariable = ThresholdVariable;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Threshold Rings</para>
		/// </summary>
		public override string DisplayName => "Generate Threshold Rings";

		/// <summary>
		/// <para>Tool Name : GenerateThresholdRingTradeArea</para>
		/// </summary>
		public override string ToolName => "GenerateThresholdRingTradeArea";

		/// <summary>
		/// <para>Tool Excute Name : ba.GenerateThresholdRingTradeArea</para>
		/// </summary>
		public override string ExcuteName => "ba.GenerateThresholdRingTradeArea";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "baDataSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, ThresholdVariable, ThresholdValues, Units, IdField, InputMethod, Expression };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input point feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Threshold Variable</para>
		/// <para>The selected Business Analyst dataset variable to which the threshold value will be applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ThresholdVariable { get; set; }

		/// <summary>
		/// <para>Threshold Values</para>
		/// <para>The size of the output rings. The rings will expand until they contain the threshold value of the selected variable.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPNumericDomain()]
		public object ThresholdValues { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>The distance units to be used with the threshold values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Units { get; set; }

		/// <summary>
		/// <para>ID Field</para>
		/// <para>An ID that uniquely identifies each input point and is included in the output as an attribute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object IdField { get; set; }

		/// <summary>
		/// <para>Input Method</para>
		/// <para>Specifies the type of value that is to be used for each drive time.</para>
		/// <para>Values—Uses a constant value (all trade areas will be the same size). This is the default.</para>
		/// <para>Expression—The values from a field or an expression (trade areas can be a different size).</para>
		/// <para><see cref="InputMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InputMethod { get; set; } = "VALUES";

		/// <summary>
		/// <para>Expression</para>
		/// <para>A fields-based expression to calculate the radii.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object Expression { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateThresholdRingTradeArea SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Input Method</para>
		/// </summary>
		public enum InputMethodEnum 
		{
			/// <summary>
			/// <para>Values—Uses a constant value (all trade areas will be the same size). This is the default.</para>
			/// </summary>
			[GPValue("VALUES")]
			[Description("Values")]
			Values,

			/// <summary>
			/// <para>Expression—The values from a field or an expression (trade areas can be a different size).</para>
			/// </summary>
			[GPValue("EXPRESSION")]
			[Description("Expression")]
			Expression,

		}

#endregion
	}
}
