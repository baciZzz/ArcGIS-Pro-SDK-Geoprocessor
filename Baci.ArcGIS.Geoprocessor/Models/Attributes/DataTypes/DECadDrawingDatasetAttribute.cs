using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>CAD Drawing Dataset</para>
	/// <para>CAD 工程图数据集</para>
	/// <para>A vector data source mixed with feature types and symbology. The dataset is not usable for feature class-based queries or analysis.</para>
	/// <para>与多种要素类型和符号系统混合的矢量数据源。 此数据集不适用于基于要素类的查询或分析。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DECadDrawingDatasetAttribute : BaseDataTypeAttribute
	{

	}
}
