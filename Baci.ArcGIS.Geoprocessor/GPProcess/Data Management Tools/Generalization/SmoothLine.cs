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
	/// <para>Smooth Line</para>
	/// <para>Smoothes a line to improve visual quality.</para>
	/// </summary>
	[Obsolete()]
	public class SmoothLine : AbstractGPProcess
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
		/// <para>Smoothing Algorithm</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </param>
		/// <param name="Tolerance">
		/// <para>Smoothing Tolerance</para>
		/// </param>
		public SmoothLine(object InFeatures, object OutFeatureClass, object Algorithm, object Tolerance)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.Algorithm = Algorithm;
			this.Tolerance = Tolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : Smooth Line</para>
		/// </summary>
		public override string DisplayName() => "Smooth Line";

		/// <summary>
		/// <para>Tool Name : SmoothLine</para>
		/// </summary>
		public override string ToolName() => "SmoothLine";

		/// <summary>
		/// <para>Tool Excute Name : management.SmoothLine</para>
		/// </summary>
		public override string ExcuteName() => "management.SmoothLine";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, Algorithm, Tolerance, EndpointOption, ErrorOption, InBarriers };

		/// <summary>
		/// <para>Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Smoothing Algorithm</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Algorithm { get; set; } = "PAEK";

		/// <summary>
		/// <para>Smoothing Tolerance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object Tolerance { get; set; }

		/// <summary>
		/// <para>Preserve endpoint for closed lines</para>
		/// <para><see cref="EndpointOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object EndpointOption { get; set; } = "true";

		/// <summary>
		/// <para>Handling Topological Errors</para>
		/// <para><see cref="ErrorOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ErrorOption { get; set; } = "NO_CHECK";

		/// <summary>
		/// <para>Input Barriers Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InBarriers { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Smoothing Algorithm</para>
		/// </summary>
		public enum AlgorithmEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PAEK")]
			[Description("PAEK")]
			PAEK,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("BEZIER_INTERPOLATION")]
			[Description("BEZIER_INTERPOLATION")]
			BEZIER_INTERPOLATION,

		}

		/// <summary>
		/// <para>Preserve endpoint for closed lines</para>
		/// </summary>
		public enum EndpointOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FIXED_CLOSED_ENDPOINT")]
			FIXED_CLOSED_ENDPOINT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FIXED")]
			NO_FIXED,

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

#endregion
	}
}
