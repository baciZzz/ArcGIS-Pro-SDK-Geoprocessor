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
	/// <para>Band Collection Statistics</para>
	/// <para>Band Collection Statistics</para>
	/// <para>Calculates the statistics for a set of raster bands.</para>
	/// </summary>
	public class BandCollectionStats : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterBands">
		/// <para>Input raster bands</para>
		/// <para>The input raster bands.</para>
		/// <para>They can be integer or floating point type.</para>
		/// </param>
		/// <param name="OutStatFile">
		/// <para>Output statistics file</para>
		/// <para>The output ASCII file containing the statistics.</para>
		/// <para>A .txt extension is required.</para>
		/// </param>
		public BandCollectionStats(object InRasterBands, object OutStatFile)
		{
			this.InRasterBands = InRasterBands;
			this.OutStatFile = OutStatFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Band Collection Statistics</para>
		/// </summary>
		public override string DisplayName() => "Band Collection Statistics";

		/// <summary>
		/// <para>Tool Name : BandCollectionStats</para>
		/// </summary>
		public override string ToolName() => "BandCollectionStats";

		/// <summary>
		/// <para>Tool Excute Name : sa.BandCollectionStats</para>
		/// </summary>
		public override string ExcuteName() => "sa.BandCollectionStats";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasterBands, OutStatFile, ComputeMatrices! };

		/// <summary>
		/// <para>Input raster bands</para>
		/// <para>The input raster bands.</para>
		/// <para>They can be integer or floating point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasterBands { get; set; }

		/// <summary>
		/// <para>Output statistics file</para>
		/// <para>The output ASCII file containing the statistics.</para>
		/// <para>A .txt extension is required.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TXT", "ASC")]
		public object OutStatFile { get; set; }

		/// <summary>
		/// <para>Compute covariance and correlation matrices</para>
		/// <para>Specifies whether covariance and correlation matrices are calculated.</para>
		/// <para>Unchecked—Only the basic statistical measures (minimum, maximum, mean, and standard deviation) will be calculated for every layer. This is the default.</para>
		/// <para>Checked—In addition to the standard statistics calculated, the covariance and correlation matrices will also be determined.</para>
		/// <para><see cref="ComputeMatricesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ComputeMatrices { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BandCollectionStats SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Compute covariance and correlation matrices</para>
		/// </summary>
		public enum ComputeMatricesEnum 
		{
			/// <summary>
			/// <para>Unchecked—Only the basic statistical measures (minimum, maximum, mean, and standard deviation) will be calculated for every layer. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("BRIEF")]
			BRIEF,

			/// <summary>
			/// <para>Checked—In addition to the standard statistics calculated, the covariance and correlation matrices will also be determined.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DETAILED")]
			DETAILED,

		}

#endregion
	}
}
