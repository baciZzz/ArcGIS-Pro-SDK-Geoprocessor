using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Simplify Polygon</para>
	/// <para>Simplifies polygons by removing small fluctuations.</para>
	/// </summary>
	[Obsolete()]
	public class SimplifyPolygon : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// </param>
		/// <param name="Algorithm">
		/// <para>Simplification Algorithm</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </param>
		/// <param name="Tolerance">
		/// <para>Simplification Tolerance</para>
		/// </param>
		public SimplifyPolygon(object InFeatures, object OutFeatureClass, object Algorithm, object Tolerance)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.Algorithm = Algorithm;
			this.Tolerance = Tolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : Simplify Polygon</para>
		/// </summary>
		public override string DisplayName => "Simplify Polygon";

		/// <summary>
		/// <para>Tool Name : SimplifyPolygon</para>
		/// </summary>
		public override string ToolName => "SimplifyPolygon";

		/// <summary>
		/// <para>Tool Excute Name : management.SimplifyPolygon</para>
		/// </summary>
		public override string ExcuteName => "management.SimplifyPolygon";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, Algorithm, Tolerance, MinimumArea, ErrorOption, CollapsedPointOption, OutPointFeatureClass, InBarriers };

		/// <summary>
		/// <para>Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Simplification Algorithm</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Algorithm { get; set; } = "POINT_REMOVE";

		/// <summary>
		/// <para>Simplification Tolerance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object Tolerance { get; set; }

		/// <summary>
		/// <para>Minimum Area</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object MinimumArea { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Handling Topological Errors</para>
		/// <para><see cref="ErrorOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ErrorOption { get; set; } = "RESOLVE_ERRORS";

		/// <summary>
		/// <para>Keep collapsed points</para>
		/// <para><see cref="CollapsedPointOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CollapsedPointOption { get; set; } = "true";

		/// <summary>
		/// <para>Output Point Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutPointFeatureClass { get; set; } = "output_feature_class_Pnt";

		/// <summary>
		/// <para>Input Barriers Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InBarriers { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Simplification Algorithm</para>
		/// </summary>
		public enum AlgorithmEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("POINT_REMOVE")]
			[Description("POINT_REMOVE")]
			POINT_REMOVE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("BEND_SIMPLIFY")]
			[Description("BEND_SIMPLIFY")]
			BEND_SIMPLIFY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("WEIGHTED_AREA")]
			[Description("WEIGHTED_AREA")]
			WEIGHTED_AREA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("EFFECTIVE_AREA")]
			[Description("EFFECTIVE_AREA")]
			EFFECTIVE_AREA,

		}

		/// <summary>
		/// <para>Handling Topological Errors</para>
		/// </summary>
		public enum ErrorOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NO_CHECK")]
			[Description("NO_CHECK")]
			NO_CHECK,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("FLAG_ERRORS")]
			[Description("FLAG_ERRORS")]
			FLAG_ERRORS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RESOLVE_ERRORS")]
			[Description("RESOLVE_ERRORS")]
			RESOLVE_ERRORS,

		}

		/// <summary>
		/// <para>Keep collapsed points</para>
		/// </summary>
		public enum CollapsedPointOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_COLLAPSED_POINTS")]
			KEEP_COLLAPSED_POINTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_KEEP")]
			NO_KEEP,

		}

#endregion
	}
}
