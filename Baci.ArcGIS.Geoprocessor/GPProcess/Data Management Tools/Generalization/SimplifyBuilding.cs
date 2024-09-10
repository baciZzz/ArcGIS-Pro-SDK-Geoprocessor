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
	/// <para>Simplify Building</para>
	/// <para>Simplifies boundaries or building footprints.</para>
	/// </summary>
	[Obsolete()]
	public class SimplifyBuilding : AbstractGPProcess
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
		/// <param name="SimplificationTolerance">
		/// <para>Simplification Tolerance</para>
		/// </param>
		public SimplifyBuilding(object InFeatures, object OutFeatureClass, object SimplificationTolerance)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.SimplificationTolerance = SimplificationTolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : Simplify Building</para>
		/// </summary>
		public override string DisplayName() => "Simplify Building";

		/// <summary>
		/// <para>Tool Name : SimplifyBuilding</para>
		/// </summary>
		public override string ToolName() => "SimplifyBuilding";

		/// <summary>
		/// <para>Tool Excute Name : management.SimplifyBuilding</para>
		/// </summary>
		public override string ExcuteName() => "management.SimplifyBuilding";

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
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, SimplificationTolerance, MinimumArea, ConflictOption, InBarriers, OutPointFeatureClass, CollapsedPointOption };

		/// <summary>
		/// <para>Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexJunction", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Simplification Tolerance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SimplificationTolerance { get; set; }

		/// <summary>
		/// <para>Minimum Area</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object MinimumArea { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Check for spatial conflicts</para>
		/// <para><see cref="ConflictOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ConflictOption { get; set; } = "false";

		/// <summary>
		/// <para>Input Barriers Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InBarriers { get; set; }

		/// <summary>
		/// <para>Output Point Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutPointFeatureClass { get; set; } = "output_feature_class_Pnt";

		/// <summary>
		/// <para>Keep collapsed points</para>
		/// <para><see cref="CollapsedPointOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CollapsedPointOption { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Check for spatial conflicts</para>
		/// </summary>
		public enum ConflictOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CHECK_CONFLICTS")]
			CHECK_CONFLICTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CHECK")]
			NO_CHECK,

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
