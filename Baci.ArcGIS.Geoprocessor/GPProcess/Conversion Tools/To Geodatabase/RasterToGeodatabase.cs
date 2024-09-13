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
	/// <para>Raster To Geodatabase</para>
	/// <para>Raster To Geodatabase</para>
	/// <para>Loads multiple raster datasets into a geodatabase.</para>
	/// </summary>
	public class RasterToGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputRasters">
		/// <para>Input Rasters</para>
		/// <para>Input raster dataset(s).</para>
		/// </param>
		/// <param name="OutputGeodatabase">
		/// <para>Output Geodatabase</para>
		/// <para>The path and name of a geodatabase.</para>
		/// </param>
		public RasterToGeodatabase(object InputRasters, object OutputGeodatabase)
		{
			this.InputRasters = InputRasters;
			this.OutputGeodatabase = OutputGeodatabase;
		}

		/// <summary>
		/// <para>Tool Display Name : Raster To Geodatabase</para>
		/// </summary>
		public override string DisplayName() => "Raster To Geodatabase";

		/// <summary>
		/// <para>Tool Name : RasterToGeodatabase</para>
		/// </summary>
		public override string ToolName() => "RasterToGeodatabase";

		/// <summary>
		/// <para>Tool Excute Name : conversion.RasterToGeodatabase</para>
		/// </summary>
		public override string ExcuteName() => "conversion.RasterToGeodatabase";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "ZDomain", "ZResolution", "compression", "configKeyword", "extent", "outputCoordinateSystem", "outputZFlag", "pyramid", "rasterStatistics", "scratchWorkspace", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputRasters, OutputGeodatabase, ConfigurationKeyword!, DerivedGeodatabase! };

		/// <summary>
		/// <para>Input Rasters</para>
		/// <para>Input raster dataset(s).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputRasters { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// <para>The path and name of a geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object OutputGeodatabase { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>The storage parameters (configuration) for a geodatabase. Configuration keywords are set up by your database administrator.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ConfigurationKeyword { get; set; }

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? DerivedGeodatabase { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterToGeodatabase SetEnviroment(object? XYDomain = null , object? ZDomain = null , object? ZResolution = null , object? compression = null , object? configKeyword = null , object? extent = null , object? outputCoordinateSystem = null , object? outputZFlag = null , object? pyramid = null , object? rasterStatistics = null , object? scratchWorkspace = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, ZDomain: ZDomain, ZResolution: ZResolution, compression: compression, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputZFlag: outputZFlag, pyramid: pyramid, rasterStatistics: rasterStatistics, scratchWorkspace: scratchWorkspace, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
