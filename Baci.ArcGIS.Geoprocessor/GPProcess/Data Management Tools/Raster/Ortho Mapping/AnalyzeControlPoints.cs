using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Analyze Control Points</para>
	/// <para>Analyze Control Points</para>
	/// <para>Analyzes the control point</para>
	/// <para>coverage and identifies the areas that need</para>
	/// <para>additional control points to improve the block adjust result.</para>
	/// </summary>
	public class AnalyzeControlPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>The input mosaic dataset against which to analyze the control points.</para>
		/// </param>
		/// <param name="InControlPoints">
		/// <para>Input Control Points</para>
		/// <para>The input control point feature class.</para>
		/// <para>It is normally created from the Compute Tie Points or the Compute Control Points tool.</para>
		/// </param>
		/// <param name="OutCoverageTable">
		/// <para>Output Control Point Coverage Feature Class</para>
		/// <para>A polygon feature class output that contains the control point coverage and the percentage of the area within the corresponding image.</para>
		/// </param>
		public AnalyzeControlPoints(object InMosaicDataset, object InControlPoints, object OutCoverageTable)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.InControlPoints = InControlPoints;
			this.OutCoverageTable = OutCoverageTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Analyze Control Points</para>
		/// </summary>
		public override string DisplayName() => "Analyze Control Points";

		/// <summary>
		/// <para>Tool Name : AnalyzeControlPoints</para>
		/// </summary>
		public override string ToolName() => "AnalyzeControlPoints";

		/// <summary>
		/// <para>Tool Excute Name : management.AnalyzeControlPoints</para>
		/// </summary>
		public override string ExcuteName() => "management.AnalyzeControlPoints";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, InControlPoints, OutCoverageTable, OutOverlapTable!, InMaskDataset!, MinimumArea!, MaximumLevel! };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>The input mosaic dataset against which to analyze the control points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Input Control Points</para>
		/// <para>The input control point feature class.</para>
		/// <para>It is normally created from the Compute Tie Points or the Compute Control Points tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InControlPoints { get; set; }

		/// <summary>
		/// <para>Output Control Point Coverage Feature Class</para>
		/// <para>A polygon feature class output that contains the control point coverage and the percentage of the area within the corresponding image.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutCoverageTable { get; set; }

		/// <summary>
		/// <para>Output Overlap Feature Class</para>
		/// <para>A polygon feature class output that contains all the overlap areas between images.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutOverlapTable { get; set; }

		/// <summary>
		/// <para>Input Mask</para>
		/// <para>A polygon feature class used to exclude areas that you do not want in the analysis of the control points computation.</para>
		/// <para>A field with a name of mask can control the inclusion or exclusion of areas. A value of 1 indicates that the areas defined by the polygons (inside) will be excluded from the computation. A value of 2 indicates the defined polygons (inside) will be included in the computation while areas outside of the polygons will be excluded.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object? InMaskDataset { get; set; }

		/// <summary>
		/// <para>Minimum Overlap Area</para>
		/// <para>Specify the minimum percent that the overlap area must be, in relation to the image. Areas that are lower than the specified percent threshold will be excluded from the analysis.</para>
		/// <para>Ensure that you do not have areas that are too small; otherwise, you will have small slivers being analyzed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinimumArea { get; set; } = "0.2";

		/// <summary>
		/// <para>Maximum Overlap Level</para>
		/// <para>The maximum number of images that can be overlapped when analyzing the control points.</para>
		/// <para>For example, if there are four images in your mosaic dataset, and a maximum overlap value of 3 was specified, then there are ten different combinations that will appear in the Overlap Window. If the four images were named i1, i2, i3, and i4, the ten combinations that would appear are [i1, i2, i3], [i1 i2 i4], [i1 i3 i4], [i2 i3 i4], [i1, i2], [i1, i3], [i1, i4], [i2, i3], [i2, i4], and [i3, i4].</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaximumLevel { get; set; } = "2";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AnalyzeControlPoints SetEnviroment(object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
