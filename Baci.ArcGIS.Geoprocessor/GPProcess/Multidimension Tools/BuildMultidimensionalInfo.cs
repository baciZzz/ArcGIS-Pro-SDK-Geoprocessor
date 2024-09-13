using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MultidimensionTools
{
	/// <summary>
	/// <para>Build Multidimensional Info</para>
	/// <para>构建多维信息</para>
	/// <para>在镶嵌数据集中生成多维元数据，其中包含有关变量和维度的信息。</para>
	/// </summary>
	public class BuildMultidimensionalInfo : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>输入多维镶嵌数据集。</para>
		/// </param>
		public BuildMultidimensionalInfo(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 构建多维信息</para>
		/// </summary>
		public override string DisplayName() => "构建多维信息";

		/// <summary>
		/// <para>Tool Name : BuildMultidimensionalInfo</para>
		/// </summary>
		public override string ToolName() => "BuildMultidimensionalInfo";

		/// <summary>
		/// <para>Tool Excute Name : md.BuildMultidimensionalInfo</para>
		/// </summary>
		public override string ExcuteName() => "md.BuildMultidimensionalInfo";

		/// <summary>
		/// <para>Toolbox Display Name : Multidimension Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Multidimension Tools";

		/// <summary>
		/// <para>Toolbox Alise : md</para>
		/// </summary>
		public override string ToolboxAlise() => "md";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, VariableField!, DimensionFields!, VariableDescUnits!, OutMosaicDataset!, DeleteMultidimensionalInfo! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>输入多维镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Variable Field</para>
		/// <para>镶嵌数据集中用于存储变量名称的字段，并且用于填充名为 Variable 的新字段。如果镶嵌数据集中的所有栅格都表示同一变量，请输入变量名称，例如 Temperature。</para>
		/// <para>如果 Variable 字段尚不存在，必须指定现有字段或字符串值。如果 Variable 字段存在，该工具将仅更新多维信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? VariableField { get; set; }

		/// <summary>
		/// <para>Dimension Fields</para>
		/// <para>镶嵌数据集中用于存储维度信息的字段，并且用于填充名为 Dimensions 的新字段。</para>
		/// <para>如果 Dimensions 字段已存在，该工具将仅更新多维信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? DimensionFields { get; set; }

		/// <summary>
		/// <para>Variable Info</para>
		/// <para>指定有关 Variable 字段的其他信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? VariableDescUnits { get; set; }

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMosaicLayer()]
		public object? OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Delete Multidimensional Info</para>
		/// <para>指定是否删除现有多维信息。</para>
		/// <para>未选中 - 如果镶嵌数据集中存在多维信息，则不会将其删除。 这是默认设置。</para>
		/// <para>选中 - 如果镶嵌数据集中存在多维信息，则会将其删除。</para>
		/// <para><see cref="DeleteMultidimensionalInfoEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeleteMultidimensionalInfo { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Delete Multidimensional Info</para>
		/// </summary>
		public enum DeleteMultidimensionalInfoEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_MULTIDIMENSIONAL_INFO")]
			DELETE_MULTIDIMENSIONAL_INFO,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_MULTIDIMENSIONAL_INFO")]
			NO_DELETE_MULTIDIMENSIONAL_INFO,

		}

#endregion
	}
}
