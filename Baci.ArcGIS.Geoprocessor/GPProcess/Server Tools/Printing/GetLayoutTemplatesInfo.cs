using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ServerTools
{
	/// <summary>
	/// <para>Get Layout Templates Info</para>
	/// <para>Returns the content</para>
	/// <para>of layout templates in JavaScript Object Notation</para>
	/// <para>(JSON) format. Layout files (.pagx files) located in a folder are used as layout templates.</para>
	/// </summary>
	public class GetLayoutTemplatesInfo : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		public GetLayoutTemplatesInfo()
		{
		}

		/// <summary>
		/// <para>Tool Display Name : Get Layout Templates Info</para>
		/// </summary>
		public override string DisplayName => "Get Layout Templates Info";

		/// <summary>
		/// <para>Tool Name : GetLayoutTemplatesInfo</para>
		/// </summary>
		public override string ToolName => "GetLayoutTemplatesInfo";

		/// <summary>
		/// <para>Tool Excute Name : server.GetLayoutTemplatesInfo</para>
		/// </summary>
		public override string ExcuteName => "server.GetLayoutTemplatesInfo";

		/// <summary>
		/// <para>Toolbox Display Name : Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : server</para>
		/// </summary>
		public override string ToolboxAlise => "server";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { LayoutTemplatesFolder!, OutputJSON! };

		/// <summary>
		/// <para>Layout Templates Folder</para>
		/// <para>Full path to the folder where layout files (.pagx files), to be used as layout templates, are located. The default location is <install_directory>\Resources\ArcToolBox\Templates\ExportWebMapTemplates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object? LayoutTemplatesFolder { get; set; }

		/// <summary>
		/// <para>JSON String</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutputJSON { get; set; }

	}
}
