using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DefenseTools
{
	/// <summary>
	/// <para>Generate Grid From Point</para>
	/// <para>Generate Grid From Point</para>
	/// <para>Generates a Gridded Reference Graphic (GRG) as a polygon feature class over a specified area with a custom size.</para>
	/// </summary>
	public class GenerateGRGFromPoint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeature">
		/// <para>Input Feature</para>
		/// <para>The center point for the GRG starting point.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class containing the GRG to be created.</para>
		/// </param>
		public GenerateGRGFromPoint(object InFeature, object OutFeatureClass)
		{
			this.InFeature = InFeature;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Grid From Point</para>
		/// </summary>
		public override string DisplayName() => "Generate Grid From Point";

		/// <summary>
		/// <para>Tool Name : GenerateGRGFromPoint</para>
		/// </summary>
		public override string ToolName() => "GenerateGRGFromPoint";

		/// <summary>
		/// <para>Tool Excute Name : defense.GenerateGRGFromPoint</para>
		/// </summary>
		public override string ExcuteName() => "defense.GenerateGRGFromPoint";

		/// <summary>
		/// <para>Toolbox Display Name : Defense Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Defense Tools";

		/// <summary>
		/// <para>Toolbox Alise : defense</para>
		/// </summary>
		public override string ToolboxAlise() => "defense";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeature, OutFeatureClass, HorizontalCells, VerticalCells, CellWidth, CellHeight, CellUnits, LabelStartPosition, LabelFormat, LabelSeparator, GridAngle, GridAngleUnits };

		/// <summary>
		/// <para>Input Feature</para>
		/// <para>The center point for the GRG starting point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeature { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class containing the GRG to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Number of Rows</para>
		/// <para>The number of horizontal grid cells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Cell Options")]
		public object HorizontalCells { get; set; } = "10";

		/// <summary>
		/// <para>Number of Columns</para>
		/// <para>The number of vertical grid cells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Cell Options")]
		public object VerticalCells { get; set; } = "10";

		/// <summary>
		/// <para>Cell Width</para>
		/// <para>The width of the cells. Measurement units are specified by the Cell Units parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Cell Options")]
		public object CellWidth { get; set; } = "1000";

		/// <summary>
		/// <para>Cell Height</para>
		/// <para>The height of the cells. Measurement units are specified by the Cell Units parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Cell Options")]
		public object CellHeight { get; set; } = "1000";

		/// <summary>
		/// <para>Cell Units</para>
		/// <para>Specifies the measurement units for cell width and height.</para>
		/// <para>Meters—The unit will be meters. This is the default.</para>
		/// <para>Kilometers—The unit will be kilometers.</para>
		/// <para>Miles—The unit will be miles.</para>
		/// <para>Nautical miles—The unit will be nautical miles.</para>
		/// <para>Feet—The unit will be feet.</para>
		/// <para>US survey feet—The unit will be U.S. survey feet.</para>
		/// <para><see cref="CellUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Cell Options")]
		public object CellUnits { get; set; } = "METERS";

		/// <summary>
		/// <para>Label Start Position</para>
		/// <para>Specifies the grid cell where labelling will start.</para>
		/// <para>Upper left—The label position will be the upper left. This is the default.</para>
		/// <para>Lower left—The label position will be the lower left.</para>
		/// <para>Upper right—The label position will be the upper right.</para>
		/// <para>Lower right—The label position will be in the lower right.</para>
		/// <para><see cref="LabelStartPositionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Label Options")]
		public object LabelStartPosition { get; set; } = "UPPER_LEFT";

		/// <summary>
		/// <para>Label Format</para>
		/// <para>Specifies the labeling type for each grid cell.</para>
		/// <para>Alpha-numeric—The label will use an alpha character, a separator, and a number for the label. This is the default.</para>
		/// <para>Alpha-alpha—The label will use an alpha character, a separator, and an additional alpha character for the label.</para>
		/// <para>Numeric—The label will be numeric.</para>
		/// <para><see cref="LabelFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Label Options")]
		public object LabelFormat { get; set; } = "ALPHA_NUMERIC";

		/// <summary>
		/// <para>Label Separator</para>
		/// <para>Specifies the separator to be used between x- and y-values when the Label Format parameter is set to Alpha-alpha, for example, A-A, A-AA, AA-A.</para>
		/// <para>Hyphen—The label separator will be a hyphen. This is the default.</para>
		/// <para>Comma—The label separator will be a comma.</para>
		/// <para>Period—The label separator will be a period.</para>
		/// <para>Forward slash—The label separator will be a forward slash.</para>
		/// <para><see cref="LabelSeparatorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Label Options")]
		public object LabelSeparator { get; set; } = "-";

		/// <summary>
		/// <para>Grid Rotation Angle</para>
		/// <para>The angle used to rotate the grid.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object GridAngle { get; set; } = "0";

		/// <summary>
		/// <para>Grid Rotation Angular Units</para>
		/// <para>The angular units for grid rotation.</para>
		/// <para>Degrees—The angle will be degrees. This is the default.</para>
		/// <para>Mils—The angle will be mils.</para>
		/// <para>Radians—The angle will be radians.</para>
		/// <para>Gradians—The angle will be gradians.</para>
		/// <para><see cref="GridAngleUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GridAngleUnits { get; set; } = "DEGREES";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateGRGFromPoint SetEnviroment(object outputCoordinateSystem = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Cell Units</para>
		/// </summary>
		public enum CellUnitsEnum 
		{
			/// <summary>
			/// <para>Meters—The unit will be meters. This is the default.</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Kilometers—The unit will be kilometers.</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Miles—The unit will be miles.</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para>Nautical miles—The unit will be nautical miles.</para>
			/// </summary>
			[GPValue("NAUTICAL_MILES")]
			[Description("Nautical miles")]
			Nautical_miles,

			/// <summary>
			/// <para>Feet—The unit will be feet.</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>US survey feet—The unit will be U.S. survey feet.</para>
			/// </summary>
			[GPValue("US_SURVEY_FEET")]
			[Description("US survey feet")]
			US_survey_feet,

		}

		/// <summary>
		/// <para>Label Start Position</para>
		/// </summary>
		public enum LabelStartPositionEnum 
		{
			/// <summary>
			/// <para>Upper left—The label position will be the upper left. This is the default.</para>
			/// </summary>
			[GPValue("UPPER_LEFT")]
			[Description("Upper left")]
			Upper_left,

			/// <summary>
			/// <para>Lower left—The label position will be the lower left.</para>
			/// </summary>
			[GPValue("LOWER_LEFT")]
			[Description("Lower left")]
			Lower_left,

			/// <summary>
			/// <para>Upper right—The label position will be the upper right.</para>
			/// </summary>
			[GPValue("UPPER_RIGHT")]
			[Description("Upper right")]
			Upper_right,

			/// <summary>
			/// <para>Lower right—The label position will be in the lower right.</para>
			/// </summary>
			[GPValue("LOWER_RIGHT")]
			[Description("Lower right")]
			Lower_right,

		}

		/// <summary>
		/// <para>Label Format</para>
		/// </summary>
		public enum LabelFormatEnum 
		{
			/// <summary>
			/// <para>Alpha-numeric—The label will use an alpha character, a separator, and a number for the label. This is the default.</para>
			/// </summary>
			[GPValue("ALPHA_NUMERIC")]
			[Description("Alpha-numeric")]
			ALPHA_NUMERIC,

			/// <summary>
			/// <para>Alpha-alpha—The label will use an alpha character, a separator, and an additional alpha character for the label.</para>
			/// </summary>
			[GPValue("ALPHA_ALPHA")]
			[Description("Alpha-alpha")]
			ALPHA_ALPHA,

			/// <summary>
			/// <para>Numeric—The label will be numeric.</para>
			/// </summary>
			[GPValue("NUMERIC")]
			[Description("Numeric")]
			Numeric,

		}

		/// <summary>
		/// <para>Label Separator</para>
		/// </summary>
		public enum LabelSeparatorEnum 
		{
			/// <summary>
			/// <para>Hyphen—The label separator will be a hyphen. This is the default.</para>
			/// </summary>
			[GPValue("-")]
			[Description("Hyphen")]
			Hyphen,

			/// <summary>
			/// <para>Comma—The label separator will be a comma.</para>
			/// </summary>
			[GPValue(",")]
			[Description("Comma")]
			Comma,

			/// <summary>
			/// <para>Period—The label separator will be a period.</para>
			/// </summary>
			[GPValue(".")]
			[Description("Period")]
			Period,

			/// <summary>
			/// <para>Forward slash—The label separator will be a forward slash.</para>
			/// </summary>
			[GPValue("/")]
			[Description("Forward slash")]
			Forward_slash,

		}

		/// <summary>
		/// <para>Grid Rotation Angular Units</para>
		/// </summary>
		public enum GridAngleUnitsEnum 
		{
			/// <summary>
			/// <para>Degrees—The angle will be degrees. This is the default.</para>
			/// </summary>
			[GPValue("DEGREES")]
			[Description("Degrees")]
			Degrees,

			/// <summary>
			/// <para>Mils—The angle will be mils.</para>
			/// </summary>
			[GPValue("MILS")]
			[Description("Mils")]
			Mils,

			/// <summary>
			/// <para>Radians—The angle will be radians.</para>
			/// </summary>
			[GPValue("RADS")]
			[Description("Radians")]
			Radians,

			/// <summary>
			/// <para>Gradians—The angle will be gradians.</para>
			/// </summary>
			[GPValue("GRADS")]
			[Description("Gradians")]
			Gradians,

		}

#endregion
	}
}
