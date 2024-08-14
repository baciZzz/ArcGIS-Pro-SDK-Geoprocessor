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
	/// <para>Delete Routes</para>
	/// <para>Deletes routes and associated data elements from the LRS Network.</para>
	/// </summary>
	public class DeleteRoutes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRouteFeatures">
		/// <para>Input Route Features</para>
		/// <para>The route feature class registered with the network.</para>
		/// </param>
		public DeleteRoutes(object InRouteFeatures)
		{
			this.InRouteFeatures = InRouteFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Delete Routes</para>
		/// </summary>
		public override string DisplayName => "Delete Routes";

		/// <summary>
		/// <para>Tool Name : DeleteRoutes</para>
		/// </summary>
		public override string ToolName => "DeleteRoutes";

		/// <summary>
		/// <para>Tool Excute Name : locref.DeleteRoutes</para>
		/// </summary>
		public override string ExcuteName => "locref.DeleteRoutes";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRouteFeatures, DeleteAssociatedCalibrationPoints, DeleteAssociatedEvents, DeleteAssociatedCenterlines, UpdatedRouteFeatures, OutDetailsFile, OutDerivedRouteFeatures };

		/// <summary>
		/// <para>Input Route Features</para>
		/// <para>The route feature class registered with the network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InRouteFeatures { get; set; }

		/// <summary>
		/// <para>Delete associated calibration points</para>
		/// <para>Specifies whether calibration points associated with the deleted routes will be deleted.</para>
		/// <para>Checked—Calibration points associated with the routes will be deleted.</para>
		/// <para>Unchecked—Calibration points associated with the routes will not be deleted. This is the default.</para>
		/// <para><see cref="DeleteAssociatedCalibrationPointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DeleteAssociatedCalibrationPoints { get; set; } = "false";

		/// <summary>
		/// <para>Delete associated events</para>
		/// <para>Specifies whether events associated with the deleted routes will be deleted.</para>
		/// <para>Checked—Events associated with the routes will be deleted.</para>
		/// <para>Unchecked—Events associated with the routes will not be deleted. This is the default.</para>
		/// <para><see cref="DeleteAssociatedEventsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DeleteAssociatedEvents { get; set; } = "false";

		/// <summary>
		/// <para>Delete associated centerlines</para>
		/// <para>Specifies whether centerlines that are exclusively associated with the deleted routes will be deleted.</para>
		/// <para>Checked—Centerlines exclusively associated with the selected routes will be deleted. If centerlines are shared between networks, those common centerlines will not be deleted.</para>
		/// <para>Unchecked—Centerlines will not be deleted. This is the default.</para>
		/// <para><see cref="DeleteAssociatedCenterlinesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DeleteAssociatedCenterlines { get; set; } = "false";

		/// <summary>
		/// <para>Updated Route Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object UpdatedRouteFeatures { get; set; }

		/// <summary>
		/// <para>Output Results File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object OutDetailsFile { get; set; }

		/// <summary>
		/// <para>Output Derived Route Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutDerivedRouteFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeleteRoutes SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Delete associated calibration points</para>
		/// </summary>
		public enum DeleteAssociatedCalibrationPointsEnum 
		{
			/// <summary>
			/// <para>Unchecked—Calibration points associated with the routes will not be deleted. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_CALIBRATION_POINTS")]
			NO_DELETE_CALIBRATION_POINTS,

			/// <summary>
			/// <para>Checked—Calibration points associated with the routes will be deleted.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_CALIBRATION_POINTS")]
			DELETE_CALIBRATION_POINTS,

		}

		/// <summary>
		/// <para>Delete associated events</para>
		/// </summary>
		public enum DeleteAssociatedEventsEnum 
		{
			/// <summary>
			/// <para>Unchecked—Events associated with the routes will not be deleted. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_EVENTS")]
			NO_DELETE_EVENTS,

			/// <summary>
			/// <para>Checked—Events associated with the routes will be deleted.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_EVENTS")]
			DELETE_EVENTS,

		}

		/// <summary>
		/// <para>Delete associated centerlines</para>
		/// </summary>
		public enum DeleteAssociatedCenterlinesEnum 
		{
			/// <summary>
			/// <para>Unchecked—Centerlines will not be deleted. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_CENTERLINES")]
			NO_DELETE_CENTERLINES,

			/// <summary>
			/// <para>Checked—Centerlines exclusively associated with the selected routes will be deleted. If centerlines are shared between networks, those common centerlines will not be deleted.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_CENTERLINES")]
			DELETE_CENTERLINES,

		}

#endregion
	}
}
