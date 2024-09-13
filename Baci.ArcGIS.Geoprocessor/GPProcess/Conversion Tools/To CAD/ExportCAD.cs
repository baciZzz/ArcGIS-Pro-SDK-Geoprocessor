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
	/// <para>根据一个或多个输入要素图层或要素类将要素导出到新的或现有的 CAD 文件。</para>
	/// </summary>
	public class ExportCAD : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>其空间参考和几何将导出到一个或多个 CAD 文件的要素类和要素图层的集合。 要素几何和要素属性都将添加到 AutoCAD 格式的文件中。</para>
		/// </param>
		/// <param name="OutputType">
		/// <para>Output Type</para>
		/// <para>指定将用于新输出 CAD 文件的 CAD 平台和文件版本。 多个版本的 CAD 软件可能会为多个版本共享一种文件格式版本。 选择将指定文件格式版本，该版本不一定是可能仍使用以前文件格式版本的软件版本。</para>
		/// <para>Microstation DGN 文件—输出类型将为 Microstation DGN。</para>
		/// <para>DWG 2018 版—输出类型将为 DWG 2018 版。 这是默认设置。</para>
		/// <para>DWG 2013 版—输出类型将为 DWG 2013 版。</para>
		/// <para>DWG 2010 版—输出类型将为 DWG 2010 版。</para>
		/// <para>DWG 2007 版—输出类型将为 DWG 2007 版。</para>
		/// <para>DWG 2005 版—输出类型将为 DWG 2005 版。</para>
		/// <para>DWG 2004 版—输出类型将为 DWG 2004 版。</para>
		/// <para>DWG 2000 版—输出类型将为 DWG 2000 版。</para>
		/// <para>DWG 14 版—输出类型将为 DWG 14 版。</para>
		/// <para>DXF 2018 版—输出类型将为 DXF 2018 版。</para>
		/// <para>DXF 2013 版—输出类型将为 DXF 2013 版。</para>
		/// <para>DXF 2010 版—输出类型将为 DXF 2010 版。</para>
		/// <para>DXF 2007 版—输出类型将为 DXF 2007 版。</para>
		/// <para>DXF 2005 版—输出类型将为 DXF 2005 版。</para>
		/// <para>DXF 2004 版—输出类型将为 DXF 2004 版。</para>
		/// <para>DXF 2000 版—输出类型将为 DXF 2000 版。</para>
		/// <para>DXF 14 版—输出类型将为 DXF 14 版。</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>输出的 CAD 工程图文件的路径。 除非选中了忽略表中的路径参数，否则此路径将被作为字段值包含在输入要素字段或名为 DocPath 的别名字段中的任何有效文件路径覆盖。</para>
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
		public override object[] Parameters() => new object[] { InFeatures, OutputType, OutputFile, IgnoreFilenames!, AppendToExisting!, SeedFile! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>其空间参考和几何将导出到一个或多个 CAD 文件的要素类和要素图层的集合。 要素几何和要素属性都将添加到 AutoCAD 格式的文件中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon", "Point", "MultiPatch")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Type</para>
		/// <para>指定将用于新输出 CAD 文件的 CAD 平台和文件版本。 多个版本的 CAD 软件可能会为多个版本共享一种文件格式版本。 选择将指定文件格式版本，该版本不一定是可能仍使用以前文件格式版本的软件版本。</para>
		/// <para>Microstation DGN 文件—输出类型将为 Microstation DGN。</para>
		/// <para>DWG 2018 版—输出类型将为 DWG 2018 版。 这是默认设置。</para>
		/// <para>DWG 2013 版—输出类型将为 DWG 2013 版。</para>
		/// <para>DWG 2010 版—输出类型将为 DWG 2010 版。</para>
		/// <para>DWG 2007 版—输出类型将为 DWG 2007 版。</para>
		/// <para>DWG 2005 版—输出类型将为 DWG 2005 版。</para>
		/// <para>DWG 2004 版—输出类型将为 DWG 2004 版。</para>
		/// <para>DWG 2000 版—输出类型将为 DWG 2000 版。</para>
		/// <para>DWG 14 版—输出类型将为 DWG 14 版。</para>
		/// <para>DXF 2018 版—输出类型将为 DXF 2018 版。</para>
		/// <para>DXF 2013 版—输出类型将为 DXF 2013 版。</para>
		/// <para>DXF 2010 版—输出类型将为 DXF 2010 版。</para>
		/// <para>DXF 2007 版—输出类型将为 DXF 2007 版。</para>
		/// <para>DXF 2005 版—输出类型将为 DXF 2005 版。</para>
		/// <para>DXF 2004 版—输出类型将为 DXF 2004 版。</para>
		/// <para>DXF 2000 版—输出类型将为 DXF 2000 版。</para>
		/// <para>DXF 14 版—输出类型将为 DXF 14 版。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputType { get; set; } = "DWG_R2018";

		/// <summary>
		/// <para>Output File</para>
		/// <para>输出的 CAD 工程图文件的路径。 除非选中了忽略表中的路径参数，否则此路径将被作为字段值包含在输入要素字段或名为 DocPath 的别名字段中的任何有效文件路径覆盖。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DECadDrawingDataset()]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Ignore Paths in Tables</para>
		/// <para>指定是否忽略输入要素 DocPath 字段中包含的有效路径。</para>
		/// <para>选中 - 将忽略有效路径，并将所有实体的输出添加到输出文件参数值中。 这是默认设置。</para>
		/// <para>未选中 - 将使用有效路径，以便将每个新 CAD 实体写入由该字段值指定的文件。</para>
		/// <para><see cref="IgnoreFilenamesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreFilenames { get; set; } = "true";

		/// <summary>
		/// <para>Append to Existing Files</para>
		/// <para>指定实体是否将追加到现有的输出 CAD 文件，或由输出文件参数指定的 CAD 文件或根据忽略表中的路径参数包含在 DocPath 字段值中的任何有效文件路径将被覆盖。</para>
		/// <para>选中 - 实体将被追加到输出 CAD 文件（如果存在）。 现有 CAD 文件内容将被保留。</para>
		/// <para>未选中 - 如果存在输出 CAD 文件，它将被覆盖。 这是默认设置。</para>
		/// <para><see cref="AppendToExistingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AppendToExisting { get; set; } = "false";

		/// <summary>
		/// <para>Seed File</para>
		/// <para>创建输出 CAD 文件时，现有 CAD 工程图的内容以及文档和图层属性将用作种子文件。 种子文件的 CAD 平台及格式版本会覆盖输出类型参数所指定的值。 如果追加到现有 CAD 文件，则种子图将被忽略。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DECadDrawingDataset()]
		public object? SeedFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportCAD SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? workspace = null )
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
