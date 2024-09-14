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
	/// <para>Raster to NetCDF</para>
	/// <para>Raster to NetCDF</para>
	/// <para>Converts a raster dataset to a netCDF file.</para>
	/// </summary>
	public class RasterToNetCDF : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The input raster dataset.</para>
		/// </param>
		/// <param name="OutNetcdfFile">
		/// <para>Output netCDF File</para>
		/// <para>The output netCDF file. The file name must have an .nc extension.</para>
		/// </param>
		public RasterToNetCDF(object InRaster, object OutNetcdfFile)
		{
			this.InRaster = InRaster;
			this.OutNetcdfFile = OutNetcdfFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Raster to NetCDF</para>
		/// </summary>
		public override string DisplayName() => "Raster to NetCDF";

		/// <summary>
		/// <para>Tool Name : RasterToNetCDF</para>
		/// </summary>
		public override string ToolName() => "RasterToNetCDF";

		/// <summary>
		/// <para>Tool Excute Name : md.RasterToNetCDF</para>
		/// </summary>
		public override string ExcuteName() => "md.RasterToNetCDF";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutNetcdfFile, Variable!, VariableUnits!, XDimension!, YDimension!, BandDimension!, FieldsToDimensions!, CompressionLevel! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The input raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output netCDF File</para>
		/// <para>The output netCDF file. The file name must have an .nc extension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object OutNetcdfFile { get; set; }

		/// <summary>
		/// <para>Variable</para>
		/// <para>The netCDF variable name that will be used in the output netCDF file. This variable will contain the values of cells in the input raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Variable { get; set; }

		/// <summary>
		/// <para>Variable Units</para>
		/// <para>The units of the data contained within the variable. The variable name is specified in the Variable parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? VariableUnits { get; set; }

		/// <summary>
		/// <para>X Dimension</para>
		/// <para>The netCDF dimension name that will be used to specify x, or longitude, coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? XDimension { get; set; }

		/// <summary>
		/// <para>Y Dimension</para>
		/// <para>The netCDF dimension name that will be used to specify y, or latitude, coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? YDimension { get; set; }

		/// <summary>
		/// <para>Band Dimension</para>
		/// <para>The netCDF dimension name that will be used to specify bands.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? BandDimension { get; set; }

		/// <summary>
		/// <para>Fields to Dimensions</para>
		/// <para>The field or fields used to create dimensions in the netCDF file.</para>
		/// <para>Field—A field in the input raster attribute table.</para>
		/// <para>Dimension—The netCDF dimension name</para>
		/// <para>Units—The units of the data represented by the field</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? FieldsToDimensions { get; set; }

		/// <summary>
		/// <para>Compression Level</para>
		/// <para>The level at which the output netCDF file will be compressed. The default value is 0, which implies no compression. A value of 9 represents maximum compression.</para>
		/// <para><see cref="CompressionLevelEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object? CompressionLevel { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterToNetCDF SetEnviroment(object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Compression Level</para>
		/// </summary>
		public enum CompressionLevelEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("0")]
			[Description("0")]
			_0,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("1")]
			[Description("1")]
			_1,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("2")]
			[Description("2")]
			_2,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("3")]
			[Description("3")]
			_3,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("4")]
			[Description("4")]
			_4,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("5")]
			[Description("5")]
			_5,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("6")]
			[Description("6")]
			_6,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("7")]
			[Description("7")]
			_7,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("8")]
			[Description("8")]
			_8,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("9")]
			[Description("9")]
			_9,

		}

#endregion
	}
}
