using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsServerTools
{
	/// <summary>
	/// <para>Detect Incidents</para>
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
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
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
		public DetectIncidents(object InputLayer, object OutputName, object TrackFields, object StartCondition)
		{
			this.InputLayer = InputLayer;
			this.OutputName = OutputName;
			this.TrackFields = TrackFields;
			this.StartCondition = StartCondition;
		}

		/// <summary>
		/// <para>Tool Display Name : Detect Incidents</para>
		/// </summary>
		public override string DisplayName() => "Detect Incidents";

		/// <summary>
		/// <para>Tool Name : DetectIncidents</para>
		/// </summary>
		public override string ToolName() => "DetectIncidents";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.DetectIncidents</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.DetectIncidents";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise() => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, OutputName, TrackFields, StartCondition, EndCondition, OutputMode, DataStore, Output, TimeBoundarySplit, TimeBoundaryReference };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The input features that contain potential incidents.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Track Fields</para>
		/// <para>A field or fields that will be used to identify unique tracks.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
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
		public object EndCondition { get; set; }

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
		public object OutputMode { get; set; } = "ALL_FEATURES";

		/// <summary>
		/// <para>Data Store</para>
		/// <para>Specifies the ArcGIS Data Store where the output will be saved. The default is Spatiotemporal big data store. All results stored in a spatiotemporal big data store will be stored in WGS84. Results stored in a relational data store will maintain their coordinate system.</para>
		/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
		/// <para>Relational data store—Output will be stored in a relational data store.</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Time Boundary Split</para>
		/// <para>A time span to split the input data into for analysis. A time boundary allows you to analyze values within a defined time span. For example, if you use a time boundary of 1 day, starting on January 1, 1980, tracks will be split at the beginning of every day. This parameter is only available with ArcGIS Enterprise 10.7 and later.</para>
		/// <para><see cref="TimeBoundarySplitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TimeBoundarySplit { get; set; }

		/// <summary>
		/// <para>Time Boundary Reference</para>
		/// <para>The reference time used to split the input data into for analysis. Time boundaries will be created for the entire span of the data, and the reference time does not need to occur at the start. If no reference time is specified, January 1, 1970, is used. This parameter is only available with ArcGIS Enterprise 10.7 and later.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object TimeBoundaryReference { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DetectIncidents SetEnviroment(object extent = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
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

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("Spatiotemporal big data store")]
			Spatiotemporal_big_data_store,

			/// <summary>
			/// <para>Relational data store—Output will be stored in a relational data store.</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("Relational data store")]
			Relational_data_store,

		}

		/// <summary>
		/// <para>Time Boundary Split</para>
		/// </summary>
		public enum TimeBoundarySplitEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Milliseconds")]
			[Description("Milliseconds")]
			Milliseconds,

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

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Weeks")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Months")]
			[Description("Months")]
			Months,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Years")]
			[Description("Years")]
			Years,

		}

#endregion
	}
}
