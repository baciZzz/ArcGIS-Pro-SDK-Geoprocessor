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
	/// <para>Generate Airspace Lines</para>
	/// <para>Generate Airspace Lines</para>
	/// <para>Adds, modifies, or deletes polyline features from coincident edges of airspace polygons.</para>
	/// </summary>
	public class GenerateAirspaceLines : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InAirspaceFeatures">
		/// <para>Input Airspace Features</para>
		/// <para>The polygon feature class containing the airspace boundaries.</para>
		/// </param>
		/// <param name="TargetAirspaceLineFeatures">
		/// <para>Target Airspace Line Features</para>
		/// <para>The polyline feature class containing the airspace line data.</para>
		/// </param>
		/// <param name="AoiFeatures">
		/// <para>Area of Interest Features</para>
		/// <para>The polygon feature class containing the area of interest (AOI) data.</para>
		/// <para>The tool will use the selected polygon features to filter which airspace lines will be added, modified, or deleted.</para>
		/// </param>
		/// <param name="PreferenceTable">
		/// <para>Preference Table</para>
		/// <para>The table of preferences that controls how the airspace lines are added, modified, or deleted.</para>
		/// </param>
		/// <param name="Preference">
		/// <para>Preference</para>
		/// <para>The name of a preference in the Preference Table parameter. The selected preference controls how the airspace lines are added, modified, or deleted.</para>
		/// <para>The name of a selected preference in the preference_table parameter. The selected preference controls how the airspace lines are added, modified, or deleted.</para>
		/// </param>
		public GenerateAirspaceLines(object InAirspaceFeatures, object TargetAirspaceLineFeatures, object AoiFeatures, object PreferenceTable, object Preference)
		{
			this.InAirspaceFeatures = InAirspaceFeatures;
			this.TargetAirspaceLineFeatures = TargetAirspaceLineFeatures;
			this.AoiFeatures = AoiFeatures;
			this.PreferenceTable = PreferenceTable;
			this.Preference = Preference;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Airspace Lines</para>
		/// </summary>
		public override string DisplayName() => "Generate Airspace Lines";

		/// <summary>
		/// <para>Tool Name : GenerateAirspaceLines</para>
		/// </summary>
		public override string ToolName() => "GenerateAirspaceLines";

		/// <summary>
		/// <para>Tool Excute Name : aviation.GenerateAirspaceLines</para>
		/// </summary>
		public override string ExcuteName() => "aviation.GenerateAirspaceLines";

		/// <summary>
		/// <para>Toolbox Display Name : Aviation Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Aviation Tools";

		/// <summary>
		/// <para>Toolbox Alise : aviation</para>
		/// </summary>
		public override string ToolboxAlise() => "aviation";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InAirspaceFeatures, TargetAirspaceLineFeatures, AoiFeatures, PreferenceTable, Preference, UpdatedAirspaceLineFeatures! };

		/// <summary>
		/// <para>Input Airspace Features</para>
		/// <para>The polygon feature class containing the airspace boundaries.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InAirspaceFeatures { get; set; }

		/// <summary>
		/// <para>Target Airspace Line Features</para>
		/// <para>The polyline feature class containing the airspace line data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object TargetAirspaceLineFeatures { get; set; }

		/// <summary>
		/// <para>Area of Interest Features</para>
		/// <para>The polygon feature class containing the area of interest (AOI) data.</para>
		/// <para>The tool will use the selected polygon features to filter which airspace lines will be added, modified, or deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object AoiFeatures { get; set; }

		/// <summary>
		/// <para>Preference Table</para>
		/// <para>The table of preferences that controls how the airspace lines are added, modified, or deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object PreferenceTable { get; set; }

		/// <summary>
		/// <para>Preference</para>
		/// <para>The name of a preference in the Preference Table parameter. The selected preference controls how the airspace lines are added, modified, or deleted.</para>
		/// <para>The name of a selected preference in the preference_table parameter. The selected preference controls how the airspace lines are added, modified, or deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Preference { get; set; }

		/// <summary>
		/// <para>Updated Airspace Line Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object? UpdatedAirspaceLineFeatures { get; set; }

	}
}
