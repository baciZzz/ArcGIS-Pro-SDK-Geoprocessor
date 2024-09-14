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
	/// <para>获取布局模板信息</para>
	/// <para>以 JavaScript 对象表示法 (JSON) 格式返回布局模板的内容。位于文件夹中的布局文件（.pagx 文件）被用作布局模板。</para>
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
		/// <para>Tool Display Name : 获取布局模板信息</para>
		/// </summary>
		public override string DisplayName() => "获取布局模板信息";

		/// <summary>
		/// <para>Tool Name : GetLayoutTemplatesInfo</para>
		/// </summary>
		public override string ToolName() => "GetLayoutTemplatesInfo";

		/// <summary>
		/// <para>Tool Excute Name : server.GetLayoutTemplatesInfo</para>
		/// </summary>
		public override string ExcuteName() => "server.GetLayoutTemplatesInfo";

		/// <summary>
		/// <para>Toolbox Display Name : Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : server</para>
		/// </summary>
		public override string ToolboxAlise() => "server";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { LayoutTemplatesFolder, OutputJSON };

		/// <summary>
		/// <para>Layout Templates Folder</para>
		/// <para>用作布局模板的布局文件（.pagx 文件）所在的文件夹的完整路径。默认位置为 &lt;install_directory&gt;\Resources\ArcToolBox\Templates\ExportWebMapTemplates。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object LayoutTemplatesFolder { get; set; }

		/// <summary>
		/// <para>JSON String</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutputJSON { get; set; }

	}
}
