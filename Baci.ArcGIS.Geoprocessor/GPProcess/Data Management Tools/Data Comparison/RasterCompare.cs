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
	/// <para>Raster Compare</para>
	/// <para>栅格比较</para>
	/// <para>比较两个栅格数据集或镶嵌数据集的属性。</para>
	/// </summary>
	public class RasterCompare : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBaseRaster">
		/// <para>Input Base Raster</para>
		/// <para>要比较的第一个栅格或镶嵌数据集。</para>
		/// </param>
		/// <param name="InTestRaster">
		/// <para>Input Test Raster</para>
		/// <para>要与第一个栅格或镶嵌数据集进行比较的第二个栅格或镶嵌数据集。</para>
		/// </param>
		public RasterCompare(object InBaseRaster, object InTestRaster)
		{
			this.InBaseRaster = InBaseRaster;
			this.InTestRaster = InTestRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 栅格比较</para>
		/// </summary>
		public override string DisplayName() => "栅格比较";

		/// <summary>
		/// <para>Tool Name : RasterCompare</para>
		/// </summary>
		public override string ToolName() => "RasterCompare";

		/// <summary>
		/// <para>Tool Excute Name : management.RasterCompare</para>
		/// </summary>
		public override string ExcuteName() => "management.RasterCompare";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InBaseRaster, InTestRaster, CompareType!, IgnoreOption!, ContinueCompare!, OutCompareFile!, ParameterTolerances!, AttributeTolerances!, OmitField!, CompareStatus! };

		/// <summary>
		/// <para>Input Base Raster</para>
		/// <para>要比较的第一个栅格或镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InBaseRaster { get; set; }

		/// <summary>
		/// <para>Input Test Raster</para>
		/// <para>要与第一个栅格或镶嵌数据集进行比较的第二个栅格或镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTestRaster { get; set; }

		/// <summary>
		/// <para>Compare Type</para>
		/// <para>指定将比较的栅格类型。</para>
		/// <para>栅格数据集—将比较两个栅格数据集。</para>
		/// <para>地理数据库栅格数据集—将比较地理数据库中的两个栅格数据集。</para>
		/// <para>镶嵌数据集—将比较两个镶嵌数据集。</para>
		/// <para><see cref="CompareTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CompareType { get; set; } = "RASTER_DATASET";

		/// <summary>
		/// <para>Ignore Options</para>
		/// <para>指定将在比较中被忽略的属性。</para>
		/// <para>波段计数—将忽略波段数。</para>
		/// <para>范围—将忽略范围。</para>
		/// <para>列和行—将忽略列和行数。</para>
		/// <para>像素类型—将忽略像素类型。</para>
		/// <para>NoData—将忽略 NoData 值。</para>
		/// <para>空间参考—将忽略空间参考系统。</para>
		/// <para>像素值—将忽略像素值。</para>
		/// <para>色彩映射表—将忽略色彩映射表。</para>
		/// <para>栅格属性表—将忽略属性表。</para>
		/// <para>统计数据—将忽略统计数据。</para>
		/// <para>元数据—将忽略元数据。</para>
		/// <para>存在金字塔—将忽略已有的金字塔。</para>
		/// <para>压缩类型—将忽略压缩类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? IgnoreOption { get; set; }

		/// <summary>
		/// <para>Continue Comparison</para>
		/// <para>指定发现不匹配时是否停止比较。</para>
		/// <para>未选中 - 发现不匹配时，将停止比较。 这是默认设置。</para>
		/// <para>选中 - 发现不匹配时，继续比较。</para>
		/// <para><see cref="ContinueCompareEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ContinueCompare { get; set; } = "false";

		/// <summary>
		/// <para>Output Compare File</para>
		/// <para>包含比较结果的文本文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object? OutCompareFile { get; set; }

		/// <summary>
		/// <para>Parameter Tolerance</para>
		/// <para>落在此公差范围内的要值视作相同。 可以对所有参数使用相同的容差，也可以向各个参数应用不同的容差。</para>
		/// <para>容差类型可以为值，也可以为小数部分。</para>
		/// <para>如果容差类型是分数，则每个像素的容差将不同，因为每个像素具有不同的值。 例如，如果容差分数设置为 0.5，则容差计算如下：</para>
		/// <para>如果像素值为 0.2，则容差将为 0.1，因为 0.5 * 0.2 = 0.1。</para>
		/// <para>如果像素值为 3，则容差将为 1.5，因为 0.5 * 3 = 1.5。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ParameterTolerances { get; set; }

		/// <summary>
		/// <para>Attribute Tolerance</para>
		/// <para>将比较这些字段以确定它们是否在公差范围内。 容差值的单位为属性的单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? AttributeTolerances { get; set; }

		/// <summary>
		/// <para>Omit Fields</para>
		/// <para>在比较过程中将被忽略的一个或多个字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? OmitField { get; set; }

		/// <summary>
		/// <para>Compare Status</para>
		/// <para><see cref="CompareStatusEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CompareStatus { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterCompare SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Compare Type</para>
		/// </summary>
		public enum CompareTypeEnum 
		{
			/// <summary>
			/// <para>栅格数据集—将比较两个栅格数据集。</para>
			/// </summary>
			[GPValue("RASTER_DATASET")]
			[Description("栅格数据集")]
			Raster_dataset,

			/// <summary>
			/// <para>地理数据库栅格数据集—将比较地理数据库中的两个栅格数据集。</para>
			/// </summary>
			[GPValue("GDB_RASTER_DATASET")]
			[Description("地理数据库栅格数据集")]
			Geodatabase_raster_dataset,

			/// <summary>
			/// <para>镶嵌数据集—将比较两个镶嵌数据集。</para>
			/// </summary>
			[GPValue("MOSAIC_DATASET")]
			[Description("镶嵌数据集")]
			Mosaic_dataset,

		}

		/// <summary>
		/// <para>Continue Comparison</para>
		/// </summary>
		public enum ContinueCompareEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CONTINUE_COMPARE")]
			CONTINUE_COMPARE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CONTINUE_COMPARE")]
			NO_CONTINUE_COMPARE,

		}

		/// <summary>
		/// <para>Compare Status</para>
		/// </summary>
		public enum CompareStatusEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("NO_DIFFERENCES_FOUND")]
			NO_DIFFERENCES_FOUND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DIFFERENCES_FOUND")]
			DIFFERENCES_FOUND,

		}

#endregion
	}
}
