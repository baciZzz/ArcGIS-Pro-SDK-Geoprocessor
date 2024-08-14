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
	/// <para>Apply Feature Level Metadata</para>
	/// <para>Applies values from a metadata record in the FeatureLevelMetadata table to selected features that have matching attribute fields.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ApplyFeatureLevelMetadata : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The inputs to which the Metadata Favorite value will be applied.</para>
		/// </param>
		/// <param name="InMetadataTable">
		/// <para>Input Metadata Table</para>
		/// <para>The path to the metadata table containing the records that will be used to populate attributes.</para>
		/// </param>
		/// <param name="MetadataFavorite">
		/// <para>Metadata Favorite</para>
		/// <para>The record that will be used to populate attributes. The available options depend on the records available in the metadata table.</para>
		/// </param>
		public ApplyFeatureLevelMetadata(object InFeatures, object InMetadataTable, object MetadataFavorite)
		{
			this.InFeatures = InFeatures;
			this.InMetadataTable = InMetadataTable;
			this.MetadataFavorite = MetadataFavorite;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Feature Level Metadata</para>
		/// </summary>
		public override string DisplayName => "Apply Feature Level Metadata";

		/// <summary>
		/// <para>Tool Name : ApplyFeatureLevelMetadata</para>
		/// </summary>
		public override string ToolName => "ApplyFeatureLevelMetadata";

		/// <summary>
		/// <para>Tool Excute Name : topographic.ApplyFeatureLevelMetadata</para>
		/// </summary>
		public override string ExcuteName => "topographic.ApplyFeatureLevelMetadata";

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
		public override object[] Parameters => new object[] { InFeatures, InMetadataTable, MetadataFavorite, UpdatedFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The inputs to which the Metadata Favorite value will be applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Metadata Table</para>
		/// <para>The path to the metadata table containing the records that will be used to populate attributes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[GPTablesDomain()]
		public object InMetadataTable { get; set; }

		/// <summary>
		/// <para>Metadata Favorite</para>
		/// <para>The record that will be used to populate attributes. The available options depend on the records available in the metadata table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MetadataFavorite { get; set; }

		/// <summary>
		/// <para>Updated Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		public object? UpdatedFeatures { get; set; }

	}
}
