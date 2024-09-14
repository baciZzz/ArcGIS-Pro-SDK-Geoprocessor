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
	/// <para>Upgrade Scene Layer</para>
	/// <para>Upgrade Scene Layer</para>
	/// <para>Upgrades a scene layer package to the current I3S version in SLPK format or output to i3sREST format for use in ArcGIS Enterprise.</para>
	/// </summary>
	public class UpgradeSceneLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>The input scene layer package.</para>
		/// </param>
		/// <param name="OutFolderPath">
		/// <para>Output Folder</para>
		/// <para>The location where the output scene layer package will be created, or the cloud connection file (.acs) to output to i3sREST.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Output Name</para>
		/// <para>The name of the output scene layer.</para>
		/// </param>
		public UpgradeSceneLayer(object InDataset, object OutFolderPath, object OutName)
		{
			this.InDataset = InDataset;
			this.OutFolderPath = OutFolderPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : Upgrade Scene Layer</para>
		/// </summary>
		public override string DisplayName() => "Upgrade Scene Layer";

		/// <summary>
		/// <para>Tool Name : UpgradeSceneLayer</para>
		/// </summary>
		public override string ToolName() => "UpgradeSceneLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.UpgradeSceneLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.UpgradeSceneLayer";

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
		public override object[] Parameters() => new object[] { InDataset, OutFolderPath, OutName, OutLog, TextureOptimization };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>The input scene layer package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("SLPK", "SPK")]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>The location where the output scene layer package will be created, or the cloud connection file (.acs) to output to i3sREST.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolderPath { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output scene layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Output Log File</para>
		/// <para>The output log file that will summarize the results of the evaluation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("json")]
		public object OutLog { get; set; }

		/// <summary>
		/// <para>Texture Optimization</para>
		/// <para>Specifies the textures that will be optimized according to the target platform where the scene layer package is used. Desktop includes Windows, Linux, and Mac platforms.</para>
		/// <para>Desktop—Texture formats will be optimized for use in desktop and web platforms. Texture formats will be JPEG and DXT. This is the default.</para>
		/// <para>None—Textures formats will be optimized for use in a desktop platform. The texture format will be JPEG.</para>
		/// <para><see cref="TextureOptimizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TextureOptimization { get; set; } = "DESKTOP";

		#region InnerClass

		/// <summary>
		/// <para>Texture Optimization</para>
		/// </summary>
		public enum TextureOptimizationEnum 
		{
			/// <summary>
			/// <para>Desktop—Texture formats will be optimized for use in desktop and web platforms. Texture formats will be JPEG and DXT. This is the default.</para>
			/// </summary>
			[GPValue("DESKTOP")]
			[Description("Desktop")]
			Desktop,

			/// <summary>
			/// <para>None—Textures formats will be optimized for use in a desktop platform. The texture format will be JPEG.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

		}

#endregion
	}
}
