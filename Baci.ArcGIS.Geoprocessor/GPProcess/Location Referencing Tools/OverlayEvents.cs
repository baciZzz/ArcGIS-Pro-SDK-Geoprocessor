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
	/// <para>Overlay Events</para>
	/// <para>Overlay Events</para>
	/// <para>Overlays one or more linear event feature layers onto a target network </para>
	/// <para>and outputs a feature class or table that represents the dynamic segmentation of the inputs.</para>
	/// </summary>
	public class OverlayEvents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRouteFeatures">
		/// <para>Input Route Features</para>
		/// <para>The target network onto which the event layers will be dynamically segmented.</para>
		/// </param>
		/// <param name="EventLayers">
		/// <para>Event Layers</para>
		/// <para>The event layers that will be dynamically segmented together onto a target network.</para>
		/// </param>
		/// <param name="OutputDataset">
		/// <para>Output Dataset</para>
		/// <para>The table or feature class containing the output event records that will be created.</para>
		/// </param>
		public OverlayEvents(object InRouteFeatures, object EventLayers, object OutputDataset)
		{
			this.InRouteFeatures = InRouteFeatures;
			this.EventLayers = EventLayers;
			this.OutputDataset = OutputDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Overlay Events</para>
		/// </summary>
		public override string DisplayName() => "Overlay Events";

		/// <summary>
		/// <para>Tool Name : OverlayEvents</para>
		/// </summary>
		public override string ToolName() => "OverlayEvents";

		/// <summary>
		/// <para>Tool Excute Name : locref.OverlayEvents</para>
		/// </summary>
		public override string ExcuteName() => "locref.OverlayEvents";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRouteFeatures, EventLayers, OutputDataset, IncludeGeometry!, NetworkFields! };

		/// <summary>
		/// <para>Input Route Features</para>
		/// <para>The target network onto which the event layers will be dynamically segmented.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InRouteFeatures { get; set; }

		/// <summary>
		/// <para>Event Layers</para>
		/// <para>The event layers that will be dynamically segmented together onto a target network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object EventLayers { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>The table or feature class containing the output event records that will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		[GPDatasetDomain()]
		[DataSetType("Table", "FeatureClass")]
		public object OutputDataset { get; set; }

		/// <summary>
		/// <para>Include Geometry</para>
		/// <para>Specifies whether the Output Dataset value will include event geometry.</para>
		/// <para>Unchecked—The Output Dataset value will not include event geometry. Event records will be stored as a table. This is the default.</para>
		/// <para>Checked—The Output Dataset value will include event geometry. Event records will be stored as a feature class.</para>
		/// <para><see cref="IncludeGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeGeometry { get; set; } = "false";

		/// <summary>
		/// <para>Network Fields</para>
		/// <para>Fields from the network layer that will be included in the output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GlobalID", "GUID")]
		public object? NetworkFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public OverlayEvents SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Include Geometry</para>
		/// </summary>
		public enum IncludeGeometryEnum 
		{
			/// <summary>
			/// <para>Checked—The Output Dataset value will include event geometry. Event records will be stored as a feature class.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_GEOMETRY")]
			INCLUDE_GEOMETRY,

			/// <summary>
			/// <para>Unchecked—The Output Dataset value will not include event geometry. Event records will be stored as a table. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_GEOMETRY")]
			EXCLUDE_GEOMETRY,

		}

#endregion
	}
}
