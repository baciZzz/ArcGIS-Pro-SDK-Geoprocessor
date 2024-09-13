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
	/// <para>Layer 3D To Feature Class</para>
	/// <para>Layer 3D To Feature Class</para>
	/// <para>Exports feature layers with 3D display properties to 3D lines or multipatch features.</para>
	/// </summary>
	public class Layer3DToFeatureClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureLayer">
		/// <para>Input Feature Layer</para>
		/// <para>The input feature layer with 3D display properties defined.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class with 3D features. Extruded points will be exported as 3D lines. Points with 3D symbols, extruded lines, and polygons will be exported as multipatch features.</para>
		/// </param>
		public Layer3DToFeatureClass(object InFeatureLayer, object OutFeatureClass)
		{
			this.InFeatureLayer = InFeatureLayer;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Layer 3D To Feature Class</para>
		/// </summary>
		public override string DisplayName() => "Layer 3D To Feature Class";

		/// <summary>
		/// <para>Tool Name : Layer3DToFeatureClass</para>
		/// </summary>
		public override string ToolName() => "Layer3DToFeatureClass";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Layer3DToFeatureClass</para>
		/// </summary>
		public override string ExcuteName() => "3d.Layer3DToFeatureClass";

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
		public override object[] Parameters() => new object[] { InFeatureLayer, OutFeatureClass, GroupField!, DisableMaterials! };

		/// <summary>
		/// <para>Input Feature Layer</para>
		/// <para>The input feature layer with 3D display properties defined.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline", "Polygon", "MultiPatch")]
		public object InFeatureLayer { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class with 3D features. Extruded points will be exported as 3D lines. Points with 3D symbols, extruded lines, and polygons will be exported as multipatch features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Grouping Field</para>
		/// <para>The input feature's text field that will be used to merge multiple input features into the same output feature. The resulting output's remaining attributes will be inherited from one of the input records.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("OID", "Short", "Long", "Text")]
		public object? GroupField { get; set; }

		/// <summary>
		/// <para>Disable Color and Texture</para>
		/// <para>Specifies whether color and texture properties will be maintained when exporting a 3D layer to a multipatch feature class.</para>
		/// <para>Checked—Colors and textures will not be stored as part of the multipatch definition. This is the default.</para>
		/// <para>Unchecked—Colors and textures will be preserved with the multipatch.</para>
		/// <para><see cref="DisableMaterialsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DisableMaterials { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Layer3DToFeatureClass SetEnviroment(object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Disable Color and Texture</para>
		/// </summary>
		public enum DisableMaterialsEnum 
		{
			/// <summary>
			/// <para>Checked—Colors and textures will not be stored as part of the multipatch definition. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DISABLE_COLORS_AND_TEXTURES")]
			DISABLE_COLORS_AND_TEXTURES,

			/// <summary>
			/// <para>Unchecked—Colors and textures will be preserved with the multipatch.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ENABLE_COLORS_AND_TEXTURES")]
			ENABLE_COLORS_AND_TEXTURES,

		}

#endregion
	}
}
