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
	/// <para>Enrich</para>
	/// <para>Enriches data by adding demographic and landscape facts about the people and places that surround or are inside data locations.  The output is a duplicate of your input with additional attribute fields.  This tool requires an ArcGIS Online organizational account or a locally installed Business Analyst dataset.</para>
	/// </summary>
	[Obsolete()]
	public class Enrich : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The features to be enriched.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output feature class</para>
		/// <para>A new layer containing both the input attributes and user-selected attributes. User-selected attributes are summarized from underlying demographic boundaries. Only the area inside the input boundary is considered.</para>
		/// </param>
		public Enrich(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Enrich</para>
		/// </summary>
		public override string DisplayName => "Enrich";

		/// <summary>
		/// <para>Tool Name : Enrich</para>
		/// </summary>
		public override string ToolName => "Enrich";

		/// <summary>
		/// <para>Tool Excute Name : analysis.Enrich</para>
		/// </summary>
		public override string ExcuteName => "analysis.Enrich";

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
		public override string[] ValidEnvironments => new string[] { "baDataSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, Variables, BufferType, Distance, Unit };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The features to be enriched.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output feature class</para>
		/// <para>A new layer containing both the input attributes and user-selected attributes. User-selected attributes are summarized from underlying demographic boundaries. Only the area inside the input boundary is considered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Variables</para>
		/// <para>The variables to be summarized and added to the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Variables { get; set; }

		/// <summary>
		/// <para>Define areas to enrich</para>
		/// <para>Input point features must have an associated boundary polygon to enrich. When connected to ArcGIS Online, travel mode options are dynamically populated. Input line features can only use Straight Line distance. The default value is Straight Line.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object BufferType { get; set; }

		/// <summary>
		/// <para>Distance or time</para>
		/// <para>Determines the distance or size of an area to enrich (for example, a 1-mile buffer or 5-minute walk time). Units correspond to the buffer type. The default value is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Distance { get; set; } = "1";

		/// <summary>
		/// <para>Unit</para>
		/// <para>The units associated with the distance or time parameter.</para>
		/// <para>Miles—Miles</para>
		/// <para>Yards—Yards</para>
		/// <para>Feet—Feet</para>
		/// <para>Kilometers—Kilometers</para>
		/// <para>Meters—Meters</para>
		/// <para>Hours—Hours</para>
		/// <para>Minutes—Minutes</para>
		/// <para>Seconds—Seconds</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Unit { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Enrich SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
