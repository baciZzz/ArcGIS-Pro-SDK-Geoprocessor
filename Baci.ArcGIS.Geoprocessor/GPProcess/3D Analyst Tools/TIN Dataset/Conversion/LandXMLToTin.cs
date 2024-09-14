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
	/// <para>LandXML To TIN</para>
	/// <para>This tool imports one or more triangulated irregular network (TIN) surfaces from a LandXML file to output Esri TINs.</para>
	/// </summary>
	public class LandXMLToTin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLandxmlPath">
		/// <para>Input</para>
		/// <para>The input LandXML file.</para>
		/// </param>
		/// <param name="OutTinFolder">
		/// <para>Output TIN Folder</para>
		/// <para>The folder that the output TINs will be created in.</para>
		/// </param>
		/// <param name="TinBasename">
		/// <para>Output TIN Base Name</para>
		/// <para>The basename of the resulting TIN. When several TINs will be exported from the LandXML file, the basename is used to define a unique name for each output TIN. If &lt;basename&gt; already exists, the tool will not write anything. If &lt;basename&gt; does not exist but &lt;basename&gt;2 exists, the tool will create &lt;basename&gt; and &lt;basename&gt;2_1, instead of &lt;basename&gt;2.</para>
		/// </param>
		public LandXMLToTin(object InLandxmlPath, object OutTinFolder, object TinBasename)
		{
			this.InLandxmlPath = InLandxmlPath;
			this.OutTinFolder = OutTinFolder;
			this.TinBasename = TinBasename;
		}

		/// <summary>
		/// <para>Tool Display Name : LandXML To TIN</para>
		/// </summary>
		public override string DisplayName() => "LandXML To TIN";

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
		public override object[] Parameters() => new object[] { InLandxmlPath, OutTinFolder, TinBasename, Tinnames!, DerivedTinFolder! };

		/// <summary>
		/// <para>Input</para>
		/// <para>The input LandXML file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("XML")]
		public object InLandxmlPath { get; set; }

		/// <summary>
		/// <para>Output TIN Folder</para>
		/// <para>The folder that the output TINs will be created in.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutTinFolder { get; set; }

		/// <summary>
		/// <para>Output TIN Base Name</para>
		/// <para>The basename of the resulting TIN. When several TINs will be exported from the LandXML file, the basename is used to define a unique name for each output TIN. If &lt;basename&gt; already exists, the tool will not write anything. If &lt;basename&gt; does not exist but &lt;basename&gt;2 exists, the tool will create &lt;basename&gt; and &lt;basename&gt;2_1, instead of &lt;basename&gt;2.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TinBasename { get; set; }

		/// <summary>
		/// <para>TINs to Import</para>
		/// <para>The one or more LandXML TIN surfaces that will be exported to an Esri TIN.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Tinnames { get; set; }

		/// <summary>
		/// <para>Updated Output TIN Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object? DerivedTinFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LandXMLToTin SetEnviroment(object? scratchWorkspace = null, object? tinSaveVersion = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, tinSaveVersion: tinSaveVersion, workspace: workspace);
			return this;
		}

	}
}
