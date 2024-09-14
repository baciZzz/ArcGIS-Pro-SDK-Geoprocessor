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
	/// <para>Edgematch Features</para>
	/// <para>边匹配要素</para>
	/// <para>以指定的边匹配链接为指导，通过在空间上调整输入线要素的形状对其进行修改，这样这些输入线要素便可与相邻数据集中的线互相连接。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class EdgematchFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要进行调整的输入线要素。</para>
		/// </param>
		/// <param name="InLinkFeatures">
		/// <para>Input Link Features</para>
		/// <para>表示边匹配链接的输入线要素。</para>
		/// </param>
		public EdgematchFeatures(object InFeatures, object InLinkFeatures)
		{
			this.InFeatures = InFeatures;
			this.InLinkFeatures = InLinkFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 边匹配要素</para>
		/// </summary>
		public override string DisplayName() => "边匹配要素";

		/// <summary>
		/// <para>Tool Name : EdgematchFeatures</para>
		/// </summary>
		public override string ToolName() => "EdgematchFeatures";

		/// <summary>
		/// <para>Tool Excute Name : edit.EdgematchFeatures</para>
		/// </summary>
		public override string ExcuteName() => "edit.EdgematchFeatures";

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
		public override object[] Parameters() => new object[] { InFeatures, InLinkFeatures, Method, AdjacentFeatures, BorderFeatures, OutFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要进行调整的输入线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Link Features</para>
		/// <para>表示边匹配链接的输入线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLinkFeatures { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>仅将输入要素或同时将输入要素与相邻要素调整至新连接位置的边匹配方法。</para>
		/// <para>移动端点—将线端点移动至新的连接位置。这是默认设置。</para>
		/// <para>添加线段—在线端点处添加直线段，从而使线端点位于新的连接位置。</para>
		/// <para>调整折点—将线端点调整至新的连接位置。同时也会对其余折点进行调整，从而使折点的位置变化朝着线的另一端逐渐减少。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "MOVE_ENDPOINT";

		/// <summary>
		/// <para>Adjacent Features</para>
		/// <para>与输入要素相邻的线要素。在经过指定的情况下，输入要素与相邻要素会调整为在新连接位置相连接，新连接位置将是边匹配链接的中点或与边界要素的链接中点距离最近的位置（如果指定）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge")]
		public object AdjacentFeatures { get; set; }

		/// <summary>
		/// <para>Border Features</para>
		/// <para>表示输入要素与相邻要素之间边界的线要素或面要素。指定边界要素时，输入要素与相邻要素都会调整至在距离边界要素的链接中点最近的新连接位置相连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		public object BorderFeatures { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EdgematchFeatures SetEnviroment(object extent = null, object workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>移动端点—将线端点移动至新的连接位置。这是默认设置。</para>
			/// </summary>
			[GPValue("MOVE_ENDPOINT")]
			[Description("移动端点")]
			Move_endpoint,

			/// <summary>
			/// <para>添加线段—在线端点处添加直线段，从而使线端点位于新的连接位置。</para>
			/// </summary>
			[GPValue("ADD_SEGMENT")]
			[Description("添加线段")]
			Add_segment,

			/// <summary>
			/// <para>调整折点—将线端点调整至新的连接位置。同时也会对其余折点进行调整，从而使折点的位置变化朝着线的另一端逐渐减少。</para>
			/// </summary>
			[GPValue("ADJUST_VERTICES")]
			[Description("调整折点")]
			Adjust_vertices,

		}

#endregion
	}
}
