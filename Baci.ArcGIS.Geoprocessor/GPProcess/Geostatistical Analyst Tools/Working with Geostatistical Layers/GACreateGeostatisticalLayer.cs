using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>Create Geostatistical Layer</para>
	/// <para>创建地统计图层</para>
	/// <para>创建新的地统计图层。要为新图层填充初始值，需要使用现有的地统计图层。</para>
	/// </summary>
	public class GACreateGeostatisticalLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGaModelSource">
		/// <para>Input geostatistical model source</para>
		/// <para>要分析的地统计模型源。</para>
		/// </param>
		/// <param name="InDatasets">
		/// <para>Input dataset(s)</para>
		/// <para>用于创建输出图层的输入数据集的名称和字段名称。</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output geostatistical layer</para>
		/// <para>由该工具生成的地统计图层。</para>
		/// </param>
		public GACreateGeostatisticalLayer(object InGaModelSource, object InDatasets, object OutLayer)
		{
			this.InGaModelSource = InGaModelSource;
			this.InDatasets = InDatasets;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建地统计图层</para>
		/// </summary>
		public override string DisplayName() => "创建地统计图层";

		/// <summary>
		/// <para>Tool Name : GACreateGeostatisticalLayer</para>
		/// </summary>
		public override string ToolName() => "GACreateGeostatisticalLayer";

		/// <summary>
		/// <para>Tool Excute Name : ga.GACreateGeostatisticalLayer</para>
		/// </summary>
		public override string ExcuteName() => "ga.GACreateGeostatisticalLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise() => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "coincidentPoints", "extent", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGaModelSource, InDatasets, OutLayer };

		/// <summary>
		/// <para>Input geostatistical model source</para>
		/// <para>要分析的地统计模型源。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InGaModelSource { get; set; }

		/// <summary>
		/// <para>Input dataset(s)</para>
		/// <para>用于创建输出图层的输入数据集的名称和字段名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGAValueTable()]
		public object InDatasets { get; set; }

		/// <summary>
		/// <para>Output geostatistical layer</para>
		/// <para>由该工具生成的地统计图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GACreateGeostatisticalLayer SetEnviroment(object coincidentPoints = null, object extent = null, object parallelProcessingFactor = null, object workspace = null)
		{
			base.SetEnv(coincidentPoints: coincidentPoints, extent: extent, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

	}
}
