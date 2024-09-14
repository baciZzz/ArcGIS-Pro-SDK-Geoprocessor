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
	/// <para>Evaluate Rules</para>
	/// <para>Evaluate Rules</para>
	/// <para>Evaluates geodatabase rules and functionality.</para>
	/// </summary>
	public class EvaluateRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>A file geodatabase or feature service URL. An example of a feature service URL is https://myserver/server/rest/services/myservicename/FeatureServer.</para>
		/// </param>
		/// <param name="EvaluationTypes">
		/// <para>Evaluation Types</para>
		/// <para>Specifies the types of evaluation that will be used.</para>
		/// <para>Calculation rules—Batch calculation attribute rules will be evaluated.</para>
		/// <para>Validation rules—Validation attribute rules will be evaluated.</para>
		/// <para><see cref="EvaluationTypesEnum"/></para>
		/// </param>
		public EvaluateRules(object InWorkspace, object EvaluationTypes)
		{
			this.InWorkspace = InWorkspace;
			this.EvaluationTypes = EvaluationTypes;
		}

		/// <summary>
		/// <para>Tool Display Name : Evaluate Rules</para>
		/// </summary>
		public override string DisplayName() => "Evaluate Rules";

		/// <summary>
		/// <para>Tool Name : EvaluateRules</para>
		/// </summary>
		public override string ToolName() => "EvaluateRules";

		/// <summary>
		/// <para>Tool Excute Name : management.EvaluateRules</para>
		/// </summary>
		public override string ExcuteName() => "management.EvaluateRules";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, EvaluationTypes, Extent!, RunAsync!, UpdatedWorkspace! };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>A file geodatabase or feature service URL. An example of a feature service URL is https://myserver/server/rest/services/myservicename/FeatureServer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database", "Local Database", "Feature Service")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Evaluation Types</para>
		/// <para>Specifies the types of evaluation that will be used.</para>
		/// <para>Calculation rules—Batch calculation attribute rules will be evaluated.</para>
		/// <para>Validation rules—Validation attribute rules will be evaluated.</para>
		/// <para><see cref="EvaluationTypesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object EvaluationTypes { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>The extent to be evaluated. If there is a selection in the map, only selected features within the specified extent will be evaluated.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Union of Inputs—The extent will be based on the maximum extent of all inputs.</para>
		/// <para>Intersection of Inputs—The extent will be based on the minimum area common to all inputs.</para>
		/// <para>Current Display Extent—The extent is equal to the visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? Extent { get; set; }

		/// <summary>
		/// <para>Async</para>
		/// <para>Specifies whether the evaluation will run synchronously or asynchronously. This parameter is only supported when the input workspace is a feature service.</para>
		/// <para>Checked—The evaluation will run asynchronously. This option dedicates server resources to run the evaluation with a longer time-out. Running asynchronously is recommended when evaluating large datasets that contain many features requiring calculation or validation. This is the default.</para>
		/// <para>Unchecked—The evaluation will run synchronously. This option has a shorter time-out and is best used when evaluating an extent with a small number of features requiring calculation or validation.</para>
		/// <para><see cref="RunAsyncEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? RunAsync { get; set; } = "true";

		/// <summary>
		/// <para>Updated Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? UpdatedWorkspace { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Evaluation Types</para>
		/// </summary>
		public enum EvaluationTypesEnum 
		{
			/// <summary>
			/// <para>Calculation rules—Batch calculation attribute rules will be evaluated.</para>
			/// </summary>
			[GPValue("CALCULATION_RULES")]
			[Description("Calculation rules")]
			Calculation_rules,

			/// <summary>
			/// <para>Validation rules—Validation attribute rules will be evaluated.</para>
			/// </summary>
			[GPValue("VALIDATION_RULES")]
			[Description("Validation rules")]
			Validation_rules,

		}

		/// <summary>
		/// <para>Async</para>
		/// </summary>
		public enum RunAsyncEnum 
		{
			/// <summary>
			/// <para>Checked—The evaluation will run asynchronously. This option dedicates server resources to run the evaluation with a longer time-out. Running asynchronously is recommended when evaluating large datasets that contain many features requiring calculation or validation. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ASYNC")]
			ASYNC,

			/// <summary>
			/// <para>Unchecked—The evaluation will run synchronously. This option has a shorter time-out and is best used when evaluating an extent with a small number of features requiring calculation or validation.</para>
			/// </summary>
			[GPValue("false")]
			[Description("SYNC")]
			SYNC,

		}

#endregion
	}
}
