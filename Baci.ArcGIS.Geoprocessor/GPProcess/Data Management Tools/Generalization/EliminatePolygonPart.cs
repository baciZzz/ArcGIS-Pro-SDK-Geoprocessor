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
	/// <para>Eliminate Polygon Part</para>
	/// <para>消除面部件</para>
	/// <para>创建一个新的输出要素类，包含从输入面上删除某些指定大小的部分或孔洞所得的要素。</para>
	/// </summary>
	public class EliminatePolygonPart : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>其要素将被复制到输出要素类（消除某些部分或洞）的输入要素类或图层。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含其余部分的输出面要素类。</para>
		/// </param>
		public EliminatePolygonPart(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 消除面部件</para>
		/// </summary>
		public override string DisplayName() => "消除面部件";

		/// <summary>
		/// <para>Tool Name : EliminatePolygonPart</para>
		/// </summary>
		public override string ToolName() => "EliminatePolygonPart";

		/// <summary>
		/// <para>Tool Excute Name : management.EliminatePolygonPart</para>
		/// </summary>
		public override string ExcuteName() => "management.EliminatePolygonPart";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, Condition, PartArea, PartAreaPercent, PartOption };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>其要素将被复制到输出要素类（消除某些部分或洞）的输入要素类或图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含其余部分的输出面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Condition</para>
		/// <para>指定要消除的部分的确定方式。</para>
		/// <para>面积—面积小于指定值的部分将被消除。</para>
		/// <para>百分比—总外部面积百分比小于指定值的部分将被消除。</para>
		/// <para>面积和百分比—面积和百分比均小于指定值的部分将被消除。只有同时满足面积和百分比两个条件的面部分才会被删除。</para>
		/// <para>面积或百分比—面积或百分比小于指定值的部分将被消除。如果面部分满足面积或百分比条件之一，该面将被删除。</para>
		/// <para><see cref="ConditionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Condition { get; set; } = "AREA";

		/// <summary>
		/// <para>Area</para>
		/// <para>消除小于此面积的部分。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object PartArea { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Percentage</para>
		/// <para>消除小于此要素总外部面积百分比的部分。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = false, Value = 100)]
		public object PartAreaPercent { get; set; } = "0";

		/// <summary>
		/// <para>Eliminate contained parts only</para>
		/// <para>确定可消除的部分。</para>
		/// <para>选中 - 仅消除完全包含于其他部分的部分。这是默认设置。</para>
		/// <para>取消选中 - 可消除任意部分。</para>
		/// <para><see cref="PartOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PartOption { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EliminatePolygonPart SetEnviroment(object MDomain = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(MDomain: MDomain, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Condition</para>
		/// </summary>
		public enum ConditionEnum 
		{
			/// <summary>
			/// <para>面积—面积小于指定值的部分将被消除。</para>
			/// </summary>
			[GPValue("AREA")]
			[Description("面积")]
			Area,

			/// <summary>
			/// <para>百分比—总外部面积百分比小于指定值的部分将被消除。</para>
			/// </summary>
			[GPValue("PERCENT")]
			[Description("百分比")]
			Percent,

			/// <summary>
			/// <para>面积和百分比—面积和百分比均小于指定值的部分将被消除。只有同时满足面积和百分比两个条件的面部分才会被删除。</para>
			/// </summary>
			[GPValue("AREA_AND_PERCENT")]
			[Description("面积和百分比")]
			Area_and_percent,

			/// <summary>
			/// <para>面积或百分比—面积或百分比小于指定值的部分将被消除。如果面部分满足面积或百分比条件之一，该面将被删除。</para>
			/// </summary>
			[GPValue("AREA_OR_PERCENT")]
			[Description("面积或百分比")]
			Area_or_percent,

		}

		/// <summary>
		/// <para>Eliminate contained parts only</para>
		/// </summary>
		public enum PartOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CONTAINED_ONLY")]
			CONTAINED_ONLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ANY")]
			ANY,

		}

#endregion
	}
}
