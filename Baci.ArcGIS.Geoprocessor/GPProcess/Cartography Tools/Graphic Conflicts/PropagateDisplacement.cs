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
	/// <para>Propagate Displacement</para>
	/// <para>Propagate Displacement</para>
	/// <para>Propagates the displacement resulting from road adjustment in the Resolve Road Conflicts  and Merge Divided Roads tools to adjacent features to reestablish spatial relationships.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class PropagateDisplacement : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input feature layer containing features that may be in conflict. May be point, line, or polygon.</para>
		/// </param>
		/// <param name="DisplacementFeatures">
		/// <para>Displacement Features</para>
		/// <para>The displacement polygon features created by the Resolve Road Conflicts or the Merge Divided Roads tools that contain the degree and direction of road displacement that took place. These polygons dictate the amount of displacement that will be propagated to the input features.</para>
		/// </param>
		/// <param name="AdjustmentStyle">
		/// <para>Adjustment Style</para>
		/// <para>Defines the type of adjustment that will be used when displacing input features.</para>
		/// <para>Automatic—The tool will decide for each input feature whether a SOLID or an ELASTIC adjustment is most appropriate. In general, features with orthogonal shapes will have SOLID adjustment applied, while organically shaped features will have ELASTIC adjustment applied. This is the default.</para>
		/// <para>Solid—The feature will be translated. All vertices will move the same distance and direction. Topological errors may be introduced. This option is most useful when input features have regular geometric shapes.</para>
		/// <para>Elastic—The vertices of the feature may be moved independently to best fit the feature to the road network. The shape of the feature may be modified slightly. Topological errors are less likely to be introduced. This option only applies to line and polygon input features. This option is most useful for organically shaped input features.</para>
		/// <para><see cref="AdjustmentStyleEnum"/></para>
		/// </param>
		public PropagateDisplacement(object InFeatures, object DisplacementFeatures, object AdjustmentStyle)
		{
			this.InFeatures = InFeatures;
			this.DisplacementFeatures = DisplacementFeatures;
			this.AdjustmentStyle = AdjustmentStyle;
		}

		/// <summary>
		/// <para>Tool Display Name : Propagate Displacement</para>
		/// </summary>
		public override string DisplayName() => "Propagate Displacement";

		/// <summary>
		/// <para>Tool Name : PropagateDisplacement</para>
		/// </summary>
		public override string ToolName() => "PropagateDisplacement";

		/// <summary>
		/// <para>Tool Excute Name : cartography.PropagateDisplacement</para>
		/// </summary>
		public override string ExcuteName() => "cartography.PropagateDisplacement";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, DisplacementFeatures, AdjustmentStyle, OutFeatures! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input feature layer containing features that may be in conflict. May be point, line, or polygon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline", "Point")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Displacement Features</para>
		/// <para>The displacement polygon features created by the Resolve Road Conflicts or the Merge Divided Roads tools that contain the degree and direction of road displacement that took place. These polygons dictate the amount of displacement that will be propagated to the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object DisplacementFeatures { get; set; }

		/// <summary>
		/// <para>Adjustment Style</para>
		/// <para>Defines the type of adjustment that will be used when displacing input features.</para>
		/// <para>Automatic—The tool will decide for each input feature whether a SOLID or an ELASTIC adjustment is most appropriate. In general, features with orthogonal shapes will have SOLID adjustment applied, while organically shaped features will have ELASTIC adjustment applied. This is the default.</para>
		/// <para>Solid—The feature will be translated. All vertices will move the same distance and direction. Topological errors may be introduced. This option is most useful when input features have regular geometric shapes.</para>
		/// <para>Elastic—The vertices of the feature may be moved independently to best fit the feature to the road network. The shape of the feature may be modified slightly. Topological errors are less likely to be introduced. This option only applies to line and polygon input features. This option is most useful for organically shaped input features.</para>
		/// <para><see cref="AdjustmentStyleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AdjustmentStyle { get; set; } = "AUTO";

		/// <summary>
		/// <para>Output Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatures { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Adjustment Style</para>
		/// </summary>
		public enum AdjustmentStyleEnum 
		{
			/// <summary>
			/// <para>Automatic—The tool will decide for each input feature whether a SOLID or an ELASTIC adjustment is most appropriate. In general, features with orthogonal shapes will have SOLID adjustment applied, while organically shaped features will have ELASTIC adjustment applied. This is the default.</para>
			/// </summary>
			[GPValue("AUTO")]
			[Description("Automatic")]
			Automatic,

			/// <summary>
			/// <para>Solid—The feature will be translated. All vertices will move the same distance and direction. Topological errors may be introduced. This option is most useful when input features have regular geometric shapes.</para>
			/// </summary>
			[GPValue("SOLID")]
			[Description("Solid")]
			Solid,

			/// <summary>
			/// <para>Elastic—The vertices of the feature may be moved independently to best fit the feature to the road network. The shape of the feature may be modified slightly. Topological errors are less likely to be introduced. This option only applies to line and polygon input features. This option is most useful for organically shaped input features.</para>
			/// </summary>
			[GPValue("ELASTIC")]
			[Description("Elastic")]
			Elastic,

		}

#endregion
	}
}
