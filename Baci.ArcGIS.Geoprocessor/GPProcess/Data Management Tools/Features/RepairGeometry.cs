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
	/// <para>Repair Geometry</para>
	/// <para>修复几何</para>
	/// <para>检查要素的几何问题并修复它们。 如发现问题，将对其执行修复，并将通过一行描述识别要素及修复的几何问题。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RepairGeometry : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>将处理的要素类或图层。</para>
		/// <para>Desktop Basic 许可仅允许存储在文件地理数据库、GeoPackage 或 SpatiaLite 数据库中的 shapefile 和要素类作为有效的输入要素格式。 Desktop Standard 或 Desktop Advanced 许可额外允许存储在企业级数据库或企业级地理数据库中的要素类作为有效的输入要素格式使用。</para>
		/// </param>
		public RepairGeometry(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 修复几何</para>
		/// </summary>
		public override string DisplayName() => "修复几何";

		/// <summary>
		/// <para>Tool Name : RepairGeometry</para>
		/// </summary>
		public override string ToolName() => "RepairGeometry";

		/// <summary>
		/// <para>Tool Excute Name : management.RepairGeometry</para>
		/// </summary>
		public override string ExcuteName() => "management.RepairGeometry";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, DeleteNull!, OutFeatureClass!, ValidationMethod! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将处理的要素类或图层。</para>
		/// <para>Desktop Basic 许可仅允许存储在文件地理数据库、GeoPackage 或 SpatiaLite 数据库中的 shapefile 和要素类作为有效的输入要素格式。 Desktop Standard 或 Desktop Advanced 许可额外允许存储在企业级数据库或企业级地理数据库中的要素类作为有效的输入要素格式使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Delete Features with Null Geometry</para>
		/// <para>指定是否删除几何为空的要素。</para>
		/// <para>选中 - 将从输入中删除几何为空的要素。 这是默认设置。</para>
		/// <para>未选中 - 不从输入中删除几何为空的要素。</para>
		/// <para>对于存储在企业级数据库、企业级地理数据库、GeoPackage 或 SpatiaLite 数据库中的数据，删除几何为空的要素不可用。</para>
		/// <para><see cref="DeleteNullEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeleteNull { get; set; } = "true";

		/// <summary>
		/// <para>Repaired Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Validation Method</para>
		/// <para>指定用于识别几何问题的几何验证方法。</para>
		/// <para>Esri—将使用 Esri 几何验证方法。 这是默认设置。</para>
		/// <para>OGC—将使用 OGC 几何验证方法。</para>
		/// <para><see cref="ValidationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ValidationMethod { get; set; } = "ESRI";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RepairGeometry SetEnviroment(object? extent = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Delete Features with Null Geometry</para>
		/// </summary>
		public enum DeleteNullEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_NULL")]
			DELETE_NULL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_NULL")]
			KEEP_NULL,

		}

		/// <summary>
		/// <para>Validation Method</para>
		/// </summary>
		public enum ValidationMethodEnum 
		{
			/// <summary>
			/// <para>Esri—将使用 Esri 几何验证方法。 这是默认设置。</para>
			/// </summary>
			[GPValue("ESRI")]
			[Description("Esri")]
			Esri,

			/// <summary>
			/// <para>OGC—将使用 OGC 几何验证方法。</para>
			/// </summary>
			[GPValue("OGC")]
			[Description("OGC")]
			OGC,

		}

#endregion
	}
}
