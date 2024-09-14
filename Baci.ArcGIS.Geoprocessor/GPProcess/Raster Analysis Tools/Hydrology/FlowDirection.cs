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
	/// <para>Flow Direction</para>
	/// <para>流向</para>
	/// <para>使用 D8、D-Infinity (DINF) 或多流向 (MFD) 方法计算从每个像元到其下坡的一个或多个相邻点的流向。</para>
	/// </summary>
	public class FlowDirection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputsurfaceraster">
		/// <para>Input Surface Raster</para>
		/// <para>输入栅格表示连续的表面。</para>
		/// </param>
		/// <param name="Outputflowdirectionname">
		/// <para>Output Flow Direction Name</para>
		/// <para>输出流向栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </param>
		public FlowDirection(object Inputsurfaceraster, object Outputflowdirectionname)
		{
			this.Inputsurfaceraster = Inputsurfaceraster;
			this.Outputflowdirectionname = Outputflowdirectionname;
		}

		/// <summary>
		/// <para>Tool Display Name : 流向</para>
		/// </summary>
		public override string DisplayName() => "流向";

		/// <summary>
		/// <para>Tool Name : FlowDirection</para>
		/// </summary>
		public override string ToolName() => "FlowDirection";

		/// <summary>
		/// <para>Tool Excute Name : ra.FlowDirection</para>
		/// </summary>
		public override string ExcuteName() => "ra.FlowDirection";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputsurfaceraster, Outputflowdirectionname, Forceflow, Flowdirectiontype, Outputdropname, Outputflowdirectionraster, Outputdropraster };

		/// <summary>
		/// <para>Input Surface Raster</para>
		/// <para>输入栅格表示连续的表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputsurfaceraster { get; set; }

		/// <summary>
		/// <para>Output Flow Direction Name</para>
		/// <para>输出流向栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputflowdirectionname { get; set; }

		/// <summary>
		/// <para>Force all edge cells to flow outward</para>
		/// <para>指定边缘像元始终向外流还是遵循正常流动规则。</para>
		/// <para>未选中 - 如果边缘像元内部的最大降幅大于零，则将照常确定流向；否则流向将朝向边缘。应从表面栅格的边缘向内流的像元也将执行此行为。这是默认设置。</para>
		/// <para>选中 - 表面栅格边缘的所有像元将从表面栅格向外流。</para>
		/// <para><see cref="ForceflowEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Forceflow { get; set; } = "false";

		/// <summary>
		/// <para>Flow Direction Type</para>
		/// <para>指定计算流向时使用的流向法的类型。</para>
		/// <para>D8—根据 D8 流向法分配流向。此方法可将流向分配至最陡下坡相邻点。这是默认设置。</para>
		/// <para>MFD—根据 MFD 流向法分配流向。此方法可将多流向分配至所有下坡邻域。</para>
		/// <para>DINF—根据 D-Infinity 流向法，使用三角面的最陡坡度指定流向。</para>
		/// <para><see cref="FlowdirectiontypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Flowdirectiontype { get; set; } = "D8";

		/// <summary>
		/// <para>Output Drop Name</para>
		/// <para>输出下降率栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Outputdropname { get; set; }

		/// <summary>
		/// <para>Output Flow Direction Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputflowdirectionraster { get; set; }

		/// <summary>
		/// <para>Output Drop Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputdropraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FlowDirection SetEnviroment(object cellSize = null, object extent = null, object mask = null, object outputCoordinateSystem = null, object snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Force all edge cells to flow outward</para>
		/// </summary>
		public enum ForceflowEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FORCE")]
			FORCE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NORMAL")]
			NORMAL,

		}

		/// <summary>
		/// <para>Flow Direction Type</para>
		/// </summary>
		public enum FlowdirectiontypeEnum 
		{
			/// <summary>
			/// <para>D8—根据 D8 流向法分配流向。此方法可将流向分配至最陡下坡相邻点。这是默认设置。</para>
			/// </summary>
			[GPValue("D8")]
			[Description("D8")]
			D8,

			/// <summary>
			/// <para>MFD—根据 MFD 流向法分配流向。此方法可将多流向分配至所有下坡邻域。</para>
			/// </summary>
			[GPValue("MFD")]
			[Description("MFD")]
			MFD,

			/// <summary>
			/// <para>DINF—根据 D-Infinity 流向法，使用三角面的最陡坡度指定流向。</para>
			/// </summary>
			[GPValue("DINF")]
			[Description("DINF")]
			DINF,

		}

#endregion
	}
}
