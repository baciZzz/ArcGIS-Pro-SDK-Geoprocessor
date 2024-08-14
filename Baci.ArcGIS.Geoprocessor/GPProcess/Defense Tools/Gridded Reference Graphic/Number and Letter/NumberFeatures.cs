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
	/// <para>Number Features</para>
	/// <para>Adds a sequential number to a new or existing field of a set of input features.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class NumberFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input features that will be numbered.</para>
		/// </param>
		/// <param name="FieldToNumber">
		/// <para>Field to Number (Existing or New)</para>
		/// <para>The input field that will be numbered. The field can be an existing short, long, or text field, or a new field.</para>
		/// </param>
		public NumberFeatures(object InFeatures, object FieldToNumber)
		{
			this.InFeatures = InFeatures;
			this.FieldToNumber = FieldToNumber;
		}

		/// <summary>
		/// <para>Tool Display Name : Number Features</para>
		/// </summary>
		public override string DisplayName => "Number Features";

		/// <summary>
		/// <para>Tool Name : NumberFeatures</para>
		/// </summary>
		public override string ToolName => "NumberFeatures";

		/// <summary>
		/// <para>Tool Excute Name : defense.NumberFeatures</para>
		/// </summary>
		public override string ExcuteName => "defense.NumberFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Defense Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Defense Tools";

		/// <summary>
		/// <para>Toolbox Alise : defense</para>
		/// </summary>
		public override string ToolboxAlise => "defense";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, FieldToNumber, InArea!, SpatialSortMethod!, NewFieldType!, OutFeatureClass!, StartingNumber!, IncrementBy!, CenterPoint!, AddDistanceAndBearing! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features that will be numbered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Field to Number (Existing or New)</para>
		/// <para>The input field that will be numbered. The field can be an existing short, long, or text field, or a new field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object FieldToNumber { get; set; }

		/// <summary>
		/// <para>Input Area to Number</para>
		/// <para>The area that will limit the features to number; only features within this area will be numbered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		public object? InArea { get; set; }

		/// <summary>
		/// <para>Spatial Sort Method</para>
		/// <para>Specifies how features will be spatially sorted for the purpose of numbering. Features are not reordered in the table.</para>
		/// <para>Upper right—Features will be sorted starting at the upper right corner. This is the default.</para>
		/// <para>Upper left—Features will be sorted starting at the upper left corner.</para>
		/// <para>Lower right—Features will be sorted starting at the lower right corner.</para>
		/// <para>Lower left—Features will be sorted starting at the lower left corner.</para>
		/// <para>Peano curve—Features will be sorted using a space-filling curve algorithm, also known as a Peano curve.</para>
		/// <para>Center—Features will be sorted starting from a center point (the mean center will be used if no center is supplied).</para>
		/// <para>Clockwise—Features will be sorted starting from a center point and moving clockwise.</para>
		/// <para>Counterclockwise—Features will be sorted starting from a center point and moving counterclockwise.</para>
		/// <para>None—No spatial sort will be used. The same order as the feature class will be used.</para>
		/// <para><see cref="SpatialSortMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SpatialSortMethod { get; set; } = "UR";

		/// <summary>
		/// <para>Field Type For New Field</para>
		/// <para>Specifies the field type that will be used for the new field. This parameter is only used when the field name does not exist in the input table.</para>
		/// <para>Short—The field will be of short type. This is the default.</para>
		/// <para>Long—The field will be of long type.</para>
		/// <para>Text—The field will be of text type.</para>
		/// <para><see cref="NewFieldTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? NewFieldType { get; set; } = "LONG";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Starting With</para>
		/// <para>The value that will be used to begin numbering.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? StartingNumber { get; set; } = "1";

		/// <summary>
		/// <para>Increment By</para>
		/// <para>The value that will be used to increment by from the previous value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? IncrementBy { get; set; } = "1";

		/// <summary>
		/// <para>Center Point</para>
		/// <para>The center point that will be used to sort and number features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		public object? CenterPoint { get; set; }

		/// <summary>
		/// <para>Add Distance and Bearing to Center</para>
		/// <para>Specifies whether fields will be added to the output for distance and bearing to a center point.</para>
		/// <para>Do not add distance and bearing—No distance or bearing fields will be added to the output. This is the default.</para>
		/// <para>Add distance and bearing—DIST_TO_CENTER and ANGLE_TO_CENTER fields will be added to the output.</para>
		/// <para><see cref="AddDistanceAndBearingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AddDistanceAndBearing { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public NumberFeatures SetEnviroment(object? extent = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Spatial Sort Method</para>
		/// </summary>
		public enum SpatialSortMethodEnum 
		{
			/// <summary>
			/// <para>Upper right—Features will be sorted starting at the upper right corner. This is the default.</para>
			/// </summary>
			[GPValue("UR")]
			[Description("Upper right")]
			Upper_right,

			/// <summary>
			/// <para>Upper left—Features will be sorted starting at the upper left corner.</para>
			/// </summary>
			[GPValue("UL")]
			[Description("Upper left")]
			Upper_left,

			/// <summary>
			/// <para>Lower right—Features will be sorted starting at the lower right corner.</para>
			/// </summary>
			[GPValue("LR")]
			[Description("Lower right")]
			Lower_right,

			/// <summary>
			/// <para>Lower left—Features will be sorted starting at the lower left corner.</para>
			/// </summary>
			[GPValue("LL")]
			[Description("Lower left")]
			Lower_left,

			/// <summary>
			/// <para>Peano curve—Features will be sorted using a space-filling curve algorithm, also known as a Peano curve.</para>
			/// </summary>
			[GPValue("PEANO")]
			[Description("Peano curve")]
			Peano_curve,

			/// <summary>
			/// <para>Center—Features will be sorted starting from a center point (the mean center will be used if no center is supplied).</para>
			/// </summary>
			[GPValue("CENTER")]
			[Description("Center")]
			Center,

			/// <summary>
			/// <para>Counterclockwise—Features will be sorted starting from a center point and moving counterclockwise.</para>
			/// </summary>
			[GPValue("COUNTERCLOCKWISE")]
			[Description("Counterclockwise")]
			Counterclockwise,

			/// <summary>
			/// <para>Clockwise—Features will be sorted starting from a center point and moving clockwise.</para>
			/// </summary>
			[GPValue("CLOCKWISE")]
			[Description("Clockwise")]
			Clockwise,

			/// <summary>
			/// <para>None—No spatial sort will be used. The same order as the feature class will be used.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

		}

		/// <summary>
		/// <para>Field Type For New Field</para>
		/// </summary>
		public enum NewFieldTypeEnum 
		{
			/// <summary>
			/// <para>Short—The field will be of short type. This is the default.</para>
			/// </summary>
			[GPValue("SHORT")]
			[Description("Short")]
			Short,

			/// <summary>
			/// <para>Long—The field will be of long type.</para>
			/// </summary>
			[GPValue("LONG")]
			[Description("Long")]
			Long,

			/// <summary>
			/// <para>Text—The field will be of text type.</para>
			/// </summary>
			[GPValue("TEXT")]
			[Description("Text")]
			Text,

		}

		/// <summary>
		/// <para>Add Distance and Bearing to Center</para>
		/// </summary>
		public enum AddDistanceAndBearingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_DISTANCE")]
			ADD_DISTANCE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_ADD_DISTANCE")]
			DONT_ADD_DISTANCE,

		}

#endregion
	}
}
