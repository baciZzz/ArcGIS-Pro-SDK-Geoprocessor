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
	/// <para>Copy</para>
	/// <para>Makes a copy of the input data.</para>
	/// </summary>
	[Obsolete()]
	public class Copy : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input Data</para>
		/// <para>The data to be copied.</para>
		/// </param>
		/// <param name="OutData">
		/// <para>Output Data</para>
		/// <para>The location and name of the output data.</para>
		/// </param>
		public Copy(object InData, object OutData)
		{
			this.InData = InData;
			this.OutData = OutData;
		}

		/// <summary>
		/// <para>Tool Display Name : Copy</para>
		/// </summary>
		public override string DisplayName() => "Copy";

		/// <summary>
		/// <para>Tool Name : Copy</para>
		/// </summary>
		public override string ToolName() => "Copy";

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
		/// <para>The data to be copied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEType()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Output Data</para>
		/// <para>The location and name of the output data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEType()]
		public object OutData { get; set; }

		/// <summary>
		/// <para>Data type</para>
		/// <para>The type of the data on disk to be copied. This is only necessary when the input data is in a geodatabase and naming conflicts exist, for example, if the geodatabase contains a feature dataset and a feature class with the same name. In this case, the data type is used to clarify which dataset you want to copy.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DataType { get; set; }

		/// <summary>
		/// <para>Associated Data</para>
		/// <para>When the input has associated data, this parameter can be used to control the associated output data&apos;s name and config keyword.</para>
		/// <para>From Name—Data associated with the input data, which will also be copied.</para>
		/// <para>Data Type—The type of the data on disk to be copied. The only time you need to provide a value is when a geodatabase contains a feature dataset and a feature class with the same name. In this case, you need to select the data type, FeatureDataset or FeatureClass, of the item you want to copy.</para>
		/// <para>To Name—The name of the copied data in the Output Data parameter value.</para>
		/// <para>Config Keyword—The geodatabase storage parameters (configuration).</para>
		/// <para>The From Name and To Name column names will be identical if the To Name value is not already used in Output Data. If a name already exists in the Output Data value, a unique To Name value will be created by appending an underscore plus a number (for example, rivers_1).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? AssociatedData { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Copy SetEnviroment(object? configKeyword = null , bool? maintainAttachments = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, maintainAttachments: maintainAttachments, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
