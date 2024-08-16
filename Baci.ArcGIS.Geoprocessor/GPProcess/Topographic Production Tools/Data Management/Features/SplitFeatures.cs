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
	/// <para>Split Features</para>
	/// <para>Splits features on input feature classes for any number of polyline or polygon target feature classes using the cutting features and inserts points on the cutting feature.</para>
	/// </summary>
	public class SplitFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="CuttingFeatures">
		/// <para>Cutting Features</para>
		/// <para>The cutting feature used to split the target features where they intersect the target feature class geometries.</para>
		/// </param>
		/// <param name="TargetFeatures">
		/// <para>Target Features</para>
		/// <para>The features that will be divided by the cutting features.</para>
		/// </param>
		/// <param name="UseTargetZ">
		/// <para>Use Target Z Values</para>
		/// <para>Specifies the source of the z-value from the source or target.</para>
		/// <para>Checked—Uses the z-value from the source or target.</para>
		/// <para>Unchecked—Does not use the z-value. This is the default.</para>
		/// <para><see cref="UseTargetZEnum"/></para>
		/// </param>
		public SplitFeatures(object CuttingFeatures, object TargetFeatures, object UseTargetZ)
		{
			this.CuttingFeatures = CuttingFeatures;
			this.TargetFeatures = TargetFeatures;
			this.UseTargetZ = UseTargetZ;
		}

		/// <summary>
		/// <para>Tool Display Name : Split Features</para>
		/// </summary>
		public override string DisplayName => "Split Features";

		/// <summary>
		/// <para>Tool Name : SplitFeatures</para>
		/// </summary>
		public override string ToolName => "SplitFeatures";

		/// <summary>
		/// <para>Tool Excute Name : topographic.SplitFeatures</para>
		/// </summary>
		public override string ExcuteName => "topographic.SplitFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { CuttingFeatures, TargetFeatures, UseTargetZ, OutFeatureLayer };

		/// <summary>
		/// <para>Cutting Features</para>
		/// <para>The cutting feature used to split the target features where they intersect the target feature class geometries.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object CuttingFeatures { get; set; }

		/// <summary>
		/// <para>Target Features</para>
		/// <para>The features that will be divided by the cutting features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		[FeatureType("Simple")]
		public object TargetFeatures { get; set; }

		/// <summary>
		/// <para>Use Target Z Values</para>
		/// <para>Specifies the source of the z-value from the source or target.</para>
		/// <para>Checked—Uses the z-value from the source or target.</para>
		/// <para>Unchecked—Does not use the z-value. This is the default.</para>
		/// <para><see cref="UseTargetZEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseTargetZ { get; set; } = "true";

		/// <summary>
		/// <para>Output Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureLayer { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Use Target Z Values</para>
		/// </summary>
		public enum UseTargetZEnum 
		{
			/// <summary>
			/// <para>Checked—Uses the z-value from the source or target.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_TARGET_Z")]
			USE_TARGET_Z,

			/// <summary>
			/// <para>Unchecked—Does not use the z-value. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_USE_TARGET_Z")]
			DONT_USE_TARGET_Z,

		}

#endregion
	}
}
