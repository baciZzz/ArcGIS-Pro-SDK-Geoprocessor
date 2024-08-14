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
	/// <para>Set LAS Class Codes Using Features</para>
	/// <para>Classifies LAS points that intersect the two-dimensional extent of input features.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class SetLasClassCodesUsingFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </param>
		/// <param name="FeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>One or more input features that will be used to define class code values for the lidar files referenced by the LAS dataset. The classification flag options default to No change but can be assigned by choosing Set or removed by choosing Clear. Each feature has the following options:</para>
		/// <para>Features—The features used for reclassifying LAS points.</para>
		/// <para>Buffer Distance—The distance that input features are buffered by prior to determining the LAS points that intersect the buffered area.</para>
		/// <para>New Class—The class code to be assigned.</para>
		/// <para>Synthetic—The Synthetic classification flag is used to identify points that were not obtained from a lidar sensor but were included in the .las file, such as survey control points that may not have been captured by the lidar sensor.</para>
		/// <para>KeyPoint—The Model Key Point classification flag represents a subset of points that are required to capture a particular level of detail in the lidar collection. Historically, this flag was associated with representing thinned ground points within a specific z-tolerance.</para>
		/// <para>Withheld—The Withheld classification flag signifies erroneous data that should be excluded from analysis and visualization.</para>
		/// <para>Overlap—The Overlap designation identifies points from overlapping scans and is only supported in LAS 1.4 files.</para>
		/// </param>
		public SetLasClassCodesUsingFeatures(object InLasDataset, object FeatureClass)
		{
			this.InLasDataset = InLasDataset;
			this.FeatureClass = FeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Set LAS Class Codes Using Features</para>
		/// </summary>
		public override string DisplayName => "Set LAS Class Codes Using Features";

		/// <summary>
		/// <para>Tool Name : SetLasClassCodesUsingFeatures</para>
		/// </summary>
		public override string ToolName => "SetLasClassCodesUsingFeatures";

		/// <summary>
		/// <para>Tool Excute Name : 3d.SetLasClassCodesUsingFeatures</para>
		/// </summary>
		public override string ExcuteName => "3d.SetLasClassCodesUsingFeatures";

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
		public override string[] ValidEnvironments => new string[] { "extent", "geographicTransformations", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InLasDataset, FeatureClass, ComputeStats, DerivedLasDataset, UpdatePyramid };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>One or more input features that will be used to define class code values for the lidar files referenced by the LAS dataset. The classification flag options default to No change but can be assigned by choosing Set or removed by choosing Clear. Each feature has the following options:</para>
		/// <para>Features—The features used for reclassifying LAS points.</para>
		/// <para>Buffer Distance—The distance that input features are buffered by prior to determining the LAS points that intersect the buffered area.</para>
		/// <para>New Class—The class code to be assigned.</para>
		/// <para>Synthetic—The Synthetic classification flag is used to identify points that were not obtained from a lidar sensor but were included in the .las file, such as survey control points that may not have been captured by the lidar sensor.</para>
		/// <para>KeyPoint—The Model Key Point classification flag represents a subset of points that are required to capture a particular level of detail in the lidar collection. Historically, this flag was associated with representing thinned ground points within a specific z-tolerance.</para>
		/// <para>Withheld—The Withheld classification flag signifies erroneous data that should be excluded from analysis and visualization.</para>
		/// <para>Overlap—The Overlap designation identifies points from overlapping scans and is only supported in LAS 1.4 files.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object FeatureClass { get; set; }

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
		/// <para>Updated Input LAS Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLasDatasetLayer()]
		public object DerivedLasDataset { get; set; }

		/// <summary>
		/// <para>Update pyramid</para>
		/// <para>Specifies whether the LAS dataset pyramid will be updated after the class codes are modified.</para>
		/// <para>Checked—The LAS dataset pyramid will be updated. This is the default.</para>
		/// <para>Unchecked—The LAS dataset pyramid will not be updated.</para>
		/// <para><see cref="UpdatePyramidEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UpdatePyramid { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetLasClassCodesUsingFeatures SetEnviroment(object extent = null , object geographicTransformations = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, workspace: workspace);
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
		/// <para>Update pyramid</para>
		/// </summary>
		public enum UpdatePyramidEnum 
		{
			/// <summary>
			/// <para>Checked—The LAS dataset pyramid will be updated. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_PYRAMID")]
			UPDATE_PYRAMID,

			/// <summary>
			/// <para>Unchecked—The LAS dataset pyramid will not be updated.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UPDATE_PYRAMID")]
			NO_UPDATE_PYRAMID,

		}

#endregion
	}
}
