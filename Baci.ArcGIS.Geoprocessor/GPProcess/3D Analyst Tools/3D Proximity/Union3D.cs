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
	/// <para>Union 3D</para>
	/// <para>Merges closed, overlapping multipatch features from an input feature class.</para>
	/// </summary>
	public class Union3D : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Input Multipatch Features</para>
		/// <para>The multipatch features that will be unioned.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output multipatch feature class that will store the aggregated features.</para>
		/// </param>
		public Union3D(object InFeatureClass, object OutFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Union 3D</para>
		/// </summary>
		public override string DisplayName => "Union 3D";

		/// <summary>
		/// <para>Tool Name : Union3D</para>
		/// </summary>
		public override string ToolName => "Union3D";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Union3D</para>
		/// </summary>
		public override string ExcuteName => "3d.Union3D";

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
		public override object[] Parameters => new object[] { InFeatureClass, OutFeatureClass, GroupField, DisableOptimization, OutputAll, OutTable };

		/// <summary>
		/// <para>Input Multipatch Features</para>
		/// <para>The multipatch features that will be unioned.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output multipatch feature class that will store the aggregated features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Grouping Field</para>
		/// <para>The field used to identify the features that should be grouped together.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object GroupField { get; set; }

		/// <summary>
		/// <para>Disable Optimization</para>
		/// <para>Specifies whether optimization is performed or not performed on the input data. Optimization will preprocess the input data by grouping them to improve performance and create unique outputs for each set of overlapping features.</para>
		/// <para>Unchecked—Optimization is enabled, and the grouping field is ignored. This is the default.</para>
		/// <para>Checked—No optimization is performed on the input data. Features will either be stored in a single output feature or be unioned according to their grouping field, if one is provided.</para>
		/// <para><see cref="DisableOptimizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DisableOptimization { get; set; } = "false";

		/// <summary>
		/// <para>Output All Solids</para>
		/// <para>Determines if the output feature class contains all features or only the overlapping ones that were unioned.</para>
		/// <para>Checked—All input features are written to the output. This is the default.</para>
		/// <para>Unchecked—Only unioned features are written to the output. Non-overlapping features will be ignored.</para>
		/// <para><see cref="OutputAllEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object OutputAll { get; set; } = "true";

		/// <summary>
		/// <para>Output Table</para>
		/// <para>A many-to-one table that identifies the input features that contribute to each output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Union3D SetEnviroment(object XYDomain = null , object ZDomain = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, ZDomain: ZDomain, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Disable Optimization</para>
		/// </summary>
		public enum DisableOptimizationEnum 
		{
			/// <summary>
			/// <para>Checked—No optimization is performed on the input data. Features will either be stored in a single output feature or be unioned according to their grouping field, if one is provided.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DISABLE")]
			DISABLE,

			/// <summary>
			/// <para>Unchecked—Optimization is enabled, and the grouping field is ignored. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ENABLE")]
			ENABLE,

		}

		/// <summary>
		/// <para>Output All Solids</para>
		/// </summary>
		public enum OutputAllEnum 
		{
			/// <summary>
			/// <para>Checked—All input features are written to the output. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ENABLE")]
			ENABLE,

			/// <summary>
			/// <para>Unchecked—Only unioned features are written to the output. Non-overlapping features will be ignored.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DISABLE")]
			DISABLE,

		}

#endregion
	}
}
