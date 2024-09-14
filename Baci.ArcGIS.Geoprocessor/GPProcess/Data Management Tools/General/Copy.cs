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
	/// <para>Copy</para>
	/// <para>复制</para>
	/// <para>复制输入数据。</para>
	/// </summary>
	[Obsolete()]
	public class Copy : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input Data</para>
		/// <para>要复制的数据。</para>
		/// </param>
		/// <param name="OutData">
		/// <para>Output Data</para>
		/// <para>输出数据的位置和名称。</para>
		/// </param>
		public Copy(object InData, object OutData)
		{
			this.InData = InData;
			this.OutData = OutData;
		}

		/// <summary>
		/// <para>Tool Display Name : 复制</para>
		/// </summary>
		public override string DisplayName() => "复制";

		/// <summary>
		/// <para>Tool Name : 复制</para>
		/// </summary>
		public override string ToolName() => "复制";

		/// <summary>
		/// <para>Tool Excute Name : management.Copy</para>
		/// </summary>
		public override string ExcuteName() => "management.Copy";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "maintainAttachments", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InData, OutData, DataType!, AssociatedData! };

		/// <summary>
		/// <para>Input Data</para>
		/// <para>要复制的数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEType()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Output Data</para>
		/// <para>输出数据的位置和名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEType()]
		public object OutData { get; set; }

		/// <summary>
		/// <para>Data type</para>
		/// <para>磁盘上要复制的数据的类型。 仅当输入数据位于地理数据库中且存在命名冲突（例如，如果地理数据库包含同名的要素数据集和要素类）时需要此项。 在这种情况下，数据类型将用于确定要复制的数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DataType { get; set; }

		/// <summary>
		/// <para>Associated Data</para>
		/// <para>如果输入具有关联的数据，则此参数可用于控制关联输出数据名称和配置关键字。</para>
		/// <para>自名称 - 将与输入数据一同复制的相关联的数据。</para>
		/// <para>数据类型 - 磁盘上要复制的数据的类型。 只有在地理数据库中的要素数据集和要素类名称相同时，才需要提供一个值。 在这种情况下，需要为希望复制的项选择数据类型（FeatureDataset 或 FeatureClass）。</para>
		/// <para>至名称 - 输出数据参数值中已复制数据的名称。</para>
		/// <para>配置关键字 - 地理数据库存储参数（配置）。</para>
		/// <para>如果已在输出数据中使用了至名称值，则自名称和至名称列名称将相同。 如果某个名称已存在于输出数据值中，则将通过附加下划线加数字（例如 rivers_1）来创建唯一的至名称值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? AssociatedData { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Copy SetEnviroment(object? configKeyword = null, bool? maintainAttachments = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(configKeyword: configKeyword, maintainAttachments: maintainAttachments, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
