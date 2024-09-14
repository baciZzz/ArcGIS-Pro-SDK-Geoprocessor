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
	/// <para>Check Geometry</para>
	/// <para>检查几何</para>
	/// <para>生成要素类中几何问题的报告。</para>
	/// </summary>
	public class CheckGeometry : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要检查是否存在几何问题的一个或多个要素类或要素图层。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>所发现问题的报告（作为表的形式）。</para>
		/// </param>
		public CheckGeometry(object InFeatures, object OutTable)
		{
			this.InFeatures = InFeatures;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 检查几何</para>
		/// </summary>
		public override string DisplayName() => "检查几何";

		/// <summary>
		/// <para>Tool Name : CheckGeometry</para>
		/// </summary>
		public override string ToolName() => "CheckGeometry";

		/// <summary>
		/// <para>Tool Excute Name : management.CheckGeometry</para>
		/// </summary>
		public override string ExcuteName() => "management.CheckGeometry";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutTable, ValidationMethod };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要检查是否存在几何问题的一个或多个要素类或要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>所发现问题的报告（作为表的形式）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Validation Method</para>
		/// <para>指定用于识别几何问题的几何验证方法。</para>
		/// <para>Esri—将使用 Esri 几何验证方法。这是默认设置。</para>
		/// <para>OGC— 将使用开放地理空间联盟 (OGC) 几何验证方法。</para>
		/// <para><see cref="ValidationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ValidationMethod { get; set; } = "ESRI";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CheckGeometry SetEnviroment(object configKeyword = null, object extent = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(configKeyword: configKeyword, extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Validation Method</para>
		/// </summary>
		public enum ValidationMethodEnum 
		{
			/// <summary>
			/// <para>Esri—将使用 Esri 几何验证方法。这是默认设置。</para>
			/// </summary>
			[GPValue("ESRI")]
			[Description("Esri")]
			Esri,

			/// <summary>
			/// <para>OGC— 将使用开放地理空间联盟 (OGC) 几何验证方法。</para>
			/// </summary>
			[GPValue("OGC")]
			[Description("OGC")]
			OGC,

		}

#endregion
	}
}
