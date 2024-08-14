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
	/// <para>Validate S-57 File</para>
	/// <para>Validates an ENC or IENC file and generates an .S58 file as a result.</para>
	/// </summary>
	public class ValidateS57File : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InS57File">
		/// <para>Input S-57 File</para>
		/// <para>The base cell file (*.000).</para>
		/// </param>
		/// <param name="OutDirectory">
		/// <para>Output Directory</para>
		/// <para>The location where the validated S-57 log will be created.</para>
		/// </param>
		public ValidateS57File(object InS57File, object OutDirectory)
		{
			this.InS57File = InS57File;
			this.OutDirectory = OutDirectory;
		}

		/// <summary>
		/// <para>Tool Display Name : Validate S-57 File</para>
		/// </summary>
		public override string DisplayName => "Validate S-57 File";

		/// <summary>
		/// <para>Tool Name : ValidateS57File</para>
		/// </summary>
		public override string ToolName => "ValidateS57File";

		/// <summary>
		/// <para>Tool Excute Name : maritime.ValidateS57File</para>
		/// </summary>
		public override string ExcuteName => "maritime.ValidateS57File";

		/// <summary>
		/// <para>Toolbox Display Name : Maritime Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Maritime Tools";

		/// <summary>
		/// <para>Toolbox Alise : maritime</para>
		/// </summary>
		public override string ToolboxAlise => "maritime";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InS57File, OutDirectory, InUpdateCells!, RegionalRules!, InIgnoreList!, OutLogFile! };

		/// <summary>
		/// <para>Input S-57 File</para>
		/// <para>The base cell file (*.000).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object InS57File { get; set; }

		/// <summary>
		/// <para>Output Directory</para>
		/// <para>The location where the validated S-57 log will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutDirectory { get; set; }

		/// <summary>
		/// <para>Update Cells</para>
		/// <para>The update cell files (*.001 - *.999).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFileDomain()]
		public object? InUpdateCells { get; set; }

		/// <summary>
		/// <para>Regional Rules</para>
		/// <para>For IENC cells, some validation rules don&apos;t apply in certain regions, or they check for different objects and attribution. The selected region will honor the rules set forth in the Recommended Inland ENC Validation Checks for that region.</para>
		/// <para>Brazil—Brazilian validation rules apply.</para>
		/// <para>Europe—European validation rules apply.</para>
		/// <para>Russian Federation—Russian Federation validation rules apply.</para>
		/// <para>United States—United States validation rules apply.</para>
		/// <para><see cref="RegionalRulesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RegionalRules { get; set; }

		/// <summary>
		/// <para>Ignore List</para>
		/// <para>A text file containing a list of checks to ignore in the output log file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object? InIgnoreList { get; set; }

		/// <summary>
		/// <para>Output S-58 Log File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutLogFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ValidateS57File SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Regional Rules</para>
		/// </summary>
		public enum RegionalRulesEnum 
		{
			/// <summary>
			/// <para>Brazil—Brazilian validation rules apply.</para>
			/// </summary>
			[GPValue("BR")]
			[Description("Brazil")]
			Brazil,

			/// <summary>
			/// <para>Europe—European validation rules apply.</para>
			/// </summary>
			[GPValue("EU")]
			[Description("Europe")]
			Europe,

			/// <summary>
			/// <para>Russian Federation—Russian Federation validation rules apply.</para>
			/// </summary>
			[GPValue("RU")]
			[Description("Russian Federation")]
			Russian_Federation,

			/// <summary>
			/// <para>United States—United States validation rules apply.</para>
			/// </summary>
			[GPValue("US")]
			[Description("United States")]
			United_States,

		}

#endregion
	}
}
