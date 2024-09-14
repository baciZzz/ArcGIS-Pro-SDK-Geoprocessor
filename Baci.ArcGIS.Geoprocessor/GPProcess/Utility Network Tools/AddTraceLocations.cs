using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.UtilityNetworkTools
{
	/// <summary>
	/// <para>Add Trace Locations</para>
	/// <para>Add Trace Locations</para>
	/// <para>Creates a feature class to be used as the starting points and barriers input for the Trace tool.</para>
	/// </summary>
	public class AddTraceLocations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The input utility network where the trace locations will be added.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the trace locations. If you specify a new feature class name, a new output feature class will be created.</para>
		/// <para>To use an existing feature class that was previously created by this tool and append or overwrite the existing locations, specify the name of the existing feature class.</para>
		/// </param>
		public AddTraceLocations(object InUtilityNetwork, object OutFeatureClass)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Trace Locations</para>
		/// </summary>
		public override string DisplayName() => "Add Trace Locations";

		/// <summary>
		/// <para>Tool Name : AddTraceLocations</para>
		/// </summary>
		public override string ToolName() => "AddTraceLocations";

		/// <summary>
		/// <para>Tool Excute Name : un.AddTraceLocations</para>
		/// </summary>
		public override string ExcuteName() => "un.AddTraceLocations";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise() => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputZFlag", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, OutFeatureClass, LoadSelectedFeatures, ClearTraceLocations, TraceLocations, FilterBarrier };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The input utility network where the trace locations will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the trace locations. If you specify a new feature class name, a new output feature class will be created.</para>
		/// <para>To use an existing feature class that was previously created by this tool and append or overwrite the existing locations, specify the name of the existing feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Load Selected Features</para>
		/// <para>Specifies whether selected features in the active map will be loaded as trace locations.</para>
		/// <para>Checked—Trace locations will be loaded based on the selection in the map.</para>
		/// <para>Unchecked—Trace locations will not be loaded based on the selection in the map. This is the default. However, trace locations can be loaded using the Trace Locations parameter.</para>
		/// <para><see cref="LoadSelectedFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object LoadSelectedFeatures { get; set; } = "false";

		/// <summary>
		/// <para>Clear Trace Locations</para>
		/// <para>Specifies whether trace locations will be cleared from the output feature class.</para>
		/// <para>Checked—Existing trace locations will be cleared.</para>
		/// <para>Unchecked—Existing trace locations will not be cleared; they will be kept. This is the default.</para>
		/// <para><see cref="ClearTraceLocationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ClearTraceLocations { get; set; } = "false";

		/// <summary>
		/// <para>Trace Locations</para>
		/// <para>The trace locations that will be added to the output feature class. If you are not using the Load Selected Features parameter in an active map, you can use this parameter to specify the utility network features to add as trace locations by providing the required values in the value table.</para>
		/// <para>The trace locations properties are as follows:</para>
		/// <para>Layer Name—The layer participating in the utility network that contains a starting point or barrier location to be added. If there is an active map, only layers from the map are allowed.</para>
		/// <para>Global ID—The Global ID of the layer feature for the location to add.</para>
		/// <para>Terminal ID—The terminal ID of the layer feature for the location to add.</para>
		/// <para>Percent Along—The percent along value of the layer feature. For line features, the default value is 0.5.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object TraceLocations { get; set; }

		/// <summary>
		/// <para>Filter Barrier</para>
		/// <para>Specifies the behavior of the barriers for the trace locations.</para>
		/// <para>Checked—The barrier behaves like a filter barrier. This is useful for subnetwork-based traces where the barrier allows the subnetwork to be evaluated first and then is applied on a second traversal of the network features, essentially acting like a filter barrier.</para>
		/// <para>Unchecked—The barrier behaves like a traversability barrier. Traversability barriers define the extent of subnetworks and will be evaluated on the first pass. This is the default.</para>
		/// <para>This parameter requires ArcGIS Enterprise 10.9 or later.</para>
		/// <para><see cref="FilterBarrierEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object FilterBarrier { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddTraceLocations SetEnviroment(object outputZFlag = null, object workspace = null)
		{
			base.SetEnv(outputZFlag: outputZFlag, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Load Selected Features</para>
		/// </summary>
		public enum LoadSelectedFeaturesEnum 
		{
			/// <summary>
			/// <para>Checked—Trace locations will be loaded based on the selection in the map.</para>
			/// </summary>
			[GPValue("true")]
			[Description("LOAD_SELECTED_FEATURES")]
			LOAD_SELECTED_FEATURES,

			/// <summary>
			/// <para>Unchecked—Trace locations will not be loaded based on the selection in the map. This is the default. However, trace locations can be loaded using the Trace Locations parameter.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_LOAD_SELECTED_FEATURES")]
			DO_NOT_LOAD_SELECTED_FEATURES,

		}

		/// <summary>
		/// <para>Clear Trace Locations</para>
		/// </summary>
		public enum ClearTraceLocationsEnum 
		{
			/// <summary>
			/// <para>Checked—Existing trace locations will be cleared.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLEAR_LOCATIONS")]
			CLEAR_LOCATIONS,

			/// <summary>
			/// <para>Unchecked—Existing trace locations will not be cleared; they will be kept. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_LOCATIONS")]
			KEEP_LOCATIONS,

		}

		/// <summary>
		/// <para>Filter Barrier</para>
		/// </summary>
		public enum FilterBarrierEnum 
		{
			/// <summary>
			/// <para>Checked—The barrier behaves like a filter barrier. This is useful for subnetwork-based traces where the barrier allows the subnetwork to be evaluated first and then is applied on a second traversal of the network features, essentially acting like a filter barrier.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FILTER_BARRIER")]
			FILTER_BARRIER,

			/// <summary>
			/// <para>Unchecked—The barrier behaves like a traversability barrier. Traversability barriers define the extent of subnetworks and will be evaluated on the first pass. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("TRAVERSABILITY_BARRIER")]
			TRAVERSABILITY_BARRIER,

		}

#endregion
	}
}
