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
	/// <para>Tile LAS</para>
	/// <para>Creates a set of nonoverlapping LAS files whose horizontal extents are divided by a regular grid.</para>
	/// </summary>
	public class TileLas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </param>
		/// <param name="TargetFolder">
		/// <para>Target Folder</para>
		/// <para>The folder where the tiled LAS files will be written.</para>
		/// </param>
		public TileLas(object InLasDataset, object TargetFolder)
		{
			this.InLasDataset = InLasDataset;
			this.TargetFolder = TargetFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Tile LAS</para>
		/// </summary>
		public override string DisplayName() => "Tile LAS";

		/// <summary>
		/// <para>Tool Name : TileLas</para>
		/// </summary>
		public override string ToolName() => "TileLas";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TileLas</para>
		/// </summary>
		public override string ExcuteName() => "3d.TileLas";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, TargetFolder, BaseName, OutLasDataset, ComputeStats, LasVersion, PointFormat, Compression, LasOptions, TileFeature, NamingMethod, FileSize, TileWidth, TileHeight, TileOrigin, OutFolder };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Target Folder</para>
		/// <para>The folder where the tiled LAS files will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object TargetFolder { get; set; }

		/// <summary>
		/// <para>Output Base Name</para>
		/// <para>The name that each output file will begin with.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object BaseName { get; set; } = "Tile";

		/// <summary>
		/// <para>Output LAS Dataset</para>
		/// <para>The new LAS dataset that references the tiled LAS files created by this tool. This is optional.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DELasDataset()]
		public object OutLasDataset { get; set; }

		/// <summary>
		/// <para>Compute statistics</para>
		/// <para>Specifies whether statistics will be computed for the .las files referenced by the LAS dataset. Computing statistics provides a spatial index for each .las file, which improves analysis and display performance. Statistics also enhance the filtering and symbology experience by limiting the display of LAS attributes, such as classification codes and return information, to values that are present in the .las file.</para>
		/// <para>Checked—Statistics will be computed. This is the default.</para>
		/// <para>Unchecked—Statistics will not be computed.</para>
		/// <para><see cref="ComputeStatsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ComputeStats { get; set; } = "true";

		/// <summary>
		/// <para>Output Version</para>
		/// <para>Specifies the LAS file version of each output file. The default is 1.4.</para>
		/// <para>1.0—This version supported 256 unique class codes but did not have a predefined classification schema.</para>
		/// <para>1.1—This version introduced a predefined classification scheme, and point record formats 0 and 1, and the synthetic classification flag for points that were derived from a source other than a lidar sensor.</para>
		/// <para>1.2—This version featured support for GPS time and RGB records in point records 2 and 3.</para>
		/// <para>1.3—This version added support for point records 4 and 5 for waveform data. However, waveform information is not read in ArcGIS.</para>
		/// <para>1.4—This version introduced point record formats 6 through 10, along with new class definitions, 256 unique class codes, and the overlap classification flag.</para>
		/// <para><see cref="LasVersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object LasVersion { get; set; }

		/// <summary>
		/// <para>Point Format</para>
		/// <para>The point record format of the output LAS files. The available options will vary based on the LAS file version specified in the Output Version parameter.</para>
		/// <para><see cref="PointFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object PointFormat { get; set; }

		/// <summary>
		/// <para>Compression</para>
		/// <para>Specifies whether the output LAS file will be in a compressed format or the standard LAS format.</para>
		/// <para>No Compression—The output will be in the standard LAS format (*.las file). This is the default.</para>
		/// <para>zLAS Compression—Output LAS files will be compressed in the zLAS format.</para>
		/// <para><see cref="CompressionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object Compression { get; set; } = "NO_COMPRESSION";

		/// <summary>
		/// <para>LAS Options</para>
		/// <para>A list of optional modifications to the output LAS files.</para>
		/// <para>Rearrange Points—LAS points will be arranged according to their spatial clustering.</para>
		/// <para>Remove Variable Length Records—Variable-length records that are added after the header and the point records of each file will be removed.</para>
		/// <para>Remove Extra Bytes—Extra bytes that are present with each point record in the input LAS file will be removed.</para>
		/// <para><see cref="LasOptionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object LasOptions { get; set; } = "REARRANGE_POINTS";

		/// <summary>
		/// <para>Import from Feature Class</para>
		/// <para>The polygon features that define the tile width and height to be used when tiling the lidar data. The polygons are presumed to be rectangular, and the first feature's extent is used to define the tile width and height.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[Category("Tiling Options")]
		public object TileFeature { get; set; }

		/// <summary>
		/// <para>Naming Method</para>
		/// <para>Specifies the method used to provide a unique name for each output LAS file. Each file name will be appended to the text specified in the Output Base Name parameter. When input features are used to define the tiling scheme, its text or numeric field names will also be included as a source for defining the file name. The following automatically generated naming conventions are supported:</para>
		/// <para>XY Coordinates—The X and Y coordinates of the center point of each tile will be appended. This is the default.</para>
		/// <para>Rows and Columns—The tile name will be assigned based on the row and column it belongs to in the overall tiling scheme. The rows increment from the top down, while the columns increment from left to right.</para>
		/// <para>Ordinal Designation—The tile name will be assigned based on its order of creation, where 1 is the first tile, 2 is the second, and so on.</para>
		/// <para><see cref="NamingMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Tiling Options")]
		public object NamingMethod { get; set; } = "XY_COORDS";

		/// <summary>
		/// <para>Target File Size (MB)</para>
		/// <para>This value, which is expressed in megabytes, represents the upper limit of the uncompressed file size of an output LAS tile with uniform point distribution across its entire extent. The default is 250, and the value is used to estimate the tile width and height.</para>
		/// <para>The value of this parameter changes when the Tile Width and Tile Height parameters are modified. When input features are specified in the Import from Feature Class parameter, this parameter will be disabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Tiling Options")]
		public object FileSize { get; set; } = "250";

		/// <summary>
		/// <para>Tile Width</para>
		/// <para>The width of each tile. Specifying a value will update the target file size and point count if a tile height is also present. Similarly, if the target file size or point count is independently updated, the tile width and height will also be changed to reflect the size of the corresponding tile. When input features are specified in the Import from Feature Class parameter, the tile width will be derived from the height of the first feature, and this parameter will be disabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Tiling Options")]
		public object TileWidth { get; set; }

		/// <summary>
		/// <para>Tile Height</para>
		/// <para>The height of each tile. Specifying a value will update the target file size if a tile width is also present. Similarly, if the target file size is independently updated, the tile width and height will also be proportionately changed to reflect the size of the corresponding tile. When input features are specified in the Import from Feature Class parameter, the tile height will be derived from the height of the first feature, and this parameter will be disabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Tiling Options")]
		public object TileHeight { get; set; }

		/// <summary>
		/// <para>Tile Origin</para>
		/// <para>The coordinates of the origin of the tiling grid. The default values are obtained from the lower left corner of the input LAS dataset. When input features are specified in the Import from Feature Class parameter, the origin will be inherited from the lower left corner of the first feature, and this parameter will be disabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		[Category("Tiling Options")]
		public object TileOrigin { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TileLas SetEnviroment(object extent = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Compute statistics</para>
		/// </summary>
		public enum ComputeStatsEnum 
		{
			/// <summary>
			/// <para>Checked—Statistics will be computed. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPUTE_STATS")]
			COMPUTE_STATS,

			/// <summary>
			/// <para>Unchecked—Statistics will not be computed.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COMPUTE_STATS")]
			NO_COMPUTE_STATS,

		}

		/// <summary>
		/// <para>Output Version</para>
		/// </summary>
		public enum LasVersionEnum 
		{
			/// <summary>
			/// <para>1.0—This version supported 256 unique class codes but did not have a predefined classification schema.</para>
			/// </summary>
			[GPValue("1.0")]
			[Description("1.0")]
			_10,

			/// <summary>
			/// <para>1.1—This version introduced a predefined classification scheme, and point record formats 0 and 1, and the synthetic classification flag for points that were derived from a source other than a lidar sensor.</para>
			/// </summary>
			[GPValue("1.1")]
			[Description("1.1")]
			_11,

			/// <summary>
			/// <para>1.2—This version featured support for GPS time and RGB records in point records 2 and 3.</para>
			/// </summary>
			[GPValue("1.2")]
			[Description("1.2")]
			_12,

			/// <summary>
			/// <para>1.3—This version added support for point records 4 and 5 for waveform data. However, waveform information is not read in ArcGIS.</para>
			/// </summary>
			[GPValue("1.3")]
			[Description("1.3")]
			_13,

			/// <summary>
			/// <para>1.4—This version introduced point record formats 6 through 10, along with new class definitions, 256 unique class codes, and the overlap classification flag.</para>
			/// </summary>
			[GPValue("1.4")]
			[Description("1.4")]
			_14,

		}

		/// <summary>
		/// <para>Point Format</para>
		/// </summary>
		public enum PointFormatEnum 
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

		}

		/// <summary>
		/// <para>Compression</para>
		/// </summary>
		public enum CompressionEnum 
		{
			/// <summary>
			/// <para>No Compression—The output will be in the standard LAS format (*.las file). This is the default.</para>
			/// </summary>
			[GPValue("NO_COMPRESSION")]
			[Description("No Compression")]
			No_Compression,

			/// <summary>
			/// <para>zLAS Compression—Output LAS files will be compressed in the zLAS format.</para>
			/// </summary>
			[GPValue("ZLAS")]
			[Description("zLAS Compression")]
			zLAS_Compression,

		}

		/// <summary>
		/// <para>LAS Options</para>
		/// </summary>
		public enum LasOptionsEnum 
		{
			/// <summary>
			/// <para>Rearrange Points—LAS points will be arranged according to their spatial clustering.</para>
			/// </summary>
			[GPValue("REARRANGE_POINTS")]
			[Description("Rearrange Points")]
			Rearrange_Points,

			/// <summary>
			/// <para>Remove Variable Length Records—Variable-length records that are added after the header and the point records of each file will be removed.</para>
			/// </summary>
			[GPValue("REMOVE_VLR")]
			[Description("Remove Variable Length Records")]
			Remove_Variable_Length_Records,

			/// <summary>
			/// <para>Remove Extra Bytes—Extra bytes that are present with each point record in the input LAS file will be removed.</para>
			/// </summary>
			[GPValue("REMOVE_EXTRA_BYTES")]
			[Description("Remove Extra Bytes")]
			Remove_Extra_Bytes,

		}

		/// <summary>
		/// <para>Naming Method</para>
		/// </summary>
		public enum NamingMethodEnum 
		{
			/// <summary>
			/// <para>XY Coordinates—The X and Y coordinates of the center point of each tile will be appended. This is the default.</para>
			/// </summary>
			[GPValue("XY_COORDS")]
			[Description("XY Coordinates")]
			XY_Coordinates,

			/// <summary>
			/// <para>Rows and Columns—The tile name will be assigned based on the row and column it belongs to in the overall tiling scheme. The rows increment from the top down, while the columns increment from left to right.</para>
			/// </summary>
			[GPValue("ROW_COLUMN")]
			[Description("Rows and Columns")]
			Rows_and_Columns,

			/// <summary>
			/// <para>Ordinal Designation—The tile name will be assigned based on its order of creation, where 1 is the first tile, 2 is the second, and so on.</para>
			/// </summary>
			[GPValue("ORDINAL")]
			[Description("Ordinal Designation")]
			Ordinal_Designation,

		}

#endregion
	}
}
