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
	/// <para>Create Random Raster</para>
	/// <para>Create Random Raster</para>
	/// <para>Creates a raster dataset of random values with a distribution you define.</para>
	/// </summary>
	public class CreateRandomRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutPath">
		/// <para>Output Location</para>
		/// <para>The folder or geodatabase where the output raster dataset will be stored.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Raster Dataset Name with Extension</para>
		/// <para>The name and format of the raster dataset you are creating.</para>
		/// <para>To store the output as a raster dataset in a geodatabase, do not add a file extension to the raster dataset name.</para>
		/// <para>For file-based rasters, use the appropriate extension to specify the format to create as follows:</para>
		/// <para>.tif—TIFF raster</para>
		/// <para>.img—ERDAS IMAGINE raster</para>
		/// <para>.crf—CRF raster</para>
		/// <para>No extension—Esri Grid</para>
		/// </param>
		public CreateRandomRaster(object OutPath, object OutName)
		{
			this.OutPath = OutPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Random Raster</para>
		/// </summary>
		public override string DisplayName() => "Create Random Raster";

		/// <summary>
		/// <para>Tool Name : CreateRandomRaster</para>
		/// </summary>
		public override string ToolName() => "CreateRandomRaster";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateRandomRaster</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateRandomRaster";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "pyramid" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutPath, OutName, Distribution!, RasterExtent!, Cellsize!, OutRasterDataset!, BuildRat! };

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The folder or geodatabase where the output raster dataset will be stored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutPath { get; set; }

		/// <summary>
		/// <para>Raster Dataset Name with Extension</para>
		/// <para>The name and format of the raster dataset you are creating.</para>
		/// <para>To store the output as a raster dataset in a geodatabase, do not add a file extension to the raster dataset name.</para>
		/// <para>For file-based rasters, use the appropriate extension to specify the format to create as follows:</para>
		/// <para>.tif—TIFF raster</para>
		/// <para>.img—ERDAS IMAGINE raster</para>
		/// <para>.crf—CRF raster</para>
		/// <para>No extension—Esri Grid</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Distribution</para>
		/// <para>Specifies the random value distribution method to use.</para>
		/// <para>Each type has one or two settings to control the distribution.</para>
		/// <para>Uniform—A uniform distribution with the defined range between the Minimum and Maximum values. The default values are 0.0 for Minimum and 1.0 for Maximum. This is the default.</para>
		/// <para>Integer—An integer distribution with the defined range between the Minimum and Maximum values. The default values are 1 for Minimum and 10 for Maximum.</para>
		/// <para>Normal—A normal distribution with defined Mean and Standard Deviation values. The default values are 0.0 for Mean and 1.0 for Standard Deviation.</para>
		/// <para>Exponential—An exponential distribution with a defined Mean value. The default value is 1.0.</para>
		/// <para>Poisson-—A Poisson distribution with a defined Mean value. The default value is 1.0.</para>
		/// <para>Gamma—A gamma distribution with defined Alpha and Beta values. The default values are 1.0 for Alpha and 1.0 for Beta.</para>
		/// <para>Binomial—A binomial distribution with defined N and Probability values. The default values are 10 for N and 0.5 for Probability.</para>
		/// <para>Geometric—A geometric distribution with a defined Probability value. The default value is 0.5.</para>
		/// <para>Negative Binomial—A Pascal distribution with defined r and Probability values. The default values are 10.0 for r and 0.5 for Probability.</para>
		/// <para>To edit the default value, click the value in the table and type the new value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Distribution { get; set; } = "UNIFORM 0.0 1.0";

		/// <summary>
		/// <para>Output extent</para>
		/// <para>The extent of the output raster dataset.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? RasterExtent { get; set; }

		/// <summary>
		/// <para>Cellsize</para>
		/// <para>The spatial resolution of the output raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Cellsize { get; set; }

		/// <summary>
		/// <para>Output raster dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object? OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Build raster attribute table</para>
		/// <para>Specifies whether the tool will unconditionally build a raster attribute table for the output raster in which the selected distribution results in an integer output raster.</para>
		/// <para>This parameter has no effect if the output raster is floating point.</para>
		/// <para>Checked—A raster attribute table will be unconditionally built for integer output rasters. This is the default.</para>
		/// <para>Unchecked—A raster attribute table will not be built for integer output rasters if the number of unique values is greater than or equal to 65535. If the number of unique values is less than 65535, a raster attribute table will be built.</para>
		/// <para><see cref="BuildRatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? BuildRat { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateRandomRaster SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? pyramid = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Build raster attribute table</para>
		/// </summary>
		public enum BuildRatEnum 
		{
			/// <summary>
			/// <para>Checked—A raster attribute table will be unconditionally built for integer output rasters. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD")]
			BUILD,

			/// <summary>
			/// <para>Unchecked—A raster attribute table will not be built for integer output rasters if the number of unique values is greater than or equal to 65535. If the number of unique values is less than 65535, a raster attribute table will be built.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_BUILD")]
			DO_NOT_BUILD,

		}

#endregion
	}
}
