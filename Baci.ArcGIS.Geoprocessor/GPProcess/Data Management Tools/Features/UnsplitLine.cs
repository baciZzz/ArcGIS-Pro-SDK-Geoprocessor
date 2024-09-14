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
	/// <para>Unsplit Line</para>
	/// <para>取消线分割</para>
	/// <para>用于聚合具有重合端点及公共属性值（可选）的线要素。</para>
	/// </summary>
	public class UnsplitLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要聚合的线要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>要创建的将包含聚合要素的要素类。</para>
		/// </param>
		public UnsplitLine(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 取消线分割</para>
		/// </summary>
		public override string DisplayName() => "取消线分割";

		/// <summary>
		/// <para>Tool Name : UnsplitLine</para>
		/// </summary>
		public override string ToolName() => "UnsplitLine";

		/// <summary>
		/// <para>Tool Excute Name : management.UnsplitLine</para>
		/// </summary>
		public override string ExcuteName() => "management.UnsplitLine";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, DissolveField!, StatisticsFields!, ConcatenationSeparator! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要聚合的线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>要创建的将包含聚合要素的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Dissolve Fields</para>
		/// <para>将进行聚合的要素的一个或多个字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID")]
		public object? DissolveField { get; set; }

		/// <summary>
		/// <para>Statistics Fields</para>
		/// <para>指定包含用于计算指定统计数据的属性值的一个或多个数值字段。 可以指定多项统计和字段组合。 空值将被排除在所有统计计算之外。</para>
		/// <para>可使用第一种和最后一种统计来对文本属性字段进行汇总。 可使用任何一种统计来对数值属性字段进行汇总。</para>
		/// <para>可用统计类型如下：</para>
		/// <para>总和 - 将指定字段的值相加在一起。</para>
		/// <para>平均值 - 将计算指定字段的平均值。</para>
		/// <para>最小值 - 将查找指定字段所有记录的最小值。</para>
		/// <para>最大值 - 将查找指定字段所有记录的最大值。</para>
		/// <para>范围 - 将计算指定字段的值范围（最大值 - 最小值）。</para>
		/// <para>标准差 - 将计算指定字段中值的标准差。</para>
		/// <para>计数 - 将查找统计计算中包括的值的数目。 计数包括除空值外的所有值。 要确定字段中的空值数，请在相应字段上创建计数，然后在另一个不包含空值的字段上创建计数（例如 OID，如果存在的话），然后将这两个值相减。</para>
		/// <para>第一个 - 将使用输入中第一条记录的指定字段值。</para>
		/// <para>最后一个 - 将使用输入中最后一条记录的指定字段值。</para>
		/// <para>中值 - 将计算指定字段所有记录的中值。</para>
		/// <para>方差 - 将计算指定字段所有记录的方差。</para>
		/// <para>唯一值 - 将计算指定字段的唯一值数量。</para>
		/// <para>串连 - 指定字段的值将被串连。 可以使用串连分隔符参数分隔这些值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? StatisticsFields { get; set; }

		/// <summary>
		/// <para>Concatenation Separator</para>
		/// <para>当串连选项用于统计数据字段参数时，将用于串连值的一个或多个字符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ConcatenationSeparator { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UnsplitLine SetEnviroment(object? MDomain = null, double? MResolution = null, double? MTolerance = null, object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, int? autoCommit = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, bool? qualifiedFieldNames = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
