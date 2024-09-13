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
	/// <para>Create Referenced Mosaic Dataset</para>
	/// <para>Create Referenced Mosaic Dataset</para>
	/// <para>Creates a separate mosaic dataset from items in an existing mosaic dataset.</para>
	/// </summary>
	public class CreateReferencedMosaicDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset from which items will be selected.</para>
		/// </param>
		/// <param name="OutMosaicDataset">
		/// <para>Output Mosaic Dataset</para>
		/// <para>The referenced mosaic dataset to be created.</para>
		/// </param>
		public CreateReferencedMosaicDataset(object InDataset, object OutMosaicDataset)
		{
			this.InDataset = InDataset;
			this.OutMosaicDataset = OutMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Referenced Mosaic Dataset</para>
		/// </summary>
		public override string DisplayName() => "Create Referenced Mosaic Dataset";

		/// <summary>
		/// <para>Tool Name : CreateReferencedMosaicDataset</para>
		/// </summary>
		public override string ToolName() => "CreateReferencedMosaicDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateReferencedMosaicDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateReferencedMosaicDataset";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, OutMosaicDataset, CoordinateSystem!, NumberOfBands!, PixelType!, WhereClause!, InTemplateDataset!, Extent!, SelectUsingFeatures!, LodField!, MinpsField!, MaxpsField!, Pixelsize!, BuildBoundary! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset from which items will be selected.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Mosaic Dataset</para>
		/// <para>The referenced mosaic dataset to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEMosaicDataset()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The projection for the output mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object? CoordinateSystem { get; set; }

		/// <summary>
		/// <para>Number of Bands</para>
		/// <para>The number of bands that the referenced mosaic dataset will have.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Pixel Properties")]
		public object? NumberOfBands { get; set; }

		/// <summary>
		/// <para>Pixel Type</para>
		/// <para>The bit depth, or radiometric resolution, of the mosaic dataset. If this is not defined, it will be taken from the first raster dataset.</para>
		/// <para>1-bit—The pixel type will be a 1-bit unsigned integer. The values can be 0 or 1.</para>
		/// <para>2-bit—The pixel type will be a 2-bit unsigned integer. The values supported can range from 0 to 3.</para>
		/// <para>4-bit—The pixel type will be a 4-bit unsigned integer. The values supported can range from 0 to 15.</para>
		/// <para>8-bit unsigned—The pixel type will be an unsigned 8-bit data type. The values supported can range from 0 to 255.</para>
		/// <para>8-bit signed—The pixel type will be a signed 8-bit data type. The values supported can range from -128 to 127.</para>
		/// <para>16-bit unsigned—The pixel type will be a 16-bit unsigned data type. The values can range from 0 to 65,535.</para>
		/// <para>16-bit signed—The pixel type will be a 16-bit signed data type. The values can range from -32,768 to 32,767.</para>
		/// <para>32-bit unsigned—The pixel type will be a 32-bit unsigned data type. The values can range from 0 to 4,294,967,295.</para>
		/// <para>32-bit signed—The pixel type will be a 32-bit signed data type. The values can range from -2,147,483,648 to 2,147,483,647.</para>
		/// <para>32-bit floating point—The pixel type will be a 32-bit data type supporting decimals.</para>
		/// <para>64-bit—The pixel type will be a 64-bit data type supporting decimals.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Pixel Properties")]
		public object? PixelType { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>An SQL expression to select raster datasets that will be included in the output mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		[Category("Selection")]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Extent from Dataset</para>
		/// <para>Select raster datasets based on the extent of another image or feature class. Raster datasets that lay along the defined extent will be included in the mosaic dataset. To manually input the minimum and maximum coordinates for the extent, use the Extent parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[Category("Selection")]
		public object? InTemplateDataset { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>The minimum and maximum coordinates for the extent. If a dataset is selected in Extent from Dataset, those coordinates will automatically appear here.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEnvelope()]
		[Category("Selection")]
		public object? Extent { get; set; }

		/// <summary>
		/// <para>Using Input Geometry for Selection</para>
		/// <para>Limit the extent to the shape or envelope when a feature class is selected in the Extent from Dataset parameter.</para>
		/// <para>Checked—Select based on the shape of the feature. This is the default.</para>
		/// <para>Unchecked—Select based on the extent of the feature class.</para>
		/// <para><see cref="SelectUsingFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Selection")]
		public object? SelectUsingFeatures { get; set; } = "true";

		/// <summary>
		/// <para>Scale Field</para>
		/// <para>This parameter has been deprecated and is ignored in tool execution. It remains for backward compatibility reasons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		[Category("Visibility")]
		public object? LodField { get; set; }

		/// <summary>
		/// <para>Minimum Cell Size Field</para>
		/// <para>Specify a field from the footprint attribute table that defines the minimum cell size for displaying the mosaic dataset; otherwise, only a footprint will be displayed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		[Category("Visibility")]
		public object? MinpsField { get; set; }

		/// <summary>
		/// <para>Maximum Cell Size Field</para>
		/// <para>Specify a field from the footprint attribute table that defines the maximum cell size for displaying the mosaic dataset; otherwise, only a footprint will be displayed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		[Category("Visibility")]
		public object? MaxpsField { get; set; }

		/// <summary>
		/// <para>Maximum Visible Cell Size</para>
		/// <para>Set a maximum cell size to display the mosaic instead of specifying a field. If you zoom out beyond this cell size, only the footprint will be displayed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Visibility")]
		public object? Pixelsize { get; set; }

		/// <summary>
		/// <para>Build Boundary</para>
		/// <para>Rebuild the boundary. If the selection covers a smaller area than the source mosaic dataset, this is recommended.</para>
		/// <para>This is only available if the mosaic dataset is created in a geodatabase.</para>
		/// <para>Checked—Generate the boundary. This is the default.</para>
		/// <para>Unchecked—Do not generate the boundary.</para>
		/// <para><see cref="BuildBoundaryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? BuildBoundary { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateReferencedMosaicDataset SetEnviroment(object? configKeyword = null , object? extent = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Using Input Geometry for Selection</para>
		/// </summary>
		public enum SelectUsingFeaturesEnum 
		{
			/// <summary>
			/// <para>Checked—Select based on the shape of the feature. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SELECT_USING_FEATURES")]
			SELECT_USING_FEATURES,

			/// <summary>
			/// <para>Unchecked—Select based on the extent of the feature class.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SELECT_USING_FEATURES")]
			NO_SELECT_USING_FEATURES,

		}

		/// <summary>
		/// <para>Build Boundary</para>
		/// </summary>
		public enum BuildBoundaryEnum 
		{
			/// <summary>
			/// <para>Checked—Generate the boundary. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD_BOUNDARY")]
			BUILD_BOUNDARY,

			/// <summary>
			/// <para>Unchecked—Do not generate the boundary.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_BOUNDARY")]
			NO_BOUNDARY,

		}

#endregion
	}
}
