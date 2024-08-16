using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.BusinessAnalystTools
{
	/// <summary>
	/// <para>Remove Overlap</para>
	/// <para>Removes overlap between two or more areas to form adjacent boundaries.</para>
	/// </summary>
	public class RemoveOverlap : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input features containing the overlapping polygons.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class containing the new trade area features.</para>
		/// </param>
		public RemoveOverlap(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Overlap</para>
		/// </summary>
		public override string DisplayName => "Remove Overlap";

		/// <summary>
		/// <para>Tool Name : RemoveOverlap</para>
		/// </summary>
		public override string ToolName => "RemoveOverlap";

		/// <summary>
		/// <para>Tool Excute Name : ba.RemoveOverlap</para>
		/// </summary>
		public override string ExcuteName => "ba.RemoveOverlap";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, Method, DefineTradeArea, RingIdField, WeightField, StoreId, InStoresLayer, LinkField };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features containing the overlapping polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class containing the new trade area features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>Specifies how the overlap between trade areas will be removed.</para>
		/// <para>Center Line— Overlap will be removed by creating a border that evenly distributes the area of intersection between polygons. This is the default.</para>
		/// <para>Thiessen— Overlap will be removed using straight lines to divide the area of intersection.</para>
		/// <para>Grid— Overlap will be removed by creating a grid of parallel lines used to define a natural division between polygons.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "CENTER_LINE";

		/// <summary>
		/// <para>Define Trade Areas</para>
		/// <para>Specifies whether ring overlap in a trade area will be removed.</para>
		/// <para>Checked—Overlap will only be removed between polygons with equal values in the Ring ID Field parameter.</para>
		/// <para>Unchecked—Overlap will be removed from all intersecting polygons. This is the default.</para>
		/// <para><see cref="DefineTradeAreaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DefineTradeArea { get; set; } = "false";

		/// <summary>
		/// <para>Ring ID Field</para>
		/// <para>A field from the input that defines common trade areas. Overlap between polygons will only be removed if their values in this field are equal.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Short", "Long", "GUID", "GlobalID")]
		public object RingIdField { get; set; }

		/// <summary>
		/// <para>Weight Field</para>
		/// <para>A field from the input used to influence removal of overlap based on its values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object WeightField { get; set; }

		/// <summary>
		/// <para>Input Feature Store ID Field</para>
		/// <para>A unique ID field in the stores feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Short", "Long", "GUID", "GlobalID")]
		public object StoreId { get; set; }

		/// <summary>
		/// <para>Stores</para>
		/// <para>The input features containing the center points for the overlapping trade areas.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InStoresLayer { get; set; }

		/// <summary>
		/// <para>Associated Store ID Field</para>
		/// <para>A unique ID field representing a store or facility location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object LinkField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveOverlap SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Center Line— Overlap will be removed by creating a border that evenly distributes the area of intersection between polygons. This is the default.</para>
			/// </summary>
			[GPValue("CENTER_LINE")]
			[Description("Center Line")]
			Center_Line,

			/// <summary>
			/// <para>Thiessen— Overlap will be removed using straight lines to divide the area of intersection.</para>
			/// </summary>
			[GPValue("THIESSEN")]
			[Description("Thiessen")]
			Thiessen,

			/// <summary>
			/// <para>Grid— Overlap will be removed by creating a grid of parallel lines used to define a natural division between polygons.</para>
			/// </summary>
			[GPValue("GRID")]
			[Description("Grid")]
			Grid,

		}

		/// <summary>
		/// <para>Define Trade Areas</para>
		/// </summary>
		public enum DefineTradeAreaEnum 
		{
			/// <summary>
			/// <para>Checked—Overlap will only be removed between polygons with equal values in the Ring ID Field parameter.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DEFINE_TRADE_AREA")]
			DEFINE_TRADE_AREA,

			/// <summary>
			/// <para>Unchecked—Overlap will be removed from all intersecting polygons. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_DEFINE_TRADE_AREA")]
			DO_NOT_DEFINE_TRADE_AREA,

		}

#endregion
	}
}
