using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.StandardFeatureAnalysisTools
{
	/// <summary>
	/// <para>Merge Layers</para>
	/// <para>Copies all features from two layers into a new layer. The layers to be combined must contain the same feature types (points, lines, or polygons). You can control how the fields from the input layers are joined and copied.</para>
	/// </summary>
	public class MergeLayers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputlayer">
		/// <para>Input Layer</para>
		/// <para>The point, line, or polygon features to merge with the merge layer.</para>
		/// </param>
		/// <param name="Mergelayer">
		/// <para>Merge Layer</para>
		/// <para>The point, line, or polygon features to merge with the input layer. The merge layer must contain the same feature type (point, line, or polygon) as the input layer.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output layer to create on your portal.</para>
		/// </param>
		public MergeLayers(object Inputlayer, object Mergelayer, object Outputname)
		{
			this.Inputlayer = Inputlayer;
			this.Mergelayer = Mergelayer;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : Merge Layers</para>
		/// </summary>
		public override string DisplayName => "Merge Layers";

		/// <summary>
		/// <para>Tool Name : MergeLayers</para>
		/// </summary>
		public override string ToolName => "MergeLayers";

		/// <summary>
		/// <para>Tool Excute Name : sfa.MergeLayers</para>
		/// </summary>
		public override string ExcuteName => "sfa.MergeLayers";

		/// <summary>
		/// <para>Toolbox Display Name : Standard Feature Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Standard Feature Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : sfa</para>
		/// </summary>
		public override string ToolboxAlise => "sfa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Inputlayer, Mergelayer, Outputname, Mergingattributes, Output };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The point, line, or polygon features to merge with the merge layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Inputlayer { get; set; }

		/// <summary>
		/// <para>Merge Layer</para>
		/// <para>The point, line, or polygon features to merge with the input layer. The merge layer must contain the same feature type (point, line, or polygon) as the input layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Mergelayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output layer to create on your portal.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Merging Attributes</para>
		/// <para>A list of values that describe how fields from the merge layer are to be modified and matched with fields in the input layer. By default, all fields from both inputs will be carried across to the output layer.</para>
		/// <para>If a field exists in one layer but not the other, the output layer will contain both fields. The output field will contain null values for the input features that did not have the field. For example, if the input layer contains a field named TYPE but the merge layer does not contain TYPE, the output will contain TYPE, but its values will be null for all the features copied from the merge layer.</para>
		/// <para>You can control the following merge actions (how fields on the merge layer are written to the output).</para>
		/// <para>REMOVE—The merge layer field will be removed from the output layer.</para>
		/// <para>RENAME—The merge layer field will be renamed in the output. You cannot rename a field from the merge layer to a field from the input layer. If you want to make field names equivalent, use the match option.</para>
		/// <para>MATCH—The merge layer field is renamed and matched to a field from the input layer. For example, the input layer has a field named CODE and the merge layer has a field named STATUS. You can match STATUS to CODE, and the output will contain the CODE field with values of the STATUS field used for features copied from the merge layer. Type casting is supported (for example, double to integer, integer to string), except for string to numeric.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Mergingattributes { get; set; }

		/// <summary>
		/// <para>Output</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MergeLayers SetEnviroment(object extent = null )
		{
			base.SetEnv(extent: extent);
			return this;
		}

	}
}
