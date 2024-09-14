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
	/// <para>Create Fishnet</para>
	/// <para>Create Fishnet</para>
	/// <para>Creates a fishnet of rectangular cells.  The output can be polyline or polygon features.</para>
	/// </summary>
	public class CreateFishnet : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the fishnet of rectangular cells.</para>
		/// </param>
		/// <param name="OriginCoord">
		/// <para>Fishnet Origin Coordinate</para>
		/// <para>The starting pivot point of the fishnet.</para>
		/// </param>
		/// <param name="YAxisCoord">
		/// <para>Y-Axis Coordinate</para>
		/// <para>The Y-axis coordinate is used to orient the fishnet. The fishnet is rotated by the same angle as defined by the line connecting the origin and the y-axis coordinate.</para>
		/// </param>
		/// <param name="CellWidth">
		/// <para>Cell Size Width</para>
		/// <para>Determines the width of each cell. If you want the width to be automatically calculated using the value in the Number of Rows parameter, leave this parameter empty or set the value to zero—the width will be calculated when the tool is run.</para>
		/// </param>
		/// <param name="CellHeight">
		/// <para>Cell Size Height</para>
		/// <para>Determines the height of each cell. If you want the height to be automatically calculated using the value in the Number of Columns parameter, leave this parameter empty or set the value to zero—the height will be calculated when the tool is run.</para>
		/// </param>
		/// <param name="NumberRows">
		/// <para>Number of Rows</para>
		/// <para>Determines the number of rows the fishnet will have. If you want the number of rows to be automatically calculated using the value in the Cell Size Width parameter, leave this parameter empty or set the value to zero—the number of rows will be calculated when the tool is run.</para>
		/// </param>
		/// <param name="NumberColumns">
		/// <para>Number of Columns</para>
		/// <para>Determines the number of columns the fishnet will have. If you want the number of columns to be automatically calculated using the value in the Cell Size Height parameter, leave this parameter empty or set the value to zero—the number of columns will be calculated when the tool is run.</para>
		/// </param>
		public CreateFishnet(object OutFeatureClass, object OriginCoord, object YAxisCoord, object CellWidth, object CellHeight, object NumberRows, object NumberColumns)
		{
			this.OutFeatureClass = OutFeatureClass;
			this.OriginCoord = OriginCoord;
			this.YAxisCoord = YAxisCoord;
			this.CellWidth = CellWidth;
			this.CellHeight = CellHeight;
			this.NumberRows = NumberRows;
			this.NumberColumns = NumberColumns;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Fishnet</para>
		/// </summary>
		public override string DisplayName() => "Create Fishnet";

		/// <summary>
		/// <para>Tool Name : CreateFishnet</para>
		/// </summary>
		public override string ToolName() => "CreateFishnet";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateFishnet</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateFishnet";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "XYDomain", "ZDomain", "configKeyword", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutFeatureClass, OriginCoord, YAxisCoord, CellWidth, CellHeight, NumberRows, NumberColumns, CornerCoord!, Labels!, Template!, GeometryType!, OutLabel! };

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the fishnet of rectangular cells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		[FeatureType("Simple")]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Fishnet Origin Coordinate</para>
		/// <para>The starting pivot point of the fishnet.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPPoint()]
		public object OriginCoord { get; set; }

		/// <summary>
		/// <para>Y-Axis Coordinate</para>
		/// <para>The Y-axis coordinate is used to orient the fishnet. The fishnet is rotated by the same angle as defined by the line connecting the origin and the y-axis coordinate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPPoint()]
		public object YAxisCoord { get; set; }

		/// <summary>
		/// <para>Cell Size Width</para>
		/// <para>Determines the width of each cell. If you want the width to be automatically calculated using the value in the Number of Rows parameter, leave this parameter empty or set the value to zero—the width will be calculated when the tool is run.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object CellWidth { get; set; }

		/// <summary>
		/// <para>Cell Size Height</para>
		/// <para>Determines the height of each cell. If you want the height to be automatically calculated using the value in the Number of Columns parameter, leave this parameter empty or set the value to zero—the height will be calculated when the tool is run.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object CellHeight { get; set; }

		/// <summary>
		/// <para>Number of Rows</para>
		/// <para>Determines the number of rows the fishnet will have. If you want the number of rows to be automatically calculated using the value in the Cell Size Width parameter, leave this parameter empty or set the value to zero—the number of rows will be calculated when the tool is run.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberRows { get; set; }

		/// <summary>
		/// <para>Number of Columns</para>
		/// <para>Determines the number of columns the fishnet will have. If you want the number of columns to be automatically calculated using the value in the Cell Size Height parameter, leave this parameter empty or set the value to zero—the number of columns will be calculated when the tool is run.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberColumns { get; set; }

		/// <summary>
		/// <para>Opposite corner of Fishnet</para>
		/// <para>The opposite corner of the fishnet set by X-Coordinate and Y-Coordinate values. The values for opposite corner are automatically set if a template extent is used. This parameter becomes disabled if the origin, Y-axis, cell size, and number of rows and columns are set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		public object? CornerCoord { get; set; }

		/// <summary>
		/// <para>Create Label Points</para>
		/// <para>Specifies whether or not a point feature class will be created containing label points at the center of each fishnet cell.</para>
		/// <para>Checked—A new feature class is created with label points. This is the default.</para>
		/// <para>Unchecked—The label points feature class is not created.</para>
		/// <para><see cref="LabelsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Labels { get; set; } = "true";

		/// <summary>
		/// <para>Template Extent</para>
		/// <para>Specify the extent of the fishnet. The extent can be entered by specifying the coordinates or using a template dataset.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? Template { get; set; }

		/// <summary>
		/// <para>Geometry Type</para>
		/// <para>Determines if the output fishnet cells will be polyline or polygon features.</para>
		/// <para>Polyline—Output is a polyline feature class. Each cell is defined by four line features.</para>
		/// <para>Polygon—Output is a polygon feature class. Each cell is defined by one polygon feature.</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? GeometryType { get; set; } = "POLYLINE";

		/// <summary>
		/// <para>Output Label Feature Class (Optional)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutLabel { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateFishnet SetEnviroment(object? MDomain = null, object? XYDomain = null, object? ZDomain = null, object? configKeyword = null, object? extent = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null)
		{
			base.SetEnv(MDomain: MDomain, XYDomain: XYDomain, ZDomain: ZDomain, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Create Label Points</para>
		/// </summary>
		public enum LabelsEnum 
		{
			/// <summary>
			/// <para>Checked—A new feature class is created with label points. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("LABELS")]
			LABELS,

			/// <summary>
			/// <para>Unchecked—The label points feature class is not created.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_LABELS")]
			NO_LABELS,

		}

		/// <summary>
		/// <para>Geometry Type</para>
		/// </summary>
		public enum GeometryTypeEnum 
		{
			/// <summary>
			/// <para>Polyline—Output is a polyline feature class. Each cell is defined by four line features.</para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("Polyline")]
			Polyline,

			/// <summary>
			/// <para>Polygon—Output is a polygon feature class. Each cell is defined by one polygon feature.</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon")]
			Polygon,

		}

#endregion
	}
}
