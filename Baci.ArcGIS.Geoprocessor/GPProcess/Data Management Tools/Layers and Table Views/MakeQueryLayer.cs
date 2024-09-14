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
	/// <para>Make Query Layer</para>
	/// <para>Make Query Layer</para>
	/// <para>Creates a query layer  from a DBMS table based on an input SQL select statement.</para>
	/// </summary>
	public class MakeQueryLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>The database connection file that contains the data to be queried.</para>
		/// </param>
		/// <param name="OutLayerName">
		/// <para>Output Layer Name</para>
		/// <para>The output name of the feature layer or table view to be created.</para>
		/// </param>
		/// <param name="Query">
		/// <para>Query</para>
		/// <para>The SQL statement that defines the select query to be executed in the database.</para>
		/// <para>This string must pass validation before remaining controls will be enabled. Validation will be triggered when you click outside this input box. The validation process executes the query in the database and verifies whether the result of the SQL query meets the data modeling standards enforced by ArcGIS. If the validation fails, the tool will return a warning. The only exception is for Model Builder, in which case validation will not be triggered if the input is derived data.</para>
		/// <para>Rules for validation are as follows:</para>
		/// <para>The result of the SQL query must have only one spatial field.</para>
		/// <para>The result of the SQL query must have only one spatial reference.</para>
		/// <para>The result of the SQL query must have only one entity type, such as point, multipoint, line, or polygon.</para>
		/// <para>The result of the SQL query cannot have any field types not supported by ArcGIS; ArcGIS field data types describes the field types supported in ArcGIS.</para>
		/// <para>Validation is especially important when working with data in spatial databases that do not enforce the same standards as ArcGIS.</para>
		/// </param>
		public MakeQueryLayer(object InputDatabase, object OutLayerName, object Query)
		{
			this.InputDatabase = InputDatabase;
			this.OutLayerName = OutLayerName;
			this.Query = Query;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Query Layer</para>
		/// </summary>
		public override string DisplayName() => "Make Query Layer";

		/// <summary>
		/// <para>Tool Name : MakeQueryLayer</para>
		/// </summary>
		public override string ToolName() => "MakeQueryLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeQueryLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeQueryLayer";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputDatabase, OutLayerName, Query, OidFields!, ShapeType!, Srid!, SpatialReference!, OutLayer!, SpatialProperties!, MValues!, ZValues!, Extent! };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>The database connection file that contains the data to be queried.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Output Layer Name</para>
		/// <para>The output name of the feature layer or table view to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutLayerName { get; set; }

		/// <summary>
		/// <para>Query</para>
		/// <para>The SQL statement that defines the select query to be executed in the database.</para>
		/// <para>This string must pass validation before remaining controls will be enabled. Validation will be triggered when you click outside this input box. The validation process executes the query in the database and verifies whether the result of the SQL query meets the data modeling standards enforced by ArcGIS. If the validation fails, the tool will return a warning. The only exception is for Model Builder, in which case validation will not be triggered if the input is derived data.</para>
		/// <para>Rules for validation are as follows:</para>
		/// <para>The result of the SQL query must have only one spatial field.</para>
		/// <para>The result of the SQL query must have only one spatial reference.</para>
		/// <para>The result of the SQL query must have only one entity type, such as point, multipoint, line, or polygon.</para>
		/// <para>The result of the SQL query cannot have any field types not supported by ArcGIS; ArcGIS field data types describes the field types supported in ArcGIS.</para>
		/// <para>Validation is especially important when working with data in spatial databases that do not enforce the same standards as ArcGIS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Query { get; set; }

		/// <summary>
		/// <para>Unique Identifier Field(s)</para>
		/// <para>One or more fields from the SELECT statement SELECT list that will generate a dynamic, unique row identifier.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? OidFields { get; set; }

		/// <summary>
		/// <para>Shape Type</para>
		/// <para>Specifies the shape type of the query layer. Only those records from the result set of the query that match the specified shape type will be used in the output query layer. Tool validation will attempt to set this property based on the first record in the result set. This can be changed before executing the tool if it is not the desired output shape type. This parameter is ignored if the result set of the query does not return a geometry field.</para>
		/// <para>Point—The output query layer will use point geometry.</para>
		/// <para>Multipoint—The output query layer will use multipoint geometry.</para>
		/// <para>Polygon—The output query layer will use polygon geometry.</para>
		/// <para>Polyline—The output query layer will use polyline geometry.</para>
		/// <para><see cref="ShapeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ShapeType { get; set; }

		/// <summary>
		/// <para>SRID</para>
		/// <para>The spatial reference identifier (SRID) value for queries that return geometry. Only those records from the result set of the query that match the specified SRID value will be used in the output query layer. Tool validation will attempt to set this property based on the first record in the result set. This can be changed before executing the tool if it is not the desired output SRID value. This parameter is ignored if the result set of the query does not return a geometry field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Srid { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The coordinate system that will be used by the output query layer. Tool validation will attempt to set this property based on the first record in the result set. This can be changed before executing the tool if it is not the desired output coordinate system. This parameter is ignored if the result set of the query does not return a geometry field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? OutLayer { get; set; }

		/// <summary>
		/// <para>Define the spatial properties of the layer</para>
		/// <para>Specifies how the spatial properties for the layer will be defined.</para>
		/// <para>During the validation process, dimensionality, geometry type, spatial reference, SRID, and unique identifier properties will be set on the query layer. These values are based on the first row returned in the query. To manually define these properties instead of the tool querying the table to get them, the Define spatial properties for the layer parameter is checked by default.</para>
		/// <para>Checked—Manually define the spatial properties of the layer. This is the default.</para>
		/// <para>Unchecked—Layer properties will be determined based on the first row returned in the query.</para>
		/// <para><see cref="SpatialPropertiesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SpatialProperties { get; set; } = "true";

		/// <summary>
		/// <para>Coordinates include M values</para>
		/// <para>Specifies whether the layer will have m-values.</para>
		/// <para>Checked—The layer will have m-values.</para>
		/// <para>Unchecked—The layer will not have m-values. This is the default.</para>
		/// <para><see cref="MValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MValues { get; set; } = "false";

		/// <summary>
		/// <para>Coordinates include Z values</para>
		/// <para>Specifies whether the layer will have z-values.</para>
		/// <para>Checked—The layer will have z-values.</para>
		/// <para>Unchecked—The layer will not have z-values. This is the default.</para>
		/// <para><see cref="ZValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ZValues { get; set; } = "false";

		/// <summary>
		/// <para>Extent</para>
		/// <para>The extent of the layer. This parameter is only used if Define spatial properties for the layer is checked (spatial_properties = DEFINE_SPATIAL_PROPERTIES in Python). The extent must include all features in the table.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? Extent { get; set; } = "0 0 0 0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeQueryLayer SetEnviroment(object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Shape Type</para>
		/// </summary>
		public enum ShapeTypeEnum 
		{
			/// <summary>
			/// <para>Point—The output query layer will use point geometry.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

			/// <summary>
			/// <para>Multipoint—The output query layer will use multipoint geometry.</para>
			/// </summary>
			[GPValue("MULTIPOINT")]
			[Description("Multipoint")]
			Multipoint,

			/// <summary>
			/// <para>Polygon—The output query layer will use polygon geometry.</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon")]
			Polygon,

			/// <summary>
			/// <para>Polyline—The output query layer will use polyline geometry.</para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("Polyline")]
			Polyline,

		}

		/// <summary>
		/// <para>Define the spatial properties of the layer</para>
		/// </summary>
		public enum SpatialPropertiesEnum 
		{
			/// <summary>
			/// <para>Checked—Manually define the spatial properties of the layer. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DEFINE_SPATIAL_PROPERTIES")]
			DEFINE_SPATIAL_PROPERTIES,

			/// <summary>
			/// <para>Unchecked—Layer properties will be determined based on the first row returned in the query.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_DEFINE_SPATIAL_PROPERTIES")]
			DO_NOT_DEFINE_SPATIAL_PROPERTIES,

		}

		/// <summary>
		/// <para>Coordinates include M values</para>
		/// </summary>
		public enum MValuesEnum 
		{
			/// <summary>
			/// <para>Checked—The layer will have m-values.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_M_VALUES")]
			INCLUDE_M_VALUES,

			/// <summary>
			/// <para>Unchecked—The layer will not have m-values. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_INCLUDE_M_VALUES")]
			DO_NOT_INCLUDE_M_VALUES,

		}

		/// <summary>
		/// <para>Coordinates include Z values</para>
		/// </summary>
		public enum ZValuesEnum 
		{
			/// <summary>
			/// <para>Checked—The layer will have z-values.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_Z_VALUES")]
			INCLUDE_Z_VALUES,

			/// <summary>
			/// <para>Unchecked—The layer will not have z-values. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_INCLUDE_Z_VALUES")]
			DO_NOT_INCLUDE_Z_VALUES,

		}

#endregion
	}
}
