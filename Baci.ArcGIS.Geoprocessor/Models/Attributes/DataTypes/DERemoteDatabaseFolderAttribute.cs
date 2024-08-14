using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Database Connections</para>
	/// <para>数据库连接</para>
	/// <para>The database connection folder in ArcCatalog.</para>
	/// <para>ArcCatalog 中的数据库连接文件夹。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DERemoteDatabaseFolderAttribute : DataTypeAttribute
	{

	}
}
