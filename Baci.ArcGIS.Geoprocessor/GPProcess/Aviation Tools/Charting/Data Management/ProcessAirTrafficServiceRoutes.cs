using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AviationTools
{
	/// <summary>
	/// <para>Process Air Traffic Service Routes</para>
	/// <para>Identifies, generalizes, and offsets overlapping Air Traffic Service (ATS) routes.</para>
	/// </summary>
	public class ProcessAirTrafficServiceRoutes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRouteFeatures">
		/// <para>Input Route Features</para>
		/// <para>The polyline feature layer containing air traffic service (ATS) route data. This data will be used to update features in the Target Cartographic Route Features feature layer.</para>
		/// </param>
		/// <param name="TargetCartoRouteFeatures">
		/// <para>Target Cartographic Route Features</para>
		/// <para>The cartographic feature layer containing air traffic service (ATS) routes. The attributes of these features will be modified to simplify the display of overlapping routes.</para>
		/// </param>
		/// <param name="AoiFeatures">
		/// <para>Area of Interest Features</para>
		/// <para>The polygon feature class containing area of interest (AOI) features.</para>
		/// </param>
		/// <param name="PreferenceTable">
		/// <para>Preference Table</para>
		/// <para>The table of preferences that control how air traffic service (ATS) routes are processed.</para>
		/// </param>
		/// <param name="Preference">
		/// <para>Preference</para>
		/// <para>The name of a preference from the Preference Table parameter. The preference controls how air traffic service (ATS) routes are processed.</para>
		/// </param>
		public ProcessAirTrafficServiceRoutes(object InRouteFeatures, object TargetCartoRouteFeatures, object AoiFeatures, object PreferenceTable, object Preference)
		{
			this.InRouteFeatures = InRouteFeatures;
			this.TargetCartoRouteFeatures = TargetCartoRouteFeatures;
			this.AoiFeatures = AoiFeatures;
			this.PreferenceTable = PreferenceTable;
			this.Preference = Preference;
		}

		/// <summary>
		/// <para>Tool Display Name : Process Air Traffic Service Routes</para>
		/// </summary>
		public override string DisplayName => "Process Air Traffic Service Routes";

		/// <summary>
		/// <para>Tool Name : ProcessAirTrafficServiceRoutes</para>
		/// </summary>
		public override string ToolName => "ProcessAirTrafficServiceRoutes";

		/// <summary>
		/// <para>Tool Excute Name : aviation.ProcessAirTrafficServiceRoutes</para>
		/// </summary>
		public override string ExcuteName => "aviation.ProcessAirTrafficServiceRoutes";

		/// <summary>
		/// <para>Toolbox Display Name : Aviation Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Aviation Tools";

		/// <summary>
		/// <para>Toolbox Alise : aviation</para>
		/// </summary>
		public override string ToolboxAlise => "aviation";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRouteFeatures, TargetCartoRouteFeatures, AoiFeatures, PreferenceTable, Preference, UpdatedCartoRouteFeatures };

		/// <summary>
		/// <para>Input Route Features</para>
		/// <para>The polyline feature layer containing air traffic service (ATS) route data. This data will be used to update features in the Target Cartographic Route Features feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InRouteFeatures { get; set; }

		/// <summary>
		/// <para>Target Cartographic Route Features</para>
		/// <para>The cartographic feature layer containing air traffic service (ATS) routes. The attributes of these features will be modified to simplify the display of overlapping routes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object TargetCartoRouteFeatures { get; set; }

		/// <summary>
		/// <para>Area of Interest Features</para>
		/// <para>The polygon feature class containing area of interest (AOI) features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object AoiFeatures { get; set; }

		/// <summary>
		/// <para>Preference Table</para>
		/// <para>The table of preferences that control how air traffic service (ATS) routes are processed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object PreferenceTable { get; set; }

		/// <summary>
		/// <para>Preference</para>
		/// <para>The name of a preference from the Preference Table parameter. The preference controls how air traffic service (ATS) routes are processed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Preference { get; set; }

		/// <summary>
		/// <para>Updated Cartographic Route Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object UpdatedCartoRouteFeatures { get; set; }

	}
}
