using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.RasterAnalysisTools
{
	/// <summary>
	/// <para>Interpolate Points</para>
	/// <para>插值点</para>
	/// <para>根据一组点的测量结果来预测新位置上的值。 该工具对具有数值的点数据进行处理，并返回预测值的栅格。</para>
	/// </summary>
	public class InterpolatePoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputpointfeatures">
		/// <para>Input Point Features</para>
		/// <para>要执行插值操作的输入点要素。</para>
		/// </param>
		/// <param name="Interpolatefield">
		/// <para>Interpolate Field</para>
		/// <para>包含要进行插值的数据值的字段。 该字段必须为数值型。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>输出栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。 如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </param>
		public InterpolatePoints(object Inputpointfeatures, object Interpolatefield, object Outputname)
		{
			this.Inputpointfeatures = Inputpointfeatures;
			this.Interpolatefield = Interpolatefield;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : 插值点</para>
		/// </summary>
		public override string DisplayName() => "插值点";

		/// <summary>
		/// <para>Tool Name : InterpolatePoints</para>
		/// </summary>
		public override string ToolName() => "InterpolatePoints";

		/// <summary>
		/// <para>Tool Excute Name : ra.InterpolatePoints</para>
		/// </summary>
		public override string ExcuteName() => "ra.InterpolatePoints";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise() => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "pyramid", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputpointfeatures, Interpolatefield, Outputname, Optimizefor!, Transformdata!, Sizeoflocalmodels!, Numberofneighbors!, Outputcellsize!, Outputpredictionerror!, Outputraster!, Outputerrorraster! };

		/// <summary>
		/// <para>Input Point Features</para>
		/// <para>要执行插值操作的输入点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		[FeatureType("Simple")]
		public object Inputpointfeatures { get; set; }

		/// <summary>
		/// <para>Interpolate Field</para>
		/// <para>包含要进行插值的数据值的字段。 该字段必须为数值型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object Interpolatefield { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。 如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Optimize For</para>
		/// <para>根据您的偏好选择“快速”或“精确”。 预测结果越精确，所花费的计算时间就越长。</para>
		/// <para>速度—此操作可用于优化速度。</para>
		/// <para>平衡—速度与精度之间的平衡。 这是默认设置。</para>
		/// <para>准确性—此操作可用于优化精度。</para>
		/// <para><see cref="OptimizeforEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Optimizefor { get; set; } = "BALANCE";

		/// <summary>
		/// <para>Transform Data to Normal Distribution</para>
		/// <para>选择是否在执行分析前将数据转换为正态分布。 如果您的数据值似乎未采用正态分布（钟形），则建议您进行转换。</para>
		/// <para>选中 - 应用正态分布转换。</para>
		/// <para>未选中 - 不应用转换。 这是默认设置。</para>
		/// <para><see cref="TransformdataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? Transformdata { get; set; } = "false";

		/// <summary>
		/// <para>Size of Local Models</para>
		/// <para>选择各局部模型中的点数。 数值越大，插值的全局性和稳定性越好，但是可能会失去小比例的效果。 数值越小，插值的局部性越好，因此更可能获得小比例的效果，但是插值可能不稳定。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 30, Max = 500)]
		[Category("Additional Options")]
		public object? Sizeoflocalmodels { get; set; }

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>计算特定像元的预测值时使用的相邻要素的数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 64)]
		[Category("Additional Options")]
		public object? Numberofneighbors { get; set; }

		/// <summary>
		/// <para>Output Cell Size</para>
		/// <para>设置输出栅格的像元大小和单位。 如果要创建预测误差栅格，则仍将使用此像元大小。</para>
		/// <para>单位可以是千米、米、英里或英尺。</para>
		/// <para>默认单位是米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? Outputcellsize { get; set; }

		/// <summary>
		/// <para>Output Prediction Error</para>
		/// <para>选择是否输出插值预测的标准误差栅格。</para>
		/// <para>标准误差可提供有关预测值的可信度的信息，因此非常有用。 一般来说，有 95% 的真值会落在两个预测值标准误差之间。 例如，假设一个新地区的预测值是 50，标准误差是 5。 这意味着通过此任务预测出此地区的真值是 50，但不排除真值低至 40 或高至 60 的可能。 为计算合理值的范围，可先用标准误差乘以 2，然后将得出的值加上预测值来获得范围上限，再用预测值减去乘以 2 后得出的值来获得范围下限。</para>
		/// <para>如果需要插值预测的标准误差栅格，则其名称与结果图层名称相同，但是会追加 Errors。</para>
		/// <para>未选中 - 不生成输出预测误差。 这是默认设置。</para>
		/// <para>选中 - 生成输出预测误差。</para>
		/// <para><see cref="OutputpredictionerrorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Outputpredictionerror { get; set; } = "false";

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputraster { get; set; }

		/// <summary>
		/// <para>Output Error Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputerrorraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public InterpolatePoints SetEnviroment(object? cellSize = null , object? extent = null , object? mask = null , object? outputCoordinateSystem = null , object? pyramid = null , object? snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Optimize For</para>
		/// </summary>
		public enum OptimizeforEnum 
		{
			/// <summary>
			/// <para>速度—此操作可用于优化速度。</para>
			/// </summary>
			[GPValue("SPEED")]
			[Description("速度")]
			Speed,

			/// <summary>
			/// <para>平衡—速度与精度之间的平衡。 这是默认设置。</para>
			/// </summary>
			[GPValue("BALANCE")]
			[Description("平衡")]
			Balance,

			/// <summary>
			/// <para>准确性—此操作可用于优化精度。</para>
			/// </summary>
			[GPValue("ACCURACY")]
			[Description("准确性")]
			Accuracy,

		}

		/// <summary>
		/// <para>Transform Data to Normal Distribution</para>
		/// </summary>
		public enum TransformdataEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("TRANSFORM")]
			TRANSFORM,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_TRANSFORM")]
			NO_TRANSFORM,

		}

		/// <summary>
		/// <para>Output Prediction Error</para>
		/// </summary>
		public enum OutputpredictionerrorEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OUTPUT_ERROR")]
			OUTPUT_ERROR,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_OUTPUT_ERROR")]
			NO_OUTPUT_ERROR,

		}

#endregion
	}
}
