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
	/// <para>Edit Signatures</para>
	/// <para>Edits and updates a signature file by merging, renumbering, and deleting class signatures.</para>
	/// </summary>
	public class EditSignatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterBands">
		/// <para>Input raster bands</para>
		/// <para>The input raster bands for which to edit the signatures.</para>
		/// <para>They can be integer or floating point type.</para>
		/// </param>
		/// <param name="InSignatureFile">
		/// <para>Input signature file</para>
		/// <para>Input signature file whose class signatures are to be edited.</para>
		/// <para>A .gsg extension is required.</para>
		/// </param>
		/// <param name="InSignatureRemapFile">
		/// <para>Input signature remap file</para>
		/// <para>Input ASCII remap table containing the class IDs to be merged, renumbered, or deleted.</para>
		/// <para>The extension can be .rmp, .asc or .txt. The default is .rmp.</para>
		/// </param>
		/// <param name="OutSignatureFile">
		/// <para>Output signature file</para>
		/// <para>The output signature file.</para>
		/// <para>A .gsg extension must be specified.</para>
		/// </param>
		public EditSignatures(object InRasterBands, object InSignatureFile, object InSignatureRemapFile, object OutSignatureFile)
		{
			this.InRasterBands = InRasterBands;
			this.InSignatureFile = InSignatureFile;
			this.InSignatureRemapFile = InSignatureRemapFile;
			this.OutSignatureFile = OutSignatureFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Edit Signatures</para>
		/// </summary>
		public override string DisplayName => "Edit Signatures";

		/// <summary>
		/// <para>Tool Name : EditSignatures</para>
		/// </summary>
		public override string ToolName => "EditSignatures";

		/// <summary>
		/// <para>Tool Excute Name : sa.EditSignatures</para>
		/// </summary>
		public override string ExcuteName => "sa.EditSignatures";

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
		public override object[] Parameters => new object[] { InRasterBands, InSignatureFile, InSignatureRemapFile, OutSignatureFile, SampleInterval };

		/// <summary>
		/// <para>Input raster bands</para>
		/// <para>The input raster bands for which to edit the signatures.</para>
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
		/// <para>Input signature file</para>
		/// <para>Input signature file whose class signatures are to be edited.</para>
		/// <para>A .gsg extension is required.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("GSG")]
		public object InSignatureFile { get; set; }

		/// <summary>
		/// <para>Input signature remap file</para>
		/// <para>Input ASCII remap table containing the class IDs to be merged, renumbered, or deleted.</para>
		/// <para>The extension can be .rmp, .asc or .txt. The default is .rmp.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("RMP", "TXT", "ASC")]
		public object InSignatureRemapFile { get; set; }

		/// <summary>
		/// <para>Output signature file</para>
		/// <para>The output signature file.</para>
		/// <para>A .gsg extension must be specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("GSG")]
		public object OutSignatureFile { get; set; }

		/// <summary>
		/// <para>Sample interval</para>
		/// <para>The interval to be used for sampling.</para>
		/// <para>The default is 10.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object SampleInterval { get; set; } = "10";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EditSignatures SetEnviroment(object cellSize = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

	}
}
