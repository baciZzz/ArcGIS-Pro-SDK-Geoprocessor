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
	/// <para>Generate Derived Airspace Geometry</para>
	/// <para>Generates airspace  geometry for associated airspace features from an imported AIXM 5.1 message.</para>
	/// </summary>
	public class GenerateDerivedAirspaceGeometry : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InAirspaceFeatures">
		/// <para>Input Airspace Features</para>
		/// <para>The input polygon feature class containing three or more airspace features, some or all of which will be used to derive more complex airspace features. The derived features will be updated in this target feature class.</para>
		/// </param>
		/// <param name="AirspaceAssociationTable">
		/// <para>Airspace Association Table</para>
		/// <para>The input table containing information about the geometric associations between two or more airspace features. The airspace relationship information stored in this table is populated through the AIXM import process.</para>
		/// </param>
		public GenerateDerivedAirspaceGeometry(object InAirspaceFeatures, object AirspaceAssociationTable)
		{
			this.InAirspaceFeatures = InAirspaceFeatures;
			this.AirspaceAssociationTable = AirspaceAssociationTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Derived Airspace Geometry</para>
		/// </summary>
		public override string DisplayName => "Generate Derived Airspace Geometry";

		/// <summary>
		/// <para>Tool Name : GenerateDerivedAirspaceGeometry</para>
		/// </summary>
		public override string ToolName => "GenerateDerivedAirspaceGeometry";

		/// <summary>
		/// <para>Tool Excute Name : aviation.GenerateDerivedAirspaceGeometry</para>
		/// </summary>
		public override string ExcuteName => "aviation.GenerateDerivedAirspaceGeometry";

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
		public override object[] Parameters => new object[] { InAirspaceFeatures, AirspaceAssociationTable, UpdatedAirspaceFeatures!, AirspacePartFeatures! };

		/// <summary>
		/// <para>Input Airspace Features</para>
		/// <para>The input polygon feature class containing three or more airspace features, some or all of which will be used to derive more complex airspace features. The derived features will be updated in this target feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InAirspaceFeatures { get; set; }

		/// <summary>
		/// <para>Airspace Association Table</para>
		/// <para>The input table containing information about the geometric associations between two or more airspace features. The airspace relationship information stored in this table is populated through the AIXM import process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object AirspaceAssociationTable { get; set; }

		/// <summary>
		/// <para>Updated Derived Airspace Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object? UpdatedAirspaceFeatures { get; set; }

		/// <summary>
		/// <para>Airspace Parts</para>
		/// <para>The feature class to be updated with airspace features derived from the Input Airspace Features parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object? AirspacePartFeatures { get; set; }

	}
}
