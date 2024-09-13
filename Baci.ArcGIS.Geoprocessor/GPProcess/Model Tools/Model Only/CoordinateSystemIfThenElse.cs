using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>If Coordinate System Is</para>
	/// <para>如果坐标系为</para>
	/// <para>评估指定坐标系的输入数据。</para>
	/// </summary>
	public class CoordinateSystemIfThenElse : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input Data Element</para>
		/// <para>要评估的输入数据元素。</para>
		/// </param>
		/// <param name="CoordinateSystem">
		/// <para>Coordinate System</para>
		/// <para>将进行评估的坐标系。</para>
		/// </param>
		public CoordinateSystemIfThenElse(object InData, object CoordinateSystem)
		{
			this.InData = InData;
			this.CoordinateSystem = CoordinateSystem;
		}

		/// <summary>
		/// <para>Tool Display Name : 如果坐标系为</para>
		/// </summary>
		public override string DisplayName() => "如果坐标系为";

		/// <summary>
		/// <para>Tool Name : CoordinateSystemIfThenElse</para>
		/// </summary>
		public override string ToolName() => "CoordinateSystemIfThenElse";

		/// <summary>
		/// <para>Tool Excute Name : mb.CoordinateSystemIfThenElse</para>
		/// </summary>
		public override string ExcuteName() => "mb.CoordinateSystemIfThenElse";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise() => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InData, CoordinateSystem, True!, False! };

		/// <summary>
		/// <para>Input Data Element</para>
		/// <para>要评估的输入数据元素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>将进行评估的坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object CoordinateSystem { get; set; }

		/// <summary>
		/// <para>True</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? True { get; set; } = "false";

		/// <summary>
		/// <para>False</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? False { get; set; } = "false";

	}
}
