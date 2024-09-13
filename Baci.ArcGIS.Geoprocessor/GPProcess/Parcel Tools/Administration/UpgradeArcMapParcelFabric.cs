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
	/// <para>Upgrade ArcMap Parcel Fabric</para>
	/// <para>Upgrade ArcMap Parcel Fabric</para>
	/// <para>Upgrades an ArcMap  parcel fabric to an ArcGIS Pro parcel fabric.</para>
	/// </summary>
	public class UpgradeArcMapParcelFabric : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFabric">
		/// <para>Input Parcel Fabric For ArcMap</para>
		/// <para>The ArcMap parcel fabric that will be upgraded to an ArcGIS Pro parcel fabric.</para>
		/// </param>
		/// <param name="TargetDataset">
		/// <para>Target Feature Dataset</para>
		/// <para>The feature dataset that will contain the upgraded ArcGIS Pro parcel fabric.</para>
		/// </param>
		/// <param name="Name">
		/// <para>Name</para>
		/// <para>The name of the upgraded ArcGIS Pro parcel fabric.</para>
		/// </param>
		public UpgradeArcMapParcelFabric(object InParcelFabric, object TargetDataset, object Name)
		{
			this.InParcelFabric = InParcelFabric;
			this.TargetDataset = TargetDataset;
			this.Name = Name;
		}

		/// <summary>
		/// <para>Tool Display Name : Upgrade ArcMap Parcel Fabric</para>
		/// </summary>
		public override string DisplayName() => "Upgrade ArcMap Parcel Fabric";

		/// <summary>
		/// <para>Tool Name : UpgradeArcMapParcelFabric</para>
		/// </summary>
		public override string ToolName() => "UpgradeArcMapParcelFabric";

		/// <summary>
		/// <para>Tool Excute Name : parcel.UpgradeArcMapParcelFabric</para>
		/// </summary>
		public override string ExcuteName() => "parcel.UpgradeArcMapParcelFabric";

		/// <summary>
		/// <para>Toolbox Display Name : Parcel Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Parcel Tools";

		/// <summary>
		/// <para>Toolbox Alise : parcel</para>
		/// </summary>
		public override string ToolboxAlise() => "parcel";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InParcelFabric, TargetDataset, Name, OutParcelFabric!, DeleteIdentical! };

		/// <summary>
		/// <para>Input Parcel Fabric For ArcMap</para>
		/// <para>The ArcMap parcel fabric that will be upgraded to an ArcGIS Pro parcel fabric.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCadastralFabricLayer()]
		public object InParcelFabric { get; set; }

		/// <summary>
		/// <para>Target Feature Dataset</para>
		/// <para>The feature dataset that will contain the upgraded ArcGIS Pro parcel fabric.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object TargetDataset { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// <para>The name of the upgraded ArcGIS Pro parcel fabric.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Output Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object? OutParcelFabric { get; set; }

		/// <summary>
		/// <para>Delete identical overlapping lines</para>
		/// <para>Specifies whether identical overlapping lines will be deleted. When this parameter is checked, overlapping lines will be deleted if the line shapes are identical (lines are coincident) and they have the following matching attributes:</para>
		/// <para>Directions in the Direction field. This includes directions that are reversed by 180 degrees.</para>
		/// <para>Distances in the Distance field. Distances are rounded to four decimal places.</para>
		/// <para>Records in the Created By Record field.</para>
		/// <para>Records in the Retired By Record field.</para>
		/// <para>Checked—Identical overlapping lines will be deleted.</para>
		/// <para>Unchecked—Identical overlapping lines will not be deleted. This is the default.</para>
		/// <para><see cref="DeleteIdenticalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeleteIdentical { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Delete identical overlapping lines</para>
		/// </summary>
		public enum DeleteIdenticalEnum 
		{
			/// <summary>
			/// <para>Checked—Identical overlapping lines will be deleted.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_IDENTICAL_LINES")]
			DELETE_IDENTICAL_LINES,

			/// <summary>
			/// <para>Unchecked—Identical overlapping lines will not be deleted. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_IDENTICAL_LINES")]
			KEEP_IDENTICAL_LINES,

		}

#endregion
	}
}
