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
	/// <para>Inside 3D</para>
	/// <para>3D 内部</para>
	/// <para>确定来自输入要素类的 3D 要素是否包含在闭合的多面体中，并且写入记录要素（部分或全部在多面体中）的输出表。</para>
	/// </summary>
	public class Inside3D : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTargetFeatureClass">
		/// <para>Input Features</para>
		/// <para>输入多面体或 3D 点、线或面要素类。</para>
		/// </param>
		/// <param name="InContainerFeatureClass">
		/// <para>Input Multipatch Features</para>
		/// <para>用作输入要素容器的闭合多面体要素。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>输出表，它提供全部或部分位于闭合输入多面体要素内部的 3D 输入要素的列表。输出表包含 OBJECTID（对象 ID）、Target_ID 和 Status 字段。Status 字段将指明输入要素 (Target_ID) 是否完全或部分落入多面体内。</para>
		/// </param>
		public Inside3D(object InTargetFeatureClass, object InContainerFeatureClass, object OutTable)
		{
			this.InTargetFeatureClass = InTargetFeatureClass;
			this.InContainerFeatureClass = InContainerFeatureClass;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 3D 内部</para>
		/// </summary>
		public override string DisplayName() => "3D 内部";

		/// <summary>
		/// <para>Tool Name : Inside3D</para>
		/// </summary>
		public override string ToolName() => "Inside3D";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Inside3D</para>
		/// </summary>
		public override string ExcuteName() => "3d.Inside3D";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "configKeyword", "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTargetFeatureClass, InContainerFeatureClass, OutTable, ComplexOutput! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入多面体或 3D 点、线或面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object InTargetFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Multipatch Features</para>
		/// <para>用作输入要素容器的闭合多面体要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object InContainerFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>输出表，它提供全部或部分位于闭合输入多面体要素内部的 3D 输入要素的列表。输出表包含 OBJECTID（对象 ID）、Target_ID 和 Status 字段。Status 字段将指明输入要素 (Target_ID) 是否完全或部分落入多面体内。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Complex Output Table</para>
		/// <para>指定输出表是否通过创建 Contain_ID 字段（识别包含输入要素的多面体要素）来识别输入要素和输入多面体要素之间的关系。</para>
		/// <para>选中 - 将识别包含输入要素的多面体要素。</para>
		/// <para>未选中 - 将不识别包含输入要素的多面体要素。这是默认设置。</para>
		/// <para><see cref="ComplexOutputEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ComplexOutput { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Inside3D SetEnviroment(int? autoCommit = null, object? configKeyword = null, object? extent = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Complex Output Table</para>
		/// </summary>
		public enum ComplexOutputEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPLEX")]
			COMPLEX,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("SIMPLE")]
			SIMPLE,

		}

#endregion
	}
}
