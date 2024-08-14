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
	/// <para>Minimum Bounding Geometry</para>
	/// <para>Creates a feature class containing polygons which represent a specified minimum bounding geometry enclosing each input feature or each group of input features.</para>
	/// </summary>
	public class MinimumBoundingGeometry : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input features that can be point, multipoint, line, polygon, or multipatch.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class.</para>
		/// </param>
		public MinimumBoundingGeometry(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Minimum Bounding Geometry</para>
		/// </summary>
		public override string DisplayName => "Minimum Bounding Geometry";

		/// <summary>
		/// <para>Tool Name : MinimumBoundingGeometry</para>
		/// </summary>
		public override string ToolName => "MinimumBoundingGeometry";

		/// <summary>
		/// <para>Tool Excute Name : management.MinimumBoundingGeometry</para>
		/// </summary>
		public override string ExcuteName => "management.MinimumBoundingGeometry";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "MDomain", "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, GeometryType!, GroupOption!, GroupField!, MbgFieldsOption! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features that can be point, multipoint, line, polygon, or multipatch.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Geometry Type</para>
		/// <para>Specifies what type of minimum bounding geometry the output polygons will represent.</para>
		/// <para>Rectangle by area—The rectangle of the smallest area enclosing an input feature. This is the default.</para>
		/// <para>Rectangle by width—The rectangle of the smallest width enclosing an input feature.</para>
		/// <para>Convex hull—The smallest convex polygon enclosing an input feature.</para>
		/// <para>Circle—The smallest circle enclosing an input feature envelope.</para>
		/// <para>Envelope—The envelope of an input feature.</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? GeometryType { get; set; } = "RECTANGLE_BY_AREA";

		/// <summary>
		/// <para>Group Option</para>
		/// <para>Specifies how the input features will be grouped; each group will be enclosed with one output polygon.</para>
		/// <para>None—Input features will not be grouped. This is the default. This option is not available for point input.</para>
		/// <para>All—All input features will be treated as one group.</para>
		/// <para>List—Input features will be grouped based on their common values in the specified field or fields in the group field parameter.</para>
		/// <para><see cref="GroupOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? GroupOption { get; set; } = "NONE";

		/// <summary>
		/// <para>Group Field(s)</para>
		/// <para>The field or fields in the input features that will be used to group features, when List is specified as Group Option. At least one group field is required for List option. All features that have the same value in the specified field or fields will be treated as a group.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		public object? GroupField { get; set; }

		/// <summary>
		/// <para>Add geometry characteristics as attributes to output</para>
		/// <para>Specifies whether to add the geometric attributes in the output feature class or omit them in the output feature class.</para>
		/// <para>Unchecked—Omits the geometric attributes in the output feature class. This is the default.</para>
		/// <para>Checked—Adds the geometric attributes in the output feature class.</para>
		/// <para><see cref="MbgFieldsOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MbgFieldsOption { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MinimumBoundingGeometry SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , object? extent = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Geometry Type</para>
		/// </summary>
		public enum GeometryTypeEnum 
		{
			/// <summary>
			/// <para>Rectangle by area—The rectangle of the smallest area enclosing an input feature. This is the default.</para>
			/// </summary>
			[GPValue("RECTANGLE_BY_AREA")]
			[Description("Rectangle by area")]
			Rectangle_by_area,

			/// <summary>
			/// <para>Rectangle by width—The rectangle of the smallest width enclosing an input feature.</para>
			/// </summary>
			[GPValue("RECTANGLE_BY_WIDTH")]
			[Description("Rectangle by width")]
			Rectangle_by_width,

			/// <summary>
			/// <para>Convex hull—The smallest convex polygon enclosing an input feature.</para>
			/// </summary>
			[GPValue("CONVEX_HULL")]
			[Description("Convex hull")]
			Convex_hull,

			/// <summary>
			/// <para>Circle—The smallest circle enclosing an input feature envelope.</para>
			/// </summary>
			[GPValue("CIRCLE")]
			[Description("Circle")]
			Circle,

			/// <summary>
			/// <para>Envelope—The envelope of an input feature.</para>
			/// </summary>
			[GPValue("ENVELOPE")]
			[Description("Envelope")]
			Envelope,

		}

		/// <summary>
		/// <para>Group Option</para>
		/// </summary>
		public enum GroupOptionEnum 
		{
			/// <summary>
			/// <para>None—Input features will not be grouped. This is the default. This option is not available for point input.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>All—All input features will be treated as one group.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>List—Input features will be grouped based on their common values in the specified field or fields in the group field parameter.</para>
			/// </summary>
			[GPValue("LIST")]
			[Description("List")]
			List,

		}

		/// <summary>
		/// <para>Add geometry characteristics as attributes to output</para>
		/// </summary>
		public enum MbgFieldsOptionEnum 
		{
			/// <summary>
			/// <para>Checked—Adds the geometric attributes in the output feature class.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MBG_FIELDS")]
			MBG_FIELDS,

			/// <summary>
			/// <para>Unchecked—Omits the geometric attributes in the output feature class. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MBG_FIELDS")]
			NO_MBG_FIELDS,

		}

#endregion
	}
}
