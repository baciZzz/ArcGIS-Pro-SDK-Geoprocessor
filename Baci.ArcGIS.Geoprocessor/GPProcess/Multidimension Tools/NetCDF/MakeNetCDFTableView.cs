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
	/// <para>Make NetCDF Table View</para>
	/// <para>Make NetCDF Table View</para>
	/// <para>Makes a table view from a netCDF file.</para>
	/// </summary>
	public class MakeNetCDFTableView : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetcdfFile">
		/// <para>Input netCDF File</para>
		/// <para>The input netCDF file.</para>
		/// </param>
		/// <param name="Variable">
		/// <para>Variables</para>
		/// <para>The netCDF variable, or variables, used to create fields in the table view.</para>
		/// </param>
		/// <param name="OutTableView">
		/// <para>Output Table View</para>
		/// <para>The name of the output table view.</para>
		/// </param>
		public MakeNetCDFTableView(object InNetcdfFile, object Variable, object OutTableView)
		{
			this.InNetcdfFile = InNetcdfFile;
			this.Variable = Variable;
			this.OutTableView = OutTableView;
		}

		/// <summary>
		/// <para>Tool Display Name : Make NetCDF Table View</para>
		/// </summary>
		public override string DisplayName() => "Make NetCDF Table View";

		/// <summary>
		/// <para>Tool Name : MakeNetCDFTableView</para>
		/// </summary>
		public override string ToolName() => "MakeNetCDFTableView";

		/// <summary>
		/// <para>Tool Excute Name : md.MakeNetCDFTableView</para>
		/// </summary>
		public override string ExcuteName() => "md.MakeNetCDFTableView";

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
		public override object[] Parameters() => new object[] { InNetcdfFile, Variable, OutTableView, RowDimension!, DimensionValues!, ValueSelectionMethod! };

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
		/// <para>Variables</para>
		/// <para>The netCDF variable, or variables, used to create fields in the table view.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Variable { get; set; }

		/// <summary>
		/// <para>Output Table View</para>
		/// <para>The name of the output table view.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object OutTableView { get; set; }

		/// <summary>
		/// <para>Row Dimensions</para>
		/// <para>The netCDF dimension, or dimensions, used to create fields populated with unique values in the table view. The dimension, or dimensions, set here determine the number of rows in the table view and the fields that will be present.</para>
		/// <para>For instance, if stationID is a dimension in the netCDF file and has 10 values, by setting stationID as the dimension to use, 10 rows will be created in the table view. If stationID and time are used and there are 3 time slices, 30 rows will be created in the table view.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? RowDimension { get; set; }

		/// <summary>
		/// <para>Dimension Values</para>
		/// <para>A set of dimension-value pairs used to specify a slice of a multidimensional variable.</para>
		/// <para>Dimension—A netCDF dimension.</para>
		/// <para>Value—The dimension value to use.</para>
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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeNetCDFTableView SetEnviroment(object? workspace = null)
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
