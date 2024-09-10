using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Generate Routes</para>
	/// <para>Re-creates shapes and applies calibration changes for route features in an LRS Network.</para>
	/// </summary>
	public class GenerateRoutes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRouteFeatures">
		/// <para>Input Route Features</para>
		/// <para>The LRS Network for which route shapes will be regenerated and calibration changes will be applied.</para>
		/// </param>
		public GenerateRoutes(object InRouteFeatures)
		{
			this.InRouteFeatures = InRouteFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Routes</para>
		/// </summary>
		public override string DisplayName() => "Generate Routes";

		/// <summary>
		/// <para>Tool Name : GenerateRoutes</para>
		/// </summary>
		public override string ToolName() => "GenerateRoutes";

		/// <summary>
		/// <para>Tool Excute Name : locref.GenerateRoutes</para>
		/// </summary>
		public override string ExcuteName() => "locref.GenerateRoutes";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRouteFeatures, RecordCalibrationChanges, OutRouteFeatures, OutDerivedRouteFeatures, OutDetailsFile };

		/// <summary>
		/// <para>Input Route Features</para>
		/// <para>The LRS Network for which route shapes will be regenerated and calibration changes will be applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InRouteFeatures { get; set; }

		/// <summary>
		/// <para>Record calibration changes for event location updates</para>
		/// <para>Specifies whether event behaviors will be applied.</para>
		/// <para>Checked—Any calibration points created, modified, or deleted outside the Location Referencing tools will be applied to the routes in the network, and event behaviors will be applied the next time Apply Event Behaviors is run.</para>
		/// <para>Unchecked—Calibration changes will be applied to the routes in the LRS Network, but no event behaviors will be applied. This is the default.</para>
		/// <para><see cref="RecordCalibrationChangesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RecordCalibrationChanges { get; set; } = "false";

		/// <summary>
		/// <para>Output Route Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutRouteFeatures { get; set; }

		/// <summary>
		/// <para>Output Derived Route Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutDerivedRouteFeatures { get; set; }

		/// <summary>
		/// <para>Output Results File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object OutDetailsFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateRoutes SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Record calibration changes for event location updates</para>
		/// </summary>
		public enum RecordCalibrationChangesEnum 
		{
			/// <summary>
			/// <para>Unchecked—Calibration changes will be applied to the routes in the LRS Network, but no event behaviors will be applied. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_RECORD_CALIBRATION_CHANGES")]
			NO_RECORD_CALIBRATION_CHANGES,

			/// <summary>
			/// <para>Checked—Any calibration points created, modified, or deleted outside the Location Referencing tools will be applied to the routes in the network, and event behaviors will be applied the next time Apply Event Behaviors is run.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RECORD_CALIBRATION_CHANGES")]
			RECORD_CALIBRATION_CHANGES,

		}

#endregion
	}
}
