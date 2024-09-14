using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Calculate Metrics</para>
	/// <para>Calculate Metrics</para>
	/// <para>Populates metrics for features in a geodatabase. Metrics include length, width, area, and elevation attributes.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class CalculateMetrics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The features for which metrics will be calculated.</para>
		/// </param>
		/// <param name="InMetricTypes">
		/// <para>Input Metric Types</para>
		/// <para>Specifies the types of metrics that will be calculated.</para>
		/// <para>Angle of orientation—Angle of orientation metrics will be calculated</para>
		/// <para>Area—Area metrics will be calculated.</para>
		/// <para>Elevation—Elevation metrics will be calculated.</para>
		/// <para>Length—Length metrics will be calculated.</para>
		/// <para>Military Grid Reference System—Military Grid Reference System coordinates will be calculated.</para>
		/// <para>Width—Width metrics will be calculated.</para>
		/// <para><see cref="InMetricTypesEnum"/></para>
		/// </param>
		public CalculateMetrics(object InFeatures, object InMetricTypes)
		{
			this.InFeatures = InFeatures;
			this.InMetricTypes = InMetricTypes;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Metrics</para>
		/// </summary>
		public override string DisplayName() => "Calculate Metrics";

		/// <summary>
		/// <para>Tool Name : CalculateMetrics</para>
		/// </summary>
		public override string ToolName() => "CalculateMetrics";

		/// <summary>
		/// <para>Tool Excute Name : topographic.CalculateMetrics</para>
		/// </summary>
		public override string ExcuteName() => "topographic.CalculateMetrics";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise() => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, InMetricTypes, InLengthAttributes!, InWidthAttributes!, InAreaAttributes!, InAngleAttributes!, InElevationAttributes!, InPrecision!, OutFeatures!, MgrsAttributes!, MgrsPrecision! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The features for which metrics will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Metric Types</para>
		/// <para>Specifies the types of metrics that will be calculated.</para>
		/// <para>Angle of orientation—Angle of orientation metrics will be calculated</para>
		/// <para>Area—Area metrics will be calculated.</para>
		/// <para>Elevation—Elevation metrics will be calculated.</para>
		/// <para>Length—Length metrics will be calculated.</para>
		/// <para>Military Grid Reference System—Military Grid Reference System coordinates will be calculated.</para>
		/// <para>Width—Width metrics will be calculated.</para>
		/// <para><see cref="InMetricTypesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object InMetricTypes { get; set; } = "LENGTH;WIDTH;AREA;ANGLE_OF_ORIENTATION;ELEVATION;MGRS";

		/// <summary>
		/// <para>Input Length Attributes</para>
		/// <para>A comma-delimited string of field names from which the length metrics will be calculated. The default is LEG,LEN,LEN_,LGN,LZN. You can add the names of other length metric fields; if the fields exist in the Input Features value, they will be computed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced")]
		public object? InLengthAttributes { get; set; } = "LEG,LEN,LEN_,LGN,LZN";

		/// <summary>
		/// <para>Input Width Attributes</para>
		/// <para>A comma-delimited string of field names from which the width metrics will be calculated. The default is WID,WID_,WGP. You can add the names of other width metric fields; if the fields exist in the Input Features value, they will be computed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced")]
		public object? InWidthAttributes { get; set; } = "WID,WID_,WGP";

		/// <summary>
		/// <para>Input Area Attributes</para>
		/// <para>A comma-delimited string of field names from which the area metrics will be calculated. The default is ARA,ARE,ARE_. You can add the names of other area metric fields; if the fields exist in the Input Features value, they will be computed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced")]
		public object? InAreaAttributes { get; set; } = "ARA,ARE,ARE_";

		/// <summary>
		/// <para>Input Angle of Orientation Attributes</para>
		/// <para>A comma-delimited string of field names from which the angle of orientation metrics will be calculated. The default is AOO,DOF,FEO. You can add the names of other angle of orientation metric fields; if the fields exist in the Input Features value, they will be computed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced")]
		public object? InAngleAttributes { get; set; } = "AOO,DOF,FEO";

		/// <summary>
		/// <para>Input Elevation Attributes</para>
		/// <para>A comma-delimited string of field names from which the elevation metrics will be calculated. The default is ZV2,ZVH. You can add the names of other elevation metric fields; if the fields exist in the Input Features value, they will be computed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced")]
		public object? InElevationAttributes { get; set; } = "ZV2,ZVH";

		/// <summary>
		/// <para>Input Floating Point Precision</para>
		/// <para>The precision of the metrics written to the target attributes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced")]
		public object? InPrecision { get; set; } = "0";

		/// <summary>
		/// <para>Output Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutFeatures { get; set; }

		/// <summary>
		/// <para>Input MGRS Attributes</para>
		/// <para>A comma-delimited string of field names from which the MGRS coordinates will be calculated. The default is MGRSValue,MGRS. You can add the names of other MGRS fields; if the fields exist in the Input Features value, they will be computed. The fields must have a String field type and a field length greater than the largest possible MGRS coordinate value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced")]
		public object? MgrsAttributes { get; set; } = "MGRSValue,MGRS";

		/// <summary>
		/// <para>MGRS Precision</para>
		/// <para>Specifies the precision of the coordinates that will be calculated for the target attributes.</para>
		/// <para>6×8 (4Q)—The precision will be calculated at grid-level precision, typically the polygon formed by a 6-degree wide UTM zone and 8-degree high latitude bands.</para>
		/// <para>100km (4QFJ)—The precision will be calculated at 100,000 meters squared.</para>
		/// <para>10km (4QFJ16)—The precision will be calculated at 10,000 meters squared.</para>
		/// <para>1km (4QFJ1267)—The precision will be calculated at 1,000 meters squared.</para>
		/// <para>100m (4QFJ123678)—The precision will be calculated at 100 meters squared.</para>
		/// <para>10m (4QFJ12346789)—The precision will be calculated at 10 meters squared.</para>
		/// <para>1m (4QFJ1234567890)—The precision will be calculated at 1 meter squared.</para>
		/// <para>Image City Map (1234)—The precision will be calculated at the level of an Image City Map (ICM). This is the default.</para>
		/// <para><see cref="MgrsPrecisionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? MgrsPrecision { get; set; } = "Image City Map (1234)";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateMetrics SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Input Metric Types</para>
		/// </summary>
		public enum InMetricTypesEnum 
		{
			/// <summary>
			/// <para>Length—Length metrics will be calculated.</para>
			/// </summary>
			[GPValue("LENGTH")]
			[Description("Length")]
			Length,

			/// <summary>
			/// <para>Width—Width metrics will be calculated.</para>
			/// </summary>
			[GPValue("WIDTH")]
			[Description("Width")]
			Width,

			/// <summary>
			/// <para>Area—Area metrics will be calculated.</para>
			/// </summary>
			[GPValue("AREA")]
			[Description("Area")]
			Area,

			/// <summary>
			/// <para>Angle of orientation—Angle of orientation metrics will be calculated</para>
			/// </summary>
			[GPValue("ANGLE_OF_ORIENTATION")]
			[Description("Angle of orientation")]
			Angle_of_orientation,

			/// <summary>
			/// <para>Elevation—Elevation metrics will be calculated.</para>
			/// </summary>
			[GPValue("ELEVATION")]
			[Description("Elevation")]
			Elevation,

			/// <summary>
			/// <para>Military Grid Reference System—Military Grid Reference System coordinates will be calculated.</para>
			/// </summary>
			[GPValue("MGRS")]
			[Description("Military Grid Reference System")]
			Military_Grid_Reference_System,

		}

		/// <summary>
		/// <para>MGRS Precision</para>
		/// </summary>
		public enum MgrsPrecisionEnum 
		{
			/// <summary>
			/// <para>6×8 (4Q)—The precision will be calculated at grid-level precision, typically the polygon formed by a 6-degree wide UTM zone and 8-degree high latitude bands.</para>
			/// </summary>
			[GPValue("6x8 (4Q)")]
			[Description("6×8 (4Q)")]
			_6x8_,

			/// <summary>
			/// <para>100km (4QFJ)—The precision will be calculated at 100,000 meters squared.</para>
			/// </summary>
			[GPValue("100km (4QFJ)")]
			[Description("100km (4QFJ)")]
			_100km_,

			/// <summary>
			/// <para>10km (4QFJ16)—The precision will be calculated at 10,000 meters squared.</para>
			/// </summary>
			[GPValue("10km (4QFJ16)")]
			[Description("10km (4QFJ16)")]
			_10km_,

			/// <summary>
			/// <para>1km (4QFJ1267)—The precision will be calculated at 1,000 meters squared.</para>
			/// </summary>
			[GPValue("1km (4QFJ1267)")]
			[Description("1km (4QFJ1267)")]
			_1km_,

			/// <summary>
			/// <para>100m (4QFJ123678)—The precision will be calculated at 100 meters squared.</para>
			/// </summary>
			[GPValue("100m (4QFJ123678)")]
			[Description("100m (4QFJ123678)")]
			_100m_,

			/// <summary>
			/// <para>10m (4QFJ12346789)—The precision will be calculated at 10 meters squared.</para>
			/// </summary>
			[GPValue("10m (4QFJ12346789)")]
			[Description("10m (4QFJ12346789)")]
			_10m_,

			/// <summary>
			/// <para>1m (4QFJ1234567890)—The precision will be calculated at 1 meter squared.</para>
			/// </summary>
			[GPValue("1m (4QFJ1234567890)")]
			[Description("1m (4QFJ1234567890)")]
			_1m_,

			/// <summary>
			/// <para>Image City Map (1234)—The precision will be calculated at the level of an Image City Map (ICM). This is the default.</para>
			/// </summary>
			[GPValue("Image City Map (1234)")]
			[Description("Image City Map (1234)")]
			Image_City_Map_,

		}

#endregion
	}
}
