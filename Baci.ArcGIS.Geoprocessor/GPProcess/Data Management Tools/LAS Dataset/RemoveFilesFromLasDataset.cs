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
	/// <para>从 LAS 数据集移除文件</para>
	/// <para>从 LAS 数据集移除一个或多个 LAS 文件和表面约束要素。</para>
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
		/// <para>待处理的 LAS 数据集。</para>
		/// </param>
		public RemoveFilesFromLasDataset(object InLasDataset)
		{
			this.InLasDataset = InLasDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 从 LAS 数据集移除文件</para>
		/// </summary>
		public override string DisplayName() => "从 LAS 数据集移除文件";

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
		public override object[] Parameters() => new object[] { InLasDataset, InFiles, InSurfaceConstraints, DerivedLasDataset, DeletePyramid };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>LAS Files or Folders</para>
		/// <para>LAS 文件或包含要从 LAS 数据集移除参考的 LAS 文件的文件夹的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object InFiles { get; set; }

		/// <summary>
		/// <para>Surface Constraints</para>
		/// <para>将从 LAS 数据集中移除的表面约束要素的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object InSurfaceConstraints { get; set; }

		/// <summary>
		/// <para>Updated LAS Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLasDatasetLayer()]
		public object DerivedLasDataset { get; set; }

		/// <summary>
		/// <para>Delete Pyramid</para>
		/// <para>指定是否将删除 LAS 数据集的显示金字塔。</para>
		/// <para>选中 - 将删除 LAS 数据集的显示金字塔。</para>
		/// <para>未选中 - 不会删除 LAS数据集的显示金字塔。这是默认设置。</para>
		/// <para><see cref="DeletePyramidEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DeletePyramid { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveFilesFromLasDataset SetEnviroment(object workspace = null )
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_PYRAMID")]
			DELETE_PYRAMID,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_PYRAMID")]
			NO_DELETE_PYRAMID,

		}

#endregion
	}
}
