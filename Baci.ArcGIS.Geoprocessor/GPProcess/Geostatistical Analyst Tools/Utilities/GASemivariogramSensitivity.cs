using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>Semivariogram Sensitivity</para>
	/// <para>This tool performs a sensitivity analysis on the predicted values and associated standard errors by changing the model's semivariogram parameters (the nugget, partial sill, and major/minor ranges) within a percentage of the original values.</para>
	/// </summary>
	public class GASemivariogramSensitivity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGaModelSource">
		/// <para>Input geostatistical model source</para>
		/// <para>The geostatistical model source to be analyzed.</para>
		/// </param>
		/// <param name="InDatasets">
		/// <para>Input dataset(s)</para>
		/// <para>The name of the input datasets and field names used in the creation of the output layer.</para>
		/// </param>
		/// <param name="InLocations">
		/// <para>Input point observation locations</para>
		/// <para>Point locations where the sensitivity analysis is performed.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output table</para>
		/// <para>Table storing the sensitivity results.</para>
		/// </param>
		public GASemivariogramSensitivity(object InGaModelSource, object InDatasets, object InLocations, object OutTable)
		{
			this.InGaModelSource = InGaModelSource;
			this.InDatasets = InDatasets;
			this.InLocations = InLocations;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Semivariogram Sensitivity</para>
		/// </summary>
		public override string DisplayName => "Semivariogram Sensitivity";

		/// <summary>
		/// <para>Tool Name : GASemivariogramSensitivity</para>
		/// </summary>
		public override string ToolName => "GASemivariogramSensitivity";

		/// <summary>
		/// <para>Tool Excute Name : ga.GASemivariogramSensitivity</para>
		/// </summary>
		public override string ExcuteName => "ga.GASemivariogramSensitivity";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "coincidentPoints", "randomGenerator", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InGaModelSource, InDatasets, InLocations, NuggetSpanPercents!, NuggetCalcTimes!, PartialsillSpanPercents!, PartialsillCalcTimes!, RangeSpanPercents!, RangeCalcTimes!, MinrangeSpanPercents!, MinrangeCalcTimes!, OutTable };

		/// <summary>
		/// <para>Input geostatistical model source</para>
		/// <para>The geostatistical model source to be analyzed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InGaModelSource { get; set; }

		/// <summary>
		/// <para>Input dataset(s)</para>
		/// <para>The name of the input datasets and field names used in the creation of the output layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGAValueTable()]
		public object InDatasets { get; set; }

		/// <summary>
		/// <para>Input point observation locations</para>
		/// <para>Point locations where the sensitivity analysis is performed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InLocations { get; set; }

		/// <summary>
		/// <para>Nugget span (% of model value)</para>
		/// <para>The percentage subtracted and added to the Nugget parameter to create a range for a subsequent random Nugget parameter selection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain()]
		public object? NuggetSpanPercents { get; set; } = "10";

		/// <summary>
		/// <para>Number of calculations for Nugget</para>
		/// <para>Number of random Nugget values randomly sampled from the Nugget span.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		public object? NuggetCalcTimes { get; set; } = "3";

		/// <summary>
		/// <para>Partial Sill span (% of model value)</para>
		/// <para>Percentage subtracted from and added to the Partial Sill parameter to create a range for a random Partial Sill selection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain()]
		public object? PartialsillSpanPercents { get; set; } = "0";

		/// <summary>
		/// <para>Number of calculations for Partial Sill</para>
		/// <para>Number of Partial Sill values randomly sampled from the Partial Sill span.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		public object? PartialsillCalcTimes { get; set; } = "0";

		/// <summary>
		/// <para>Major Range span (% of model value)</para>
		/// <para>Percentage subtracted and added to the Major Range parameter to create a range for a random Major Range selection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain()]
		public object? RangeSpanPercents { get; set; } = "0";

		/// <summary>
		/// <para>Number of calculations for Major Range</para>
		/// <para>Number of Major Range values randomly sampled from the Major Range span.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		public object? RangeCalcTimes { get; set; } = "0";

		/// <summary>
		/// <para>Minor Range span (% of model value)</para>
		/// <para>Percentage subtracted and added to the Minor Range parameter to create a range for a random Minor Range selection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain()]
		public object? MinrangeSpanPercents { get; set; } = "0";

		/// <summary>
		/// <para>Number of calculations for Minor Range</para>
		/// <para>Number of Minor Range values randomly sampled from the Minor Range span.</para>
		/// <para>If Anisotropy has been set in the input geostatistical model source, a value is required.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		public object? MinrangeCalcTimes { get; set; } = "0";

		/// <summary>
		/// <para>Output table</para>
		/// <para>Table storing the sensitivity results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GASemivariogramSensitivity SetEnviroment(object? coincidentPoints = null , object? randomGenerator = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(coincidentPoints: coincidentPoints, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
