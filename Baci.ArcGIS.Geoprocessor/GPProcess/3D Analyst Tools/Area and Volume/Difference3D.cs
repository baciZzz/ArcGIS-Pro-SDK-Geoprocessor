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
	/// <para>Difference 3D</para>
	/// <para>Difference 3D</para>
	/// <para>Eliminates portions  of multipatch features in a target feature class that overlap with enclosed volumes of multipatch features in the subtraction feature class.</para>
	/// </summary>
	public class Difference3D : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeaturesMinuend">
		/// <para>Input Features</para>
		/// <para>The multipatch features that will have its features removed by the subtrahend features.</para>
		/// </param>
		/// <param name="InFeaturesSubtrahend">
		/// <para>Subtract Features</para>
		/// <para>The multipatch features that will be subtracted from the input.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output multipatch feature class that will contain the resulting features.</para>
		/// </param>
		public Difference3D(object InFeaturesMinuend, object InFeaturesSubtrahend, object OutFeatureClass)
		{
			this.InFeaturesMinuend = InFeaturesMinuend;
			this.InFeaturesSubtrahend = InFeaturesSubtrahend;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Difference 3D</para>
		/// </summary>
		public override string DisplayName() => "Difference 3D";

		/// <summary>
		/// <para>Tool Name : Difference3D</para>
		/// </summary>
		public override string ToolName() => "Difference3D";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Difference3D</para>
		/// </summary>
		public override string ExcuteName() => "3d.Difference3D";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "ZDomain", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeaturesMinuend, InFeaturesSubtrahend, OutFeatureClass, OutTable! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The multipatch features that will have its features removed by the subtrahend features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object InFeaturesMinuend { get; set; }

		/// <summary>
		/// <para>Subtract Features</para>
		/// <para>The multipatch features that will be subtracted from the input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object InFeaturesSubtrahend { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output multipatch feature class that will contain the resulting features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>An optional table that stores information about the relationship between the input features and the difference output. The following fields are present in this table:</para>
		/// <para>Output_ID—The ID of the output feature.</para>
		/// <para>Minuend_ID—The ID of the input feature.</para>
		/// <para>Subtrahend—The ID of the subtract feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Difference3D SetEnviroment(object? XYDomain = null , object? ZDomain = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, ZDomain: ZDomain, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

	}
}
