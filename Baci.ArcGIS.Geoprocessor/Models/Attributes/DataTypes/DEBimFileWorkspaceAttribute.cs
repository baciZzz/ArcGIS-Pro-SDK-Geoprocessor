using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>BIM File Workspace</para>
	/// <para>BIM 文件工作空间</para>
	/// <para>Spatial data in Revit file format.</para>
	/// <para>Revit 文件格式的空间数据。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DEBimFileWorkspaceAttribute : BaseDataTypeAttribute
	{

	}
}
