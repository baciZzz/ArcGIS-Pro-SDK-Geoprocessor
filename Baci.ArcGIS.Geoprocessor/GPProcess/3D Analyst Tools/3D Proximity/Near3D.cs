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
	/// <para>Near 3D</para>
	/// <para>3D 邻近</para>
	/// <para>计算每个输入要素到一个或多个邻近要素类中的最近要素的三维距离。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class Near3D : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入要素类，将使用有关最近要素的信息设置其要素属性。</para>
		/// </param>
		/// <param name="NearFeatures">
		/// <para>Near Features</para>
		/// <para>将计算到输入要素邻近性的一个或多个要素。如果指定了多个要素类，则将向输入要素类额外添加一个名为 NEAR_FC 的字段，以识别包含最近要素的邻近要素类。</para>
		/// </param>
		public Near3D(object InFeatures, object NearFeatures)
		{
			this.InFeatures = InFeatures;
			this.NearFeatures = NearFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 3D 邻近</para>
		/// </summary>
		public override string DisplayName() => "3D 邻近";

		/// <summary>
		/// <para>Tool Name : Near3D</para>
		/// </summary>
		public override string ToolName() => "Near3D";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Near3D</para>
		/// </summary>
		public override string ExcuteName() => "3d.Near3D";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, NearFeatures, SearchRadius, Location, Angle, Delta, OutFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入要素类，将使用有关最近要素的信息设置其要素属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Near Features</para>
		/// <para>将计算到输入要素邻近性的一个或多个要素。如果指定了多个要素类，则将向输入要素类额外添加一个名为 NEAR_FC 的字段，以识别包含最近要素的邻近要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object NearFeatures { get; set; }

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>将根据给定输入为其确定最近要素的最大距离。如果未指定值，则将确定在任意距离处的最近要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SearchRadius { get; set; }

		/// <summary>
		/// <para>Location</para>
		/// <para>确定是否将输入要素和邻近要素上的最近点的坐标添加到输入属性表。</para>
		/// <para>未选中 - 不会向输入要素添加坐标。这是默认设置。</para>
		/// <para>选中 - 会向输入要素添加坐标。</para>
		/// <para><see cref="LocationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Location { get; set; } = "false";

		/// <summary>
		/// <para>Angle</para>
		/// <para>确定是否将输入要素与最近要素之间的算术水平角和垂直角添加到输入属性表中。</para>
		/// <para>未选中 - 不会向输入属性表添加角。这是默认设置。</para>
		/// <para>选中 - 会向输入属性表中的 NEAR_ANG_H 和 NEAR_ANG_V 字段添加算术水平角和垂直角。</para>
		/// <para><see cref="AngleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Angle { get; set; } = "false";

		/// <summary>
		/// <para>Delta</para>
		/// <para>确定是否向输入属性表添加输入要素与最近要素之间沿 X、Y 和 Z 轴的距离。</para>
		/// <para>未选中 - 不会向输入属性表添加距离。这是默认设置。</para>
		/// <para>选中 - 会计算 NEAR_DELTX、NEAR_DELTY 和 NEAR_DELTZ 字段中沿 X、Y 和 Z 轴的距离。</para>
		/// <para><see cref="DeltaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Delta { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Near3D SetEnviroment(object extent = null, object workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Location</para>
		/// </summary>
		public enum LocationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("LOCATION")]
			LOCATION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_LOCATION")]
			NO_LOCATION,

		}

		/// <summary>
		/// <para>Angle</para>
		/// </summary>
		public enum AngleEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ANGLE")]
			ANGLE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ANGLE")]
			NO_ANGLE,

		}

		/// <summary>
		/// <para>Delta</para>
		/// </summary>
		public enum DeltaEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DELTA")]
			DELTA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELTA")]
			NO_DELTA,

		}

#endregion
	}
}
