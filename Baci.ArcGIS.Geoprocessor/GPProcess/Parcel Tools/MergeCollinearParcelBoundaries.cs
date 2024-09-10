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
	/// <para>Merge Collinear Parcel Boundaries</para>
	/// <para>Merges  connected collinear parcel lines  into a single parcel line.</para>
	/// <para>  Shared parcel fabric points between connected collinear lines are deleted and vertices are created in their place.</para>
	/// </summary>
	public class MergeCollinearParcelBoundaries : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelBoundaries">
		/// <para>Input Parcel Boundaries</para>
		/// <para>The parcel lines to be merged. Lines can be parcel lines or connection lines.</para>
		/// </param>
		/// <param name="OffsetTolerance">
		/// <para>Offset Tolerance</para>
		/// <para>The maximum distance shared parcel points can be offset from their connected lines for the lines to be considered collinear. The offset is the distance between the shared parcel points and the straight lines between the endpoints of the connected parcel lines.</para>
		/// </param>
		public MergeCollinearParcelBoundaries(object InParcelBoundaries, object OffsetTolerance)
		{
			this.InParcelBoundaries = InParcelBoundaries;
			this.OffsetTolerance = OffsetTolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : Merge Collinear Parcel Boundaries</para>
		/// </summary>
		public override string DisplayName() => "Merge Collinear Parcel Boundaries";

		/// <summary>
		/// <para>Tool Name : MergeCollinearParcelBoundaries</para>
		/// </summary>
		public override string ToolName() => "MergeCollinearParcelBoundaries";

		/// <summary>
		/// <para>Tool Excute Name : parcel.MergeCollinearParcelBoundaries</para>
		/// </summary>
		public override string ExcuteName() => "parcel.MergeCollinearParcelBoundaries";

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
		public override object[] Parameters() => new object[] { InParcelBoundaries, OffsetTolerance, OutParcelBoundaries };

		/// <summary>
		/// <para>Input Parcel Boundaries</para>
		/// <para>The parcel lines to be merged. Lines can be parcel lines or connection lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InParcelBoundaries { get; set; }

		/// <summary>
		/// <para>Offset Tolerance</para>
		/// <para>The maximum distance shared parcel points can be offset from their connected lines for the lines to be considered collinear. The offset is the distance between the shared parcel points and the straight lines between the endpoints of the connected parcel lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object OffsetTolerance { get; set; } = "0.5 Meters";

		/// <summary>
		/// <para>Updated Parcel Boundaries</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutParcelBoundaries { get; set; }

	}
}
