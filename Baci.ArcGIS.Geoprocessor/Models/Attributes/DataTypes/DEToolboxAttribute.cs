using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Toolbox</para>
	/// <para>工具箱</para>
	/// <para>A geoprocessing toolbox.</para>
	/// <para>地理处理工具箱。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DEToolboxAttribute : BaseDataTypeAttribute
	{

	}
}
