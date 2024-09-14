using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.EditingTools
{
	/// <summary>
	/// <para>Split Line By Match</para>
	/// <para>按匹配分割线</para>
	/// <para>可根据匹配关系来分割输入要素，以获得更好的相应线分割。</para>
	/// </summary>
	public class SplitLineByMatch : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要分割的输入线要素。必须用匹配要素对其进行预匹配。</para>
		/// </param>
		/// <param name="MatchedFeatures">
		/// <para>Matched Features</para>
		/// <para>匹配要素可作为分割输入要素时的参考使用。必须用输入要素对其进行预匹配。</para>
		/// </param>
		/// <param name="InMatchTable">
		/// <para>Input Match Table</para>
		/// <para>包含输入和匹配要素间匹配信息的表格。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含分割线以及未分割的原始线的输出要素类。</para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>用于确定分割位置的距离值。该值必须大于 0。如果未指定单位，则将沿用输入的单位。</para>
		/// </param>
		public SplitLineByMatch(object InFeatures, object MatchedFeatures, object InMatchTable, object OutFeatureClass, object SearchDistance)
		{
			this.InFeatures = InFeatures;
			this.MatchedFeatures = MatchedFeatures;
			this.InMatchTable = InMatchTable;
			this.OutFeatureClass = OutFeatureClass;
			this.SearchDistance = SearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : 按匹配分割线</para>
		/// </summary>
		public override string DisplayName() => "按匹配分割线";

		/// <summary>
		/// <para>Tool Name : SplitLineByMatch</para>
		/// </summary>
		public override string ToolName() => "SplitLineByMatch";

		/// <summary>
		/// <para>Tool Excute Name : edit.SplitLineByMatch</para>
		/// </summary>
		public override string ExcuteName() => "edit.SplitLineByMatch";

		/// <summary>
		/// <para>Toolbox Display Name : Editing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Editing Tools";

		/// <summary>
		/// <para>Toolbox Alise : edit</para>
		/// </summary>
		public override string ToolboxAlise() => "edit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, MatchedFeatures, InMatchTable, OutFeatureClass, SearchDistance, InFeaturesAs, OutPointFeatureClass, SplitDangle, MinMatchGroupLength, MinSplitLength, SplitFields };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要分割的输入线要素。必须用匹配要素对其进行预匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Matched Features</para>
		/// <para>匹配要素可作为分割输入要素时的参考使用。必须用输入要素对其进行预匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object MatchedFeatures { get; set; }

		/// <summary>
		/// <para>Input Match Table</para>
		/// <para>包含输入和匹配要素间匹配信息的表格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[GPTablesDomain()]
		public object InMatchTable { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含分割线以及未分割的原始线的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>用于确定分割位置的距离值。该值必须大于 0。如果未指定单位，则将沿用输入的单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; }

		/// <summary>
		/// <para>Input Features In Match</para>
		/// <para>用于指定匹配表中的输入要素是源要素还是目标要素，以便分割正确的要素。</para>
		/// <para>作为源要素—输入要素作为源要素存储在匹配表中。这是默认设置。</para>
		/// <para>作为目标要素—输入要素作为目标要素存储在匹配表中。</para>
		/// <para><see cref="InFeaturesAsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InFeaturesAs { get; set; } = "AS_SOURCE";

		/// <summary>
		/// <para>Output Split Points</para>
		/// <para>包含表示分割位置的点的输出点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object OutPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Split dangle features</para>
		/// <para>用于指定是否将分割悬挂线。</para>
		/// <para>选中 - 将按照工具的分割规则分割悬挂线。这是默认设置。</para>
		/// <para>未选中 - 将不会分割悬挂线。</para>
		/// <para><see cref="SplitDangleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SplitDangle { get; set; } = "true";

		/// <summary>
		/// <para>Minimum Match Group Length</para>
		/// <para>如果输入要素的总长度或匹配要素的总长度大于指定值，则给定匹配组将只参与分割过程。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MinMatchGroupLength { get; set; }

		/// <summary>
		/// <para>Minimum Split Length</para>
		/// <para>如果分割会导致一个或两个分割段短于指定值，则分割不会发生。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MinSplitLength { get; set; }

		/// <summary>
		/// <para>Split Field(s)</para>
		/// <para>输入要素的数值字段列表。其字段值将基于分割线的比例。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		[ExcludeField("SHAPE_Length", "SHAPE_Area")]
		public object SplitFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SplitLineByMatch SetEnviroment(object extent = null, object workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Input Features In Match</para>
		/// </summary>
		public enum InFeaturesAsEnum 
		{
			/// <summary>
			/// <para>作为源要素—输入要素作为源要素存储在匹配表中。这是默认设置。</para>
			/// </summary>
			[GPValue("AS_SOURCE")]
			[Description("作为源要素")]
			As_source_features,

			/// <summary>
			/// <para>作为目标要素—输入要素作为目标要素存储在匹配表中。</para>
			/// </summary>
			[GPValue("AS_TARGET")]
			[Description("作为目标要素")]
			As_target_features,

		}

		/// <summary>
		/// <para>Split dangle features</para>
		/// </summary>
		public enum SplitDangleEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SPLIT_DANGLE")]
			SPLIT_DANGLE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SPLIT_DANGLE")]
			NO_SPLIT_DANGLE,

		}

#endregion
	}
}
