using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Calculate Route Concurrencies</para>
	/// <para>Calculate Route Concurrencies</para>
	/// <para>Calculates and reports concurrent route sections in an LRS Network.</para>
	/// </summary>
	public class CalculateRouteConcurrencies : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRouteFeatures">
		/// <para>Input Route Features</para>
		/// <para>The LRS Network feature class in which route concurrencies will be calculated.</para>
		/// </param>
		/// <param name="OutDataset">
		/// <para>Output Dataset</para>
		/// <para>The feature class or table to which the calculated results will be posted.</para>
		/// </param>
		public CalculateRouteConcurrencies(object InRouteFeatures, object OutDataset)
		{
			this.InRouteFeatures = InRouteFeatures;
			this.OutDataset = OutDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Route Concurrencies</para>
		/// </summary>
		public override string DisplayName() => "Calculate Route Concurrencies";

		/// <summary>
		/// <para>Tool Name : CalculateRouteConcurrencies</para>
		/// </summary>
		public override string ToolName() => "CalculateRouteConcurrencies";

		/// <summary>
		/// <para>Tool Excute Name : locref.CalculateRouteConcurrencies</para>
		/// </summary>
		public override string ExcuteName() => "locref.CalculateRouteConcurrencies";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRouteFeatures, OutDataset, Tvd!, FindDominance!, IncludeGeometry! };

		/// <summary>
		/// <para>Input Route Features</para>
		/// <para>The LRS Network feature class in which route concurrencies will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InRouteFeatures { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>The feature class or table to which the calculated results will be posted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Temporal View Date</para>
		/// <para>The temporal view date for the network, if one is specified. Leaving this field blank shows all time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? Tvd { get; set; }

		/// <summary>
		/// <para>Set route dominance based on priority rules</para>
		/// <para>Specifies whether configured route dominance rules will be used to set dominance.</para>
		/// <para>Checked—Configured route dominance rules will be used to determine the dominant route in each concurrent section. This is the default.</para>
		/// <para>Unchecked—Configured route dominance rules will not be used to determine the dominant route in each concurrent section.</para>
		/// <para><see cref="FindDominanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? FindDominance { get; set; } = "true";

		/// <summary>
		/// <para>Include Geometry</para>
		/// <para>Specifies whether geometry will be included in the output dataset.</para>
		/// <para>Checked—Geometry will be included in the output dataset.</para>
		/// <para>Unchecked—Geometry will not be included in the output dataset. This is the default.</para>
		/// <para><see cref="IncludeGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeGeometry { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateRouteConcurrencies SetEnviroment(object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Set route dominance based on priority rules</para>
		/// </summary>
		public enum FindDominanceEnum 
		{
			/// <summary>
			/// <para>Checked—Configured route dominance rules will be used to determine the dominant route in each concurrent section. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_DOMINANCE")]
			FIND_DOMINANCE,

			/// <summary>
			/// <para>Unchecked—Configured route dominance rules will not be used to determine the dominant route in each concurrent section.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FIND_DOMINANCE")]
			NO_FIND_DOMINANCE,

		}

		/// <summary>
		/// <para>Include Geometry</para>
		/// </summary>
		public enum IncludeGeometryEnum 
		{
			/// <summary>
			/// <para>Checked—Geometry will be included in the output dataset.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_GEOMETRY")]
			INCLUDE_GEOMETRY,

			/// <summary>
			/// <para>Unchecked—Geometry will not be included in the output dataset. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_GEOMETRY")]
			EXCLUDE_GEOMETRY,

		}

#endregion
	}
}
