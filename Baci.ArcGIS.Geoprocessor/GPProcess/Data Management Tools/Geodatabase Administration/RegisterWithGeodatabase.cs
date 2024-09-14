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
	/// <para>Register with Geodatabase</para>
	/// <para>注册到地理数据库</para>
	/// <para>向地理数据库注册要素类、表、视图和栅格图层，而这些要素类、表、视图和栅格图层是使用第三方工具或具有创建数据库视图工具的视图在数据库中创建的。 注册之后，有关项目（例如表和列的名称、空间范围和几何类型）的信息会存储于地理数据库系统表中，从而使这些注册的项目可参与地理数据库的功能。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RegisterWithGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Datasets</para>
		/// <para>使用第三方工具或 SQL 创建的要素类、表、视图或栅格，或者使用将在地理数据库中注册的创建数据库视图工具创建的视图。 数据集必须存在于与地理数据库相同的数据库中。</para>
		/// </param>
		public RegisterWithGeodatabase(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 注册到地理数据库</para>
		/// </summary>
		public override string DisplayName() => "注册到地理数据库";

		/// <summary>
		/// <para>Tool Name : RegisterWithGeodatabase</para>
		/// </summary>
		public override string ToolName() => "RegisterWithGeodatabase";

		/// <summary>
		/// <para>Tool Excute Name : management.RegisterWithGeodatabase</para>
		/// </summary>
		public override string ExcuteName() => "management.RegisterWithGeodatabase";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, RegDataset!, InObjectIdField!, InShapeField!, InGeometryType!, InSpatialReference!, InExtent! };

		/// <summary>
		/// <para>Input Datasets</para>
		/// <para>使用第三方工具或 SQL 创建的要素类、表、视图或栅格，或者使用将在地理数据库中注册的创建数据库视图工具创建的视图。 数据集必须存在于与地理数据库相同的数据库中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Registered Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? RegDataset { get; set; }

		/// <summary>
		/// <para>Object ID Field</para>
		/// <para>将用作 ObjectID 字段的字段。 注册视图时需要此输入，且您必须提供一个现有的整型字段。 注册其他数据集类型时该参数为可选参数；如果使用现有字段，则该参数必须为整形数据类型。 如果在注册这些数据集类型时未提供现有字段，则将创建 ObjectID 字段并进行填充。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("OID", "Short", "Long")]
		public object? InObjectIdField { get; set; }

		/// <summary>
		/// <para>Shape Field</para>
		/// <para>如果输入数据集包含空间数据类型列，则在注册过程中应将该字段包括在内。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Geometry")]
		public object? InShapeField { get; set; }

		/// <summary>
		/// <para>Geometry Type</para>
		/// <para>指定几何类型。 如果存在 Shape 字段参数值，您必须指定一个几何类型。 支持的几何类型包括点、多点、面和折线。 如果正在注册的数据集包含现有要素，则指定的几何类型必须与这些要素的实体类型相匹配。</para>
		/// <para><see cref="InGeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? InGeometryType { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>如果 Shape 字段参数值存在，且表为空，则指定将要用于要素的坐标系。 如果正在注册的数据集包含现有要素，则指定的坐标系必须与现有要素的坐标系相匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? InSpatialReference { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>如果 Shape 字段参数值存在，则指定允许的 x,y 坐标的坐标范围。 如果正在注册的数据集包含现有要素，则将使用现有要素的范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEnvelope()]
		public object? InExtent { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RegisterWithGeodatabase SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Geometry Type</para>
		/// </summary>
		public enum InGeometryTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点")]
			Point,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("MULTIPOINT")]
			[Description("多点")]
			Multipoint,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("面")]
			Polygon,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("折线")]
			Polyline,

		}

#endregion
	}
}
