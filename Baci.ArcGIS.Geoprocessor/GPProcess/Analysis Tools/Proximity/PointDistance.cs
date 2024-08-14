using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Point Distance</para>
	/// <para>Determines the distances from input point features to all points in the near features within a specified search radius.</para>
	/// </summary>
	[Obsolete()]
	public class PointDistance : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The point features from which distances to the near features will be calculated.</para>
		/// </param>
		/// <param name="NearFeatures">
		/// <para>Near Features</para>
		/// <para>The points to which distances from the input features will be calculated. Distances between points within the same feature class or layer can be determined by specifying the same feature class or layer for the input and near features.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The table containing the list of input features and information about all near features within the search radius. If a search radius is not specified, distances from all input features to all near features are calculated.</para>
		/// </param>
		public PointDistance(object InFeatures, object NearFeatures, object OutTable)
		{
			this.InFeatures = InFeatures;
			this.NearFeatures = NearFeatures;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Point Distance</para>
		/// </summary>
		public override string DisplayName => "Point Distance";

		/// <summary>
		/// <para>Tool Name : PointDistance</para>
		/// </summary>
		public override string ToolName => "PointDistance";

		/// <summary>
		/// <para>Tool Excute Name : analysis.PointDistance</para>
		/// </summary>
		public override string ExcuteName => "analysis.PointDistance";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, NearFeatures, OutTable, SearchRadius! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The point features from which distances to the near features will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Near Features</para>
		/// <para>The points to which distances from the input features will be calculated. Distances between points within the same feature class or layer can be determined by specifying the same feature class or layer for the input and near features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object NearFeatures { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The table containing the list of input features and information about all near features within the search radius. If a search radius is not specified, distances from all input features to all near features are calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>Specifies the radius used to search for candidate near features. The near features within this radius are considered for calculating the nearest feature. If no value is specified (that is, the default (empty) radius is used) all near features are considered for calculation. The unit of search radius defaults to units of the input features. The units can be changed to any other unit. However, this has no impact on the units of the output DISTANCE field which is based on the units of the coordinate system of the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SearchRadius { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PointDistance SetEnviroment(object? extent = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
