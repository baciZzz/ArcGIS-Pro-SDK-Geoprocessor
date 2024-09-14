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
	/// <para>Subdivide Polygon</para>
	/// <para>Subdivide Polygon</para>
	/// <para>Divides polygon features into a number of equal areas or parts.</para>
	/// </summary>
	public class SubdividePolygon : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPolygons">
		/// <para>Input Features</para>
		/// <para>The polygon features to be subdivided.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class of subdivided polygons.</para>
		/// </param>
		/// <param name="Method">
		/// <para>Subdivision Method</para>
		/// <para>Specifies the method that will be used to divide the polygons.</para>
		/// <para>Number of equal parts— Polygons will be divided evenly into a number of parts. This is the default.</para>
		/// <para>Equal areas—Polygons will be divided into a specified number of parts of a certain area, and a remainder part.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </param>
		public SubdividePolygon(object InPolygons, object OutFeatureClass, object Method)
		{
			this.InPolygons = InPolygons;
			this.OutFeatureClass = OutFeatureClass;
			this.Method = Method;
		}

		/// <summary>
		/// <para>Tool Display Name : Subdivide Polygon</para>
		/// </summary>
		public override string DisplayName() => "Subdivide Polygon";

		/// <summary>
		/// <para>Tool Name : SubdividePolygon</para>
		/// </summary>
		public override string ToolName() => "SubdividePolygon";

		/// <summary>
		/// <para>Tool Excute Name : management.SubdividePolygon</para>
		/// </summary>
		public override string ExcuteName() => "management.SubdividePolygon";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPolygons, OutFeatureClass, Method, NumAreas!, TargetArea!, TargetWidth!, SplitAngle!, SubdivisionType! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The polygon features to be subdivided.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InPolygons { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class of subdivided polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Subdivision Method</para>
		/// <para>Specifies the method that will be used to divide the polygons.</para>
		/// <para>Number of equal parts— Polygons will be divided evenly into a number of parts. This is the default.</para>
		/// <para>Equal areas—Polygons will be divided into a specified number of parts of a certain area, and a remainder part.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "NUMBER_OF_EQUAL_PARTS";

		/// <summary>
		/// <para>Number of Areas</para>
		/// <para>The number of areas into which the polygon will be divided if the Number of equal parts subdivision method is specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 2)]
		[High(Allow = false, Value = 2147483647)]
		public object? NumAreas { get; set; }

		/// <summary>
		/// <para>Target Area</para>
		/// <para>The area of the equal parts if the Equal areas subdivision method is specified. If the Target Area is larger than the area of the input polygon, the polygon will not be subdivided.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object? TargetArea { get; set; }

		/// <summary>
		/// <para>RESERVED</para>
		/// <para>This parameter is not yet supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		public object? TargetWidth { get; set; }

		/// <summary>
		/// <para>Split Angle</para>
		/// <para>The angle that will be used to draw the lines that divide the polygon. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SplitAngle { get; set; } = "0";

		/// <summary>
		/// <para>Subdivision Type</para>
		/// <para>Specifies how the polygons will be divided.</para>
		/// <para>Strips— Polygons will be divided into strips. This is the default.</para>
		/// <para>Stacked blocks—Polygons will be divided into stacked blocks.</para>
		/// <para><see cref="SubdivisionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SubdivisionType { get; set; } = "STRIPS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SubdividePolygon SetEnviroment(object? parallelProcessingFactor = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Subdivision Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Number of equal parts— Polygons will be divided evenly into a number of parts. This is the default.</para>
			/// </summary>
			[GPValue("NUMBER_OF_EQUAL_PARTS")]
			[Description("Number of equal parts")]
			Number_of_equal_parts,

			/// <summary>
			/// <para>Equal areas—Polygons will be divided into a specified number of parts of a certain area, and a remainder part.</para>
			/// </summary>
			[GPValue("EQUAL_AREAS")]
			[Description("Equal areas")]
			Equal_areas,

		}

		/// <summary>
		/// <para>Subdivision Type</para>
		/// </summary>
		public enum SubdivisionTypeEnum 
		{
			/// <summary>
			/// <para>Strips— Polygons will be divided into strips. This is the default.</para>
			/// </summary>
			[GPValue("STRIPS")]
			[Description("Strips")]
			Strips,

			/// <summary>
			/// <para>Stacked blocks—Polygons will be divided into stacked blocks.</para>
			/// </summary>
			[GPValue("STACKED_BLOCKS")]
			[Description("Stacked blocks")]
			Stacked_blocks,

		}

#endregion
	}
}
