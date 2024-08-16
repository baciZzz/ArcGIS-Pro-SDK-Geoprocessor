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
	/// <para>Thin LAS</para>
	/// <para>Creates new LAS files that contain a subset of LAS points from the input LAS dataset.</para>
	/// </summary>
	public class ThinLas : AbstractGPProcess
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
		/// <para>The existing folder to which the output .las files will be written.</para>
		/// </param>
		/// <param name="ThinningDimension">
		/// <para>Thinning Dimension</para>
		/// <para>The type of thinning operation that will be conducted.</para>
		/// <para>2D—Thinning will occur in tiles defined along the x,y-axis.</para>
		/// <para>3D—Thinning will occur in volumes of space defined by tiles along the x,y-axis, and height gradients along the z-axis. This is the default.</para>
		/// <para><see cref="ThinningDimensionEnum"/></para>
		/// </param>
		/// <param name="XyResolution">
		/// <para>Target XY Resolution</para>
		/// <para>The size of each side of the thinning tile along the x,y-axis.</para>
		/// </param>
		public ThinLas(object InLasDataset, object TargetFolder, object ThinningDimension, object XyResolution)
		{
			this.InLasDataset = InLasDataset;
			this.TargetFolder = TargetFolder;
			this.ThinningDimension = ThinningDimension;
			this.XyResolution = XyResolution;
		}

		/// <summary>
		/// <para>Tool Display Name : Thin LAS</para>
		/// </summary>
		public override string DisplayName => "Thin LAS";

		/// <summary>
		/// <para>Tool Name : ThinLas</para>
		/// </summary>
		public override string ToolName => "ThinLas";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ThinLas</para>
		/// </summary>
		public override string ExcuteName => "3d.ThinLas";

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
		public override string[] ValidEnvironments => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InLasDataset, TargetFolder, ThinningDimension, XyResolution, ZResolution, PointSelectionMethod, ClassCodesWeights, NameSuffix, OutLasDataset, PreservedClassCodes, PreservedFlags, PreservedReturns, ExcludedClassCodes, ExcludedFlags, ExcludedReturns, Compression, RemoveVlr, RearrangePoints, ComputeStats, OutputFolder };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Target Folder</para>
		/// <para>The existing folder to which the output .las files will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object TargetFolder { get; set; }

		/// <summary>
		/// <para>Thinning Dimension</para>
		/// <para>The type of thinning operation that will be conducted.</para>
		/// <para>2D—Thinning will occur in tiles defined along the x,y-axis.</para>
		/// <para>3D—Thinning will occur in volumes of space defined by tiles along the x,y-axis, and height gradients along the z-axis. This is the default.</para>
		/// <para><see cref="ThinningDimensionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ThinningDimension { get; set; } = "3D";

		/// <summary>
		/// <para>Target XY Resolution</para>
		/// <para>The size of each side of the thinning tile along the x,y-axis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		public object XyResolution { get; set; }

		/// <summary>
		/// <para>Target Z Resolution</para>
		/// <para>The height of each thinning region when using the 3D thinning method.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object ZResolution { get; set; }

		/// <summary>
		/// <para>Point Selection Method</para>
		/// <para>The method used to determine which points are retained in each thinning region.</para>
		/// <para>Closest to Center—The LAS point that is closest to the center of the region being thinned. This is the default.</para>
		/// <para>Class Code Weights—The LAS points with the class code that has the highest weight assigned.</para>
		/// <para>Most Frequent Class Code—The LAS points with the most frequent class code value in the region being thinned.</para>
		/// <para>Lowest Point—The lowest LAS point in the region being thinned.</para>
		/// <para>Highest Point—The highest LAS point in the region being thinned.</para>
		/// <para>Lowest and Highest Point—The highest and lowest LAS points in the region being thinned.</para>
		/// <para>Closest to Average Height—The LAS point whose height is closest to the average of height of all points in the region being thinned.</para>
		/// <para>Lowest Intensity—The LAS point whose intensity value is the lowest among the points in the region being thinned.</para>
		/// <para>Highest Intensity—The LAS point whose intensity value is the highest among the points in the region being thinned.</para>
		/// <para>Lowest and Highest Intensity—The two LAS points with the lowest and the highest intensity values among the points in the region being thinned.</para>
		/// <para>Closest to Average Intensity—The LAS point whose intensity value is closest to the average of all intensity values from points in the region being thinned.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PointSelectionMethod { get; set; } = "CLOSEST_TO_CENTER";

		/// <summary>
		/// <para>Input Class Codes and Weights</para>
		/// <para>The weights assigned to each class code that determine which points are retained in each thinning region. This parameter is only enabled when the Class Code Weights option is specified in the Point Selection Method parameter. The class code with the highest weight will be retained in the thinning region. If two class codes with the same weight exist in a given thinning region, the class code with the smallest point source ID will be retained.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object ClassCodesWeights { get; set; }

		/// <summary>
		/// <para>Output File Name Suffix</para>
		/// <para>The name added to each output file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object NameSuffix { get; set; } = "thinned";

		/// <summary>
		/// <para>Output LAS Dataset</para>
		/// <para>The output LAS dataset referencing the newly created .las files.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DELasDataset()]
		public object OutLasDataset { get; set; }

		/// <summary>
		/// <para>Preserved Classes</para>
		/// <para>The input LAS points with the specified class code values will not be thinned from the output LAS files.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 255)]
		[Category("Points To Preserve")]
		public object PreservedClassCodes { get; set; }

		/// <summary>
		/// <para>Preserved Flags</para>
		/// <para>The input LAS points with the specified class flag designations will be preserved in the output LAS files.</para>
		/// <para>Model Key—Points with the model key class flag will be preserved.</para>
		/// <para>Overlap—Points with the overlap class flag will be preserved.</para>
		/// <para>Synthetic—Points with the synthetic class flag will be preserved.</para>
		/// <para>Withheld—Points with the withheld class flag will be preserved.</para>
		/// <para><see cref="PreservedFlagsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Points To Preserve")]
		public object PreservedFlags { get; set; }

		/// <summary>
		/// <para>Preserved Returns</para>
		/// <para>The input LAS points with the specified returns will be preserved in the output LAS files.</para>
		/// <para>Single returns—All single return points will be included.</para>
		/// <para>Last returns—All single and last returns will be included.</para>
		/// <para>First of many returns—All points that are the first of multiple returns will be included.</para>
		/// <para>Last of many returns—All points that are the last of multiple returns will be included.</para>
		/// <para><see cref="PreservedReturnsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Points To Preserve")]
		public object PreservedReturns { get; set; }

		/// <summary>
		/// <para>Excluded Classes</para>
		/// <para>The input LAS points with the specified class code values will be excluded from the output LAS files.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 255)]
		[Category("Points To Exclude")]
		public object ExcludedClassCodes { get; set; }

		/// <summary>
		/// <para>Excluded Flags</para>
		/// <para>The input LAS points with the specified class flag designations will be excluded from the output LAS files.</para>
		/// <para>Model Key—Points with the model key class flag will be excluded.</para>
		/// <para>Overlap—Points with the overlap class flag will be excluded.</para>
		/// <para>Synthetic—Points with the synthetic class flag will be excluded.</para>
		/// <para>Withheld—Points with the withheld class flag will be excluded.</para>
		/// <para><see cref="ExcludedFlagsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Points To Exclude")]
		public object ExcludedFlags { get; set; }

		/// <summary>
		/// <para>Excluded Returns</para>
		/// <para>The input LAS points with the specified returns will be excluded from the output LAS files.</para>
		/// <para>Single returns—All single return points will be excluded.</para>
		/// <para>Last returns—All single and last returns will be excluded.</para>
		/// <para>First of many returns—All points that are the first of multiple returns will be excluded.</para>
		/// <para>Last of many returns—All points that are the last of multiple returns will be excluded.</para>
		/// <para><see cref="ExcludedReturnsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Points To Exclude")]
		public object ExcludedReturns { get; set; }

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
		public object Compression { get; set; } = "NO_COMPRESSION";

		/// <summary>
		/// <para>Remove Variable Length Records</para>
		/// <para>Indicates whether variable length records stored with the input LAS points will be preserved or eliminated in the output LAS data.</para>
		/// <para>Unchecked—Variable length records will be maintained in the output LAS points. This is the default.</para>
		/// <para>Checked—Variable length records will be removed from the output LAS points.</para>
		/// <para><see cref="RemoveVlrEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object RemoveVlr { get; set; } = "false";

		/// <summary>
		/// <para>Rearrange LAS Points</para>
		/// <para>Indicates if LAS points will be stored in spatially organized clusters.</para>
		/// <para>Unchecked—The order of the points in the LAS files will remain the same.</para>
		/// <para>Checked—The points in the LAS files will be rearranged. This is the default.</para>
		/// <para><see cref="RearrangePointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object RearrangePoints { get; set; } = "true";

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
		public object ComputeStats { get; set; } = "true";

		/// <summary>
		/// <para>Output Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ThinLas SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Thinning Dimension</para>
		/// </summary>
		public enum ThinningDimensionEnum 
		{
			/// <summary>
			/// <para>2D—Thinning will occur in tiles defined along the x,y-axis.</para>
			/// </summary>
			[GPValue("2D")]
			[Description("2D")]
			_2D,

			/// <summary>
			/// <para>3D—Thinning will occur in volumes of space defined by tiles along the x,y-axis, and height gradients along the z-axis. This is the default.</para>
			/// </summary>
			[GPValue("3D")]
			[Description("3D")]
			_3D,

		}

		/// <summary>
		/// <para>Preserved Flags</para>
		/// </summary>
		public enum PreservedFlagsEnum 
		{
			/// <summary>
			/// <para>Model Key—Points with the model key class flag will be preserved.</para>
			/// </summary>
			[GPValue("MODEL_KEY")]
			[Description("Model Key")]
			Model_Key,

			/// <summary>
			/// <para>Overlap—Points with the overlap class flag will be preserved.</para>
			/// </summary>
			[GPValue("OVERLAP")]
			[Description("Overlap")]
			Overlap,

			/// <summary>
			/// <para>Synthetic—Points with the synthetic class flag will be preserved.</para>
			/// </summary>
			[GPValue("SYNTHETIC")]
			[Description("Synthetic")]
			Synthetic,

			/// <summary>
			/// <para>Withheld—Points with the withheld class flag will be preserved.</para>
			/// </summary>
			[GPValue("WITHHELD")]
			[Description("Withheld")]
			Withheld,

		}

		/// <summary>
		/// <para>Preserved Returns</para>
		/// </summary>
		public enum PreservedReturnsEnum 
		{
			/// <summary>
			/// <para>Single returns—All single return points will be included.</para>
			/// </summary>
			[GPValue("SINGLE")]
			[Description("Single returns")]
			Single_returns,

			/// <summary>
			/// <para>Last returns—All single and last returns will be included.</para>
			/// </summary>
			[GPValue("LAST")]
			[Description("Last returns")]
			Last_returns,

			/// <summary>
			/// <para>First of many returns—All points that are the first of multiple returns will be included.</para>
			/// </summary>
			[GPValue("FIRST_OF_MANY")]
			[Description("First of many returns")]
			First_of_many_returns,

			/// <summary>
			/// <para>Last of many returns—All points that are the last of multiple returns will be included.</para>
			/// </summary>
			[GPValue("LAST_OF_MANY")]
			[Description("Last of many returns")]
			Last_of_many_returns,

		}

		/// <summary>
		/// <para>Excluded Flags</para>
		/// </summary>
		public enum ExcludedFlagsEnum 
		{
			/// <summary>
			/// <para>Model Key—Points with the model key class flag will be excluded.</para>
			/// </summary>
			[GPValue("MODEL_KEY")]
			[Description("Model Key")]
			Model_Key,

			/// <summary>
			/// <para>Overlap—Points with the overlap class flag will be excluded.</para>
			/// </summary>
			[GPValue("OVERLAP")]
			[Description("Overlap")]
			Overlap,

			/// <summary>
			/// <para>Synthetic—Points with the synthetic class flag will be excluded.</para>
			/// </summary>
			[GPValue("SYNTHETIC")]
			[Description("Synthetic")]
			Synthetic,

			/// <summary>
			/// <para>Withheld—Points with the withheld class flag will be excluded.</para>
			/// </summary>
			[GPValue("WITHHELD")]
			[Description("Withheld")]
			Withheld,

		}

		/// <summary>
		/// <para>Excluded Returns</para>
		/// </summary>
		public enum ExcludedReturnsEnum 
		{
			/// <summary>
			/// <para>Single returns—All single return points will be excluded.</para>
			/// </summary>
			[GPValue("SINGLE")]
			[Description("Single returns")]
			Single_returns,

			/// <summary>
			/// <para>Last returns—All single and last returns will be excluded.</para>
			/// </summary>
			[GPValue("LAST")]
			[Description("Last returns")]
			Last_returns,

			/// <summary>
			/// <para>First of many returns—All points that are the first of multiple returns will be excluded.</para>
			/// </summary>
			[GPValue("FIRST_OF_MANY")]
			[Description("First of many returns")]
			First_of_many_returns,

			/// <summary>
			/// <para>Last of many returns—All points that are the last of multiple returns will be excluded.</para>
			/// </summary>
			[GPValue("LAST_OF_MANY")]
			[Description("Last of many returns")]
			Last_of_many_returns,

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
		/// <para>Remove Variable Length Records</para>
		/// </summary>
		public enum RemoveVlrEnum 
		{
			/// <summary>
			/// <para>Checked—Variable length records will be removed from the output LAS points.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE_VLR")]
			REMOVE_VLR,

			/// <summary>
			/// <para>Unchecked—Variable length records will be maintained in the output LAS points. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("MAINTAIN_VLR")]
			MAINTAIN_VLR,

		}

		/// <summary>
		/// <para>Rearrange LAS Points</para>
		/// </summary>
		public enum RearrangePointsEnum 
		{
			/// <summary>
			/// <para>Checked—The points in the LAS files will be rearranged. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REARRANGE_POINTS")]
			REARRANGE_POINTS,

			/// <summary>
			/// <para>Unchecked—The order of the points in the LAS files will remain the same.</para>
			/// </summary>
			[GPValue("false")]
			[Description("MAINTAIN_POINTS")]
			MAINTAIN_POINTS,

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
