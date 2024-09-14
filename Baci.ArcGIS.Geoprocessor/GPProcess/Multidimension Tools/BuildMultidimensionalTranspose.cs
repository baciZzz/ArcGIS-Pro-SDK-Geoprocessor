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
	/// <para>构建多维转置</para>
	/// <para>转置多维栅格数据集，以沿着每个维度对多维数据进行划分，从而优化访问所有剖切的像素值时的性能。</para>
	/// </summary>
	public class BuildMultidimensionalTranspose : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultidimensionalRaster">
		/// <para>Input Multidimensional Raster</para>
		/// <para>输入 CRF 多维栅格数据集。</para>
		/// </param>
		public BuildMultidimensionalTranspose(object InMultidimensionalRaster)
		{
			this.InMultidimensionalRaster = InMultidimensionalRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 构建多维转置</para>
		/// </summary>
		public override string DisplayName() => "构建多维转置";

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
		/// <para>输入 CRF 多维栅格数据集。</para>
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
		/// <para>指定是否将删除现有转置。</para>
		/// <para>未选中 - 如果存在转置，则该转置将被新构建的转置覆盖。这是默认设置。</para>
		/// <para>选中 - 如果存在转置，则该转置将被删除且不会构建新的转置。</para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_TRANSPOSE")]
			DELETE_TRANSPOSE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_TRANSPOSE")]
			NO_DELETE_TRANSPOSE,

		}

#endregion
	}
}
