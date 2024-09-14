using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AviationTools
{
	/// <summary>
	/// <para>Generate Changeover Points</para>
	/// <para>Generate Changeover Points</para>
	/// <para>Creates changeover points along routes.</para>
	/// </summary>
	public class GenerateChangeoverPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input ATS Route Features</para>
		/// <para>The input feature class of routes on which changeover points are based. It must contain polyline features.</para>
		/// </param>
		/// <param name="TargetChangeoverFeatures">
		/// <para>Target Changeover Point Features</para>
		/// <para>The point feature class that contains the changeover points. After running the tool, new changeover points are added and existing changeover points are updated.</para>
		/// </param>
		/// <param name="DistanceSourceType">
		/// <para>Distance Source Type</para>
		/// <para>Specifies the source of the changeover distance value.</para>
		/// <para>Route—The changeover distances are stored in the target point layer.</para>
		/// <para>Point—The changeover distances are stored in the source line layer.</para>
		/// <para><see cref="DistanceSourceTypeEnum"/></para>
		/// </param>
		public GenerateChangeoverPoints(object InFeatures, object TargetChangeoverFeatures, object DistanceSourceType)
		{
			this.InFeatures = InFeatures;
			this.TargetChangeoverFeatures = TargetChangeoverFeatures;
			this.DistanceSourceType = DistanceSourceType;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Changeover Points</para>
		/// </summary>
		public override string DisplayName() => "Generate Changeover Points";

		/// <summary>
		/// <para>Tool Name : GenerateChangeoverPoints</para>
		/// </summary>
		public override string ToolName() => "GenerateChangeoverPoints";

		/// <summary>
		/// <para>Tool Excute Name : aviation.GenerateChangeoverPoints</para>
		/// </summary>
		public override string ExcuteName() => "aviation.GenerateChangeoverPoints";

		/// <summary>
		/// <para>Toolbox Display Name : Aviation Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Aviation Tools";

		/// <summary>
		/// <para>Toolbox Alise : aviation</para>
		/// </summary>
		public override string ToolboxAlise() => "aviation";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, TargetChangeoverFeatures, DistanceSourceType, UpdatedFeatures! };

		/// <summary>
		/// <para>Input ATS Route Features</para>
		/// <para>The input feature class of routes on which changeover points are based. It must contain polyline features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Target Changeover Point Features</para>
		/// <para>The point feature class that contains the changeover points. After running the tool, new changeover points are added and existing changeover points are updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object TargetChangeoverFeatures { get; set; }

		/// <summary>
		/// <para>Distance Source Type</para>
		/// <para>Specifies the source of the changeover distance value.</para>
		/// <para>Route—The changeover distances are stored in the target point layer.</para>
		/// <para>Point—The changeover distances are stored in the source line layer.</para>
		/// <para><see cref="DistanceSourceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceSourceType { get; set; }

		/// <summary>
		/// <para>Updated Point Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object? UpdatedFeatures { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Distance Source Type</para>
		/// </summary>
		public enum DistanceSourceTypeEnum 
		{
			/// <summary>
			/// <para>Point—The changeover distances are stored in the source line layer.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

			/// <summary>
			/// <para>Route—The changeover distances are stored in the target point layer.</para>
			/// </summary>
			[GPValue("ROUTE")]
			[Description("Route")]
			Route,

		}

#endregion
	}
}
