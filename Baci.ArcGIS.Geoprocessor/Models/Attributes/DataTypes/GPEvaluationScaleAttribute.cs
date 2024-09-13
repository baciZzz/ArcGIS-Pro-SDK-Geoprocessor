using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Evaluation Scale</para>
	/// <para>评估等级</para>
	/// <para>The scale value range and increment value applied to inputs in a weighted overlay operation.</para>
	/// <para>加权叠加操作中应用于输入值的级别值范围和增量值。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPEvaluationScaleAttribute : BaseDataTypeAttribute
	{

	}
}
