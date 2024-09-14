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
	/// <para>Remove Files From LAS Dataset</para>
	/// <para>Remove Files From LAS Dataset</para>
	/// <para>Removes one or more LAS files and surface constraint features from a LAS dataset.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RemoveFilesFromLasDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </param>
		public RemoveFilesFromLasDataset(object InLasDataset)
		{
			this.InLasDataset = InLasDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Files From LAS Dataset</para>
		/// </summary>
		public override string DisplayName() => "Remove Files From LAS Dataset";

		/// <summary>
		/// <para>Tool Name : RemoveFilesFromLasDataset</para>
		/// </summary>
		public override string ToolName() => "RemoveFilesFromLasDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.RemoveFilesFromLasDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.RemoveFilesFromLasDataset";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, InFiles!, InSurfaceConstraints!, DerivedLasDataset!, DeletePyramid! };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>LAS Files or Folders</para>
		/// <para>The name of the LAS files or folders containing LAS files whose reference will be removed from the LAS dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? InFiles { get; set; }

		/// <summary>
		/// <para>Surface Constraints</para>
		/// <para>The name of the surface constraint features that will be removed from the LAS dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? InSurfaceConstraints { get; set; }

		/// <summary>
		/// <para>Updated LAS Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLasDatasetLayer()]
		public object? DerivedLasDataset { get; set; }

		/// <summary>
		/// <para>Delete Pyramid</para>
		/// <para>Specifies whether the LAS dataset&apos;s display pyramid will be deleted.</para>
		/// <para>Checked—The LAS dataset&apos;s display pyramid will be deleted.</para>
		/// <para>Unchecked—The LAS dataset&apos;s display pyramid will not be deleted. This is the default.</para>
		/// <para><see cref="DeletePyramidEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeletePyramid { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveFilesFromLasDataset SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Delete Pyramid</para>
		/// </summary>
		public enum DeletePyramidEnum 
		{
			/// <summary>
			/// <para>Checked—The LAS dataset&apos;s display pyramid will be deleted.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_PYRAMID")]
			DELETE_PYRAMID,

			/// <summary>
			/// <para>Unchecked—The LAS dataset&apos;s display pyramid will not be deleted. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_PYRAMID")]
			NO_DELETE_PYRAMID,

		}

#endregion
	}
}
