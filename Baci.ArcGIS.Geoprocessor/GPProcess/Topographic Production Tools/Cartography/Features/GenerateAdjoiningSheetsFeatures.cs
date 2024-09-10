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
	/// <para>Generate Adjoining Sheets Features</para>
	/// <para>Generates features necessary for display in a typical topographic map adjoining sheets diagram.</para>
	/// </summary>
	public class GenerateAdjoiningSheetsFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureDataset">
		/// <para>Input Feature Dataset</para>
		/// <para>An existing feature dataset that will contain the ASG_ feature classes. The tool will create these feature classes if they do not exist.</para>
		/// </param>
		/// <param name="AreaOfInterest">
		/// <para>Area Of Interest</para>
		/// <para>A feature layer with a single selected feature used to identify the center and surrounding AOIs. Adjoining sheets features will be created from the selected AOI and the intersecting AOIs as required.</para>
		/// </param>
		public GenerateAdjoiningSheetsFeatures(object InFeatureDataset, object AreaOfInterest)
		{
			this.InFeatureDataset = InFeatureDataset;
			this.AreaOfInterest = AreaOfInterest;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Adjoining Sheets Features</para>
		/// </summary>
		public override string DisplayName() => "Generate Adjoining Sheets Features";

		/// <summary>
		/// <para>Tool Name : GenerateAdjoiningSheetsFeatures</para>
		/// </summary>
		public override string ToolName() => "GenerateAdjoiningSheetsFeatures";

		/// <summary>
		/// <para>Tool Excute Name : topographic.GenerateAdjoiningSheetsFeatures</para>
		/// </summary>
		public override string ExcuteName() => "topographic.GenerateAdjoiningSheetsFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise() => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureDataset, AreaOfInterest, LandFeatures, Scale, ClipAoiToSheets, ModifiedFeatureDataset };

		/// <summary>
		/// <para>Input Feature Dataset</para>
		/// <para>An existing feature dataset that will contain the ASG_ feature classes. The tool will create these feature classes if they do not exist.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object InFeatureDataset { get; set; }

		/// <summary>
		/// <para>Area Of Interest</para>
		/// <para>A feature layer with a single selected feature used to identify the center and surrounding AOIs. Adjoining sheets features will be created from the selected AOI and the intersecting AOIs as required.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Input Land Features</para>
		/// <para>Land features used to generate adjoining sheets features in the ASG_COAST_A and ASG_COAST_L feature classes in the target feature dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object LandFeatures { get; set; }

		/// <summary>
		/// <para>Scale</para>
		/// <para>Defines a factor by which the extent of the Area of Interest is expanded. The expanded extent is used to select adjoining AOIs. Data from the adjoining AOIs is included in the adjoining sheets diagram.</para>
		/// <para>1:25000—Uses specification MIL-T-89301A as a guide to determine how to expand the width and height of the extent of the Area of Interest.</para>
		/// <para>1:50000—Uses specification MIL-T-89301A to determine how to expand the width and height of the extent of the Area of Interest. This is the default.</para>
		/// <para>1:100000—Uses specification MIL-T-89306 to determine how to expand the width and height of the extent of the Area of Interest.</para>
		/// <para><see cref="ScaleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Scale { get; set; } = "1:50000";

		/// <summary>
		/// <para>Clip AOI to Sheets</para>
		/// <para>Determines if the AOI created for the extent of the adjoining sheets diagram will be clipped to the extents of the sheets to be displayed. If the Clip AOI to Sheets check box is checked, the AOI for the adjoining sheets diagram will be modified from its originally calculated rectangular shape to include any irregular map sheet extents that will be included or excluded in the diagram.</para>
		/// <para>Checked—The AOI feature will be clipped by the sheets to be displayed in the adjoining sheet diagram and may have an irregular shape. This is the default.</para>
		/// <para>Unchecked—The AOI feature will not be clipped and will retain its originally calculated rectangular shape. This may result in partial sheets being displayed in the adjoining sheets diagram.</para>
		/// <para><see cref="ClipAoiToSheetsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ClipAoiToSheets { get; set; } = "true";

		/// <summary>
		/// <para>Modified Feature Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureDataset()]
		public object ModifiedFeatureDataset { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Scale</para>
		/// </summary>
		public enum ScaleEnum 
		{
			/// <summary>
			/// <para>1:25000—Uses specification MIL-T-89301A as a guide to determine how to expand the width and height of the extent of the Area of Interest.</para>
			/// </summary>
			[GPValue("1:25000")]
			[Description("1:25000")]
			_1_25000,

			/// <summary>
			/// <para>1:50000—Uses specification MIL-T-89301A to determine how to expand the width and height of the extent of the Area of Interest. This is the default.</para>
			/// </summary>
			[GPValue("1:50000")]
			[Description("1:50000")]
			_1_50000,

			/// <summary>
			/// <para>1:100000—Uses specification MIL-T-89306 to determine how to expand the width and height of the extent of the Area of Interest.</para>
			/// </summary>
			[GPValue("1:100000")]
			[Description("1:100000")]
			_1_100000,

		}

		/// <summary>
		/// <para>Clip AOI to Sheets</para>
		/// </summary>
		public enum ClipAoiToSheetsEnum 
		{
			/// <summary>
			/// <para>Checked—The AOI feature will be clipped by the sheets to be displayed in the adjoining sheet diagram and may have an irregular shape. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLIP_AOI")]
			CLIP_AOI,

			/// <summary>
			/// <para>Unchecked—The AOI feature will not be clipped and will retain its originally calculated rectangular shape. This may result in partial sheets being displayed in the adjoining sheets diagram.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_CLIP_AOI")]
			DONT_CLIP_AOI,

		}

#endregion
	}
}
