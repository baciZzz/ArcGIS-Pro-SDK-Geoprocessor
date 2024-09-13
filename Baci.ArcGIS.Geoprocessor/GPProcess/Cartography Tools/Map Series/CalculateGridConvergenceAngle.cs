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
	/// <para>Calculate Grid Convergence Angle</para>
	/// <para>Calculate Grid Convergence Angle</para>
	/// <para>Calculates the rotation angle for true north based on the center point of each feature in a feature class and populates this value in a specified field. This field can be used in conjunction with a spatial map series to rotate each map to true north.</para>
	/// </summary>
	public class CalculateGridConvergenceAngle : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input feature class (points, multipoints, lines, and polygons).</para>
		/// </param>
		/// <param name="AngleField">
		/// <para>Angle Field</para>
		/// <para>The existing field that will be populated with the true north calculation value in decimal degrees.</para>
		/// </param>
		public CalculateGridConvergenceAngle(object InFeatures, object AngleField)
		{
			this.InFeatures = InFeatures;
			this.AngleField = AngleField;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Grid Convergence Angle</para>
		/// </summary>
		public override string DisplayName() => "Calculate Grid Convergence Angle";

		/// <summary>
		/// <para>Tool Name : CalculateGridConvergenceAngle</para>
		/// </summary>
		public override string ToolName() => "CalculateGridConvergenceAngle";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CalculateGridConvergenceAngle</para>
		/// </summary>
		public override string ExcuteName() => "cartography.CalculateGridConvergenceAngle";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise() => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cartographicCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, AngleField, RotationMethod!, CoordinateSysField!, OutFeatures! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input feature class (points, multipoints, lines, and polygons).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Angle Field</para>
		/// <para>The existing field that will be populated with the true north calculation value in decimal degrees.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object AngleField { get; set; }

		/// <summary>
		/// <para>Rotation Method</para>
		/// <para>Specifies the method used to calculate the rotation value.</para>
		/// <para>Geographic—The angle is calculated clockwise with 0 at the top. This is the default.</para>
		/// <para>Arithmetic—The angle is calculated counterclockwise with 0 at the right.</para>
		/// <para>Graphic—The angle is calculated counterclockwise with 0 at the top.</para>
		/// <para><see cref="RotationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RotationMethod { get; set; } = "GEOGRAPHIC";

		/// <summary>
		/// <para>Coordinate System Field</para>
		/// <para>The field containing a projection engine string for a projected coordinate system to be used for angle calculation. The angle calculation for each feature will be based on the projected coordinate system projection engine string for the specific feature. In cases of an invalid value, the tool will use the cartographic coordinate system specified in the Cartography environment settings. The default is none, or no field specified. When no field is specified, the projected coordinate system used for calculation will be taken from the Cartography environment settings.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		[KeyField("NONE")]
		public object? CoordinateSysField { get; set; } = "NONE";

		/// <summary>
		/// <para>Output Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateGridConvergenceAngle SetEnviroment(object? cartographicCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Rotation Method</para>
		/// </summary>
		public enum RotationMethodEnum 
		{
			/// <summary>
			/// <para>Geographic—The angle is calculated clockwise with 0 at the top. This is the default.</para>
			/// </summary>
			[GPValue("GEOGRAPHIC")]
			[Description("Geographic")]
			Geographic,

			/// <summary>
			/// <para>Arithmetic—The angle is calculated counterclockwise with 0 at the right.</para>
			/// </summary>
			[GPValue("ARITHMETIC")]
			[Description("Arithmetic")]
			Arithmetic,

			/// <summary>
			/// <para>Graphic—The angle is calculated counterclockwise with 0 at the top.</para>
			/// </summary>
			[GPValue("GRAPHIC")]
			[Description("Graphic")]
			Graphic,

		}

#endregion
	}
}
