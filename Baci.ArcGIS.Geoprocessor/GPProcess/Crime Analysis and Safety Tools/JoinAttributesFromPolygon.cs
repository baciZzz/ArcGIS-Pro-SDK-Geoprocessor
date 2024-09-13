using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CrimeAnalysisandSafetyTools
{
	/// <summary>
	/// <para>Join Attributes From Polygon</para>
	/// <para>连接面属性</para>
	/// <para>将输入面要素的属性连接到输入点要素。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class JoinAttributesFromPolygon : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetFeatures">
		/// <para>Target Point Features</para>
		/// <para>将使用输入面要素中的属性更新的点要素。</para>
		/// <para>将使用 in_features 中的属性更新的点要素。</para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Polygon Features</para>
		/// <para>输入面要素。</para>
		/// </param>
		public JoinAttributesFromPolygon(object TargetFeatures, object InFeatures)
		{
			this.TargetFeatures = TargetFeatures;
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 连接面属性</para>
		/// </summary>
		public override string DisplayName() => "连接面属性";

		/// <summary>
		/// <para>Tool Name : JoinAttributesFromPolygon</para>
		/// </summary>
		public override string ToolName() => "JoinAttributesFromPolygon";

		/// <summary>
		/// <para>Tool Excute Name : ca.JoinAttributesFromPolygon</para>
		/// </summary>
		public override string ExcuteName() => "ca.JoinAttributesFromPolygon";

		/// <summary>
		/// <para>Toolbox Display Name : Crime Analysis and Safety Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Crime Analysis and Safety Tools";

		/// <summary>
		/// <para>Toolbox Alise : ca</para>
		/// </summary>
		public override string ToolboxAlise() => "ca";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetFeatures, InFeatures, Fields, OutFeatures };

		/// <summary>
		/// <para>Target Point Features</para>
		/// <para>将使用输入面要素中的属性更新的点要素。</para>
		/// <para>将使用 in_features 中的属性更新的点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object TargetFeatures { get; set; }

		/// <summary>
		/// <para>Input Polygon Features</para>
		/// <para>输入面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Join Fields</para>
		/// <para>输入面要素中将追加到目标点要素的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Text", "Float", "Double", "Short", "Long", "Date")]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Updated Point Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public JoinAttributesFromPolygon SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
