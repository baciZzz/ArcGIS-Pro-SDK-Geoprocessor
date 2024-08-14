using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AviationTools
{
	/// <summary>
	/// <para>Calculate ATS Route Attributes</para>
	/// <para>Calculates segment distance and bearing attributes on Air Traffic Service (ATS) route features.</para>
	/// </summary>
	public class CalculateATSRouteAttributes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input ATS Route Feature Layer</para>
		/// <para>The polyline features for which ATS route attributes will be calculated.</para>
		/// </param>
		/// <param name="AtsrouteAttributes">
		/// <para>ATS Route Attributes</para>
		/// <para>Specifies the ATS route attributes that will be calculated.</para>
		/// <para>Length—The route distance from the start to the end will be calculated.</para>
		/// <para>Magnetic Track—The adjusted value for magnetic variation from the start to the end of a route will be calculated.</para>
		/// <para>Reverse Magnetic Track—The adjusted value for magnetic variation from the end to the start of a route will be calculated.</para>
		/// <para>Reverse True Track—The bearing values of the route from the end position to the start of the route will be calculated.</para>
		/// <para>True Track—The bearing values of the route from the start position to the end of the route will be calculated.</para>
		/// </param>
		public CalculateATSRouteAttributes(object InFeatures, object AtsrouteAttributes)
		{
			this.InFeatures = InFeatures;
			this.AtsrouteAttributes = AtsrouteAttributes;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate ATS Route Attributes</para>
		/// </summary>
		public override string DisplayName => "Calculate ATS Route Attributes";

		/// <summary>
		/// <para>Tool Name : CalculateATSRouteAttributes</para>
		/// </summary>
		public override string ToolName => "CalculateATSRouteAttributes";

		/// <summary>
		/// <para>Tool Excute Name : aviation.CalculateATSRouteAttributes</para>
		/// </summary>
		public override string ExcuteName => "aviation.CalculateATSRouteAttributes";

		/// <summary>
		/// <para>Toolbox Display Name : Aviation Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Aviation Tools";

		/// <summary>
		/// <para>Toolbox Alise : aviation</para>
		/// </summary>
		public override string ToolboxAlise => "aviation";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, AtsrouteAttributes, MagneticVariationDate!, UpdatedFeatures! };

		/// <summary>
		/// <para>Input ATS Route Feature Layer</para>
		/// <para>The polyline features for which ATS route attributes will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>ATS Route Attributes</para>
		/// <para>Specifies the ATS route attributes that will be calculated.</para>
		/// <para>Length—The route distance from the start to the end will be calculated.</para>
		/// <para>Magnetic Track—The adjusted value for magnetic variation from the start to the end of a route will be calculated.</para>
		/// <para>Reverse Magnetic Track—The adjusted value for magnetic variation from the end to the start of a route will be calculated.</para>
		/// <para>Reverse True Track—The bearing values of the route from the end position to the start of the route will be calculated.</para>
		/// <para>True Track—The bearing values of the route from the start position to the end of the route will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object AtsrouteAttributes { get; set; }

		/// <summary>
		/// <para>Magnetic Variation Date</para>
		/// <para>The date for which the magnetic field values will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? MagneticVariationDate { get; set; }

		/// <summary>
		/// <para>Updated Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedFeatures { get; set; }

	}
}
