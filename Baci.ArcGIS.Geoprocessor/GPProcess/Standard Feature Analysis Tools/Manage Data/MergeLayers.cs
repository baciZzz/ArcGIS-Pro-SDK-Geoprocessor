using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.StandardFeatureAnalysisTools
{
	/// <summary>
	/// <para>Merge Layers</para>
	/// <para>合并图层</para>
	/// <para>将两个图层的所有要素复制到一个新图层中。要合并的图层必须包含相同的要素类型（点、线或面）。您可以控制输入图层中各字段的连接和复制方式。</para>
	/// </summary>
	public class MergeLayers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputlayer">
		/// <para>Input Layer</para>
		/// <para>将与合并图层进行合并的点、线或面要素。</para>
		/// </param>
		/// <param name="Mergelayer">
		/// <para>Merge Layer</para>
		/// <para>将与输入图层进行合并的点、线或面要素。合并图层必须包含与输入图层相同的要素类型（点、线或面）。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>要在门户中创建的输出图层的名称。</para>
		/// </param>
		public MergeLayers(object Inputlayer, object Mergelayer, object Outputname)
		{
			this.Inputlayer = Inputlayer;
			this.Mergelayer = Mergelayer;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : 合并图层</para>
		/// </summary>
		public override string DisplayName() => "合并图层";

		/// <summary>
		/// <para>Tool Name : MergeLayers</para>
		/// </summary>
		public override string ToolName() => "MergeLayers";

		/// <summary>
		/// <para>Tool Excute Name : sfa.MergeLayers</para>
		/// </summary>
		public override string ExcuteName() => "sfa.MergeLayers";

		/// <summary>
		/// <para>Toolbox Display Name : Standard Feature Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Standard Feature Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : sfa</para>
		/// </summary>
		public override string ToolboxAlise() => "sfa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputlayer, Mergelayer, Outputname, Mergingattributes, Output };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>将与合并图层进行合并的点、线或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Inputlayer { get; set; }

		/// <summary>
		/// <para>Merge Layer</para>
		/// <para>将与输入图层进行合并的点、线或面要素。合并图层必须包含与输入图层相同的要素类型（点、线或面）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Mergelayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>要在门户中创建的输出图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Merging Attributes</para>
		/// <para>用于描述如何修改合并图层中的字段并将其与输入图层中的字段相匹配的值列表。默认情况下，两个输入图层的所有字段都会传递到输出图层中。</para>
		/// <para>如果某个字段存在于一个图层中但不存在于另一个图层中，则输出图层将包含这两个字段。对于不含该字段的输入要素，输出字段中将包含空值。例如，如果输入图层中含有名为 TYPE 的字段，但合并图层中不含有 TYPE，则输出图层中将含有 TYPE，但从合并图层复制的所有要素的 TYPE 值均将为空。</para>
		/// <para>您可以控制以下合并操作（将合并图层上的字段写入输出图层的方式）。</para>
		/// <para>移除 - 合并图层字段将从输出图层中移除。</para>
		/// <para>重命名 - 合并图层字段将在输出中重命名。您无法将合并图层中的字段重命名为输入图层中的字段。如果您希望使字段名保持不变，请使用匹配选项。</para>
		/// <para>匹配 - 系统将重命名合并图层字段并使其与输入图层中的字段进行匹配。例如，输入图层中具有名为 CODE 的字段，同时合并图层中具有名为 STATUS 的字段。可将 STATUS 与 CODE 进行匹配，随后输出中将包含 CODE 字段，其中含有从合并图层复制的要素所用的 STATUS 字段值。系统支持类型转换（例如双精度型至整型、整型至字符串型），字符串型至数字型的转换除外。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Mergingattributes { get; set; }

		/// <summary>
		/// <para>Output</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MergeLayers SetEnviroment(object extent = null )
		{
			base.SetEnv(extent: extent);
			return this;
		}

	}
}
