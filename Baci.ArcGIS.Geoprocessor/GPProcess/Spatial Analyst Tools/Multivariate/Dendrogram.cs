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
	/// <para>Dendrogram</para>
	/// <para>Dendrogram</para>
	/// <para>Constructs a tree diagram (dendrogram) showing attribute distances between sequentially merged classes in a signature file.</para>
	/// </summary>
	public class Dendrogram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSignatureFile">
		/// <para>Input signature file</para>
		/// <para>Input signature file whose class signatures are used to produce a dendrogram.</para>
		/// <para>A .gsg extension is required.</para>
		/// </param>
		/// <param name="OutDendrogramFile">
		/// <para>Output dendrogram file</para>
		/// <para>The output dendrogram ASCII file.</para>
		/// <para>The extension can be .txt or .asc.</para>
		/// </param>
		public Dendrogram(object InSignatureFile, object OutDendrogramFile)
		{
			this.InSignatureFile = InSignatureFile;
			this.OutDendrogramFile = OutDendrogramFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Dendrogram</para>
		/// </summary>
		public override string DisplayName() => "Dendrogram";

		/// <summary>
		/// <para>Tool Name : Dendrogram</para>
		/// </summary>
		public override string ToolName() => "Dendrogram";

		/// <summary>
		/// <para>Tool Excute Name : sa.Dendrogram</para>
		/// </summary>
		public override string ExcuteName() => "sa.Dendrogram";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSignatureFile, OutDendrogramFile, DistanceCalculation, LineWidth };

		/// <summary>
		/// <para>Input signature file</para>
		/// <para>Input signature file whose class signatures are used to produce a dendrogram.</para>
		/// <para>A .gsg extension is required.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("GSG")]
		public object InSignatureFile { get; set; }

		/// <summary>
		/// <para>Output dendrogram file</para>
		/// <para>The output dendrogram ASCII file.</para>
		/// <para>The extension can be .txt or .asc.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TXT", "ASC")]
		public object OutDendrogramFile { get; set; }

		/// <summary>
		/// <para>Use variance in distance calculations</para>
		/// <para>Specifies the manner in which the distances between classes in multidimensional attribute space are defined.</para>
		/// <para>Checked—The distances between classes will be computed based on the variances and the Euclidean distance between the means of their signatures.</para>
		/// <para>Unchecked—The distances between classes will be determined by the Euclidean distances between the means of the class signatures only.</para>
		/// <para><see cref="DistanceCalculationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DistanceCalculation { get; set; } = "true";

		/// <summary>
		/// <para>Line width of dendrogram</para>
		/// <para>Sets the width of the dendrogram in number of characters on a line.</para>
		/// <para>The default is 78.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object LineWidth { get; set; } = "78";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Dendrogram SetEnviroment(object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Use variance in distance calculations</para>
		/// </summary>
		public enum DistanceCalculationEnum 
		{
			/// <summary>
			/// <para>Checked—The distances between classes will be computed based on the variances and the Euclidean distance between the means of their signatures.</para>
			/// </summary>
			[GPValue("true")]
			[Description("VARIANCE")]
			VARIANCE,

			/// <summary>
			/// <para>Unchecked—The distances between classes will be determined by the Euclidean distances between the means of the class signatures only.</para>
			/// </summary>
			[GPValue("false")]
			[Description("MEAN_ONLY")]
			MEAN_ONLY,

		}

#endregion
	}
}
