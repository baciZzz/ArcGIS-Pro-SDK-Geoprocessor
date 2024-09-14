using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Export Training Data For Deep Learning</para>
	/// <para>Export Training Data For Deep Learning</para>
	/// <para>Converts labeled vector or raster data into deep learning training datasets using a remote sensing image. The output will be a folder of image chips and a folder of metadata files in the specified format.</para>
	/// </summary>
	public class ExportTrainingDataForDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The input source imagery, typically multispectral imagery.</para>
		/// <para>Examples of the types of input source imagery include multispectral satellite, drone, aerial, and National Agriculture Imagery Program (NAIP). The input can be a folder of images.</para>
		/// </param>
		/// <param name="OutFolder">
		/// <para>Output Folder</para>
		/// <para>The folder where the output image chips and metadata will be stored.</para>
		/// <para>The folder can also be a folder URL that uses a cloud storage connection file (*.acs).</para>
		/// </param>
		public ExportTrainingDataForDeepLearning(object InRaster, object OutFolder)
		{
			this.InRaster = InRaster;
			this.OutFolder = OutFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Training Data For Deep Learning</para>
		/// </summary>
		public override string DisplayName() => "Export Training Data For Deep Learning";

		/// <summary>
		/// <para>Tool Name : ExportTrainingDataForDeepLearning</para>
		/// </summary>
		public override string ToolName() => "ExportTrainingDataForDeepLearning";

		/// <summary>
		/// <para>Tool Excute Name : sa.ExportTrainingDataForDeepLearning</para>
		/// </summary>
		public override string ExcuteName() => "sa.ExportTrainingDataForDeepLearning";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutFolder, InClassData, ImageChipFormat, TileSizeX, TileSizeY, StrideX, StrideY, OutputNofeatureTiles, MetadataFormat, StartIndex, ClassValueField, BufferRadius, InMaskPolygons, RotationAngle, ReferenceSystem, ProcessingMode, BlackenAroundFeature, CropMode, InRaster2 };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The input source imagery, typically multispectral imagery.</para>
		/// <para>Examples of the types of input source imagery include multispectral satellite, drone, aerial, and National Agriculture Imagery Program (NAIP). The input can be a folder of images.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>The folder where the output image chips and metadata will be stored.</para>
		/// <para>The folder can also be a folder URL that uses a cloud storage connection file (*.acs).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Input Feature Class Or Classified Raster Or Table</para>
		/// <para>The training sample data in either vector or raster form.</para>
		/// <para>Vector inputs should follow the training sample format generated using the Training Samples Manager pane. Raster inputs should follow a classified raster format generated by the Classify Raster tool. The raster input can also be from a folder of classified rasters. Input tables should follow a training sample format generated by the Label Objects for Deep Learning tool in the Training Samples Manager pane. Following the proper training sample format will produce optimal results with the statistical information; however, the input can also be a point feature class without a class value field or an integer raster without any class information.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object InClassData { get; set; }

		/// <summary>
		/// <para>Image Format</para>
		/// <para>Specifies the raster format that will be used for the image chip outputs.</para>
		/// <para>The PNG and JPEG formats support up to three bands.</para>
		/// <para>TIFF format—TIFF format will be used.</para>
		/// <para>PNG format—PNG format will be used.</para>
		/// <para>JPEG format—JPEG format will be used.</para>
		/// <para>MRF (Meta Raster Format)—Meta Raster Format (MRF) will be used.</para>
		/// <para><see cref="ImageChipFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ImageChipFormat { get; set; } = "TIFF";

		/// <summary>
		/// <para>Tile Size X</para>
		/// <para>The size of the image chips for the x dimension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object TileSizeX { get; set; } = "256";

		/// <summary>
		/// <para>Tile Size Y</para>
		/// <para>The size of the image chips for the y dimension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object TileSizeY { get; set; } = "256";

		/// <summary>
		/// <para>Stride X</para>
		/// <para>The distance to move in the x direction when creating the next image chips.</para>
		/// <para>When stride is equal to tile size, there will be no overlap. When stride is equal to half the tile size, there will be 50 percent overlap.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object StrideX { get; set; } = "128";

		/// <summary>
		/// <para>Stride Y</para>
		/// <para>The distance to move in the y direction when creating the next image chips.</para>
		/// <para>When stride is equal to tile size, there will be no overlap. When stride is equal to half the tile size, there will be 50 percent overlap.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object StrideY { get; set; } = "128";

		/// <summary>
		/// <para>Output No Feature Tiles</para>
		/// <para>Specifies whether image chips that do not capture training samples will be exported.</para>
		/// <para>Checked—All image chips, including those that do not capture training samples, will be exported.</para>
		/// <para>Unchecked—Only image chips that capture training samples will be exported. This is the default.</para>
		/// <para>If checked, image chips that do not capture labeled data will also be exported; if not checked, they will not be exported.</para>
		/// <para><see cref="OutputNofeatureTilesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object OutputNofeatureTiles { get; set; } = "false";

		/// <summary>
		/// <para>Metadata Format</para>
		/// <para>Specifies the format of the output metadata labels.</para>
		/// <para>If the input training sample data is a feature class layer, such as a building layer or a standard classification training sample file, use the KITTI Labels or PASCAL Visual Object Classes option (KITTI_rectangles or PASCAL_VOC_rectangles in Python). The output metadata is a .txt file or an .xml file containing the training sample data contained in the minimum bounding rectangle. The name of the metadata file matches the input source image name. If the input training sample data is a class map, use the Classified Tiles option (Classified_Tiles in Python) as the output metadata format.</para>
		/// <para>KITTI Labels—The metadata follows the same format as the Karlsruhe Institute of Technology and Toyota Technological Institute (KITTI) Object Detection Evaluation dataset. The KITTI dataset is a vision benchmark suite. The label files are plain text files. All values, both numerical and strings, are separated by spaces, and each row corresponds to one object.This format is used for object detection.</para>
		/// <para>PASCAL Visual Object Classes—The metadata follows the same format as the Pattern Analysis, Statistical Modeling and Computational Learning, Visual Object Classes (PASCAL_VOC) dataset. The PASCAL VOC dataset is a standardized image dataset for object class recognition. The label files are in XML format and contain information about image name, class value, and bounding boxes.This format is used for object detection. This is the default.</para>
		/// <para>Classified Tiles—The output will be one classified image chip per input image chip. No other metadata for each image chip is used. Only the statistics output has more information on the classes, such as class names, class values, and output statistics.This format is primarily used for pixel classification. This format is also used for change detection when the output is one classified image chip from two image chips.</para>
		/// <para>RCNN Masks—The output will be image chips that have a mask on the areas where the sample exists. The model generates bounding boxes and segmentation masks for each instance of an object in the image. This format is based on Feature Pyramid Network (FPN) and a ResNet101 backbone in the deep learning framework model.This format is used for object detection.</para>
		/// <para>Labeled Tiles—Each output tile will be labeled with a specific class.This format is used for object classification.</para>
		/// <para>Multi-labeled Tiles—Each output tile will be labeled with one or more classes. For example, a tile may be labeled agriculture and also cloudy.This format is used for object classification.</para>
		/// <para>Export Tiles—The output will be image chips with no label.This format is used for image translation techniques, such as Pix2Pix and Super Resolution.</para>
		/// <para>CycleGAN—The output will be image chips with no label. This format is used for image translation technique CycleGAN, which is used to train images that do not overlap.</para>
		/// <para>For the KITTI metadata format, 15 columns are created, but only 5 of them are used in the tool. The first column is the class value. The next 3 columns are skipped. Columns 5 through 8 define the minimum bounding rectangle, which is composed of four image coordinate locations: left, top, right, and bottom pixels. The minimum bounding rectangle encompasses the training chip used in the deep learning classifier. The remaining columns are not used.</para>
		/// <para><see cref="MetadataFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MetadataFormat { get; set; } = "PASCAL_VOC_rectangles";

		/// <summary>
		/// <para>Start Index</para>
		/// <para>This parameter has been deprecated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object StartIndex { get; set; } = "0";

		/// <summary>
		/// <para>Class Value Field</para>
		/// <para>The field that contains the class values. If no field is specified, the system searches for a value or classvalue field. If the feature does not contain a class field, the system determines that all records belong to one class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object ClassValueField { get; set; }

		/// <summary>
		/// <para>Buffer Radius</para>
		/// <para>The radius for a buffer around each training sample to delineate a training sample area. This allows you to create circular polygon training samples from points.</para>
		/// <para>The linear unit of the Input Feature Class Or Classified Raster spatial reference is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object BufferRadius { get; set; } = "0";

		/// <summary>
		/// <para>Input Mask Polygons</para>
		/// <para>A polygon feature class that delineates the area where image chips will be created.</para>
		/// <para>Only image chips that fall completely within the polygons will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object InMaskPolygons { get; set; }

		/// <summary>
		/// <para>Rotation Angle</para>
		/// <para>The rotation angle that will be used to generate additional image chips.</para>
		/// <para>An image chip will be generated with a rotation angle of 0, which means no rotation. It will then be rotated at the specified angle to create an additional image chip. The same training samples will be captured at multiple angles in multiple image chips for data augmentation.</para>
		/// <para>The default rotation angle is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object RotationAngle { get; set; } = "0";

		/// <summary>
		/// <para>Reference System</para>
		/// <para>Specifies the type of reference system that will be used to interpret the input image. The reference system specified must match the reference system used to train the deep learning model.</para>
		/// <para>Map space—A map-based coordinate system will be used. This is the default.</para>
		/// <para>Pixel space—Image space will be used, with no rotation and no distortion.</para>
		/// <para><see cref="ReferenceSystemEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ReferenceSystem { get; set; } = "MAP_SPACE";

		/// <summary>
		/// <para>Processing Mode</para>
		/// <para>Specifies how all raster items in a mosaic dataset or an image service will be processed. This parameter is applied when the input raster is a mosaic dataset or an image service.</para>
		/// <para>Process as mosaicked image—All raster items in the mosaic dataset or image service will be mosaicked together and processed. This is the default.</para>
		/// <para>Process all raster items separately—All raster items in the mosaic dataset or image service will be processed as separate images.</para>
		/// <para><see cref="ProcessingModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ProcessingMode { get; set; } = "PROCESS_AS_MOSAICKED_IMAGE";

		/// <summary>
		/// <para>Blacken Around Feature</para>
		/// <para>Specifies whether the pixels around each object or feature in each image tile will be masked out.</para>
		/// <para>This parameter only applies when the metadata format is set to Labeled Tiles and an input feature class or classified raster has been specified.</para>
		/// <para>Unchecked—Pixels surrounding objects or features will not be masked out. This is the default.</para>
		/// <para>Checked—Pixels surrounding objects or features will be masked out.</para>
		/// <para><see cref="BlackenAroundFeatureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object BlackenAroundFeature { get; set; } = "false";

		/// <summary>
		/// <para>Crop Mode</para>
		/// <para>Specifies whether the exported tiles will be cropped so that they are all the same size.</para>
		/// <para>This parameter only applies when the metadata format is set to Labeled Tiles and an input feature class or classified raster has been specified.</para>
		/// <para>Fixed size—Exported tiles will be cropped to the same size and will center on the feature. This is the default.</para>
		/// <para>Bounding box—Exported tiles will be cropped so that the bounding geometry surrounds only the feature in the tile.</para>
		/// <para><see cref="CropModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CropMode { get; set; } = "FIXED_SIZE";

		/// <summary>
		/// <para>Additional Input Raster</para>
		/// <para>An additional input imagery source for image translation methods.</para>
		/// <para>This parameter is valid when the Metadata Format parameter is set to Classified Tiles, Export Tiles, or CycleGAN.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object InRaster2 { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportTrainingDataForDeepLearning SetEnviroment(object cellSize = null, object extent = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Image Format</para>
		/// </summary>
		public enum ImageChipFormatEnum 
		{
			/// <summary>
			/// <para>TIFF format—TIFF format will be used.</para>
			/// </summary>
			[GPValue("TIFF")]
			[Description("TIFF format")]
			TIFF_format,

			/// <summary>
			/// <para>MRF (Meta Raster Format)—Meta Raster Format (MRF) will be used.</para>
			/// </summary>
			[GPValue("MRF")]
			[Description("MRF (Meta Raster Format)")]
			MRF,

			/// <summary>
			/// <para>PNG format—PNG format will be used.</para>
			/// </summary>
			[GPValue("PNG")]
			[Description("PNG format")]
			PNG_format,

			/// <summary>
			/// <para>JPEG format—JPEG format will be used.</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG format")]
			JPEG_format,

		}

		/// <summary>
		/// <para>Output No Feature Tiles</para>
		/// </summary>
		public enum OutputNofeatureTilesEnum 
		{
			/// <summary>
			/// <para>Checked—All image chips, including those that do not capture training samples, will be exported.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL_TILES")]
			ALL_TILES,

			/// <summary>
			/// <para>Unchecked—Only image chips that capture training samples will be exported. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ONLY_TILES_WITH_FEATURES")]
			ONLY_TILES_WITH_FEATURES,

		}

		/// <summary>
		/// <para>Metadata Format</para>
		/// </summary>
		public enum MetadataFormatEnum 
		{
			/// <summary>
			/// <para>KITTI Labels—The metadata follows the same format as the Karlsruhe Institute of Technology and Toyota Technological Institute (KITTI) Object Detection Evaluation dataset. The KITTI dataset is a vision benchmark suite. The label files are plain text files. All values, both numerical and strings, are separated by spaces, and each row corresponds to one object.This format is used for object detection.</para>
			/// </summary>
			[GPValue("KITTI_rectangles")]
			[Description("KITTI Labels")]
			KITTI_Labels,

			/// <summary>
			/// <para>PASCAL Visual Object Classes—The metadata follows the same format as the Pattern Analysis, Statistical Modeling and Computational Learning, Visual Object Classes (PASCAL_VOC) dataset. The PASCAL VOC dataset is a standardized image dataset for object class recognition. The label files are in XML format and contain information about image name, class value, and bounding boxes.This format is used for object detection. This is the default.</para>
			/// </summary>
			[GPValue("PASCAL_VOC_rectangles")]
			[Description("PASCAL Visual Object Classes")]
			PASCAL_Visual_Object_Classes,

			/// <summary>
			/// <para>Classified Tiles—The output will be one classified image chip per input image chip. No other metadata for each image chip is used. Only the statistics output has more information on the classes, such as class names, class values, and output statistics.This format is primarily used for pixel classification. This format is also used for change detection when the output is one classified image chip from two image chips.</para>
			/// </summary>
			[GPValue("Classified_Tiles")]
			[Description("Classified Tiles")]
			Classified_Tiles,

			/// <summary>
			/// <para>RCNN Masks—The output will be image chips that have a mask on the areas where the sample exists. The model generates bounding boxes and segmentation masks for each instance of an object in the image. This format is based on Feature Pyramid Network (FPN) and a ResNet101 backbone in the deep learning framework model.This format is used for object detection.</para>
			/// </summary>
			[GPValue("RCNN_Masks")]
			[Description("RCNN Masks")]
			RCNN_Masks,

			/// <summary>
			/// <para>Labeled Tiles—Each output tile will be labeled with a specific class.This format is used for object classification.</para>
			/// </summary>
			[GPValue("Labeled_Tiles")]
			[Description("Labeled Tiles")]
			Labeled_Tiles,

			/// <summary>
			/// <para>Multi-labeled Tiles—Each output tile will be labeled with one or more classes. For example, a tile may be labeled agriculture and also cloudy.This format is used for object classification.</para>
			/// </summary>
			[GPValue("MultiLabeled_Tiles")]
			[Description("Multi-labeled Tiles")]
			MultiLabeled_Tiles,

			/// <summary>
			/// <para>Export Tiles—The output will be image chips with no label.This format is used for image translation techniques, such as Pix2Pix and Super Resolution.</para>
			/// </summary>
			[GPValue("Export_Tiles")]
			[Description("Export Tiles")]
			Export_Tiles,

			/// <summary>
			/// <para>CycleGAN—The output will be image chips with no label. This format is used for image translation technique CycleGAN, which is used to train images that do not overlap.</para>
			/// </summary>
			[GPValue("CycleGAN")]
			[Description("CycleGAN")]
			CycleGAN,

		}

		/// <summary>
		/// <para>Reference System</para>
		/// </summary>
		public enum ReferenceSystemEnum 
		{
			/// <summary>
			/// <para>Map space—A map-based coordinate system will be used. This is the default.</para>
			/// </summary>
			[GPValue("MAP_SPACE")]
			[Description("Map space")]
			Map_space,

			/// <summary>
			/// <para>Pixel space—Image space will be used, with no rotation and no distortion.</para>
			/// </summary>
			[GPValue("PIXEL_SPACE")]
			[Description("Pixel space")]
			Pixel_space,

		}

		/// <summary>
		/// <para>Processing Mode</para>
		/// </summary>
		public enum ProcessingModeEnum 
		{
			/// <summary>
			/// <para>Process as mosaicked image—All raster items in the mosaic dataset or image service will be mosaicked together and processed. This is the default.</para>
			/// </summary>
			[GPValue("PROCESS_AS_MOSAICKED_IMAGE")]
			[Description("Process as mosaicked image")]
			Process_as_mosaicked_image,

			/// <summary>
			/// <para>Process all raster items separately—All raster items in the mosaic dataset or image service will be processed as separate images.</para>
			/// </summary>
			[GPValue("PROCESS_ITEMS_SEPARATELY")]
			[Description("Process all raster items separately")]
			Process_all_raster_items_separately,

		}

		/// <summary>
		/// <para>Blacken Around Feature</para>
		/// </summary>
		public enum BlackenAroundFeatureEnum 
		{
			/// <summary>
			/// <para>Checked—Pixels surrounding objects or features will be masked out.</para>
			/// </summary>
			[GPValue("true")]
			[Description("BLACKEN_AROUND_FEATURE")]
			BLACKEN_AROUND_FEATURE,

			/// <summary>
			/// <para>Unchecked—Pixels surrounding objects or features will not be masked out. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_BLACKEN")]
			NO_BLACKEN,

		}

		/// <summary>
		/// <para>Crop Mode</para>
		/// </summary>
		public enum CropModeEnum 
		{
			/// <summary>
			/// <para>Fixed size—Exported tiles will be cropped to the same size and will center on the feature. This is the default.</para>
			/// </summary>
			[GPValue("FIXED_SIZE")]
			[Description("Fixed size")]
			Fixed_size,

			/// <summary>
			/// <para>Bounding box—Exported tiles will be cropped so that the bounding geometry surrounds only the feature in the tile.</para>
			/// </summary>
			[GPValue("BOUNDING_BOX")]
			[Description("Bounding box")]
			Bounding_box,

		}

#endregion
	}
}
