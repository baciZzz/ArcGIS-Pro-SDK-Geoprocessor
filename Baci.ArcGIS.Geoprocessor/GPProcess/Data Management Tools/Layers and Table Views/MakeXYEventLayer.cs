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
	/// <para>Make XY Event Layer</para>
	/// <para>Creates a new point feature layer based on x- and y-coordinates defined in a table. If the source table contains z-coordinates (elevation values), that field can also be specified in the creation of the event layer. The layer created by this tool is temporary.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.DataManagementTools.XYTableToPoint"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.DataManagementTools.XYTableToPoint))]
	public class MakeXYEventLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Table">
		/// <para>XY Table</para>
		/// <para>The table containing the x- and y-coordinates that define the locations of the point features to create.</para>
		/// </param>
		/// <param name="InXField">
		/// <para>X Field</para>
		/// <para>The field in the input table that contains the x-coordinates (or longitude).</para>
		/// </param>
		/// <param name="InYField">
		/// <para>Y Field</para>
		/// <para>The field in the input table that contains the y-coordinates (or latitude).</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Layer Name</para>
		/// <para>The name of the output point event layer.</para>
		/// </param>
		public MakeXYEventLayer(object Table, object InXField, object InYField, object OutLayer)
		{
			this.Table = Table;
			this.InXField = InXField;
			this.InYField = InYField;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Make XY Event Layer</para>
		/// </summary>
		public override string DisplayName => "Make XY Event Layer";

		/// <summary>
		/// <para>Tool Name : MakeXYEventLayer</para>
		/// </summary>
		public override string ToolName => "MakeXYEventLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeXYEventLayer</para>
		/// </summary>
		public override string ExcuteName => "management.MakeXYEventLayer";

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
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Table, InXField, InYField, OutLayer, SpatialReference!, InZField! };

		/// <summary>
		/// <para>XY Table</para>
		/// <para>The table containing the x- and y-coordinates that define the locations of the point features to create.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object Table { get; set; }

		/// <summary>
		/// <para>X Field</para>
		/// <para>The field in the input table that contains the x-coordinates (or longitude).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object InXField { get; set; }

		/// <summary>
		/// <para>Y Field</para>
		/// <para>The field in the input table that contains the y-coordinates (or latitude).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object InYField { get; set; }

		/// <summary>
		/// <para>Layer Name</para>
		/// <para>The name of the output point event layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>The spatial reference of the coordinates specified in the X Field and Y Field parameters. This will be the output event layer's spatial reference.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Z Field</para>
		/// <para>The field in the input table that contains the z-coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? InZField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeXYEventLayer SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
