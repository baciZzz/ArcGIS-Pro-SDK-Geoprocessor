using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ParcelTools
{
	/// <summary>
	/// <para>Analyze Parcels By Least Squares Adjustment</para>
	/// <para>Analyze Parcels By Least Squares Adjustment</para>
	/// <para>Analyzes the parcel fabric measurement network by running a least-squares adjustment on the input parcels. A least-squares adjustment is a mathematical procedure that uses statistical analysis to estimate  the most likely coordinates for connected points in a measurement network. A least-squares adjustment can be run on the parcel fabric to evaluate and improve spatial accuracy of parcel corner point locations.</para>
	/// </summary>
	public class AnalyzeParcelsByLeastSquaresAdjustment : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFabric">
		/// <para>Input Parcel Fabric</para>
		/// <para>The input parcel fabric to be analyzed by least-squares adjustment.</para>
		/// </param>
		/// <param name="AnalysisType">
		/// <para>Analysis Type</para>
		/// <para>Specifies the type of least-squares analysis that will be used in the adjustment.</para>
		/// <para>Consistency check—A free-network least-squares adjustment will be run to check dimensions on parcel lines for inconsistencies and mistakes. Fixed or weighted control points will not be used by the adjustment.</para>
		/// <para>Weighted least squares—A weighted least-squares adjustment will be run to compute updated coordinates for parcel points. The parcels being adjusted should connect to at least two fixed or weighted control points.</para>
		/// <para><see cref="AnalysisTypeEnum"/></para>
		/// </param>
		public AnalyzeParcelsByLeastSquaresAdjustment(object InParcelFabric, object AnalysisType)
		{
			this.InParcelFabric = InParcelFabric;
			this.AnalysisType = AnalysisType;
		}

		/// <summary>
		/// <para>Tool Display Name : Analyze Parcels By Least Squares Adjustment</para>
		/// </summary>
		public override string DisplayName() => "Analyze Parcels By Least Squares Adjustment";

		/// <summary>
		/// <para>Tool Name : AnalyzeParcelsByLeastSquaresAdjustment</para>
		/// </summary>
		public override string ToolName() => "AnalyzeParcelsByLeastSquaresAdjustment";

		/// <summary>
		/// <para>Tool Excute Name : parcel.AnalyzeParcelsByLeastSquaresAdjustment</para>
		/// </summary>
		public override string ExcuteName() => "parcel.AnalyzeParcelsByLeastSquaresAdjustment";

		/// <summary>
		/// <para>Toolbox Display Name : Parcel Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Parcel Tools";

		/// <summary>
		/// <para>Toolbox Alise : parcel</para>
		/// </summary>
		public override string ToolboxAlise() => "parcel";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InParcelFabric, AnalysisType, ConvergenceTolerance, UpdatedParcelFabric, UpdatedAdjustmentPoints, UpdatedAdjustmentLines, UpdatedAdjustmentVectors };

		/// <summary>
		/// <para>Input Parcel Fabric</para>
		/// <para>The input parcel fabric to be analyzed by least-squares adjustment.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object InParcelFabric { get; set; }

		/// <summary>
		/// <para>Analysis Type</para>
		/// <para>Specifies the type of least-squares analysis that will be used in the adjustment.</para>
		/// <para>Consistency check—A free-network least-squares adjustment will be run to check dimensions on parcel lines for inconsistencies and mistakes. Fixed or weighted control points will not be used by the adjustment.</para>
		/// <para>Weighted least squares—A weighted least-squares adjustment will be run to compute updated coordinates for parcel points. The parcels being adjusted should connect to at least two fixed or weighted control points.</para>
		/// <para><see cref="AnalysisTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AnalysisType { get; set; } = "CONSISTENCY_CHECK";

		/// <summary>
		/// <para>Convergence Tolerance</para>
		/// <para>The tolerance representing the maximum coordinate shift expected after iterating the least-squares adjustment. A least-squares adjustment is run repeatedly (in iterations) until the solution converges. The solution is considered converged when maximum coordinate shift encountered becomes less than the specified convergence tolerance. The default value is 0.05 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object ConvergenceTolerance { get; set; } = "0.05 Meters";

		/// <summary>
		/// <para>Updated Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object UpdatedParcelFabric { get; set; }

		/// <summary>
		/// <para>Updated Adjustment Points</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object UpdatedAdjustmentPoints { get; set; }

		/// <summary>
		/// <para>Updated Adjustment Lines</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object UpdatedAdjustmentLines { get; set; }

		/// <summary>
		/// <para>Updated Adjustment Vectors</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object UpdatedAdjustmentVectors { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Analysis Type</para>
		/// </summary>
		public enum AnalysisTypeEnum 
		{
			/// <summary>
			/// <para>Consistency check—A free-network least-squares adjustment will be run to check dimensions on parcel lines for inconsistencies and mistakes. Fixed or weighted control points will not be used by the adjustment.</para>
			/// </summary>
			[GPValue("CONSISTENCY_CHECK")]
			[Description("Consistency check")]
			Consistency_check,

			/// <summary>
			/// <para>Weighted least squares—A weighted least-squares adjustment will be run to compute updated coordinates for parcel points. The parcels being adjusted should connect to at least two fixed or weighted control points.</para>
			/// </summary>
			[GPValue("WEIGHTED_LEAST_SQUARES")]
			[Description("Weighted least squares")]
			Weighted_least_squares,

		}

#endregion
	}
}
