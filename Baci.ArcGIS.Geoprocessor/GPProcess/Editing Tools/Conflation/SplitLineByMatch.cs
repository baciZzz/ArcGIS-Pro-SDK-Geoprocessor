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
	/// <para>Splits input features based on matching relationships to obtain better corresponding line segmentation.</para>
	/// </summary>
	public class SplitLineByMatch : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input line features to be split. They must be prematched with the matched features.</para>
		/// </param>
		/// <param name="MatchedFeatures">
		/// <para>Matched Features</para>
		/// <para>Matched features are used as reference when splitting the input features. They must be prematched with the input features.</para>
		/// </param>
		/// <param name="InMatchTable">
		/// <para>Input Match Table</para>
		/// <para>A table that includes matching information between input and matched features.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing split lines and original lines that are not split.</para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>The distance value used to determine split locations. The value must be greater than 0. If units are not specified, the units of the input will be used.</para>
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
		/// <para>Tool Display Name : Split Line By Match</para>
		/// </summary>
		public override string DisplayName => "Split Line By Match";

		/// <summary>
		/// <para>Tool Name : SplitLineByMatch</para>
		/// </summary>
		public override string ToolName => "SplitLineByMatch";

		/// <summary>
		/// <para>Tool Excute Name : edit.SplitLineByMatch</para>
		/// </summary>
		public override string ExcuteName => "edit.SplitLineByMatch";

		/// <summary>
		/// <para>Toolbox Display Name : Editing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Editing Tools";

		/// <summary>
		/// <para>Toolbox Alise : edit</para>
		/// </summary>
		public override string ToolboxAlise => "edit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, MatchedFeatures, InMatchTable, OutFeatureClass, SearchDistance, InFeaturesAs, OutPointFeatureClass, SplitDangle, MinMatchGroupLength, MinSplitLength, SplitFields };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input line features to be split. They must be prematched with the matched features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Matched Features</para>
		/// <para>Matched features are used as reference when splitting the input features. They must be prematched with the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object MatchedFeatures { get; set; }

		/// <summary>
		/// <para>Input Match Table</para>
		/// <para>A table that includes matching information between input and matched features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[GPTablesDomain()]
		public object InMatchTable { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing split lines and original lines that are not split.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The distance value used to determine split locations. The value must be greater than 0. If units are not specified, the units of the input will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; }

		/// <summary>
		/// <para>Input Features In Match</para>
		/// <para>Specifies whether the input features in the match table are source features or target features, so the correct features will be split.</para>
		/// <para>As source features—The input features are stored as the source features in the match table. This is the default.</para>
		/// <para>As target features—The input features are stored as the target features in the match table.</para>
		/// <para><see cref="InFeaturesAsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InFeaturesAs { get; set; } = "AS_SOURCE";

		/// <summary>
		/// <para>Output Split Points</para>
		/// <para>The output point feature class containing points that represent split locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object OutPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Split dangle features</para>
		/// <para>Specifies whether dangling lines will be split.</para>
		/// <para>Checked—Dangling lines will be split following the tool&apos;s split rules. This is the default.</para>
		/// <para>Unchecked—Dangling lines will not be split.</para>
		/// <para><see cref="SplitDangleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SplitDangle { get; set; } = "true";

		/// <summary>
		/// <para>Minimum Match Group Length</para>
		/// <para>A given match group will only participate in the splitting process if either the total length of the input features or the total length of the matched features are greater than the specified value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MinMatchGroupLength { get; set; }

		/// <summary>
		/// <para>Minimum Split Length</para>
		/// <para>If a split will result in one or both of the split pieces being shorter than the specified value, the split will not occur.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MinSplitLength { get; set; }

		/// <summary>
		/// <para>Split Field(s)</para>
		/// <para>A list of numeric fields from input features. Their field values will be based on the proportions of the split lines.</para>
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
		public SplitLineByMatch SetEnviroment(object extent = null , object workspace = null )
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
			/// <para>As source features—The input features are stored as the source features in the match table. This is the default.</para>
			/// </summary>
			[GPValue("AS_SOURCE")]
			[Description("As source features")]
			As_source_features,

			/// <summary>
			/// <para>As target features—The input features are stored as the target features in the match table.</para>
			/// </summary>
			[GPValue("AS_TARGET")]
			[Description("As target features")]
			As_target_features,

		}

		/// <summary>
		/// <para>Split dangle features</para>
		/// </summary>
		public enum SplitDangleEnum 
		{
			/// <summary>
			/// <para>Checked—Dangling lines will be split following the tool&apos;s split rules. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SPLIT_DANGLE")]
			SPLIT_DANGLE,

			/// <summary>
			/// <para>Unchecked—Dangling lines will not be split.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SPLIT_DANGLE")]
			NO_SPLIT_DANGLE,

		}

#endregion
	}
}
