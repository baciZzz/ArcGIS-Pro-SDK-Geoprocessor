using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AviationTools
{
	/// <summary>
	/// <para>Generate Aviation Chart Leads</para>
	/// <para>Generate Aviation Chart Leads</para>
	/// <para>Creates text graphics at intersection points between a map frame boundary and line features.</para>
	/// </summary>
	public class GenerateAviationChartLeads : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayout">
		/// <para>Layout</para>
		/// <para>The target layout that contains the map frame for which chart leads will be generated.</para>
		/// </param>
		/// <param name="InMapframe">
		/// <para>Map Frame</para>
		/// <para>The map frame for which chart leads will be generated.</para>
		/// </param>
		/// <param name="InPreferencesTable">
		/// <para>Preferences Table</para>
		/// <para>The table of preferences that controls how the chart leads will be calculated and placed.</para>
		/// </param>
		/// <param name="Preference">
		/// <para>Preference</para>
		/// <para>The list of preferences determined from the Preferences Table parameter.</para>
		/// </param>
		public GenerateAviationChartLeads(object InLayout, object InMapframe, object InPreferencesTable, object Preference)
		{
			this.InLayout = InLayout;
			this.InMapframe = InMapframe;
			this.InPreferencesTable = InPreferencesTable;
			this.Preference = Preference;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Aviation Chart Leads</para>
		/// </summary>
		public override string DisplayName() => "Generate Aviation Chart Leads";

		/// <summary>
		/// <para>Tool Name : GenerateAviationChartLeads</para>
		/// </summary>
		public override string ToolName() => "GenerateAviationChartLeads";

		/// <summary>
		/// <para>Tool Excute Name : aviation.GenerateAviationChartLeads</para>
		/// </summary>
		public override string ExcuteName() => "aviation.GenerateAviationChartLeads";

		/// <summary>
		/// <para>Toolbox Display Name : Aviation Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Aviation Tools";

		/// <summary>
		/// <para>Toolbox Alise : aviation</para>
		/// </summary>
		public override string ToolboxAlise() => "aviation";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLayout, InMapframe, InPreferencesTable, Preference, UpdatedLayout! };

		/// <summary>
		/// <para>Layout</para>
		/// <para>The target layout that contains the map frame for which chart leads will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayout()]
		public object InLayout { get; set; }

		/// <summary>
		/// <para>Map Frame</para>
		/// <para>The map frame for which chart leads will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InMapframe { get; set; }

		/// <summary>
		/// <para>Preferences Table</para>
		/// <para>The table of preferences that controls how the chart leads will be calculated and placed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InPreferencesTable { get; set; }

		/// <summary>
		/// <para>Preference</para>
		/// <para>The list of preferences determined from the Preferences Table parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Preference { get; set; }

		/// <summary>
		/// <para>Updated Layout</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLayout()]
		public object? UpdatedLayout { get; set; }

	}
}
