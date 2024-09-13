using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.BusinessAnalystTools
{
	/// <summary>
	/// <para>Enrich Layer</para>
	/// <para>Enrich Layer</para>
	/// <para>Enriches data by adding demographic and landscape facts about the people and places that surround or are inside data locations.</para>
	/// </summary>
	public class EnrichLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The features that will be enriched.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output layer containing both the input attributes and user-selected attributes. Selected attributes are summarized from underlying demographic boundaries. Only the area inside the input boundary is considered.</para>
		/// </param>
		public EnrichLayer(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Enrich Layer</para>
		/// </summary>
		public override string DisplayName() => "Enrich Layer";

		/// <summary>
		/// <para>Tool Name : EnrichLayer</para>
		/// </summary>
		public override string ToolName() => "EnrichLayer";

		/// <summary>
		/// <para>Tool Excute Name : ba.EnrichLayer</para>
		/// </summary>
		public override string ExcuteName() => "ba.EnrichLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise() => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "baDataSource", "baNetworkSource", "baUseDetailedAggregation", "geographicTransformations", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, Variables!, BufferType!, Distance!, Unit! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The features that will be enriched.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output layer containing both the input attributes and user-selected attributes. Selected attributes are summarized from underlying demographic boundaries. Only the area inside the input boundary is considered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Variables</para>
		/// <para>One or more variables that will be summarized and added to the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Variables { get; set; }

		/// <summary>
		/// <para>Define areas to enrich</para>
		/// <para>Defines the area that will be enriched. The default value is Straight Line.</para>
		/// <para>When you&apos;re signed in to ArcGIS Online, travel mode options are dynamically populated. Input line features can only use the Straight Line distance method.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? BufferType { get; set; }

		/// <summary>
		/// <para>Distance or time</para>
		/// <para>The distance or size of an area to enrich, for example, a 1-mile buffer or 5-minute walk time. Units correspond to the polygon type. The default value is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Distance { get; set; } = "1";

		/// <summary>
		/// <para>Unit</para>
		/// <para>The units associated with the Distance or time parameter. The default value is Kilometers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Unit { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EnrichLayer SetEnviroment(object? baDataSource = null , object? baNetworkSource = null , bool? baUseDetailedAggregation = null , object? geographicTransformations = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(baDataSource: baDataSource, baNetworkSource: baNetworkSource, baUseDetailedAggregation: baUseDetailedAggregation, geographicTransformations: geographicTransformations, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

	}
}
