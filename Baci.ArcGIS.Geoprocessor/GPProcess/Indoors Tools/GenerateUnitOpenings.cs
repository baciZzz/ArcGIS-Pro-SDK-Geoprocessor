using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IndoorsTools
{
	/// <summary>
	/// <para>Generate Unit Openings</para>
	/// <para>Generate Unit Openings</para>
	/// <para>Creates unit openings as line features that model the location and physical extent of an entrance.</para>
	/// </summary>
	public class GenerateUnitOpenings : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUnitFeatures">
		/// <para>Input Unit Features</para>
		/// <para>The input polygon features representing unit footprints for one or more facilities. In the Indoors model, this is the Units layer. The tool only processes the levels that contain the selected features.</para>
		/// </param>
		/// <param name="InDetailFeatures">
		/// <para>Input Detail Features</para>
		/// <para>The input polyline features representing the architectural detail polylines.</para>
		/// </param>
		/// <param name="DoorDetailExpression">
		/// <para>Door Detail Expression</para>
		/// <para>An SQL expression used to identify which detail polylines represent doors.</para>
		/// </param>
		/// <param name="WallDetailExpression">
		/// <para>Wall Detail Expression</para>
		/// <para>An SQL expression used to identify which detail polylines represent walls.</para>
		/// </param>
		/// <param name="TargetOpenings">
		/// <para>Target Openings</para>
		/// <para>The existing polyline feature class or feature layer to which generated polylines will be written. In the Indoors model this is the Details layer.</para>
		/// </param>
		public GenerateUnitOpenings(object InUnitFeatures, object InDetailFeatures, object DoorDetailExpression, object WallDetailExpression, object TargetOpenings)
		{
			this.InUnitFeatures = InUnitFeatures;
			this.InDetailFeatures = InDetailFeatures;
			this.DoorDetailExpression = DoorDetailExpression;
			this.WallDetailExpression = WallDetailExpression;
			this.TargetOpenings = TargetOpenings;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Unit Openings</para>
		/// </summary>
		public override string DisplayName() => "Generate Unit Openings";

		/// <summary>
		/// <para>Tool Name : GenerateUnitOpenings</para>
		/// </summary>
		public override string ToolName() => "GenerateUnitOpenings";

		/// <summary>
		/// <para>Tool Excute Name : indoors.GenerateUnitOpenings</para>
		/// </summary>
		public override string ExcuteName() => "indoors.GenerateUnitOpenings";

		/// <summary>
		/// <para>Toolbox Display Name : Indoors Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Indoors Tools";

		/// <summary>
		/// <para>Toolbox Alise : indoors</para>
		/// </summary>
		public override string ToolboxAlise() => "indoors";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUnitFeatures, InDetailFeatures, DoorDetailExpression, WallDetailExpression, TargetOpenings, WallThicknessTolerance!, DeleteExistingOpenings!, UpdatedOpenings! };

		/// <summary>
		/// <para>Input Unit Features</para>
		/// <para>The input polygon features representing unit footprints for one or more facilities. In the Indoors model, this is the Units layer. The tool only processes the levels that contain the selected features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InUnitFeatures { get; set; }

		/// <summary>
		/// <para>Input Detail Features</para>
		/// <para>The input polyline features representing the architectural detail polylines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InDetailFeatures { get; set; }

		/// <summary>
		/// <para>Door Detail Expression</para>
		/// <para>An SQL expression used to identify which detail polylines represent doors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSQLExpression()]
		public object DoorDetailExpression { get; set; }

		/// <summary>
		/// <para>Wall Detail Expression</para>
		/// <para>An SQL expression used to identify which detail polylines represent walls.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSQLExpression()]
		public object WallDetailExpression { get; set; }

		/// <summary>
		/// <para>Target Openings</para>
		/// <para>The existing polyline feature class or feature layer to which generated polylines will be written. In the Indoors model this is the Details layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object TargetOpenings { get; set; }

		/// <summary>
		/// <para>Wall Thickness Tolerance</para>
		/// <para>The distance the tool will search inward and outward from the edge of a unit feature to find a door feature. The default unit of measurement is feet. The default value is 2 feet but can range from 0 to 6 feet.</para>
		/// <para><see cref="WallThicknessToleranceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object? WallThicknessTolerance { get; set; } = "2 Feet";

		/// <summary>
		/// <para>Delete Existing Openings</para>
		/// <para>Specifies whether existing opening features with a USE_TYPE field value of Opening will be deleted before creating new opening features. If deleted, the tool will replace existing openings with new openings if they are at the same location.</para>
		/// <para>Checked—Existing openings will be deleted.</para>
		/// <para>Unchecked—Existing openings will not be deleted. This is the default.</para>
		/// <para><see cref="DeleteExistingOpeningsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeleteExistingOpenings { get; set; } = "false";

		/// <summary>
		/// <para>Updated Openings</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedOpenings { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateUnitOpenings SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Wall Thickness Tolerance</para>
		/// </summary>
		public enum WallThicknessToleranceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

		}

		/// <summary>
		/// <para>Delete Existing Openings</para>
		/// </summary>
		public enum DeleteExistingOpeningsEnum 
		{
			/// <summary>
			/// <para>Unchecked—Existing openings will not be deleted. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_EXISTING")]
			KEEP_EXISTING,

			/// <summary>
			/// <para>Checked—Existing openings will be deleted.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_EXISTING")]
			DELETE_EXISTING,

		}

#endregion
	}
}
