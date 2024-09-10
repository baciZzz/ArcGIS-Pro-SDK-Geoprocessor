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
	/// <para>TIN Triangle</para>
	/// <para>Exports triangle faces from a TIN dataset to polygon features  and provides slope, aspect, and optional attributes of hillshade and tag values for each triangle.</para>
	/// </summary>
	public class TinTriangle : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>The TIN dataset to process.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </param>
		public TinTriangle(object InTin, object OutFeatureClass)
		{
			this.InTin = InTin;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : TIN Triangle</para>
		/// </summary>
		public override string DisplayName() => "TIN Triangle";

		/// <summary>
		/// <para>Tool Name : TinTriangle</para>
		/// </summary>
		public override string ToolName() => "TinTriangle";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TinTriangle</para>
		/// </summary>
		public override string ExcuteName() => "3d.TinTriangle";

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
		public override object[] Parameters() => new object[] { InTin, OutFeatureClass, Units, ZFactor, Hillshade, TagField };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>The TIN dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Slope Units</para>
		/// <para>The units of measure to be used in calculating slope.</para>
		/// <para>Percent—Slope is expressed as a percentage value. This is the default.</para>
		/// <para>Degree—Slope is expressed as the angle of inclination from a horizontal plane.</para>
		/// <para><see cref="UnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Units { get; set; } = "PERCENT";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>The factor by which z-values will be multiplied. This is typically used to convert z linear units to match x,y linear units. The default is 1, which leaves elevation values unchanged. This parameter is not available if the spatial reference of the input surface has a z datum with a specified linear unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>HILLSHADE azimuth, altitude</para>
		/// <para>Specifies the azimuth and altitude angles of the light source when applying a hillshade effect for the feature layer output. Azimuth can range from 0 to 360 degrees, whereas altitude can range from 0 to 90. An azimuth of 45 degrees and altitude of 30 degrees would be entered as "HILLSHADE 45, 30".</para>
		/// <para><see cref="HillshadeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Hillshade { get; set; }

		/// <summary>
		/// <para>Tag Value Field</para>
		/// <para>The field name in the output feature that will store the triangle tag value. This parameter is empty by default, which will result in tag values not being written to the output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object TagField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TinTriangle SetEnviroment(object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Slope Units</para>
		/// </summary>
		public enum UnitsEnum 
		{
			/// <summary>
			/// <para>Percent—Slope is expressed as a percentage value. This is the default.</para>
			/// </summary>
			[GPValue("PERCENT")]
			[Description("Percent")]
			Percent,

			/// <summary>
			/// <para>Degree—Slope is expressed as the angle of inclination from a horizontal plane.</para>
			/// </summary>
			[GPValue("DEGREE")]
			[Description("Degree")]
			Degree,

		}

		/// <summary>
		/// <para>HILLSHADE azimuth, altitude</para>
		/// </summary>
		public enum HillshadeEnum 
		{
			/// <summary>
			/// <para>HILLSHADE azimuth, altitude</para>
			/// </summary>
			[GPValue("HILLSHADE")]
			[Description("HILLSHADE")]
			HILLSHADE,

		}

#endregion
	}
}
