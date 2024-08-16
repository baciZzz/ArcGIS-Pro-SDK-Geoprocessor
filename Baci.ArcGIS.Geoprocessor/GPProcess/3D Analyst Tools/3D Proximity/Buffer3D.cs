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
	/// <para>Buffer 3D</para>
	/// <para>Creates a 3-dimensional buffer around points or lines to produce spherical or cylindrical multipatch features.</para>
	/// </summary>
	public class Buffer3D : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The line or point features to be buffered.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output multipatch containing the 3D buffers.</para>
		/// </param>
		/// <param name="BufferDistanceOrField">
		/// <para>Distance</para>
		/// <para>The distance of the buffer around the input features, which can be provided as either a linear distance or be derived from a numeric field in the input feature&apos;s attribute table. If the buffer distance is specified from an input field, its unit of measurement will be derived from the feature&apos;s spatial reference. If the linear distance is specified as a numeric value, the following units of measure are supported:</para>
		/// <para>Unknown—Unknown</para>
		/// <para>Inches—Inches</para>
		/// <para>Feet—Feet</para>
		/// <para>Yards—Yards</para>
		/// <para>Miles—Miles</para>
		/// <para>Millimeters—Millimeters</para>
		/// <para>Centimeters—Centimeters</para>
		/// <para>Decimeters—Decimeters</para>
		/// <para>Meters—Meters</para>
		/// <para>Kilometers—Kilometers</para>
		/// </param>
		public Buffer3D(object InFeatures, object OutFeatureClass, object BufferDistanceOrField)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.BufferDistanceOrField = BufferDistanceOrField;
		}

		/// <summary>
		/// <para>Tool Display Name : Buffer 3D</para>
		/// </summary>
		public override string DisplayName => "Buffer 3D";

		/// <summary>
		/// <para>Tool Name : Buffer3D</para>
		/// </summary>
		public override string ToolName => "Buffer3D";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Buffer3D</para>
		/// </summary>
		public override string ExcuteName => "3d.Buffer3D";

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
		public override string[] ValidEnvironments => new string[] { "XYDomain", "ZDomain", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, BufferDistanceOrField, BufferJointType, BufferQuality, SimplificationTolerance };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The line or point features to be buffered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output multipatch containing the 3D buffers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Distance</para>
		/// <para>The distance of the buffer around the input features, which can be provided as either a linear distance or be derived from a numeric field in the input feature&apos;s attribute table. If the buffer distance is specified from an input field, its unit of measurement will be derived from the feature&apos;s spatial reference. If the linear distance is specified as a numeric value, the following units of measure are supported:</para>
		/// <para>Unknown—Unknown</para>
		/// <para>Inches—Inches</para>
		/// <para>Feet—Feet</para>
		/// <para>Yards—Yards</para>
		/// <para>Miles—Miles</para>
		/// <para>Millimeters—Millimeters</para>
		/// <para>Centimeters—Centimeters</para>
		/// <para>Decimeters—Decimeters</para>
		/// <para>Meters—Meters</para>
		/// <para>Kilometers—Kilometers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object BufferDistanceOrField { get; set; }

		/// <summary>
		/// <para>Joint Type</para>
		/// <para>The shape of the buffer between the vertices of the line segments. This parameter is only valid for input line features.</para>
		/// <para>Straight—The shape of connections between vertices will be straight. This is the default.</para>
		/// <para>Round—The shape of connections between vertices will be round.</para>
		/// <para><see cref="BufferJointTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BufferJointType { get; set; } = "STRAIGHT";

		/// <summary>
		/// <para>Buffer Quality</para>
		/// <para>The number of segments used to represent the resulting multipatch features. The default is 20, but any number between the range of 6 to 60 can be entered. A higher Buffer Quality value produces smoother 3D features, but also lengthens the processing time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 6, Max = 60)]
		public object BufferQuality { get; set; } = "20";

		/// <summary>
		/// <para>Simplification (Maximum Allowable Offset)</para>
		/// <para>Simplifies the input lines by maintaining their shape within the specified offset of its original form. Simplification will not take place if no value is specified. The following units of measurement are supported:</para>
		/// <para>Unknown—Unknown</para>
		/// <para>Inches—Inches</para>
		/// <para>Feet—Feet</para>
		/// <para>Yards—Yards</para>
		/// <para>Miles—Miles</para>
		/// <para>Millimeters—Millimeters</para>
		/// <para>Centimeters—Centimeters</para>
		/// <para>Decimeters—Decimeters</para>
		/// <para>Meters—Meters</para>
		/// <para>Kilometers—Kilometers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SimplificationTolerance { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Buffer3D SetEnviroment(object XYDomain = null , object ZDomain = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, ZDomain: ZDomain, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Joint Type</para>
		/// </summary>
		public enum BufferJointTypeEnum 
		{
			/// <summary>
			/// <para>Straight—The shape of connections between vertices will be straight. This is the default.</para>
			/// </summary>
			[GPValue("STRAIGHT")]
			[Description("Straight")]
			Straight,

			/// <summary>
			/// <para>Round—The shape of connections between vertices will be round.</para>
			/// </summary>
			[GPValue("ROUND")]
			[Description("Round")]
			Round,

		}

#endregion
	}
}
