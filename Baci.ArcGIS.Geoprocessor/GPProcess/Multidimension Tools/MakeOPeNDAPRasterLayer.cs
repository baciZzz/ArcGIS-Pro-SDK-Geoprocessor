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
	/// <para>Make OPeNDAP Raster Layer</para>
	/// <para>Make OPeNDAP Raster Layer</para>
	/// <para>Creates a raster layer from data stored on an OPeNDAP server.</para>
	/// </summary>
	public class MakeOPeNDAPRasterLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InOpendapURL">
		/// <para>Input OPeNDAP URL</para>
		/// <para>The URL that references the remote OPeNDAP dataset. The URL should resolve to the dataset level (for example, file name), not a directory name.</para>
		/// </param>
		/// <param name="Variable">
		/// <para>Variable</para>
		/// <para>The variable from the OPeNDAP dataset that will be used to create the raster layer.</para>
		/// </param>
		/// <param name="XDimension">
		/// <para>X Dimension</para>
		/// <para>The dimension of the OPeNDAP dataset used to define the x, or longitude, coordinates of the output raster layer.</para>
		/// </param>
		/// <param name="YDimension">
		/// <para>Y Dimension</para>
		/// <para>The dimension of the OPeNDAP dataset used to define the y, or latitude, coordinates of the output raster layer.</para>
		/// </param>
		/// <param name="OutRasterLayer">
		/// <para>Output Raster Layer</para>
		/// <para>The name of the output raster layer.</para>
		/// </param>
		public MakeOPeNDAPRasterLayer(object InOpendapURL, object Variable, object XDimension, object YDimension, object OutRasterLayer)
		{
			this.InOpendapURL = InOpendapURL;
			this.Variable = Variable;
			this.XDimension = XDimension;
			this.YDimension = YDimension;
			this.OutRasterLayer = OutRasterLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Make OPeNDAP Raster Layer</para>
		/// </summary>
		public override string DisplayName() => "Make OPeNDAP Raster Layer";

		/// <summary>
		/// <para>Tool Name : MakeOPeNDAPRasterLayer</para>
		/// </summary>
		public override string ToolName() => "MakeOPeNDAPRasterLayer";

		/// <summary>
		/// <para>Tool Excute Name : md.MakeOPeNDAPRasterLayer</para>
		/// </summary>
		public override string ExcuteName() => "md.MakeOPeNDAPRasterLayer";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InOpendapURL, Variable, XDimension, YDimension, OutRasterLayer, Extent, DimensionValues, ValueSelectionMethod, CellRegistration };

		/// <summary>
		/// <para>Input OPeNDAP URL</para>
		/// <para>The URL that references the remote OPeNDAP dataset. The URL should resolve to the dataset level (for example, file name), not a directory name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InOpendapURL { get; set; }

		/// <summary>
		/// <para>Variable</para>
		/// <para>The variable from the OPeNDAP dataset that will be used to create the raster layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Variable { get; set; }

		/// <summary>
		/// <para>X Dimension</para>
		/// <para>The dimension of the OPeNDAP dataset used to define the x, or longitude, coordinates of the output raster layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object XDimension { get; set; }

		/// <summary>
		/// <para>Y Dimension</para>
		/// <para>The dimension of the OPeNDAP dataset used to define the y, or latitude, coordinates of the output raster layer.</para>
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
		/// <para>Extent</para>
		/// <para>The output extent of the raster layer. Specify the extent coordinates in the units of the OPeNDAP data source (these could be latitude-longitude, projected coordinates, or some arbitrary grid coordinates). The purpose of this parameter is to allow subsetting to an area of interest or to reduce the size of the data that is transferred.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEnvelope()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Dimension Values</para>
		/// <para>The starting and ending values of the dimensions or dimensions used to constrain which data will be extracted from the remote OPeNDAP server. By default, the minimum and maximum values of the dimension or dimensions will be used.</para>
		/// <para>Dimension—A netCDF dimension.</para>
		/// <para>Start Value—The start value to use for the specified dimension.</para>
		/// <para>End Value—The end value to use.</para>
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
		/// <para>Specifies how the cells will be registered with respect to the XY coordinate.</para>
		/// <para>Center—The XY coordinate represents the center of the cell. This is the default.</para>
		/// <para>Lower Left—The XY coordinate represents the lower left of the cell.</para>
		/// <para>Upper Left—The XY coordinate represents the upper left of the cell.</para>
		/// <para><see cref="CellRegistrationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CellRegistration { get; set; } = "CENTER";

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
			/// <para>Center—The XY coordinate represents the center of the cell. This is the default.</para>
			/// </summary>
			[GPValue("CENTER")]
			[Description("Center")]
			Center,

			/// <summary>
			/// <para>Lower Left—The XY coordinate represents the lower left of the cell.</para>
			/// </summary>
			[GPValue("LOWER_LEFT")]
			[Description("Lower Left")]
			Lower_Left,

			/// <summary>
			/// <para>Upper Left—The XY coordinate represents the upper left of the cell.</para>
			/// </summary>
			[GPValue("UPPER_LEFT")]
			[Description("Upper Left")]
			Upper_Left,

		}

#endregion
	}
}
