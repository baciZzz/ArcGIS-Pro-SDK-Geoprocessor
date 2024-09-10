using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MultidimensionTools
{
	/// <summary>
	/// <para>Build Multidimensional Info</para>
	/// <para>Generates multidimensional metadata in the mosaic dataset, including information regarding variables and dimensions.</para>
	/// </summary>
	public class BuildMultidimensionalInfo : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The input multidimensional mosaic dataset.</para>
		/// </param>
		public BuildMultidimensionalInfo(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Build Multidimensional Info</para>
		/// </summary>
		public override string DisplayName() => "Build Multidimensional Info";

		/// <summary>
		/// <para>Tool Name : BuildMultidimensionalInfo</para>
		/// </summary>
		public override string ToolName() => "BuildMultidimensionalInfo";

		/// <summary>
		/// <para>Tool Excute Name : md.BuildMultidimensionalInfo</para>
		/// </summary>
		public override string ExcuteName() => "md.BuildMultidimensionalInfo";

		/// <summary>
		/// <para>Toolbox Display Name : Multidimension Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Multidimension Tools";

		/// <summary>
		/// <para>Toolbox Alise : md</para>
		/// </summary>
		public override string ToolboxAlise() => "md";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, VariableField, DimensionFields, VariableDescUnits, OutMosaicDataset, DeleteMultidimensionalInfo };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The input multidimensional mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Variable Field</para>
		/// <para>The field in the mosaic dataset that stores the variable names and is used to populate a new field named Variable. If all rasters in the mosaic dataset represent the same variable, type the name of the variable, for example, Temperature.</para>
		/// <para>If the Variable field does not already exist, an existing field or string value must be specified. If the Variable field exists, the tool will update the multidimensional information only.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object VariableField { get; set; }

		/// <summary>
		/// <para>Dimension Fields</para>
		/// <para>The fields in the mosaic dataset that store the dimension information and are used to populate a new field named Dimensions.</para>
		/// <para>If the Dimensions field already exists, the tool will update the multidimensional information only.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object DimensionFields { get; set; }

		/// <summary>
		/// <para>Variable Info</para>
		/// <para>Specify additional information about the Variable field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object VariableDescUnits { get; set; }

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMosaicLayer()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Delete Multidimensional Info</para>
		/// <para>Specifies whether existing multidimensional information will be deleted.</para>
		/// <para>Unchecked—If multidimensional information exists in the mosaic dataset, it will not be deleted. This is the default.</para>
		/// <para>Checked—If multidimensional information exists in the mosaic dataset, it will be deleted.</para>
		/// <para><see cref="DeleteMultidimensionalInfoEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DeleteMultidimensionalInfo { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Delete Multidimensional Info</para>
		/// </summary>
		public enum DeleteMultidimensionalInfoEnum 
		{
			/// <summary>
			/// <para>Checked—If multidimensional information exists in the mosaic dataset, it will be deleted.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_MULTIDIMENSIONAL_INFO")]
			DELETE_MULTIDIMENSIONAL_INFO,

			/// <summary>
			/// <para>Unchecked—If multidimensional information exists in the mosaic dataset, it will not be deleted. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_MULTIDIMENSIONAL_INFO")]
			NO_DELETE_MULTIDIMENSIONAL_INFO,

		}

#endregion
	}
}
