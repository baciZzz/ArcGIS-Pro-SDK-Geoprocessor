using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ParcelTools
{
	/// <summary>
	/// <para>Apply Parcel Least Squares Adjustment</para>
	/// <para>Applies the results of a least squares adjustment to parcel  fabric feature classes. Least squares adjustment results stored in the AdjustmentLines and AdjustmentPoints feature classes are applied to the corresponding parcel line, connection line, and parcel fabric point feature classes.</para>
	/// </summary>
	public class ApplyParcelLeastSquaresAdjustment : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFabric">
		/// <para>Input Parcel Fabric</para>
		/// <para>The parcel fabric to be updated.</para>
		/// </param>
		public ApplyParcelLeastSquaresAdjustment(object InParcelFabric)
		{
			this.InParcelFabric = InParcelFabric;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Parcel Least Squares Adjustment</para>
		/// </summary>
		public override string DisplayName => "Apply Parcel Least Squares Adjustment";

		/// <summary>
		/// <para>Tool Name : ApplyParcelLeastSquaresAdjustment</para>
		/// </summary>
		public override string ToolName => "ApplyParcelLeastSquaresAdjustment";

		/// <summary>
		/// <para>Tool Excute Name : parcel.ApplyParcelLeastSquaresAdjustment</para>
		/// </summary>
		public override string ExcuteName => "parcel.ApplyParcelLeastSquaresAdjustment";

		/// <summary>
		/// <para>Toolbox Display Name : Parcel Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Parcel Tools";

		/// <summary>
		/// <para>Toolbox Alise : parcel</para>
		/// </summary>
		public override string ToolboxAlise => "parcel";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InParcelFabric, MovementTolerance, UpdatedParcelFabric, UpdateAttributes };

		/// <summary>
		/// <para>Input Parcel Fabric</para>
		/// <para>The parcel fabric to be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object InParcelFabric { get; set; }

		/// <summary>
		/// <para>Movement Tolerance</para>
		/// <para>The tolerance representing the minimum allowable coordinate shift when updating parcel fabric points. If the distance between the adjustment point and the parcel fabric point is greater than the specified tolerance, the parcel fabric point is updated to the location of the adjustment point. The default tolerance is 0.05 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MovementTolerance { get; set; } = "0.05 Meters";

		/// <summary>
		/// <para>Updated Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object UpdatedParcelFabric { get; set; }

		/// <summary>
		/// <para>Update Attribute Fields</para>
		/// <para>Specifies whether attribute fields in the parcel fabric Points feature class will be updated with statistical metadata. The XY Uncertainty, Error Ellipse Semi Major, Error Ellipse Semi Minor, and Error Ellipse Direction fields will be updated with the values stored in the same fields in the AdjustmentPoints feature class.</para>
		/// <para>Checked—Attribute fields in the parcel fabric Points feature class will be updated with statistical metadata.</para>
		/// <para>Unchecked—Attribute fields will not be updated. This is the default.</para>
		/// <para><see cref="UpdateAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UpdateAttributes { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Update Attribute Fields</para>
		/// </summary>
		public enum UpdateAttributesEnum 
		{
			/// <summary>
			/// <para>Checked—Attribute fields in the parcel fabric Points feature class will be updated with statistical metadata.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_ATTRIBUTES")]
			UPDATE_ATTRIBUTES,

			/// <summary>
			/// <para>Unchecked—Attribute fields will not be updated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UPDATE_ATTRIBUTES")]
			NO_UPDATE_ATTRIBUTES,

		}

#endregion
	}
}
