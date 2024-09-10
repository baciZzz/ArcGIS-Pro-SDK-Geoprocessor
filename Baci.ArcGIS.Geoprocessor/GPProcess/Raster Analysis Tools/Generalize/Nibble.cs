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
	/// <para>Replaces cells of a raster corresponding to a mask with the values of the nearest neighbors.</para>
	/// </summary>
	public class Nibble : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputraster">
		/// <para>Input Raster</para>
		/// <para>The input raster that will be nibbled.</para>
		/// <para>The raster can be either integer or floating point type.</para>
		/// </param>
		/// <param name="Inputmaskraster">
		/// <para>Input Mask Raster</para>
		/// <para>The raster used as the mask.</para>
		/// <para>The cells that are NoData define the cells that will be nibbled, or replaced, by the value of the closest nearest neighbour.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output nibble raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </param>
		public Nibble(object Inputraster, object Inputmaskraster, object Outputname)
		{
			this.Inputraster = Inputraster;
			this.Inputmaskraster = Inputmaskraster;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : Nibble</para>
		/// </summary>
		public override string DisplayName() => "Nibble";

		/// <summary>
		/// <para>Tool Name : Nibble</para>
		/// </summary>
		public override string ToolName() => "Nibble";

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
		/// <para>The input raster that will be nibbled.</para>
		/// <para>The raster can be either integer or floating point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputraster { get; set; }

		/// <summary>
		/// <para>Input Mask Raster</para>
		/// <para>The raster used as the mask.</para>
		/// <para>The cells that are NoData define the cells that will be nibbled, or replaced, by the value of the closest nearest neighbour.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputmaskraster { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output nibble raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Use NoData values if they are the nearest neighbor</para>
		/// <para>Defines if NoData values in the input raster are allowed to nibble into the area defined by the mask raster.</para>
		/// <para>Checked—Specifies that the nearest neighbor value will be used whether it is NoData or another data value in the input raster. NoData values in the input raster are free to nibble into areas defined in the mask if they are the nearest neighbor. This is the default.</para>
		/// <para>Unchecked—Specifies that only data values are free to nibble into areas defined in the mask raster. NoData values in the input raster are not allowed to nibble into areas defined in the mask raster even if they are the nearest neighbor.</para>
		/// <para><see cref="NibblevaluesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Nibblevalues { get; set; } = "true";

		/// <summary>
		/// <para>Nibble NoData cells</para>
		/// <para>Defines if NoData cells in the input raster that are within the mask will remain NoData in the output raster.</para>
		/// <para>Unchecked—Specifies that NoData cells in the input raster and within the mask will remain NoData in the output. This is the default.</para>
		/// <para>Checked—Specifies that NoData cells in the input raster and within the mask can be nibbled into valid output cell values.</para>
		/// <para><see cref="NibblenodataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Nibblenodata { get; set; } = "false";

		/// <summary>
		/// <para>Input Zone Raster</para>
		/// <para>The input zone raster. For each zone, input cells that are within the mask will be replaced only by the nearest cell values within that same zone.</para>
		/// <para>A zone is all the cells in a raster that have the same value, whether or not they are contiguous. The input zone layer defines the shape, values, and locations of the zones. The zone raster can be either integer or floating point type.</para>
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
		public Nibble SetEnviroment(object cellSize = null , object extent = null , object mask = null , object outputCoordinateSystem = null , object snapRaster = null )
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
			/// <para>Checked—Specifies that the nearest neighbor value will be used whether it is NoData or another data value in the input raster. NoData values in the input raster are free to nibble into areas defined in the mask if they are the nearest neighbor. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL_VALUES")]
			ALL_VALUES,

			/// <summary>
			/// <para>Unchecked—Specifies that only data values are free to nibble into areas defined in the mask raster. NoData values in the input raster are not allowed to nibble into areas defined in the mask raster even if they are the nearest neighbor.</para>
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
			/// <para>Checked—Specifies that NoData cells in the input raster and within the mask can be nibbled into valid output cell values.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PROCESS_NODATA")]
			PROCESS_NODATA,

			/// <summary>
			/// <para>Unchecked—Specifies that NoData cells in the input raster and within the mask will remain NoData in the output. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("PRESERVE_NODATA")]
			PRESERVE_NODATA,

		}

#endregion
	}
}
