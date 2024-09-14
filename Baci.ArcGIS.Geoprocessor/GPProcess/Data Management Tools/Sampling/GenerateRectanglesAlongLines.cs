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
	/// <para>Generate Rectangles Along Lines</para>
	/// <para>Generate Rectangles Along Lines</para>
	/// <para>Creates a series of rectangular polygons that follow a single linear feature or a group of linear features.</para>
	/// </summary>
	public class GenerateRectanglesAlongLines : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Line Features</para>
		/// <para>The input polyline features defining the path of the features.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class.</para>
		/// </param>
		public GenerateRectanglesAlongLines(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Rectangles Along Lines</para>
		/// </summary>
		public override string DisplayName() => "Generate Rectangles Along Lines";

		/// <summary>
		/// <para>Tool Name : GenerateRectanglesAlongLines</para>
		/// </summary>
		public override string ToolName() => "GenerateRectanglesAlongLines";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateRectanglesAlongLines</para>
		/// </summary>
		public override string ExcuteName() => "management.GenerateRectanglesAlongLines";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, LengthAlongLine, LengthPerpendicularToLine, SpatialSortMethod };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>The input polyline features defining the path of the features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Length Along the Line</para>
		/// <para>The length of the output polygon features along the input line features. The default value is determined by the spatial reference of the input line features. This value will be 1/100 of the input feature class extent along the x-axis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object LengthAlongLine { get; set; } = "2 DecimalDegrees";

		/// <summary>
		/// <para>Length Perpendicular to the Line</para>
		/// <para>The length of the output polygon features perpendicular to the input line features. The default value is determined by the spatial reference of the input line features. This value will be one-half the number used for the length along the line.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object LengthPerpendicularToLine { get; set; } = "1 DecimalDegrees";

		/// <summary>
		/// <para>Spatial Sort Method</para>
		/// <para>Output features are created in a sequential order and require a spatial starting point. Setting the direction type to upper right will start the output features in the upper right of each input feature.</para>
		/// <para>Upper right—Features start in the upper right corner. This is the default.</para>
		/// <para>Upper left—Features start in the upper left corner.</para>
		/// <para>Lower right—Features starts in the lower right corner.</para>
		/// <para>Lower left—Features starts in the lower left corner.</para>
		/// <para><see cref="SpatialSortMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SpatialSortMethod { get; set; } = "UL";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateRectanglesAlongLines SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Spatial Sort Method</para>
		/// </summary>
		public enum SpatialSortMethodEnum 
		{
			/// <summary>
			/// <para>Upper left—Features start in the upper left corner.</para>
			/// </summary>
			[GPValue("UL")]
			[Description("Upper left")]
			Upper_left,

			/// <summary>
			/// <para>Upper right—Features start in the upper right corner. This is the default.</para>
			/// </summary>
			[GPValue("UR")]
			[Description("Upper right")]
			Upper_right,

			/// <summary>
			/// <para>Lower left—Features starts in the lower left corner.</para>
			/// </summary>
			[GPValue("LL")]
			[Description("Lower left")]
			Lower_left,

			/// <summary>
			/// <para>Lower right—Features starts in the lower right corner.</para>
			/// </summary>
			[GPValue("LR")]
			[Description("Lower right")]
			Lower_right,

		}

#endregion
	}
}
