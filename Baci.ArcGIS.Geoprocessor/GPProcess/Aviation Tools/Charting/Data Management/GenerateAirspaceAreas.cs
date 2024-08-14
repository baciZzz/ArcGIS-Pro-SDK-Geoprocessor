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
	/// <para>Generate Airspace Areas</para>
	/// <para>Generates AirspaceArea features from Airspace features.</para>
	/// </summary>
	public class GenerateAirspaceAreas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InAirspaceFeatures">
		/// <para>Input Airspace Features</para>
		/// <para>The input Airspace features. These features adhere to the AIS geodatabase schema.</para>
		/// </param>
		/// <param name="TargetAirspaceAreaFeatures">
		/// <para>Target Airspace Area Features</para>
		/// <para>The target AirspaceArea feature class. These features adhere to the AIS geodatabase schema.</para>
		/// </param>
		/// <param name="AoiFeatures">
		/// <para>Area of Interest Features</para>
		/// <para>The area of interest boundary within which features will be processed.</para>
		/// </param>
		/// <param name="PreferenceTable">
		/// <para>Preference Table</para>
		/// <para>The table containing the specified preferences.</para>
		/// </param>
		/// <param name="Preference">
		/// <para>Preference</para>
		/// <para>The preference derived from the Preference Table parameter that will be used to process the airspace features at the chosen altitudes..</para>
		/// </param>
		public GenerateAirspaceAreas(object InAirspaceFeatures, object TargetAirspaceAreaFeatures, object AoiFeatures, object PreferenceTable, object Preference)
		{
			this.InAirspaceFeatures = InAirspaceFeatures;
			this.TargetAirspaceAreaFeatures = TargetAirspaceAreaFeatures;
			this.AoiFeatures = AoiFeatures;
			this.PreferenceTable = PreferenceTable;
			this.Preference = Preference;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Airspace Areas</para>
		/// </summary>
		public override string DisplayName => "Generate Airspace Areas";

		/// <summary>
		/// <para>Tool Name : GenerateAirspaceAreas</para>
		/// </summary>
		public override string ToolName => "GenerateAirspaceAreas";

		/// <summary>
		/// <para>Tool Excute Name : aviation.GenerateAirspaceAreas</para>
		/// </summary>
		public override string ExcuteName => "aviation.GenerateAirspaceAreas";

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
		public override object[] Parameters => new object[] { InAirspaceFeatures, TargetAirspaceAreaFeatures, AoiFeatures, PreferenceTable, Preference, DerivedAirspacePartFeatures, VerticalLimitOverrideTable, UpdatedAirspaceAreaFeatures };

		/// <summary>
		/// <para>Input Airspace Features</para>
		/// <para>The input Airspace features. These features adhere to the AIS geodatabase schema.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InAirspaceFeatures { get; set; }

		/// <summary>
		/// <para>Target Airspace Area Features</para>
		/// <para>The target AirspaceArea feature class. These features adhere to the AIS geodatabase schema.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object TargetAirspaceAreaFeatures { get; set; }

		/// <summary>
		/// <para>Area of Interest Features</para>
		/// <para>The area of interest boundary within which features will be processed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object AoiFeatures { get; set; }

		/// <summary>
		/// <para>Preference Table</para>
		/// <para>The table containing the specified preferences.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object PreferenceTable { get; set; }

		/// <summary>
		/// <para>Preference</para>
		/// <para>The preference derived from the Preference Table parameter that will be used to process the airspace features at the chosen altitudes..</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Preference { get; set; }

		/// <summary>
		/// <para>Derived Airspace Parts</para>
		/// <para>The feature class that will be updated with airspace features derived from the Input Airspace Features parameter.</para>
		/// <para>The feature class that will be updated with airspace features derived from the in_airspace_features parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object DerivedAirspacePartFeatures { get; set; }

		/// <summary>
		/// <para>Vertical Limit Override Table</para>
		/// <para>A table that overrides the vertical height values set in the preference table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object VerticalLimitOverrideTable { get; set; }

		/// <summary>
		/// <para>Updated Airspace Area Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object UpdatedAirspaceAreaFeatures { get; set; }

	}
}
