using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Split</para>
	/// <para>Split</para>
	/// <para>Splits an input with overlaying features to  create a subset of output feature classes.</para>
	/// </summary>
	public class Split : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The features to be split.</para>
		/// </param>
		/// <param name="SplitFeatures">
		/// <para>Split Features</para>
		/// <para>Polygon features containing a tabular field whose unique values are used to split the input features and provide the output feature classes' names.</para>
		/// </param>
		/// <param name="SplitField">
		/// <para>Split Field</para>
		/// <para>The character field used to split the input features. This field's values identify the split features used to create each output feature class. The split field's unique values provide the output feature classes' names.</para>
		/// </param>
		/// <param name="OutWorkspace">
		/// <para>Target Workspace</para>
		/// <para>The existing workspace where the output feature classes are stored.</para>
		/// </param>
		public Split(object InFeatures, object SplitFeatures, object SplitField, object OutWorkspace)
		{
			this.InFeatures = InFeatures;
			this.SplitFeatures = SplitFeatures;
			this.SplitField = SplitField;
			this.OutWorkspace = OutWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : Split</para>
		/// </summary>
		public override string DisplayName() => "Split";

		/// <summary>
		/// <para>Tool Name : Split</para>
		/// </summary>
		public override string ToolName() => "Split";

		/// <summary>
		/// <para>Tool Excute Name : analysis.Split</para>
		/// </summary>
		public override string ExcuteName() => "analysis.Split";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "configKeyword", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, SplitFeatures, SplitField, OutWorkspace, ClusterTolerance, OutWorkspace2 };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The features to be split.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Split Features</para>
		/// <para>Polygon features containing a tabular field whose unique values are used to split the input features and provide the output feature classes' names.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object SplitFeatures { get; set; }

		/// <summary>
		/// <para>Split Field</para>
		/// <para>The character field used to split the input features. This field's values identify the split features used to create each output feature class. The split field's unique values provide the output feature classes' names.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object SplitField { get; set; }

		/// <summary>
		/// <para>Target Workspace</para>
		/// <para>The existing workspace where the output feature classes are stored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>The minimum distance separating all feature coordinates (nodes and vertices) as well as the distance a coordinate can move in X or Y (or both). Set the value to be higher for data that has less coordinate accuracy and lower for datasets with extremely high accuracy.</para>
		/// <para>Changing this parameter&apos;s value may cause failure or unexpected results. It is recommended that this parameter not be modified. It has been removed from view in the tool dialog. By default, the input feature class&apos;s spatial reference x,y tolerance property is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object ClusterTolerance { get; set; }

		/// <summary>
		/// <para>Updated Target Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutWorkspace2 { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Split SetEnviroment(object MDomain = null, object MResolution = null, object MTolerance = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, object configKeyword = null, object extent = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, object parallelProcessingFactor = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

	}
}
