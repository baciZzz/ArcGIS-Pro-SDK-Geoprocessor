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
	/// <para>Compress File Geodatabase Data</para>
	/// <para>压缩文件地理数据库数据</para>
	/// <para>压缩地理数据库中的所有内容、要素数据集中的所有内容或各个独立要素类/表。</para>
	/// </summary>
	public class CompressFileGeodatabaseData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input file geodatabase data</para>
		/// <para>要压缩的地理数据库、要素数据集、要素类或表。</para>
		/// </param>
		/// <param name="Lossless">
		/// <para>Lossless compression</para>
		/// <para>提示是否使用无损压缩。</para>
		/// <para>未选中 - 不使用无损压缩。</para>
		/// <para>选中 - 使用无损压缩。这是默认设置。注：10.0 版之前的文件地理数据库不支持无损压缩。此选项不可更改，未选中且不可用。</para>
		/// <para><see cref="LosslessEnum"/></para>
		/// </param>
		public CompressFileGeodatabaseData(object InData, object Lossless)
		{
			this.InData = InData;
			this.Lossless = Lossless;
		}

		/// <summary>
		/// <para>Tool Display Name : 压缩文件地理数据库数据</para>
		/// </summary>
		public override string DisplayName() => "压缩文件地理数据库数据";

		/// <summary>
		/// <para>Tool Name : CompressFileGeodatabaseData</para>
		/// </summary>
		public override string ToolName() => "CompressFileGeodatabaseData";

		/// <summary>
		/// <para>Tool Excute Name : management.CompressFileGeodatabaseData</para>
		/// </summary>
		public override string ExcuteName() => "management.CompressFileGeodatabaseData";

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
		public override object[] Parameters() => new object[] { InData, Lossless, OutData };

		/// <summary>
		/// <para>Input file geodatabase data</para>
		/// <para>要压缩的地理数据库、要素数据集、要素类或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Lossless compression</para>
		/// <para>提示是否使用无损压缩。</para>
		/// <para>未选中 - 不使用无损压缩。</para>
		/// <para>选中 - 使用无损压缩。这是默认设置。注：10.0 版之前的文件地理数据库不支持无损压缩。此选项不可更改，未选中且不可用。</para>
		/// <para><see cref="LosslessEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Lossless { get; set; } = "true";

		/// <summary>
		/// <para>Compressed Input Data</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object OutData { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CompressFileGeodatabaseData SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Lossless compression</para>
		/// </summary>
		public enum LosslessEnum 
		{
			/// <summary>
			/// <para>Lossless compression</para>
			/// </summary>
			[GPValue("Lossless compression")]
			[Description("Lossless compression")]
			Lossless_compression,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Non-lossless compression")]
			[Description("Non-lossless compression")]
			Non_lossless_compression,

		}

#endregion
	}
}
