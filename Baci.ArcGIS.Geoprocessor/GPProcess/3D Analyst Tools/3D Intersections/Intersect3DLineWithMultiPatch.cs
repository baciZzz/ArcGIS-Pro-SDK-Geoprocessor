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
	/// <para>Intersect 3D Line With Multipatch</para>
	/// <para>3D 线与多面体相交</para>
	/// <para>返回 3D 线和多面体要素之间几何交集的数量，并且还提供用于表示相交点的可选要素，另在这些点处对 3D 线进行分割。</para>
	/// </summary>
	public class Intersect3DLineWithMultiPatch : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLineFeatures">
		/// <para>Input Line Features</para>
		/// <para>要与多面体要素相交的线要素。</para>
		/// </param>
		/// <param name="InMultipatchFeatures">
		/// <para>Input Multipatch Features</para>
		/// <para>要与线相交的多面体要素。</para>
		/// </param>
		public Intersect3DLineWithMultiPatch(object InLineFeatures, object InMultipatchFeatures)
		{
			this.InLineFeatures = InLineFeatures;
			this.InMultipatchFeatures = InMultipatchFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 3D 线与多面体相交</para>
		/// </summary>
		public override string DisplayName() => "3D 线与多面体相交";

		/// <summary>
		/// <para>Tool Name : Intersect3DLineWithMultiPatch</para>
		/// </summary>
		public override string ToolName() => "Intersect3DLineWithMultiPatch";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Intersect3DLineWithMultiPatch</para>
		/// </summary>
		public override string ExcuteName() => "3d.Intersect3DLineWithMultiPatch";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLineFeatures, InMultipatchFeatures, JoinAttributes, OutPointFeatureClass, OutLineFeatureClass, OutIntersectionCount };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>要与多面体要素相交的线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLineFeatures { get; set; }

		/// <summary>
		/// <para>Input Multipatch Features</para>
		/// <para>要与线相交的多面体要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object InMultipatchFeatures { get; set; }

		/// <summary>
		/// <para>Join Attributes</para>
		/// <para>将与可选输出要素一同存储的输入线要素属性。</para>
		/// <para>仅要素 ID 号— 仅存储要素标识号。这是默认设置。</para>
		/// <para>所有属性—将存储所有属性。</para>
		/// <para><see cref="JoinAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object JoinAttributes { get; set; } = "IDS_ONLY";

		/// <summary>
		/// <para>Output Points</para>
		/// <para>用于表示 3D 线和多面体之间交点的可选要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Lines</para>
		/// <para>在与多面体要素的各交点处对输入线进行分割的可选线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutLineFeatureClass { get; set; }

		/// <summary>
		/// <para>Intersection Count</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object OutIntersectionCount { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Intersect3DLineWithMultiPatch SetEnviroment(object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Join Attributes</para>
		/// </summary>
		public enum JoinAttributesEnum 
		{
			/// <summary>
			/// <para>仅要素 ID 号— 仅存储要素标识号。这是默认设置。</para>
			/// </summary>
			[GPValue("IDS_ONLY")]
			[Description("仅要素 ID 号")]
			Only_Feature_ID_Numbers,

			/// <summary>
			/// <para>所有属性—将存储所有属性。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有属性")]
			All_Attributes,

		}

#endregion
	}
}
