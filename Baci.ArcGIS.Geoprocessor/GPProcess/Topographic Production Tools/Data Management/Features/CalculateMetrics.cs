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
	/// <para>Populates metrics for features in a geodatabase. Metrics include length, width, area, and elevation attributes.</para>
	/// </summary>
	public class CalculateMetrics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The features on which metrics will be calculated.</para>
		/// </param>
		/// <param name="InMetricTypes">
		/// <para>Input Metric Types</para>
		/// <para>Specifies the types of metrics to calculate, including angle of orientation, area, elevation, length, and width.</para>
		/// <para>Angle of orientation—Calculate angle of orientation metrics</para>
		/// <para>Area—Calculate area metrics</para>
		/// <para>Elevation—Calculate elevation metrics</para>
		/// <para>Length—Calculate length metrics</para>
		/// <para>Width—Calculate width metrics</para>
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
		public override object[] Parameters() => new object[] { InFeatures, InMetricTypes, InLengthAttributes, InWidthAttributes, InAreaAttributes, InAngleAttributes, InElevationAttributes, InPrecision, OutFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The features on which metrics will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Metric Types</para>
		/// <para>Specifies the types of metrics to calculate, including angle of orientation, area, elevation, length, and width.</para>
		/// <para>Angle of orientation—Calculate angle of orientation metrics</para>
		/// <para>Area—Calculate area metrics</para>
		/// <para>Elevation—Calculate elevation metrics</para>
		/// <para>Length—Calculate length metrics</para>
		/// <para>Width—Calculate width metrics</para>
		/// <para><see cref="InMetricTypesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object InMetricTypes { get; set; } = "LENGTH;WIDTH;AREA;ANGLE_OF_ORIENTATION;ELEVATION";

		/// <summary>
		/// <para>Input Length Attributes</para>
		/// <para>A comma-delimited string of field names from which the length metrics will be calculated. The default is LEG,LEN,LEN_,LGN,LZN. You can add the names of other length metric fields; if the fields exist in Input Features, they will be computed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced")]
		public object InLengthAttributes { get; set; } = "LEG,LEN,LEN_,LGN,LZN";

		/// <summary>
		/// <para>Input Width Attributes</para>
		/// <para>A comma-delimited string of field names from which the width metrics will be calculated. The default is WID,WID_,WGP. You can add the names of other width metric fields; if the fields exist in Input Features, they will be computed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced")]
		public object InWidthAttributes { get; set; } = "WID,WID_,WGP";

		/// <summary>
		/// <para>Input Area Attributes</para>
		/// <para>A comma-delimited string of field names from which the area metrics will be calculated. The default is ARA,ARE,ARE_. You can add the names of other area metric fields; if the fields exist in Input Features, they will be computed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced")]
		public object InAreaAttributes { get; set; } = "ARA,ARE,ARE_";

		/// <summary>
		/// <para>Input Angle of Orientation Attributes</para>
		/// <para>A comma-delimited string of field names from which the angle of orientation metrics will be calculated. The default is AOO,DOF,FEO. You can add the names of other angle of orientation metric fields; if the fields exist in Input Features, they will be computed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced")]
		public object InAngleAttributes { get; set; } = "AOO,DOF,FEO";

		/// <summary>
		/// <para>Input Elevation Attributes</para>
		/// <para>A comma-delimited string of field names from which the elevation metrics will be calculated. The default is ZV2,ZVH. You can add the names of other elevation metric fields; if the fields exist in Input Features, they will be computed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced")]
		public object InElevationAttributes { get; set; } = "ZV2,ZVH";

		/// <summary>
		/// <para>Input Floating Point Precision</para>
		/// <para>The precision of the metrics written to the target attributes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced")]
		public object InPrecision { get; set; } = "0";

		/// <summary>
		/// <para>Output Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateMetrics SetEnviroment(object workspace = null )
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
			/// <para>Length—Calculate length metrics</para>
			/// </summary>
			[GPValue("LENGTH")]
			[Description("Length")]
			Length,

			/// <summary>
			/// <para>Width—Calculate width metrics</para>
			/// </summary>
			[GPValue("WIDTH")]
			[Description("Width")]
			Width,

			/// <summary>
			/// <para>Area—Calculate area metrics</para>
			/// </summary>
			[GPValue("AREA")]
			[Description("Area")]
			Area,

			/// <summary>
			/// <para>Angle of orientation—Calculate angle of orientation metrics</para>
			/// </summary>
			[GPValue("ANGLE_OF_ORIENTATION")]
			[Description("Angle of orientation")]
			Angle_of_orientation,

			/// <summary>
			/// <para>Elevation—Calculate elevation metrics</para>
			/// </summary>
			[GPValue("ELEVATION")]
			[Description("Elevation")]
			Elevation,

		}

#endregion
	}
}
