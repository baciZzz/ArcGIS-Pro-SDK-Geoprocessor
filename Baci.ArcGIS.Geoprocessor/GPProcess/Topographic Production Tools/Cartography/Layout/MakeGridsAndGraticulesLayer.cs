using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Make Grids And Graticules Layer</para>
	/// <para>Creates a grouped layer of feature classes depicting grid, graticule, and border features using predefined cartographic specifications. Grid layers are ideal for advanced grid definitions that are scale and extent specific.</para>
	/// </summary>
	public class MakeGridsAndGraticulesLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGridXml">
		/// <para>Grid Template (XML file)</para>
		/// <para>The XML grid definition template that stores the specification's graphic properties for each grid layer. In addition to the graphic properties, which cannot be altered before execution, the definition has specific default values, exposed as parameters, that can be modified before execution.</para>
		/// </param>
		/// <param name="AreaOfInterest">
		/// <para>Input Area of Interest [feature or extent]</para>
		/// <para>The polygon feature layer or geographic extent used to determine the area over which the grid features are created.</para>
		/// </param>
		/// <param name="TargetFeatureDataset">
		/// <para>Target Feature Dataset</para>
		/// <para>The feature dataset that will store the grid features. Grid-specific feature classes will be created if they do not already exist. If they already exist, and a grid with the same name and type as the one being created also exists, it will be overwritten.</para>
		/// </param>
		/// <param name="OutLayerName">
		/// <para>Output Layer Name</para>
		/// <para>The name of the group layer that will be created to contain the symbolized grid and graticule feature classes. The group layer can be composed of the following layers for grid elements:</para>
		/// <para>Mask (polygon)</para>
		/// <para>Clip (polygon)</para>
		/// <para>Segments (line)</para>
		/// <para>Gridlines (line)</para>
		/// <para>Ticks (line)</para>
		/// <para>Endpoints (point)</para>
		/// <para>Points (point)</para>
		/// <para>Annotation</para>
		/// <para>This is a temporary layer that you must save in the project or as a layer file.</para>
		/// </param>
		public MakeGridsAndGraticulesLayer(object InGridXml, object AreaOfInterest, object TargetFeatureDataset, object OutLayerName)
		{
			this.InGridXml = InGridXml;
			this.AreaOfInterest = AreaOfInterest;
			this.TargetFeatureDataset = TargetFeatureDataset;
			this.OutLayerName = OutLayerName;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Grids And Graticules Layer</para>
		/// </summary>
		public override string DisplayName => "Make Grids And Graticules Layer";

		/// <summary>
		/// <para>Tool Name : MakeGridsAndGraticulesLayer</para>
		/// </summary>
		public override string ToolName => "MakeGridsAndGraticulesLayer";

		/// <summary>
		/// <para>Tool Excute Name : topographic.MakeGridsAndGraticulesLayer</para>
		/// </summary>
		public override string ExcuteName => "topographic.MakeGridsAndGraticulesLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cartographicCoordinateSystem", "configKeyword", "outputMFlag", "outputZFlag", "referenceScale" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InGridXml, AreaOfInterest, TargetFeatureDataset, OutLayerName, GridName!, ConfigureLayout!, Layout!, MapFrame!, ReferenceScale!, Rotation!, MaskSize!, XyTolerance!, PrimaryCoordinateSystem!, AncillaryCoordinateSystem1!, AncillaryCoordinateSystem2!, AncillaryCoordinateSystem3!, AncillaryCoordinateSystem4! };

		/// <summary>
		/// <para>Grid Template (XML file)</para>
		/// <para>The XML grid definition template that stores the specification's graphic properties for each grid layer. In addition to the graphic properties, which cannot be altered before execution, the definition has specific default values, exposed as parameters, that can be modified before execution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object InGridXml { get; set; }

		/// <summary>
		/// <para>Input Area of Interest [feature or extent]</para>
		/// <para>The polygon feature layer or geographic extent used to determine the area over which the grid features are created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Target Feature Dataset</para>
		/// <para>The feature dataset that will store the grid features. Grid-specific feature classes will be created if they do not already exist. If they already exist, and a grid with the same name and type as the one being created also exists, it will be overwritten.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object TargetFeatureDataset { get; set; }

		/// <summary>
		/// <para>Output Layer Name</para>
		/// <para>The name of the group layer that will be created to contain the symbolized grid and graticule feature classes. The group layer can be composed of the following layers for grid elements:</para>
		/// <para>Mask (polygon)</para>
		/// <para>Clip (polygon)</para>
		/// <para>Segments (line)</para>
		/// <para>Gridlines (line)</para>
		/// <para>Ticks (line)</para>
		/// <para>Endpoints (point)</para>
		/// <para>Points (point)</para>
		/// <para>Annotation</para>
		/// <para>This is a temporary layer that you must save in the project or as a layer file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGroupLayer()]
		public object OutLayerName { get; set; }

		/// <summary>
		/// <para>Grid Name [value or field]</para>
		/// <para>The name used to uniquely identify the grid. You can use a unique name for the grid or choose a field from the input area of interest feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? GridName { get; set; }

		/// <summary>
		/// <para>Configure map frame and layout using grid settings</para>
		/// <para>Adjusts the map, map frame, and layout settings to ensure they match the grid layer. The map’s coordinate system as well as the map frame&apos;s scale, rotation, size, and extent can be altered to enforce consistency. This setting requires that a map frame is chosen from the Map Frame parameter.</para>
		/// <para>Checked—The data frame and layout are configured using grid settings.</para>
		/// <para>Unchecked—The data frame and layout are not configured. This is the default</para>
		/// <para><see cref="ConfigureLayoutEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ConfigureLayout { get; set; } = "false";

		/// <summary>
		/// <para>Layout</para>
		/// <para>The layout that contains the map frame to which the grid will be added when the Configure map frame and layout using grid settings check box is checked. The layout can be in the current project or from an existing layout file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLayout()]
		public object? Layout { get; set; }

		/// <summary>
		/// <para>Map Frame</para>
		/// <para>The map frame that will be updated. The map associated with the map frame can also be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MapFrame { get; set; }

		/// <summary>
		/// <para>Reference Scale</para>
		/// <para>The scale at which the grid is created and should be viewed. When the reference scale from the XML grid definition file is defined as Use Environment, the reference scale is derived in the following order:</para>
		/// <para>The geoprocessing Reference Scale environment setting</para>
		/// <para>The active data frame&apos;s reference scale</para>
		/// <para>The active data frame&apos;s scale</para>
		/// <para>The value from the XML grid definition file</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Advanced Settings (optional)")]
		public object? ReferenceScale { get; set; }

		/// <summary>
		/// <para>Rotation</para>
		/// <para>The rotation angle for the grid components. Rotation is used to create annotation features that are aligned with the page. Unless otherwise specified, rotation is calculated using the area of interest feature. When the rotation type from the XML grid definition file is defined as Use Environment, the rotation is derived in the following order:</para>
		/// <para>The active data frame&apos;s rotation</para>
		/// <para>The value from the XML grid definition file</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced Settings (optional)")]
		public object? Rotation { get; set; }

		/// <summary>
		/// <para>Mask Size</para>
		/// <para>The mask is a polygon feature that forms an outer ring around the extent of the neatline and is used to mask data that falls in the area reserved for coordinate labels. Mask size defines the width of the polygon mask feature in map or page units. The data frame may need to be resized to fit around the edge of the mask while including the coordinate labels.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Advanced Settings (optional)")]
		public object? MaskSize { get; set; }

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>The minimum distance between geodatabase features, expressed in linear units. This value defaults to the value set in the grid XML. You can set higher values for data with less coordinate accuracy and lower values for data with extremely high accuracy. Features that fall within the set x,y tolerance will be considered coincident.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Advanced Settings (optional)")]
		public object? XyTolerance { get; set; }

		/// <summary>
		/// <para>Primary Coordinate System</para>
		/// <para>The primary coordinate system used to create grid features. The final product or data frame should use the same coordinate system. This coordinate system must be a projected coordinate system.</para>
		/// <para>When the primary coordinate system in the XML grid definition file is defined as Use Environment, the default primary coordinate system is derived in the following order:</para>
		/// <para>The geoprocessing Cartographic Coordinate System environment setting</para>
		/// <para>The active data frame&apos;s coordinate system if it is a projected coordinate system</para>
		/// <para>The Fixed value from the XML grid definition file</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		[Category("Advanced Settings (optional)")]
		public object? PrimaryCoordinateSystem { get; set; }

		/// <summary>
		/// <para>Ancillary Coordinate System 1</para>
		/// <para>The first of up to four ancillary coordinate systems used to create grid features. The grid template XML file specifies the number of ancillary grids.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		[Category("Advanced Settings (optional)")]
		public object? AncillaryCoordinateSystem1 { get; set; }

		/// <summary>
		/// <para>Ancillary Coordinate System 2</para>
		/// <para>The second of up to four ancillary coordinate systems used to create grid features. The grid template XML file specifies the number of ancillary grids.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		[Category("Advanced Settings (optional)")]
		public object? AncillaryCoordinateSystem2 { get; set; }

		/// <summary>
		/// <para>Ancillary Coordinate System 3</para>
		/// <para>The third of up to four ancillary coordinate systems used to create grid features. The grid template XML file specifies the number of ancillary grids.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		[Category("Advanced Settings (optional)")]
		public object? AncillaryCoordinateSystem3 { get; set; }

		/// <summary>
		/// <para>Ancillary Coordinate System 4</para>
		/// <para>The fourth of up to four ancillary coordinate systems used to create grid features. The grid template XML file specifies the number of ancillary grids.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		[Category("Advanced Settings (optional)")]
		public object? AncillaryCoordinateSystem4 { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeGridsAndGraticulesLayer SetEnviroment(object? cartographicCoordinateSystem = null , object? configKeyword = null , object? outputMFlag = null , object? outputZFlag = null , double? referenceScale = null )
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, configKeyword: configKeyword, outputMFlag: outputMFlag, outputZFlag: outputZFlag, referenceScale: referenceScale);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Configure map frame and layout using grid settings</para>
		/// </summary>
		public enum ConfigureLayoutEnum 
		{
			/// <summary>
			/// <para>Checked—The data frame and layout are configured using grid settings.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CONFIGURE_LAYOUT")]
			CONFIGURE_LAYOUT,

			/// <summary>
			/// <para>Unchecked—The data frame and layout are not configured. This is the default</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CONFIGURE_LAYOUT")]
			NO_CONFIGURE_LAYOUT,

		}

#endregion
	}
}
