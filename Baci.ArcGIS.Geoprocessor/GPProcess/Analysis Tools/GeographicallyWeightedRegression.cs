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
	/// <para>Geographically Weighted Regression</para>
	/// <para>Calculates Geographically Weighted Regression.</para>
	/// </summary>
	[Obsolete()]
	public class GeographicallyWeightedRegression : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input features</para>
		/// </param>
		/// <param name="DependentField">
		/// <para>Dependent variable</para>
		/// </param>
		/// <param name="ExplanatoryField">
		/// <para>Explanatory variable(s)</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output feature class</para>
		/// </param>
		/// <param name="KernelType">
		/// <para>Kernel type</para>
		/// <para><see cref="KernelTypeEnum"/></para>
		/// </param>
		/// <param name="BandwidthMethod">
		/// <para>Bandwidth method</para>
		/// <para><see cref="BandwidthMethodEnum"/></para>
		/// </param>
		public GeographicallyWeightedRegression(object InFeatures, object DependentField, object ExplanatoryField, object OutFeatureclass, object KernelType, object BandwidthMethod)
		{
			this.InFeatures = InFeatures;
			this.DependentField = DependentField;
			this.ExplanatoryField = ExplanatoryField;
			this.OutFeatureclass = OutFeatureclass;
			this.KernelType = KernelType;
			this.BandwidthMethod = BandwidthMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : Geographically Weighted Regression</para>
		/// </summary>
		public override string DisplayName => "Geographically Weighted Regression";

		/// <summary>
		/// <para>Tool Name : GeographicallyWeightedRegression</para>
		/// </summary>
		public override string ToolName => "GeographicallyWeightedRegression";

		/// <summary>
		/// <para>Tool Excute Name : analysis.GeographicallyWeightedRegression</para>
		/// </summary>
		public override string ExcuteName => "analysis.GeographicallyWeightedRegression";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, DependentField, ExplanatoryField, OutFeatureclass, KernelType, BandwidthMethod, Distance!, NumberOfNeighbors!, WeightField!, CoefficientRasterWorkspace!, CellSize!, InPredictionLocations!, PredictionExplanatoryField!, OutPredictionFeatureclass!, OutTable!, OutRegressionRasters! };

		/// <summary>
		/// <para>Input features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Dependent variable</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object DependentField { get; set; }

		/// <summary>
		/// <para>Explanatory variable(s)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		public object ExplanatoryField { get; set; }

		/// <summary>
		/// <para>Output feature class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>Kernel type</para>
		/// <para><see cref="KernelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object KernelType { get; set; } = "FIXED";

		/// <summary>
		/// <para>Bandwidth method</para>
		/// <para><see cref="BandwidthMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BandwidthMethod { get; set; } = "AICc";

		/// <summary>
		/// <para>Distance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain()]
		public object? Distance { get; set; }

		/// <summary>
		/// <para>Number of neighbors</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		public object? NumberOfNeighbors { get; set; } = "30";

		/// <summary>
		/// <para>Weights</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? WeightField { get; set; }

		/// <summary>
		/// <para>Coefficient raster workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEWorkspace()]
		[Category("Additional Parameters (Optional)")]
		public object? CoefficientRasterWorkspace { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain()]
		[Category("Additional Parameters (Optional)")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Prediction locations</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[Category("Additional Parameters (Optional)")]
		public object? InPredictionLocations { get; set; }

		/// <summary>
		/// <para>Prediction explanatory variable(s)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[Category("Additional Parameters (Optional)")]
		public object? PredictionExplanatoryField { get; set; }

		/// <summary>
		/// <para>Output prediction feature class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Additional Parameters (Optional)")]
		public object? OutPredictionFeatureclass { get; set; }

		/// <summary>
		/// <para>Output table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Output regression rasters</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutRegressionRasters { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Kernel type</para>
		/// </summary>
		public enum KernelTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("FIXED")]
			[Description("FIXED")]
			FIXED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("ADAPTIVE")]
			[Description("ADAPTIVE")]
			ADAPTIVE,

		}

		/// <summary>
		/// <para>Bandwidth method</para>
		/// </summary>
		public enum BandwidthMethodEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("AICc")]
			[Description("AICc")]
			AICc,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("CV")]
			[Description("CV")]
			CV,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("BANDWIDTH_PARAMETER")]
			[Description("BANDWIDTH_PARAMETER")]
			BANDWIDTH_PARAMETER,

		}

#endregion
	}
}
