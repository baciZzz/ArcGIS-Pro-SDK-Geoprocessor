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
	/// <para>Fence Diagram</para>
	/// <para>Constructs a vertical cross-section of a collection of surfaces.</para>
	/// </summary>
	public class FenceDiagram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLineFeatures">
		/// <para>Input Line Features</para>
		/// <para>The line features that will be used to construct the fence diagram.</para>
		/// </param>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>The surfaces that will be used to construct the fence diagram.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Multipatch Feature Class</para>
		/// <para>The output multipatch that is composed of vertical faces that depict the fence diagram.</para>
		/// </param>
		public FenceDiagram(object InLineFeatures, object InSurface, object OutFeatureClass)
		{
			this.InLineFeatures = InLineFeatures;
			this.InSurface = InSurface;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Fence Diagram</para>
		/// </summary>
		public override string DisplayName => "Fence Diagram";

		/// <summary>
		/// <para>Tool Name : FenceDiagram</para>
		/// </summary>
		public override string ToolName => "FenceDiagram";

		/// <summary>
		/// <para>Tool Excute Name : 3d.FenceDiagram</para>
		/// </summary>
		public override string ExcuteName => "3d.FenceDiagram";

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
		public override string[] ValidEnvironments => new string[] { "XYDomain", "ZDomain", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InLineFeatures, InSurface, OutFeatureClass, Method, FloorHeight, CeilingHeight, SampleDistance };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>The line features that will be used to construct the fence diagram.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLineFeatures { get; set; }

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>The surfaces that will be used to construct the fence diagram.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Multipatch Feature Class</para>
		/// <para>The output multipatch that is composed of vertical faces that depict the fence diagram.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Interpolation Method</para>
		/// <para>The interpolation method that will be used to obtain z-values from TIN surfaces when constructing the fence diagram. This parameter does not apply to raster surfaces.</para>
		/// <para>Linear—Linear interpolation will be used. This is the default.</para>
		/// <para>Natural Neighbors—Natural neighbors interpolation will be used.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Floor Height</para>
		/// <para>A constant height used to define the lowest height of the fence diagram.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Height Extensions")]
		public object FloorHeight { get; set; }

		/// <summary>
		/// <para>Ceiling Height</para>
		/// <para>A constant height used to define the highest height of the fence diagram.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Height Extensions")]
		public object CeilingHeight { get; set; }

		/// <summary>
		/// <para>Sample Distance</para>
		/// <para>The horizontal distance used for determining the positions where height measurements are interpolated from the underlying surfaces.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SampleDistance { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FenceDiagram SetEnviroment(object XYDomain = null , object ZDomain = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, ZDomain: ZDomain, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Interpolation Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Linear—Linear interpolation will be used. This is the default.</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("Linear")]
			Linear,

			/// <summary>
			/// <para>Natural Neighbors—Natural neighbors interpolation will be used.</para>
			/// </summary>
			[GPValue("NATURAL_NEIGHBORS")]
			[Description("Natural Neighbors")]
			Natural_Neighbors,

		}

#endregion
	}
}
