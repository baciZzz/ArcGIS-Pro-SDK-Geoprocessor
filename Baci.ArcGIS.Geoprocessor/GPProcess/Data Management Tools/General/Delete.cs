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
	/// <para>Delete</para>
	/// <para>Permanently deletes data from disk. All types of geographic data supported by ArcGIS, as well as toolboxes and workspaces (folders and geodatabases), can be deleted. If the specified item is a workspace, all contained items are also deleted.</para>
	/// </summary>
	public class Delete : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input Data Element</para>
		/// <para>The input data to be deleted.</para>
		/// </param>
		public Delete(object InData)
		{
			this.InData = InData;
		}

		/// <summary>
		/// <para>Tool Display Name : Delete</para>
		/// </summary>
		public override string DisplayName() => "Delete";

		/// <summary>
		/// <para>Tool Name : Delete</para>
		/// </summary>
		public override string ToolName() => "Delete";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InData, DataType!, OutResults! };

		/// <summary>
		/// <para>Input Data Element</para>
		/// <para>The input data to be deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Data type</para>
		/// <para>The type of data on disk to be deleted. This is only necessary when the input data is in a geodatabase and naming conflicts exist, for example, if the geodatabase contains a feature dataset and a feature class with the same name. In this case, the data type is used to clarify which dataset to delete.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DataType { get; set; }

		/// <summary>
		/// <para>Delete Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? OutResults { get; set; } = "false";

	}
}
