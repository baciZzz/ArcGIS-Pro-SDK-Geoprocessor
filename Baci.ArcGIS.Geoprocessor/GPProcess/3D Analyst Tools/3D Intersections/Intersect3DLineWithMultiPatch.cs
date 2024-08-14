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
	/// <para>Returns the number of geometric intersections between  3D line and multipatch features and also provides optional features that represent points of intersection and also divide the 3D lines at such points.</para>
	/// </summary>
	public class Intersect3DLineWithMultiPatch : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLineFeatures">
		/// <para>Input Line Features</para>
		/// <para>The line features that will be intersected with the multipatch features.</para>
		/// </param>
		/// <param name="InMultipatchFeatures">
		/// <para>Input Multipatch Features</para>
		/// <para>The multipatch features that the lines will be intersected against.</para>
		/// </param>
		public Intersect3DLineWithMultiPatch(object InLineFeatures, object InMultipatchFeatures)
		{
			this.InLineFeatures = InLineFeatures;
			this.InMultipatchFeatures = InMultipatchFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Intersect 3D Line With Multipatch</para>
		/// </summary>
		public override string DisplayName => "Intersect 3D Line With Multipatch";

		/// <summary>
		/// <para>Tool Name : Intersect3DLineWithMultiPatch</para>
		/// </summary>
		public override string ToolName => "Intersect3DLineWithMultiPatch";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Intersect3DLineWithMultiPatch</para>
		/// </summary>
		public override string ExcuteName => "3d.Intersect3DLineWithMultiPatch";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InLineFeatures, InMultipatchFeatures, JoinAttributes!, OutPointFeatureClass!, OutLineFeatureClass!, OutIntersectionCount! };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>The line features that will be intersected with the multipatch features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InLineFeatures { get; set; }

		/// <summary>
		/// <para>Input Multipatch Features</para>
		/// <para>The multipatch features that the lines will be intersected against.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InMultipatchFeatures { get; set; }

		/// <summary>
		/// <para>Join Attributes</para>
		/// <para>The input line feature attributes that will be stored with the optional output features.</para>
		/// <para>Only Feature ID Numbers— Only feature identification numbers will be stored. This is the default.</para>
		/// <para>All Attributes—All attributes will be stored.</para>
		/// <para><see cref="JoinAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? JoinAttributes { get; set; } = "IDS_ONLY";

		/// <summary>
		/// <para>Output Points</para>
		/// <para>Optional features that represent points of intersection between the 3D line and multipatch.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Lines</para>
		/// <para>Optional line features that divide the input lines at each point of intersection with a multipatch feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutLineFeatureClass { get; set; }

		/// <summary>
		/// <para>Intersection Count</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? OutIntersectionCount { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Intersect3DLineWithMultiPatch SetEnviroment(object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? workspace = null )
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
			/// <para>Only Feature ID Numbers— Only feature identification numbers will be stored. This is the default.</para>
			/// </summary>
			[GPValue("IDS_ONLY")]
			[Description("Only Feature ID Numbers")]
			Only_Feature_ID_Numbers,

			/// <summary>
			/// <para>All Attributes—All attributes will be stored.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All Attributes")]
			All_Attributes,

		}

#endregion
	}
}
