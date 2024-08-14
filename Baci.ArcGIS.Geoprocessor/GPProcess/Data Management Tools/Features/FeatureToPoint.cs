using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Feature To Point</para>
	/// <para>Creates a feature class containing points generated from the representative locations of input features.</para>
	/// </summary>
	public class FeatureToPoint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input features that can be multipoint, line, polygon, or annotation.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output point feature class.</para>
		/// </param>
		public FeatureToPoint(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Feature To Point</para>
		/// </summary>
		public override string DisplayName => "Feature To Point";

		/// <summary>
		/// <para>Tool Name : FeatureToPoint</para>
		/// </summary>
		public override string ToolName => "FeatureToPoint";

		/// <summary>
		/// <para>Tool Excute Name : management.FeatureToPoint</para>
		/// </summary>
		public override string ExcuteName => "management.FeatureToPoint";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "MDomain", "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, PointLocation };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features that can be multipoint, line, polygon, or annotation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output point feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Inside</para>
		/// <para>Specifies whether to use representative centers of input features or locations contained by input features as the output point locations.</para>
		/// <para>Unchecked—Uses the representative center of an input feature as its output point location. This location may not always be contained by the input feature. This is the default.</para>
		/// <para>Checked—Uses a location contained by an input feature as its output point location.</para>
		/// <para><see cref="PointLocationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PointLocation { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeatureToPoint SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , object extent = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Inside</para>
		/// </summary>
		public enum PointLocationEnum 
		{
			/// <summary>
			/// <para>Checked—Uses a location contained by an input feature as its output point location.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INSIDE")]
			INSIDE,

			/// <summary>
			/// <para>Unchecked—Uses the representative center of an input feature as its output point location. This location may not always be contained by the input feature. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("CENTROID")]
			CENTROID,

		}

#endregion
	}
}
