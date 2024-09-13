using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.EditingTools
{
	/// <summary>
	/// <para>Extend Line</para>
	/// <para>延伸线</para>
	/// <para>将线段延伸至指定距离范围内的第一个相交要素。 如果在指定距离范围内不存在相交的要素，则不会延伸该线段。 工具用于完成质量控制任务，例如，清除在未设置适合的捕捉环境的情况下而进行数字化的要素中的拓扑错误。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ExtendLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要延伸的线输入要素。</para>
		/// </param>
		public ExtendLine(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 延伸线</para>
		/// </summary>
		public override string DisplayName() => "延伸线";

		/// <summary>
		/// <para>Tool Name : ExtendLine</para>
		/// </summary>
		public override string ToolName() => "ExtendLine";

		/// <summary>
		/// <para>Tool Excute Name : edit.ExtendLine</para>
		/// </summary>
		public override string ExcuteName() => "edit.ExtendLine";

		/// <summary>
		/// <para>Toolbox Display Name : Editing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Editing Tools";

		/// <summary>
		/// <para>Toolbox Alise : edit</para>
		/// </summary>
		public override string ToolboxAlise() => "edit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, Length!, ExtendTo!, OutFeatureClass! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要延伸的线输入要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Extend Length</para>
		/// <para>线段延伸到相交要素所需的最大距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? Length { get; set; }

		/// <summary>
		/// <para>Extend to Extensions</para>
		/// <para>指定线段是否可延伸至指定延伸长度范围内的其他延伸线段。</para>
		/// <para>选中 - 线段可延伸至其他延伸线段以及现有线要素。 这是默认设置。</para>
		/// <para>未选中 - 线段只能延伸至现有线要素。</para>
		/// <para><see cref="ExtendToEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ExtendTo { get; set; } = "true";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtendLine SetEnviroment(object? extent = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Extend to Extensions</para>
		/// </summary>
		public enum ExtendToEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EXTENSION")]
			EXTENSION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("FEATURE")]
			FEATURE,

		}

#endregion
	}
}
