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
	/// <para>Add XY Coordinates</para>
	/// <para>添加 XY 坐标</para>
	/// <para>将字段 POINT_X 和 POINT_Y 添加到点输入要素并计算其值。如果启用了输入要素的 Z 值和 M 值，还将追加 POINT_Z 和 POINT_M 字段。</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.DataManagementTools.CalculateGeometryAttributes"/> tool provides enhanced functionality or performance</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.DataManagementTools.CalculateGeometryAttributes))]
	[InputWillBeModified()]
	public class AddXY : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>x,y 坐标将作为 POINT_X 和 POINT_Y 字段追加到点要素。</para>
		/// </param>
		public AddXY(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加 XY 坐标</para>
		/// </summary>
		public override string DisplayName() => "添加 XY 坐标";

		/// <summary>
		/// <para>Tool Name : AddXY</para>
		/// </summary>
		public override string ToolName() => "AddXY";

		/// <summary>
		/// <para>Tool Excute Name : management.AddXY</para>
		/// </summary>
		public override string ExcuteName() => "management.AddXY";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatures! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>x,y 坐标将作为 POINT_X 和 POINT_Y 字段追加到点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddXY SetEnviroment(object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

	}
}
