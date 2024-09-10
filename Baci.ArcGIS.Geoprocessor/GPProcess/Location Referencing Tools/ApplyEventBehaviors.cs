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
	/// <para>Apply Event Behaviors</para>
	/// <para>Updates the event locations for all event feature classes registered with the input network based on the route edit performed.</para>
	/// </summary>
	public class ApplyEventBehaviors : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRouteFeatures">
		/// <para>Input Route Features</para>
		/// <para>The LRS Network for which event locations will be updated. This must be a feature layer registered as a network with the LRS.</para>
		/// </param>
		public ApplyEventBehaviors(object InRouteFeatures)
		{
			this.InRouteFeatures = InRouteFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Event Behaviors</para>
		/// </summary>
		public override string DisplayName() => "Apply Event Behaviors";

		/// <summary>
		/// <para>Tool Name : ApplyEventBehaviors</para>
		/// </summary>
		public override string ToolName() => "ApplyEventBehaviors";

		/// <summary>
		/// <para>Tool Excute Name : locref.ApplyEventBehaviors</para>
		/// </summary>
		public override string ExcuteName() => "locref.ApplyEventBehaviors";

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
		public override object[] Parameters() => new object[] { InRouteFeatures, OutEventLayers, OutDetailsFile };

		/// <summary>
		/// <para>Input Route Features</para>
		/// <para>The LRS Network for which event locations will be updated. This must be a feature layer registered as a network with the LRS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InRouteFeatures { get; set; }

		/// <summary>
		/// <para>Output Event Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutEventLayers { get; set; }

		/// <summary>
		/// <para>Output Details File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object OutDetailsFile { get; set; }

	}
}
