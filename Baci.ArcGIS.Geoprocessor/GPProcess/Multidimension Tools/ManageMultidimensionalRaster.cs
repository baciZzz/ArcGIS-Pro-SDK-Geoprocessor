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
	/// <para>Manage Multidimensional Raster</para>
	/// <para>管理多维栅格</para>
	/// <para>通过添加或删除变量或维度来编辑多维栅格。</para>
	/// </summary>
	public class ManageMultidimensionalRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetMultidimensionalRaster">
		/// <para>Target Multidimensional Raster</para>
		/// <para>要修改的云栅格格式 (.crf) 的多维栅格。</para>
		/// </param>
		public ManageMultidimensionalRaster(object TargetMultidimensionalRaster)
		{
			this.TargetMultidimensionalRaster = TargetMultidimensionalRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 管理多维栅格</para>
		/// </summary>
		public override string DisplayName() => "管理多维栅格";

		/// <summary>
		/// <para>Tool Name : ManageMultidimensionalRaster</para>
		/// </summary>
		public override string ToolName() => "ManageMultidimensionalRaster";

		/// <summary>
		/// <para>Tool Excute Name : md.ManageMultidimensionalRaster</para>
		/// </summary>
		public override string ExcuteName() => "md.ManageMultidimensionalRaster";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetMultidimensionalRaster, ManageMode, Variables, InMultidimensionalRasters, DimensionName, DimensionValue, DimensionDescription, DimensionUnit, UpdateStatistics, UpdateTranspose, UpdatedTargetMultidimensionalRaster };

		/// <summary>
		/// <para>Target Multidimensional Raster</para>
		/// <para>要修改的云栅格格式 (.crf) 的多维栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object TargetMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Manage Mode</para>
		/// <para>指定将在目标栅格上执行的修改的类型。</para>
		/// <para>添加维度—维度将添加到输入多维栅格中。</para>
		/// <para>追加剖切片—输入多维栅格中的剖切片将添加到维度的剖切片的末尾。这是默认设置。</para>
		/// <para>追加变量—将添加输入多维栅格中的变量。</para>
		/// <para>替换剖切片—在特定的维度值下，现有剖切片将替换为另一个多维栅格中的剖切片。</para>
		/// <para>删除变量—一个或多个变量将从多维栅格中删除。</para>
		/// <para>移除维度—单剖切片多维栅格将转换为无维度栅格。</para>
		/// <para><see cref="ManageModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ManageMode { get; set; } = "APPEND_SLICES";

		/// <summary>
		/// <para>Variables</para>
		/// <para>将在目标多维栅格中修改的一个或多个变量。如果要执行的操作是对现有变量进行修改，则此参数为必需项。</para>
		/// <para>如果未指定变量，则将修改目标多维栅格中的第一个变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Variables { get; set; }

		/// <summary>
		/// <para>Input Multidimensional Rasters</para>
		/// <para>包含要添加到目标多维栅格的剖切片或变量的多维栅格数据集。当管理模式设置为追加剖切片、替换剖切片或追加变量时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InMultidimensionalRasters { get; set; }

		/// <summary>
		/// <para>Dimension Name</para>
		/// <para>要添加到栅格属性的新维度的名称。如果将管理模式设置为添加维度，则此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DimensionName { get; set; }

		/// <summary>
		/// <para>Dimension Value</para>
		/// <para>要添加的维度的值。该值可以是单个值，也可以是值范围。对于值范围，提供以逗号分隔的最小值和最大值。例如，对于新的高度维度，输入 0,10 时生成的维度的第一个剖切片包含前 10 米高度的信息。</para>
		/// <para>如果将管理模式设置为添加维度，则此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DimensionValue { get; set; }

		/// <summary>
		/// <para>Dimension Description</para>
		/// <para>为了元数据将添加到栅格属性的新维度的描述。如果将管理模式设置为添加维度，则此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DimensionDescription { get; set; }

		/// <summary>
		/// <para>Dimension Unit</para>
		/// <para>为了元数据将添加到栅格属性的新维度的单位。如果将管理模式设置为添加维度，则此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DimensionUnit { get; set; }

		/// <summary>
		/// <para>Update Statistics</para>
		/// <para>指定是否将为多维栅格数据集重新计算统计数据。</para>
		/// <para>选中 - 将重新计算统计数据。这是默认设置。</para>
		/// <para>未选中 - 将不会重新计算统计数据。</para>
		/// <para><see cref="UpdateStatisticsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UpdateStatistics { get; set; } = "true";

		/// <summary>
		/// <para>Update Transpose</para>
		/// <para>指定是否将为多维栅格数据集重新构建转置。</para>
		/// <para>选中 - 将重新构建转置。如果不存在转置，则系统将构建一个新转置。这是默认设置。</para>
		/// <para>未选中 - 不重新构建转置。</para>
		/// <para><see cref="UpdateTransposeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UpdateTranspose { get; set; } = "true";

		/// <summary>
		/// <para>Target Multidimensional Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object UpdatedTargetMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ManageMultidimensionalRaster SetEnviroment(object parallelProcessingFactor = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Manage Mode</para>
		/// </summary>
		public enum ManageModeEnum 
		{
			/// <summary>
			/// <para>追加剖切片—输入多维栅格中的剖切片将添加到维度的剖切片的末尾。这是默认设置。</para>
			/// </summary>
			[GPValue("APPEND_SLICES")]
			[Description("追加剖切片")]
			Append_Slices,

			/// <summary>
			/// <para>替换剖切片—在特定的维度值下，现有剖切片将替换为另一个多维栅格中的剖切片。</para>
			/// </summary>
			[GPValue("REPLACE_SLICES")]
			[Description("替换剖切片")]
			Replace_Slices,

			/// <summary>
			/// <para>追加变量—将添加输入多维栅格中的变量。</para>
			/// </summary>
			[GPValue("APPEND_VARIABLES")]
			[Description("追加变量")]
			Append_Variables,

			/// <summary>
			/// <para>删除变量—一个或多个变量将从多维栅格中删除。</para>
			/// </summary>
			[GPValue("DELETE_VARIABLES")]
			[Description("删除变量")]
			Delete_Variables,

			/// <summary>
			/// <para>添加维度—维度将添加到输入多维栅格中。</para>
			/// </summary>
			[GPValue("ADD_DIMENSION")]
			[Description("添加维度")]
			Add_Dimension,

			/// <summary>
			/// <para>移除维度—单剖切片多维栅格将转换为无维度栅格。</para>
			/// </summary>
			[GPValue("REMOVE_DIMENSION")]
			[Description("移除维度")]
			Remove_Dimension,

		}

		/// <summary>
		/// <para>Update Statistics</para>
		/// </summary>
		public enum UpdateStatisticsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_STATISTICS")]
			UPDATE_STATISTICS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UPDATE_STATISTICS")]
			NO_UPDATE_STATISTICS,

		}

		/// <summary>
		/// <para>Update Transpose</para>
		/// </summary>
		public enum UpdateTransposeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_TRANSPOSE")]
			UPDATE_TRANSPOSE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UPDATE_TRANSPOSE")]
			NO_UPDATE_TRANSPOSE,

		}

#endregion
	}
}
