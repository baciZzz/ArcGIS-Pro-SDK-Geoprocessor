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
	/// <para>Generate Parcel Fabric Links</para>
	/// <para>Generates displacement links for parcel fabric points that have changed</para>
	/// <para>locations in a specified time period.</para>
	/// </summary>
	public class GenerateParcelFabricLinks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetParcelFabric">
		/// <para>Input Parcel Fabric</para>
		/// <para>The parcel fabric that will be used to generate links. The parcel fabric must be published as a feature service and the default version is used to generate links.</para>
		/// </param>
		/// <param name="OutLinksFeatureClass">
		/// <para>Output Links Feature Class</para>
		/// <para>The output line feature class that will store the generated links.</para>
		/// </param>
		/// <param name="OutAnchorPointsFeatureClass">
		/// <para>Output Anchor Points Feature Class</para>
		/// <para>The output point feature class that will store the anchor points.</para>
		/// </param>
		/// <param name="FromDate">
		/// <para>From Date</para>
		/// <para>The date from which to search the parcel fabric for points that have changed locations. Links and anchor points will be only be generated for points on or after this date.</para>
		/// </param>
		public GenerateParcelFabricLinks(object TargetParcelFabric, object OutLinksFeatureClass, object OutAnchorPointsFeatureClass, object FromDate)
		{
			this.TargetParcelFabric = TargetParcelFabric;
			this.OutLinksFeatureClass = OutLinksFeatureClass;
			this.OutAnchorPointsFeatureClass = OutAnchorPointsFeatureClass;
			this.FromDate = FromDate;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Parcel Fabric Links</para>
		/// </summary>
		public override string DisplayName => "Generate Parcel Fabric Links";

		/// <summary>
		/// <para>Tool Name : GenerateParcelFabricLinks</para>
		/// </summary>
		public override string ToolName => "GenerateParcelFabricLinks";

		/// <summary>
		/// <para>Tool Excute Name : parcel.GenerateParcelFabricLinks</para>
		/// </summary>
		public override string ExcuteName => "parcel.GenerateParcelFabricLinks";

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
		public override object[] Parameters => new object[] { TargetParcelFabric, OutLinksFeatureClass, OutAnchorPointsFeatureClass, FromDate, ToDate, MinLinkLength, Extent };

		/// <summary>
		/// <para>Input Parcel Fabric</para>
		/// <para>The parcel fabric that will be used to generate links. The parcel fabric must be published as a feature service and the default version is used to generate links.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object TargetParcelFabric { get; set; }

		/// <summary>
		/// <para>Output Links Feature Class</para>
		/// <para>The output line feature class that will store the generated links.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		public object OutLinksFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Anchor Points Feature Class</para>
		/// <para>The output point feature class that will store the anchor points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		public object OutAnchorPointsFeatureClass { get; set; }

		/// <summary>
		/// <para>From Date</para>
		/// <para>The date from which to search the parcel fabric for points that have changed locations. Links and anchor points will be only be generated for points on or after this date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDate()]
		public object FromDate { get; set; }

		/// <summary>
		/// <para>To Date</para>
		/// <para>The end date of the time period in which to search the parcel fabric for points that have changed locations. Links and anchor points will only be generated for points on or before this date. If no To date is specified, links and anchor points will be generated for all points on or after the specified From Date. If the To Date is specified at a future date, links will be generated in the time period between the From Date and the current date and time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object ToDate { get; set; }

		/// <summary>
		/// <para>Minimum Link Length</para>
		/// <para>The minimum length of the generated links. If the link length between the current points and their original locations is smaller than the specified value, anchor points are created for the original locations of the points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MinLinkLength { get; set; } = "0.01 Meters";

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
		public object Extent { get; set; }

	}
}
