using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Export MGCP Metadata</para>
	/// <para>Export MGCP Metadata</para>
	/// <para>Exports Multinational Geospatial Co-production Program (MGCP) metadata datasets (Cell, Subregion, and Source feature classes) to an XML file.</para>
	/// </summary>
	public class ExportMetadata : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCellFeatures">
		/// <para>Cell Features</para>
		/// <para>The MGCP Cell feature layer to export.</para>
		/// </param>
		/// <param name="ExportLocation">
		/// <para>Export Location</para>
		/// <para>The directory where the metadata XML files will be created.</para>
		/// </param>
		public ExportMetadata(object InCellFeatures, object ExportLocation)
		{
			this.InCellFeatures = InCellFeatures;
			this.ExportLocation = ExportLocation;
		}

		/// <summary>
		/// <para>Tool Display Name : Export MGCP Metadata</para>
		/// </summary>
		public override string DisplayName() => "Export MGCP Metadata";

		/// <summary>
		/// <para>Tool Name : ExportMetadata</para>
		/// </summary>
		public override string ToolName() => "ExportMetadata";

		/// <summary>
		/// <para>Tool Excute Name : topographic.ExportMetadata</para>
		/// </summary>
		public override string ExcuteName() => "topographic.ExportMetadata";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise() => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCellFeatures, ExportLocation, OutExportLocation! };

		/// <summary>
		/// <para>Cell Features</para>
		/// <para>The MGCP Cell feature layer to export.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InCellFeatures { get; set; }

		/// <summary>
		/// <para>Export Location</para>
		/// <para>The directory where the metadata XML files will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object ExportLocation { get; set; }

		/// <summary>
		/// <para>Output Export Location</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object? OutExportLocation { get; set; }

	}
}
