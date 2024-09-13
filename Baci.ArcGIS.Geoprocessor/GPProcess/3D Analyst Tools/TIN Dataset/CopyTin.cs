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
	/// <para>Copy TIN</para>
	/// <para>复制 TIN</para>
	/// <para>创建不规则三角网 (TIN) 数据集的副本。</para>
	/// </summary>
	public class CopyTin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>将要复制的 TIN。</para>
		/// </param>
		/// <param name="OutTin">
		/// <para>Output TIN</para>
		/// <para>将要生成的 TIN 数据集。</para>
		/// </param>
		public CopyTin(object InTin, object OutTin)
		{
			this.InTin = InTin;
			this.OutTin = OutTin;
		}

		/// <summary>
		/// <para>Tool Display Name : 复制 TIN</para>
		/// </summary>
		public override string DisplayName() => "复制 TIN";

		/// <summary>
		/// <para>Tool Name : CopyTin</para>
		/// </summary>
		public override string ToolName() => "CopyTin";

		/// <summary>
		/// <para>Tool Excute Name : 3d.CopyTin</para>
		/// </summary>
		public override string ExcuteName() => "3d.CopyTin";

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
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "tinSaveVersion", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTin, OutTin, Version };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>将要复制的 TIN。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

		/// <summary>
		/// <para>Output TIN</para>
		/// <para>将要生成的 TIN 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETin()]
		public object OutTin { get; set; }

		/// <summary>
		/// <para>Version</para>
		/// <para>输出 TIN 的版本。</para>
		/// <para>Current—当前 TIN 版本，支持约束型 Delaunay 三角测量、增强的空间参考信息以及结点源和边标签值的存储。生成的 TIN 不会向后兼容 10.0 之前的 ArcGIS 版本。这是默认设置。</para>
		/// <para>Pre 10.0—TIN 会向后兼容 10.0 之前的 ArcGIS 版本，且仅支持符合 Delaunay 的三角测量。</para>
		/// <para><see cref="VersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Version { get; set; } = "CURRENT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CopyTin SetEnviroment(object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object tinSaveVersion = null , object workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, tinSaveVersion: tinSaveVersion, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Version</para>
		/// </summary>
		public enum VersionEnum 
		{
			/// <summary>
			/// <para>Pre 10.0—TIN 会向后兼容 10.0 之前的 ArcGIS 版本，且仅支持符合 Delaunay 的三角测量。</para>
			/// </summary>
			[GPValue("PRE_10.0")]
			[Description("Pre 10.0")]
			Pre_100,

			/// <summary>
			/// <para>Current—当前 TIN 版本，支持约束型 Delaunay 三角测量、增强的空间参考信息以及结点源和边标签值的存储。生成的 TIN 不会向后兼容 10.0 之前的 ArcGIS 版本。这是默认设置。</para>
			/// </summary>
			[GPValue("CURRENT")]
			[Description("Current")]
			Current,

		}

#endregion
	}
}
