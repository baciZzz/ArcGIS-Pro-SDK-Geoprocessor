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
	/// <para>Add Parcel Type</para>
	/// <para>Add Parcel Type</para>
	/// <para>Adds a parcel type to a parcel fabric.</para>
	/// <para>A parcel type is defined by a separate polygon and  line feature class. Parcel type feature classes are controlled by the parcel fabric dataset.</para>
	/// </summary>
	public class AddParcelType : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFabric">
		/// <para>Input Parcel Fabric</para>
		/// <para>The parcel fabric to which the parcel type will be added. The parcel fabric can be from a file geodatabase or an enterprise geodatabase.</para>
		/// </param>
		/// <param name="Name">
		/// <para>Name</para>
		/// <para>The name of the parcel type. The name will be assigned to the output polygon and line feature classes.</para>
		/// </param>
		public AddParcelType(object InParcelFabric, object Name)
		{
			this.InParcelFabric = InParcelFabric;
			this.Name = Name;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Parcel Type</para>
		/// </summary>
		public override string DisplayName() => "Add Parcel Type";

		/// <summary>
		/// <para>Tool Name : AddParcelType</para>
		/// </summary>
		public override string ToolName() => "AddParcelType";

		/// <summary>
		/// <para>Tool Excute Name : parcel.AddParcelType</para>
		/// </summary>
		public override string ExcuteName() => "parcel.AddParcelType";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InParcelFabric, Name, UpdatedParcelFabric, OutPolygonFc, OutLineFc, AdministrativePolygon };

		/// <summary>
		/// <para>Input Parcel Fabric</para>
		/// <para>The parcel fabric to which the parcel type will be added. The parcel fabric can be from a file geodatabase or an enterprise geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object InParcelFabric { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// <para>The name of the parcel type. The name will be assigned to the output polygon and line feature classes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Updated Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object UpdatedParcelFabric { get; set; }

		/// <summary>
		/// <para>Output Polygon Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutPolygonFc { get; set; }

		/// <summary>
		/// <para>Output Line Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutLineFc { get; set; }

		/// <summary>
		/// <para>Use for administrative boundaries</para>
		/// <para>Specifies whether the parcel type will be used to store parcels with administrative boundaries or regular boundaries. Administrative boundaries are used for very large parcels such as country parcels or state parcels. The parcel type polygon feature class will not participate in the parcel fabric topology.</para>
		/// <para>Checked—The parcel type will be used to store administrative boundaries. The parcel type polygon feature class will not participate in the parcel fabric topology.</para>
		/// <para>Unchecked—The parcel type will not be used to store administrative boundaries. The parcel type polygon feature class will participate in the parcel fabric topology. This is the default.</para>
		/// <para><see cref="AdministrativePolygonEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AdministrativePolygon { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Use for administrative boundaries</para>
		/// </summary>
		public enum AdministrativePolygonEnum 
		{
			/// <summary>
			/// <para>Checked—The parcel type will be used to store administrative boundaries. The parcel type polygon feature class will not participate in the parcel fabric topology.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADMINISTRATIVE_POLYGON")]
			ADMINISTRATIVE_POLYGON,

			/// <summary>
			/// <para>Unchecked—The parcel type will not be used to store administrative boundaries. The parcel type polygon feature class will participate in the parcel fabric topology. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("TOPOLOGY_POLYGON")]
			TOPOLOGY_POLYGON,

		}

#endregion
	}
}
