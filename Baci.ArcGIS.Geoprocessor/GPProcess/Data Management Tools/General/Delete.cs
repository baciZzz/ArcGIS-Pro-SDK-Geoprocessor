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
	/// <para>Delete</para>
	/// <para>删除</para>
	/// <para>从磁盘中永久性删除数据。可删除 ArcGIS 支持的所有类型的地理数据以及工具箱和工作空间（文件夹和地理数据库）。如果指定的项为工作空间，则其中包含的所有项也将被删除。</para>
	/// </summary>
	public class Delete : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input Data Element</para>
		/// <para>要删除的输入数据。</para>
		/// </param>
		public Delete(object InData)
		{
			this.InData = InData;
		}

		/// <summary>
		/// <para>Tool Display Name : 删除</para>
		/// </summary>
		public override string DisplayName() => "删除";

		/// <summary>
		/// <para>Tool Name : 删除</para>
		/// </summary>
		public override string ToolName() => "删除";

		/// <summary>
		/// <para>Tool Excute Name : management.Delete</para>
		/// </summary>
		public override string ExcuteName() => "management.Delete";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InData, DataType, OutResults };

		/// <summary>
		/// <para>Input Data Element</para>
		/// <para>要删除的输入数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Data type</para>
		/// <para>磁盘上要删除的数据类型。仅当输入数据位于地理数据库中且存在命名冲突（例如，如果地理数据库包含同名的要素数据集和要素类）时需要此项。在这种情况下，数据类型将用于确定要删除的数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DataType { get; set; }

		/// <summary>
		/// <para>Delete Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object OutResults { get; set; } = "false";

	}
}
