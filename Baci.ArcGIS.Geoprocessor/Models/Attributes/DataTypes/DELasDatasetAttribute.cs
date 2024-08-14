using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>LAS Dataset</para>
	/// <para>LAS 数据集</para>
	/// <para>A LAS dataset stores reference to one or more LAS files on disk as well as to additional surface features. A LAS file is a binary file that stores airborne lidar data.</para>
	/// <para>LAS 数据集存储对磁盘上一个或多个 LAS 文件以及其他表面要素的引用。 LAS 文件是一个二进制文件，存储机载激光雷达数据。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DELasDatasetAttribute : DataTypeAttribute
	{

	}
}
