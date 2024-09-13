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
	/// <para>Set Parcel Line Label Position</para>
	/// <para>设置宗地线标注位置</para>
	/// <para>将线的 COGO 尺寸的标注位置设置在宗地线的左侧、右侧或位于宗地线的中心。</para>
	/// </summary>
	public class SetParcelLineLabelPosition : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFeatures">
		/// <para>Input Parcel Features</para>
		/// <para>具有将被更新的标注位置的输入宗地线图层。</para>
		/// </param>
		public SetParcelLineLabelPosition(object InParcelFeatures)
		{
			this.InParcelFeatures = InParcelFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 设置宗地线标注位置</para>
		/// </summary>
		public override string DisplayName() => "设置宗地线标注位置";

		/// <summary>
		/// <para>Tool Name : SetParcelLineLabelPosition</para>
		/// </summary>
		public override string ToolName() => "SetParcelLineLabelPosition";

		/// <summary>
		/// <para>Tool Excute Name : parcel.SetParcelLineLabelPosition</para>
		/// </summary>
		public override string ExcuteName() => "parcel.SetParcelLineLabelPosition";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InParcelFeatures, UpdatedParcelFeatures! };

		/// <summary>
		/// <para>Input Parcel Features</para>
		/// <para>具有将被更新的标注位置的输入宗地线图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InParcelFeatures { get; set; }

		/// <summary>
		/// <para>Updated Parcel Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? UpdatedParcelFeatures { get; set; }

	}
}
