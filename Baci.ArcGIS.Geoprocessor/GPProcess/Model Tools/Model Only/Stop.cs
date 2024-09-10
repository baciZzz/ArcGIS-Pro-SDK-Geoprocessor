using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>Stop</para>
	/// <para>Exits a model out of the iteration loop if the input values are set to true or set to false.  For the set of input values, iteration will continue if all the inputs are true and stop if any one of the inputs is false. It is functionally similar to the While tool but is useful to stop a model if there is one While iterator in a model and no additional iterators can be added.</para>
	/// </summary>
	public class Stop : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InValues">
		/// <para>Input Values</para>
		/// <para>The values that will be checked before the model iteration will stop.</para>
		/// </param>
		public Stop(object InValues)
		{
			this.InValues = InValues;
		}

		/// <summary>
		/// <para>Tool Display Name : Stop</para>
		/// </summary>
		public override string DisplayName() => "Stop";

		/// <summary>
		/// <para>Tool Name : Stop</para>
		/// </summary>
		public override string ToolName() => "Stop";

		/// <summary>
		/// <para>Tool Excute Name : mb.Stop</para>
		/// </summary>
		public override string ExcuteName() => "mb.Stop";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise() => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InValues, Condition, Continue };

		/// <summary>
		/// <para>Input Values</para>
		/// <para>The values that will be checked before the model iteration will stop.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InValues { get; set; }

		/// <summary>
		/// <para>Stop when inputs are</para>
		/// <para>Specifies whether the iteration will run until all the inputs values are true or all the input values are false.</para>
		/// <para>True—The iteration will run until all the input values are true. This is the default.</para>
		/// <para>False—The iteration will run until all the input values are false.</para>
		/// <para><see cref="ConditionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Condition { get; set; } = "TRUE";

		/// <summary>
		/// <para>Continue</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object Continue { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Stop when inputs are</para>
		/// </summary>
		public enum ConditionEnum 
		{
			/// <summary>
			/// <para>True—The iteration will run until all the input values are true. This is the default.</para>
			/// </summary>
			[GPValue("TRUE")]
			[Description("True")]
			True,

			/// <summary>
			/// <para>False—The iteration will run until all the input values are false.</para>
			/// </summary>
			[GPValue("FALSE")]
			[Description("False")]
			False,

		}

#endregion
	}
}
