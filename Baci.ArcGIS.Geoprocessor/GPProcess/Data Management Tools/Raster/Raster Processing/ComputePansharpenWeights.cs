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
	/// <para>Compute Pansharpen Weights</para>
	/// <para>计算全色锐化权重</para>
	/// <para>为新的或自定义的传感器数据计算一组最佳的全色锐化权重。</para>
	/// </summary>
	public class ComputePansharpenWeights : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>具有全色波段的多光谱栅格。</para>
		/// </param>
		/// <param name="InPanchromaticImage">
		/// <para>Panchromatic Image</para>
		/// <para>与多光谱栅格相关联的全色波段。</para>
		/// </param>
		public ComputePansharpenWeights(object InRaster, object InPanchromaticImage)
		{
			this.InRaster = InRaster;
			this.InPanchromaticImage = InPanchromaticImage;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算全色锐化权重</para>
		/// </summary>
		public override string DisplayName() => "计算全色锐化权重";

		/// <summary>
		/// <para>Tool Name : ComputePansharpenWeights</para>
		/// </summary>
		public override string ToolName() => "ComputePansharpenWeights";

		/// <summary>
		/// <para>Tool Excute Name : management.ComputePansharpenWeights</para>
		/// </summary>
		public override string ExcuteName() => "management.ComputePansharpenWeights";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, InPanchromaticImage, BandIndexes!, OutString! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>具有全色波段的多光谱栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Panchromatic Image</para>
		/// <para>与多光谱栅格相关联的全色波段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InPanchromaticImage { get; set; }

		/// <summary>
		/// <para>Band Indexes</para>
		/// <para>全色锐化权重的波段顺序。</para>
		/// <para>如果将栅格产品用作输入栅格，则应用栅格产品模板中的波段顺序。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? BandIndexes { get; set; }

		/// <summary>
		/// <para>Pan-sharpened Weights</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutString { get; set; }

	}
}
