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
	/// <para>Export to CAD</para>
	/// <para>导出为 CAD</para>
	/// <para>基于包含在一个或多个输入要素类或要素图层以及支持表中的值，创建一个或多个 CAD 工程图。</para>
	/// </summary>
	public class ExportCAD : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要素类和/或要素图层的集合，其几何图形将导出到一个或多个 CAD 文件。</para>
		/// </param>
		/// <param name="OutputType">
		/// <para>Output Type</para>
		/// <para>输出文件的 CAD 平台以及文件版本。此值将覆盖任何包含于关键名称列或别名列 CADFile_Type 中的 Output_Type 值。</para>
		/// <para>Microstation DGN 文件—Microstation DGN 文件</para>
		/// <para>DWG 2018 版—DWG 2018 版</para>
		/// <para>DWG 2013 版—DWG 2013 版</para>
		/// <para>DWG 2010 版—DWG 2010 版</para>
		/// <para>DWG 2007 版—DWG 2007 版</para>
		/// <para>DWG 2005 版—DWG 2005 版</para>
		/// <para>DWG 2004 版—DWG 2004 版</para>
		/// <para>DWG 2000 版—DWG 2000 版</para>
		/// <para>DWG 14 版—DWG 14 版</para>
		/// <para>DXF 2018 版—DXF 2018 版</para>
		/// <para>DXF 2013 版—DXF 2013 版</para>
		/// <para>DXF 2010 版—DXF 2010 版</para>
		/// <para>DXF 2007 版—DXF 2007 版</para>
		/// <para>DXF 2005 版—DXF 2005 版</para>
		/// <para>DXF 2004 版—DXF 2004 版</para>
		/// <para>DXF 2000 版—DXF 2000 版</para>
		/// <para>DXF 14 版—DXF 14 版</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>所要输出的 CAD 工程图文件的路径。此名称将覆盖任何包括在名为 DrawingPathName 的输入要素列或别名列中的绘图名称信息。</para>
		/// </param>
		public ExportCAD(object InFeatures, object OutputType, object OutputFile)
		{
			this.InFeatures = InFeatures;
			this.OutputType = OutputType;
			this.OutputFile = OutputFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出为 CAD</para>
		/// </summary>
		public override string DisplayName() => "导出为 CAD";

		/// <summary>
		/// <para>Tool Name : ExportCAD</para>
		/// </summary>
		public override string ToolName() => "ExportCAD";

		/// <summary>
		/// <para>Tool Excute Name : conversion.ExportCAD</para>
		/// </summary>
		public override string ExcuteName() => "conversion.ExportCAD";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutputType, OutputFile, IgnoreFilenames, AppendToExisting, SeedFile };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要素类和/或要素图层的集合，其几何图形将导出到一个或多个 CAD 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon", "Point", "MultiPatch")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Type</para>
		/// <para>输出文件的 CAD 平台以及文件版本。此值将覆盖任何包含于关键名称列或别名列 CADFile_Type 中的 Output_Type 值。</para>
		/// <para>Microstation DGN 文件—Microstation DGN 文件</para>
		/// <para>DWG 2018 版—DWG 2018 版</para>
		/// <para>DWG 2013 版—DWG 2013 版</para>
		/// <para>DWG 2010 版—DWG 2010 版</para>
		/// <para>DWG 2007 版—DWG 2007 版</para>
		/// <para>DWG 2005 版—DWG 2005 版</para>
		/// <para>DWG 2004 版—DWG 2004 版</para>
		/// <para>DWG 2000 版—DWG 2000 版</para>
		/// <para>DWG 14 版—DWG 14 版</para>
		/// <para>DXF 2018 版—DXF 2018 版</para>
		/// <para>DXF 2013 版—DXF 2013 版</para>
		/// <para>DXF 2010 版—DXF 2010 版</para>
		/// <para>DXF 2007 版—DXF 2007 版</para>
		/// <para>DXF 2005 版—DXF 2005 版</para>
		/// <para>DXF 2004 版—DXF 2004 版</para>
		/// <para>DXF 2000 版—DXF 2000 版</para>
		/// <para>DXF 14 版—DXF 14 版</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputType { get; set; } = "DWG_R2018";

		/// <summary>
		/// <para>Output File</para>
		/// <para>所要输出的 CAD 工程图文件的路径。此名称将覆盖任何包括在名为 DrawingPathName 的输入要素列或别名列中的绘图名称信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DECadDrawingDataset()]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Ignore Paths in Tables</para>
		/// <para>指定该功能将忽略还是使用 DrawingPathName 中的路径。这样，该功能便可将 CAD 实体输出到特定的绘图中，或者忽略此参数并将 CAD 实体添加到一个 CAD 文件。</para>
		/// <para>已选中 - 将忽略文档实体字段中的路径，并将所有实体的输出添加到单个 CAD 文件。这是默认设置。</para>
		/// <para>未选中 - 将使用文档实体字段中的路径和每个实体的路径，以使每个 CAD 部分写入单独文件。</para>
		/// <para><see cref="IgnoreFilenamesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IgnoreFilenames { get; set; } = "true";

		/// <summary>
		/// <para>Append to Existing Files</para>
		/// <para>指定是否将输出追加到现有 CAD 文件。这样，您便可以将信息添加到磁盘上的 CAD 文件。</para>
		/// <para>已选中 - 输出文件内容将添加到现有 CAD 输出文件。现有 CAD 文件内容不会丢失。</para>
		/// <para>未选中 - 输出文件内容将覆盖现有 CAD 文件内容。这是默认设置。</para>
		/// <para><see cref="AppendToExistingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AppendToExisting { get; set; } = "false";

		/// <summary>
		/// <para>Seed File</para>
		/// <para>现有 CAD 工程图，其内容以及文档和图层属性将用于所有新建 CAD 输出文件。种子文件的 CAD 平台及格式版本会覆盖输出类型参数所指定的值。如果追加到现有 CAD 文件，则会忽略种子绘图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DECadDrawingDataset()]
		public object SeedFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportCAD SetEnviroment(object extent = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Ignore Paths in Tables</para>
		/// </summary>
		public enum IgnoreFilenamesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("Ignore_Filenames_in_Tables")]
			Ignore_Filenames_in_Tables,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("Use_Filenames_in_Tables")]
			Use_Filenames_in_Tables,

		}

		/// <summary>
		/// <para>Append to Existing Files</para>
		/// </summary>
		public enum AppendToExistingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("Append_To_Existing_Files")]
			Append_To_Existing_Files,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("Overwrite_Existing_Files")]
			Overwrite_Existing_Files,

		}

#endregion
	}
}
