using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AviationTools
{
	/// <summary>
	/// <para>Rotate Aviation Features</para>
	/// <para>Aligns features to a grid or to the page.</para>
	/// </summary>
	public class RotateAviationFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input Map</para>
		/// <para>The map containing aviation features.</para>
		/// </param>
		/// <param name="TargetLayers">
		/// <para>Target Point or Annotation Layers</para>
		/// <para>The point or annotation feature layers that will be rotated.</para>
		/// </param>
		public RotateAviationFeatures(object InMap, object TargetLayers)
		{
			this.InMap = InMap;
			this.TargetLayers = TargetLayers;
		}

		/// <summary>
		/// <para>Tool Display Name : Rotate Aviation Features</para>
		/// </summary>
		public override string DisplayName() => "Rotate Aviation Features";

		/// <summary>
		/// <para>Tool Name : RotateAviationFeatures</para>
		/// </summary>
		public override string ToolName() => "RotateAviationFeatures";

		/// <summary>
		/// <para>Tool Excute Name : aviation.RotateAviationFeatures</para>
		/// </summary>
		public override string ExcuteName() => "aviation.RotateAviationFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Aviation Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Aviation Tools";

		/// <summary>
		/// <para>Toolbox Alise : aviation</para>
		/// </summary>
		public override string ToolboxAlise() => "aviation";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMap, TargetLayers, RotateOption, UpdatedLayers };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>The map containing aviation features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Target Point or Annotation Layers</para>
		/// <para>The point or annotation feature layers that will be rotated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object TargetLayers { get; set; }

		/// <summary>
		/// <para>Rotate Option</para>
		/// <para>Specifies how the features will be rotated.</para>
		/// <para>Rotate to the map&apos;s grid—The features will be rotated to the map&apos;s grid. This is the default.</para>
		/// <para>Rotate to the top of the page—The features will be rotated to the top of the page.</para>
		/// <para>Rotate to the left of the page—The features will be rotated to the left side of the page.</para>
		/// <para>Rotate to the bottom of the page—The features will be rotated to the bottom of the page.</para>
		/// <para>Rotate to the right of the page—The features will be rotated to the right side of the page.</para>
		/// <para><see cref="RotateOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RotateOption { get; set; } = "ROTATE_TO_GRID";

		/// <summary>
		/// <para>Updated Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object UpdatedLayers { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Rotate Option</para>
		/// </summary>
		public enum RotateOptionEnum 
		{
			/// <summary>
			/// <para>Rotate to the map&apos;s grid—The features will be rotated to the map&apos;s grid. This is the default.</para>
			/// </summary>
			[GPValue("ROTATE_TO_GRID")]
			[Description("Rotate to the map's grid")]
			ROTATE_TO_GRID,

			/// <summary>
			/// <para>Rotate to the top of the page—The features will be rotated to the top of the page.</para>
			/// </summary>
			[GPValue("ROTATE_TO_PAGE_TOP")]
			[Description("Rotate to the top of the page")]
			Rotate_to_the_top_of_the_page,

			/// <summary>
			/// <para>Rotate to the left of the page—The features will be rotated to the left side of the page.</para>
			/// </summary>
			[GPValue("ROTATE_TO_PAGE_LEFT")]
			[Description("Rotate to the left of the page")]
			Rotate_to_the_left_of_the_page,

			/// <summary>
			/// <para>Rotate to the bottom of the page—The features will be rotated to the bottom of the page.</para>
			/// </summary>
			[GPValue("ROTATE_TO_PAGE_BOTTOM")]
			[Description("Rotate to the bottom of the page")]
			Rotate_to_the_bottom_of_the_page,

			/// <summary>
			/// <para>Rotate to the right of the page—The features will be rotated to the right side of the page.</para>
			/// </summary>
			[GPValue("ROTATE_TO_PAGE_RIGHT")]
			[Description("Rotate to the right of the page")]
			Rotate_to_the_right_of_the_page,

		}

#endregion
	}
}
