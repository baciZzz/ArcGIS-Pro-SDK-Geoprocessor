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
	/// <para>XY Table To Point</para>
	/// <para>Creates a new point feature class based on x-, y-, and z-coordinates from a table.</para>
	/// </summary>
	public class XYTableToPoint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table containing the x- and y-coordinates that define the locations of the point features to create.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class containing the output point features.</para>
		/// </param>
		/// <param name="XField">
		/// <para>X Field</para>
		/// <para>The field in the input table that contains the x-coordinates (or longitude).</para>
		/// </param>
		/// <param name="YField">
		/// <para>Y Field</para>
		/// <para>The field in the input table that contains the y-coordinates (or latitude).</para>
		/// </param>
		public XYTableToPoint(object InTable, object OutFeatureClass, object XField, object YField)
		{
			this.InTable = InTable;
			this.OutFeatureClass = OutFeatureClass;
			this.XField = XField;
			this.YField = YField;
		}

		/// <summary>
		/// <para>Tool Display Name : XY Table To Point</para>
		/// </summary>
		public override string DisplayName => "XY Table To Point";

		/// <summary>
		/// <para>Tool Name : XYTableToPoint</para>
		/// </summary>
		public override string ToolName => "XYTableToPoint";

		/// <summary>
		/// <para>Tool Excute Name : management.XYTableToPoint</para>
		/// </summary>
		public override string ExcuteName => "management.XYTableToPoint";

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
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, OutFeatureClass, XField, YField, ZField, CoordinateSystem };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table containing the x- and y-coordinates that define the locations of the point features to create.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class containing the output point features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>X Field</para>
		/// <para>The field in the input table that contains the x-coordinates (or longitude).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object XField { get; set; }

		/// <summary>
		/// <para>Y Field</para>
		/// <para>The field in the input table that contains the y-coordinates (or latitude).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object YField { get; set; }

		/// <summary>
		/// <para>Z Field</para>
		/// <para>The field in the input table that contains the z-coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object ZField { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The coordinate system of the x- and y-coordinates. This will be the coordinate system of the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object CoordinateSystem { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public XYTableToPoint SetEnviroment(object extent = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

	}
}
