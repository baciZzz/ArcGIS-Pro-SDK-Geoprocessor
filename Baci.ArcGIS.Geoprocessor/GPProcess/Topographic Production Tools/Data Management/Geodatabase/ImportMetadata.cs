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
	/// <para>Import MGCP Metadata</para>
	/// <para>Imports Multinational Geospatial Co-production Program (MGCP) metadata into an MGCP database to perform maintenance on cells and subregions.</para>
	/// </summary>
	public class ImportMetadata : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Files">
		/// <para>Metadata Files</para>
		/// <para>The XML files that contain the metadata to import.</para>
		/// </param>
		/// <param name="InCellFeatures">
		/// <para>Cell Features</para>
		/// <para>The Cell feature class where the metadata will be imported.</para>
		/// </param>
		public ImportMetadata(object Files, object InCellFeatures)
		{
			this.Files = Files;
			this.InCellFeatures = InCellFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Import MGCP Metadata</para>
		/// </summary>
		public override string DisplayName => "Import MGCP Metadata";

		/// <summary>
		/// <para>Tool Name : ImportMetadata</para>
		/// </summary>
		public override string ToolName => "ImportMetadata";

		/// <summary>
		/// <para>Tool Excute Name : topographic.ImportMetadata</para>
		/// </summary>
		public override string ExcuteName => "topographic.ImportMetadata";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Files, InCellFeatures, OutCells };

		/// <summary>
		/// <para>Metadata Files</para>
		/// <para>The XML files that contain the metadata to import.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object Files { get; set; }

		/// <summary>
		/// <para>Cell Features</para>
		/// <para>The Cell feature class where the metadata will be imported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InCellFeatures { get; set; }

		/// <summary>
		/// <para>Output Cell Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutCells { get; set; }

	}
}
