using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Grid Index Features</para>
	/// <para>Grid Index Features</para>
	/// <para>Creates a grid of rectangular polygon features that can be used as an index to specify pages in a spatial map series. A grid can be created that includes only polygon features that intersect another feature layer.</para>
	/// </summary>
	public class GridIndexFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The resulting feature class of polygon index features.</para>
		/// <para>The coordinate system of the output feature class is determined in the following order:</para>
		/// <para>If a coordinate system is specified by the Output Coordinate System environment, the output feature class will use this coordinate system.</para>
		/// <para>If a coordinate system is not specified by the Output Coordinate System environment, the output feature class will use the coordinate system of the active map (ArcGIS Pro is open).</para>
		/// <para>If a coordinate system is not specified by the Output Coordinate System environment, and there is no active map (ArcGIS Pro is not open), the output feature class will use the coordinate system of the first input feature.</para>
		/// <para>If a coordinate system is not specified by the Output Coordinate System environment, there is no active map (ArcGIS Pro is not open), and there are no specified input features, the coordinate system of the output feature class will be unknown.</para>
		/// </param>
		public GridIndexFeatures(object OutFeatureClass)
		{
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Grid Index Features</para>
		/// </summary>
		public override string DisplayName() => "Grid Index Features";

		/// <summary>
		/// <para>Tool Name : GridIndexFeatures</para>
		/// </summary>
		public override string ToolName() => "GridIndexFeatures";

		/// <summary>
		/// <para>Tool Excute Name : cartography.GridIndexFeatures</para>
		/// </summary>
		public override string ExcuteName() => "cartography.GridIndexFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise() => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutFeatureClass, InFeatures, IntersectFeature, UsePageUnit, Scale, PolygonWidth, PolygonHeight, OriginCoord, NumberRows, NumberColumns, StartingPageNumber, LabelFromOrigin };

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The resulting feature class of polygon index features.</para>
		/// <para>The coordinate system of the output feature class is determined in the following order:</para>
		/// <para>If a coordinate system is specified by the Output Coordinate System environment, the output feature class will use this coordinate system.</para>
		/// <para>If a coordinate system is not specified by the Output Coordinate System environment, the output feature class will use the coordinate system of the active map (ArcGIS Pro is open).</para>
		/// <para>If a coordinate system is not specified by the Output Coordinate System environment, and there is no active map (ArcGIS Pro is not open), the output feature class will use the coordinate system of the first input feature.</para>
		/// <para>If a coordinate system is not specified by the Output Coordinate System environment, there is no active map (ArcGIS Pro is not open), and there are no specified input features, the coordinate system of the output feature class will be unknown.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features to be used to define the extent of the polygon grid that will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Generate Polygon Grid that intersects input feature layers or datasets</para>
		/// <para>Specifies whether the output grid feature class is limited to areas that intersect input feature layers or datasets. The intersection of input features will be used to create index features.</para>
		/// <para>Checked—Limits the output grid feature class to areas that intersect input feature layers or datasets. When input features are specified, this is the default.</para>
		/// <para>Unchecked—An output grid feature class is created using specified coordinates, rows, and columns.</para>
		/// <para><see cref="IntersectFeatureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IntersectFeature { get; set; } = "false";

		/// <summary>
		/// <para>Use Page Unit and Scale</para>
		/// <para>Specifies whether index polygon size input is in page units.</para>
		/// <para>Checked—Index polygon height and width are calculated in page units.</para>
		/// <para>Unchecked—Index polygon height and width are calculated in map units. This is the default.</para>
		/// <para><see cref="UsePageUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UsePageUnit { get; set; } = "false";

		/// <summary>
		/// <para>Map Scale</para>
		/// <para>The map scale. The scale must be specified if the index polygon height and width are to be calculated in page units. If the tool is used outside an active ArcGIS Pro session, the default scale value is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object Scale { get; set; }

		/// <summary>
		/// <para>Polygon Width</para>
		/// <para>The width of the index polygon specified in either map or page units. If page units are used, the default value is 1 inch. If map units are used, the default value is 1 degree.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object PolygonWidth { get; set; } = "1 DecimalDegrees";

		/// <summary>
		/// <para>Polygon Height</para>
		/// <para>The height of the index polygon specified in either map or page units. If page units are used, the default value is 1 inch. If map units are used, the default value is 1 degree.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object PolygonHeight { get; set; } = "1 DecimalDegrees";

		/// <summary>
		/// <para>Polygon Grid Origin Coordinate</para>
		/// <para>The coordinate value for the lower left origin of the output grid feature class. If input features are specified, the default value is determined by the extent of the union of extents for these features. If there are no input features specified, the default coordinates are 0 and 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		public object OriginCoord { get; set; } = "0 0";

		/// <summary>
		/// <para>Number of Rows</para>
		/// <para>The number of rows to create in the y direction from the point of origin. The default is 10.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object NumberRows { get; set; } = "10";

		/// <summary>
		/// <para>Number of Columns</para>
		/// <para>The number of columns to create in the x direction from the point of origin. The default is 10.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object NumberColumns { get; set; } = "10";

		/// <summary>
		/// <para>Starting Page Number</para>
		/// <para>Each grid index feature is assigned a sequential page number starting with a specified starting page number. The default is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object StartingPageNumber { get; set; } = "1";

		/// <summary>
		/// <para>Start labeling from the Origin</para>
		/// <para>Specifies where page numbers (labels) begin.</para>
		/// <para>Checked—Page numbers (labels) begin with the polygon feature in the lower left corner of the output grid.</para>
		/// <para>Unchecked—Page numbers (labels) begin with the polygon feature in the upper left corner of the output grid. This is the default.</para>
		/// <para><see cref="LabelFromOriginEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object LabelFromOrigin { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GridIndexFeatures SetEnviroment(object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Generate Polygon Grid that intersects input feature layers or datasets</para>
		/// </summary>
		public enum IntersectFeatureEnum 
		{
			/// <summary>
			/// <para>Checked—Limits the output grid feature class to areas that intersect input feature layers or datasets. When input features are specified, this is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INTERSECTFEATURE")]
			INTERSECTFEATURE,

			/// <summary>
			/// <para>Unchecked—An output grid feature class is created using specified coordinates, rows, and columns.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_INTERSECTFEATURE")]
			NO_INTERSECTFEATURE,

		}

		/// <summary>
		/// <para>Use Page Unit and Scale</para>
		/// </summary>
		public enum UsePageUnitEnum 
		{
			/// <summary>
			/// <para>Checked—Index polygon height and width are calculated in page units.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USEPAGEUNIT")]
			USEPAGEUNIT,

			/// <summary>
			/// <para>Unchecked—Index polygon height and width are calculated in map units. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_USEPAGEUNIT")]
			NO_USEPAGEUNIT,

		}

		/// <summary>
		/// <para>Start labeling from the Origin</para>
		/// </summary>
		public enum LabelFromOriginEnum 
		{
			/// <summary>
			/// <para>Checked—Page numbers (labels) begin with the polygon feature in the lower left corner of the output grid.</para>
			/// </summary>
			[GPValue("true")]
			[Description("LABELFROMORIGIN")]
			LABELFROMORIGIN,

			/// <summary>
			/// <para>Unchecked—Page numbers (labels) begin with the polygon feature in the upper left corner of the output grid. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_LABELFROMORIGIN")]
			NO_LABELFROMORIGIN,

		}

#endregion
	}
}
