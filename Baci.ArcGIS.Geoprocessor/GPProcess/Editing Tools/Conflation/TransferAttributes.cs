using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.EditingTools
{
	/// <summary>
	/// <para>Transfer Attributes</para>
	/// <para>传递属性</para>
	/// <para>查找源线要素与目标线要素空间上匹配的位置，并将指定属性从源要素传递到互相匹配的目标要素。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class TransferAttributes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="SourceFeatures">
		/// <para>Source Features</para>
		/// <para>传递属性的源线要素。</para>
		/// </param>
		/// <param name="TargetFeatures">
		/// <para>Target Features</para>
		/// <para>传递属性的目标线要素。 指定的传递字段会添加到目标要素。</para>
		/// </param>
		/// <param name="TransferFields">
		/// <para>Transfer Field(s)</para>
		/// <para>要传递至目标要素的源字段列表。 必须至少指定一个字段。</para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>用于搜索匹配候选项的距离。必须指定一个距离，且此距离必须大于零。可以选择首选单位；默认为要素单位。</para>
		/// </param>
		public TransferAttributes(object SourceFeatures, object TargetFeatures, object TransferFields, object SearchDistance)
		{
			this.SourceFeatures = SourceFeatures;
			this.TargetFeatures = TargetFeatures;
			this.TransferFields = TransferFields;
			this.SearchDistance = SearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : 传递属性</para>
		/// </summary>
		public override string DisplayName() => "传递属性";

		/// <summary>
		/// <para>Tool Name : TransferAttributes</para>
		/// </summary>
		public override string ToolName() => "TransferAttributes";

		/// <summary>
		/// <para>Tool Excute Name : edit.TransferAttributes</para>
		/// </summary>
		public override string ExcuteName() => "edit.TransferAttributes";

		/// <summary>
		/// <para>Toolbox Display Name : Editing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Editing Tools";

		/// <summary>
		/// <para>Toolbox Alise : edit</para>
		/// </summary>
		public override string ToolboxAlise() => "edit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { SourceFeatures, TargetFeatures, TransferFields, SearchDistance, MatchFields!, OutMatchTable!, OutFeatureClass!, TransferRuleFields! };

		/// <summary>
		/// <para>Source Features</para>
		/// <para>传递属性的源线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object SourceFeatures { get; set; }

		/// <summary>
		/// <para>Target Features</para>
		/// <para>传递属性的目标线要素。 指定的传递字段会添加到目标要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object TargetFeatures { get; set; }

		/// <summary>
		/// <para>Transfer Field(s)</para>
		/// <para>要传递至目标要素的源字段列表。 必须至少指定一个字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "Blob", "Raster", "XML", "GUID")]
		[ExcludeField("SHAPE_Length", "SHAPE_Area")]
		public object TransferFields { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>用于搜索匹配候选项的距离。必须指定一个距离，且此距离必须大于零。可以选择首选单位；默认为要素单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; }

		/// <summary>
		/// <para>Match Fields</para>
		/// <para>来自源要素与目标要素的字段的列表。如果指定，将检查每对字段中的匹配候选项，以帮助确定正确的匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "Blob", "Raster", "XML", "GUID", "OID")]
		[ExcludeField("SHAPE_Length", "SHAPE_Area")]
		public object? MatchFields { get; set; }

		/// <summary>
		/// <para>Output Match Table</para>
		/// <para>包含完整的要素匹配信息的输出表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutMatchTable { get; set; }

		/// <summary>
		/// <para>Updated Target Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Transfer Rule Field(s)</para>
		/// <para>当多个源要素与目标要素匹配时，设置规则以控制用于将属性传递到目标要素的源要素。 用于传递的源要素由指定的规则字段和规则值确定，按其在指定列表中的显示顺序为其分配从高至低优先级。 如果未指定规则，则将使用多个匹配的源要素中最长的源要素进行传递。</para>
		/// <para>可用规则类型如下：</para>
		/// <para>MIN - 整型或日期型字段的最小值。 对于日期字段，则为最近日期。</para>
		/// <para>MAX - 整型或日期型字段的最大值。 对于日期字段，则为最早日期。</para>
		/// <para>可能存在于源要素中的文本或整数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? TransferRuleFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TransferAttributes SetEnviroment(object? extent = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

	}
}
