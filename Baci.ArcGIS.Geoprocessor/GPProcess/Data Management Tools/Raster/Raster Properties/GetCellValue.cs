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
	/// <para>Retrieves the value of a given pixel using its x, y coordinates.</para>
	/// </summary>
	public class GetCellValue : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster that you want to query.</para>
		/// </param>
		/// <param name="LocationPoint">
		/// <para>Location</para>
		/// <para>The X and Y coordinates of the pixel location.</para>
		/// </param>
		public GetCellValue(object InRaster, object LocationPoint)
		{
			this.InRaster = InRaster;
			this.LocationPoint = LocationPoint;
		}

		/// <summary>
		/// <para>Tool Display Name : Get Cell Value</para>
		/// </summary>
		public override string DisplayName => "Get Cell Value";

		/// <summary>
		/// <para>Tool Name : GetCellValue</para>
		/// </summary>
		public override string ToolName => "GetCellValue";

		/// <summary>
		/// <para>Tool Excute Name : management.GetCellValue</para>
		/// </summary>
		public override string ExcuteName => "management.GetCellValue";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, LocationPoint, BandIndex, OutString };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster that you want to query.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Location</para>
		/// <para>The X and Y coordinates of the pixel location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPPoint()]
		public object LocationPoint { get; set; }

		/// <summary>
		/// <para>Bands</para>
		/// <para>Specify the bands that you want to query. Leave blank to query all bands in a multiband dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object BandIndex { get; set; }

		/// <summary>
		/// <para>Pixel Value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutString { get; set; }

	}
}
