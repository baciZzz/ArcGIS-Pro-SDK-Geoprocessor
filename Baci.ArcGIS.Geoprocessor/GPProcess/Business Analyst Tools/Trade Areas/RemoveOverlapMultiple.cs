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
	/// <para>Remove Overlap (multiple)</para>
	/// <para>Removes overlap between polygons contained in multiple input layers.</para>
	/// </summary>
	public class RemoveOverlapMultiple : AbstractGPProcess
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
		public RemoveOverlapMultiple(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Overlap (multiple)</para>
		/// </summary>
		public override string DisplayName => "Remove Overlap (multiple)";

		/// <summary>
		/// <para>Tool Name : RemoveOverlapMultiple</para>
		/// </summary>
		public override string ToolName => "RemoveOverlapMultiple";

		/// <summary>
		/// <para>Tool Excute Name : ba.RemoveOverlapMultiple</para>
		/// </summary>
		public override string ExcuteName => "ba.RemoveOverlapMultiple";

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
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, Method, JoinAttributes };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features containing the overlapping polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
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
		/// <para>Center Line—Overlap will be removed by creating a border that evenly distributes the area of intersection between polygons. This is the default.</para>
		/// <para>Thiessen—Overlap will be removed using straight lines to divide the area of intersection.</para>
		/// <para>Grid—Overlap will be removed by creating a grid of parallel lines used to define a natural division between polygons.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "CENTER_LINE";

		/// <summary>
		/// <para>Attributes To Join</para>
		/// <para>Specifies which attributes of input layers will be copied to the output.</para>
		/// <para>All attributes—All attributes from the input features will be transferred to the output feature class. This is the default.</para>
		/// <para>All attributes except feature IDs—All attributes from the input features, except the FID field, will be transferred to the output feature class.</para>
		/// <para>Only feature IDs—Only the FID field from the input features will be transferred to the output feature class.</para>
		/// <para><see cref="JoinAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object JoinAttributes { get; set; } = "ALL";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveOverlapMultiple SetEnviroment(object workspace = null )
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
			/// <para>Center Line—Overlap will be removed by creating a border that evenly distributes the area of intersection between polygons. This is the default.</para>
			/// </summary>
			[GPValue("CENTER_LINE")]
			[Description("Center Line")]
			Center_Line,

			/// <summary>
			/// <para>Thiessen—Overlap will be removed using straight lines to divide the area of intersection.</para>
			/// </summary>
			[GPValue("THIESSEN")]
			[Description("Thiessen")]
			Thiessen,

			/// <summary>
			/// <para>Grid—Overlap will be removed by creating a grid of parallel lines used to define a natural division between polygons.</para>
			/// </summary>
			[GPValue("GRID")]
			[Description("Grid")]
			Grid,

		}

		/// <summary>
		/// <para>Attributes To Join</para>
		/// </summary>
		public enum JoinAttributesEnum 
		{
			/// <summary>
			/// <para>All attributes—All attributes from the input features will be transferred to the output feature class. This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All attributes")]
			All_attributes,

			/// <summary>
			/// <para>All attributes except feature IDs—All attributes from the input features, except the FID field, will be transferred to the output feature class.</para>
			/// </summary>
			[GPValue("NO_FID")]
			[Description("All attributes except feature IDs")]
			All_attributes_except_feature_IDs,

			/// <summary>
			/// <para>Only feature IDs—Only the FID field from the input features will be transferred to the output feature class.</para>
			/// </summary>
			[GPValue("ONLY_FID")]
			[Description("Only feature IDs")]
			Only_feature_IDs,

		}

#endregion
	}
}
