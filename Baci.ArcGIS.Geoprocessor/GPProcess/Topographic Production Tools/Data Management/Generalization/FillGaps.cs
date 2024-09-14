using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Fill Gaps</para>
	/// <para>Fill Gaps</para>
	/// <para>Fills gaps between polygon features that participate in a topology where the coincident boundaries are evident.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class FillGaps : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>A list of input polygon feature classes or layers to be analyzed for gaps.</para>
		/// </param>
		/// <param name="MaxGapArea">
		/// <para>Maximum Gap Area</para>
		/// <para>The maximum area that can be considered a gap. Areas larger than this threshold are not filled.</para>
		/// </param>
		public FillGaps(object InputFeatures, object MaxGapArea)
		{
			this.InputFeatures = InputFeatures;
			this.MaxGapArea = MaxGapArea;
		}

		/// <summary>
		/// <para>Tool Display Name : Fill Gaps</para>
		/// </summary>
		public override string DisplayName() => "Fill Gaps";

		/// <summary>
		/// <para>Tool Name : FillGaps</para>
		/// </summary>
		public override string ToolName() => "FillGaps";

		/// <summary>
		/// <para>Tool Excute Name : topographic.FillGaps</para>
		/// </summary>
		public override string ExcuteName() => "topographic.FillGaps";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise() => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatures, MaxGapArea, FillOption!, FillUnenclosedGaps!, MaxGapDistance!, UpdatedFeatures! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>A list of input polygon feature classes or layers to be analyzed for gaps.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Maximum Gap Area</para>
		/// <para>The maximum area that can be considered a gap. Areas larger than this threshold are not filled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPArealUnit()]
		public object MaxGapArea { get; set; }

		/// <summary>
		/// <para>Fill Option</para>
		/// <para>Specifies how enclosed and unenclosed gaps are filled.</para>
		/// <para>Fill By Length—Gaps are filled by adding a gap&apos;s geometry to the polygon with the longest shared edge. This is the default.</para>
		/// <para>Fill By Order—Gaps are filled sequentially according to the order of the input polygon features list.</para>
		/// <para><see cref="FillOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FillOption { get; set; } = "FILL_BY_LENGTH";

		/// <summary>
		/// <para>Fill Unenclosed Gaps</para>
		/// <para>Specifies whether the tool fills unenclosed gaps.</para>
		/// <para>Unchecked—Only enclosed gaps are filled. Unenclosed gaps are skipped. This is the default.</para>
		/// <para>Checked—Both enclosed and unenclosed gaps are filled.</para>
		/// <para><see cref="FillUnenclosedGapsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? FillUnenclosedGaps { get; set; } = "false";

		/// <summary>
		/// <para>Maximum Gap Distance</para>
		/// <para>The maximum distance between features in which a gap can be filled. This parameter is used only when the Fill Unenclosed Gaps parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? MaxGapDistance { get; set; }

		/// <summary>
		/// <para>Updated Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? UpdatedFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FillGaps SetEnviroment(object? scratchWorkspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Fill Option</para>
		/// </summary>
		public enum FillOptionEnum 
		{
			/// <summary>
			/// <para>Fill By Length—Gaps are filled by adding a gap&apos;s geometry to the polygon with the longest shared edge. This is the default.</para>
			/// </summary>
			[GPValue("FILL_BY_LENGTH")]
			[Description("Fill By Length")]
			Fill_By_Length,

			/// <summary>
			/// <para>Fill By Order—Gaps are filled sequentially according to the order of the input polygon features list.</para>
			/// </summary>
			[GPValue("FILL_BY_ORDER")]
			[Description("Fill By Order")]
			Fill_By_Order,

		}

		/// <summary>
		/// <para>Fill Unenclosed Gaps</para>
		/// </summary>
		public enum FillUnenclosedGapsEnum 
		{
			/// <summary>
			/// <para>Unchecked—Only enclosed gaps are filled. Unenclosed gaps are skipped. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("SKIP_UNENCLOSED_GAPS")]
			SKIP_UNENCLOSED_GAPS,

			/// <summary>
			/// <para>Checked—Both enclosed and unenclosed gaps are filled.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FILL_ALL")]
			FILL_ALL,

		}

#endregion
	}
}
