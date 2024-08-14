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
	/// <para>Apply Symbology From Layer</para>
	/// <para>Applies the symbology from a specified layer or layer file to the input. It can be applied to feature, raster, network analysis, TIN, and geostatistical layers.</para>
	/// </summary>
	public class ApplySymbologyFromLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayer">
		/// <para>Input Layer</para>
		/// <para>The layer to which the symbology will be applied.</para>
		/// </param>
		/// <param name="InSymbologyLayer">
		/// <para>Symbology Layer</para>
		/// <para>The symbology of this layer will be applied to the input layer. Both .lyrx and .lyr files are supported.</para>
		/// </param>
		public ApplySymbologyFromLayer(object InLayer, object InSymbologyLayer)
		{
			this.InLayer = InLayer;
			this.InSymbologyLayer = InSymbologyLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Symbology From Layer</para>
		/// </summary>
		public override string DisplayName => "Apply Symbology From Layer";

		/// <summary>
		/// <para>Tool Name : ApplySymbologyFromLayer</para>
		/// </summary>
		public override string ToolName => "ApplySymbologyFromLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.ApplySymbologyFromLayer</para>
		/// </summary>
		public override string ExcuteName => "management.ApplySymbologyFromLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InLayer, InSymbologyLayer, SymbologyFields, OutLayer, UpdateSymbology };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The layer to which the symbology will be applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InLayer { get; set; }

		/// <summary>
		/// <para>Symbology Layer</para>
		/// <para>The symbology of this layer will be applied to the input layer. Both .lyrx and .lyr files are supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		public object InSymbologyLayer { get; set; }

		/// <summary>
		/// <para>Symbology Fields</para>
		/// <para>The fields from the input layer that match the symbology fields used in the symbology layer. Symbology fields contain three properties:</para>
		/// <para>Field type—Specifies the field type: symbology value, normalization, or other type.</para>
		/// <para>Source field—The symbology field used by the symbology layer. Use a blank value or &quot;#&quot; if you do not know the source field and want to use the default.</para>
		/// <para>Target field—The field from the input layer to use when applying the symbology.</para>
		/// <para>Supported field types are as follows:</para>
		/// <para>Value field—Primary field used to symbolize values</para>
		/// <para>Normalization field—Field used to normalize quantitative values</para>
		/// <para>Exclusion clause field—Field used for the symbology exclusion clause</para>
		/// <para>Chart renderer pie size field—Field used to set the size of pie chart symbols</para>
		/// <para>Rotation X expression field—Field used to set the rotation of symbols on the x-axis</para>
		/// <para>Rotation Y expression field—Field used to set the rotation of symbols on the y-axis</para>
		/// <para>Rotation Z expression field—Field used to set the rotation of symbols on the z-axis</para>
		/// <para>Transparency expression field—Field used to set the transparency of symbols</para>
		/// <para>Transparency normalization field—Field used to normalize transparency values</para>
		/// <para>Size expression field—Field used to set the size or width of symbols</para>
		/// <para>Color expression field—Field used to set the color of symbols</para>
		/// <para>Primitive override expression field—Field used to set various properties on individual symbol layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object SymbologyFields { get; set; }

		/// <summary>
		/// <para>Updated Input Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Update Symbology Ranges by Data</para>
		/// <para>Specifies whether symbology ranges will be updated.</para>
		/// <para>Default—Symbology ranges will be updated, except in the following situations: when the input layer is empty; when the symbology layer uses class breaks (for example, graduated colors or graduated symbols) and the classification method is manual or defined interval; or when the symbology layer uses unique values and the Show all other values option is checked.</para>
		/// <para>Update ranges—Symbology ranges will be updated.</para>
		/// <para>Maintain ranges—Symbology ranges will not be updated; they will be maintained.</para>
		/// <para><see cref="UpdateSymbologyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object UpdateSymbology { get; set; } = "DEFAULT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ApplySymbologyFromLayer SetEnviroment(int? autoCommit = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Update Symbology Ranges by Data</para>
		/// </summary>
		public enum UpdateSymbologyEnum 
		{
			/// <summary>
			/// <para>Default—Symbology ranges will be updated, except in the following situations: when the input layer is empty; when the symbology layer uses class breaks (for example, graduated colors or graduated symbols) and the classification method is manual or defined interval; or when the symbology layer uses unique values and the Show all other values option is checked.</para>
			/// </summary>
			[GPValue("DEFAULT")]
			[Description("Default")]
			Default,

			/// <summary>
			/// <para>Update ranges—Symbology ranges will be updated.</para>
			/// </summary>
			[GPValue("UPDATE")]
			[Description("Update ranges")]
			Update_ranges,

			/// <summary>
			/// <para>Maintain ranges—Symbology ranges will not be updated; they will be maintained.</para>
			/// </summary>
			[GPValue("MAINTAIN")]
			[Description("Maintain ranges")]
			Maintain_ranges,

		}

#endregion
	}
}
