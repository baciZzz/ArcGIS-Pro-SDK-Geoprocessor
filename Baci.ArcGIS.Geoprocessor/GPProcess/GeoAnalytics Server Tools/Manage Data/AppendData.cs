using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsServerTools
{
	/// <summary>
	/// <para>Append Data</para>
	/// <para>Appends features to an existing hosted feature layer.</para>
	/// </summary>
	public class AppendData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>The hosted feature layer to which features will be appended.</para>
		/// </param>
		/// <param name="AppendLayer">
		/// <para>Append Layer</para>
		/// <para>The layer containing features to append to the input layer.</para>
		/// </param>
		/// <param name="AppendMethod">
		/// <para>Append Method</para>
		/// <para>Specifies how fields from the Input Layer will be appended with values from the Append Layer.</para>
		/// <para>Append matching fields only—Input layer fields will only be appended if they have a matching field in the append layer. Fields without a match will be appended with null values.</para>
		/// <para>Append matching fields and resolve differences—Input layer fields can be appended with append layer fields of the same name and different type, or with values calculated from Arcade expressions.</para>
		/// <para><see cref="AppendMethodEnum"/></para>
		/// </param>
		public AppendData(object InputLayer, object AppendLayer, object AppendMethod)
		{
			this.InputLayer = InputLayer;
			this.AppendLayer = AppendLayer;
			this.AppendMethod = AppendMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : Append Data</para>
		/// </summary>
		public override string DisplayName => "Append Data";

		/// <summary>
		/// <para>Tool Name : AppendData</para>
		/// </summary>
		public override string ToolName => "AppendData";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.AppendData</para>
		/// </summary>
		public override string ExcuteName => "geoanalytics.AppendData";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputLayer, AppendLayer, AppendMethod, AppendFields, AppendExpressions, AppendResult };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The hosted feature layer to which features will be appended.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Append Layer</para>
		/// <para>The layer containing features to append to the input layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		[GPTablesDomain()]
		public object AppendLayer { get; set; }

		/// <summary>
		/// <para>Append Method</para>
		/// <para>Specifies how fields from the Input Layer will be appended with values from the Append Layer.</para>
		/// <para>Append matching fields only—Input layer fields will only be appended if they have a matching field in the append layer. Fields without a match will be appended with null values.</para>
		/// <para>Append matching fields and resolve differences—Input layer fields can be appended with append layer fields of the same name and different type, or with values calculated from Arcade expressions.</para>
		/// <para><see cref="AppendMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AppendMethod { get; set; } = "MATCHING_ONLY";

		/// <summary>
		/// <para>Append Fields</para>
		/// <para>The append layer fields of the same type and different name as the input layer fields to be appended. Select the Input Field you want to append to, and the Append Field containing the values you want to append.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object AppendFields { get; set; }

		/// <summary>
		/// <para>Append Expressions</para>
		/// <para>The Arcade expression used to calculate field values for the input field. Expressions are written in Arcade and can include mathematical operators and multiple fields.</para>
		/// <para>Select the fields you want to append to, and enter an expression for each to calculate the values you want to append. If the layer is added to the map, the fields and helpers can be used to build an expression.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object AppendExpressions { get; set; }

		/// <summary>
		/// <para>Append Result</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object AppendResult { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AppendData SetEnviroment(object extent = null , object workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Append Method</para>
		/// </summary>
		public enum AppendMethodEnum 
		{
			/// <summary>
			/// <para>Append matching fields only—Input layer fields will only be appended if they have a matching field in the append layer. Fields without a match will be appended with null values.</para>
			/// </summary>
			[GPValue("MATCHING_ONLY")]
			[Description("Append matching fields only")]
			Append_matching_fields_only,

			/// <summary>
			/// <para>Append matching fields and resolve differences—Input layer fields can be appended with append layer fields of the same name and different type, or with values calculated from Arcade expressions.</para>
			/// </summary>
			[GPValue("FIELD_MAPPING")]
			[Description("Append matching fields and resolve differences")]
			Append_matching_fields_and_resolve_differences,

		}

#endregion
	}
}
