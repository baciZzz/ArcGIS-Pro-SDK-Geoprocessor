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
	/// <para>Dissolve Boundaries</para>
	/// <para>融合边界</para>
	/// <para>查找重叠或共用公共边界的面，然后将其合并到一起以形成一个单个面。</para>
	/// </summary>
	public class DissolveBoundaries : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputlayer">
		/// <para>Input Layer</para>
		/// <para>包含将进行融合或组合的面要素的图层。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>要在门户中创建的输出图层的名称。</para>
		/// </param>
		public DissolveBoundaries(object Inputlayer, object Outputname)
		{
			this.Inputlayer = Inputlayer;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : 融合边界</para>
		/// </summary>
		public override string DisplayName() => "融合边界";

		/// <summary>
		/// <para>Tool Name : DissolveBoundaries</para>
		/// </summary>
		public override string ToolName() => "DissolveBoundaries";

		/// <summary>
		/// <para>Tool Excute Name : sfa.DissolveBoundaries</para>
		/// </summary>
		public override string ExcuteName() => "sfa.DissolveBoundaries";

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
		public override object[] Parameters() => new object[] { Inputlayer, Outputname, Dissolvefields, Summaryfields, Output };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>包含将进行融合或组合的面要素的图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Inputlayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>要在门户中创建的输出图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Dissolve Fields</para>
		/// <para>输入图层中控制要合并的面的一个或多个字段。如果您不提供融合字段，则共用公共边界的面（也就是说它们是相邻的）或重叠的面区域将会被融合为一个面。</para>
		/// <para>如果您不提供字段，则共用公共边界以及在一个或多个字段中包含相同值的面将被融合。例如，如果有一个县图层，并且每个县都具有 State_Name 属性，则可以使用 State_Name 属性来融合边界。如果相邻的县具有相同的 State_Name 值，则将它们合并到一起。最终结果是一个州边界图层。如果指定了两个或多个字段，则这些字段中的值必须相同才能融合边界。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object Dissolvefields { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>字段名称及您想要为各面内全部点计算的统计汇总类型的列表。始终返回每个面内的点计数。支持的统计数据类型如下：</para>
		/// <para>Sum - 总值。</para>
		/// <para>Minimum - 最小值。</para>
		/// <para>Max - 最大值。</para>
		/// <para>Mean - 平均值。</para>
		/// <para>Standard deviation - 标准差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Summaryfields { get; set; }

		/// <summary>
		/// <para>Output</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DissolveBoundaries SetEnviroment(object extent = null)
		{
			base.SetEnv(extent: extent);
			return this;
		}

	}
}
