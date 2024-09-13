using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>Iterate Feature Selection</para>
	/// <para>Iterate Feature Selection</para>
	/// <para>Iterates over features in a feature class.</para>
	/// </summary>
	public class IterateFeatureSelection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>In Features</para>
		/// <para>The input feature class or layer containing features to iterate.</para>
		/// </param>
		public IterateFeatureSelection(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Iterate Feature Selection</para>
		/// </summary>
		public override string DisplayName() => "Iterate Feature Selection";

		/// <summary>
		/// <para>Tool Name : IterateFeatureSelection</para>
		/// </summary>
		public override string ToolName() => "IterateFeatureSelection";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateFeatureSelection</para>
		/// </summary>
		public override string ExcuteName() => "mb.IterateFeatureSelection";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise() => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, Fields!, SkipNulls!, Selection!, Value! };

		/// <summary>
		/// <para>In Features</para>
		/// <para>The input feature class or layer containing features to iterate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Group By Fields</para>
		/// <para>The input field or fields used to group the features for selection. Any number of input fields can be defined, resulting in a selection based on a unique combination of the fields. If a field is not specified, the Object ID is used to iterate over features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPFieldDomain()]
		[FieldType("Long", "Short", "Text", "OID", "Float", "Double", "Date", "GUID", "GlobalID", "XML")]
		public object? Fields { get; set; }

		/// <summary>
		/// <para>Skip Null Values</para>
		/// <para>Specifies whether null values in the grouping field or fields are skipped during selection.</para>
		/// <para>Checked—Skip through all the null values in the grouping fields during selection.</para>
		/// <para>Unchecked—Set as default. Include all the null values in the grouping fields during selection. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		public object? SkipNulls { get; set; } = "false";

		/// <summary>
		/// <para>Selected Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? Selection { get; set; }

		/// <summary>
		/// <para>Value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPVariant()]
		public object? Value { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public IterateFeatureSelection SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
