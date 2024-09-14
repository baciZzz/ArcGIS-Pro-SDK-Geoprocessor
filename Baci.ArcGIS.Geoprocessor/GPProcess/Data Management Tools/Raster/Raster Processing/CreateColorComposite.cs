using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Create Color Composite</para>
	/// <para>Create Color Composite</para>
	/// <para>Creates a three-band raster dataset from a multiband raster dataset.</para>
	/// </summary>
	public class CreateColorComposite : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The input multiband raster data.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>The output three-band composite raster.</para>
		/// </param>
		/// <param name="Method">
		/// <para>Method</para>
		/// <para>Specifies the method that will be used to extract bands.</para>
		/// <para>Band names—The band name representing the wavelength interval on the electromagnetic spectrum (such as Red, Near Infrared, or Thermal Infrared) or the polarization (such as VH, VV, HH, or HV) will be used. This is the default.</para>
		/// <para>Band IDs— The band number (such as B1, B2, or B3) will be used.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </param>
		/// <param name="RedExpression">
		/// <para>Red Expression</para>
		/// <para>The calculation assigned to the first band.</para>
		/// <para>A band name, band ID, or an algebraic expression using the bands.</para>
		/// <para>The supported operators are unary: plus (+), minus (-), times (*), and divide (/).</para>
		/// </param>
		/// <param name="GreenExpression">
		/// <para>Green Expression</para>
		/// <para>The calculation assigned to the second band.</para>
		/// <para>A band name, band ID, or an algebraic expression using the bands.</para>
		/// <para>The supported operators are unary: plus (+), minus (-), times (*), and divide (/).</para>
		/// </param>
		/// <param name="BlueExpression">
		/// <para>Blue Expression</para>
		/// <para>The calculation assigned to the third band.</para>
		/// <para>A band name, band ID, or an algebraic expression using the bands.</para>
		/// <para>The supported operators are unary: plus (+), minus (-), times (*), and divide (/).</para>
		/// </param>
		public CreateColorComposite(object InRaster, object OutRaster, object Method, object RedExpression, object GreenExpression, object BlueExpression)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
			this.Method = Method;
			this.RedExpression = RedExpression;
			this.GreenExpression = GreenExpression;
			this.BlueExpression = BlueExpression;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Color Composite</para>
		/// </summary>
		public override string DisplayName() => "Create Color Composite";

		/// <summary>
		/// <para>Tool Name : CreateColorComposite</para>
		/// </summary>
		public override string ToolName() => "CreateColorComposite";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateColorComposite</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateColorComposite";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellAlignment", "cellSize", "compression", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, Method, RedExpression, GreenExpression, BlueExpression };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The input multiband raster data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>The output three-band composite raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>Specifies the method that will be used to extract bands.</para>
		/// <para>Band names—The band name representing the wavelength interval on the electromagnetic spectrum (such as Red, Near Infrared, or Thermal Infrared) or the polarization (such as VH, VV, HH, or HV) will be used. This is the default.</para>
		/// <para>Band IDs— The band number (such as B1, B2, or B3) will be used.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "BAND_IDS";

		/// <summary>
		/// <para>Red Expression</para>
		/// <para>The calculation assigned to the first band.</para>
		/// <para>A band name, band ID, or an algebraic expression using the bands.</para>
		/// <para>The supported operators are unary: plus (+), minus (-), times (*), and divide (/).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object RedExpression { get; set; }

		/// <summary>
		/// <para>Green Expression</para>
		/// <para>The calculation assigned to the second band.</para>
		/// <para>A band name, band ID, or an algebraic expression using the bands.</para>
		/// <para>The supported operators are unary: plus (+), minus (-), times (*), and divide (/).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object GreenExpression { get; set; }

		/// <summary>
		/// <para>Blue Expression</para>
		/// <para>The calculation assigned to the third band.</para>
		/// <para>A band name, band ID, or an algebraic expression using the bands.</para>
		/// <para>The supported operators are unary: plus (+), minus (-), times (*), and divide (/).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object BlueExpression { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateColorComposite SetEnviroment(object? cellAlignment = null, object? cellSize = null, object? compression = null, object? extent = null, object? geographicTransformations = null, object? nodata = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? pyramid = null, object? rasterStatistics = null, object? resamplingMethod = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(cellAlignment: cellAlignment, cellSize: cellSize, compression: compression, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Band names—The band name representing the wavelength interval on the electromagnetic spectrum (such as Red, Near Infrared, or Thermal Infrared) or the polarization (such as VH, VV, HH, or HV) will be used. This is the default.</para>
			/// </summary>
			[GPValue("BAND_NAMES")]
			[Description("Band names")]
			Band_names,

			/// <summary>
			/// <para>Band IDs— The band number (such as B1, B2, or B3) will be used.</para>
			/// </summary>
			[GPValue("BAND_IDS")]
			[Description("Band IDs")]
			Band_IDs,

		}

#endregion
	}
}
