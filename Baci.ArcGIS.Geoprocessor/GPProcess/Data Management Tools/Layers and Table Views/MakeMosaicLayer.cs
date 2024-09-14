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
	/// <para>Make Mosaic Layer</para>
	/// <para>Make Mosaic Layer</para>
	/// <para>Creates a  mosaic layer from a mosaic dataset or layer file. The layer that is created by the tool is temporary and will not persist after the session ends unless the layer is saved as a layer file or the map  is saved.</para>
	/// </summary>
	public class MakeMosaicLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The path and name of the input mosaic dataset.</para>
		/// </param>
		/// <param name="OutMosaicLayer">
		/// <para>Output Mosaic Layer</para>
		/// <para>The name of the output mosaic layer.</para>
		/// </param>
		public MakeMosaicLayer(object InMosaicDataset, object OutMosaicLayer)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.OutMosaicLayer = OutMosaicLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Mosaic Layer</para>
		/// </summary>
		public override string DisplayName() => "Make Mosaic Layer";

		/// <summary>
		/// <para>Tool Name : MakeMosaicLayer</para>
		/// </summary>
		public override string ToolName() => "MakeMosaicLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeMosaicLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeMosaicLayer";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, OutMosaicLayer, WhereClause!, Template!, BandIndex!, MosaicMethod!, OrderField!, OrderBaseValue!, LockRasterid!, SortOrder!, MosaicOperator!, CellSize!, ProcessingTemplate! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The path and name of the input mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Output Mosaic Layer</para>
		/// <para>The name of the output mosaic layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object OutMosaicLayer { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>Define a query using SQL or use the Query Builder to build a query.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Template Extent</para>
		/// <para>The output extent can be specified by defining the four coordinates or by using the extent of an existing layer.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? Template { get; set; }

		/// <summary>
		/// <para>Bands</para>
		/// <para>The bands that will be exported for the layer. If no bands are specified, all the bands will be used in the output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? BandIndex { get; set; }

		/// <summary>
		/// <para>Mosaic Method</para>
		/// <para>Choose the mosaic method. The mosaic method defines how the layer is created from different rasters in the mosaic dataset.</para>
		/// <para>Closest to center—Sorts rasters based on an order where rasters that have their center closest to the view center are placed on top.</para>
		/// <para>Northwest—Sorts rasters based on an order where rasters that have their center closest to the northwest are placed on top.</para>
		/// <para>Lock raster—Enables a user to lock the display of single or multiple rasters, based on an ID or name. When you choose this option, you need to specify the Lock Raster ID.</para>
		/// <para>By attribute—Sorts rasters based on an attribute field and its difference from the base value. When this option is chosen, the order field and order base value parameters also need to be set.</para>
		/// <para>Closest to nadir—Sorts rasters based on an order where rasters that have their nadir position closest to the view center are placed on top. The nadir point can be different from the center point, especially in oblique imagery.</para>
		/// <para>Closest to view point—Sorts rasters based on an order where the nadir position is closest to the user-defined viewpoint location and are placed on top.</para>
		/// <para>Seamline—Cuts the rasters using the predefined seamline shape for each raster using optional feathering along the seams. The ordering is predefined during seamline generation. The LAST mosaic operator is not valid with this mosaic method.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Mosaic Properties")]
		public object? MosaicMethod { get; set; }

		/// <summary>
		/// <para>Order Field</para>
		/// <para>Choose the order field. When the mosaic method is By attribute, the default field to use when ordering rasters needs to be set. The list of fields is defined as those in the service table that are of type metadata.</para>
		/// <para>Choose the order field. When the mosaic method is BY_ATTRIBUTE, the default field to use when ordering rasters needs to be set. The list of fields is defined as those in the service table that are of type metadata.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Mosaic Properties")]
		public object? OrderField { get; set; }

		/// <summary>
		/// <para>Order Base Value</para>
		/// <para>The order base value. The images are sorted based on the difference between this value and the attribute value in the specified field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Mosaic Properties")]
		public object? OrderBaseValue { get; set; }

		/// <summary>
		/// <para>Lock Raster ID</para>
		/// <para>The Raster ID or raster name to which the service should be locked so that only the specified rasters are displayed. If left undefined, it will be similar to the system default. Multiple IDs can be defined as a semicolon-delimited list.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Mosaic Properties")]
		public object? LockRasterid { get; set; }

		/// <summary>
		/// <para>Sort Order</para>
		/// <para>Choose whether the sort order is ascending or descending.</para>
		/// <para>Ascending—The sort order will be ascending. This is the default.</para>
		/// <para>Descending—The sort order will be descending.</para>
		/// <para><see cref="SortOrderEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Mosaic Properties")]
		public object? SortOrder { get; set; } = "ASCENDING";

		/// <summary>
		/// <para>Mosaic Operator</para>
		/// <para>Choose the mosaic operator to use. When two or more rasters have the same sort priority, this parameter is used to further refine the sort order.</para>
		/// <para>First—The first raster in the list will be on top. This is the default.</para>
		/// <para>Last—The last raster in the list will be on top.</para>
		/// <para>Minimum—The raster with the lowest value will be on top.</para>
		/// <para>Maximum—The raster with the highest value will be on top.</para>
		/// <para>Mean—The average pixel value will be on top.</para>
		/// <para>Blend—The output cell value will be a blend of values; this blend value relies on an algorithm that is weight based and dependent on the distance from the pixel to the edge within the overlapping area.</para>
		/// <para>Sum—The output cell value will be the aggregate of all overlapping cells.</para>
		/// <para><see cref="MosaicOperatorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Mosaic Properties")]
		public object? MosaicOperator { get; set; } = "FIRST";

		/// <summary>
		/// <para>Output Cell Size</para>
		/// <para>The cell size of the output mosaic layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Processing Template</para>
		/// <para>The raster function processing template that can be applied on the output mosaic layer.</para>
		/// <para>None—No processing template.</para>
		/// <para><see cref="ProcessingTemplateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ProcessingTemplate { get; set; } = "None";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeMosaicLayer SetEnviroment(object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Sort Order</para>
		/// </summary>
		public enum SortOrderEnum 
		{
			/// <summary>
			/// <para>Ascending—The sort order will be ascending. This is the default.</para>
			/// </summary>
			[GPValue("ASCENDING")]
			[Description("Ascending")]
			Ascending,

			/// <summary>
			/// <para>Descending—The sort order will be descending.</para>
			/// </summary>
			[GPValue("DESCENDING")]
			[Description("Descending")]
			Descending,

		}

		/// <summary>
		/// <para>Mosaic Operator</para>
		/// </summary>
		public enum MosaicOperatorEnum 
		{
			/// <summary>
			/// <para>First—The first raster in the list will be on top. This is the default.</para>
			/// </summary>
			[GPValue("FIRST")]
			[Description("First")]
			First,

			/// <summary>
			/// <para>Last—The last raster in the list will be on top.</para>
			/// </summary>
			[GPValue("LAST")]
			[Description("Last")]
			Last,

			/// <summary>
			/// <para>Minimum—The raster with the lowest value will be on top.</para>
			/// </summary>
			[GPValue("MIN")]
			[Description("Minimum")]
			Minimum,

			/// <summary>
			/// <para>Maximum—The raster with the highest value will be on top.</para>
			/// </summary>
			[GPValue("MAX")]
			[Description("Maximum")]
			Maximum,

			/// <summary>
			/// <para>Mean—The average pixel value will be on top.</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Mean")]
			Mean,

			/// <summary>
			/// <para>Blend—The output cell value will be a blend of values; this blend value relies on an algorithm that is weight based and dependent on the distance from the pixel to the edge within the overlapping area.</para>
			/// </summary>
			[GPValue("BLEND")]
			[Description("Blend")]
			Blend,

			/// <summary>
			/// <para>Sum—The output cell value will be the aggregate of all overlapping cells.</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("Sum")]
			Sum,

		}

		/// <summary>
		/// <para>Processing Template</para>
		/// </summary>
		public enum ProcessingTemplateEnum 
		{
			/// <summary>
			/// <para>None—No processing template.</para>
			/// </summary>
			[GPValue("None")]
			[Description("None")]
			None,

		}

#endregion
	}
}
