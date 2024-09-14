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
	/// <para>Convert S-57 to S-101 Cell</para>
	/// <para>Convert S-57 to S-101 Cell</para>
	/// <para>Converts the S-57 vector product for storing nautical charting data to the new vector S-101 format.</para>
	/// </summary>
	public class ConvertS57ToS101 : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureCatalogue">
		/// <para>S-100 Feature Catalogue</para>
		/// <para>The S-101 feature catalogue (XML document) from the International Hydrographic Organization (IHO) containing the schema of the features, attributes, and relationships used for encoding the hydrographic data in the S-101 cells.</para>
		/// </param>
		/// <param name="InConfigFile">
		/// <para>Configuration File</para>
		/// <para>The input XML file that can be used to customize some aspects of the conversion process.</para>
		/// </param>
		/// <param name="InputS57">
		/// <para>Input S-57 (File or Folder)</para>
		/// <para>The input S-57 file with a .000 extension or a CATALOG.031 file that references a collection of S-57 files.</para>
		/// </param>
		/// <param name="OutLocation">
		/// <para>Output Location</para>
		/// <para>The directory where the converted cell will be written.</para>
		/// </param>
		public ConvertS57ToS101(object InFeatureCatalogue, object InConfigFile, object InputS57, object OutLocation)
		{
			this.InFeatureCatalogue = InFeatureCatalogue;
			this.InConfigFile = InConfigFile;
			this.InputS57 = InputS57;
			this.OutLocation = OutLocation;
		}

		/// <summary>
		/// <para>Tool Display Name : Convert S-57 to S-101 Cell</para>
		/// </summary>
		public override string DisplayName() => "Convert S-57 to S-101 Cell";

		/// <summary>
		/// <para>Tool Name : ConvertS57ToS101</para>
		/// </summary>
		public override string ToolName() => "ConvertS57ToS101";

		/// <summary>
		/// <para>Tool Excute Name : maritime.ConvertS57ToS101</para>
		/// </summary>
		public override string ExcuteName() => "maritime.ConvertS57ToS101";

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
		public override string[] ValidEnvironments() => new string[] { "S100FeatureCatalogueFile" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureCatalogue, InConfigFile, InputS57, OutLocation, OutS101! };

		/// <summary>
		/// <para>S-100 Feature Catalogue</para>
		/// <para>The S-101 feature catalogue (XML document) from the International Hydrographic Organization (IHO) containing the schema of the features, attributes, and relationships used for encoding the hydrographic data in the S-101 cells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object InFeatureCatalogue { get; set; }

		/// <summary>
		/// <para>Configuration File</para>
		/// <para>The input XML file that can be used to customize some aspects of the conversion process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object InConfigFile { get; set; } = "C:\\ArcGIS\\Resources\\Maritime\\S57to101Configuration.xml";

		/// <summary>
		/// <para>Input S-57 (File or Folder)</para>
		/// <para>The input S-57 file with a .000 extension or a CATALOG.031 file that references a collection of S-57 files.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InputS57 { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The directory where the converted cell will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutLocation { get; set; }

		/// <summary>
		/// <para>Output S-101 Data</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutS101 { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConvertS57ToS101 SetEnviroment(object? S100FeatureCatalogueFile = null)
		{
			base.SetEnv(S100FeatureCatalogueFile: S100FeatureCatalogueFile);
			return this;
		}

	}
}
