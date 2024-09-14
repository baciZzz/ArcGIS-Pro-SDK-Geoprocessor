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
	/// <para>Resolve Building Conflicts</para>
	/// <para>Resolve Building Conflicts</para>
	/// <para>Resolves symbol conflicts among buildings with respect to linear barrier features by moving, resizing, or hiding buildings.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ResolveBuildingConflicts : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBuildings">
		/// <para>Input Building Layers</para>
		/// <para>The input layers containing building features that may be in conflict or smaller than allowable size. Buildings can be either points or polygons. Buildings will be modified to resolve conflicts with other buildings and with barrier features.</para>
		/// <para>When point building layers are used as inputs, the Angle property of the marker symbol layer must be set to a field in the feature class. This field will store the rotation adjustments</para>
		/// </param>
		/// <param name="InvisibilityField">
		/// <para>Invisibility Field</para>
		/// <para>The field that stores the invisibility values that can be used to remove some buildings from display to resolve symbol conflicts. Buildings with a value of 1 will be removed from display; those with a value of zero will not be removed. Use a definition query on the layer to display visible buildings only. No features are deleted.</para>
		/// </param>
		/// <param name="InBarriers">
		/// <para>Input Barrier Layers</para>
		/// <para>The layers containing the linear or polygon features that are conflict barriers for input building features. Buildings will be modified to resolve conflicts between buildings and barriers. The orient value is Boolean, specifying whether buildings will be oriented to the barrier layer.</para>
		/// <para>Gap specifies the distance that buildings will move toward or away from the barrier layer. A unit must be entered with the value.</para>
		/// <para>A gap value of 0 (zero) will snap buildings directly to the edge of the barrier line or outline symbology.</para>
		/// <para>A null (unspecified) gap value means that buildings will not be moved toward or away from barrier lines or outlines except movement required by conflict resolution.</para>
		/// <para>If no unit is entered with the gap value (that is, 10 instead of 10 meters), the linear unit from the input feature&apos;s coordinate system will be used.</para>
		/// </param>
		/// <param name="BuildingGap">
		/// <para>Building Gap</para>
		/// <para>The minimum allowable distance between symbolized buildings at scale. Buildings that are closer together will be displaced or hidden to enforce this distance. The minimum allowable distance is set relative to the reference scale (that is, 15 meters at 1:50,000 scale). The value is 0 if the reference scale is not set.</para>
		/// </param>
		/// <param name="MinimumSize">
		/// <para>Minimum Allowable Building Size</para>
		/// <para>The minimum allowable size of the shortest side of a rotated best-fit bounding box around the symbolized building feature drawn at the reference scale. Buildings with a bounding box side smaller than this value will be enlarged to meet it. Resizing may occur nonproportionally, resulting in a change to the building morphology.</para>
		/// </param>
		public ResolveBuildingConflicts(object InBuildings, object InvisibilityField, object InBarriers, object BuildingGap, object MinimumSize)
		{
			this.InBuildings = InBuildings;
			this.InvisibilityField = InvisibilityField;
			this.InBarriers = InBarriers;
			this.BuildingGap = BuildingGap;
			this.MinimumSize = MinimumSize;
		}

		/// <summary>
		/// <para>Tool Display Name : Resolve Building Conflicts</para>
		/// </summary>
		public override string DisplayName() => "Resolve Building Conflicts";

		/// <summary>
		/// <para>Tool Name : ResolveBuildingConflicts</para>
		/// </summary>
		public override string ToolName() => "ResolveBuildingConflicts";

		/// <summary>
		/// <para>Tool Excute Name : cartography.ResolveBuildingConflicts</para>
		/// </summary>
		public override string ExcuteName() => "cartography.ResolveBuildingConflicts";

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
		public override object[] Parameters() => new object[] { InBuildings, InvisibilityField, InBarriers, BuildingGap, MinimumSize, HierarchyField!, OutLayers! };

		/// <summary>
		/// <para>Input Building Layers</para>
		/// <para>The input layers containing building features that may be in conflict or smaller than allowable size. Buildings can be either points or polygons. Buildings will be modified to resolve conflicts with other buildings and with barrier features.</para>
		/// <para>When point building layers are used as inputs, the Angle property of the marker symbol layer must be set to a field in the feature class. This field will store the rotation adjustments</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPLayerDomain()]
		[GeometryType("Polygon", "Point")]
		public object InBuildings { get; set; }

		/// <summary>
		/// <para>Invisibility Field</para>
		/// <para>The field that stores the invisibility values that can be used to remove some buildings from display to resolve symbol conflicts. Buildings with a value of 1 will be removed from display; those with a value of zero will not be removed. Use a definition query on the layer to display visible buildings only. No features are deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InvisibilityField { get; set; }

		/// <summary>
		/// <para>Input Barrier Layers</para>
		/// <para>The layers containing the linear or polygon features that are conflict barriers for input building features. Buildings will be modified to resolve conflicts between buildings and barriers. The orient value is Boolean, specifying whether buildings will be oriented to the barrier layer.</para>
		/// <para>Gap specifies the distance that buildings will move toward or away from the barrier layer. A unit must be entered with the value.</para>
		/// <para>A gap value of 0 (zero) will snap buildings directly to the edge of the barrier line or outline symbology.</para>
		/// <para>A null (unspecified) gap value means that buildings will not be moved toward or away from barrier lines or outlines except movement required by conflict resolution.</para>
		/// <para>If no unit is entered with the gap value (that is, 10 instead of 10 meters), the linear unit from the input feature&apos;s coordinate system will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object InBarriers { get; set; }

		/// <summary>
		/// <para>Building Gap</para>
		/// <para>The minimum allowable distance between symbolized buildings at scale. Buildings that are closer together will be displaced or hidden to enforce this distance. The minimum allowable distance is set relative to the reference scale (that is, 15 meters at 1:50,000 scale). The value is 0 if the reference scale is not set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object BuildingGap { get; set; }

		/// <summary>
		/// <para>Minimum Allowable Building Size</para>
		/// <para>The minimum allowable size of the shortest side of a rotated best-fit bounding box around the symbolized building feature drawn at the reference scale. Buildings with a bounding box side smaller than this value will be enlarged to meet it. Resizing may occur nonproportionally, resulting in a change to the building morphology.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object MinimumSize { get; set; }

		/// <summary>
		/// <para>Hierarchy Field</para>
		/// <para>The field that contains hierarchical ranking of feature importance in which 1 is very important and larger integers reflect decreasing importance. A value of 0 (zero) causes the building to retain visibility, although it may be moved somewhat to resolve conflicts. If this parameter is not used, feature importance will be assessed by the tool based on perimeter length and proximity to barrier features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? HierarchyField { get; set; }

		/// <summary>
		/// <para>Output Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutLayers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ResolveBuildingConflicts SetEnviroment(object? cartographicCoordinateSystem = null, object? cartographicPartitions = null, double? referenceScale = null)
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, cartographicPartitions: cartographicPartitions, referenceScale: referenceScale);
			return this;
		}

	}
}
