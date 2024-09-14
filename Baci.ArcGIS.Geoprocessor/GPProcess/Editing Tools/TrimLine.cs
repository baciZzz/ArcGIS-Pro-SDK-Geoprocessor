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
	/// <para>Trim Line</para>
	/// <para>修剪线</para>
	/// <para>移除线上超过交点指定距离的部分（悬挂线）。 可修剪两个端点均未与其他线相接触的任何线，但只能移除超过交点指定距离的线段。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class TrimLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要修剪的线输入要素。</para>
		/// </param>
		public TrimLine(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 修剪线</para>
		/// </summary>
		public override string DisplayName() => "修剪线";

		/// <summary>
		/// <para>Tool Name : TrimLine</para>
		/// </summary>
		public override string ToolName() => "TrimLine";

		/// <summary>
		/// <para>Tool Excute Name : edit.TrimLine</para>
		/// </summary>
		public override string ExcuteName() => "edit.TrimLine";

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
		public override object[] Parameters() => new object[] { InFeatures, DangleLength, DeleteShorts, OutFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要修剪的线输入要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Dangle Length</para>
		/// <para>将修剪长度短于指定“悬挂长度”且两个端点均未接触到其他线的线段（悬挂线）。</para>
		/// <para>如果未指定“悬挂长度”，则将所有悬挂线（两个端点均未接触到其他线的线段）均修剪至交点处，而不考虑悬挂线的长度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object DangleLength { get; set; }

		/// <summary>
		/// <para>Delete Short Features</para>
		/// <para>指定是否删除长度短于悬挂长度的独立线段。</para>
		/// <para>选中 - 删除独立的短要素。 这是默认设置。</para>
		/// <para>未选中 - 不删除独立的短要素。</para>
		/// <para><see cref="DeleteShortsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DeleteShorts { get; set; } = "true";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TrimLine SetEnviroment(object extent = null, object workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Delete Short Features</para>
		/// </summary>
		public enum DeleteShortsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_SHORT")]
			DELETE_SHORT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_SHORT")]
			KEEP_SHORT,

		}

#endregion
	}
}
