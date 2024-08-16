using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Reclass by ASCII File</para>
	/// <para>Reclassifies (or changes) the values of the input cells of a raster using an ASCII remap file.</para>
	/// </summary>
	public class ReclassByASCIIFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster to be reclassified.</para>
		/// </param>
		/// <param name="InRemapFile">
		/// <para>Input ASCII remap file</para>
		/// <para>ASCII remap file defining the single values or ranges to be reclassified and the values they will become.</para>
		/// <para>Allowed extensions for the ASCII remap files are .rmp, .txt, and .asc.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output reclassified raster.</para>
		/// <para>The output will always be of integer type.</para>
		/// </param>
		public ReclassByASCIIFile(object InRaster, object InRemapFile, object OutRaster)
		{
			this.InRaster = InRaster;
			this.InRemapFile = InRemapFile;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Reclass by ASCII File</para>
		/// </summary>
		public override string DisplayName => "Reclass by ASCII File";

		/// <summary>
		/// <para>Tool Name : ReclassByASCIIFile</para>
		/// </summary>
		public override string ToolName => "ReclassByASCIIFile";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ReclassByASCIIFile</para>
		/// </summary>
		public override string ExcuteName => "3d.ReclassByASCIIFile";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, InRemapFile, OutRaster, MissingValues };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster to be reclassified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Input ASCII remap file</para>
		/// <para>ASCII remap file defining the single values or ranges to be reclassified and the values they will become.</para>
		/// <para>Allowed extensions for the ASCII remap files are .rmp, .txt, and .asc.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("RMP", "TXT", "ASC")]
		public object InRemapFile { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output reclassified raster.</para>
		/// <para>The output will always be of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Change missing values to NoData</para>
		/// <para>Denotes whether missing values in the reclass file retain their value or get mapped to NoData.</para>
		/// <para>Unchecked—Signifies that if any cell location on the input raster contains a value that is not present or reclassed in the remap file, the value should remain intact and be written for that location to the output raster. This is the default.</para>
		/// <para>Checked—Signifies that if any cell location on the input raster contains a value that is not present or reclassed in the remap file, the value will be reclassed to NoData for that location on the output raster.</para>
		/// <para><see cref="MissingValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MissingValues { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReclassByASCIIFile SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Change missing values to NoData</para>
		/// </summary>
		public enum MissingValuesEnum 
		{
			/// <summary>
			/// <para>Unchecked—Signifies that if any cell location on the input raster contains a value that is not present or reclassed in the remap file, the value should remain intact and be written for that location to the output raster. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DATA")]
			DATA,

			/// <summary>
			/// <para>Checked—Signifies that if any cell location on the input raster contains a value that is not present or reclassed in the remap file, the value will be reclassed to NoData for that location on the output raster.</para>
			/// </summary>
			[GPValue("true")]
			[Description("NODATA")]
			NODATA,

		}

#endregion
	}
}
