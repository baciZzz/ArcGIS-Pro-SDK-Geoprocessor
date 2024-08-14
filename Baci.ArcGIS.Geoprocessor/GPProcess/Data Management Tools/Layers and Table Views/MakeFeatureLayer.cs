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
	/// <para>Make Feature Layer</para>
	/// <para>Creates a feature layer from an input feature class or layer file. The layer that is created is temporary and will not persist after the session ends unless the layer is saved to disk or the map document is saved.</para>
	/// </summary>
	public class MakeFeatureLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input feature class or layer from which the new layer will be made. Complex feature classes, such as annotation and dimensions, are not valid inputs.</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Layer</para>
		/// <para>The name of the feature layer to be created. The newly created layer can be used as input to any geoprocessing tool that accepts a feature layer as input.</para>
		/// </param>
		public MakeFeatureLayer(object InFeatures, object OutLayer)
		{
			this.InFeatures = InFeatures;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Feature Layer</para>
		/// </summary>
		public override string DisplayName => "Make Feature Layer";

		/// <summary>
		/// <para>Tool Name : MakeFeatureLayer</para>
		/// </summary>
		public override string ToolName => "MakeFeatureLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeFeatureLayer</para>
		/// </summary>
		public override string ExcuteName => "management.MakeFeatureLayer";

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
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutLayer, WhereClause!, Workspace!, FieldInfo! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input feature class or layer from which the new layer will be made. Complex feature classes, such as annotation and dimensions, are not valid inputs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>The name of the feature layer to be created. The newly created layer can be used as input to any geoprocessing tool that accepts a feature layer as input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>An SQL expression used to select a subset of features.</para>
		/// <para>If the input is a layer with an existing definition query and a where clause is specified with this parameter, both where clauses will be combined with an AND operator for the output layer. For example, if the input layer has a where clause of ID &gt; 10 and this parameter is set to ID &lt; 20, the resulting layer&apos;s where clause will be ID &gt; 10 AND ID &lt; 20.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Workspace or Feature Dataset</para>
		/// <para>The input workspace used to validate the field names. If the input is a geodatabase table and the output workspace is a dBASE table, the field names may be truncated, since dBASE fields can only have names of ten characters or less.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? Workspace { get; set; }

		/// <summary>
		/// <para>Field Info</para>
		/// <para>The fields from the input that will be renamed and made visible in the output. A split policy can be specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldInfo()]
		public object? FieldInfo { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeFeatureLayer SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
