using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.StandardFeatureAnalysisTools
{
	/// <summary>
	/// <para>Find Hot Spots</para>
	/// <para>Identifies statistically significant spatial clustering of high values (hot spots) or low values (cold spots), or data counts,  in your data. Use this tool to uncover hot  and cold spots of high and low home values, crime densities, traffic accident fatalities, unemployment or biodiversity, for example.</para>
	/// </summary>
	public class FindHotSpots : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Analysislayer">
		/// <para>Input Features</para>
		/// <para>The point or polygon feature layer for which hot spots will be calculated.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output layer to create on your portal.</para>
		/// </param>
		public FindHotSpots(object Analysislayer, object Outputname)
		{
			this.Analysislayer = Analysislayer;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : Find Hot Spots</para>
		/// </summary>
		public override string DisplayName => "Find Hot Spots";

		/// <summary>
		/// <para>Tool Name : FindHotSpots</para>
		/// </summary>
		public override string ToolName => "FindHotSpots";

		/// <summary>
		/// <para>Tool Excute Name : sfa.FindHotSpots</para>
		/// </summary>
		public override string ExcuteName => "sfa.FindHotSpots";

		/// <summary>
		/// <para>Toolbox Display Name : Standard Feature Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Standard Feature Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : sfa</para>
		/// </summary>
		public override string ToolboxAlise => "sfa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Analysislayer, Outputname, Analysisfield, Dividebyfield, Boundingpolygonlayer, Aggregatepolygonlayer, Outputlayer };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The point or polygon feature layer for which hot spots will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		public object Analysislayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output layer to create on your portal.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Analysis Field</para>
		/// <para>A numeric field (number of incidents, crime rates, test scores, and so on) to be evaluated. The field you select might represent the following:</para>
		/// <para>Counts (such as the number of traffic accidents)</para>
		/// <para>Rates (such as the number of crimes per square mile)</para>
		/// <para>Averages (such as the mean math test score)</para>
		/// <para>Indices (such as a customer satisfaction score)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object Analysisfield { get; set; }

		/// <summary>
		/// <para>Divide By Field</para>
		/// <para>The numeric field in the input layer that will be used to normalize your data. For example, if your points represent crimes, dividing by total population would result in an analysis of crimes per capita rather than raw crime counts.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object Dividebyfield { get; set; }

		/// <summary>
		/// <para>Bounding Polygons</para>
		/// <para>When the analysis layer is points and no analysis field is specified, you can provide polygon features that define where incidents could have occurred. For example, if you are analyzing boating accidents in a harbor, the outline of the harbor might provide a good boundary for where accidents could occur. When no bounding areas are provided, only locations with at least one point will be included in the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object Boundingpolygonlayer { get; set; }

		/// <summary>
		/// <para>Aggregation Polygons</para>
		/// <para>When the input layer contains points and no analysis field is specified, you can provide polygon features into which the points will be aggregated and analyzed, such as administrative units. The number of points that fall within each polygon is counted and the point count in each polygon is analyzed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object Aggregatepolygonlayer { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Outputlayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindHotSpots SetEnviroment(object extent = null )
		{
			base.SetEnv(extent: extent);
			return this;
		}

	}
}
