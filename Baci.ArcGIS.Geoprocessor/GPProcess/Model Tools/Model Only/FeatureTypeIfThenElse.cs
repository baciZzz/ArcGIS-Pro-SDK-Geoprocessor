using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>If Feature Type Is</para>
	/// <para>If Feature Type Is</para>
	/// <para>Evaluates if a feature class is of the specified feature type.</para>
	/// </summary>
	public class FeatureTypeIfThenElse : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>Input feature layer to evaluate.</para>
		/// </param>
		/// <param name="FeatureType">
		/// <para>Feature Type</para>
		/// <para>The type of feature being evaluated.</para>
		/// <para>Annotation—Evaluate if the input features are annotation features.</para>
		/// <para>Dimension—Evaluate if the input features are dimension features</para>
		/// <para>Edge—Evaluate if the input features are edge features.</para>
		/// <para>Junction—Evaluate if the input features are junction features.</para>
		/// <para>Line— Evaluate if the input features are line features.</para>
		/// <para>Point—Evaluate if the input features are point features.</para>
		/// <para>Polygon—Evaluate if the input features are polygon features.</para>
		/// <para>Multipatch—Evaluate if the input features are multipatch features.</para>
		/// <para><see cref="FeatureTypeEnum"/></para>
		/// </param>
		public FeatureTypeIfThenElse(object InFeatures, object FeatureType)
		{
			this.InFeatures = InFeatures;
			this.FeatureType = FeatureType;
		}

		/// <summary>
		/// <para>Tool Display Name : If Feature Type Is</para>
		/// </summary>
		public override string DisplayName() => "If Feature Type Is";

		/// <summary>
		/// <para>Tool Name : FeatureTypeIfThenElse</para>
		/// </summary>
		public override string ToolName() => "FeatureTypeIfThenElse";

		/// <summary>
		/// <para>Tool Excute Name : mb.FeatureTypeIfThenElse</para>
		/// </summary>
		public override string ExcuteName() => "mb.FeatureTypeIfThenElse";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise() => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, FeatureType, True, False };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>Input feature layer to evaluate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Feature Type</para>
		/// <para>The type of feature being evaluated.</para>
		/// <para>Annotation—Evaluate if the input features are annotation features.</para>
		/// <para>Dimension—Evaluate if the input features are dimension features</para>
		/// <para>Edge—Evaluate if the input features are edge features.</para>
		/// <para>Junction—Evaluate if the input features are junction features.</para>
		/// <para>Line— Evaluate if the input features are line features.</para>
		/// <para>Point—Evaluate if the input features are point features.</para>
		/// <para>Polygon—Evaluate if the input features are polygon features.</para>
		/// <para>Multipatch—Evaluate if the input features are multipatch features.</para>
		/// <para><see cref="FeatureTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object FeatureType { get; set; }

		/// <summary>
		/// <para>True</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object True { get; set; } = "false";

		/// <summary>
		/// <para>False</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object False { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Feature Type</para>
		/// </summary>
		public enum FeatureTypeEnum 
		{
			/// <summary>
			/// <para>Annotation—Evaluate if the input features are annotation features.</para>
			/// </summary>
			[GPValue("ANNOTATION")]
			[Description("Annotation")]
			Annotation,

			/// <summary>
			/// <para>Dimension—Evaluate if the input features are dimension features</para>
			/// </summary>
			[GPValue("DIMENSION")]
			[Description("Dimension")]
			Dimension,

			/// <summary>
			/// <para>Edge—Evaluate if the input features are edge features.</para>
			/// </summary>
			[GPValue("EDGE")]
			[Description("Edge")]
			Edge,

			/// <summary>
			/// <para>Junction—Evaluate if the input features are junction features.</para>
			/// </summary>
			[GPValue("JUNCTION")]
			[Description("Junction")]
			Junction,

			/// <summary>
			/// <para>Line— Evaluate if the input features are line features.</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("Line")]
			Line,

			/// <summary>
			/// <para>Point—Evaluate if the input features are point features.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

			/// <summary>
			/// <para>Polygon—Evaluate if the input features are polygon features.</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon")]
			Polygon,

			/// <summary>
			/// <para>Multipatch—Evaluate if the input features are multipatch features.</para>
			/// </summary>
			[GPValue("MULTIPATCH")]
			[Description("Multipatch")]
			Multipatch,

		}

#endregion
	}
}
