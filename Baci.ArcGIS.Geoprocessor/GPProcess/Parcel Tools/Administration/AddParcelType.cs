using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ParcelTools
{
	/// <summary>
	/// <para>Add Parcel Type</para>
	/// <para>添加宗地类型</para>
	/// <para>向宗地结构添加宗地类型。 宗地类型由单独的面和线要素类进行定义。 宗地类型要素类由宗地结构数据集进行控制。</para>
	/// </summary>
	public class AddParcelType : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFabric">
		/// <para>Input Parcel Fabric</para>
		/// <para>宗地类型将被添加到的宗地结构。 宗地结构可来自文件地理数据库或企业级地理数据库。</para>
		/// </param>
		/// <param name="Name">
		/// <para>Name</para>
		/// <para>宗地类型的名称。 该名称将分配给输出面和线要素类。</para>
		/// </param>
		public AddParcelType(object InParcelFabric, object Name)
		{
			this.InParcelFabric = InParcelFabric;
			this.Name = Name;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加宗地类型</para>
		/// </summary>
		public override string DisplayName() => "添加宗地类型";

		/// <summary>
		/// <para>Tool Name : AddParcelType</para>
		/// </summary>
		public override string ToolName() => "AddParcelType";

		/// <summary>
		/// <para>Tool Excute Name : parcel.AddParcelType</para>
		/// </summary>
		public override string ExcuteName() => "parcel.AddParcelType";

		/// <summary>
		/// <para>Toolbox Display Name : Parcel Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Parcel Tools";

		/// <summary>
		/// <para>Toolbox Alise : parcel</para>
		/// </summary>
		public override string ToolboxAlise() => "parcel";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InParcelFabric, Name, UpdatedParcelFabric, OutPolygonFc, OutLineFc, AdministrativePolygon };

		/// <summary>
		/// <para>Input Parcel Fabric</para>
		/// <para>宗地类型将被添加到的宗地结构。 宗地结构可来自文件地理数据库或企业级地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object InParcelFabric { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// <para>宗地类型的名称。 该名称将分配给输出面和线要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Updated Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object UpdatedParcelFabric { get; set; }

		/// <summary>
		/// <para>Output Polygon Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutPolygonFc { get; set; }

		/// <summary>
		/// <para>Output Line Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutLineFc { get; set; }

		/// <summary>
		/// <para>Use for administrative boundaries</para>
		/// <para>指定宗地类型将用于存储具有行政边界还是常规边界的宗地。 行政边界将用于非常大的宗地，例如国家宗地或州宗地。 宗地类型面要素类将不参与宗地结构拓扑。</para>
		/// <para>选中 - 宗地类型将用于存储行政边界。 宗地类型面要素类将不参与宗地结构拓扑。</para>
		/// <para>未选中 - 宗地类型不会用于存储行政边界。 宗地类型面要素类将参与宗地结构拓扑。 这是默认设置。</para>
		/// <para><see cref="AdministrativePolygonEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AdministrativePolygon { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Use for administrative boundaries</para>
		/// </summary>
		public enum AdministrativePolygonEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADMINISTRATIVE_POLYGON")]
			ADMINISTRATIVE_POLYGON,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("TOPOLOGY_POLYGON")]
			TOPOLOGY_POLYGON,

		}

#endregion
	}
}
