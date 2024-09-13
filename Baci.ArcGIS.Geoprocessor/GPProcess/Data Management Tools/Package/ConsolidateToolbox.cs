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
	/// <para>Consolidate Toolbox</para>
	/// <para>合并工具箱</para>
	/// <para>将一个或多个工具箱（.tbx 或 .pyt 文件）合并到指定的输出文件夹中。</para>
	/// </summary>
	public class ConsolidateToolbox : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InToolbox">
		/// <para>Toolbox</para>
		/// <para>要合并的工具箱。</para>
		/// </param>
		/// <param name="OutputFolder">
		/// <para>Output Folder</para>
		/// <para>将包含合并工具箱的输出文件夹。</para>
		/// <para>如果指定的文件夹不存在，将创建一个新文件夹。</para>
		/// </param>
		public ConsolidateToolbox(object InToolbox, object OutputFolder)
		{
			this.InToolbox = InToolbox;
			this.OutputFolder = OutputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 合并工具箱</para>
		/// </summary>
		public override string DisplayName() => "合并工具箱";

		/// <summary>
		/// <para>Tool Name : ConsolidateToolbox</para>
		/// </summary>
		public override string ToolName() => "ConsolidateToolbox";

		/// <summary>
		/// <para>Tool Excute Name : management.ConsolidateToolbox</para>
		/// </summary>
		public override string ExcuteName() => "management.ConsolidateToolbox";

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
		public override object[] Parameters() => new object[] { InToolbox, OutputFolder, Version };

		/// <summary>
		/// <para>Toolbox</para>
		/// <para>要合并的工具箱。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InToolbox { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>将包含合并工具箱的输出文件夹。</para>
		/// <para>如果指定的文件夹不存在，将创建一个新文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Version</para>
		/// <para>指定合并工具箱的版本。指定版本可实现与之前版本的 ArcGIS 共享工具箱，并可支持向后兼容。</para>
		/// <para>当前版本—合并的文件夹将包含与当前版本兼容的工具。这是默认设置。</para>
		/// <para>2.1—合并的文件夹将包含与 2.1 版本兼容的工具。</para>
		/// <para>2.2— 合并的文件夹将包含与 2.2 版本兼容的工具。</para>
		/// <para>2.3—合并的文件夹将包含与 2.3 版本兼容的工具。</para>
		/// <para>2.4—合并的文件夹将包含与 2.4 版本兼容的工具。</para>
		/// <para>2.5—合并的文件夹将包含与 2.5 版本兼容的工具。</para>
		/// <para>2.6—合并的文件夹将包含与 2.6 版本兼容的工具。</para>
		/// <para><see cref="VersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Version { get; set; } = "CURRENT";

		#region InnerClass

		/// <summary>
		/// <para>Version</para>
		/// </summary>
		public enum VersionEnum 
		{
			/// <summary>
			/// <para>当前版本—合并的文件夹将包含与当前版本兼容的工具。这是默认设置。</para>
			/// </summary>
			[GPValue("CURRENT")]
			[Description("当前版本")]
			Current_version,

			/// <summary>
			/// <para>2.1—合并的文件夹将包含与 2.1 版本兼容的工具。</para>
			/// </summary>
			[GPValue("2.1")]
			[Description("2.1")]
			_21,

			/// <summary>
			/// <para>2.2— 合并的文件夹将包含与 2.2 版本兼容的工具。</para>
			/// </summary>
			[GPValue("2.2")]
			[Description("2.2")]
			_22,

			/// <summary>
			/// <para>2.3—合并的文件夹将包含与 2.3 版本兼容的工具。</para>
			/// </summary>
			[GPValue("2.3")]
			[Description("2.3")]
			_23,

			/// <summary>
			/// <para>2.4—合并的文件夹将包含与 2.4 版本兼容的工具。</para>
			/// </summary>
			[GPValue("2.4")]
			[Description("2.4")]
			_24,

			/// <summary>
			/// <para>2.5—合并的文件夹将包含与 2.5 版本兼容的工具。</para>
			/// </summary>
			[GPValue("2.5")]
			[Description("2.5")]
			_25,

			/// <summary>
			/// <para>2.6—合并的文件夹将包含与 2.6 版本兼容的工具。</para>
			/// </summary>
			[GPValue("2.6")]
			[Description("2.6")]
			_26,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("2.7")]
			[Description("2.7")]
			_27,

		}

#endregion
	}
}
