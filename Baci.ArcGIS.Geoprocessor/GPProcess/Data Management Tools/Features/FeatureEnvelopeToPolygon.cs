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
	/// <para>Feature Envelope To Polygon</para>
	/// <para>Feature Envelope To Polygon</para>
	/// <para>Creates a feature class containing polygons, each of which represents the envelope of an input feature.</para>
	/// </summary>
	public class FeatureEnvelopeToPolygon : AbstractGPProcess
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
		/// <para>The output polygon feature class.</para>
		/// </param>
		public FeatureEnvelopeToPolygon(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Feature Envelope To Polygon</para>
		/// </summary>
		public override string DisplayName() => "Feature Envelope To Polygon";

		/// <summary>
		/// <para>Tool Name : FeatureEnvelopeToPolygon</para>
		/// </summary>
		public override string ToolName() => "FeatureEnvelopeToPolygon";

		/// <summary>
		/// <para>Tool Excute Name : management.FeatureEnvelopeToPolygon</para>
		/// </summary>
		public override string ExcuteName() => "management.FeatureEnvelopeToPolygon";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, SingleEnvelope! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features that can be multipoint, line, polygon, or annotation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Multipoint", "Polyline", "Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Create multipart features</para>
		/// <para>Specifies whether to use one envelope for each entire multipart feature or one envelope per part of a multipart feature. This parameter will affect the results of multipart input features only.</para>
		/// <para>Unchecked—Uses one envelope containing an entire multipart feature; therefore, the resulting polygon will be singlepart. This is the default.</para>
		/// <para>Checked—Uses one envelope for each part of a multipart feature; the resulting polygon of the multipart feature will remain multipart.</para>
		/// <para><see cref="SingleEnvelopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SingleEnvelope { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeatureEnvelopeToPolygon SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , object? extent = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Create multipart features</para>
		/// </summary>
		public enum SingleEnvelopeEnum 
		{
			/// <summary>
			/// <para>Checked—Uses one envelope for each part of a multipart feature; the resulting polygon of the multipart feature will remain multipart.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTIPART")]
			MULTIPART,

			/// <summary>
			/// <para>Unchecked—Uses one envelope containing an entire multipart feature; therefore, the resulting polygon will be singlepart. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("SINGLEPART")]
			SINGLEPART,

		}

#endregion
	}
}
