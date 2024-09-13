using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Encrypted String</para>
	/// <para>加密字符串</para>
	/// <para>Encrypted string for passwords.</para>
	/// <para>密码加密的字符串。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPEncryptedStringAttribute : BaseDataTypeAttribute
	{

	}
}
