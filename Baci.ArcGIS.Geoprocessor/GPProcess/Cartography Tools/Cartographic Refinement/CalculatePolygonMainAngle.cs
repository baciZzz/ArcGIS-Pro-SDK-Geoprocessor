using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Calculate Polygon Main Angle</para>
	/// <para>Calculates the dominant angles of  input polygon features and assigns the values to a specified field in the feature class.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class CalculatePolygonMainAngle : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input polygon features.</para>
		/// </param>
		/// <param name="AngleField">
		/// <para>Angle Field</para>
		/// <para>The field that will be updated with the polygon main angle values.</para>
		/// </param>
		public CalculatePolygonMainAngle(object InFeatures, object AngleField)
		{
			this.InFeatures = InFeatures;
			this.AngleField = AngleField;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Polygon Main Angle</para>
		/// </summary>
		public override string DisplayName => "Calculate Polygon Main Angle";

		/// <summary>
		/// <para>Tool Name : CalculatePolygonMainAngle</para>
		/// </summary>
		public override string ToolName => "CalculatePolygonMainAngle";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CalculatePolygonMainAngle</para>
		/// </summary>
		public override string ExcuteName => "cartography.CalculatePolygonMainAngle";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cartographicCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, AngleField, OutFeatures, RotationMethod };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input polygon features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Angle Field</para>
		/// <para>The field that will be updated with the polygon main angle values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object AngleField { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Rotation Method</para>
		/// <para>Controls the method and origin point of rotation.</para>
		/// <para>Geographic—Angle is calculated clockwise with 0 at top/north.</para>
		/// <para>Arithmetic—Angle is calculated counterclockwise with 0 at the right/east.</para>
		/// <para>Graphic—Angle is calculated counterclockwise with 0 at top/north. This is the default.</para>
		/// <para><see cref="RotationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RotationMethod { get; set; } = "GRAPHIC";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculatePolygonMainAngle SetEnviroment(object cartographicCoordinateSystem = null )
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Rotation Method</para>
		/// </summary>
		public enum RotationMethodEnum 
		{
			/// <summary>
			/// <para>Geographic—Angle is calculated clockwise with 0 at top/north.</para>
			/// </summary>
			[GPValue("GEOGRAPHIC")]
			[Description("Geographic")]
			Geographic,

			/// <summary>
			/// <para>Arithmetic—Angle is calculated counterclockwise with 0 at the right/east.</para>
			/// </summary>
			[GPValue("ARITHMETIC")]
			[Description("Arithmetic")]
			Arithmetic,

			/// <summary>
			/// <para>Graphic—Angle is calculated counterclockwise with 0 at top/north. This is the default.</para>
			/// </summary>
			[GPValue("GRAPHIC")]
			[Description("Graphic")]
			Graphic,

		}

#endregion
	}
}
