using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Get Cell Value</para>
	/// <para>获取像元值</para>
	/// <para>使用 x，y 坐标获取给定像素的值。</para>
	/// </summary>
	public class GetCellValue : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>要查询的栅格。</para>
		/// </param>
		/// <param name="LocationPoint">
		/// <para>Location</para>
		/// <para>像素位置的 x 和 y 坐标。</para>
		/// </param>
		public GetCellValue(object InRaster, object LocationPoint)
		{
			this.InRaster = InRaster;
			this.LocationPoint = LocationPoint;
		}

		/// <summary>
		/// <para>Tool Display Name : 获取像元值</para>
		/// </summary>
		public override string DisplayName() => "获取像元值";

		/// <summary>
		/// <para>Tool Name : GetCellValue</para>
		/// </summary>
		public override string ToolName() => "GetCellValue";

		/// <summary>
		/// <para>Tool Excute Name : management.GetCellValue</para>
		/// </summary>
		public override string ExcuteName() => "management.GetCellValue";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, LocationPoint, BandIndex!, OutString! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>要查询的栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Location</para>
		/// <para>像素位置的 x 和 y 坐标。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPPoint()]
		public object LocationPoint { get; set; }

		/// <summary>
		/// <para>Bands</para>
		/// <para>指定要查询的波段。留空以查询多波段数据集中的所有波段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? BandIndex { get; set; }

		/// <summary>
		/// <para>Pixel Value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutString { get; set; }

	}
}
