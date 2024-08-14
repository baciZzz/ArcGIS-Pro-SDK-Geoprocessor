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
	/// <para>Convert LAS</para>
	/// <para>Converts LAS format files between different compression methods, file versions,  and  point record formats.</para>
	/// </summary>
	public class ConvertLas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLas">
		/// <para>Input LAS</para>
		/// <para>The LAS data that will be converted. A folder can be specified to process all of the .las files contained therein.</para>
		/// </param>
		/// <param name="TargetFolder">
		/// <para>Target Folder</para>
		/// <para>The existing folder to which the output .las files will be written.</para>
		/// </param>
		public ConvertLas(object InLas, object TargetFolder)
		{
			this.InLas = InLas;
			this.TargetFolder = TargetFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Convert LAS</para>
		/// </summary>
		public override string DisplayName => "Convert LAS";

		/// <summary>
		/// <para>Tool Name : ConvertLas</para>
		/// </summary>
		public override string ToolName => "ConvertLas";

		/// <summary>
		/// <para>Tool Excute Name : conversion.ConvertLas</para>
		/// </summary>
		public override string ExcuteName => "conversion.ConvertLas";

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
		public override string[] ValidEnvironments => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InLas, TargetFolder, FileVersion, PointFormat, Compression, LasOptions, OutLasDataset, DefineCoordinateSystem, InCoordinateSystem };

		/// <summary>
		/// <para>Input LAS</para>
		/// <para>The LAS data that will be converted. A folder can be specified to process all of the .las files contained therein.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InLas { get; set; }

		/// <summary>
		/// <para>Target Folder</para>
		/// <para>The existing folder to which the output .las files will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object TargetFolder { get; set; }

		/// <summary>
		/// <para>File Version</para>
		/// <para>The LAS format file version of the output files.</para>
		/// <para>Same As Input—The output file version will be the same as the input. This is the default.</para>
		/// <para>1.0—The base version for the LAS format that supported 256 class codes.</para>
		/// <para>1.1—The output file version will be 1.1. Class codes were reduced to 32, but support for classification flags was added.</para>
		/// <para>1.2—The output file version will be 1.2. Support for red-green-blue (RGB) color channels and GPS time was added.</para>
		/// <para>1.3—The output file version will be 1.3. Storage of lidar waveform data for point record formats that are not supported in the ArcGIS platform was added.</para>
		/// <para>1.4— The output file version will be 1.4. Support for coordinate system definition using Well Known Text (WKT) convention, 256 class codes, up to 15 discrete returns per pulse, higher precision scan angle, and overlap classification flag was added.</para>
		/// <para><see cref="FileVersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FileVersion { get; set; } = "SAME_AS_INPUT";

		/// <summary>
		/// <para>Point Format</para>
		/// <para>Specifies the point record format of the output .las files. The available options will vary based on the output LAS format file version.</para>
		/// <para>0—The base type for storing discrete LAS points that supports attributes such as lidar intensity, return values, scan angle, scan direction, and edge of flight line.</para>
		/// <para>1—GPS time is added to the attributes supported in point format 0.</para>
		/// <para>2—RGB values are added to the attributes supported in point format 0.</para>
		/// <para>3—RGB values and GPS time are added to the attributes supported in point format 0.</para>
		/// <para>6—The preferred base type for storing discrete LAS points in LAS file version 1.4.</para>
		/// <para>7—RGB values are added to the attributes supported in point format 6.</para>
		/// <para>8—RGB and near-infrared values are added to the attributes supported in point format 6.</para>
		/// <para><see cref="PointFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PointFormat { get; set; }

		/// <summary>
		/// <para>Compression</para>
		/// <para>Specifies whether the output .las file will be in a compressed format or the standard LAS format.</para>
		/// <para>No Compression—The output will be in the standard LAS format (*.las). This is the default.</para>
		/// <para>zLAS Compression—Output .las files will be compressed in the zLAS format (*.zlas).</para>
		/// <para>LAZ Compression—Output .las files will be compressed in the LAZ format (*.laz).</para>
		/// <para><see cref="CompressionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Compression { get; set; } = "NO_COMPRESSION";

		/// <summary>
		/// <para>LAS Options</para>
		/// <para>Specifies modifications that will be made to reduce the size of the output .las files and improve their usability and performance in display and analysis operations.</para>
		/// <para>Rearrange Points—Points will be rearranged to improve display and analysis performance. Statistics will be automatically computed during this process. This is the default.</para>
		/// <para>Remove Variable Length Records—Variable-length records that are added after the header as well as the points records of each file will be removed.</para>
		/// <para>Remove Extra Bytes—Extra bytes that may be present with each point from the input file will be removed.</para>
		/// <para><see cref="LasOptionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object LasOptions { get; set; } = "REARRANGE_POINTS";

		/// <summary>
		/// <para>Output LAS Dataset</para>
		/// <para>The output LAS dataset referencing the newly created .las files.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DELasDataset()]
		public object OutLasDataset { get; set; }

		/// <summary>
		/// <para>Define Input Coordinate System</para>
		/// <para>Specifies whether the spatial reference of input .las files will be defined by the Define Input Coordinate System parameter.</para>
		/// <para>No LAS Files—The spatial reference of input .las files will not be defined as an input argument. This is the default.</para>
		/// <para>All LAS Files—The spatial reference of input .las files will be defined as an input argument.</para>
		/// <para>LAS Files with No Spatial Reference—The spatial reference of input .las files that have no projection information in the header will be defined.</para>
		/// <para><see cref="DefineCoordinateSystemEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DefineCoordinateSystem { get; set; } = "NO_FILES";

		/// <summary>
		/// <para>Input Coordinate System</para>
		/// <para>The coordinate system that will be used to define the spatial reference of the input .las files. This parameter is only active if the Define Input Coordinate System parameter is set to All LAS Files or LAS Files with No Spatial Reference.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object InCoordinateSystem { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConvertLas SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>File Version</para>
		/// </summary>
		public enum FileVersionEnum 
		{
			/// <summary>
			/// <para>Same As Input—The output file version will be the same as the input. This is the default.</para>
			/// </summary>
			[GPValue("SAME_AS_INPUT")]
			[Description("Same As Input")]
			Same_As_Input,

			/// <summary>
			/// <para>1.0—The base version for the LAS format that supported 256 class codes.</para>
			/// </summary>
			[GPValue("1.0")]
			[Description("1.0")]
			_10,

			/// <summary>
			/// <para>1.1—The output file version will be 1.1. Class codes were reduced to 32, but support for classification flags was added.</para>
			/// </summary>
			[GPValue("1.1")]
			[Description("1.1")]
			_11,

			/// <summary>
			/// <para>1.2—The output file version will be 1.2. Support for red-green-blue (RGB) color channels and GPS time was added.</para>
			/// </summary>
			[GPValue("1.2")]
			[Description("1.2")]
			_12,

			/// <summary>
			/// <para>1.3—The output file version will be 1.3. Storage of lidar waveform data for point record formats that are not supported in the ArcGIS platform was added.</para>
			/// </summary>
			[GPValue("1.3")]
			[Description("1.3")]
			_13,

			/// <summary>
			/// <para>1.4— The output file version will be 1.4. Support for coordinate system definition using Well Known Text (WKT) convention, 256 class codes, up to 15 discrete returns per pulse, higher precision scan angle, and overlap classification flag was added.</para>
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
			/// <para>0—The base type for storing discrete LAS points that supports attributes such as lidar intensity, return values, scan angle, scan direction, and edge of flight line.</para>
			/// </summary>
			[GPValue("0")]
			[Description("0")]
			_0,

			/// <summary>
			/// <para>1—GPS time is added to the attributes supported in point format 0.</para>
			/// </summary>
			[GPValue("1")]
			[Description("1")]
			_1,

			/// <summary>
			/// <para>2—RGB values are added to the attributes supported in point format 0.</para>
			/// </summary>
			[GPValue("2")]
			[Description("2")]
			_2,

			/// <summary>
			/// <para>3—RGB values and GPS time are added to the attributes supported in point format 0.</para>
			/// </summary>
			[GPValue("3")]
			[Description("3")]
			_3,

			/// <summary>
			/// <para>6—The preferred base type for storing discrete LAS points in LAS file version 1.4.</para>
			/// </summary>
			[GPValue("6")]
			[Description("6")]
			_6,

			/// <summary>
			/// <para>7—RGB values are added to the attributes supported in point format 6.</para>
			/// </summary>
			[GPValue("7")]
			[Description("7")]
			_7,

			/// <summary>
			/// <para>8—RGB and near-infrared values are added to the attributes supported in point format 6.</para>
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
			/// <para>No Compression—The output will be in the standard LAS format (*.las). This is the default.</para>
			/// </summary>
			[GPValue("NO_COMPRESSION")]
			[Description("No Compression")]
			No_Compression,

			/// <summary>
			/// <para>zLAS Compression—Output .las files will be compressed in the zLAS format (*.zlas).</para>
			/// </summary>
			[GPValue("ZLAS")]
			[Description("zLAS Compression")]
			zLAS_Compression,

			/// <summary>
			/// <para>LAZ Compression—Output .las files will be compressed in the LAZ format (*.laz).</para>
			/// </summary>
			[GPValue("LAZ")]
			[Description("LAZ Compression")]
			LAZ_Compression,

		}

		/// <summary>
		/// <para>LAS Options</para>
		/// </summary>
		public enum LasOptionsEnum 
		{
			/// <summary>
			/// <para>Rearrange Points—Points will be rearranged to improve display and analysis performance. Statistics will be automatically computed during this process. This is the default.</para>
			/// </summary>
			[GPValue("REARRANGE_POINTS")]
			[Description("Rearrange Points")]
			Rearrange_Points,

			/// <summary>
			/// <para>Remove Variable Length Records—Variable-length records that are added after the header as well as the points records of each file will be removed.</para>
			/// </summary>
			[GPValue("REMOVE_VLR")]
			[Description("Remove Variable Length Records")]
			Remove_Variable_Length_Records,

			/// <summary>
			/// <para>Remove Extra Bytes—Extra bytes that may be present with each point from the input file will be removed.</para>
			/// </summary>
			[GPValue("REMOVE_EXTRA_BYTES")]
			[Description("Remove Extra Bytes")]
			Remove_Extra_Bytes,

		}

		/// <summary>
		/// <para>Define Input Coordinate System</para>
		/// </summary>
		public enum DefineCoordinateSystemEnum 
		{
			/// <summary>
			/// <para>No LAS Files—The spatial reference of input .las files will not be defined as an input argument. This is the default.</para>
			/// </summary>
			[GPValue("NO_FILES")]
			[Description("No LAS Files")]
			No_LAS_Files,

			/// <summary>
			/// <para>All LAS Files—The spatial reference of input .las files will be defined as an input argument.</para>
			/// </summary>
			[GPValue("ALL_FILES")]
			[Description("All LAS Files")]
			All_LAS_Files,

			/// <summary>
			/// <para>LAS Files with No Spatial Reference—The spatial reference of input .las files that have no projection information in the header will be defined.</para>
			/// </summary>
			[GPValue("FILES_MISSING_PROJECTION")]
			[Description("LAS Files with No Spatial Reference")]
			LAS_Files_with_No_Spatial_Reference,

		}

#endregion
	}
}
