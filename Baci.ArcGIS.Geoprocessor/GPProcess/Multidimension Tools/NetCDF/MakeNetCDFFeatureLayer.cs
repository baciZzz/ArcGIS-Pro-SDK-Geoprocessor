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
	/// <para>Make NetCDF Feature Layer</para>
	/// <para>Makes a feature layer from a netCDF file.</para>
	/// </summary>
	public class MakeNetCDFFeatureLayer : AbstractGPProcess
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
		/// <para>The netCDF variable, or variables, that will be added as fields in the feature attribute table.</para>
		/// </param>
		/// <param name="XVariable">
		/// <para>X Variable</para>
		/// <para>A netCDF coordinate variable used to define the x, or longitude, coordinates of the output layer.</para>
		/// </param>
		/// <param name="YVariable">
		/// <para>Y Variable</para>
		/// <para>A netCDF coordinate variable used to define the y, or latitude, coordinates of the output layer.</para>
		/// </param>
		/// <param name="OutFeatureLayer">
		/// <para>Output Feature Layer</para>
		/// <para>The name of the output feature layer.</para>
		/// </param>
		public MakeNetCDFFeatureLayer(object InNetcdfFile, object Variable, object XVariable, object YVariable, object OutFeatureLayer)
		{
			this.InNetcdfFile = InNetcdfFile;
			this.Variable = Variable;
			this.XVariable = XVariable;
			this.YVariable = YVariable;
			this.OutFeatureLayer = OutFeatureLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Make NetCDF Feature Layer</para>
		/// </summary>
		public override string DisplayName() => "Make NetCDF Feature Layer";

		/// <summary>
		/// <para>Tool Name : MakeNetCDFFeatureLayer</para>
		/// </summary>
		public override string ToolName() => "MakeNetCDFFeatureLayer";

		/// <summary>
		/// <para>Tool Excute Name : md.MakeNetCDFFeatureLayer</para>
		/// </summary>
		public override string ExcuteName() => "md.MakeNetCDFFeatureLayer";

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
		public override object[] Parameters() => new object[] { InNetcdfFile, Variable, XVariable, YVariable, OutFeatureLayer, RowDimension, ZVariable, MVariable, DimensionValues, ValueSelectionMethod };

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
		/// <para>The netCDF variable, or variables, that will be added as fields in the feature attribute table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Variable { get; set; }

		/// <summary>
		/// <para>X Variable</para>
		/// <para>A netCDF coordinate variable used to define the x, or longitude, coordinates of the output layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object XVariable { get; set; }

		/// <summary>
		/// <para>Y Variable</para>
		/// <para>A netCDF coordinate variable used to define the y, or latitude, coordinates of the output layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object YVariable { get; set; }

		/// <summary>
		/// <para>Output Feature Layer</para>
		/// <para>The name of the output feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object OutFeatureLayer { get; set; }

		/// <summary>
		/// <para>Row Dimensions</para>
		/// <para>The netCDF dimension, or dimensions, used to create features with unique values in the feature layer. The dimension or dimensions set here determine the number of features in the feature layer and the fields that will be presented in the feature layer&apos;s attribute table.</para>
		/// <para>For instance, if StationID is a dimension in the netCDF file and has 10 values, by setting StationID as the dimension to use, 10 features will be created (10 rows will be created in the feature layer&apos;s attribute table). If StationID and time are used, and there are 3 time slices, 30 features will be created (30 rows will be created in the feature layer&apos;s attribute table). If you will be animating the netCDF feature layer, it is recommended, for efficiency reasons, to not set time as a row dimension. Time will still be available as a dimension that you can set to animate through, but the attribute table will not store this information.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object RowDimension { get; set; }

		/// <summary>
		/// <para>Z Variable</para>
		/// <para>A netCDF variable used to specify elevation values (z-values) for features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ZVariable { get; set; }

		/// <summary>
		/// <para>M Variable</para>
		/// <para>A netCDF variable used to specify linear measurement values (m-values) for features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object MVariable { get; set; }

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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeNetCDFFeatureLayer SetEnviroment(object workspace = null )
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

#endregion
	}
}
