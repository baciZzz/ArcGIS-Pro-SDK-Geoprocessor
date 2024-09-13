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
	/// <para>Colorize LAS</para>
	/// <para>Colorize LAS</para>
	/// <para>Applies colors and near-infrared values from orthographic imagery  to LAS points.</para>
	/// </summary>
	public class ColorizeLas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </param>
		/// <param name="InImage">
		/// <para>Input Image</para>
		/// <para>The image that will be used to assign colors to LAS points.</para>
		/// </param>
		/// <param name="Bands">
		/// <para>Band Assignment</para>
		/// <para>The bands from the input image that will be assigned to the color channels associated with the output LAS points.</para>
		/// </param>
		/// <param name="TargetFolder">
		/// <para>Target Folder</para>
		/// <para>The existing folder to which the output .las files will be written.</para>
		/// </param>
		public ColorizeLas(object InLasDataset, object InImage, object Bands, object TargetFolder)
		{
			this.InLasDataset = InLasDataset;
			this.InImage = InImage;
			this.Bands = Bands;
			this.TargetFolder = TargetFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Colorize LAS</para>
		/// </summary>
		public override string DisplayName() => "Colorize LAS";

		/// <summary>
		/// <para>Tool Name : ColorizeLas</para>
		/// </summary>
		public override string ToolName() => "ColorizeLas";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ColorizeLas</para>
		/// </summary>
		public override string ExcuteName() => "3d.ColorizeLas";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, InImage, Bands, TargetFolder, NameSuffix!, LasVersion!, PointFormat!, Compression!, RearrangePoints!, ComputeStats!, OutLasDataset!, OutputFolder! };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Input Image</para>
		/// <para>The image that will be used to assign colors to LAS points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InImage { get; set; }

		/// <summary>
		/// <para>Band Assignment</para>
		/// <para>The bands from the input image that will be assigned to the color channels associated with the output LAS points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Bands { get; set; }

		/// <summary>
		/// <para>Target Folder</para>
		/// <para>The existing folder to which the output .las files will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object TargetFolder { get; set; }

		/// <summary>
		/// <para>Output File Name Suffix</para>
		/// <para>The text that will be appended to the name of each output .las file. Each file will inherit its base name from its source file, followed by the suffix specified in this parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("LAS File Options")]
		public object? NameSuffix { get; set; } = "_colorized";

		/// <summary>
		/// <para>LAS File Version</para>
		/// <para>The LAS version of the output files being created.</para>
		/// <para>LAS 1.2 Files—LAS file version 1.2 will be created.</para>
		/// <para>LAS 1.3 Files—LAS file version 1.3 will be created.</para>
		/// <para>LAS 1.4 Files—LAS file version 1.4 will be created. This is the default.</para>
		/// <para><see cref="LasVersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object? LasVersion { get; set; } = "1.4";

		/// <summary>
		/// <para>Point Format</para>
		/// <para>The point record format of the output LAS files.</para>
		/// <para>2—Point record format 2.</para>
		/// <para>3—Point record format 3 supports the storage of GPS time.</para>
		/// <para>7—Point record format 7. This is the default value and is only available for LAS version 1.4</para>
		/// <para>8—Point record format 8 supports the storage of near-infrared values. This is only available for LAS version 1.4.</para>
		/// <para><see cref="PointFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object? PointFormat { get; set; } = "7";

		/// <summary>
		/// <para>Compression</para>
		/// <para>Specifies whether the output .las file will be in a compressed format or the standard LAS format.</para>
		/// <para>No Compression—The output will be in the standard LAS format (*.las file). This is the default.</para>
		/// <para>zLAS Compression—Output .las files will be compressed in the zLAS format.</para>
		/// <para><see cref="CompressionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object? Compression { get; set; } = "NO_COMPRESSION";

		/// <summary>
		/// <para>Rearrange Points</para>
		/// <para>Specifies whether points in the .las files will be rearranged.</para>
		/// <para>Unchecked—The order of the points in the .las files will not be rearranged.</para>
		/// <para>Checked—The points in the .las files will be rearranged. This is the default.</para>
		/// <para><see cref="RearrangePointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object? RearrangePoints { get; set; } = "true";

		/// <summary>
		/// <para>Compute Statistics</para>
		/// <para>Specifies whether statistics will be computed for the .las files referenced by the LAS dataset. Computing statistics provides a spatial index for each .las file, which improves analysis and display performance. Statistics also enhance the filtering and symbology experience by limiting the display of LAS attributes, such as classification codes and return information, to values that are present in the .las file.</para>
		/// <para>Checked—Statistics will be computed. This is the default.</para>
		/// <para>Unchecked—Statistics will not be computed.</para>
		/// <para><see cref="ComputeStatsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object? ComputeStats { get; set; } = "true";

		/// <summary>
		/// <para>Output LAS Dataset</para>
		/// <para>The output LAS dataset referencing the newly created .las files.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DELasDataset()]
		public object? OutLasDataset { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object? OutputFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ColorizeLas SetEnviroment(object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>LAS File Version</para>
		/// </summary>
		public enum LasVersionEnum 
		{
			/// <summary>
			/// <para>LAS 1.2 Files—LAS file version 1.2 will be created.</para>
			/// </summary>
			[GPValue("1.2")]
			[Description("LAS 1.2 Files")]
			LAS_12_Files,

			/// <summary>
			/// <para>LAS 1.3 Files—LAS file version 1.3 will be created.</para>
			/// </summary>
			[GPValue("1.3")]
			[Description("LAS 1.3 Files")]
			LAS_13_Files,

			/// <summary>
			/// <para>LAS 1.4 Files—LAS file version 1.4 will be created. This is the default.</para>
			/// </summary>
			[GPValue("1.4")]
			[Description("LAS 1.4 Files")]
			LAS_14_Files,

		}

		/// <summary>
		/// <para>Point Format</para>
		/// </summary>
		public enum PointFormatEnum 
		{
			/// <summary>
			/// <para>7—Point record format 7. This is the default value and is only available for LAS version 1.4</para>
			/// </summary>
			[GPValue("7")]
			[Description("7")]
			_7,

			/// <summary>
			/// <para>8—Point record format 8 supports the storage of near-infrared values. This is only available for LAS version 1.4.</para>
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
			/// <para>zLAS Compression—Output .las files will be compressed in the zLAS format.</para>
			/// </summary>
			[GPValue("ZLAS")]
			[Description("zLAS Compression")]
			zLAS_Compression,

		}

		/// <summary>
		/// <para>Rearrange Points</para>
		/// </summary>
		public enum RearrangePointsEnum 
		{
			/// <summary>
			/// <para>Checked—The points in the .las files will be rearranged. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REARRANGE_POINTS")]
			REARRANGE_POINTS,

			/// <summary>
			/// <para>Unchecked—The order of the points in the .las files will not be rearranged.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_REARRANGE_POINTS")]
			NO_REARRANGE_POINTS,

		}

		/// <summary>
		/// <para>Compute Statistics</para>
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

#endregion
	}
}
