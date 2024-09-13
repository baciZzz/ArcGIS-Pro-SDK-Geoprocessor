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
	/// <para>Calculate Distance</para>
	/// <para>计算距离</para>
	/// <para>计算距离 - 计算距离单个源或一组源的欧氏距离。</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.RasterAnalysisTools.DistanceAllocation"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.RasterAnalysisTools.DistanceAllocation))]
	public class CalculateDistance : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputsourcerasterorfeatures">
		/// <para>Input Source Raster or Features</para>
		/// <para>此图层用于定义计算距离的源。 此图层可以是影像服务或要素服务。</para>
		/// <para>对于影像服务，输入类型可以为整型或浮点型。</para>
		/// <para>对于要素服务，输入可以为点、线或面。</para>
		/// </param>
		/// <param name="Outputdistancename">
		/// <para>Output Distance Name</para>
		/// <para>输出距离栅格服务的名称。</para>
		/// </param>
		public CalculateDistance(object Inputsourcerasterorfeatures, object Outputdistancename)
		{
			this.Inputsourcerasterorfeatures = Inputsourcerasterorfeatures;
			this.Outputdistancename = Outputdistancename;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算距离</para>
		/// </summary>
		public override string DisplayName() => "计算距离";

		/// <summary>
		/// <para>Tool Name : CalculateDistance</para>
		/// </summary>
		public override string ToolName() => "CalculateDistance";

		/// <summary>
		/// <para>Tool Excute Name : ra.CalculateDistance</para>
		/// </summary>
		public override string ExcuteName() => "ra.CalculateDistance";

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
		public override object[] Parameters() => new object[] { Inputsourcerasterorfeatures, Outputdistancename, Maximumdistance!, Outputcellsize!, Outputdirectionname!, Outputallocationname!, Allocationfield!, Outputdistanceraster!, Outputdirectionraster!, Outputallocationraster!, Distancemethod!, Inputbarrierrasterorfeatures!, Outputbackdirectionname!, Outputbackdirectionraster! };

		/// <summary>
		/// <para>Input Source Raster or Features</para>
		/// <para>此图层用于定义计算距离的源。 此图层可以是影像服务或要素服务。</para>
		/// <para>对于影像服务，输入类型可以为整型或浮点型。</para>
		/// <para>对于要素服务，输入可以为点、线或面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputsourcerasterorfeatures { get; set; }

		/// <summary>
		/// <para>Output Distance Name</para>
		/// <para>输出距离栅格服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputdistancename { get; set; }

		/// <summary>
		/// <para>Maximum Distance</para>
		/// <para>用于计算输出的最大距离。</para>
		/// <para>单位可以是千米、米、英里、码或英尺。</para>
		/// <para>默认单位是米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? Maximumdistance { get; set; }

		/// <summary>
		/// <para>Output Cell Size</para>
		/// <para>设置输出栅格的像元大小和单位。</para>
		/// <para>单位可以是千米、米、英里、码或英尺。</para>
		/// <para>默认单位是米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? Outputcellsize { get; set; }

		/// <summary>
		/// <para>Output Direction Name</para>
		/// <para>输出方向栅格服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Outputdirectionname { get; set; }

		/// <summary>
		/// <para>Output Allocation Name</para>
		/// <para>输出分配栅格服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Outputallocationname { get; set; }

		/// <summary>
		/// <para>Allocation Field</para>
		/// <para>用于保存定义每个源的值的源输出上的字段。 其类型必须为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Allocationfield { get; set; }

		/// <summary>
		/// <para>Output Distance Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputdistanceraster { get; set; }

		/// <summary>
		/// <para>Output Direction Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputdirectionraster { get; set; }

		/// <summary>
		/// <para>Output Allocation Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputallocationraster { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>指定是否使用平面（平地）或测地线（椭球）方法计算距离。</para>
		/// <para>平面—将使用 2D 笛卡尔坐标系对投影平面执行距离计算。 这是默认设置。</para>
		/// <para>测地线—距离计算将在椭圆体上执行。 因此，结果不会改变，不考虑输入或输出投影。</para>
		/// <para><see cref="DistancemethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Distancemethod { get; set; } = "Planar";

		/// <summary>
		/// <para>Input Barrier Raster or Features</para>
		/// <para>定义障碍的数据集。</para>
		/// <para>可通过整型或浮点型栅格或者要素图层来定义障碍。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? Inputbarrierrasterorfeatures { get; set; }

		/// <summary>
		/// <para>Output Back Direction Name</para>
		/// <para>输出反向栅格服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Outputbackdirectionname { get; set; }

		/// <summary>
		/// <para>Output Back Direction Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputbackdirectionraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateDistance SetEnviroment(object? cellSize = null , object? extent = null , object? mask = null , object? outputCoordinateSystem = null , object? pyramid = null , object? snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistancemethodEnum 
		{
			/// <summary>
			/// <para>平面—将使用 2D 笛卡尔坐标系对投影平面执行距离计算。 这是默认设置。</para>
			/// </summary>
			[GPValue("Planar")]
			[Description("平面")]
			Planar,

			/// <summary>
			/// <para>测地线—距离计算将在椭圆体上执行。 因此，结果不会改变，不考虑输入或输出投影。</para>
			/// </summary>
			[GPValue("Geodesic")]
			[Description("测地线")]
			Geodesic,

		}

#endregion
	}
}
