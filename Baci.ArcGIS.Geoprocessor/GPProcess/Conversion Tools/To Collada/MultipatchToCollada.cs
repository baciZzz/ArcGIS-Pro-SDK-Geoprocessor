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
	/// <para>Multipatch To Collada</para>
	/// <para>Converts one or more multipatch features into a collection of COLLADA (.dae) files and referenced texture image files in an output folder. The inputs can be a layer or a feature class.</para>
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
		/// <para>Output Collada Folder</para>
		/// <para>The destination folder where the output COLLADA files and texture image files will be placed.</para>
		/// </param>
		public MultipatchToCollada(object InFeatures, object OutputFolder)
		{
			this.InFeatures = InFeatures;
			this.OutputFolder = OutputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Multipatch To Collada</para>
		/// </summary>
		public override string DisplayName() => "Multipatch To Collada";

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
		public override object[] Parameters() => new object[] { InFeatures, OutputFolder, PrependSource, FieldName };

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
		/// <para>Output Collada Folder</para>
		/// <para>The destination folder where the output COLLADA files and texture image files will be placed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Prepend Source Name</para>
		/// <para>Prepend the file names of the output COLLADA files with the name of the source feature layer.</para>
		/// <para>Checked—Prepend the file names.</para>
		/// <para>Unchecked—Do not prepend the file names. This is the default.</para>
		/// <para><see cref="PrependSourceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PrependSource { get; set; } = "false";

		/// <summary>
		/// <para>Use Field Name</para>
		/// <para>The feature attribute to use as the output COLLADA file name for each exported feature. If no field is specified, the feature's Object ID is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("OID", "Text", "Short", "Long")]
		public object FieldName { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Prepend Source Name</para>
		/// </summary>
		public enum PrependSourceEnum 
		{
			/// <summary>
			/// <para>Checked—Prepend the file names.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PREPEND_SOURCE_NAME")]
			PREPEND_SOURCE_NAME,

			/// <summary>
			/// <para>Unchecked—Do not prepend the file names. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("PREPEND_NONE")]
			PREPEND_NONE,

		}

#endregion
	}
}
