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
	/// <para>Resolve Road Conflicts</para>
	/// <para>解决道路冲突</para>
	/// <para>通过调整部分线段来解决符号化的道路要素之间的图形冲突。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ResolveRoadConflicts : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayers">
		/// <para>Input Road Layers</para>
		/// <para>包含可能存在冲突的符号化道路要素的输入要素图层。</para>
		/// </param>
		/// <param name="HierarchyField">
		/// <para>Hierarchy Field</para>
		/// <para>该字段包含要素重要性的等级级别，其中 1 表示非常重要，重要性随整数值的增大而递减。 字段值为 0（零）表示将锁定要素以确保其无法移动。 对于所有输入要素类，必须存在等级字段并且指定为相同的值。</para>
		/// </param>
		public ResolveRoadConflicts(object InLayers, object HierarchyField)
		{
			this.InLayers = InLayers;
			this.HierarchyField = HierarchyField;
		}

		/// <summary>
		/// <para>Tool Display Name : 解决道路冲突</para>
		/// </summary>
		public override string DisplayName() => "解决道路冲突";

		/// <summary>
		/// <para>Tool Name : ResolveRoadConflicts</para>
		/// </summary>
		public override string ToolName() => "ResolveRoadConflicts";

		/// <summary>
		/// <para>Tool Excute Name : cartography.ResolveRoadConflicts</para>
		/// </summary>
		public override string ExcuteName() => "cartography.ResolveRoadConflicts";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise() => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cartographicCoordinateSystem", "cartographicPartitions", "referenceScale" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLayers, HierarchyField, OutDisplacementFeatures, OutLayers };

		/// <summary>
		/// <para>Input Road Layers</para>
		/// <para>包含可能存在冲突的符号化道路要素的输入要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPLayerDomain()]
		[GeometryType("Polyline")]
		public object InLayers { get; set; }

		/// <summary>
		/// <para>Hierarchy Field</para>
		/// <para>该字段包含要素重要性的等级级别，其中 1 表示非常重要，重要性随整数值的增大而递减。 字段值为 0（零）表示将锁定要素以确保其无法移动。 对于所有输入要素类，必须存在等级字段并且指定为相同的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object HierarchyField { get; set; }

		/// <summary>
		/// <para>Output Displacement Feature Class</para>
		/// <para>包含道路位移的程度和方向的输出面要素，传递位移工具将使用这些要素保留空间关系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object OutDisplacementFeatures { get; set; }

		/// <summary>
		/// <para>Output Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutLayers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ResolveRoadConflicts SetEnviroment(object cartographicCoordinateSystem = null, object cartographicPartitions = null, object referenceScale = null)
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, cartographicPartitions: cartographicPartitions, referenceScale: referenceScale);
			return this;
		}

	}
}
