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
	/// <para>Thin Road Network</para>
	/// <para>Generates a simplified road network that retains connectivity and general character for display at a smaller scale.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ThinRoadNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Road Features</para>
		/// <para>The input linear roads that will be thinned to create a simplified collection for display at smaller scales.</para>
		/// </param>
		/// <param name="MinimumLength">
		/// <para>Minimum Length</para>
		/// <para>An indication of the shortest road segment that is sensible to display at the output scale. This controls the resolution, or density, of the resulting road collection. If the units are in points, millimeters, centimeters, or inches, the value is considered in page units and the reference scale is taken into account.</para>
		/// </param>
		/// <param name="InvisibilityField">
		/// <para>Invisibility Field</para>
		/// <para>The field that stores the results of the tool. Features that participate in the resulting simplified road collection have a value of 0 (zero). Those that are extraneous have a value of 1. A layer definition query can be used to display the resulting road collection. This field must be present and named the same for each input feature class.</para>
		/// </param>
		/// <param name="HierarchyField">
		/// <para>Hierarchy Field</para>
		/// <para>The field that contains hierarchical ranking of feature importance, in which 1 is very important and larger integers reflect decreasing importance. A value of 0 forces the feature to remain visible in the output collection. This field must be present and named the same for each input feature class. Hierarchy values equal to NULL are not accepted and will produce an error.</para>
		/// </param>
		public ThinRoadNetwork(object InFeatures, object MinimumLength, object InvisibilityField, object HierarchyField)
		{
			this.InFeatures = InFeatures;
			this.MinimumLength = MinimumLength;
			this.InvisibilityField = InvisibilityField;
			this.HierarchyField = HierarchyField;
		}

		/// <summary>
		/// <para>Tool Display Name : Thin Road Network</para>
		/// </summary>
		public override string DisplayName => "Thin Road Network";

		/// <summary>
		/// <para>Tool Name : ThinRoadNetwork</para>
		/// </summary>
		public override string ToolName => "ThinRoadNetwork";

		/// <summary>
		/// <para>Tool Excute Name : cartography.ThinRoadNetwork</para>
		/// </summary>
		public override string ExcuteName => "cartography.ThinRoadNetwork";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cartographicCoordinateSystem", "cartographicPartitions", "referenceScale" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, MinimumLength, InvisibilityField, HierarchyField, OutFeatures! };

		/// <summary>
		/// <para>Input Road Features</para>
		/// <para>The input linear roads that will be thinned to create a simplified collection for display at smaller scales.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Minimum Length</para>
		/// <para>An indication of the shortest road segment that is sensible to display at the output scale. This controls the resolution, or density, of the resulting road collection. If the units are in points, millimeters, centimeters, or inches, the value is considered in page units and the reference scale is taken into account.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object MinimumLength { get; set; }

		/// <summary>
		/// <para>Invisibility Field</para>
		/// <para>The field that stores the results of the tool. Features that participate in the resulting simplified road collection have a value of 0 (zero). Those that are extraneous have a value of 1. A layer definition query can be used to display the resulting road collection. This field must be present and named the same for each input feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InvisibilityField { get; set; }

		/// <summary>
		/// <para>Hierarchy Field</para>
		/// <para>The field that contains hierarchical ranking of feature importance, in which 1 is very important and larger integers reflect decreasing importance. A value of 0 forces the feature to remain visible in the output collection. This field must be present and named the same for each input feature class. Hierarchy values equal to NULL are not accepted and will produce an error.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object HierarchyField { get; set; }

		/// <summary>
		/// <para>Updated Input Road Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ThinRoadNetwork SetEnviroment(object? cartographicCoordinateSystem = null , object? cartographicPartitions = null , double? referenceScale = null )
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, cartographicPartitions: cartographicPartitions, referenceScale: referenceScale);
			return this;
		}

	}
}
