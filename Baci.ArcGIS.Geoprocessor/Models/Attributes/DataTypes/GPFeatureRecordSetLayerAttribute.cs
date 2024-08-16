using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes
{
	/// <summary>
	/// <para>Feature Set</para>
	/// <para>要素集</para>
	/// <para>Interactive features that draw the features when the tool is run.</para>
	/// <para>工具运行时绘制要素的交互式要素。</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class GPFeatureRecordSetLayerAttribute : BaseDataTypeAttribute
	{

	}
}
