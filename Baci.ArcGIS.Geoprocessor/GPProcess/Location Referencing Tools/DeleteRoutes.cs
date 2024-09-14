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
	/// <para>删除路径</para>
	/// <para>从 LRS 网络中删除路径和相关数据元素。</para>
	/// </summary>
	public class DeleteRoutes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRouteFeatures">
		/// <para>Input Route Features</para>
		/// <para>在网络中注册的路径要素类。</para>
		/// </param>
		public DeleteRoutes(object InRouteFeatures)
		{
			this.InRouteFeatures = InRouteFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 删除路径</para>
		/// </summary>
		public override string DisplayName() => "删除路径";

		/// <summary>
		/// <para>Tool Name : DeleteRoutes</para>
		/// </summary>
		public override string ToolName() => "DeleteRoutes";

		/// <summary>
		/// <para>Tool Excute Name : locref.DeleteRoutes</para>
		/// </summary>
		public override string ExcuteName() => "locref.DeleteRoutes";

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
		public override object[] Parameters() => new object[] { InRouteFeatures, DeleteAssociatedCalibrationPoints!, DeleteAssociatedEvents!, DeleteAssociatedCenterlines!, UpdatedRouteFeatures!, OutDetailsFile!, OutDerivedRouteFeatures! };

		/// <summary>
		/// <para>Input Route Features</para>
		/// <para>在网络中注册的路径要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InRouteFeatures { get; set; }

		/// <summary>
		/// <para>Delete associated calibration points</para>
		/// <para>指定是否删除与已删除路径关联的校准点。</para>
		/// <para>选中 - 将删除与路径关联的校准点。</para>
		/// <para>未选中 - 不会删除与路径关联的校准点。 这是默认设置。</para>
		/// <para><see cref="DeleteAssociatedCalibrationPointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeleteAssociatedCalibrationPoints { get; set; } = "false";

		/// <summary>
		/// <para>Delete associated events</para>
		/// <para>指定是否删除与已删除路径关联的事件。</para>
		/// <para>选中 - 将删除与路径关联的事件。</para>
		/// <para>未选中 - 不会删除与路径关联的事件。 这是默认设置。</para>
		/// <para><see cref="DeleteAssociatedEventsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeleteAssociatedEvents { get; set; } = "false";

		/// <summary>
		/// <para>Delete associated centerlines</para>
		/// <para>指定是否将删除仅与已删除路径关联的中心线。</para>
		/// <para>选中 - 将删除仅与所选路径关联的中心线。 如果在网络之间共享中心线，则不会删除这些公共中心线。</para>
		/// <para>未选中 - 不会删除中心线。 这是默认设置。</para>
		/// <para><see cref="DeleteAssociatedCenterlinesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeleteAssociatedCenterlines { get; set; } = "false";

		/// <summary>
		/// <para>Updated Route Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? UpdatedRouteFeatures { get; set; }

		/// <summary>
		/// <para>Output Results File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object? OutDetailsFile { get; set; }

		/// <summary>
		/// <para>Output Derived Route Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutDerivedRouteFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeleteRoutes SetEnviroment(object? workspace = null)
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_CALIBRATION_POINTS")]
			DELETE_CALIBRATION_POINTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_CALIBRATION_POINTS")]
			NO_DELETE_CALIBRATION_POINTS,

		}

		/// <summary>
		/// <para>Delete associated events</para>
		/// </summary>
		public enum DeleteAssociatedEventsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_EVENTS")]
			DELETE_EVENTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_EVENTS")]
			NO_DELETE_EVENTS,

		}

		/// <summary>
		/// <para>Delete associated centerlines</para>
		/// </summary>
		public enum DeleteAssociatedCenterlinesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_CENTERLINES")]
			DELETE_CENTERLINES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_CENTERLINES")]
			NO_DELETE_CENTERLINES,

		}

#endregion
	}
}
