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
	/// <para>保存至图层文件</para>
	/// <para>从地图图层中创建输出图层文件 (.lyrx)。图层文件可存储很多输入图层的属性，例如：符号系统、标注和自定义弹出窗口。不能在 ArcMap 中使用从 ArcGIS Pro 中保存的图层文件。</para>
	/// </summary>
	public class SaveToLayerFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayer">
		/// <para>Input Layer</para>
		/// <para>要作为图层文件保存到磁盘上的地图图层。</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Layer</para>
		/// <para>要创建的输出图层文件 (.lyrx)。</para>
		/// </param>
		public SaveToLayerFile(object InLayer, object OutLayer)
		{
			this.InLayer = InLayer;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 保存至图层文件</para>
		/// </summary>
		public override string DisplayName() => "保存至图层文件";

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
		public override object[] Parameters() => new object[] { InLayer, OutLayer, IsRelativePath!, Version! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>要作为图层文件保存到磁盘上的地图图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		public object InLayer { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>要创建的输出图层文件 (.lyrx)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DELayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Store Relative Path</para>
		/// <para>确定输出图层文件是存储磁盘上源数据的相对路径还是绝对路径。</para>
		/// <para>取消选中 - 输出图层文件将存储磁盘上源数据的绝对路径。这是默认设置。</para>
		/// <para>已选中 - 输出图层文件将存储磁盘上源数据的相对路径。如果输出图层文件被移动，则其源路径将更新为源数据相对于新路径应处的位置。</para>
		/// <para><see cref="IsRelativePathEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IsRelativePath { get; set; }

		/// <summary>
		/// <para>Layer Version</para>
		/// <para>输出图层文件的版本。</para>
		/// <para>当前—当前版本。这是默认设置。</para>
		/// <para><see cref="VersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Version { get; set; } = "CURRENT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SaveToLayerFile SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RELATIVE")]
			RELATIVE,

			/// <summary>
			/// <para></para>
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
			/// <para>当前—当前版本。这是默认设置。</para>
			/// </summary>
			[GPValue("CURRENT")]
			[Description("当前")]
			Current,

		}

#endregion
	}
}
