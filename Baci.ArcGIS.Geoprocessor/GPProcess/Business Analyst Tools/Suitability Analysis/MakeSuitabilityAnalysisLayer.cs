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
	/// <para>Make Suitability Analysis Layer</para>
	/// <para>Creates a Suitability Analysis layer for a given input site's polygonal layer.</para>
	/// </summary>
	public class MakeSuitabilityAnalysisLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The feature layer that will be used in the creation of the Suitability Analysis layer.</para>
		/// </param>
		/// <param name="LayerName">
		/// <para>Layer Name</para>
		/// <para>The name of the output Suitability Analysis layer to be created.</para>
		/// </param>
		public MakeSuitabilityAnalysisLayer(object InFeatures, object LayerName)
		{
			this.InFeatures = InFeatures;
			this.LayerName = LayerName;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Suitability Analysis Layer</para>
		/// </summary>
		public override string DisplayName() => "Make Suitability Analysis Layer";

		/// <summary>
		/// <para>Tool Name : MakeSuitabilityAnalysisLayer</para>
		/// </summary>
		public override string ToolName() => "MakeSuitabilityAnalysisLayer";

		/// <summary>
		/// <para>Tool Excute Name : ba.MakeSuitabilityAnalysisLayer</para>
		/// </summary>
		public override string ExcuteName() => "ba.MakeSuitabilityAnalysisLayer";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, LayerName, OutAnalysisLayer };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The feature layer that will be used in the creation of the Suitability Analysis layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Layer Name</para>
		/// <para>The name of the output Suitability Analysis layer to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object LayerName { get; set; } = "Suitability Analysis";

		/// <summary>
		/// <para>Output Suitability Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeSuitabilityAnalysisLayer SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
