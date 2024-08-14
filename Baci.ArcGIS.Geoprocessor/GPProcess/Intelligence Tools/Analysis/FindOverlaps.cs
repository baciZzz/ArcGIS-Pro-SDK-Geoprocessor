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
	/// <para>Find Overlaps</para>
	/// <para>Finds overlapping areas in a feature class and provides a count for the number of overlaps.</para>
	/// </summary>
	public class FindOverlaps : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input polygon features for which overlaps will be computed.</para>
		/// </param>
		/// <param name="OutIntersection">
		/// <para>Output Intersections</para>
		/// <para>The output intersection areas.</para>
		/// </param>
		/// <param name="OutCentroid">
		/// <para>Output Centroids</para>
		/// <para>The output centroid locations of the Output Intersections features.</para>
		/// </param>
		public FindOverlaps(object InFeatures, object OutIntersection, object OutCentroid)
		{
			this.InFeatures = InFeatures;
			this.OutIntersection = OutIntersection;
			this.OutCentroid = OutCentroid;
		}

		/// <summary>
		/// <para>Tool Display Name : Find Overlaps</para>
		/// </summary>
		public override string DisplayName => "Find Overlaps";

		/// <summary>
		/// <para>Tool Name : FindOverlaps</para>
		/// </summary>
		public override string ToolName => "FindOverlaps";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.FindOverlaps</para>
		/// </summary>
		public override string ExcuteName => "intelligence.FindOverlaps";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutIntersection, OutCentroid, GroupField };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input polygon features for which overlaps will be computed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Intersections</para>
		/// <para>The output intersection areas.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		public object OutIntersection { get; set; }

		/// <summary>
		/// <para>Output Centroids</para>
		/// <para>The output centroid locations of the Output Intersections features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		public object OutCentroid { get; set; }

		/// <summary>
		/// <para>Group Field</para>
		/// <para>The Input Features group field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object GroupField { get; set; }

	}
}
