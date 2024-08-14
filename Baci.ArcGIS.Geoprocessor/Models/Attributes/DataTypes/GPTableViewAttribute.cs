using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Table View</para>
	/// <para>表视图</para>
	/// <para>A representation of tabular data for viewing and editing purposes, stored in memory or on disk.</para>
	/// <para>用于查看和编辑的表格数据表现形式，存储在内存或磁盘中。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPTableViewAttribute : DataTypeAttribute
	{

	}
}
