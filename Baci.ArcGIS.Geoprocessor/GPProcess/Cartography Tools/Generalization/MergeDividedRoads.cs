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
	/// <para>Merge Divided Roads</para>
	/// <para>Merge Divided Roads</para>
	/// <para>Generates single-line road features in place of matched pairs of  divided road lanes.</para>
	/// </summary>
	public class MergeDividedRoads : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input linear road features that contain matched pairs of divided road lanes that will be merged into a single output line feature.</para>
		/// </param>
		/// <param name="MergeField">
		/// <para>Merge Field</para>
		/// <para>The field that contains road classification information. Only parallel, proximate roads of equal classification will be merged. A value of 0 (zero) locks a feature to prevent it from participating in merging.</para>
		/// </param>
		/// <param name="MergeDistance">
		/// <para>Merge Distance</para>
		/// <para>The minimum distance apart, in the specified units, for equal-class, relatively parallel road features to be merged. This distance must be greater than zero. If the units are in points, millimeters, centimeters, or inches, the value is considered as page units and takes into account the reference scale.</para>
		/// </param>
		/// <param name="OutFeatures">
		/// <para>Output Features</para>
		/// <para>The output feature class containing single-line merged road features and all unmerged road features.</para>
		/// </param>
		public MergeDividedRoads(object InFeatures, object MergeField, object MergeDistance, object OutFeatures)
		{
			this.InFeatures = InFeatures;
			this.MergeField = MergeField;
			this.MergeDistance = MergeDistance;
			this.OutFeatures = OutFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Merge Divided Roads</para>
		/// </summary>
		public override string DisplayName() => "Merge Divided Roads";

		/// <summary>
		/// <para>Tool Name : MergeDividedRoads</para>
		/// </summary>
		public override string ToolName() => "MergeDividedRoads";

		/// <summary>
		/// <para>Tool Excute Name : cartography.MergeDividedRoads</para>
		/// </summary>
		public override string ExcuteName() => "cartography.MergeDividedRoads";

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
		public override string[] ValidEnvironments() => new string[] { "cartographicCoordinateSystem", "cartographicPartitions", "referenceScale", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, MergeField, MergeDistance, OutFeatures, OutDisplacementFeatures!, CharacterField!, OutTable! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input linear road features that contain matched pairs of divided road lanes that will be merged into a single output line feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Merge Field</para>
		/// <para>The field that contains road classification information. Only parallel, proximate roads of equal classification will be merged. A value of 0 (zero) locks a feature to prevent it from participating in merging.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object MergeField { get; set; }

		/// <summary>
		/// <para>Merge Distance</para>
		/// <para>The minimum distance apart, in the specified units, for equal-class, relatively parallel road features to be merged. This distance must be greater than zero. If the units are in points, millimeters, centimeters, or inches, the value is considered as page units and takes into account the reference scale.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object MergeDistance { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output feature class containing single-line merged road features and all unmerged road features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Output Displacement Feature Class</para>
		/// <para>The output polygon features containing the degree and direction of road displacement.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object? OutDisplacementFeatures { get; set; }

		/// <summary>
		/// <para>Road Character Field</para>
		/// <para>Specify a numeric field that indicate the character of road segments, independent of their road classification. These values help the tool to refine the assessment of candidate feature pairs for merging. Use this parameter in unusual or complex road networks to improve the quality of the output. If there are null values (or if this parameter is not specified at all), the road character (and merge candidacy) is based only on the shapes and arrangement of features. Use value 999 to lock features from participating in a merge at all.</para>
		/// <para>Field values are assessed as follows:</para>
		/// <para>0—Traffic circles or roundabouts</para>
		/// <para>1—Carriageways, boulevards, dual-lane highways, or other parallel trending roads</para>
		/// <para>2—On- or off-ramps, highway intersection connectors</para>
		/// <para>999—Features will not be merged</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object? CharacterField { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>A many-to-many relationship table that links the merged road features to their source features. This table contains two fields, OUTPUT_FID and INPUT_FID, which store the merged feature IDs and their source feature IDs, respectively. Use this table to derive necessary attributes for the output features from their source features. No table is created when this parameter is left blank.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MergeDividedRoads SetEnviroment(object? cartographicCoordinateSystem = null, object? cartographicPartitions = null, double? referenceScale = null, object? workspace = null)
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, cartographicPartitions: cartographicPartitions, referenceScale: referenceScale, workspace: workspace);
			return this;
		}

	}
}
