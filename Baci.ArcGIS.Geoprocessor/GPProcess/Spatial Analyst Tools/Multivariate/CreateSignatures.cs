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
	/// <para>Create Signatures</para>
	/// <para>Creates an ASCII signature file of classes defined by input sample data and a set of raster bands.</para>
	/// </summary>
	public class CreateSignatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterBands">
		/// <para>Input raster bands</para>
		/// <para>The input raster bands for which to create the signatures.</para>
		/// <para>They can be integer or floating point type.</para>
		/// </param>
		/// <param name="InSampleData">
		/// <para>Input raster or feature sample data</para>
		/// <para>The input delineating the set of class samples.</para>
		/// <para>The input can be an integer raster or a feature dataset.</para>
		/// </param>
		/// <param name="OutSignatureFile">
		/// <para>Output signature file</para>
		/// <para>The output signature file.</para>
		/// <para>A .gsg extension must be specified.</para>
		/// </param>
		public CreateSignatures(object InRasterBands, object InSampleData, object OutSignatureFile)
		{
			this.InRasterBands = InRasterBands;
			this.InSampleData = InSampleData;
			this.OutSignatureFile = OutSignatureFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Signatures</para>
		/// </summary>
		public override string DisplayName => "Create Signatures";

		/// <summary>
		/// <para>Tool Name : CreateSignatures</para>
		/// </summary>
		public override string ToolName => "CreateSignatures";

		/// <summary>
		/// <para>Tool Excute Name : sa.CreateSignatures</para>
		/// </summary>
		public override string ExcuteName => "sa.CreateSignatures";

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
		public override string[] ValidEnvironments => new string[] { "cellSize", "cellSizeProjectionMethod", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRasterBands, InSampleData, OutSignatureFile, ComputeCovariance, SampleField };

		/// <summary>
		/// <para>Input raster bands</para>
		/// <para>The input raster bands for which to create the signatures.</para>
		/// <para>They can be integer or floating point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain()]
		public object InRasterBands { get; set; }

		/// <summary>
		/// <para>Input raster or feature sample data</para>
		/// <para>The input delineating the set of class samples.</para>
		/// <para>The input can be an integer raster or a feature dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InSampleData { get; set; }

		/// <summary>
		/// <para>Output signature file</para>
		/// <para>The output signature file.</para>
		/// <para>A .gsg extension must be specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutSignatureFile { get; set; }

		/// <summary>
		/// <para>Compute covariance matrices</para>
		/// <para>Specifies whether covariance matrices in addition to the means are calculated.</para>
		/// <para>Checked—Both the covariance matrices and the means for all classes of the input sample data will be computed. This is the default.</para>
		/// <para>Unchecked—Only the means for all classes of the input sample data will be calculated.</para>
		/// <para><see cref="ComputeCovarianceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ComputeCovariance { get; set; } = "true";

		/// <summary>
		/// <para>Sample field</para>
		/// <para>Field of the input raster or feature sample data to assign values to the sampled locations (classes).</para>
		/// <para>Only integer or string fields are valid fields. The specified number or string will be used as the Class name in the output signature file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object SampleField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateSignatures SetEnviroment(object cellSize = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Compute covariance matrices</para>
		/// </summary>
		public enum ComputeCovarianceEnum 
		{
			/// <summary>
			/// <para>Checked—Both the covariance matrices and the means for all classes of the input sample data will be computed. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("COVARIANCE")]
			COVARIANCE,

			/// <summary>
			/// <para>Unchecked—Only the means for all classes of the input sample data will be calculated.</para>
			/// </summary>
			[GPValue("false")]
			[Description("MEAN_ONLY")]
			MEAN_ONLY,

		}

#endregion
	}
}
