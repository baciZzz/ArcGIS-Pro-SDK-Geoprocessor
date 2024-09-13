using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>KML To Layer</para>
	/// <para>KML 转图层</para>
	/// <para>将 KML 或 KMZ 文件转换为要素类和图层文件。图层文件用于保留于原始 KML 或 KMZ 文件中找到的符号。</para>
	/// </summary>
	public class KMLToLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InKmlFile">
		/// <para>Input KML File</para>
		/// <para>要转换的 KML 或 KMZ 文件。</para>
		/// </param>
		/// <param name="OutputFolder">
		/// <para>Output Location</para>
		/// <para>文件地理数据库与图层 (.lyrx) 文件的目标文件夹。</para>
		/// </param>
		public KMLToLayer(object InKmlFile, object OutputFolder)
		{
			this.InKmlFile = InKmlFile;
			this.OutputFolder = OutputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : KML 转图层</para>
		/// </summary>
		public override string DisplayName() => "KML 转图层";

		/// <summary>
		/// <para>Tool Name : KMLToLayer</para>
		/// </summary>
		public override string ToolName() => "KMLToLayer";

		/// <summary>
		/// <para>Tool Excute Name : conversion.KMLToLayer</para>
		/// </summary>
		public override string ExcuteName() => "conversion.KMLToLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InKmlFile, OutputFolder, OutputData, IncludeGroundoverlay, OutputLayer, OutGeodatabase };

		/// <summary>
		/// <para>Input KML File</para>
		/// <para>要转换的 KML 或 KMZ 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InKmlFile { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>文件地理数据库与图层 (.lyrx) 文件的目标文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Output Data Name</para>
		/// <para>输出文件地理数据库和图层文件的名称。默认为输入 KML 文件的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object OutputData { get; set; }

		/// <summary>
		/// <para>Include Ground Overlay</para>
		/// <para>包括 KML 的地面叠加层（栅格、航空照片等）。KMZ 指向提供栅格影像的服务时，请谨慎使用。该工具将尝试按所有可用比例转换栅格影像。此过程也许会较漫长且可能超出服务能力范围。</para>
		/// <para>选中 - 地面叠加层包括在输出中。</para>
		/// <para>未选中 - 地面叠加层不包括在输出中。这是默认设置。</para>
		/// <para><see cref="IncludeGroundoverlayEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeGroundoverlay { get; set; } = "false";

		/// <summary>
		/// <para>Output Layer File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPGroupLayer()]
		public object OutputLayer { get; set; }

		/// <summary>
		/// <para>Output File Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutGeodatabase { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public KMLToLayer SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Include Ground Overlay</para>
		/// </summary>
		public enum IncludeGroundoverlayEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("GROUNDOVERLAY")]
			GROUNDOVERLAY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_GROUNDOVERLAY")]
			NO_GROUNDOVERLAY,

		}

#endregion
	}
}
