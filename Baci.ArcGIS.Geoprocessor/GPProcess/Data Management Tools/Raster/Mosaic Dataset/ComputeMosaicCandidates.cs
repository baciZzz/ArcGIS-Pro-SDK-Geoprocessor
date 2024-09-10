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
	/// <para>Compute Mosaic Candidates</para>
	/// <para>Finds the image candidates within in the mosaic dataset that best represents the mosaic area.</para>
	/// </summary>
	public class ComputeMosaicCandidates : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input mosaic dataset</para>
		/// <para>The input mosaic dataset with densely overlapped images.</para>
		/// </param>
		public ComputeMosaicCandidates(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Compute Mosaic Candidates</para>
		/// </summary>
		public override string DisplayName() => "Compute Mosaic Candidates";

		/// <summary>
		/// <para>Tool Name : ComputeMosaicCandidates</para>
		/// </summary>
		public override string ToolName() => "ComputeMosaicCandidates";

		/// <summary>
		/// <para>Tool Excute Name : management.ComputeMosaicCandidates</para>
		/// </summary>
		public override string ExcuteName() => "management.ComputeMosaicCandidates";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, MaximumOverlap, MaximumAreaLoss, OutMosaicDataset };

		/// <summary>
		/// <para>Input mosaic dataset</para>
		/// <para>The input mosaic dataset with densely overlapped images.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Maximum Area Overlap</para>
		/// <para>The maximum amount of overlap that you want between the mosaic dataset and the footprint of each image in the mosaic dataset. If the percentage of overlap is higher than this threshold, the image is excluded since it will have too much redundant information.</para>
		/// <para>The percentage is expressed as a decimal. For example, a maximum overlap of 60 percent is expressed as 0.6.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MaximumOverlap { get; set; } = "0.6";

		/// <summary>
		/// <para>Maximum Area Loss Allowed</para>
		/// <para>This is the maximum percentage of area that can be excluded by the candidate images. After the tool chooses the best candidate images based on the Maximum Area Overlap, it will then check to see if the maximum excluded area is below the threshold specified. If the excluded area is greater than the specified threshold, the tool will add more candidate images to fill in some of the voids that were missing. Most of these excluded areas will likely be along the border of the mosaic dataset.</para>
		/// <para>The percentage is expressed as a decimal. For example, a maximum excluded area of 5 percent is expressed as 0.05.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MaximumAreaLoss { get; set; } = "0.05";

		/// <summary>
		/// <para>Derived Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ComputeMosaicCandidates SetEnviroment(object parallelProcessingFactor = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
