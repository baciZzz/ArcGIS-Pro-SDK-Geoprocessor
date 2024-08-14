using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Collapse Hydro Polygon</para>
	/// <para>Collapses or partially collapses hydro polygons to a </para>
	/// <para>centerline based on a collapse width.</para>
	/// </summary>
	public class CollapseHydroPolygon : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Hydro Polygon Features</para>
		/// <para>One or more feature layers containing hydro polygons.</para>
		/// </param>
		/// <param name="OutLineFeatureClass">
		/// <para>Output Line Feature Class</para>
		/// <para>The line feature class containing the centerlines of the collapsed polygons. It contains centerlines of all input polygons including those that are not collapsed. This feature class has a COLLAPSED attribute that specifies whether the centerline feature represents a collapsed polygon.</para>
		/// </param>
		public CollapseHydroPolygon(object InFeatures, object OutLineFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutLineFeatureClass = OutLineFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Collapse Hydro Polygon</para>
		/// </summary>
		public override string DisplayName => "Collapse Hydro Polygon";

		/// <summary>
		/// <para>Tool Name : CollapseHydroPolygon</para>
		/// </summary>
		public override string ToolName => "CollapseHydroPolygon";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CollapseHydroPolygon</para>
		/// </summary>
		public override string ExcuteName => "cartography.CollapseHydroPolygon";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cartographicPartitions" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutLineFeatureClass, MergeAdjacentInputPolygons!, ConnectingFeatures!, CollapseWidth!, CollapseWidthTolerance!, MinimumLength!, TaperLengthPercentage!, OutPolyFeatureClass!, InPolyDecodeIdTable!, InLineDecodeIdTable! };

		/// <summary>
		/// <para>Input Hydro Polygon Features</para>
		/// <para>One or more feature layers containing hydro polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Line Feature Class</para>
		/// <para>The line feature class containing the centerlines of the collapsed polygons. It contains centerlines of all input polygons including those that are not collapsed. This feature class has a COLLAPSED attribute that specifies whether the centerline feature represents a collapsed polygon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		public object OutLineFeatureClass { get; set; }

		/// <summary>
		/// <para>Merge Adjacent Input Polygons</para>
		/// <para>Specifies whether adjacent input polygons will be merged before calculating the centerlines.</para>
		/// <para>Checked—Input hydro polygons will be merged before calculating the centerlines. This is the default.</para>
		/// <para>Unchecked—Centerlines will be calculated from input hydro polygons that are not merged.</para>
		/// <para><see cref="MergeAdjacentInputPolygonsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MergeAdjacentInputPolygons { get; set; } = "true";

		/// <summary>
		/// <para>Connecting Hydro Line Features</para>
		/// <para>Input hydro line features that connect to the input hydro polygons to be collapsed. Line features will be created to maintain these connections.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		public object? ConnectingFeatures { get; set; }

		/// <summary>
		/// <para>Collapse Width</para>
		/// <para>The threshold width of an input hydro polygon to be considered for collapse. All polygons below the specified width will be collapsed. The default value is 0, which will collapse all features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? CollapseWidth { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Collapse Width Tolerance (%)</para>
		/// <para>A percentage tolerance within which features will be analyzed and the surrounding context will be considered when determining whether to collapse a feature. This is to minimize oscillations within the collapse. The default value is 20 percent. This parameter is applied only when the Collapse Width parameter value is specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? CollapseWidthTolerance { get; set; } = "20";

		/// <summary>
		/// <para>Minimum Length</para>
		/// <para>The minimum length required for a polygon to be retained in the output polygon feature class. The minimum length is based on the length of the centerline created for the polygon. If the centerline of a polygon is longer than the collapse width but shorter than the minimum length, the polygon will not be included in the output polygon feature class. The default value is 0. This parameter is applied only when the Collapse Width parameter value is specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? MinimumLength { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Taper Length Percentage</para>
		/// <para>The length that connections between polygons in the output polygon feature class and the output line feature class will be tapered. This parameter specifies the length of the tapering as a percentage of the width at the connection location. A taper length percentage value of 0 will result in no tapering. The default value is 50. This parameter is applied only when the Collapse Width parameter value is specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? TaperLengthPercentage { get; set; } = "50";

		/// <summary>
		/// <para>Output Polygon Feature Class</para>
		/// <para>The polygon feature class containing the portions of the input hydro polygons that are not collapsed. This parameter is applied only when the Collapse Width parameter value is specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		public object? OutPolyFeatureClass { get; set; }

		/// <summary>
		/// <para>InPoly Decode ID Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? InPolyDecodeIdTable { get; set; }

		/// <summary>
		/// <para>InLine Decode ID Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? InLineDecodeIdTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CollapseHydroPolygon SetEnviroment(object? cartographicPartitions = null )
		{
			base.SetEnv(cartographicPartitions: cartographicPartitions);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Merge Adjacent Input Polygons</para>
		/// </summary>
		public enum MergeAdjacentInputPolygonsEnum 
		{
			/// <summary>
			/// <para>Checked—Input hydro polygons will be merged before calculating the centerlines. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MERGE_ADJACENT")]
			MERGE_ADJACENT,

			/// <summary>
			/// <para>Unchecked—Centerlines will be calculated from input hydro polygons that are not merged.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MERGE")]
			NO_MERGE,

		}

#endregion
	}
}
