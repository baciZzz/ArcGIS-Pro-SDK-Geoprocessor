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
	/// <para>Feature To 3D By Attribute</para>
	/// <para>Feature To 3D By Attribute</para>
	/// <para>Creates 3D features using height values derived from the attribute of the input features.</para>
	/// </summary>
	public class FeatureTo3DByAttribute : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input  Features</para>
		/// <para>The features that will be used to create 3D features.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </param>
		/// <param name="HeightField">
		/// <para>Height Field</para>
		/// <para>The field whose values will define the height of the resulting 3D features.</para>
		/// </param>
		public FeatureTo3DByAttribute(object InFeatures, object OutFeatureClass, object HeightField)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.HeightField = HeightField;
		}

		/// <summary>
		/// <para>Tool Display Name : Feature To 3D By Attribute</para>
		/// </summary>
		public override string DisplayName() => "Feature To 3D By Attribute";

		/// <summary>
		/// <para>Tool Name : FeatureTo3DByAttribute</para>
		/// </summary>
		public override string ToolName() => "FeatureTo3DByAttribute";

		/// <summary>
		/// <para>Tool Excute Name : 3d.FeatureTo3DByAttribute</para>
		/// </summary>
		public override string ExcuteName() => "3d.FeatureTo3DByAttribute";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "outputZValue", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, HeightField, ToHeightField! };

		/// <summary>
		/// <para>Input  Features</para>
		/// <para>The features that will be used to create 3D features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline", "Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Height Field</para>
		/// <para>The field whose values will define the height of the resulting 3D features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object HeightField { get; set; }

		/// <summary>
		/// <para>To Height Field</para>
		/// <para>An optional second height field used for lines. When using two height fields, each line will start at the first height and end at the second (sloped).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? ToHeightField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeatureTo3DByAttribute SetEnviroment(object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, double? outputZValue = null, object? workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputZValue: outputZValue, workspace: workspace);
			return this;
		}

	}
}
