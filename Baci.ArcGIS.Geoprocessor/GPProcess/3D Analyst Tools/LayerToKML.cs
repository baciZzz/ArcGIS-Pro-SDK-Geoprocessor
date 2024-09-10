using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Layer To KML</para>
	/// <para>3D Analyst Layer to KML geoprocessing function</para>
	/// </summary>
	[Obsolete()]
	public class LayerToKML : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Layer">
		/// <para>Layer</para>
		/// </param>
		/// <param name="OutKmzFile">
		/// <para>Output File</para>
		/// </param>
		public LayerToKML(object Layer, object OutKmzFile)
		{
			this.Layer = Layer;
			this.OutKmzFile = OutKmzFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Layer To KML</para>
		/// </summary>
		public override string DisplayName() => "Layer To KML";

		/// <summary>
		/// <para>Tool Name : LayerToKML</para>
		/// </summary>
		public override string ToolName() => "LayerToKML";

		/// <summary>
		/// <para>Tool Excute Name : 3d.LayerToKML</para>
		/// </summary>
		public override string ExcuteName() => "3d.LayerToKML";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Layer, OutKmzFile, LayerOutputScale, IsComposite, BoundaryBoxExtent, ImageSize, DpiOfClient, IgnoreZvalue };

		/// <summary>
		/// <para>Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Layer { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("kmz")]
		public object OutKmzFile { get; set; }

		/// <summary>
		/// <para>Layer Output Scale</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object LayerOutputScale { get; set; } = "0";

		/// <summary>
		/// <para>Return single composite image</para>
		/// <para><see cref="IsCompositeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Data Content Properties")]
		public object IsComposite { get; set; } = "false";

		/// <summary>
		/// <para>Extent to Export</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Extent Properties")]
		public object BoundaryBoxExtent { get; set; }

		/// <summary>
		/// <para>Size of returned image (pixels)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Output Image Properties")]
		public object ImageSize { get; set; } = "1024";

		/// <summary>
		/// <para>DPI of output image</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Output Image Properties")]
		public object DpiOfClient { get; set; } = "96";

		/// <summary>
		/// <para>Clamped features to ground</para>
		/// <para><see cref="IgnoreZvalueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IgnoreZvalue { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>Return single composite image</para>
		/// </summary>
		public enum IsCompositeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPOSITE")]
			COMPOSITE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COMPOSITE")]
			NO_COMPOSITE,

		}

		/// <summary>
		/// <para>Clamped features to ground</para>
		/// </summary>
		public enum IgnoreZvalueEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLAMPED_TO_GROUND")]
			CLAMPED_TO_GROUND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ABSOLUTE")]
			ABSOLUTE,

		}

#endregion
	}
}
