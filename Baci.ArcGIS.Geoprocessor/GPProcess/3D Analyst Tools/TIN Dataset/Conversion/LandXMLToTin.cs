using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>LandXML To TIN</para>
	/// <para>LandXML 转 TIN</para>
	/// <para>此工具将一个或多个不规则三角网 (TIN) 表面从 LandXML 文件导入到输出 Esri TIN。</para>
	/// </summary>
	public class LandXMLToTin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLandxmlPath">
		/// <para>Input</para>
		/// <para>输入 LandXML 文件。</para>
		/// </param>
		/// <param name="OutTinFolder">
		/// <para>Output TIN Folder</para>
		/// <para>将要在其中创建输出 TIN 的文件夹。</para>
		/// </param>
		/// <param name="TinBasename">
		/// <para>Output TIN Base Name</para>
		/// <para>生成的 TIN 的 basename。要从 LandXML 文件中导出多个 TIN 时，basename 用于为各个输出 TIN 定义唯一名称。如果已存在 &lt;basename&gt;，该工具将不会写入任何内容。如果 &lt;basename&gt; 不存在，但 &lt;basename&gt;2 存在，则工具将创建 &lt;basename&gt; 和 &lt;basename&gt;2_1，而不会创建 &lt;basename&gt;2。</para>
		/// </param>
		public LandXMLToTin(object InLandxmlPath, object OutTinFolder, object TinBasename)
		{
			this.InLandxmlPath = InLandxmlPath;
			this.OutTinFolder = OutTinFolder;
			this.TinBasename = TinBasename;
		}

		/// <summary>
		/// <para>Tool Display Name : LandXML 转 TIN</para>
		/// </summary>
		public override string DisplayName() => "LandXML 转 TIN";

		/// <summary>
		/// <para>Tool Name : LandXMLToTin</para>
		/// </summary>
		public override string ToolName() => "LandXMLToTin";

		/// <summary>
		/// <para>Tool Excute Name : 3d.LandXMLToTin</para>
		/// </summary>
		public override string ExcuteName() => "3d.LandXMLToTin";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "tinSaveVersion", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLandxmlPath, OutTinFolder, TinBasename, Tinnames, DerivedTinFolder };

		/// <summary>
		/// <para>Input</para>
		/// <para>输入 LandXML 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("XML")]
		public object InLandxmlPath { get; set; }

		/// <summary>
		/// <para>Output TIN Folder</para>
		/// <para>将要在其中创建输出 TIN 的文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutTinFolder { get; set; }

		/// <summary>
		/// <para>Output TIN Base Name</para>
		/// <para>生成的 TIN 的 basename。要从 LandXML 文件中导出多个 TIN 时，basename 用于为各个输出 TIN 定义唯一名称。如果已存在 &lt;basename&gt;，该工具将不会写入任何内容。如果 &lt;basename&gt; 不存在，但 &lt;basename&gt;2 存在，则工具将创建 &lt;basename&gt; 和 &lt;basename&gt;2_1，而不会创建 &lt;basename&gt;2。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TinBasename { get; set; }

		/// <summary>
		/// <para>TINs to Import</para>
		/// <para>一个或多个 LandXML TIN 表面将导出至一个 Esri TIN 中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Tinnames { get; set; }

		/// <summary>
		/// <para>Updated Output TIN Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object DerivedTinFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LandXMLToTin SetEnviroment(object scratchWorkspace = null , object tinSaveVersion = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, tinSaveVersion: tinSaveVersion, workspace: workspace);
			return this;
		}

	}
}
