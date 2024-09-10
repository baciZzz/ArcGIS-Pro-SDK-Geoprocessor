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
	/// <para>Create Mobile Geodatabase</para>
	/// <para>Creates a mobile geodatabase.</para>
	/// </summary>
	public class CreateMobileGDB : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutFolderPath">
		/// <para>Mobile Geodatabase Location</para>
		/// <para>The folder where the mobile geodatabase will be created.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Mobile Geodatabase Name</para>
		/// <para>The name of the mobile geodatabase to be created.</para>
		/// </param>
		public CreateMobileGDB(object OutFolderPath, object OutName)
		{
			this.OutFolderPath = OutFolderPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Mobile Geodatabase</para>
		/// </summary>
		public override string DisplayName() => "Create Mobile Geodatabase";

		/// <summary>
		/// <para>Tool Name : CreateMobileGDB</para>
		/// </summary>
		public override string ToolName() => "CreateMobileGDB";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateMobileGDB</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateMobileGDB";

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
		public override object[] Parameters() => new object[] { OutFolderPath, OutName, OutGdb };

		/// <summary>
		/// <para>Mobile Geodatabase Location</para>
		/// <para>The folder where the mobile geodatabase will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolderPath { get; set; }

		/// <summary>
		/// <para>Mobile Geodatabase Name</para>
		/// <para>The name of the mobile geodatabase to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Output Mobile Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutGdb { get; set; }

	}
}
