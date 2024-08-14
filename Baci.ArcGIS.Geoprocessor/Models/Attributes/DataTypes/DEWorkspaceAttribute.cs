using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Workspace</para>
	/// <para>工作空间</para>
	/// <para>A container such as a geodatabase or folder.</para>
	/// <para>容器，例如地理数据库或文件夹。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DEWorkspaceAttribute : DataTypeAttribute
	{

	}
}
