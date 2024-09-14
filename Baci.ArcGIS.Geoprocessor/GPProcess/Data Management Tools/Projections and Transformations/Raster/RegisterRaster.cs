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
	/// <para>Register Raster</para>
	/// <para>Register Raster</para>
	/// <para>Automatically aligns a raster to a reference image or uses a control point file for georegistration. If the input dataset is a mosaic dataset, the</para>
	/// <para>tool will operate on each mosaic dataset item. To automatically register the image, the input raster</para>
	/// <para>and the reference raster must be in a relatively close geographic</para>
	/// <para>area. The tool will run faster if the raster</para>
	/// <para>datasets are in close alignment. You may need to</para>
	/// <para>create a link file, also known as a control point file, with a few links to get your input raster into</para>
	/// <para>the same map space.</para>
	/// </summary>
	public class RegisterRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster that you want to realign. Registering a mosaic dataset item will update that particular item within the mosaic dataset.</para>
		/// <para>A mosaic dataset item will have the path to the mosaic dataset followed by the Object ID of the item. For example, the first item in the mosaic dataset would have the following path: .\mosaicDataset\objectid=1.</para>
		/// </param>
		/// <param name="RegisterMode">
		/// <para>Register Mode</para>
		/// <para>Specifies the registration mode. You can either register the raster with a transformation or reset the transformation.</para>
		/// <para>Register—Apply a geometric transformation to the input raster.</para>
		/// <para>Register multispectral—Register the multispectral input to the panchromatic input. This is only used for mosaic datasets that have a misalignment between the two.</para>
		/// <para>Reset— Remove the geometric transformation previously added by this tool.</para>
		/// <para>Create links—Create a link file with automatically generated links.</para>
		/// <para><see cref="RegisterModeEnum"/></para>
		/// </param>
		public RegisterRaster(object InRaster, object RegisterMode)
		{
			this.InRaster = InRaster;
			this.RegisterMode = RegisterMode;
		}

		/// <summary>
		/// <para>Tool Display Name : Register Raster</para>
		/// </summary>
		public override string DisplayName() => "Register Raster";

		/// <summary>
		/// <para>Tool Name : RegisterRaster</para>
		/// </summary>
		public override string ToolName() => "RegisterRaster";

		/// <summary>
		/// <para>Tool Excute Name : management.RegisterRaster</para>
		/// </summary>
		public override string ExcuteName() => "management.RegisterRaster";

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
		public override object[] Parameters() => new object[] { InRaster, RegisterMode, ReferenceRaster!, InputLinkFile!, TransformationType!, OutputCptLinkFile!, MaximumRmsValue!, OutRaster! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster that you want to realign. Registering a mosaic dataset item will update that particular item within the mosaic dataset.</para>
		/// <para>A mosaic dataset item will have the path to the mosaic dataset followed by the Object ID of the item. For example, the first item in the mosaic dataset would have the following path: .\mosaicDataset\objectid=1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Register Mode</para>
		/// <para>Specifies the registration mode. You can either register the raster with a transformation or reset the transformation.</para>
		/// <para>Register—Apply a geometric transformation to the input raster.</para>
		/// <para>Register multispectral—Register the multispectral input to the panchromatic input. This is only used for mosaic datasets that have a misalignment between the two.</para>
		/// <para>Reset— Remove the geometric transformation previously added by this tool.</para>
		/// <para>Create links—Create a link file with automatically generated links.</para>
		/// <para><see cref="RegisterModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RegisterMode { get; set; } = "REGISTER";

		/// <summary>
		/// <para>Reference Raster</para>
		/// <para>The raster dataset that will align the input raster dataset. Leave this parameter empty if you want to register your multispectral mosaic dataset items to their associated panchromatic raster datasets.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? ReferenceRaster { get; set; }

		/// <summary>
		/// <para>Input Link File</para>
		/// <para>The file that has the coordinates to link the input raster dataset with the reference. The input link table works with one mosaic item in the mosaic layer. The input must specify which item is being processed, either selecting the item or specifying the ObjectID in the input. Leave this parameter empty to register multispectral mosaic dataset items with the associated panchromatic raster datasets.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? InputLinkFile { get; set; }

		/// <summary>
		/// <para>Transformation Type</para>
		/// <para>Specifies the method for shifting the raster dataset.</para>
		/// <para>Shift only— This method uses a zero-order polynomial to shift your data. This is commonly used when your data is already georeferenced, but a small shift will better line up your data. Only one link is required to perform a zero-order polynomial shift.</para>
		/// <para>Similarity transformation— This is a first-order transformation that attempts to preserve the shape of the original raster. The RMS error tends to be higher than other polynomial transformations because the preservation of shape is more important than the best fit.</para>
		/// <para>Affine transformation—A first-order polynomial (affine) fits a flat plane to the input points.</para>
		/// <para>Second-order polynomial transformation—A second-order polynomial fits a somewhat more complicated surface to the input points.</para>
		/// <para>Third-order polynomial transformation—A third-order polynomial fits a more complicated surface to the input points.</para>
		/// <para>Adjust transformation— This method combines a polynomial transformation and uses a triangulated irregular network (TIN) interpolation technique to optimize for both global and local accuracy.</para>
		/// <para>Spline transformation— This method transforms the source control points precisely to the target control points. In the output, the control points will be accurate, but the raster pixels between the control points are not.</para>
		/// <para>Projective transformation— This method warps lines so they remain straight. In doing so, lines that were once parallel may no longer remain parallel. The projective transformation is especially useful for oblique imagery, scanned maps, and for some imagery products.</para>
		/// <para>Frame transformation—This method uses an image resection algorithm on aerial images. The image resection algorithm refines the exterior orientation (perspective, omega, phi, and kappa) of the image from known ground control points, using a least-square fitting method. Each image must have at least three noncollinear points. When the input is a mosaic dataset, it will register the selected images one at a time.</para>
		/// <para><see cref="TransformationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TransformationType { get; set; } = "POLYORDER1";

		/// <summary>
		/// <para>Output Link File</para>
		/// <para>If specified, a text file will be written containing the links created by this tool. This file can be used in the Warp From File tool. The output link table works with one mosaic dataset item in the mosaic layer. The input must specify which item is being processed, either selecting the item or specifying the ObjectID in the input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETextFile()]
		public object? OutputCptLinkFile { get; set; }

		/// <summary>
		/// <para>Maximum RMS</para>
		/// <para>The amount of modeled error (in pixels) that you want in the output. The default is 0.5, and values below 0.3 are not recommended as this leads to overfitting.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaximumRmsValue { get; set; }

		/// <summary>
		/// <para>Registered Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object? OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RegisterRaster SetEnviroment(object? parallelProcessingFactor = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Register Mode</para>
		/// </summary>
		public enum RegisterModeEnum 
		{
			/// <summary>
			/// <para>Register Mode</para>
			/// </summary>
			[GPValue("REGISTER")]
			[Description("Register")]
			Register,

			/// <summary>
			/// <para>Register multispectral—Register the multispectral input to the panchromatic input. This is only used for mosaic datasets that have a misalignment between the two.</para>
			/// </summary>
			[GPValue("REGISTER_MS")]
			[Description("Register multispectral")]
			Register_multispectral,

			/// <summary>
			/// <para>Reset— Remove the geometric transformation previously added by this tool.</para>
			/// </summary>
			[GPValue("RESET")]
			[Description("Reset")]
			Reset,

			/// <summary>
			/// <para>Create links—Create a link file with automatically generated links.</para>
			/// </summary>
			[GPValue("CREATE_LINKS")]
			[Description("Create links")]
			Create_links,

		}

		/// <summary>
		/// <para>Transformation Type</para>
		/// </summary>
		public enum TransformationTypeEnum 
		{
			/// <summary>
			/// <para>Shift only— This method uses a zero-order polynomial to shift your data. This is commonly used when your data is already georeferenced, but a small shift will better line up your data. Only one link is required to perform a zero-order polynomial shift.</para>
			/// </summary>
			[GPValue("POLYORDER0")]
			[Description("Shift only")]
			Shift_only,

			/// <summary>
			/// <para>Similarity transformation— This is a first-order transformation that attempts to preserve the shape of the original raster. The RMS error tends to be higher than other polynomial transformations because the preservation of shape is more important than the best fit.</para>
			/// </summary>
			[GPValue("POLYSIMILARITY")]
			[Description("Similarity transformation")]
			Similarity_transformation,

			/// <summary>
			/// <para>Affine transformation—A first-order polynomial (affine) fits a flat plane to the input points.</para>
			/// </summary>
			[GPValue("POLYORDER1")]
			[Description("Affine transformation")]
			Affine_transformation,

			/// <summary>
			/// <para>Second-order polynomial transformation—A second-order polynomial fits a somewhat more complicated surface to the input points.</para>
			/// </summary>
			[GPValue("POLYORDER2")]
			[Description("Second-order polynomial transformation")]
			POLYORDER2,

			/// <summary>
			/// <para>Third-order polynomial transformation—A third-order polynomial fits a more complicated surface to the input points.</para>
			/// </summary>
			[GPValue("POLYORDER3")]
			[Description("Third-order polynomial transformation")]
			POLYORDER3,

			/// <summary>
			/// <para>Projective transformation— This method warps lines so they remain straight. In doing so, lines that were once parallel may no longer remain parallel. The projective transformation is especially useful for oblique imagery, scanned maps, and for some imagery products.</para>
			/// </summary>
			[GPValue("PROJECTIVE")]
			[Description("Projective transformation")]
			Projective_transformation,

			/// <summary>
			/// <para>Spline transformation— This method transforms the source control points precisely to the target control points. In the output, the control points will be accurate, but the raster pixels between the control points are not.</para>
			/// </summary>
			[GPValue("SPLINE")]
			[Description("Spline transformation")]
			Spline_transformation,

			/// <summary>
			/// <para>Adjust transformation— This method combines a polynomial transformation and uses a triangulated irregular network (TIN) interpolation technique to optimize for both global and local accuracy.</para>
			/// </summary>
			[GPValue("ADJUST")]
			[Description("Adjust transformation")]
			Adjust_transformation,

			/// <summary>
			/// <para>Frame transformation—This method uses an image resection algorithm on aerial images. The image resection algorithm refines the exterior orientation (perspective, omega, phi, and kappa) of the image from known ground control points, using a least-square fitting method. Each image must have at least three noncollinear points. When the input is a mosaic dataset, it will register the selected images one at a time.</para>
			/// </summary>
			[GPValue("FRAME")]
			[Description("Frame transformation")]
			Frame_transformation,

		}

#endregion
	}
}
