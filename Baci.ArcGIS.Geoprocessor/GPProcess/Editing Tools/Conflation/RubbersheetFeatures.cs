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
	/// <para>Rubbersheet Features</para>
	/// <para>Rubbersheet Features</para>
	/// <para>Modifies input features by spatially adjusting them through rubbersheeting, using the specified rubbersheet links, so they are better aligned with the intended target features.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RubbersheetFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input features to be adjusted. They can be points, lines, polygons, or annotations.</para>
		/// </param>
		/// <param name="InLinkFeatures">
		/// <para>Input Link Features</para>
		/// <para>The input line features representing regular links for rubbersheeting.</para>
		/// </param>
		public RubbersheetFeatures(object InFeatures, object InLinkFeatures)
		{
			this.InFeatures = InFeatures;
			this.InLinkFeatures = InLinkFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Rubbersheet Features</para>
		/// </summary>
		public override string DisplayName() => "Rubbersheet Features";

		/// <summary>
		/// <para>Tool Name : RubbersheetFeatures</para>
		/// </summary>
		public override string ToolName() => "RubbersheetFeatures";

		/// <summary>
		/// <para>Tool Excute Name : edit.RubbersheetFeatures</para>
		/// </summary>
		public override string ExcuteName() => "edit.RubbersheetFeatures";

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
		public override object[] Parameters() => new object[] { InFeatures, InLinkFeatures, InIdentityLinks!, Method!, OutFeatureClass! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features to be adjusted. They can be points, lines, polygons, or annotations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "Annotation", "CoverageAnnotation")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Link Features</para>
		/// <para>The input line features representing regular links for rubbersheeting.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLinkFeatures { get; set; }

		/// <summary>
		/// <para>Input Point Features As Identity Links</para>
		/// <para>The input point features representing identity links for rubbersheeting.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object? InIdentityLinks { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>Specifies the rubbersheeting method to be used to adjust features.</para>
		/// <para>Linear—This method is slightly faster and produces good results when you have many links spread uniformly over the data you are adjusting. This is the default.</para>
		/// <para>Natural neighbor—This method should be used when you have few links spaced widely apart.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Modified Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RubbersheetFeatures SetEnviroment(object? extent = null , object? workspace = null )
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
			/// <para>Linear—This method is slightly faster and produces good results when you have many links spread uniformly over the data you are adjusting. This is the default.</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("Linear")]
			Linear,

			/// <summary>
			/// <para>Natural neighbor—This method should be used when you have few links spaced widely apart.</para>
			/// </summary>
			[GPValue("NATURAL_NEIGHBOR")]
			[Description("Natural neighbor")]
			Natural_neighbor,

		}

#endregion
	}
}
