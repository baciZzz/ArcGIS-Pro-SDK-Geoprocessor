using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Find Cotravelers</para>
	/// <para>Extracts unique identifiers that are moving through space and time at user-defined intervals in a point track dataset.</para>
	/// </summary>
	public class FindCotravelers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>The time-enabled features representing the known identifier that will be used to find cotravelers. The unique identifiers, time stamps, and locations will be transferred to the output layer to assist with calculating the time and spatial separation.</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class that will contain the point track segments identified as cotraveling with the input source layers. This feature class will include the source with which the specified point track segment is associated. Time and spatial separation will be calculated for each point track feature.</para>
		/// </param>
		/// <param name="IdField">
		/// <para>ID Field</para>
		/// <para>A field from the Input Features parameter that will be used to obtain the unique identifiers per point track. The field will be copied to the output feature class.</para>
		/// </param>
		public FindCotravelers(object InputFeatures, object OutFeatureclass, object IdField)
		{
			this.InputFeatures = InputFeatures;
			this.OutFeatureclass = OutFeatureclass;
			this.IdField = IdField;
		}

		/// <summary>
		/// <para>Tool Display Name : Find Cotravelers</para>
		/// </summary>
		public override string DisplayName => "Find Cotravelers";

		/// <summary>
		/// <para>Tool Name : FindCotravelers</para>
		/// </summary>
		public override string ToolName => "FindCotravelers";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.FindCotravelers</para>
		/// </summary>
		public override string ExcuteName => "intelligence.FindCotravelers";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputFeatures, OutFeatureclass, IdField, SearchDistance, TimeDifference, InputType, SecondaryFeatures, SecondaryIdField, CreateSummaryTable, OutSummaryTable, IncludeMinCotravelingDuration, MinCotravelingDuration };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The time-enabled features representing the known identifier that will be used to find cotravelers. The unique identifiers, time stamps, and locations will be transferred to the output layer to assist with calculating the time and spatial separation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class that will contain the point track segments identified as cotraveling with the input source layers. This feature class will include the source with which the specified point track segment is associated. Time and spatial separation will be calculated for each point track feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>ID Field</para>
		/// <para>A field from the Input Features parameter that will be used to obtain the unique identifiers per point track. The field will be copied to the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object IdField { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The maximum distance that can separate features before they are considered not to be cotraveling features. The default is 100 feet.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; } = "100 Feet";

		/// <summary>
		/// <para>Time Difference</para>
		/// <para>The maximum time difference that can separate features before they are considered not to be cotraveling features. The default is 10 seconds.</para>
		/// <para><see cref="TimeDifferenceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TimeDifference { get; set; } = "10 Seconds";

		/// <summary>
		/// <para>Input Type</para>
		/// <para>Specifies whether cotravelers will be identified in one feature class or between two.</para>
		/// <para>One Feature Class— Cotravelers will be detected in one feature class. This is the default.</para>
		/// <para>Two Feature Classes—Cotravelers will be detected across two feature classes.</para>
		/// <para><see cref="InputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InputType { get; set; } = "ONE_FEATURECLASS";

		/// <summary>
		/// <para>Secondary Features</para>
		/// <para>A second feature class to identify cotravelers. Potential cotravelers will be evaluated using the following:</para>
		/// <para>Cotravelers are cotraveling inside the input features.</para>
		/// <para>Cotravelers are cotraveling inside the secondary features.</para>
		/// <para>Cotravelers are cotraveling between the input features and secondary features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object SecondaryFeatures { get; set; }

		/// <summary>
		/// <para>Secondary ID Field</para>
		/// <para>A field from the Secondary Features parameter that will be used to obtain the unique identifiers per point track. The field will be copied to the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object SecondaryIdField { get; set; }

		/// <summary>
		/// <para>Create Summary Table</para>
		/// <para>Specifies whether an output summary table will be created.</para>
		/// <para>Checked—A summary table will be created.</para>
		/// <para>Unchecked—A summary table will not be created. This is the default.</para>
		/// <para><see cref="CreateSummaryTableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CreateSummaryTable { get; set; }

		/// <summary>
		/// <para>Output Summary Table</para>
		/// <para>The output table that will store the summary information. This option is only active when the Create Summary Table parameter is checked. Output files must be tables in a file geodatabase, text files, or comma separated value (CSV) files.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutSummaryTable { get; set; }

		/// <summary>
		/// <para>Include Minimum Cotraveling Duration Filter</para>
		/// <para>Specifies whether a filter that only returns cotravelers who meet a minimum time of traveling together will be applied.</para>
		/// <para>Checked—The minimum cotraveler duration filter will be applied.</para>
		/// <para>Unchecked—The minimum cotraveler duration filter will not be applied. This is the default.</para>
		/// <para><see cref="IncludeMinCotravelingDurationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeMinCotravelingDuration { get; set; }

		/// <summary>
		/// <para>Minimum Cotraveling Duration</para>
		/// <para>The minimum amount of time that two features must be moving through space and time together before they will be considered cotravelers.</para>
		/// <para><see cref="MinCotravelingDurationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object MinCotravelingDuration { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindCotravelers SetEnviroment(object extent = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Time Difference</para>
		/// </summary>
		public enum TimeDifferenceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Hours")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Days")]
			[Description("Days")]
			Days,

		}

		/// <summary>
		/// <para>Input Type</para>
		/// </summary>
		public enum InputTypeEnum 
		{
			/// <summary>
			/// <para>One Feature Class— Cotravelers will be detected in one feature class. This is the default.</para>
			/// </summary>
			[GPValue("ONE_FEATURECLASS")]
			[Description("One Feature Class")]
			One_Feature_Class,

			/// <summary>
			/// <para>Two Feature Classes—Cotravelers will be detected across two feature classes.</para>
			/// </summary>
			[GPValue("TWO_FEATURECLASSES")]
			[Description("Two Feature Classes")]
			Two_Feature_Classes,

		}

		/// <summary>
		/// <para>Create Summary Table</para>
		/// </summary>
		public enum CreateSummaryTableEnum 
		{
			/// <summary>
			/// <para>Checked—A summary table will be created.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_SUMMARY_TABLE")]
			CREATE_SUMMARY_TABLE,

			/// <summary>
			/// <para>Unchecked—A summary table will not be created. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SUMMARY_TABLE")]
			NO_SUMMARY_TABLE,

		}

		/// <summary>
		/// <para>Include Minimum Cotraveling Duration Filter</para>
		/// </summary>
		public enum IncludeMinCotravelingDurationEnum 
		{
			/// <summary>
			/// <para>Checked—The minimum cotraveler duration filter will be applied.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MIN_COTRAVELING_DURATION")]
			MIN_COTRAVELING_DURATION,

			/// <summary>
			/// <para>Unchecked—The minimum cotraveler duration filter will not be applied. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MIN_COTRAVELING_DURATION")]
			NO_MIN_COTRAVELING_DURATION,

		}

		/// <summary>
		/// <para>Minimum Cotraveling Duration</para>
		/// </summary>
		public enum MinCotravelingDurationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Hours")]
			[Description("Hours")]
			Hours,

		}

#endregion
	}
}
