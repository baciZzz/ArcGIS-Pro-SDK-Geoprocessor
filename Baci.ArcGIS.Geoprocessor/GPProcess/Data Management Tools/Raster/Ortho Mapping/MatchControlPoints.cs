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
	/// <para>Match Control Points</para>
	/// <para>Creates matching tie points for a given ground control point and initial tie point in one of the overlapping images.</para>
	/// </summary>
	public class MatchControlPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>The mosaic dataset that contains the source imagery from which the tie points will be created.</para>
		/// </param>
		/// <param name="InControlPoints">
		/// <para>Input Control Points</para>
		/// <para>The input control point set that contains a list of ground control point features and at least one initial tie point for each ground control point.</para>
		/// </param>
		/// <param name="OutControlPoints">
		/// <para>Output Control Point Table</para>
		/// <para>The output control point features that contain ground control points.</para>
		/// </param>
		public MatchControlPoints(object InMosaicDataset, object InControlPoints, object OutControlPoints)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.InControlPoints = InControlPoints;
			this.OutControlPoints = OutControlPoints;
		}

		/// <summary>
		/// <para>Tool Display Name : Match Control Points</para>
		/// </summary>
		public override string DisplayName => "Match Control Points";

		/// <summary>
		/// <para>Tool Name : MatchControlPoints</para>
		/// </summary>
		public override string ToolName => "MatchControlPoints";

		/// <summary>
		/// <para>Tool Excute Name : management.MatchControlPoints</para>
		/// </summary>
		public override string ExcuteName => "management.MatchControlPoints";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InMosaicDataset, InControlPoints, OutControlPoints, Similarity! };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>The mosaic dataset that contains the source imagery from which the tie points will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Input Control Points</para>
		/// <para>The input control point set that contains a list of ground control point features and at least one initial tie point for each ground control point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InControlPoints { get; set; }

		/// <summary>
		/// <para>Output Control Point Table</para>
		/// <para>The output control point features that contain ground control points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutControlPoints { get; set; }

		/// <summary>
		/// <para>Similarity</para>
		/// <para>Specifies the similarity level that will be used for matching tie points.</para>
		/// <para>Low similarity—The similarity criteria for the two matching points will be low. This option will produce the most matching points, but some of the matches may have a higher level of error.</para>
		/// <para>Medium similarity—The similarity criteria for the matching points will be medium.</para>
		/// <para>High similarity—The similarity criteria for the matching points will be high. This option will produce the fewest matching points, but each match will have a lower level of error.</para>
		/// <para><see cref="SimilarityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Similarity { get; set; } = "HIGH";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MatchControlPoints SetEnviroment(object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Similarity</para>
		/// </summary>
		public enum SimilarityEnum 
		{
			/// <summary>
			/// <para>Low similarity—The similarity criteria for the two matching points will be low. This option will produce the most matching points, but some of the matches may have a higher level of error.</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("Low similarity")]
			Low_similarity,

			/// <summary>
			/// <para>Medium similarity—The similarity criteria for the matching points will be medium.</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("Medium similarity")]
			Medium_similarity,

			/// <summary>
			/// <para>High similarity—The similarity criteria for the matching points will be high. This option will produce the fewest matching points, but each match will have a lower level of error.</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("High similarity")]
			High_similarity,

		}

#endregion
	}
}
