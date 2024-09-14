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
	/// <para>Collapse Road Detail</para>
	/// <para>Collapse Road Detail</para>
	/// <para>Collapses small, open  configurations of road segments that interrupt the general trend of a road network, such as traffic circles, and replaces them with a simplified depiction.</para>
	/// </summary>
	public class CollapseRoadDetail : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input features containing small enclosed road details, such as traffic circles, to be collapsed.</para>
		/// </param>
		/// <param name="CollapseDistance">
		/// <para>Collapse Distance</para>
		/// <para>The diameter of, or distance across, the road detail that will be considered for collapse.</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the collapsed features—features that were modified to accommodate the collapse—and all unaffected features.</para>
		/// </param>
		public CollapseRoadDetail(object InFeatures, object CollapseDistance, object OutputFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.CollapseDistance = CollapseDistance;
			this.OutputFeatureClass = OutputFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Collapse Road Detail</para>
		/// </summary>
		public override string DisplayName() => "Collapse Road Detail";

		/// <summary>
		/// <para>Tool Name : CollapseRoadDetail</para>
		/// </summary>
		public override string ToolName() => "CollapseRoadDetail";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CollapseRoadDetail</para>
		/// </summary>
		public override string ExcuteName() => "cartography.CollapseRoadDetail";

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
		public override string[] ValidEnvironments() => new string[] { "cartographicPartitions", "referenceScale" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, CollapseDistance, OutputFeatureClass, LockingField! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features containing small enclosed road details, such as traffic circles, to be collapsed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Collapse Distance</para>
		/// <para>The diameter of, or distance across, the road detail that will be considered for collapse.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object CollapseDistance { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the collapsed features—features that were modified to accommodate the collapse—and all unaffected features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Locking Field</para>
		/// <para>The field that contains locking information for the features. A value of 1 indicates that a feature will not be collapsed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object? LockingField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CollapseRoadDetail SetEnviroment(object? cartographicPartitions = null, double? referenceScale = null)
		{
			base.SetEnv(cartographicPartitions: cartographicPartitions, referenceScale: referenceScale);
			return this;
		}

	}
}
