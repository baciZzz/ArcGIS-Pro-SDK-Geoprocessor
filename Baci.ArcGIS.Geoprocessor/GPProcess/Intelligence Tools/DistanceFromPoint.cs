using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Distance From Point</para>
	/// <para>Determine whether entities in a layer are within a certain distance of a coordinate location.</para>
	/// </summary>
	[Obsolete()]
	public class DistanceFromPoint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputPointFeatures">
		/// <para>Input Points</para>
		/// </param>
		/// <param name="InputCoordinateType">
		/// <para>Coordinate Type</para>
		/// <para>Decimal Degrees - Longitude first—Decimal Degrees - Longitude first. This is the default.</para>
		/// <para>Decimal Degrees - Latitude first—Decimal Degrees - Latitude first</para>
		/// <para>Degrees Minutes Seconds - Longitude first—Degrees Minutes Seconds - Longitude first</para>
		/// <para>Degrees Minutes Seconds - Latitude first—Degrees Minutes Seconds - Latitude first</para>
		/// <para>Degrees Decimal Minutes - Longitude first—Degrees Decimal Minutes - Longitude first</para>
		/// <para>Degrees Decimal Minutes - Latitude first—Degrees Decimal Minutes - Latitude first</para>
		/// <para>Military Grid Reference System—Military Grid Reference System notation</para>
		/// <para>US National Grid—US National Grid notation</para>
		/// <para>Universal Transverse Mercator—Universal Transverse Mercator notation</para>
		/// <para><see cref="InputCoordinateTypeEnum"/></para>
		/// </param>
		/// <param name="InputCoordinateString">
		/// <para>Coordinate Location</para>
		/// </param>
		/// <param name="InputSearchDistance">
		/// <para>Distance</para>
		/// </param>
		public DistanceFromPoint(object InputPointFeatures, object InputCoordinateType, object InputCoordinateString, object InputSearchDistance)
		{
			this.InputPointFeatures = InputPointFeatures;
			this.InputCoordinateType = InputCoordinateType;
			this.InputCoordinateString = InputCoordinateString;
			this.InputSearchDistance = InputSearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : Distance From Point</para>
		/// </summary>
		public override string DisplayName => "Distance From Point";

		/// <summary>
		/// <para>Tool Name : DistanceFromPoint</para>
		/// </summary>
		public override string ToolName => "DistanceFromPoint";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.DistanceFromPoint</para>
		/// </summary>
		public override string ExcuteName => "intelligence.DistanceFromPoint";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputPointFeatures, InputCoordinateType, InputCoordinateString, InputSearchDistance, InputSearchExpression, OutputIdList };

		/// <summary>
		/// <para>Input Points</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InputPointFeatures { get; set; }

		/// <summary>
		/// <para>Coordinate Type</para>
		/// <para>Decimal Degrees - Longitude first—Decimal Degrees - Longitude first. This is the default.</para>
		/// <para>Decimal Degrees - Latitude first—Decimal Degrees - Latitude first</para>
		/// <para>Degrees Minutes Seconds - Longitude first—Degrees Minutes Seconds - Longitude first</para>
		/// <para>Degrees Minutes Seconds - Latitude first—Degrees Minutes Seconds - Latitude first</para>
		/// <para>Degrees Decimal Minutes - Longitude first—Degrees Decimal Minutes - Longitude first</para>
		/// <para>Degrees Decimal Minutes - Latitude first—Degrees Decimal Minutes - Latitude first</para>
		/// <para>Military Grid Reference System—Military Grid Reference System notation</para>
		/// <para>US National Grid—US National Grid notation</para>
		/// <para>Universal Transverse Mercator—Universal Transverse Mercator notation</para>
		/// <para><see cref="InputCoordinateTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InputCoordinateType { get; set; } = "DD(long/lat)";

		/// <summary>
		/// <para>Coordinate Location</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputCoordinateString { get; set; }

		/// <summary>
		/// <para>Distance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object InputSearchDistance { get; set; }

		/// <summary>
		/// <para>Input Search Expression</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object InputSearchExpression { get; set; }

		/// <summary>
		/// <para>Output OIDs</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutputIdList { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Coordinate Type</para>
		/// </summary>
		public enum InputCoordinateTypeEnum 
		{
			/// <summary>
			/// <para>Decimal Degrees - Longitude first—Decimal Degrees - Longitude first. This is the default.</para>
			/// </summary>
			[GPValue("DD(long/lat)")]
			[Description("Decimal Degrees - Longitude first")]
			DD,

			/// <summary>
			/// <para>Decimal Degrees - Latitude first—Decimal Degrees - Latitude first</para>
			/// </summary>
			[GPValue("DD(lat/long)")]
			[Description("Decimal Degrees - Latitude first")]
			DD1,

			/// <summary>
			/// <para>Degrees Minutes Seconds - Longitude first—Degrees Minutes Seconds - Longitude first</para>
			/// </summary>
			[GPValue("DMS(long/lat)")]
			[Description("Degrees Minutes Seconds - Longitude first")]
			DMS,

			/// <summary>
			/// <para>Degrees Minutes Seconds - Latitude first—Degrees Minutes Seconds - Latitude first</para>
			/// </summary>
			[GPValue("DMS(lat/long)")]
			[Description("Degrees Minutes Seconds - Latitude first")]
			DMS1,

			/// <summary>
			/// <para>Degrees Decimal Minutes - Longitude first—Degrees Decimal Minutes - Longitude first</para>
			/// </summary>
			[GPValue("DDM(long/lat)")]
			[Description("Degrees Decimal Minutes - Longitude first")]
			DDM,

			/// <summary>
			/// <para>Degrees Decimal Minutes - Latitude first—Degrees Decimal Minutes - Latitude first</para>
			/// </summary>
			[GPValue("DDM(lat/long)")]
			[Description("Degrees Decimal Minutes - Latitude first")]
			DDM1,

			/// <summary>
			/// <para>Military Grid Reference System—Military Grid Reference System notation</para>
			/// </summary>
			[GPValue("MGRS")]
			[Description("Military Grid Reference System")]
			Military_Grid_Reference_System,

			/// <summary>
			/// <para>US National Grid—US National Grid notation</para>
			/// </summary>
			[GPValue("USNG")]
			[Description("US National Grid")]
			US_National_Grid,

			/// <summary>
			/// <para>Universal Transverse Mercator—Universal Transverse Mercator notation</para>
			/// </summary>
			[GPValue("UTM")]
			[Description("Universal Transverse Mercator")]
			Universal_Transverse_Mercator,

		}

#endregion
	}
}
