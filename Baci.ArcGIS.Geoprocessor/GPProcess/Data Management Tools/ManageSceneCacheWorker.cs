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
	/// <para>Manage Scene Cache Worker</para>
	/// <para>Manage Scene Cache Worker</para>
	/// </summary>
	[Obsolete()]
	public class ManageSceneCacheWorker : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ServiceUrl">
		/// <para>Input Service URL</para>
		/// </param>
		/// <param name="Layer">
		/// <para>Layer</para>
		/// </param>
		/// <param name="UpdateMode">
		/// <para>Update Mode</para>
		/// <para><see cref="UpdateModeEnum"/></para>
		/// </param>
		public ManageSceneCacheWorker(object ServiceUrl, object Layer, object UpdateMode)
		{
			this.ServiceUrl = ServiceUrl;
			this.Layer = Layer;
			this.UpdateMode = UpdateMode;
		}

		/// <summary>
		/// <para>Tool Display Name : Manage Scene Cache Worker</para>
		/// </summary>
		public override string DisplayName => "Manage Scene Cache Worker";

		/// <summary>
		/// <para>Tool Name : ManageSceneCacheWorker</para>
		/// </summary>
		public override string ToolName => "ManageSceneCacheWorker";

		/// <summary>
		/// <para>Tool Excute Name : management.ManageSceneCacheWorker</para>
		/// </summary>
		public override string ExcuteName => "management.ManageSceneCacheWorker";

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
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { ServiceUrl, Layer, UpdateMode, UpdateExtent!, AreaOfInterest!, OutServiceUrl! };

		/// <summary>
		/// <para>Input Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ServiceUrl { get; set; }

		/// <summary>
		/// <para>Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Layer { get; set; }

		/// <summary>
		/// <para>Update Mode</para>
		/// <para><see cref="UpdateModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object UpdateMode { get; set; } = "RECREATE_ALL_NODES";

		/// <summary>
		/// <para>Update Extent</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? UpdateExtent { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object? AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Output Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutServiceUrl { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Update Mode</para>
		/// </summary>
		public enum UpdateModeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RECREATE_EMPTY_NODES")]
			[Description("RECREATE_EMPTY_NODES")]
			RECREATE_EMPTY_NODES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RECREATE_ALL_NODES")]
			[Description("RECREATE_ALL_NODES")]
			RECREATE_ALL_NODES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PARTIAL_UPDATE_NODES")]
			[Description("PARTIAL_UPDATE_NODES")]
			PARTIAL_UPDATE_NODES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PARTIAL_UPDATE_ATTRIBUTES")]
			[Description("PARTIAL_UPDATE_ATTRIBUTES")]
			PARTIAL_UPDATE_ATTRIBUTES,

		}

#endregion
	}
}
