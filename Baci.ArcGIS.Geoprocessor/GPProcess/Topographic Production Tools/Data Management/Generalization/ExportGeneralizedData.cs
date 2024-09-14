using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Export Generalized Data</para>
	/// <para>Export Generalized Data</para>
	/// <para>Exports data generalized by the ArcGIS Production Mapping theme-based generalization models into a production schema using generalization rules defined in a Microsoft Excel spreadsheet.</para>
	/// </summary>
	public class ExportGeneralizedData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputGeodatabase">
		/// <para>Input Geodatabase</para>
		/// <para>The geodatabase containing data in the generalization schema.</para>
		/// </param>
		/// <param name="TargetGeodatabase">
		/// <para>Target Geodatabase</para>
		/// <para>The geodatabase where the generalized data will be loaded.</para>
		/// </param>
		/// <param name="RuleFile">
		/// <para>Generalization Rule File</para>
		/// <para>The Excel file containing the generalization rules. This file defines features participating in the generalization process and determines the data that will be loaded and how it is organized. An example rule file is provided in the product file downloads for Defense Mapping and Production Mapping.</para>
		/// </param>
		/// <param name="DataTheme">
		/// <para>Data Theme</para>
		/// <para>A theme that specifies the type of data to be generalized. Available themes are automatically populated from the Generalization Rule File parameter. The values provided in the example rule file are as follows:</para>
		/// <para>TRANS—A data theme that groups features in a transportation network such as roads and railways.</para>
		/// <para>STRUCTURE—A data theme that groups structural features such as buildings.</para>
		/// <para>HYDRO—A data theme that groups water features such as lakes and rivers.</para>
		/// <para>SOE—A skin of the earth data theme that groups polygon features that cover the entire surface of the earth with no holes or gaps. It can consist of water, vegetation, land, and artificial features.</para>
		/// <para>GENERAL—A data theme that groups features other than those defined by another theme.</para>
		/// </param>
		public ExportGeneralizedData(object InputGeodatabase, object TargetGeodatabase, object RuleFile, object DataTheme)
		{
			this.InputGeodatabase = InputGeodatabase;
			this.TargetGeodatabase = TargetGeodatabase;
			this.RuleFile = RuleFile;
			this.DataTheme = DataTheme;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Generalized Data</para>
		/// </summary>
		public override string DisplayName() => "Export Generalized Data";

		/// <summary>
		/// <para>Tool Name : ExportGeneralizedData</para>
		/// </summary>
		public override string ToolName() => "ExportGeneralizedData";

		/// <summary>
		/// <para>Tool Excute Name : topographic.ExportGeneralizedData</para>
		/// </summary>
		public override string ExcuteName() => "topographic.ExportGeneralizedData";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise() => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputGeodatabase, TargetGeodatabase, RuleFile, DataTheme, ExportVisibleFeatures, UpdatedGeodatabase };

		/// <summary>
		/// <para>Input Geodatabase</para>
		/// <para>The geodatabase containing data in the generalization schema.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object InputGeodatabase { get; set; }

		/// <summary>
		/// <para>Target Geodatabase</para>
		/// <para>The geodatabase where the generalized data will be loaded.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object TargetGeodatabase { get; set; }

		/// <summary>
		/// <para>Generalization Rule File</para>
		/// <para>The Excel file containing the generalization rules. This file defines features participating in the generalization process and determines the data that will be loaded and how it is organized. An example rule file is provided in the product file downloads for Defense Mapping and Production Mapping.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xlsx", "xlsm")]
		public object RuleFile { get; set; }

		/// <summary>
		/// <para>Data Theme</para>
		/// <para>A theme that specifies the type of data to be generalized. Available themes are automatically populated from the Generalization Rule File parameter. The values provided in the example rule file are as follows:</para>
		/// <para>TRANS—A data theme that groups features in a transportation network such as roads and railways.</para>
		/// <para>STRUCTURE—A data theme that groups structural features such as buildings.</para>
		/// <para>HYDRO—A data theme that groups water features such as lakes and rivers.</para>
		/// <para>SOE—A skin of the earth data theme that groups polygon features that cover the entire surface of the earth with no holes or gaps. It can consist of water, vegetation, land, and artificial features.</para>
		/// <para>GENERAL—A data theme that groups features other than those defined by another theme.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DataTheme { get; set; }

		/// <summary>
		/// <para>Export only visible features</para>
		/// <para>Specifies whether features with a value of 1 in the visibility field will be exported to the target database.</para>
		/// <para>Checked—Features with the visibility field set to 1 will not be exported.</para>
		/// <para>Unchecked—All featured will be exported, regardless of the value in the visibility field. This is the default.</para>
		/// <para><see cref="ExportVisibleFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExportVisibleFeatures { get; set; }

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object UpdatedGeodatabase { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Export only visible features</para>
		/// </summary>
		public enum ExportVisibleFeaturesEnum 
		{
			/// <summary>
			/// <para>Checked—Features with the visibility field set to 1 will not be exported.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EXPORT_VISIBLE")]
			EXPORT_VISIBLE,

			/// <summary>
			/// <para>Unchecked—All featured will be exported, regardless of the value in the visibility field. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXPORT_ALL")]
			EXPORT_ALL,

		}

#endregion
	}
}
