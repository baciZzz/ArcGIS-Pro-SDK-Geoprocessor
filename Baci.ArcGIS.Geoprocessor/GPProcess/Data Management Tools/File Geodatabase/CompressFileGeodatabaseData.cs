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
	/// <para>Compress File Geodatabase Data</para>
	/// <para>Compresses all the contents in a geodatabase, all the contents in a feature</para>
	/// <para>dataset, or an individual stand-alone feature class or table.</para>
	/// </summary>
	public class CompressFileGeodatabaseData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input file geodatabase data</para>
		/// <para>The geodatabase, feature dataset, feature class, or table to compress.</para>
		/// </param>
		/// <param name="Lossless">
		/// <para>Lossless compression</para>
		/// <para>Indicates whether lossless compression will be used.</para>
		/// <para>Unchecked—Lossless compression will not be used.</para>
		/// <para>Checked—Lossless compression will be used. This is the default.Note: For pre-10.0 file geodatabases, lossless compression is not supported. This option cannot be changed and is unchecked and disabled.</para>
		/// <para><see cref="LosslessEnum"/></para>
		/// </param>
		public CompressFileGeodatabaseData(object InData, object Lossless)
		{
			this.InData = InData;
			this.Lossless = Lossless;
		}

		/// <summary>
		/// <para>Tool Display Name : Compress File Geodatabase Data</para>
		/// </summary>
		public override string DisplayName() => "Compress File Geodatabase Data";

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
		public override object[] Parameters() => new object[] { InData, Lossless, OutData! };

		/// <summary>
		/// <para>Input file geodatabase data</para>
		/// <para>The geodatabase, feature dataset, feature class, or table to compress.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Lossless compression</para>
		/// <para>Indicates whether lossless compression will be used.</para>
		/// <para>Unchecked—Lossless compression will not be used.</para>
		/// <para>Checked—Lossless compression will be used. This is the default.Note: For pre-10.0 file geodatabases, lossless compression is not supported. This option cannot be changed and is unchecked and disabled.</para>
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
		public object? OutData { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CompressFileGeodatabaseData SetEnviroment(object? workspace = null )
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
