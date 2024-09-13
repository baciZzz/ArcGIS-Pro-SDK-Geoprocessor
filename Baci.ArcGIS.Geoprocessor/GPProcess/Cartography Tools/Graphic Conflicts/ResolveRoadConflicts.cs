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
	/// <para>Resolve Road Conflicts</para>
	/// <para>Resolves graphic conflicts among symbolized road features by adjusting portions of line segments.</para>
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
		/// <para>The input feature layers containing symbolized road features that may be in conflict.</para>
		/// </param>
		/// <param name="HierarchyField">
		/// <para>Hierarchy Field</para>
		/// <para>The field that contains hierarchical ranking of feature importance in which 1 is very important and larger integers reflect decreasing importance. A value of 0 (zero) locks the feature to ensure that it is not moved. The hierarchy field must be present and named the same for all input feature classes.</para>
		/// </param>
		public ResolveRoadConflicts(object InLayers, object HierarchyField)
		{
			this.InLayers = InLayers;
			this.HierarchyField = HierarchyField;
		}

		/// <summary>
		/// <para>Tool Display Name : Resolve Road Conflicts</para>
		/// </summary>
		public override string DisplayName() => "Resolve Road Conflicts";

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
		public override object[] Parameters() => new object[] { InLayers, HierarchyField, OutDisplacementFeatures!, OutLayers! };

		/// <summary>
		/// <para>Input Road Layers</para>
		/// <para>The input feature layers containing symbolized road features that may be in conflict.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPLayerDomain()]
		[GeometryType("Polyline")]
		public object InLayers { get; set; }

		/// <summary>
		/// <para>Hierarchy Field</para>
		/// <para>The field that contains hierarchical ranking of feature importance in which 1 is very important and larger integers reflect decreasing importance. A value of 0 (zero) locks the feature to ensure that it is not moved. The hierarchy field must be present and named the same for all input feature classes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object HierarchyField { get; set; }

		/// <summary>
		/// <para>Output Displacement Feature Class</para>
		/// <para>The output polygon features containing the degree and direction of road displacement that will be used by the Propagate Displacement tool to preserve spatial relationships.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object? OutDisplacementFeatures { get; set; }

		/// <summary>
		/// <para>Output Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutLayers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ResolveRoadConflicts SetEnviroment(object? cartographicCoordinateSystem = null , object? cartographicPartitions = null , double? referenceScale = null )
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, cartographicPartitions: cartographicPartitions, referenceScale: referenceScale);
			return this;
		}

	}
}
