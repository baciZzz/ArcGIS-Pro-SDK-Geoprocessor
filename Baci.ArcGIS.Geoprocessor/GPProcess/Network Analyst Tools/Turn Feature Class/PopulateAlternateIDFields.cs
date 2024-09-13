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
	/// <para>Populate Alternate ID Fields</para>
	/// <para>填充备用 ID 字段</para>
	/// <para>为通过备用 ID 来引用边的转弯要素类创建并填充附加字段。通过备用 ID 可以使用其他一组 ID，从而有助于在编辑源边时保持转弯要素的完整性。</para>
	/// </summary>
	public class PopulateAlternateIDFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDataset">
		/// <para>Input Network Dataset</para>
		/// <para>为转弯要素类创建备用 ID 字段时所在的网络数据集。将为所有作为转弯源添加到网络数据集中的转弯要素类创建字段。</para>
		/// </param>
		/// <param name="AlternateIDFieldName">
		/// <para>Alternate ID Field Name</para>
		/// <para>网络数据集中边要素源的备用 ID 字段名称。对于转弯引用的所有边要素源，其备用 ID 字段的名称必须相同。</para>
		/// </param>
		public PopulateAlternateIDFields(object InNetworkDataset, object AlternateIDFieldName)
		{
			this.InNetworkDataset = InNetworkDataset;
			this.AlternateIDFieldName = AlternateIDFieldName;
		}

		/// <summary>
		/// <para>Tool Display Name : 填充备用 ID 字段</para>
		/// </summary>
		public override string DisplayName() => "填充备用 ID 字段";

		/// <summary>
		/// <para>Tool Name : PopulateAlternateIDFields</para>
		/// </summary>
		public override string ToolName() => "PopulateAlternateIDFields";

		/// <summary>
		/// <para>Tool Excute Name : na.PopulateAlternateIDFields</para>
		/// </summary>
		public override string ExcuteName() => "na.PopulateAlternateIDFields";

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
		/// <para>为转弯要素类创建备用 ID 字段时所在的网络数据集。将为所有作为转弯源添加到网络数据集中的转弯要素类创建字段。</para>
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
		public PopulateAlternateIDFields SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
