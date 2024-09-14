using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>Iterate Layers</para>
	/// <para>Iterate Layers</para>
	/// <para>Iterates layers in a map.</para>
	/// </summary>
	public class IterateLayers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputMap">
		/// <para>Input Map</para>
		/// <para>The input map with the layers to iterate.</para>
		/// </param>
		public IterateLayers(object InputMap)
		{
			this.InputMap = InputMap;
		}

		/// <summary>
		/// <para>Tool Display Name : Iterate Layers</para>
		/// </summary>
		public override string DisplayName() => "Iterate Layers";

		/// <summary>
		/// <para>Tool Name : IterateLayers</para>
		/// </summary>
		public override string ToolName() => "IterateLayers";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateLayers</para>
		/// </summary>
		public override string ExcuteName() => "mb.IterateLayers";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise() => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputMap, Wildcard!, LayerType!, WorkspaceType!, FeatureType!, RasterFormatType!, LayerVisibility!, LayerState!, Recursive!, OutputLayer!, OutputName!, OutputLayerType!, OutputWorkspaceType! };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>The input map with the layers to iterate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InputMap { get; set; }

		/// <summary>
		/// <para>Wildcard</para>
		/// <para>A combination of * and characters that help to limit the results. The asterisk is the same as specifying ALL. If no wildcard is specified, all inputs will be returned. For example, it can be used to restrict Iteration over input names starting with a certain character or word (for example, A* or Ari* or Land* and so on).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Wildcard { get; set; }

		/// <summary>
		/// <para>Layer Type</para>
		/// <para>Specifies the layer type that will be used to filter the layers. If a layer type is not specified, all supported layer types will be iterated. More than one layer type can be used to filter the layers.</para>
		/// <para>Annotation Layer—Annotation layers will be iterated.</para>
		/// <para>Building Layer—Building layers will be iterated.</para>
		/// <para>Building Scene Layer— Building scene layers will be iterated.</para>
		/// <para>Dimension Layer—Dimension layers will be iterated.</para>
		/// <para>Feature Layer—Feature layers will be iterated.</para>
		/// <para>Geostatistical Analyst Layer—Geostatistical layers will be iterated.</para>
		/// <para>Group Layer—Group layers will be iterated.</para>
		/// <para>Subtype Group Layer—Subtype group layers will be iterated.</para>
		/// <para>KML Layer—KML layers will be iterated.</para>
		/// <para>LAS Dataset Layer—LAS dataset layers will be iterated.</para>
		/// <para>Mosaic Layer—Mosaic layers will be iterated.</para>
		/// <para>Network Analyst Layer—Network Analyst layers will be iterated.</para>
		/// <para>Network Dataset Layer—Network dataset layers will be iterated.</para>
		/// <para>Parcel Layer—Parcel layers will be iterated.</para>
		/// <para>Raster Layer—Raster layers will be iterated.</para>
		/// <para>Scene Service Layer—Scene service layers will be iterated.</para>
		/// <para>Table View—Table views will be iterated.</para>
		/// <para>Terrain Layer—Terrain layers will be iterated.</para>
		/// <para>TIN Layer—TIN layers will be iterated.</para>
		/// <para>Topology Layer—Topology layers will be iterated.</para>
		/// <para>Trace Network Layer—Trace network layers will be iterated.</para>
		/// <para>Utility Network Layer—Utility network layers will be iterated.</para>
		/// <para>Voxel Layer—Voxel layers will be iterated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? LayerType { get; set; }

		/// <summary>
		/// <para>Workspace Type</para>
		/// <para>Specifies the workspace type that will be used to filter the layers. If a workspace type is not specified, all layers of the supported workspace types will be iterated.</para>
		/// <para>The Workspace Type parameter is only enabled when the Layer Type parameter is set to Feature Layer, Raster Layer, or Table View.</para>
		/// <para>Multifle Feature Connection—Layers in a multifile feature connection workspace will be iterated.</para>
		/// <para>BIM File—Layers in a BIM File workspace will be iterated.</para>
		/// <para>CAD—Layers in a CAD workspace will be iterated.</para>
		/// <para>Delimited Text File—Layers in a delimited text file workspace will be iterated.</para>
		/// <para>Enterprise Geodatabase—Layers in a enterprise geodatabase workspace will be iterated.</para>
		/// <para>Feature Service—Layers in a feature service workspace will be iterated.</para>
		/// <para>File Geodatabase—Layers in a file geodatabase workspace will be iterated.</para>
		/// <para>In Memory Database—Layers in an in memory database workspace will be iterated.</para>
		/// <para>Microsoft Excel—Layers in a Microsoft Excel workspace will be iterated.</para>
		/// <para>NetCDF—Layers in a NetCDF workspace will be iterated.</para>
		/// <para>OLE DB—Layers in a OLE DB workspace will be iterated.</para>
		/// <para>Raster—Layers in a raster workspace will be iterated.</para>
		/// <para>Shapefile—Layers in a shapefile workspace will be iterated.</para>
		/// <para>SQLite—Layers in an SQLite workspace will be iterated.</para>
		/// <para>SQL Query Layer—Layers in a SQL query layer workspace will be iterated.</para>
		/// <para>Stream Service—Layers in a stream service workspace will be iterated.</para>
		/// <para>Web Feature Service—Layers in a web feature service workspace will be iterated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? WorkspaceType { get; set; }

		/// <summary>
		/// <para>Feature Type</para>
		/// <para>Specifies the feature type that will be used to filter the layers. If a feature type is not specified, all supported feature types will be iterated.</para>
		/// <para>Annotation—Annotation feature classes will be iterated.</para>
		/// <para>Dimension—Dimension feature classes will be iterated.</para>
		/// <para>Simple Edge—Simple edge feature classes will be iterated.</para>
		/// <para>Complex Edge—Complex edge feature classes will be iterated.</para>
		/// <para>Simple Junction—Simple junction feature classes will be iterated.</para>
		/// <para>Complex Junction—Complex junction feature classes will be iterated.</para>
		/// <para>Line—Line feature classes will be iterated.</para>
		/// <para>Point—Point feature classes will be iterated.</para>
		/// <para>Polygon—Polygon feature classes will be iterated.</para>
		/// <para>Multipatch—Multipatch feature classes will be iterated.</para>
		/// <para><see cref="FeatureTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? FeatureType { get; set; }

		/// <summary>
		/// <para>Raster Type</para>
		/// <para>The raster format type that will be used to filter the raster layers when the Workspace Type parameter is set to Raster. If a raster type is not specified, all layers of the supported raster types will be iterated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? RasterFormatType { get; set; }

		/// <summary>
		/// <para>Visibility</para>
		/// <para>Specifies whether layer visibility will be used to filter the layers.</para>
		/// <para>All—Layer visibility will not be used to filter layers.</para>
		/// <para>Visible—Visible layers will be iterated.</para>
		/// <para>Not Visible—Nonvisible layers will be iterated.</para>
		/// <para><see cref="LayerVisibilityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Layer Properties")]
		public object? LayerVisibility { get; set; } = "ALL";

		/// <summary>
		/// <para>State</para>
		/// <para>Specifies the layer state that will be used to filter the layers. Layers with broken source path layers will be returned if the parameter is set to invalid.</para>
		/// <para>All—Layer state will not be used to filter layers.</para>
		/// <para>Valid—Valid layers will be iterated.</para>
		/// <para>Invalid—Invalid layers will be iterated.</para>
		/// <para><see cref="LayerStateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Layer Properties")]
		public object? LayerState { get; set; } = "ALL";

		/// <summary>
		/// <para>Recursive</para>
		/// <para>Specifies whether the iterator will iterate nested group layers.</para>
		/// <para>Checked—Nested group layers will be iterated.</para>
		/// <para>Unchecked—Nested group layers will not be iterated.</para>
		/// <para><see cref="RecursiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Recursive { get; set; } = "true";

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPType()]
		public object? OutputLayer { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutputName { get; set; }

		/// <summary>
		/// <para>Output Layer Type</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutputLayerType { get; set; }

		/// <summary>
		/// <para>Workspace or Format Type</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutputWorkspaceType { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Feature Type</para>
		/// </summary>
		public enum FeatureTypeEnum 
		{
			/// <summary>
			/// <para>Annotation—Annotation feature classes will be iterated.</para>
			/// </summary>
			[GPValue("ANNOTATION")]
			[Description("Annotation")]
			Annotation,

			/// <summary>
			/// <para>Dimension—Dimension feature classes will be iterated.</para>
			/// </summary>
			[GPValue("DIMENSION")]
			[Description("Dimension")]
			Dimension,

			/// <summary>
			/// <para>Simple Edge—Simple edge feature classes will be iterated.</para>
			/// </summary>
			[GPValue("SIMPLE_EDGE")]
			[Description("Simple Edge")]
			Simple_Edge,

			/// <summary>
			/// <para>Complex Edge—Complex edge feature classes will be iterated.</para>
			/// </summary>
			[GPValue("COMPLEX_EDGE")]
			[Description("Complex Edge")]
			Complex_Edge,

			/// <summary>
			/// <para>Simple Junction—Simple junction feature classes will be iterated.</para>
			/// </summary>
			[GPValue("SIMPLE_JUNCTION")]
			[Description("Simple Junction")]
			Simple_Junction,

			/// <summary>
			/// <para>Complex Junction—Complex junction feature classes will be iterated.</para>
			/// </summary>
			[GPValue("COMPLEX_JUNCTION")]
			[Description("Complex Junction")]
			Complex_Junction,

			/// <summary>
			/// <para>Line—Line feature classes will be iterated.</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("Line")]
			Line,

			/// <summary>
			/// <para>Point—Point feature classes will be iterated.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

			/// <summary>
			/// <para>Polygon—Polygon feature classes will be iterated.</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon")]
			Polygon,

			/// <summary>
			/// <para>Multipatch—Multipatch feature classes will be iterated.</para>
			/// </summary>
			[GPValue("MULTIPATCH")]
			[Description("Multipatch")]
			Multipatch,

		}

		/// <summary>
		/// <para>Visibility</para>
		/// </summary>
		public enum LayerVisibilityEnum 
		{
			/// <summary>
			/// <para>All—Layer visibility will not be used to filter layers.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>Visible—Visible layers will be iterated.</para>
			/// </summary>
			[GPValue("VISIBLE")]
			[Description("Visible")]
			Visible,

			/// <summary>
			/// <para>Not Visible—Nonvisible layers will be iterated.</para>
			/// </summary>
			[GPValue("NOT_VISIBLE")]
			[Description("Not Visible")]
			Not_Visible,

		}

		/// <summary>
		/// <para>State</para>
		/// </summary>
		public enum LayerStateEnum 
		{
			/// <summary>
			/// <para>All—Layer state will not be used to filter layers.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>Valid—Valid layers will be iterated.</para>
			/// </summary>
			[GPValue("VALID")]
			[Description("Valid")]
			Valid,

			/// <summary>
			/// <para>Invalid—Invalid layers will be iterated.</para>
			/// </summary>
			[GPValue("INVALID")]
			[Description("Invalid")]
			Invalid,

		}

		/// <summary>
		/// <para>Recursive</para>
		/// </summary>
		public enum RecursiveEnum 
		{
			/// <summary>
			/// <para>Checked—Nested group layers will be iterated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RECURSIVE")]
			RECURSIVE,

			/// <summary>
			/// <para>Unchecked—Nested group layers will not be iterated.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_RECURSIVE")]
			NOT_RECURSIVE,

		}

#endregion
	}
}
