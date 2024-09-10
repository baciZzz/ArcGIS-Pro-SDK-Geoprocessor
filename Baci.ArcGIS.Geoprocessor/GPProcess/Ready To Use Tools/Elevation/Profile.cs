using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ReadyToUseTools
{
	/// <summary>
	/// <para>Profile</para>
	/// <para>Returns elevation profiles for the input line features.</para>
	/// </summary>
	public class Profile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputlinefeatures">
		/// <para>Input Line Features</para>
		/// <para>The line features that will be profiled over the surface inputs.</para>
		/// </param>
		public Profile(object Inputlinefeatures)
		{
			this.Inputlinefeatures = Inputlinefeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Profile</para>
		/// </summary>
		public override string DisplayName() => "Profile";

		/// <summary>
		/// <para>Tool Name : Profile</para>
		/// </summary>
		public override string ToolName() => "Profile";

		/// <summary>
		/// <para>Tool Excute Name : agolservices.Profile</para>
		/// </summary>
		public override string ExcuteName() => "agolservices.Profile";

		/// <summary>
		/// <para>Toolbox Display Name : Ready To Use Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Ready To Use Tools";

		/// <summary>
		/// <para>Toolbox Alise : agolservices</para>
		/// </summary>
		public override string ToolboxAlise() => "agolservices";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputlinefeatures, Profileidfield, Demresolution, Maximumsampledistance, Maximumsampledistanceunits, Outputprofile };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>The line features that will be profiled over the surface inputs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Inputlinefeatures { get; set; }

		/// <summary>
		/// <para>Profile ID Field</para>
		/// <para>A unique identifier to associate profiles with their corresponding input line features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Profileidfield { get; set; }

		/// <summary>
		/// <para>DEM Resolution</para>
		/// <para>Specifies the approximate spatial resolution (cell size) of the source elevation data used for the calculation.</para>
		/// <para>The resolution keyword is an approximation of the spatial resolution of the digital elevation model. Many elevation sources are distributed in units of arc seconds; the keyword is an approximation in meters for easier understanding.</para>
		/// <para>Finest—The finest units available for the extent are used.</para>
		/// <para>10 meters—The elevation source resolution is 1/3 arc second or approximately 10 meters.</para>
		/// <para>24 meters—The elevation source is the Airbus WorldDEM4Ortho dataset at 24 meters resolution.</para>
		/// <para>30 meters—The elevation source resolution is 1 arc second or approximately 30 meters.</para>
		/// <para>90 meters—The elevation source resolution is 3 arc seconds or approximately 90 meters. This is the default.</para>
		/// <para>500 meters—The elevation source resolution is 15 arc seconds or approximately 500 meters.</para>
		/// <para>1000 meters—The elevation source resolution is 30 arc seconds or approximately 1000 meters.</para>
		/// <para><see cref="DemresolutionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Demresolution { get; set; }

		/// <summary>
		/// <para>Maximum Sample Distance</para>
		/// <para>The maximum sample distance along the line used to sample elevation values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Maximumsampledistance { get; set; }

		/// <summary>
		/// <para>Maximum Sample Distance Units</para>
		/// <para>Specifies the units for the Maximum Sample Distance parameter.</para>
		/// <para>Meters—The units are meters. This is the default.</para>
		/// <para>Kilometers—The units are kilometers.</para>
		/// <para>Feet—The units are feet.</para>
		/// <para>Yards—The units are yards.</para>
		/// <para>Miles—The units are miles.</para>
		/// <para><see cref="MaximumsampledistanceunitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Maximumsampledistanceunits { get; set; } = "Meters";

		/// <summary>
		/// <para>Output Profile</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Outputprofile { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>DEM Resolution</para>
		/// </summary>
		public enum DemresolutionEnum 
		{
			/// <summary>
			/// <para>Finest—The finest units available for the extent are used.</para>
			/// </summary>
			[GPValue("FINEST")]
			[Description("Finest")]
			Finest,

			/// <summary>
			/// <para>10 meters—The elevation source resolution is 1/3 arc second or approximately 10 meters.</para>
			/// </summary>
			[GPValue("10m")]
			[Description("10 meters")]
			_10_meters,

			/// <summary>
			/// <para>24 meters—The elevation source is the Airbus WorldDEM4Ortho dataset at 24 meters resolution.</para>
			/// </summary>
			[GPValue("24m")]
			[Description("24 meters")]
			_24_meters,

			/// <summary>
			/// <para>30 meters—The elevation source resolution is 1 arc second or approximately 30 meters.</para>
			/// </summary>
			[GPValue("30m")]
			[Description("30 meters")]
			_30_meters,

			/// <summary>
			/// <para>90 meters—The elevation source resolution is 3 arc seconds or approximately 90 meters. This is the default.</para>
			/// </summary>
			[GPValue("90m")]
			[Description("90 meters")]
			_90_meters,

			/// <summary>
			/// <para>500 meters—The elevation source resolution is 15 arc seconds or approximately 500 meters.</para>
			/// </summary>
			[GPValue("500m")]
			[Description("500 meters")]
			_500_meters,

			/// <summary>
			/// <para>1000 meters—The elevation source resolution is 30 arc seconds or approximately 1000 meters.</para>
			/// </summary>
			[GPValue("1000m")]
			[Description("1000 meters")]
			_1000_meters,

		}

		/// <summary>
		/// <para>Maximum Sample Distance Units</para>
		/// </summary>
		public enum MaximumsampledistanceunitsEnum 
		{
			/// <summary>
			/// <para>Meters—The units are meters. This is the default.</para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Kilometers—The units are kilometers.</para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Feet—The units are feet.</para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>Yards—The units are yards.</para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para>Miles—The units are miles.</para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

#endregion
	}
}
