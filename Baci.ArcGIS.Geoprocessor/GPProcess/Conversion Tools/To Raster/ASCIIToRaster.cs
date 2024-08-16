using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>ASCII To Raster</para>
	/// <para>Converts an ASCII file representing raster data to a raster dataset.</para>
	/// </summary>
	[Obsolete()]
	public class ASCIIToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InAsciiFile">
		/// <para>Input ASCII raster file</para>
		/// <para>The input ASCII file to be converted.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster dataset to be created.</para>
		/// <para>If the output raster will not be saved to a geodatabase, specify .tif for TIFF file format, .CRF for CRF file format, .img for ERDAS IMAGINE file format, or no extension for Esri Grid raster format.</para>
		/// </param>
		public ASCIIToRaster(object InAsciiFile, object OutRaster)
		{
			this.InAsciiFile = InAsciiFile;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : ASCII To Raster</para>
		/// </summary>
		public override string DisplayName => "ASCII To Raster";

		/// <summary>
		/// <para>Tool Name : ASCIIToRaster</para>
		/// </summary>
		public override string ToolName => "ASCIIToRaster";

		/// <summary>
		/// <para>Tool Excute Name : conversion.ASCIIToRaster</para>
		/// </summary>
		public override string ExcuteName => "conversion.ASCIIToRaster";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "compression", "configKeyword", "pyramid", "rasterStatistics", "scratchWorkspace", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InAsciiFile, OutRaster, DataType };

		/// <summary>
		/// <para>Input ASCII raster file</para>
		/// <para>The input ASCII file to be converted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TXT", "ASC")]
		public object InAsciiFile { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster dataset to be created.</para>
		/// <para>If the output raster will not be saved to a geodatabase, specify .tif for TIFF file format, .CRF for CRF file format, .img for ERDAS IMAGINE file format, or no extension for Esri Grid raster format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output data type</para>
		/// <para>Specifies the data type of the output raster dataset.</para>
		/// <para>Integer—An integer raster dataset will be created.</para>
		/// <para>Float—A floating-point raster dataset will be created.</para>
		/// <para><see cref="DataTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DataType { get; set; } = "INTEGER";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ASCIIToRaster SetEnviroment(int? autoCommit = null , object compression = null , object configKeyword = null , object pyramid = null , object rasterStatistics = null , object scratchWorkspace = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, compression: compression, configKeyword: configKeyword, pyramid: pyramid, rasterStatistics: rasterStatistics, scratchWorkspace: scratchWorkspace, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output data type</para>
		/// </summary>
		public enum DataTypeEnum 
		{
			/// <summary>
			/// <para>Integer—An integer raster dataset will be created.</para>
			/// </summary>
			[GPValue("INTEGER")]
			[Description("Integer")]
			Integer,

			/// <summary>
			/// <para>Float—A floating-point raster dataset will be created.</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("Float")]
			Float,

		}

#endregion
	}
}
