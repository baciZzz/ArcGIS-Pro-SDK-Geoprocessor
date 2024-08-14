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
	/// <para>Select by Dimension</para>
	/// <para>Updates the netCDF layer display or netCDF table view based on the dimension value.</para>
	/// </summary>
	public class SelectByDimension : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayerOrTable">
		/// <para>Input Layer or Table</para>
		/// <para>The input netCDF raster layer, netCDF feature layer, netCDF table view, or mosaic layer. If the input is a mosaic layer, it must be multidimensional.</para>
		/// </param>
		public SelectByDimension(object InLayerOrTable)
		{
			this.InLayerOrTable = InLayerOrTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Select by Dimension</para>
		/// </summary>
		public override string DisplayName => "Select by Dimension";

		/// <summary>
		/// <para>Tool Name : SelectByDimension</para>
		/// </summary>
		public override string ToolName => "SelectByDimension";

		/// <summary>
		/// <para>Tool Excute Name : md.SelectByDimension</para>
		/// </summary>
		public override string ExcuteName => "md.SelectByDimension";

		/// <summary>
		/// <para>Toolbox Display Name : Multidimension Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Multidimension Tools";

		/// <summary>
		/// <para>Toolbox Alise : md</para>
		/// </summary>
		public override string ToolboxAlise => "md";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InLayerOrTable, DimensionValues!, ValueSelectionMethod!, OutputLayerOrTable! };

		/// <summary>
		/// <para>Input Layer or Table</para>
		/// <para>The input netCDF raster layer, netCDF feature layer, netCDF table view, or mosaic layer. If the input is a mosaic layer, it must be multidimensional.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InLayerOrTable { get; set; }

		/// <summary>
		/// <para>Dimension Values</para>
		/// <para>A set of dimension-value pairs used to specify a slice of a multidimensional variable.</para>
		/// <para>Dimension—A netCDF dimension.</para>
		/// <para>Value—A dimension value that specifies a slice of a multidimensional variable.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? DimensionValues { get; set; }

		/// <summary>
		/// <para>Value Selection Method</para>
		/// <para>Specifies the dimension value selection method that will be used.</para>
		/// <para>By value—The input value will be matched with the actual dimension value.</para>
		/// <para>By index—The input value will be matched with the position or index of a dimension value. The index is 0 based; that is, the position starts at 0.</para>
		/// <para><see cref="ValueSelectionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ValueSelectionMethod { get; set; } = "BY_VALUE";

		/// <summary>
		/// <para>Updated layer or table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutputLayerOrTable { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Value Selection Method</para>
		/// </summary>
		public enum ValueSelectionMethodEnum 
		{
			/// <summary>
			/// <para>By index—The input value will be matched with the position or index of a dimension value. The index is 0 based; that is, the position starts at 0.</para>
			/// </summary>
			[GPValue("BY_INDEX")]
			[Description("By index")]
			By_index,

			/// <summary>
			/// <para>By value—The input value will be matched with the actual dimension value.</para>
			/// </summary>
			[GPValue("BY_VALUE")]
			[Description("By value")]
			By_value,

		}

#endregion
	}
}
