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
	/// <para>Make NetCDF Raster Layer</para>
	/// <para>Makes a raster layer from a netCDF file.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.MultidimensionTools.MakeMultidimensionalRasterLayer"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.MultidimensionTools.MakeMultidimensionalRasterLayer))]
	public class MakeNetCDFRasterLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetcdfFile">
		/// <para>Input netCDF File</para>
		/// <para>The input netCDF file.</para>
		/// </param>
		/// <param name="Variable">
		/// <para>Variable</para>
		/// <para>The variable of the netCDF file used to assign cell values to the output raster. This is the variable that will be displayed, such as temperature or rainfall.</para>
		/// </param>
		/// <param name="XDimension">
		/// <para>X Dimension</para>
		/// <para>A netCDF dimension used to define the x, or longitude, coordinates of the output layer.</para>
		/// </param>
		/// <param name="YDimension">
		/// <para>Y Dimension</para>
		/// <para>A netCDF dimension used to define the y, or latitude, coordinates of the output layer.</para>
		/// </param>
		/// <param name="OutRasterLayer">
		/// <para>Output Raster Layer</para>
		/// <para>The name of the output raster layer.</para>
		/// </param>
		public MakeNetCDFRasterLayer(object InNetcdfFile, object Variable, object XDimension, object YDimension, object OutRasterLayer)
		{
			this.InNetcdfFile = InNetcdfFile;
			this.Variable = Variable;
			this.XDimension = XDimension;
			this.YDimension = YDimension;
			this.OutRasterLayer = OutRasterLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Make NetCDF Raster Layer</para>
		/// </summary>
		public override string DisplayName() => "Make NetCDF Raster Layer";

		/// <summary>
		/// <para>Tool Name : MakeNetCDFRasterLayer</para>
		/// </summary>
		public override string ToolName() => "MakeNetCDFRasterLayer";

		/// <summary>
		/// <para>Tool Excute Name : md.MakeNetCDFRasterLayer</para>
		/// </summary>
		public override string ExcuteName() => "md.MakeNetCDFRasterLayer";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InNetcdfFile, Variable, XDimension, YDimension, OutRasterLayer, BandDimension, DimensionValues, ValueSelectionMethod, CellRegistration };

		/// <summary>
		/// <para>Input netCDF File</para>
		/// <para>The input netCDF file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc", "nc4")]
		public object InNetcdfFile { get; set; }

		/// <summary>
		/// <para>Variable</para>
		/// <para>The variable of the netCDF file used to assign cell values to the output raster. This is the variable that will be displayed, such as temperature or rainfall.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Variable { get; set; }

		/// <summary>
		/// <para>X Dimension</para>
		/// <para>A netCDF dimension used to define the x, or longitude, coordinates of the output layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object XDimension { get; set; }

		/// <summary>
		/// <para>Y Dimension</para>
		/// <para>A netCDF dimension used to define the y, or latitude, coordinates of the output layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object YDimension { get; set; }

		/// <summary>
		/// <para>Output Raster Layer</para>
		/// <para>The name of the output raster layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object OutRasterLayer { get; set; }

		/// <summary>
		/// <para>Band Dimension</para>
		/// <para>A netCDF dimension used to create bands in the output raster. Set this dimension if a multiband raster layer is required. For instance, altitude might be set as the band dimension to create a multiband raster where each band represents temperature at that altitude.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object BandDimension { get; set; }

		/// <summary>
		/// <para>Dimension Values</para>
		/// <para>The value (such as 01/30/05) of the dimension (such as Time) or dimensions to use when displaying the variable in the output layer. By default, the first value of the dimension or dimensions will be used.</para>
		/// <para>Dimension—A netCDF dimension.</para>
		/// <para>Value—The dimension value to use.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object DimensionValues { get; set; }

		/// <summary>
		/// <para>Value Selection Method</para>
		/// <para>Specifies the dimension value selection method that will be used.</para>
		/// <para>By value—The input value is matched with the actual dimension value.</para>
		/// <para>By index—The input value is matched with the position or index of a dimension value. The index is 0 based; that is, the position starts at 0.</para>
		/// <para><see cref="ValueSelectionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ValueSelectionMethod { get; set; } = "BY_VALUE";

		/// <summary>
		/// <para>Cell Registration</para>
		/// <para>Specifies the location of the cell registration.</para>
		/// <para>Center—Cell registration at the center of the cell. This is the default.</para>
		/// <para>Lower Left—Cell registration at the lower left of the cell.</para>
		/// <para>Upper Left—Cell registration at the upper left of the cell.</para>
		/// <para><see cref="CellRegistrationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CellRegistration { get; set; } = "CENTER";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeNetCDFRasterLayer SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Value Selection Method</para>
		/// </summary>
		public enum ValueSelectionMethodEnum 
		{
			/// <summary>
			/// <para>By index—The input value is matched with the position or index of a dimension value. The index is 0 based; that is, the position starts at 0.</para>
			/// </summary>
			[GPValue("BY_INDEX")]
			[Description("By index")]
			By_index,

			/// <summary>
			/// <para>By value—The input value is matched with the actual dimension value.</para>
			/// </summary>
			[GPValue("BY_VALUE")]
			[Description("By value")]
			By_value,

		}

		/// <summary>
		/// <para>Cell Registration</para>
		/// </summary>
		public enum CellRegistrationEnum 
		{
			/// <summary>
			/// <para>Center—Cell registration at the center of the cell. This is the default.</para>
			/// </summary>
			[GPValue("CENTER")]
			[Description("Center")]
			Center,

			/// <summary>
			/// <para>Lower Left—Cell registration at the lower left of the cell.</para>
			/// </summary>
			[GPValue("LOWER_LEFT")]
			[Description("Lower Left")]
			Lower_Left,

			/// <summary>
			/// <para>Upper Left—Cell registration at the upper left of the cell.</para>
			/// </summary>
			[GPValue("UPPER_LEFT")]
			[Description("Upper Left")]
			Upper_Left,

		}

#endregion
	}
}
