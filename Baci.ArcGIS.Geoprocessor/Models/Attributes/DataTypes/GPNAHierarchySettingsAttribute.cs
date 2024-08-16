using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Network Analyst Hierarchy Settings</para>
	/// <para>Network Analyst 等级设置</para>
	/// <para>A hierarchy attribute that divides hierarchy values of a network dataset into three groups using two integers. The first integer sets the ending value of the first group; the second number sets the beginning value of the third group.</para>
	/// <para>使用两个整数将网络数据集的等级值分成三组的等级属性。 第一个整数设置第一组的结束值；第二个数值设置第三组的起始值。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPNAHierarchySettingsAttribute : BaseDataTypeAttribute
	{

	}
}
