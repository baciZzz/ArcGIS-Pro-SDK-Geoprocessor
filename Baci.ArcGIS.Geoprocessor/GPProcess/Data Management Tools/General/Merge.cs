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
	/// <para>Merge</para>
	/// <para>合并</para>
	/// <para>可将多个输入数据集合并为新的单个输出数据集。 此工具可合并点、线或面要素类或者表。</para>
	/// </summary>
	[Obsolete()]
	public class Merge : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputs">
		/// <para>Input Datasets</para>
		/// <para>要合并为新的输出数据集的输入数据集。 输入数据集可为点、线或面要素类或表。 输入要素类必须全部具有相同的几何类型。</para>
		/// <para>表和要素类可在单一输出数据集中合并。 输出类型由第一个输入确定。 如果第一个输入是要素类，则输出将是要素类，如果第一个输入是表，则输出将是表。 如果将表合并到要素类中，则输入表中的行将具有空几何。</para>
		/// </param>
		/// <param name="Output">
		/// <para>Output Dataset</para>
		/// <para>将包含所有组合输入数据集的输出数据集。</para>
		/// </param>
		public Merge(object Inputs, object Output)
		{
			this.Inputs = Inputs;
			this.Output = Output;
		}

		/// <summary>
		/// <para>Tool Display Name : 合并</para>
		/// </summary>
		public override string DisplayName() => "合并";

		/// <summary>
		/// <para>Tool Name : 合并</para>
		/// </summary>
		public override string ToolName() => "合并";

		/// <summary>
		/// <para>Tool Excute Name : management.Merge</para>
		/// </summary>
		public override string ExcuteName() => "management.Merge";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "maintainAttachments", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "preserveGlobalIds", "scratchWorkspace", "transferGDBAttributeProperties", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputs, Output, FieldMappings!, AddSource! };

		/// <summary>
		/// <para>Input Datasets</para>
		/// <para>要合并为新的输出数据集的输入数据集。 输入数据集可为点、线或面要素类或表。 输入要素类必须全部具有相同的几何类型。</para>
		/// <para>表和要素类可在单一输出数据集中合并。 输出类型由第一个输入确定。 如果第一个输入是要素类，则输出将是要素类，如果第一个输入是表，则输出将是表。 如果将表合并到要素类中，则输入表中的行将具有空几何。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Inputs { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>将包含所有组合输入数据集的输出数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Field Map</para>
		/// <para>输出中将包括的具有相应字段属性和源字段的属性字段。 默认情况下，将包括输入的所有字段。</para>
		/// <para>可以添加、删除、重命名和重新排序字段，且可以更改其属性。</para>
		/// <para>合并规则用于指定如何将两个或更多个输入字段的值合并或组合为一个输出值。 有多种合并规则可用于确定如何用值填充输出字段。</para>
		/// <para>First - 使用输入字段的第一个值。</para>
		/// <para>Last - 使用输入字段的最后一个值。</para>
		/// <para>Join - 串连（连接）输入字段的值。</para>
		/// <para>Sum - 计算输入字段值的总和。</para>
		/// <para>Mean - 计算输入字段值的平均值。</para>
		/// <para>Median - 计算输入字段值的中值。</para>
		/// <para>Mode - 使用具有最高频率的值。</para>
		/// <para>Min - 使用所有输入字段值中的最小值。</para>
		/// <para>Max - 使用所有输入字段值中的最大值。</para>
		/// <para>Standard deviation - 对所有输入字段值使用标准差分类方法。</para>
		/// <para>Count - 查找计算中所包含的记录数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldMapping()]
		public object? FieldMappings { get; set; }

		/// <summary>
		/// <para>Add source information to output</para>
		/// <para>指定是否将源信息添加到新文本字段 MERGE_SRC 中的输出数据集中。 MERGE_SRC 字段中的值用于指示作为输出中每条记录的源的输入数据集路径或图层名称。</para>
		/// <para>未选中 - 源信息将不会添加到 MERGE_SRC 字段中的输出数据集。 这是默认设置。</para>
		/// <para>选中 - 源信息将添加到 MERGE_SRC 字段中的输出数据集。</para>
		/// <para><see cref="AddSourceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AddSource { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Merge SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , object? extent = null , object? geographicTransformations = null , bool? maintainAttachments = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , bool? preserveGlobalIds = null , object? scratchWorkspace = null , bool? transferGDBAttributeProperties = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, maintainAttachments: maintainAttachments, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, preserveGlobalIds: preserveGlobalIds, scratchWorkspace: scratchWorkspace, transferGDBAttributeProperties: transferGDBAttributeProperties, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Add source information to output</para>
		/// </summary>
		public enum AddSourceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_SOURCE_INFO")]
			ADD_SOURCE_INFO,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SOURCE_INFO")]
			NO_SOURCE_INFO,

		}

#endregion
	}
}
