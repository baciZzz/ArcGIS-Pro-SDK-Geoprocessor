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
	/// <para>Letter Features</para>
	/// <para>Adds a sequential letter to a new or existing field of a set of features.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class LetterFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input features that will be lettered.</para>
		/// </param>
		/// <param name="FieldToLetter">
		/// <para>Field to Letter (Existing or New)</para>
		/// <para>The input field that will be lettered. The field must be a new or existing text field.</para>
		/// </param>
		public LetterFeatures(object InFeatures, object FieldToLetter)
		{
			this.InFeatures = InFeatures;
			this.FieldToLetter = FieldToLetter;
		}

		/// <summary>
		/// <para>Tool Display Name : Letter Features</para>
		/// </summary>
		public override string DisplayName => "Letter Features";

		/// <summary>
		/// <para>Tool Name : LetterFeatures</para>
		/// </summary>
		public override string ToolName => "LetterFeatures";

		/// <summary>
		/// <para>Tool Excute Name : defense.LetterFeatures</para>
		/// </summary>
		public override string ExcuteName => "defense.LetterFeatures";

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
		public override object[] Parameters => new object[] { InFeatures, FieldToLetter, InArea!, SpatialSortMethod!, LetteringFormat!, StartingLetter!, OmitLetters!, CenterPoint!, AddDistanceAndBearing!, OutFeatureClass! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features that will be lettered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Field to Letter (Existing or New)</para>
		/// <para>The input field that will be lettered. The field must be a new or existing text field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object FieldToLetter { get; set; }

		/// <summary>
		/// <para>Input Area to Letter</para>
		/// <para>The area that will limit the features to letter; only features within this area will be lettered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		public object? InArea { get; set; }

		/// <summary>
		/// <para>Spatial Sort Method</para>
		/// <para>Specifies how features will be spatially sorted for the purpose of lettering. Features are not reordered in the table.</para>
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
		/// <para>Lettering Format</para>
		/// <para>Specifies the labeling format that will be used for each feature.</para>
		/// <para>Excel (A, B, C, ...)—An alpha character (for example, A, B, C) will be used as the label. This is the default.</para>
		/// <para>Grid (AA, AB, AC, ...)—A constant alpha character with an incrementing second alpha character grid (for example, AA, AB, AC) will be used.</para>
		/// <para>Alternating Grid (AA, BB, CC, ...)—A double alpha character that is incremented for each feature (for example, AA, BB, CC) will be used.</para>
		/// <para><see cref="LetteringFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LetteringFormat { get; set; } = "A_B_C";

		/// <summary>
		/// <para>Starting Letter</para>
		/// <para>The value that will be used to begin lettering.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? StartingLetter { get; set; } = "A";

		/// <summary>
		/// <para>Omit Letters</para>
		/// <para>The values that will be omitted from the lettering sequence.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? OmitLetters { get; set; }

		/// <summary>
		/// <para>Center Point</para>
		/// <para>The center point that will be used to sort and letter features.</para>
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
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LetterFeatures SetEnviroment(object? extent = null , object? scratchWorkspace = null , object? workspace = null )
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
		/// <para>Lettering Format</para>
		/// </summary>
		public enum LetteringFormatEnum 
		{
			/// <summary>
			/// <para>Excel (A, B, C, ...)—An alpha character (for example, A, B, C) will be used as the label. This is the default.</para>
			/// </summary>
			[GPValue("A_B_C")]
			[Description("Excel (A, B, C, ...)")]
			A_B_C,

			/// <summary>
			/// <para>Grid (AA, AB, AC, ...)—A constant alpha character with an incrementing second alpha character grid (for example, AA, AB, AC) will be used.</para>
			/// </summary>
			[GPValue("AA_AB_AC")]
			[Description("Grid (AA, AB, AC, ...)")]
			AA_AB_AC,

			/// <summary>
			/// <para>Alternating Grid (AA, BB, CC, ...)—A double alpha character that is incremented for each feature (for example, AA, BB, CC) will be used.</para>
			/// </summary>
			[GPValue("AA_BB_CC")]
			[Description("Alternating Grid (AA, BB, CC, ...)")]
			AA_BB_CC,

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
