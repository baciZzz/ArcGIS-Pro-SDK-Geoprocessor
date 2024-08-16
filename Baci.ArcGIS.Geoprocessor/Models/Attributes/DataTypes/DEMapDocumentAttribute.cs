using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>ArcMap Document</para>
	/// <para>ArcMap 文档</para>
	/// <para>A file that contains one map, its layout, and its associated layers, tables, charts, and reports.</para>
	/// <para>包含一个地图、它的布局以及它的关联图层、表格、图表和报表的文件。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DEMapDocumentAttribute : BaseDataTypeAttribute
	{

	}
}
