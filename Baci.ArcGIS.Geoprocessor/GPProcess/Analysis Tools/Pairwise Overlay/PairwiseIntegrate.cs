using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Pairwise Integrate</para>
	/// <para>Pairwise Integrate</para>
	/// <para>Analyzes the coordinate locations of feature vertices among features in one or more feature classes. Those that fall within a specified distance of one another are assumed to represent the same location and are assigned a common coordinate value (in other words, they are colocated). The tool also adds vertices where feature vertices are within the x,y tolerance of an edge and where line segments intersect.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class PairwiseIntegrate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The feature classes to be integrated. When the distance between features is small in comparison to the tolerance, the vertices or points will be clustered (moved to be coincident).</para>
		/// </param>
		public PairwiseIntegrate(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Pairwise Integrate</para>
		/// </summary>
		public override string DisplayName() => "Pairwise Integrate";

		/// <summary>
		/// <para>Tool Name : PairwiseIntegrate</para>
		/// </summary>
		public override string ToolName() => "PairwiseIntegrate";

		/// <summary>
		/// <para>Tool Excute Name : analysis.PairwiseIntegrate</para>
		/// </summary>
		public override string ExcuteName() => "analysis.PairwiseIntegrate";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYTolerance", "extent", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ClusterTolerance!, OutFeatures! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The feature classes to be integrated. When the distance between features is small in comparison to the tolerance, the vertices or points will be clustered (moved to be coincident).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>The distance that determines the range in which feature vertices are made coincident. To minimize undesired movement of vertices, the x,y tolerance should be fairly small. If no value is specified, the xy tolerance from the first dataset in the list of inputs will be used.</para>
		/// <para>Changing this parameter&apos;s value may cause failure or unexpected results. It is recommended that you do not modify this parameter. It has been removed from view on the tool dialog box. By default, the input feature class&apos;s spatial reference x,y tolerance property is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? ClusterTolerance { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PairwiseIntegrate SetEnviroment(object? XYTolerance = null , object? extent = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(XYTolerance: XYTolerance, extent: extent, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

	}
}
