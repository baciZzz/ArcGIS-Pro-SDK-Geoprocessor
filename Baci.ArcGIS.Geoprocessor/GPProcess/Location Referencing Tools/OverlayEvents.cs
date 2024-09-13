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
	/// <para>Overlay Events</para>
	/// <para>叠加事件</para>
	/// <para>针对目标网络覆盖一个或多个线性事件要素图层，并输出表示输入动态分段的要素类或表。</para>
	/// </summary>
	public class OverlayEvents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRouteFeatures">
		/// <para>Input Route Features</para>
		/// <para>将针对其动态分割事件图层的目标网络。</para>
		/// </param>
		/// <param name="EventLayers">
		/// <para>Event Layers</para>
		/// <para>要针对目标网络动态分割的事件图层。</para>
		/// </param>
		/// <param name="OutputDataset">
		/// <para>Output Dataset</para>
		/// <para>包含将要创建的输出事件记录的表或要素类。</para>
		/// </param>
		public OverlayEvents(object InRouteFeatures, object EventLayers, object OutputDataset)
		{
			this.InRouteFeatures = InRouteFeatures;
			this.EventLayers = EventLayers;
			this.OutputDataset = OutputDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 叠加事件</para>
		/// </summary>
		public override string DisplayName() => "叠加事件";

		/// <summary>
		/// <para>Tool Name : OverlayEvents</para>
		/// </summary>
		public override string ToolName() => "OverlayEvents";

		/// <summary>
		/// <para>Tool Excute Name : locref.OverlayEvents</para>
		/// </summary>
		public override string ExcuteName() => "locref.OverlayEvents";

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
		public override object[] Parameters() => new object[] { InRouteFeatures, EventLayers, OutputDataset, IncludeGeometry!, NetworkFields! };

		/// <summary>
		/// <para>Input Route Features</para>
		/// <para>将针对其动态分割事件图层的目标网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InRouteFeatures { get; set; }

		/// <summary>
		/// <para>Event Layers</para>
		/// <para>要针对目标网络动态分割的事件图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object EventLayers { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>包含将要创建的输出事件记录的表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		[GPDatasetDomain()]
		[DataSetType("Table", "FeatureClass")]
		public object OutputDataset { get; set; }

		/// <summary>
		/// <para>Include Geometry</para>
		/// <para>指定输出数据集值是否将包括事件几何。</para>
		/// <para>未选中 - 输出数据集值将不包括事件几何。 事件记录将存储为表。 这是默认设置。</para>
		/// <para>选中 - 输出数据集值将包括事件几何。 事件记录将存储为要素类。</para>
		/// <para><see cref="IncludeGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeGeometry { get; set; } = "false";

		/// <summary>
		/// <para>Network Fields</para>
		/// <para>来自网络图层的字段将包含在输出中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GlobalID", "GUID")]
		public object? NetworkFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public OverlayEvents SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Include Geometry</para>
		/// </summary>
		public enum IncludeGeometryEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_GEOMETRY")]
			INCLUDE_GEOMETRY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_GEOMETRY")]
			EXCLUDE_GEOMETRY,

		}

#endregion
	}
}
