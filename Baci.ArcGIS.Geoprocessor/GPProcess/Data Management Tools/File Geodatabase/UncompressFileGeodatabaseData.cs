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
	/// <para>解压文件地理数据库数据</para>
	/// <para>此工具可解压缩地理数据库中的所有内容、要素数据集中的所有内容或各个独立要素类/表。</para>
	/// </summary>
	public class UncompressFileGeodatabaseData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input file geodatabase data</para>
		/// <para>要解压缩的地理数据库、要素数据集、要素类或表。</para>
		/// </param>
		public UncompressFileGeodatabaseData(object InData)
		{
			this.InData = InData;
		}

		/// <summary>
		/// <para>Tool Display Name : 解压文件地理数据库数据</para>
		/// </summary>
		public override string DisplayName() => "解压文件地理数据库数据";

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
		/// <para>要解压缩的地理数据库、要素数据集、要素类或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Configuration keyword</para>
		/// <para>用于定义解压缩后数据的存储方式的配置关键字</para>
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
