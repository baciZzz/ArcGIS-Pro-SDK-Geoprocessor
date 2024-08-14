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
	/// <para>Inside 3D</para>
	/// <para>Determines if 3D features from an input feature class are contained inside a closed multipatch, and writes an output table recording the features that are partially or fully inside the multipatch.</para>
	/// </summary>
	public class Inside3D : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTargetFeatureClass">
		/// <para>Input Features</para>
		/// <para>The input multipatch or 3D point, line, or polygon feature class.</para>
		/// </param>
		/// <param name="InContainerFeatureClass">
		/// <para>Input Multipatch Features</para>
		/// <para>The closed multipatch features that will be used as the containers for the input features.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The output table providing a list of 3D Input Features that are inside or partially inside the Input Multipatch Features which are closed. The output table contains an OBJECTID (object ID), Target_ID, and Status field. The Status field will state if the input feature (Target_ID) is inside or partially inside a multipatch.</para>
		/// </param>
		public Inside3D(object InTargetFeatureClass, object InContainerFeatureClass, object OutTable)
		{
			this.InTargetFeatureClass = InTargetFeatureClass;
			this.InContainerFeatureClass = InContainerFeatureClass;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Inside 3D</para>
		/// </summary>
		public override string DisplayName => "Inside 3D";

		/// <summary>
		/// <para>Tool Name : Inside3D</para>
		/// </summary>
		public override string ToolName => "Inside3D";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Inside3D</para>
		/// </summary>
		public override string ExcuteName => "3d.Inside3D";

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
		public override string[] ValidEnvironments => new string[] { "autoCommit", "configKeyword", "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTargetFeatureClass, InContainerFeatureClass, OutTable, ComplexOutput! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input multipatch or 3D point, line, or polygon feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object InTargetFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Multipatch Features</para>
		/// <para>The closed multipatch features that will be used as the containers for the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object InContainerFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The output table providing a list of 3D Input Features that are inside or partially inside the Input Multipatch Features which are closed. The output table contains an OBJECTID (object ID), Target_ID, and Status field. The Status field will state if the input feature (Target_ID) is inside or partially inside a multipatch.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Complex Output Table</para>
		/// <para>Specifies if the output table will identify the relationship between the Input Features and the Input Multipatch Features through the creation of a Contain_ID field that identifies the multipatch feature that contains the input feature.</para>
		/// <para>Checked—The multipatch feature that contains an input feature will be identified.</para>
		/// <para>Unchecked—The multipatch feature that contains an input feature will not be identified. This is the default.</para>
		/// <para><see cref="ComplexOutputEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ComplexOutput { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Inside3D SetEnviroment(int? autoCommit = null , object? configKeyword = null , object? extent = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Complex Output Table</para>
		/// </summary>
		public enum ComplexOutputEnum 
		{
			/// <summary>
			/// <para>Checked—The multipatch feature that contains an input feature will be identified.</para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPLEX")]
			COMPLEX,

			/// <summary>
			/// <para>Unchecked—The multipatch feature that contains an input feature will not be identified. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("SIMPLE")]
			SIMPLE,

		}

#endregion
	}
}
