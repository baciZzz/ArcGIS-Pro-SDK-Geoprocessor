using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DefenseTools
{
	/// <summary>
	/// <para>Number Features</para>
	/// <para>对要素进行编号</para>
	/// <para>将序号添加到输入要素集的新字段或现有字段中。</para>
	/// </summary>
	public class NumberFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要编号的输入要素。</para>
		/// </param>
		/// <param name="FieldToNumber">
		/// <para>Field to Number (Existing or New)</para>
		/// <para>要编号的输入字段。 该字段可以是现有的短型、长型或文本字段，也可以是新字段。</para>
		/// </param>
		public NumberFeatures(object InFeatures, object FieldToNumber)
		{
			this.InFeatures = InFeatures;
			this.FieldToNumber = FieldToNumber;
		}

		/// <summary>
		/// <para>Tool Display Name : 对要素进行编号</para>
		/// </summary>
		public override string DisplayName() => "对要素进行编号";

		/// <summary>
		/// <para>Tool Name : NumberFeatures</para>
		/// </summary>
		public override string ToolName() => "NumberFeatures";

		/// <summary>
		/// <para>Tool Excute Name : defense.NumberFeatures</para>
		/// </summary>
		public override string ExcuteName() => "defense.NumberFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Defense Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Defense Tools";

		/// <summary>
		/// <para>Toolbox Alise : defense</para>
		/// </summary>
		public override string ToolboxAlise() => "defense";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, FieldToNumber, InArea, SpatialSortMethod, NewFieldType, OutFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要编号的输入要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline", "Multipoint", "Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Field to Number (Existing or New)</para>
		/// <para>要编号的输入字段。 该字段可以是现有的短型、长型或文本字段，也可以是新字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object FieldToNumber { get; set; }

		/// <summary>
		/// <para>Input Area to Number</para>
		/// <para>限制要编号的要素的面；将仅对此面内的要素进行编号。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InArea { get; set; }

		/// <summary>
		/// <para>Spatial Sort Method</para>
		/// <para>指定如何对要素进行空间排序以进行编号。 不会对表中的要素重新排序。</para>
		/// <para>右上角—从右上角开始排序。这是默认设置。</para>
		/// <para>左上角—从左上角开始排序。</para>
		/// <para>右下角—从右下角开始排序。</para>
		/// <para>左下角—从左下角开始排序。</para>
		/// <para>皮亚诺曲线—使用空间填充曲线算法（也称为皮亚诺曲线）排序。</para>
		/// <para>无—不会使用空间排序。将使用与要素类相同的顺序。</para>
		/// <para><see cref="SpatialSortMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SpatialSortMethod { get; set; } = "UR";

		/// <summary>
		/// <para>Field Type For New Field</para>
		/// <para>指定新字段的字段类型。 仅当输入表中不存在字段名称时才使用此参数。</para>
		/// <para>Short—该字段的类型将为短型。这是默认设置。</para>
		/// <para>Long—该字段的类型将为长型。</para>
		/// <para>文本型—该字段的类型将为文本。</para>
		/// <para><see cref="NewFieldTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object NewFieldType { get; set; } = "SHORT";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public NumberFeatures SetEnviroment(object extent = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Spatial Sort Method</para>
		/// </summary>
		public enum SpatialSortMethodEnum 
		{
			/// <summary>
			/// <para>右上角—从右上角开始排序。这是默认设置。</para>
			/// </summary>
			[GPValue("UR")]
			[Description("右上角")]
			Upper_right,

			/// <summary>
			/// <para>左上角—从左上角开始排序。</para>
			/// </summary>
			[GPValue("UL")]
			[Description("左上角")]
			Upper_left,

			/// <summary>
			/// <para>右下角—从右下角开始排序。</para>
			/// </summary>
			[GPValue("LR")]
			[Description("右下角")]
			Lower_right,

			/// <summary>
			/// <para>左下角—从左下角开始排序。</para>
			/// </summary>
			[GPValue("LL")]
			[Description("左下角")]
			Lower_left,

			/// <summary>
			/// <para>皮亚诺曲线—使用空间填充曲线算法（也称为皮亚诺曲线）排序。</para>
			/// </summary>
			[GPValue("PEANO")]
			[Description("皮亚诺曲线")]
			Peano_curve,

			/// <summary>
			/// <para>无—不会使用空间排序。将使用与要素类相同的顺序。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

		}

		/// <summary>
		/// <para>Field Type For New Field</para>
		/// </summary>
		public enum NewFieldTypeEnum 
		{
			/// <summary>
			/// <para>Short—该字段的类型将为短型。这是默认设置。</para>
			/// </summary>
			[GPValue("SHORT")]
			[Description("Short")]
			Short,

			/// <summary>
			/// <para>Long—该字段的类型将为长型。</para>
			/// </summary>
			[GPValue("LONG")]
			[Description("Long")]
			Long,

			/// <summary>
			/// <para>文本型—该字段的类型将为文本。</para>
			/// </summary>
			[GPValue("TEXT")]
			[Description("文本型")]
			Text,

		}

#endregion
	}
}
