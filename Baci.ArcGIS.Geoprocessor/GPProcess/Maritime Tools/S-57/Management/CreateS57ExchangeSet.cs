using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MaritimeTools
{
	/// <summary>
	/// <para>Create S-57 Exchange Set</para>
	/// <para>Create S-57 Exchange Set</para>
	/// <para>Allows a mariner to view the Electronic Navigational Chart (ENC) datasets in an Electronic Chart Display and Information System (ECDIS) for shipboard navigation.</para>
	/// </summary>
	public class CreateS57ExchangeSet : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDirectories">
		/// <para>Input Directories</para>
		/// <para>Folders that contain at least one S-57 base cell (*.000) and, optionally, any of the following:</para>
		/// <para>S-57 update datasets</para>
		/// <para>README.txt file</para>
		/// <para>Any referenced files in the S-57 cells (*.txt, *.tif, and *.jpg)</para>
		/// </param>
		/// <param name="OutDirectory">
		/// <para>Output Directory</para>
		/// <para>The location of an empty folder where the ENC_ROOT folder will be written. The folder must be empty for the tool to execute successfully.</para>
		/// </param>
		public CreateS57ExchangeSet(object InDirectories, object OutDirectory)
		{
			this.InDirectories = InDirectories;
			this.OutDirectory = OutDirectory;
		}

		/// <summary>
		/// <para>Tool Display Name : Create S-57 Exchange Set</para>
		/// </summary>
		public override string DisplayName() => "Create S-57 Exchange Set";

		/// <summary>
		/// <para>Tool Name : CreateS57ExchangeSet</para>
		/// </summary>
		public override string ToolName() => "CreateS57ExchangeSet";

		/// <summary>
		/// <para>Tool Excute Name : maritime.CreateS57ExchangeSet</para>
		/// </summary>
		public override string ExcuteName() => "maritime.CreateS57ExchangeSet";

		/// <summary>
		/// <para>Toolbox Display Name : Maritime Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Maritime Tools";

		/// <summary>
		/// <para>Toolbox Alise : maritime</para>
		/// </summary>
		public override string ToolboxAlise() => "maritime";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDirectories, OutDirectory, LayoutFormat, UpdatesOnly, DerivedOutDirectory };

		/// <summary>
		/// <para>Input Directories</para>
		/// <para>Folders that contain at least one S-57 base cell (*.000) and, optionally, any of the following:</para>
		/// <para>S-57 update datasets</para>
		/// <para>README.txt file</para>
		/// <para>Any referenced files in the S-57 cells (*.txt, *.tif, and *.jpg)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InDirectories { get; set; }

		/// <summary>
		/// <para>Output Directory</para>
		/// <para>The location of an empty folder where the ENC_ROOT folder will be written. The folder must be empty for the tool to execute successfully.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutDirectory { get; set; }

		/// <summary>
		/// <para>Layout Format</para>
		/// <para>Specifies the directory and folder structure of the exchange set.</para>
		/// <para>VERSION_LAYOUT— The exchange set will be written in the format ENC_ROOT\CATALOG.031, ENC_ROOT\&lt;Agency&gt;\&lt;ProductName&gt;\&lt;MajorEdition&gt;\&lt;MinorEdition&gt;\&lt;S57Product&gt;, &lt;Referenced Files&gt;. This is the default.</para>
		/// <para>PRODUCT_LAYOUT—The exchange set will be written in the format ENC_ROOT\CATALOG.031, ENC_ROOT\&lt;ProductName&gt;\&lt;S57Product&gt;, &lt;Referenced Files&gt;.</para>
		/// <para>FLAT_LAYOUT—The exchange set will be written in the format ENC_ROOT\CATALOG.031, &lt;S57Product(s)&gt;, &lt;Referenced Files&gt;.</para>
		/// <para><see cref="LayoutFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LayoutFormat { get; set; } = "VERSION_LAYOUT";

		/// <summary>
		/// <para>Updates Only</para>
		/// <para>Specifies how S-57 update datasets in the input folder will be processed.</para>
		/// <para>Checked—The output exchange set will include all the updates but not the S-57 base dataset. If there are no updates, the output will include the S-57 base dataset.</para>
		/// <para>Unchecked—The output exchange set will include the S-57 base dataset and any update datasets. This is the default.An S-57 base dataset is required in the input folder when creating an update exchange set.</para>
		/// <para><see cref="UpdatesOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UpdatesOnly { get; set; }

		/// <summary>
		/// <para>S-57 Exchange Set Directory</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object DerivedOutDirectory { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateS57ExchangeSet SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Layout Format</para>
		/// </summary>
		public enum LayoutFormatEnum 
		{
			/// <summary>
			/// <para>VERSION_LAYOUT— The exchange set will be written in the format ENC_ROOT\CATALOG.031, ENC_ROOT\&lt;Agency&gt;\&lt;ProductName&gt;\&lt;MajorEdition&gt;\&lt;MinorEdition&gt;\&lt;S57Product&gt;, &lt;Referenced Files&gt;. This is the default.</para>
			/// </summary>
			[GPValue("VERSION_LAYOUT")]
			[Description("VERSION_LAYOUT")]
			VERSION_LAYOUT,

			/// <summary>
			/// <para>PRODUCT_LAYOUT—The exchange set will be written in the format ENC_ROOT\CATALOG.031, ENC_ROOT\&lt;ProductName&gt;\&lt;S57Product&gt;, &lt;Referenced Files&gt;.</para>
			/// </summary>
			[GPValue("PRODUCT_LAYOUT")]
			[Description("PRODUCT_LAYOUT")]
			PRODUCT_LAYOUT,

			/// <summary>
			/// <para>FLAT_LAYOUT—The exchange set will be written in the format ENC_ROOT\CATALOG.031, &lt;S57Product(s)&gt;, &lt;Referenced Files&gt;.</para>
			/// </summary>
			[GPValue("FLAT_LAYOUT")]
			[Description("FLAT_LAYOUT")]
			FLAT_LAYOUT,

		}

		/// <summary>
		/// <para>Updates Only</para>
		/// </summary>
		public enum UpdatesOnlyEnum 
		{
			/// <summary>
			/// <para>Checked—The output exchange set will include all the updates but not the S-57 base dataset. If there are no updates, the output will include the S-57 base dataset.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_ONLY_UPDATES")]
			INCLUDE_ONLY_UPDATES,

			/// <summary>
			/// <para>Unchecked—The output exchange set will include the S-57 base dataset and any update datasets. This is the default.An S-57 base dataset is required in the input folder when creating an update exchange set.</para>
			/// </summary>
			[GPValue("false")]
			[Description("INCLUDE_ALL")]
			INCLUDE_ALL,

		}

#endregion
	}
}
