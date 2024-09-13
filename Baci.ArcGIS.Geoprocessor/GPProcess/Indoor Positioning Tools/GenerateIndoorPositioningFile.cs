using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IndoorPositioningTools
{
	/// <summary>
	/// <para>Generate Indoor Positioning File</para>
	/// <para>生成室内定位文件</para>
	/// <para>根据 ArcGIS IPS Setup 调查记录生成定位文件。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class GenerateIndoorPositioningFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InIpsRecordings">
		/// <para>IPS Recordings Features</para>
		/// <para>包含 ArcGIS IPS Setup 调查记录的要素类或要素服务。</para>
		/// </param>
		/// <param name="TargetIpsPositioning">
		/// <para>Target IPS Positioning Table</para>
		/// <para>将存储生成的 IPS 定位文件的表或要素服务。</para>
		/// </param>
		public GenerateIndoorPositioningFile(object InIpsRecordings, object TargetIpsPositioning)
		{
			this.InIpsRecordings = InIpsRecordings;
			this.TargetIpsPositioning = TargetIpsPositioning;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成室内定位文件</para>
		/// </summary>
		public override string DisplayName() => "生成室内定位文件";

		/// <summary>
		/// <para>Tool Name : GenerateIndoorPositioningFile</para>
		/// </summary>
		public override string ToolName() => "GenerateIndoorPositioningFile";

		/// <summary>
		/// <para>Tool Excute Name : indoorpositioning.GenerateIndoorPositioningFile</para>
		/// </summary>
		public override string ExcuteName() => "indoorpositioning.GenerateIndoorPositioningFile";

		/// <summary>
		/// <para>Toolbox Display Name : Indoor Positioning Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Indoor Positioning Tools";

		/// <summary>
		/// <para>Toolbox Alise : indoorpositioning</para>
		/// </summary>
		public override string ToolboxAlise() => "indoorpositioning";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InIpsRecordings, TargetIpsPositioning, InIpsTransitions!, InIpsComment!, OutIpsPositioning! };

		/// <summary>
		/// <para>IPS Recordings Features</para>
		/// <para>包含 ArcGIS IPS Setup 调查记录的要素类或要素服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InIpsRecordings { get; set; }

		/// <summary>
		/// <para>Target IPS Positioning Table</para>
		/// <para>将存储生成的 IPS 定位文件的表或要素服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object TargetIpsPositioning { get; set; }

		/// <summary>
		/// <para>IPS Transitions Features</para>
		/// <para>包含定义设施点入口和出口的 TRANSITION_TYPE、VERTICAL_ORDER_FROM 和 VERTICAL_ORDER_TO 字段的线要素类。 ArcGIS IPS 使用这些线要素类改进室内和室外定位和切换。 此工具使用的入口和出口 TRANSITION_TYPE 字段必须包含值 7。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object? InIpsTransitions { get; set; }

		/// <summary>
		/// <para>Comment</para>
		/// <para>将用于填充目标 IPS 定位表值中定位文件条目的 Comment 字段的文本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? InIpsComment { get; set; }

		/// <summary>
		/// <para>Updated IPS Positioning Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutIpsPositioning { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateIndoorPositioningFile SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
