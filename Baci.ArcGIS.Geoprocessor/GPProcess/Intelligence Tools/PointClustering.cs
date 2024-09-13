using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Point Clustering</para>
	/// <para>点聚类</para>
	/// <para>Find clusters of point features.</para>
	/// </summary>
	[Obsolete()]
	public class PointClustering : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputPointFeatures">
		/// <para>Input Points</para>
		/// </param>
		public PointClustering(object InputPointFeatures)
		{
			this.InputPointFeatures = InputPointFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 点聚类</para>
		/// </summary>
		public override string DisplayName() => "点聚类";

		/// <summary>
		/// <para>Tool Name : PointClustering</para>
		/// </summary>
		public override string ToolName() => "PointClustering";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.PointClustering</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.PointClustering";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise() => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputPointFeatures, InputSearchDistance!, MinimumFeaturesCluster!, OutputIdList! };

		/// <summary>
		/// <para>Input Points</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InputPointFeatures { get; set; }

		/// <summary>
		/// <para>Distance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? InputSearchDistance { get; set; } = "100 Meters";

		/// <summary>
		/// <para>Minimum Features per Cluster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MinimumFeaturesCluster { get; set; } = "5";

		/// <summary>
		/// <para>Output OIDs</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutputIdList { get; set; }

	}
}
