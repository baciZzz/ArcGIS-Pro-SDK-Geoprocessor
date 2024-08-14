using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Principal Components</para>
	/// <para>Performs Principal Component Analysis (PCA) on a set of raster bands and generates a single multiband raster as output.</para>
	/// </summary>
	public class PrincipalComponents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterBands">
		/// <para>Input raster bands</para>
		/// <para>The input raster bands.</para>
		/// <para>They can be integer or floating point type.</para>
		/// </param>
		/// <param name="OutMultibandRaster">
		/// <para>Output multiband raster</para>
		/// <para>The output multiband raster dataset.</para>
		/// <para>If all of the input bands are integer type, the output raster bands will be integer. If any of the input bands are floating point, the output will be floating point.</para>
		/// <para>If the output is an Esri Grid raster, the name must have less than 10 characters.</para>
		/// </param>
		public PrincipalComponents(object InRasterBands, object OutMultibandRaster)
		{
			this.InRasterBands = InRasterBands;
			this.OutMultibandRaster = OutMultibandRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Principal Components</para>
		/// </summary>
		public override string DisplayName => "Principal Components";

		/// <summary>
		/// <para>Tool Name : PrincipalComponents</para>
		/// </summary>
		public override string ToolName => "PrincipalComponents";

		/// <summary>
		/// <para>Tool Excute Name : sa.PrincipalComponents</para>
		/// </summary>
		public override string ExcuteName => "sa.PrincipalComponents";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRasterBands, OutMultibandRaster, NumberComponents, OutDataFile };

		/// <summary>
		/// <para>Input raster bands</para>
		/// <para>The input raster bands.</para>
		/// <para>They can be integer or floating point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain()]
		public object InRasterBands { get; set; }

		/// <summary>
		/// <para>Output multiband raster</para>
		/// <para>The output multiband raster dataset.</para>
		/// <para>If all of the input bands are integer type, the output raster bands will be integer. If any of the input bands are floating point, the output will be floating point.</para>
		/// <para>If the output is an Esri Grid raster, the name must have less than 10 characters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutMultibandRaster { get; set; }

		/// <summary>
		/// <para>Number of Principal components</para>
		/// <para>Number of principal components.</para>
		/// <para>The number must be greater than zero and less than or equal to the total number of input raster bands.</para>
		/// <para>The default is the total number of rasters in the input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object NumberComponents { get; set; }

		/// <summary>
		/// <para>Output data file</para>
		/// <para>Output ASCII data file storing principal component parameters.</para>
		/// <para>The output data file records the correlation and covariance matrices, the eigenvalues and eigenvectors, the percent variance each eigenvalue captures, and the accumulative variance described by the eigenvalues.</para>
		/// <para>The extension for the output file can be .txt or .asc.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object OutDataFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PrincipalComponents SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
