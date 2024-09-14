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
	/// <para>Flow Accumulation</para>
	/// <para>流量</para>
	/// <para>创建每个像元累积流量的栅格。</para>
	/// </summary>
	public class FlowAccumulation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputflowdirectionraster">
		/// <para>Input Flow Direction Raster</para>
		/// <para>根据每个像元来显示流向的输入栅格。</para>
		/// <para>可使用 D8、MFD 或 DINF 方法创建流向栅格。可以使用流向类型参数来指定创建流向栅格时所使用的方法。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>输出流量栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </param>
		public FlowAccumulation(object Inputflowdirectionraster, object Outputname)
		{
			this.Inputflowdirectionraster = Inputflowdirectionraster;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : 流量</para>
		/// </summary>
		public override string DisplayName() => "流量";

		/// <summary>
		/// <para>Tool Name : FlowAccumulation</para>
		/// </summary>
		public override string ToolName() => "FlowAccumulation";

		/// <summary>
		/// <para>Tool Excute Name : ra.FlowAccumulation</para>
		/// </summary>
		public override string ExcuteName() => "ra.FlowAccumulation";

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
		public override object[] Parameters() => new object[] { Inputflowdirectionraster, Outputname, Inputweightraster, Datatype, Flowdirectiontype, Outputraster };

		/// <summary>
		/// <para>Input Flow Direction Raster</para>
		/// <para>根据每个像元来显示流向的输入栅格。</para>
		/// <para>可使用 D8、MFD 或 DINF 方法创建流向栅格。可以使用流向类型参数来指定创建流向栅格时所使用的方法。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputflowdirectionraster { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出流量栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Input Weight Raster</para>
		/// <para>对每一像元应用权重的可选整型输入栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputweightraster { get; set; }

		/// <summary>
		/// <para>Output Data Type</para>
		/// <para>输出累积栅格可以是整型、浮点型或双精度型。</para>
		/// <para>浮点型—输出栅格将为浮点型。这是默认设置。</para>
		/// <para>整型—输出栅格将为整型。</para>
		/// <para>双精度型—输出栅格将为双精度型。</para>
		/// <para><see cref="DatatypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Datatype { get; set; } = "FLOAT";

		/// <summary>
		/// <para>Flow Direction Type</para>
		/// <para>指定输入流向栅格类型。</para>
		/// <para>D8—输入流向栅格为 D8 类型。这是默认设置。</para>
		/// <para>MFD—输入流向栅格为多流向 (MFD) 类型。</para>
		/// <para>DINF—输入流向栅格为 D-Infinity (DINF) 类型。</para>
		/// <para><see cref="FlowdirectiontypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Flowdirectiontype { get; set; } = "D8";

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FlowAccumulation SetEnviroment(object cellSize = null, object extent = null, object mask = null, object outputCoordinateSystem = null, object snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Data Type</para>
		/// </summary>
		public enum DatatypeEnum 
		{
			/// <summary>
			/// <para>浮点型—输出栅格将为浮点型。这是默认设置。</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("浮点型")]
			Float,

			/// <summary>
			/// <para>整型—输出栅格将为整型。</para>
			/// </summary>
			[GPValue("INTEGER")]
			[Description("整型")]
			Integer,

			/// <summary>
			/// <para>双精度型—输出栅格将为双精度型。</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("双精度型")]
			Double,

		}

		/// <summary>
		/// <para>Flow Direction Type</para>
		/// </summary>
		public enum FlowdirectiontypeEnum 
		{
			/// <summary>
			/// <para>D8—输入流向栅格为 D8 类型。这是默认设置。</para>
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

#endregion
	}
}
