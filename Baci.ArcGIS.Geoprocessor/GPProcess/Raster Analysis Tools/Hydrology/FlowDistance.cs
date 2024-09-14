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
	/// <para>Flow Distance</para>
	/// <para>流动距离</para>
	/// <para>计算每个像元沿流动路径到它们所流入河流上像元的下坡距离的水平或垂直分量。 如果是多个流动路径，则需要计算最小或最大流动距离，以及流动距离的加权平均数。</para>
	/// </summary>
	public class FlowDistance : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputstreamraster">
		/// <para>Input Stream Raster</para>
		/// <para>定义河流网络的输入栅格。</para>
		/// </param>
		/// <param name="Inputsurfaceraster">
		/// <para>Input Surface Raster</para>
		/// <para>输入栅格表示连续表面。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>输出流动距离栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。 如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </param>
		public FlowDistance(object Inputstreamraster, object Inputsurfaceraster, object Outputname)
		{
			this.Inputstreamraster = Inputstreamraster;
			this.Inputsurfaceraster = Inputsurfaceraster;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : 流动距离</para>
		/// </summary>
		public override string DisplayName() => "流动距离";

		/// <summary>
		/// <para>Tool Name : FlowDistance</para>
		/// </summary>
		public override string ToolName() => "FlowDistance";

		/// <summary>
		/// <para>Tool Excute Name : ra.FlowDistance</para>
		/// </summary>
		public override string ExcuteName() => "ra.FlowDistance";

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
		public override object[] Parameters() => new object[] { Inputstreamraster, Inputsurfaceraster, Outputname, Inputflowdirectionraster!, Distancetype!, Flowdirectiontype!, Outputraster!, Statisticstype! };

		/// <summary>
		/// <para>Input Stream Raster</para>
		/// <para>定义河流网络的输入栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputstreamraster { get; set; }

		/// <summary>
		/// <para>Input Surface Raster</para>
		/// <para>输入栅格表示连续表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputsurfaceraster { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出流动距离栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。 如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Input Flow Direction Raster</para>
		/// <para>根据每个像元来显示流向的输入栅格。</para>
		/// <para>如果提供流向栅格，则下坡方向将限于由输入流向定义的方向。</para>
		/// <para>可使用 D8、MFD 或 DINF 方法创建流向栅格。 可以使用流向类型参数来指定创建流向栅格时所使用的方法。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? Inputflowdirectionraster { get; set; }

		/// <summary>
		/// <para>Distance Type</para>
		/// <para>要计算的距离类型。</para>
		/// <para>垂直—流动距离计算表示属性域中的每个像元到其沿水流路径流入的河流上像元的最小流动距离的垂直分量。 这是默认设置。</para>
		/// <para>水平—流动距离计算表示属性域中的每个像元到其沿水流路径流入的河流上像元的最小流动距离的水平分量。</para>
		/// <para><see cref="DistancetypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Distancetype { get; set; } = "VERTICAL";

		/// <summary>
		/// <para>Flow Direction Type</para>
		/// <para>指定输入流向栅格类型。</para>
		/// <para>D8—输入流向栅格为 D8 类型。 这是默认设置。</para>
		/// <para>MFD—输入流向栅格为多流向 (MFD) 类型。</para>
		/// <para>DINF—输入流向栅格为 D-Infinity (DINF) 类型。</para>
		/// <para><see cref="FlowdirectiontypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Flowdirectiontype { get; set; } = "D8";

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputraster { get; set; }

		/// <summary>
		/// <para>Statistics type</para>
		/// <para>确定用于计算多个流动路径上的流动距离的统计类型。</para>
		/// <para>如果从每个像元到流上的某个像元只存在单一流动路径，则所有统计类型都将产生相同的结果。</para>
		/// <para>最小值—如果存在多个流动路径，则需要计算最小流动距离。 这是默认设置。</para>
		/// <para>加权平均数—如果存在多个流动路径，则需要计算流动距离的加权平均数。 从某个像元到其下游相邻像元的流量比例可用作计算加权平均数的权重。</para>
		/// <para>最大值—如果存在多个流动路径，则需要计算最大流动距离。</para>
		/// <para><see cref="StatisticstypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Statisticstype { get; set; } = "MINIMUM";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FlowDistance SetEnviroment(object? cellSize = null, object? extent = null, object? mask = null, object? outputCoordinateSystem = null, object? pyramid = null, object? snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Type</para>
		/// </summary>
		public enum DistancetypeEnum 
		{
			/// <summary>
			/// <para>垂直—流动距离计算表示属性域中的每个像元到其沿水流路径流入的河流上像元的最小流动距离的垂直分量。 这是默认设置。</para>
			/// </summary>
			[GPValue("VERTICAL")]
			[Description("垂直")]
			Vertical,

			/// <summary>
			/// <para>水平—流动距离计算表示属性域中的每个像元到其沿水流路径流入的河流上像元的最小流动距离的水平分量。</para>
			/// </summary>
			[GPValue("HORIZONTAL")]
			[Description("水平")]
			Horizontal,

		}

		/// <summary>
		/// <para>Flow Direction Type</para>
		/// </summary>
		public enum FlowdirectiontypeEnum 
		{
			/// <summary>
			/// <para>D8—输入流向栅格为 D8 类型。 这是默认设置。</para>
			/// </summary>
			[GPValue("D8")]
			[Description("D8")]
			D8,

			/// <summary>
			/// <para>MFD—输入流向栅格为多流向 (MFD) 类型。</para>
			/// </summary>
			[GPValue("MFD")]
			[Description("MFD")]
			MFD,

			/// <summary>
			/// <para>DINF—输入流向栅格为 D-Infinity (DINF) 类型。</para>
			/// </summary>
			[GPValue("DINF")]
			[Description("DINF")]
			DINF,

		}

		/// <summary>
		/// <para>Statistics type</para>
		/// </summary>
		public enum StatisticstypeEnum 
		{
			/// <summary>
			/// <para>最小值—如果存在多个流动路径，则需要计算最小流动距离。 这是默认设置。</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("最小值")]
			Minimum,

			/// <summary>
			/// <para>最大值—如果存在多个流动路径，则需要计算最大流动距离。</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("最大值")]
			Maximum,

			/// <summary>
			/// <para>加权平均数—如果存在多个流动路径，则需要计算流动距离的加权平均数。 从某个像元到其下游相邻像元的流量比例可用作计算加权平均数的权重。</para>
			/// </summary>
			[GPValue("WEIGHTED_MEAN")]
			[Description("加权平均数")]
			Weighted_Mean,

		}

#endregion
	}
}
