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
	/// <para>Save To Layer File</para>
	/// <para>Save To Layer File</para>
	/// <para>Creates an output layer file (.lyrx) from a map layer. The layer file stores many properties of the input layer such as symbology, labeling, and custom pop-ups. Layer files saved from ArcGIS Pro cannot be used in ArcMap.</para>
	/// </summary>
	public class SaveToLayerFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayer">
		/// <para>Input Layer</para>
		/// <para>The map layer to be saved to disk as a layer file.</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Layer</para>
		/// <para>The output layer file (.lyrx) to be created.</para>
		/// </param>
		public SaveToLayerFile(object InLayer, object OutLayer)
		{
			this.InLayer = InLayer;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Save To Layer File</para>
		/// </summary>
		public override string DisplayName() => "Save To Layer File";

		/// <summary>
		/// <para>Tool Name : SaveToLayerFile</para>
		/// </summary>
		public override string ToolName() => "SaveToLayerFile";

		/// <summary>
		/// <para>Tool Excute Name : management.SaveToLayerFile</para>
		/// </summary>
		public override string ExcuteName() => "management.SaveToLayerFile";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLayer, OutLayer, IsRelativePath, Version };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The map layer to be saved to disk as a layer file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		public object InLayer { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>The output layer file (.lyrx) to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DELayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Store Relative Path</para>
		/// <para>Determines if the output layer file will store a relative path to the source data stored on disk, or an absolute path.</para>
		/// <para>Unchecked—The output layer file will store an absolute path to the source data stored on disk. This is the default.</para>
		/// <para>Checked—The output layer file will store a relative path to the source data stored on disk. If the output layer file is moved, its source path will update to where the source data should be in relation to the new path.</para>
		/// <para><see cref="IsRelativePathEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsRelativePath { get; set; }

		/// <summary>
		/// <para>Layer Version</para>
		/// <para>The version of the output layer file.</para>
		/// <para>Current—The current version. This is the default.</para>
		/// <para><see cref="VersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Version { get; set; } = "CURRENT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SaveToLayerFile SetEnviroment(object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Store Relative Path</para>
		/// </summary>
		public enum IsRelativePathEnum 
		{
			/// <summary>
			/// <para>Checked—The output layer file will store a relative path to the source data stored on disk. If the output layer file is moved, its source path will update to where the source data should be in relation to the new path.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RELATIVE")]
			RELATIVE,

			/// <summary>
			/// <para>Unchecked—The output layer file will store an absolute path to the source data stored on disk. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ABSOLUTE")]
			ABSOLUTE,

		}

		/// <summary>
		/// <para>Layer Version</para>
		/// </summary>
		public enum VersionEnum 
		{
			/// <summary>
			/// <para>Current—The current version. This is the default.</para>
			/// </summary>
			[GPValue("CURRENT")]
			[Description("Current")]
			Current,

		}

#endregion
	}
}
