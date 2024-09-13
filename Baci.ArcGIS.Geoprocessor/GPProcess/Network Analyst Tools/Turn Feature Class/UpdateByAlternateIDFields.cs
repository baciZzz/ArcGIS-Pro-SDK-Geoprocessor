using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Update by Alternate ID Fields</para>
	/// <para>按备用 ID 字段更新</para>
	/// <para>使用备用 ID 字段更新转弯要素类中的所有边引用。对转弯要素所引用的输入线要素进行编辑后，应使用此工具根据备用 ID 字段来同步转弯要素。</para>
	/// </summary>
	public class UpdateByAlternateIDFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDataset">
		/// <para>Input Network Dataset</para>
		/// <para>要按备用 ID 字段更新转弯要素类的网络数据集。</para>
		/// </param>
		/// <param name="AlternateIDFieldName">
		/// <para>Alternate ID Field Name</para>
		/// <para>网络数据集中边要素源的备用 ID 字段名称。对于转弯引用的所有边要素源，其备用 ID 字段的名称必须相同。</para>
		/// </param>
		public UpdateByAlternateIDFields(object InNetworkDataset, object AlternateIDFieldName)
		{
			this.InNetworkDataset = InNetworkDataset;
			this.AlternateIDFieldName = AlternateIDFieldName;
		}

		/// <summary>
		/// <para>Tool Display Name : 按备用 ID 字段更新</para>
		/// </summary>
		public override string DisplayName() => "按备用 ID 字段更新";

		/// <summary>
		/// <para>Tool Name : UpdateByAlternateIDFields</para>
		/// </summary>
		public override string ToolName() => "UpdateByAlternateIDFields";

		/// <summary>
		/// <para>Tool Excute Name : na.UpdateByAlternateIDFields</para>
		/// </summary>
		public override string ExcuteName() => "na.UpdateByAlternateIDFields";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise() => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InNetworkDataset, AlternateIDFieldName, OutNetworkDataset };

		/// <summary>
		/// <para>Input Network Dataset</para>
		/// <para>要按备用 ID 字段更新转弯要素类的网络数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Alternate ID Field Name</para>
		/// <para>网络数据集中边要素源的备用 ID 字段名称。对于转弯引用的所有边要素源，其备用 ID 字段的名称必须相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object AlternateIDFieldName { get; set; }

		/// <summary>
		/// <para>Updated Input Network Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNetworkDatasetLayer()]
		public object OutNetworkDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UpdateByAlternateIDFields SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
