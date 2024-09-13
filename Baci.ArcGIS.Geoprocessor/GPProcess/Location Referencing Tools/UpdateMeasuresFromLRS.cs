using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Update Measures From LRS</para>
	/// <para>Update Measures From LRS</para>
	/// <para>Populates or updates  the measures and route ID on Utility Network (UN) features such as pipes, devices, and junctions or on features in feature classes that are not UN or LRS feature classes.</para>
	/// </summary>
	public class UpdateMeasuresFromLRS : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="LrsNetwork">
		/// <para>LRS Network</para>
		/// <para>The feature layer that contains the routes, route IDs, and measures.</para>
		/// </param>
		/// <param name="LrsDate">
		/// <para>LRS Date</para>
		/// <para>The date used to define the temporal view of the network for collecting the route and measure values.</para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The layer that includes route ID and measure fields that will be updated based on feature geometry relative to routes in the LRS Network parameter.</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route ID Field</para>
		/// <para>The field in the Input Features layer that contains the route ID value.</para>
		/// </param>
		/// <param name="FromMeasureField">
		/// <para>Measure Field</para>
		/// <para>The field in the Input Features layer that contains the from measure value for polyline features.</para>
		/// </param>
		public UpdateMeasuresFromLRS(object LrsNetwork, object LrsDate, object InFeatures, object RouteIdField, object FromMeasureField)
		{
			this.LrsNetwork = LrsNetwork;
			this.LrsDate = LrsDate;
			this.InFeatures = InFeatures;
			this.RouteIdField = RouteIdField;
			this.FromMeasureField = FromMeasureField;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Measures From LRS</para>
		/// </summary>
		public override string DisplayName() => "Update Measures From LRS";

		/// <summary>
		/// <para>Tool Name : UpdateMeasuresFromLRS</para>
		/// </summary>
		public override string ToolName() => "UpdateMeasuresFromLRS";

		/// <summary>
		/// <para>Tool Excute Name : locref.UpdateMeasuresFromLRS</para>
		/// </summary>
		public override string ExcuteName() => "locref.UpdateMeasuresFromLRS";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { LrsNetwork, LrsDate, InFeatures, RouteIdField, FromMeasureField, ToMeasureField!, OutFeatures!, OutDetailsFile! };

		/// <summary>
		/// <para>LRS Network</para>
		/// <para>The feature layer that contains the routes, route IDs, and measures.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object LrsNetwork { get; set; }

		/// <summary>
		/// <para>LRS Date</para>
		/// <para>The date used to define the temporal view of the network for collecting the route and measure values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDate()]
		public object LrsDate { get; set; }

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The layer that includes route ID and measure fields that will be updated based on feature geometry relative to routes in the LRS Network parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Point")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>The field in the Input Features layer that contains the route ID value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Measure Field</para>
		/// <para>The field in the Input Features layer that contains the from measure value for polyline features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object FromMeasureField { get; set; }

		/// <summary>
		/// <para>To Measure Field</para>
		/// <para>The field in the Input Features layer that contains the measure value for point features or the to measure value for polyline features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object? ToMeasureField { get; set; }

		/// <summary>
		/// <para>Out Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatures { get; set; }

		/// <summary>
		/// <para>Output Details File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object? OutDetailsFile { get; set; }

	}
}
