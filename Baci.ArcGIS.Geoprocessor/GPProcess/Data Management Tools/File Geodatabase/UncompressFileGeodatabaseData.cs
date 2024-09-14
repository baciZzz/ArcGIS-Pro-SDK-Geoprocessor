using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Uncompress File Geodatabase Data</para>
	/// <para>Uncompress File Geodatabase Data</para>
	/// <para>Uncompresses all the contents in a geodatabase, all the contents in a feature</para>
	/// <para>dataset, or an individual stand-alone feature class or table.</para>
	/// </summary>
	public class UncompressFileGeodatabaseData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input file geodatabase data</para>
		/// <para>The geodatabase, feature dataset, feature class, or table to uncompress.</para>
		/// </param>
		public UncompressFileGeodatabaseData(object InData)
		{
			this.InData = InData;
		}

		/// <summary>
		/// <para>Tool Display Name : Uncompress File Geodatabase Data</para>
		/// </summary>
		public override string DisplayName() => "Uncompress File Geodatabase Data";

		/// <summary>
		/// <para>Tool Name : UncompressFileGeodatabaseData</para>
		/// </summary>
		public override string ToolName() => "UncompressFileGeodatabaseData";

		/// <summary>
		/// <para>Tool Excute Name : management.UncompressFileGeodatabaseData</para>
		/// </summary>
		public override string ExcuteName() => "management.UncompressFileGeodatabaseData";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InData, ConfigKeyword, OutData };

		/// <summary>
		/// <para>Input file geodatabase data</para>
		/// <para>The geodatabase, feature dataset, feature class, or table to uncompress.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Configuration keyword</para>
		/// <para>The configuration keyword defining how the data will store once uncompressed</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Uncompressed Input Data</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object OutData { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UncompressFileGeodatabaseData SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
