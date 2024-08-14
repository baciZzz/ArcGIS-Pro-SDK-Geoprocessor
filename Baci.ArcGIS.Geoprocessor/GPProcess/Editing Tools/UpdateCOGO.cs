using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.EditingTools
{
	/// <summary>
	/// <para>Update COGO</para>
	/// <para>Updates the COGO attributes of COGO-enabled line features to match their line shape geometries.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class UpdateCOGO : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLineFeatures">
		/// <para>Input Line Features</para>
		/// <para>The COGO-enabled line features that will be updated.</para>
		/// </param>
		public UpdateCOGO(object InLineFeatures)
		{
			this.InLineFeatures = InLineFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Update COGO</para>
		/// </summary>
		public override string DisplayName => "Update COGO";

		/// <summary>
		/// <para>Tool Name : UpdateCOGO</para>
		/// </summary>
		public override string ToolName => "UpdateCOGO";

		/// <summary>
		/// <para>Tool Excute Name : edit.UpdateCOGO</para>
		/// </summary>
		public override string ExcuteName => "edit.UpdateCOGO";

		/// <summary>
		/// <para>Toolbox Display Name : Editing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Editing Tools";

		/// <summary>
		/// <para>Toolbox Alise : edit</para>
		/// </summary>
		public override string ToolboxAlise => "edit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InLineFeatures, DistancesType!, DistanceTolerance!, DirectionType!, MinimumDirectionDifference!, MinimumDirectionLateralOffset!, CombinedScaleFactor!, DirectionOffset!, UpdatedLineFeatures };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>The COGO-enabled line features that will be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InLineFeatures { get; set; }

		/// <summary>
		/// <para>Update Distance, Radius, and Arc Length</para>
		/// <para>Specifies how the input line&apos;s Distance, Radius, and Arc Length COGO attributes will be updated.</para>
		/// <para>Overwrite all values—All values (including NULL values) will be updated to match the shape length. This is the default.</para>
		/// <para>Update values using a minimum difference—Values that differ from the shape length by more than the specified tolerance will be updated to match the shape length.</para>
		/// <para>Do not update any values—Values will not be updated.</para>
		/// <para><see cref="DistancesTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistancesType { get; set; } = "OVERWRITE";

		/// <summary>
		/// <para>Minimum Distance Difference</para>
		/// <para>The minimum distance difference between the line shape length and the value in the Distance, Radius, and Arc Length fields. If the difference in the distances is larger than the specified tolerance, the attribute value in the Distance, Radius, or Arc Length fields will be updated to match the line shape length. The default value is 0 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? DistanceTolerance { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Update Directions</para>
		/// <para>Specifies how the input&apos;s Direction COGO attributes will be updated.</para>
		/// <para>Overwrite all values—All values (including NULL values) will be updated to match shape direction. This is the default.</para>
		/// <para>Update values using a minimum difference—Values that differ from the shape direction by more than the specified tolerance will be updated to match the shape direction.</para>
		/// <para>Do not update any values—Values will not be updated.</para>
		/// <para><see cref="DirectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DirectionType { get; set; } = "OVERWRITE";

		/// <summary>
		/// <para>Minimum Direction Difference (seconds)</para>
		/// <para>The minimum direction difference (in seconds) between the line shape direction and the value in the Direction field. If the difference in the directions is larger than the specified tolerance, the attribute value in the Direction field will be updated to match the line shape direction. The default value is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinimumDirectionDifference { get; set; }

		/// <summary>
		/// <para>Minimum Direction Lateral Offset</para>
		/// <para>The minimum allowable distance between the endpoint of the line shape and the endpoint of the line drawn using the value in the Direction field. A lateral offset tolerance can be used for very long lines in which small changes in direction can result in large differences in line endpoints. The default value is 0 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? MinimumDirectionLateralOffset { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Combined Scale Factor</para>
		/// <para>A scale factor based on a ground to grid correction that will be applied to the line's shape length. The scale factor can be provided as a number or derived from an Arcade expression using the lines attribute fields. The updated distance populated in the Distance, Radius, and Arc Length fields is a result of the shape length multiplied by the scale factor.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCalculatorExpression()]
		public object? CombinedScaleFactor { get; set; } = "1.0";

		/// <summary>
		/// <para>Direction Offset (seconds)</para>
		/// <para>A rotation based on a ground to grid correction that will be applied to the line's shape direction. The rotation offset can be provided as a value in seconds or derived from an Arcade expression using the line's attribute fields. The updated direction populated in the line's Direction field is the line shape direction rotated by the specified direction offset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCalculatorExpression()]
		public object? DirectionOffset { get; set; } = "0.0";

		/// <summary>
		/// <para>Updated Line Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedLineFeatures { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Update Distance, Radius, and Arc Length</para>
		/// </summary>
		public enum DistancesTypeEnum 
		{
			/// <summary>
			/// <para>Overwrite all values—All values (including NULL values) will be updated to match the shape length. This is the default.</para>
			/// </summary>
			[GPValue("OVERWRITE")]
			[Description("Overwrite all values")]
			Overwrite_all_values,

			/// <summary>
			/// <para>Update values using a minimum difference—Values that differ from the shape length by more than the specified tolerance will be updated to match the shape length.</para>
			/// </summary>
			[GPValue("USE_MINIMUM_DIFFERENCE")]
			[Description("Update values using a minimum difference")]
			Update_values_using_a_minimum_difference,

			/// <summary>
			/// <para>Do not update any values—Values will not be updated.</para>
			/// </summary>
			[GPValue("DO_NOT_UPDATE")]
			[Description("Do not update any values")]
			Do_not_update_any_values,

		}

		/// <summary>
		/// <para>Update Directions</para>
		/// </summary>
		public enum DirectionTypeEnum 
		{
			/// <summary>
			/// <para>Overwrite all values—All values (including NULL values) will be updated to match shape direction. This is the default.</para>
			/// </summary>
			[GPValue("OVERWRITE")]
			[Description("Overwrite all values")]
			Overwrite_all_values,

			/// <summary>
			/// <para>Update values using a minimum difference—Values that differ from the shape direction by more than the specified tolerance will be updated to match the shape direction.</para>
			/// </summary>
			[GPValue("USE_MINIMUM_DIFFERENCE")]
			[Description("Update values using a minimum difference")]
			Update_values_using_a_minimum_difference,

			/// <summary>
			/// <para>Do not update any values—Values will not be updated.</para>
			/// </summary>
			[GPValue("DO_NOT_UPDATE")]
			[Description("Do not update any values")]
			Do_not_update_any_values,

		}

#endregion
	}
}
