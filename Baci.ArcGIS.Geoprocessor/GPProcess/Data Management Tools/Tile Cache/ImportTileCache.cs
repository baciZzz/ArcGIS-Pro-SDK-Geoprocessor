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
	/// <para>Import Tile Cache</para>
	/// <para>导入切片缓存</para>
	/// <para>从现有切片缓存或切片包中导入切片。目标缓存必须与源切片缓存具有相同的切片方案、空间参考和存储格式。</para>
	/// </summary>
	public class ImportTileCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCacheTarget">
		/// <para>Target Tile Cache</para>
		/// <para>即将导入切片的现有切片缓存。</para>
		/// </param>
		/// <param name="InCacheSource">
		/// <para>Source Tile Cache</para>
		/// <para>即将从其中导入切片的现有切片缓存或切片包。</para>
		/// </param>
		public ImportTileCache(object InCacheTarget, object InCacheSource)
		{
			this.InCacheTarget = InCacheTarget;
			this.InCacheSource = InCacheSource;
		}

		/// <summary>
		/// <para>Tool Display Name : 导入切片缓存</para>
		/// </summary>
		public override string DisplayName() => "导入切片缓存";

		/// <summary>
		/// <para>Tool Name : ImportTileCache</para>
		/// </summary>
		public override string ToolName() => "ImportTileCache";

		/// <summary>
		/// <para>Tool Excute Name : management.ImportTileCache</para>
		/// </summary>
		public override string ExcuteName() => "management.ImportTileCache";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCacheTarget, InCacheSource, Scales, AreaOfInterest, Overwrite, OutTileCache };

		/// <summary>
		/// <para>Target Tile Cache</para>
		/// <para>即将导入切片的现有切片缓存。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InCacheTarget { get; set; }

		/// <summary>
		/// <para>Source Tile Cache</para>
		/// <para>即将从其中导入切片的现有切片缓存或切片包。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InCacheSource { get; set; }

		/// <summary>
		/// <para>Scales [Pixel Size] (Estimated Disk Space)</para>
		/// <para>导入切片时使用的比例级别列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Scales { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>感兴趣区域将对切片在缓存中的导入位置施加空间约束。</para>
		/// <para>该参数用于为形状不规则的区域导入切片。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Overwrite Tiles</para>
		/// <para>确定目标缓存中的图像是与原始缓存中的切片合并，还是被其覆盖。</para>
		/// <para>未选中 - 导入切片后，默认情况下将忽略原始缓存中的透明像素。将导致目标缓存中的图像合并或混合。这是默认设置。</para>
		/// <para>选中 - 导入过程会替换感兴趣区域的所有像素，并用原始缓存中的切片有效覆盖目标缓存中的切片。</para>
		/// <para><see cref="OverwriteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Overwrite { get; set; } = "false";

		/// <summary>
		/// <para>Updated Target Tile Cache</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object OutTileCache { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportTileCache SetEnviroment(object parallelProcessingFactor = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Overwrite Tiles</para>
		/// </summary>
		public enum OverwriteEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERWRITE")]
			OVERWRITE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("MERGE")]
			MERGE,

		}

#endregion
	}
}
