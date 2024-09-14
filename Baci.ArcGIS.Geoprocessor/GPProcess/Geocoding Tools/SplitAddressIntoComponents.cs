using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeocodingTools
{
	/// <summary>
	/// <para>Split Address Into Components</para>
	/// <para>将地址分割为组件</para>
	/// <para>将街道地址信息分割为地址组件，并创建一个表或要素类，将其他组件添加为唯一的字段。</para>
	/// </summary>
	public class SplitAddressIntoComponents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="CountryCode">
		/// <para>Country or Region</para>
		/// <para>指定将地址分割为组件时要使用的国家/地区地址结构。</para>
		/// <para>默认值为操作系统的区域设置。</para>
		/// <para>澳大利亚—国家/地区代码将为澳大利亚。</para>
		/// <para>加拿大—国家/地区代码将为加拿大。</para>
		/// <para>德国—国家/地区代码将为德国。</para>
		/// <para>大不列颠—国家/地区代码将为大不列颠。</para>
		/// <para>美国—国家/地区代码将为美国。</para>
		/// <para><see cref="CountryCodeEnum"/></para>
		/// </param>
		/// <param name="InAddressData">
		/// <para>Input Address Data</para>
		/// <para>包含街道地址信息的表或要素类，这些信息将被分割为单独的地址组件。</para>
		/// <para>不支持区域信息，例如城市、社区、子区域和邮政编码。</para>
		/// </param>
		/// <param name="InAddressFields">
		/// <para>Input Address Fields</para>
		/// <para>输入表或要素类中的一个或多个字段，连接后将组成要分割的街道地址。 不支持区域信息，例如城市、社区、子区域和邮政编码。</para>
		/// <para>字段的选择顺序即是字段的连接顺序。</para>
		/// </param>
		/// <param name="OutAddressData">
		/// <para>Output Address Data</para>
		/// <para>将包含已分割街道地址数据的输出要素类或表。</para>
		/// </param>
		public SplitAddressIntoComponents(object CountryCode, object InAddressData, object InAddressFields, object OutAddressData)
		{
			this.CountryCode = CountryCode;
			this.InAddressData = InAddressData;
			this.InAddressFields = InAddressFields;
			this.OutAddressData = OutAddressData;
		}

		/// <summary>
		/// <para>Tool Display Name : 将地址分割为组件</para>
		/// </summary>
		public override string DisplayName() => "将地址分割为组件";

		/// <summary>
		/// <para>Tool Name : SplitAddressIntoComponents</para>
		/// </summary>
		public override string ToolName() => "SplitAddressIntoComponents";

		/// <summary>
		/// <para>Tool Excute Name : geocoding.SplitAddressIntoComponents</para>
		/// </summary>
		public override string ExcuteName() => "geocoding.SplitAddressIntoComponents";

		/// <summary>
		/// <para>Toolbox Display Name : Geocoding Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geocoding Tools";

		/// <summary>
		/// <para>Toolbox Alise : geocoding</para>
		/// </summary>
		public override string ToolboxAlise() => "geocoding";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { CountryCode, InAddressData, InAddressFields, OutAddressData, InExceptions! };

		/// <summary>
		/// <para>Country or Region</para>
		/// <para>指定将地址分割为组件时要使用的国家/地区地址结构。</para>
		/// <para>默认值为操作系统的区域设置。</para>
		/// <para>澳大利亚—国家/地区代码将为澳大利亚。</para>
		/// <para>加拿大—国家/地区代码将为加拿大。</para>
		/// <para>德国—国家/地区代码将为德国。</para>
		/// <para>大不列颠—国家/地区代码将为大不列颠。</para>
		/// <para>美国—国家/地区代码将为美国。</para>
		/// <para><see cref="CountryCodeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CountryCode { get; set; } = "USA";

		/// <summary>
		/// <para>Input Address Data</para>
		/// <para>包含街道地址信息的表或要素类，这些信息将被分割为单独的地址组件。</para>
		/// <para>不支持区域信息，例如城市、社区、子区域和邮政编码。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InAddressData { get; set; }

		/// <summary>
		/// <para>Input Address Fields</para>
		/// <para>输入表或要素类中的一个或多个字段，连接后将组成要分割的街道地址。 不支持区域信息，例如城市、社区、子区域和邮政编码。</para>
		/// <para>字段的选择顺序即是字段的连接顺序。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InAddressFields { get; set; }

		/// <summary>
		/// <para>Output Address Data</para>
		/// <para>将包含已分割街道地址数据的输出要素类或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEDatasetType()]
		public object OutAddressData { get; set; }

		/// <summary>
		/// <para>Exceptions File</para>
		/// <para>包含街道解析例外情况的表。</para>
		/// <para>该表可以采用任何受支持的表格式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object? InExceptions { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SplitAddressIntoComponents SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Country or Region</para>
		/// </summary>
		public enum CountryCodeEnum 
		{
			/// <summary>
			/// <para>澳大利亚—国家/地区代码将为澳大利亚。</para>
			/// </summary>
			[GPValue("AUS")]
			[Description("澳大利亚")]
			Australia,

			/// <summary>
			/// <para>加拿大—国家/地区代码将为加拿大。</para>
			/// </summary>
			[GPValue("CAN")]
			[Description("加拿大")]
			Canada,

			/// <summary>
			/// <para>德国—国家/地区代码将为德国。</para>
			/// </summary>
			[GPValue("DEU")]
			[Description("德国")]
			Germany,

			/// <summary>
			/// <para>大不列颠—国家/地区代码将为大不列颠。</para>
			/// </summary>
			[GPValue("GBR")]
			[Description("大不列颠")]
			Great_Britain,

			/// <summary>
			/// <para>美国—国家/地区代码将为美国。</para>
			/// </summary>
			[GPValue("USA")]
			[Description("美国")]
			United_States,

		}

#endregion
	}
}
