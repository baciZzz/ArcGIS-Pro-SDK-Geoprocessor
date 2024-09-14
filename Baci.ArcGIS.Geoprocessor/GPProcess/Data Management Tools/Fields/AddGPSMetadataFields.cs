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
	/// <para>Add GPS Metadata Fields</para>
	/// <para>添加 GPS 元数据字段</para>
	/// <para>用于将 GNSS 字段添加到地理数据库中的要素类。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddGPSMetadataFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input Point Features</para>
		/// <para>要更新的输入点要素类。</para>
		/// </param>
		public AddGPSMetadataFields(object InPointFeatures)
		{
			this.InPointFeatures = InPointFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加 GPS 元数据字段</para>
		/// </summary>
		public override string DisplayName() => "添加 GPS 元数据字段";

		/// <summary>
		/// <para>Tool Name : AddGPSMetadataFields</para>
		/// </summary>
		public override string ToolName() => "AddGPSMetadataFields";

		/// <summary>
		/// <para>Tool Excute Name : management.AddGPSMetadataFields</para>
		/// </summary>
		public override string ExcuteName() => "management.AddGPSMetadataFields";

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
		public override object[] Parameters() => new object[] { InPointFeatures, UpdatedPointFeatures };

		/// <summary>
		/// <para>Input Point Features</para>
		/// <para>要更新的输入点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		[FeatureType("Simple")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Updated Point Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object UpdatedPointFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddGPSMetadataFields SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
