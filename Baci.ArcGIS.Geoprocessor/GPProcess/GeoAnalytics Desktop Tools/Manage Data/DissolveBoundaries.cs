using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Dissolve Boundaries</para>
	/// <para>Finds polygons that intersect or have the same field values and merges them to form a single polygon.</para>
	/// </summary>
	public class DissolveBoundaries : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Features</para>
		/// <para>The layer containing the polygon features that will be dissolved.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>A new feature class with dissolved boundaries.</para>
		/// </param>
		public DissolveBoundaries(object InputLayer, object OutFeatureClass)
		{
			this.InputLayer = InputLayer;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Dissolve Boundaries</para>
		/// </summary>
		public override string DisplayName => "Dissolve Boundaries";

		/// <summary>
		/// <para>Tool Name : DissolveBoundaries</para>
		/// </summary>
		public override string ToolName => "DissolveBoundaries";

		/// <summary>
		/// <para>Tool Excute Name : gapro.DissolveBoundaries</para>
		/// </summary>
		public override string ExcuteName => "gapro.DissolveBoundaries";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputLayer, OutFeatureClass, Multipart, DissolveFields, Fields, SummaryFields };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The layer containing the polygon features that will be dissolved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>A new feature class with dissolved boundaries.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Create Multipart Features</para>
		/// <para>Specifies whether multipart features will be created in the output feature class.</para>
		/// <para>Checked—Multipart features will be created.</para>
		/// <para>Unchecked—Multipart features will not be created. Individual features will be created for each part instead. This is the default.</para>
		/// <para><see cref="MultipartEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Multipart { get; set; } = "false";

		/// <summary>
		/// <para>Dissolve by Field Value(s)</para>
		/// <para>Specifies whether features with the same field values will be dissolved.</para>
		/// <para>Unchecked—Polygons that share a common border (that is, they are adjacent) or polygons that overlap will be dissolved into one polygon. This is the default.</para>
		/// <para>Checked—Polygons that have the same field value or values will be dissolved.</para>
		/// <para><see cref="DissolveFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DissolveFields { get; set; }

		/// <summary>
		/// <para>Dissolve Field(s)</para>
		/// <para>The field or fields that will be used to dissolve like features. Features with the same value for each field will be dissolved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>The statistics that will be calculated on specified fields.</para>
		/// <para>Count—The number of nonnull values. It can be used on numeric fields or strings. The count of [null, 0, 2] is 2.</para>
		/// <para>Sum—The sum of numeric values in a field. The sum of [null, null, 3] is 3.</para>
		/// <para>Mean—The mean of numeric values. The mean of [0, 2, null] is 1.</para>
		/// <para>Min—The minimum value of a numeric field. The minimum of [0, 2, null] is 0.</para>
		/// <para>Max—The maximum value of a numeric field. The maximum value of [0, 2, null] is 2.</para>
		/// <para>Standard Deviation—The standard deviation of a numeric field. The standard deviation of [1] is null. The standard deviation of [null, 1,1,1] is null.</para>
		/// <para>Variance—The variance of a numeric field in a track. The variance of [1] is null. The variance of [null, 1, 1, 1] is null.</para>
		/// <para>Range—The range of a numeric field. This is calculated as the minimum value subtracted from the maximum value. The range of [0, null, 1] is 1. The range of [null, 4] is 0.</para>
		/// <para>Any—A sample string from a field of type string.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object SummaryFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DissolveBoundaries SetEnviroment(object extent = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Create Multipart Features</para>
		/// </summary>
		public enum MultipartEnum 
		{
			/// <summary>
			/// <para>Checked—Multipart features will be created.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTI_PART")]
			MULTI_PART,

			/// <summary>
			/// <para>Unchecked—Multipart features will not be created. Individual features will be created for each part instead. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("SINGLE_PART")]
			SINGLE_PART,

		}

		/// <summary>
		/// <para>Dissolve by Field Value(s)</para>
		/// </summary>
		public enum DissolveFieldsEnum 
		{
			/// <summary>
			/// <para>Checked—Polygons that have the same field value or values will be dissolved.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DISSOLVE_FIELDS")]
			DISSOLVE_FIELDS,

			/// <summary>
			/// <para>Unchecked—Polygons that share a common border (that is, they are adjacent) or polygons that overlap will be dissolved into one polygon. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DISSOLVE_FIELDS")]
			NO_DISSOLVE_FIELDS,

		}

#endregion
	}
}
