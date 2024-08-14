using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Enrich Layer</para>
	/// <para>Enriches your data by adding demographic and landscape facts about the people and places that surround or are inside your data locations. The output is a duplicate of your input with new attribute fields added to the table.</para>
	/// <para>This tool requires an ArcGIS Online organizational account and consumes credits.</para>
	/// </summary>
	[Obsolete()]
	public class EnrichLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The features to enrich with new data.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class, which is a copy of the input features with new attribute fields added.</para>
		/// </param>
		/// <param name="Country">
		/// <para>Country</para>
		/// <para>The country whose data collections and variables are used to enrich the input. You can use the Global country code to obtain enriched data from anywhere in the world. Global can also be used when you have input features that are in more than one country.</para>
		/// </param>
		/// <param name="DataCollection">
		/// <para>Data Collection</para>
		/// <para>The collection of data used to enrich the input. You can specify a data collection without selecting any variables to enrich your data with all variables included in that collection. The Global country code only includes one data collection, KeyGlobalFacts.</para>
		/// </param>
		public EnrichLayer(object InFeatures, object OutFeatureClass, object Country, object DataCollection)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.Country = Country;
			this.DataCollection = DataCollection;
		}

		/// <summary>
		/// <para>Tool Display Name : Enrich Layer</para>
		/// </summary>
		public override string DisplayName => "Enrich Layer";

		/// <summary>
		/// <para>Tool Name : EnrichLayer</para>
		/// </summary>
		public override string ToolName => "EnrichLayer";

		/// <summary>
		/// <para>Tool Excute Name : analysis.EnrichLayer</para>
		/// </summary>
		public override string ExcuteName => "analysis.EnrichLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, Country, DataCollection, Variables, BufferType, Distance, Unit, Collectionmemory };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The features to enrich with new data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class, which is a copy of the input features with new attribute fields added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Country</para>
		/// <para>The country whose data collections and variables are used to enrich the input. You can use the Global country code to obtain enriched data from anywhere in the world. Global can also be used when you have input features that are in more than one country.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Country { get; set; }

		/// <summary>
		/// <para>Data Collection</para>
		/// <para>The collection of data used to enrich the input. You can specify a data collection without selecting any variables to enrich your data with all variables included in that collection. The Global country code only includes one data collection, KeyGlobalFacts.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DataCollection { get; set; }

		/// <summary>
		/// <para>Variables</para>
		/// <para>The specific variables used to enrich the input. Variables can be from one or multiple data collections.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Variables { get; set; }

		/// <summary>
		/// <para>Define areas to enrich</para>
		/// <para>If the input features are points, you must define an area around them to enrich from one of the following seven types. If the input features are lines, Straight line (Euclidean distance) is the only valid option.</para>
		/// <para>Straight line (Euclidean distance)—Straight-line or Euclidean distance is used as the distance measure.</para>
		/// <para>Driving time—Driving time is used as the distance measure. Current posted speed limits, one-way streets, and turn restrictions affect driving time.</para>
		/// <para>Driving distance—Driving distance is used as the distance measure. One-way streets and turn restrictions affect driving distance.</para>
		/// <para>Trucking time—Trucking time is used as the distance measure. Current posted speed limits, one-way streets, and turn restrictions affect trucking time. This option is similar to Driving time, but travel can only occur on roads that are suitable for trucks.</para>
		/// <para>Trucking distance—Trucking distance is used as the distance measure. One-way streets and turn restrictions affect trucking distance. This option is similar to Driving distance, but travel can only occur on roads that are suitable for trucks.</para>
		/// <para>Walking time—Walking time is used as the distance measure. Measurements are made using a walking speed of 5 KPH (3.1 MPH). Travel is allowed where pedestrians are allowed, such as trails, but not on limited-access highways.</para>
		/// <para>Walking distance—Walking distance is used as the distance measure. Travel is allowed where pedestrians are allowed, such as trails, but not on limited-access highways.</para>
		/// <para><see cref="BufferTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BufferType { get; set; } = "STRAIGHT_LINE";

		/// <summary>
		/// <para>Distance or time</para>
		/// <para>The value that determines the straight-line distance or drive time around the input features for areas to enrich. The unit of the distance or time should be supplied in the Unit parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Distance { get; set; } = "1";

		/// <summary>
		/// <para>Unit</para>
		/// <para>Specifies the unit for Distance or time parameter value.</para>
		/// <para>Miles—Miles</para>
		/// <para>Yards—Yards</para>
		/// <para>Feet—Feet</para>
		/// <para>Kilometers—Kilometers</para>
		/// <para>Meters—Meters</para>
		/// <para>Hours—Hours</para>
		/// <para>Minutes—Minutes</para>
		/// <para>Seconds—Seconds</para>
		/// <para><see cref="UnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Unit { get; set; } = "MILES";

		/// <summary>
		/// <para>Temporary data used for tool execution</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object Collectionmemory { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EnrichLayer SetEnviroment(object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputZFlag = null , object outputZValue = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Define areas to enrich</para>
		/// </summary>
		public enum BufferTypeEnum 
		{
			/// <summary>
			/// <para>Straight line (Euclidean distance)—Straight-line or Euclidean distance is used as the distance measure.</para>
			/// </summary>
			[GPValue("STRAIGHT_LINE")]
			[Description("Straight line (Euclidean distance)")]
			STRAIGHT_LINE,

			/// <summary>
			/// <para>Driving distance—Driving distance is used as the distance measure. One-way streets and turn restrictions affect driving distance.</para>
			/// </summary>
			[GPValue("DRIVING_DISTANCE")]
			[Description("Driving distance")]
			Driving_distance,

			/// <summary>
			/// <para>Driving time—Driving time is used as the distance measure. Current posted speed limits, one-way streets, and turn restrictions affect driving time.</para>
			/// </summary>
			[GPValue("DRIVE_TIME")]
			[Description("Driving time")]
			Driving_time,

			/// <summary>
			/// <para>Trucking distance—Trucking distance is used as the distance measure. One-way streets and turn restrictions affect trucking distance. This option is similar to Driving distance, but travel can only occur on roads that are suitable for trucks.</para>
			/// </summary>
			[GPValue("TRUCKING_DISTANCE")]
			[Description("Trucking distance")]
			Trucking_distance,

			/// <summary>
			/// <para>Trucking time—Trucking time is used as the distance measure. Current posted speed limits, one-way streets, and turn restrictions affect trucking time. This option is similar to Driving time, but travel can only occur on roads that are suitable for trucks.</para>
			/// </summary>
			[GPValue("TRUCKING_TIME")]
			[Description("Trucking time")]
			Trucking_time,

			/// <summary>
			/// <para>Walking distance—Walking distance is used as the distance measure. Travel is allowed where pedestrians are allowed, such as trails, but not on limited-access highways.</para>
			/// </summary>
			[GPValue("WALKING_DISTANCE")]
			[Description("Walking distance")]
			Walking_distance,

			/// <summary>
			/// <para>Walking time—Walking time is used as the distance measure. Measurements are made using a walking speed of 5 KPH (3.1 MPH). Travel is allowed where pedestrians are allowed, such as trails, but not on limited-access highways.</para>
			/// </summary>
			[GPValue("WALKING_TIME")]
			[Description("Walking time")]
			Walking_time,

		}

		/// <summary>
		/// <para>Unit</para>
		/// </summary>
		public enum UnitEnum 
		{
			/// <summary>
			/// <para>Miles—Miles</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para>Yards—Yards</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para>Feet—Feet</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>Kilometers—Kilometers</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Meters—Meters</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Hours—Hours</para>
			/// </summary>
			[GPValue("HOURS")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para>Minutes—Minutes</para>
			/// </summary>
			[GPValue("MINUTES")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para>Seconds—Seconds</para>
			/// </summary>
			[GPValue("SECONDS")]
			[Description("Seconds")]
			Seconds,

		}

#endregion
	}
}
