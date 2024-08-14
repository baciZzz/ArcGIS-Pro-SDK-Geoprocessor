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
	/// <para>Set Parcel Line Label Position</para>
	/// <para>Sets the   label position of the line's COGO dimension to the left of the parcel  line, to the right of the parcel  line, or centered over the parcel line.</para>
	/// </summary>
	public class SetParcelLineLabelPosition : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFeatures">
		/// <para>Input Parcel Features</para>
		/// <para>The input parcel line layers with label positions that will be updated.</para>
		/// </param>
		public SetParcelLineLabelPosition(object InParcelFeatures)
		{
			this.InParcelFeatures = InParcelFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Parcel Line Label Position</para>
		/// </summary>
		public override string DisplayName => "Set Parcel Line Label Position";

		/// <summary>
		/// <para>Tool Name : SetParcelLineLabelPosition</para>
		/// </summary>
		public override string ToolName => "SetParcelLineLabelPosition";

		/// <summary>
		/// <para>Tool Excute Name : parcel.SetParcelLineLabelPosition</para>
		/// </summary>
		public override string ExcuteName => "parcel.SetParcelLineLabelPosition";

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
		public override object[] Parameters => new object[] { InParcelFeatures, UpdatedParcelFeatures };

		/// <summary>
		/// <para>Input Parcel Features</para>
		/// <para>The input parcel line layers with label positions that will be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		public object InParcelFeatures { get; set; }

		/// <summary>
		/// <para>Updated Parcel Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? UpdatedParcelFeatures { get; set; }

	}
}
