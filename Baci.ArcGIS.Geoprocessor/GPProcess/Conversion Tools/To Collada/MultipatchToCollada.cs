using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Multipatch To COLLADA</para>
	/// <para>Multipatch To COLLADA</para>
	/// <para>Converts one or more multipatch features into a collection of COLLADA files (.dae) and referenced texture image files in an output folder.</para>
	/// </summary>
	public class MultipatchToCollada : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Multipatch Features</para>
		/// <para>The multipatch features to be exported.</para>
		/// </param>
		/// <param name="OutputFolder">
		/// <para>Output COLLADA Folder</para>
		/// <para>The destination folder where the output COLLADA files and texture image files will be placed.</para>
		/// </param>
		public MultipatchToCollada(object InFeatures, object OutputFolder)
		{
			this.InFeatures = InFeatures;
			this.OutputFolder = OutputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Multipatch To COLLADA</para>
		/// </summary>
		public override string DisplayName() => "Multipatch To COLLADA";

		/// <summary>
		/// <para>Tool Name : MultipatchToCollada</para>
		/// </summary>
		public override string ToolName() => "MultipatchToCollada";

		/// <summary>
		/// <para>Tool Excute Name : conversion.MultipatchToCollada</para>
		/// </summary>
		public override string ExcuteName() => "conversion.MultipatchToCollada";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutputFolder, PrependSource!, FieldName!, ColladaVersion! };

		/// <summary>
		/// <para>Input Multipatch Features</para>
		/// <para>The multipatch features to be exported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output COLLADA Folder</para>
		/// <para>The destination folder where the output COLLADA files and texture image files will be placed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Prepend Source Name</para>
		/// <para>Specifies whether the names of the output COLLADA files will be prepended with the name of the source feature layer.</para>
		/// <para>Checked—The file names will be prepended with the name of the source feature layer.</para>
		/// <para>Unchecked—The file names will not be prepended with the name of the source feature layer. This is the default.</para>
		/// <para><see cref="PrependSourceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? PrependSource { get; set; } = "false";

		/// <summary>
		/// <para>Use Field Name</para>
		/// <para>The feature attribute that will be used as the output COLLADA file name for each exported feature. If no field is specified, the feature's Object ID will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("OID", "Text", "Short", "Long")]
		public object? FieldName { get; set; }

		/// <summary>
		/// <para>COLLADA Version</para>
		/// <para>Specifies the COLLADA version to which the files will be exported.</para>
		/// <para>1.5—Files will be exported to COLLADA version 1.5. Version 1.5 supports the inclusion of georeferencing information and enhanced rendering capabilities. This is the default.</para>
		/// <para>1.4—Files will be exported to COLLADA version 1.4. Version 1.4 is the widely supported standard used in many design related application platforms. Select this version if the COLLADA file will be used on systems that do not support version 1.5.</para>
		/// <para><see cref="ColladaVersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ColladaVersion { get; set; } = "1.5";

		#region InnerClass

		/// <summary>
		/// <para>Prepend Source Name</para>
		/// </summary>
		public enum PrependSourceEnum 
		{
			/// <summary>
			/// <para>Checked—The file names will be prepended with the name of the source feature layer.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PREPEND_SOURCE_NAME")]
			PREPEND_SOURCE_NAME,

			/// <summary>
			/// <para>Unchecked—The file names will not be prepended with the name of the source feature layer. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("PREPEND_NONE")]
			PREPEND_NONE,

		}

		/// <summary>
		/// <para>COLLADA Version</para>
		/// </summary>
		public enum ColladaVersionEnum 
		{
			/// <summary>
			/// <para>1.4—Files will be exported to COLLADA version 1.4. Version 1.4 is the widely supported standard used in many design related application platforms. Select this version if the COLLADA file will be used on systems that do not support version 1.5.</para>
			/// </summary>
			[GPValue("1.4")]
			[Description("1.4")]
			_14,

			/// <summary>
			/// <para>1.5—Files will be exported to COLLADA version 1.5. Version 1.5 supports the inclusion of georeferencing information and enhanced rendering capabilities. This is the default.</para>
			/// </summary>
			[GPValue("1.5")]
			[Description("1.5")]
			_15,

		}

#endregion
	}
}
