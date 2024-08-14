using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Eliminate Polygon Part</para>
	/// <para>Creates a new output feature class containing the features from the input polygons with some parts or holes of a specified size deleted.</para>
	/// </summary>
	public class EliminatePolygonPart : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input feature class or layer whose features will be copied to the output feature class, with some parts or holes eliminated.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class containing the remaining parts.</para>
		/// </param>
		public EliminatePolygonPart(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Eliminate Polygon Part</para>
		/// </summary>
		public override string DisplayName => "Eliminate Polygon Part";

		/// <summary>
		/// <para>Tool Name : EliminatePolygonPart</para>
		/// </summary>
		public override string ToolName => "EliminatePolygonPart";

		/// <summary>
		/// <para>Tool Excute Name : management.EliminatePolygonPart</para>
		/// </summary>
		public override string ExcuteName => "management.EliminatePolygonPart";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "MDomain", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, Condition, PartArea, PartAreaPercent, PartOption };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input feature class or layer whose features will be copied to the output feature class, with some parts or holes eliminated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class containing the remaining parts.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Condition</para>
		/// <para>Specify how the parts to be eliminated will be determined.</para>
		/// <para>Area—Parts with an area less than that specified will be eliminated.</para>
		/// <para>Percent—Parts with a percent of the total outer area less than that specified will be eliminated.</para>
		/// <para>Area and percent—Parts with an area and percent less than that specified will be eliminated. Only if a polygon part meets both the area and percent criteria will it be deleted.</para>
		/// <para>Area or percent—Parts with an area or percent less than that specified will be eliminated. If a polygon part meets either the area or percent criteria, it will be deleted.</para>
		/// <para><see cref="ConditionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Condition { get; set; } = "AREA";

		/// <summary>
		/// <para>Area</para>
		/// <para>Eliminate parts smaller than this area.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object PartArea { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Percentage</para>
		/// <para>Eliminate parts smaller than this percentage of a feature's total outer area.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object PartAreaPercent { get; set; } = "0";

		/// <summary>
		/// <para>Eliminate contained parts only</para>
		/// <para>Determines what parts can be eliminated.</para>
		/// <para>Checked - Only parts totally contained by other parts can be eliminated. This is the default.</para>
		/// <para>Unchecked - Any parts can be eliminated.</para>
		/// <para><see cref="PartOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PartOption { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EliminatePolygonPart SetEnviroment(object MDomain = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Condition</para>
		/// </summary>
		public enum ConditionEnum 
		{
			/// <summary>
			/// <para>Area—Parts with an area less than that specified will be eliminated.</para>
			/// </summary>
			[GPValue("AREA")]
			[Description("Area")]
			Area,

			/// <summary>
			/// <para>Percent—Parts with a percent of the total outer area less than that specified will be eliminated.</para>
			/// </summary>
			[GPValue("PERCENT")]
			[Description("Percent")]
			Percent,

			/// <summary>
			/// <para>Area and percent—Parts with an area and percent less than that specified will be eliminated. Only if a polygon part meets both the area and percent criteria will it be deleted.</para>
			/// </summary>
			[GPValue("AREA_AND_PERCENT")]
			[Description("Area and percent")]
			Area_and_percent,

			/// <summary>
			/// <para>Area or percent—Parts with an area or percent less than that specified will be eliminated. If a polygon part meets either the area or percent criteria, it will be deleted.</para>
			/// </summary>
			[GPValue("AREA_OR_PERCENT")]
			[Description("Area or percent")]
			Area_or_percent,

		}

		/// <summary>
		/// <para>Eliminate contained parts only</para>
		/// </summary>
		public enum PartOptionEnum 
		{
			/// <summary>
			/// <para>Checked - Only parts totally contained by other parts can be eliminated. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CONTAINED_ONLY")]
			CONTAINED_ONLY,

			/// <summary>
			/// <para>Unchecked - Any parts can be eliminated.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ANY")]
			ANY,

		}

#endregion
	}
}
