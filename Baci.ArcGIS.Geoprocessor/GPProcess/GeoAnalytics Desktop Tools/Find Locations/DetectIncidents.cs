using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Detect Incidents</para>
	/// <para>Creates a layer that detects features that meet a given condition.</para>
	/// </summary>
	public class DetectIncidents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>The input features that contain potential incidents.</para>
		/// </param>
		/// <param name="Output">
		/// <para>Output Dataset</para>
		/// <para>A new output dataset that contains incidents.</para>
		/// </param>
		/// <param name="TrackFields">
		/// <para>Track Fields</para>
		/// <para>A field or fields that will be used to identify unique tracks.</para>
		/// </param>
		/// <param name="StartCondition">
		/// <para>Start Condition</para>
		/// <para>The condition that will be used to identify incidents. Expressions are written in Arcade and can include [+ - * / ] operators and multiple fields.</para>
		/// <para>If the layer is added to the map, the Fields and Helpers filters can be used to build an expression.</para>
		/// </param>
		public DetectIncidents(object InputLayer, object Output, object TrackFields, object StartCondition)
		{
			this.InputLayer = InputLayer;
			this.Output = Output;
			this.TrackFields = TrackFields;
			this.StartCondition = StartCondition;
		}

		/// <summary>
		/// <para>Tool Display Name : Detect Incidents</para>
		/// </summary>
		public override string DisplayName => "Detect Incidents";

		/// <summary>
		/// <para>Tool Name : DetectIncidents</para>
		/// </summary>
		public override string ToolName => "DetectIncidents";

		/// <summary>
		/// <para>Tool Excute Name : gapro.DetectIncidents</para>
		/// </summary>
		public override string ExcuteName => "gapro.DetectIncidents";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputLayer, Output, TrackFields, StartCondition, EndCondition!, OutputMode!, TimeBoundarySplit!, TimeBoundaryReference! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The input features that contain potential incidents.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>A new output dataset that contains incidents.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Track Fields</para>
		/// <para>A field or fields that will be used to identify unique tracks.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		public object TrackFields { get; set; }

		/// <summary>
		/// <para>Start Condition</para>
		/// <para>The condition that will be used to identify incidents. Expressions are written in Arcade and can include [+ - * / ] operators and multiple fields.</para>
		/// <para>If the layer is added to the map, the Fields and Helpers filters can be used to build an expression.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCalculatorExpression()]
		public object StartCondition { get; set; }

		/// <summary>
		/// <para>End Condition</para>
		/// <para>The condition that will be used to end incidents. If no end condition is specified, incidents will end when the start condition is no longer true.</para>
		/// <para>Expressions are written in Arcade and can include operators and multiple fields.</para>
		/// <para>If the layer is added to the map, the Fields and Helpers filters can be used to build an expression.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCalculatorExpression()]
		public object? EndCondition { get; set; }

		/// <summary>
		/// <para>Output Mode</para>
		/// <para>Specifies the features that will be returned.</para>
		/// <para>All features—All the input features will be returned. This is the default.</para>
		/// <para>Incidents—Only features that were found to be incidents will be returned.</para>
		/// <para><see cref="OutputModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutputMode { get; set; } = "ALL_FEATURES";

		/// <summary>
		/// <para>Time Boundary Split</para>
		/// <para>A time span to split the input data into for analysis. A time boundary allows you to analyze values within a defined time span. For example, if you use a time boundary of 1 day, and set the time boundary reference to January 1, 1980, tracks will be split at the beginning of every day.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeBoundarySplit { get; set; }

		/// <summary>
		/// <para>Time Boundary Reference</para>
		/// <para>The reference time used to split the input data into for analysis. Time boundaries will be created for the entire span of the data, and the reference time does not need to occur at the start. If no reference time is specified, January 1, 1970, is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? TimeBoundaryReference { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DetectIncidents SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Mode</para>
		/// </summary>
		public enum OutputModeEnum 
		{
			/// <summary>
			/// <para>All features—All the input features will be returned. This is the default.</para>
			/// </summary>
			[GPValue("ALL_FEATURES")]
			[Description("All features")]
			All_features,

			/// <summary>
			/// <para>Incidents—Only features that were found to be incidents will be returned.</para>
			/// </summary>
			[GPValue("INCIDENTS")]
			[Description("Incidents")]
			Incidents,

		}

#endregion
	}
}
