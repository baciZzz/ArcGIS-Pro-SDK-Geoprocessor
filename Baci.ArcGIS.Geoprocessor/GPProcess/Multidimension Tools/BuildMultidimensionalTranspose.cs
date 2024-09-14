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
	/// <para>Build Multidimensional Transpose</para>
	/// <para>Build Multidimensional Transpose</para>
	/// <para>Transposes a multidimensional raster dataset, which divides the  multidimensional data along each dimension to optimize performance when accessing pixel values across all slices.</para>
	/// </summary>
	public class BuildMultidimensionalTranspose : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultidimensionalRaster">
		/// <para>Input Multidimensional Raster</para>
		/// <para>The input CRF multidimensional raster dataset.</para>
		/// </param>
		public BuildMultidimensionalTranspose(object InMultidimensionalRaster)
		{
			this.InMultidimensionalRaster = InMultidimensionalRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Build Multidimensional Transpose</para>
		/// </summary>
		public override string DisplayName() => "Build Multidimensional Transpose";

		/// <summary>
		/// <para>Tool Name : BuildMultidimensionalTranspose</para>
		/// </summary>
		public override string ToolName() => "BuildMultidimensionalTranspose";

		/// <summary>
		/// <para>Tool Excute Name : md.BuildMultidimensionalTranspose</para>
		/// </summary>
		public override string ExcuteName() => "md.BuildMultidimensionalTranspose";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMultidimensionalRaster, UpdatedMultidimensionalRaster, DeleteTranspose };

		/// <summary>
		/// <para>Input Multidimensional Raster</para>
		/// <para>The input CRF multidimensional raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Output Multidimensional Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object UpdatedMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Delete Transpose</para>
		/// <para>Specifies whether an existing transpose will be deleted.</para>
		/// <para>Unchecked—If a transpose exists, it will be overwritten by the newly built transpose. This is the default.</para>
		/// <para>Checked—If a transpose exists, it will be deleted and no new transpose will be built.</para>
		/// <para><see cref="DeleteTransposeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DeleteTranspose { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildMultidimensionalTranspose SetEnviroment(object parallelProcessingFactor = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Delete Transpose</para>
		/// </summary>
		public enum DeleteTransposeEnum 
		{
			/// <summary>
			/// <para>Checked—If a transpose exists, it will be deleted and no new transpose will be built.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_TRANSPOSE")]
			DELETE_TRANSPOSE,

			/// <summary>
			/// <para>Unchecked—If a transpose exists, it will be overwritten by the newly built transpose. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_TRANSPOSE")]
			NO_DELETE_TRANSPOSE,

		}

#endregion
	}
}
