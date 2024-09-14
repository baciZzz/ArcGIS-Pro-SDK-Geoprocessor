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
	/// <para>Rename</para>
	/// <para>重命名</para>
	/// <para>更改数据集的名称。 其中包括各种数据类型，包括要素数据集、栅格、表和 shapefile。</para>
	/// </summary>
	public class Rename : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input Data Element</para>
		/// <para>要重命名的输入数据。</para>
		/// </param>
		/// <param name="OutData">
		/// <para>Output Data Element</para>
		/// <para>输出数据的名称。</para>
		/// </param>
		public Rename(object InData, object OutData)
		{
			this.InData = InData;
			this.OutData = OutData;
		}

		/// <summary>
		/// <para>Tool Display Name : 重命名</para>
		/// </summary>
		public override string DisplayName() => "重命名";

		/// <summary>
		/// <para>Tool Name : 重命名</para>
		/// </summary>
		public override string ToolName() => "重命名";

		/// <summary>
		/// <para>Tool Excute Name : management.Rename</para>
		/// </summary>
		public override string ExcuteName() => "management.Rename";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InData, OutData, DataType! };

		/// <summary>
		/// <para>Input Data Element</para>
		/// <para>要重命名的输入数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEType()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Output Data Element</para>
		/// <para>输出数据的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEType()]
		public object OutData { get; set; }

		/// <summary>
		/// <para>Data Type</para>
		/// <para>要重命名的数据的类型。 只有在地理数据库中的要素数据集和要素类名称相同时，才需要提供一个值。 在这种情况下，需要为希望重命名的项选择数据类型（要素数据集或要素类）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DataType { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Rename SetEnviroment(object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
