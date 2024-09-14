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
	/// <para>Nibble</para>
	/// <para>蚕食</para>
	/// <para>用最邻近点的值替换掩膜范围内的栅格像元的值。</para>
	/// </summary>
	public class Nibble : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputraster">
		/// <para>Input Raster</para>
		/// <para>将被蚕食的输入栅格。</para>
		/// <para>栅格可以是整型，也可以是浮点型。</para>
		/// </param>
		/// <param name="Inputmaskraster">
		/// <para>Input Mask Raster</para>
		/// <para>用作掩膜的栅格。</para>
		/// <para>NoData 像元能够定义将被蚕食或被最近邻域的值替换的像元。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>输出蚕食栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </param>
		public Nibble(object Inputraster, object Inputmaskraster, object Outputname)
		{
			this.Inputraster = Inputraster;
			this.Inputmaskraster = Inputmaskraster;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : 蚕食</para>
		/// </summary>
		public override string DisplayName() => "蚕食";

		/// <summary>
		/// <para>Tool Name : 蚕食</para>
		/// </summary>
		public override string ToolName() => "蚕食";

		/// <summary>
		/// <para>Tool Excute Name : ra.Nibble</para>
		/// </summary>
		public override string ExcuteName() => "ra.Nibble";

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
		public override object[] Parameters() => new object[] { Inputraster, Inputmaskraster, Outputname, Nibblevalues, Nibblenodata, Inputzoneraster, Outputraster };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>将被蚕食的输入栅格。</para>
		/// <para>栅格可以是整型，也可以是浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputraster { get; set; }

		/// <summary>
		/// <para>Input Mask Raster</para>
		/// <para>用作掩膜的栅格。</para>
		/// <para>NoData 像元能够定义将被蚕食或被最近邻域的值替换的像元。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputmaskraster { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出蚕食栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Use NoData values if they are the nearest neighbor</para>
		/// <para>定义是否允许一点点地除去输入栅格中的 NoData 值以形成由栅格掩膜定义的区域。</para>
		/// <para>选中 - 指定使用最邻近点值，无论其在输入栅格中是 NoData 还是其他数据值。如果输入栅格中的 NoData 值是最邻近点，则可自由地将其蚕食掉为掩膜中定义的区域。这是默认设置。</para>
		/// <para>未选中 - 指定仅可自由地将数据值蚕食为掩膜栅格中定义的区域。即使输入栅格中的 NoData 值是最邻近点，也不允许将其蚕食为掩膜栅格中定义的区域。</para>
		/// <para><see cref="NibblevaluesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Nibblevalues { get; set; } = "true";

		/// <summary>
		/// <para>Nibble NoData cells</para>
		/// <para>定义输入栅格中处于掩膜内的 NoData 像元在输出栅格中是否仍为 NoData。</para>
		/// <para>未选中 - 指定输入栅格中且处于掩膜内的 NoData 像元在输出中仍为 NoData。这是默认设置。</para>
		/// <para>选中 - 指定输入栅格中处于掩膜内的 NoData 像元可以被蚕食为有效的输出像元值。</para>
		/// <para><see cref="NibblenodataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Nibblenodata { get; set; } = "false";

		/// <summary>
		/// <para>Input Zone Raster</para>
		/// <para>输入区域栅格。在每个区域中，掩膜内的输入像元仅会被同一区域内的最近像元值替换。</para>
		/// <para>区域是指栅格中具有相同值的所有像元，无论这些像元是否相连。输入区域图层定义了区域的形状、值和位置。区域栅格可以是整型，也可以是浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputzoneraster { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Nibble SetEnviroment(object cellSize = null, object extent = null, object mask = null, object outputCoordinateSystem = null, object snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Use NoData values if they are the nearest neighbor</para>
		/// </summary>
		public enum NibblevaluesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL_VALUES")]
			ALL_VALUES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DATA_ONLY")]
			DATA_ONLY,

		}

		/// <summary>
		/// <para>Nibble NoData cells</para>
		/// </summary>
		public enum NibblenodataEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PROCESS_NODATA")]
			PROCESS_NODATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("PRESERVE_NODATA")]
			PRESERVE_NODATA,

		}

#endregion
	}
}
