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
	/// <para>Build Parcel Fabric</para>
	/// <para>Builds parcels in a parcel fabric.  Parcels can be built from polygons or lines. If parcels are built from polygons, the tool creates parcel lines and parcel points. If parcels are built from lines, the tool creates the missing polygons and points.</para>
	/// <para>When building parcels from lines, parcel seeds are required.</para>
	/// </summary>
	public class BuildParcelFabric : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFabric">
		/// <para>Input Parcel Fabric</para>
		/// <para>The parcel fabric for which to parcels will be built. The parcel fabric can be from a file, enterprise, or mobile geodatabase, or from a a feature service.</para>
		/// </param>
		public BuildParcelFabric(object InParcelFabric)
		{
			this.InParcelFabric = InParcelFabric;
		}

		/// <summary>
		/// <para>Tool Display Name : Build Parcel Fabric</para>
		/// </summary>
		public override string DisplayName => "Build Parcel Fabric";

		/// <summary>
		/// <para>Tool Name : BuildParcelFabric</para>
		/// </summary>
		public override string ToolName => "BuildParcelFabric";

		/// <summary>
		/// <para>Tool Excute Name : parcel.BuildParcelFabric</para>
		/// </summary>
		public override string ExcuteName => "parcel.BuildParcelFabric";

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
		public override object[] Parameters => new object[] { InParcelFabric, Extent!, UpdatedParcelFabric!, RecordName! };

		/// <summary>
		/// <para>Input Parcel Fabric</para>
		/// <para>The parcel fabric for which to parcels will be built. The parcel fabric can be from a file, enterprise, or mobile geodatabase, or from a a feature service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object InParcelFabric { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>The extent of the dataset to be processed. Only features that fall within the specified extent will be processed.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Union of Inputs—The extent will be based on the maximum extent of all inputs.</para>
		/// <para>Intersection of Inputs—The extent will be based on the minimum area common to all inputs.</para>
		/// <para>Current Display Extent—The extent is equal to the visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? Extent { get; set; }

		/// <summary>
		/// <para>Updated Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object? UpdatedParcelFabric { get; set; }

		/// <summary>
		/// <para>Record Name</para>
		/// <para>The name of the existing parcel record. Only parcels associated with this record will be built.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? RecordName { get; set; }

	}
}
