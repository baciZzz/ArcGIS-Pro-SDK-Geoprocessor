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
	/// <para>Intersect 3D</para>
	/// <para>Computes the intersection of multipatch features to produce closed multipatches  encompassing the overlapping volumes, open multipatch features from the common surface areas, or lines from the intersecting edges.</para>
	/// </summary>
	public class Intersect3D : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass1">
		/// <para>Input Multipatch Features</para>
		/// <para>The multipatch features that will be intersected. When only one input feature layer or feature class is provided, the output will indicate the intersection of its own features.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </param>
		public Intersect3D(object InFeatureClass1, object OutFeatureClass)
		{
			this.InFeatureClass1 = InFeatureClass1;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Intersect 3D</para>
		/// </summary>
		public override string DisplayName => "Intersect 3D";

		/// <summary>
		/// <para>Tool Name : Intersect3D</para>
		/// </summary>
		public override string ToolName => "Intersect3D";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Intersect3D</para>
		/// </summary>
		public override string ExcuteName => "3d.Intersect3D";

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
		public override string[] ValidEnvironments => new string[] { "XYDomain", "ZDomain", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatureClass1, OutFeatureClass, InFeatureClass2!, OutputGeometryType! };

		/// <summary>
		/// <para>Input Multipatch Features</para>
		/// <para>The multipatch features that will be intersected. When only one input feature layer or feature class is provided, the output will indicate the intersection of its own features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object InFeatureClass1 { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Multipatch Features</para>
		/// <para>The optional second multipatch feature layer or feature class to be intersected with the first.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object? InFeatureClass2 { get; set; }

		/// <summary>
		/// <para>Output Geometry Type</para>
		/// <para>Determines the type of intersection geometry created.</para>
		/// <para>Solid—Creates a closed multipatch representing the overlapping volumes between input features. This is the default.</para>
		/// <para>Surface—Creates a multipatch surface representing shared faces between input features.</para>
		/// <para>Line— Creates lines representing shared edges between input features.</para>
		/// <para><see cref="OutputGeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutputGeometryType { get; set; } = "SOLID";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Intersect3D SetEnviroment(object? XYDomain = null , object? ZDomain = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, ZDomain: ZDomain, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Geometry Type</para>
		/// </summary>
		public enum OutputGeometryTypeEnum 
		{
			/// <summary>
			/// <para>Solid—Creates a closed multipatch representing the overlapping volumes between input features. This is the default.</para>
			/// </summary>
			[GPValue("SOLID")]
			[Description("Solid")]
			Solid,

			/// <summary>
			/// <para>Surface—Creates a multipatch surface representing shared faces between input features.</para>
			/// </summary>
			[GPValue("SURFACE")]
			[Description("Surface")]
			Surface,

			/// <summary>
			/// <para>Line— Creates lines representing shared edges between input features.</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("Line")]
			Line,

		}

#endregion
	}
}
