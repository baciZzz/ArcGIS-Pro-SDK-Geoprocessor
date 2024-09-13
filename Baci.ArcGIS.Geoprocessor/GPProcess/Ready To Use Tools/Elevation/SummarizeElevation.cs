using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ReadyToUseTools
{
	/// <summary>
	/// <para>Summarize Elevation</para>
	/// <para>Summarize Elevation</para>
	/// <para>Calculates summary statistics of elevation for each input feature.</para>
	/// </summary>
	public class SummarizeElevation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputfeatures">
		/// <para>Input Features</para>
		/// <para>The input point, line, or area features for which the elevation will be summarized.</para>
		/// </param>
		public SummarizeElevation(object Inputfeatures)
		{
			this.Inputfeatures = Inputfeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Summarize Elevation</para>
		/// </summary>
		public override string DisplayName() => "Summarize Elevation";

		/// <summary>
		/// <para>Tool Name : SummarizeElevation</para>
		/// </summary>
		public override string ToolName() => "SummarizeElevation";

		/// <summary>
		/// <para>Tool Excute Name : agolservices.SummarizeElevation</para>
		/// </summary>
		public override string ExcuteName() => "agolservices.SummarizeElevation";

		/// <summary>
		/// <para>Toolbox Display Name : Ready To Use Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Ready To Use Tools";

		/// <summary>
		/// <para>Toolbox Alise : agolservices</para>
		/// </summary>
		public override string ToolboxAlise() => "agolservices";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputfeatures, Featureidfield!, Demresolution!, Includeslopeaspect!, Outputsummary! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input point, line, or area features for which the elevation will be summarized.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Inputfeatures { get; set; }

		/// <summary>
		/// <para>Feature ID Field</para>
		/// <para>The unique ID field to use for the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Featureidfield { get; set; }

		/// <summary>
		/// <para>DEM Resolution</para>
		/// <para>Specifies the approximate spatial resolution (cell size) of the source elevation data used for the calculation.</para>
		/// <para>The resolution keyword is an approximation of the spatial resolution of the digital elevation model. Many elevation sources are distributed in units of arc seconds; the keyword is an approximation in meters for easier understanding.</para>
		/// <para>Finest—The finest units available for the extent are used.</para>
		/// <para>10 meters—The elevation source resolution is 1/3 arc second or approximately 10 meters.</para>
		/// <para>24 meters—The elevation source is the Airbus WorldDEM4Ortho dataset at 24 meters resolution.</para>
		/// <para>30 meters—The elevation source resolution is 1 arc second or approximately 30 meters.</para>
		/// <para>90 meters—The elevation source resolution is 3 arc seconds or approximately 90 meters. This is the default.</para>
		/// <para><see cref="DemresolutionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Demresolution { get; set; }

		/// <summary>
		/// <para>Include Slope and Aspect</para>
		/// <para>Specifies whether slope and aspect values for the input features will be included in the output in addition to the elevation values.</para>
		/// <para>Checked—Slope and aspect values will be included in the output.</para>
		/// <para>Unchecked—Slope and aspect values will not be included in the output. This is the default.</para>
		/// <para><see cref="IncludeslopeaspectEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Includeslopeaspect { get; set; } = "false";

		/// <summary>
		/// <para>Output Summary</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? Outputsummary { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>DEM Resolution</para>
		/// </summary>
		public enum DemresolutionEnum 
		{
			/// <summary>
			/// <para>Finest—The finest units available for the extent are used.</para>
			/// </summary>
			[GPValue("FINEST")]
			[Description("Finest")]
			Finest,

			/// <summary>
			/// <para>10 meters—The elevation source resolution is 1/3 arc second or approximately 10 meters.</para>
			/// </summary>
			[GPValue("10m")]
			[Description("10 meters")]
			_10_meters,

			/// <summary>
			/// <para>24 meters—The elevation source is the Airbus WorldDEM4Ortho dataset at 24 meters resolution.</para>
			/// </summary>
			[GPValue("24m")]
			[Description("24 meters")]
			_24_meters,

			/// <summary>
			/// <para>30 meters—The elevation source resolution is 1 arc second or approximately 30 meters.</para>
			/// </summary>
			[GPValue("30m")]
			[Description("30 meters")]
			_30_meters,

			/// <summary>
			/// <para>90 meters—The elevation source resolution is 3 arc seconds or approximately 90 meters. This is the default.</para>
			/// </summary>
			[GPValue("90m")]
			[Description("90 meters")]
			_90_meters,

		}

		/// <summary>
		/// <para>Include Slope and Aspect</para>
		/// </summary>
		public enum IncludeslopeaspectEnum 
		{
			/// <summary>
			/// <para>Checked—Slope and aspect values will be included in the output.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SLOPE_ASPECT")]
			SLOPE_ASPECT,

			/// <summary>
			/// <para>Unchecked—Slope and aspect values will not be included in the output. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SLOPE_ASPECT")]
			NO_SLOPE_ASPECT,

		}

#endregion
	}
}
