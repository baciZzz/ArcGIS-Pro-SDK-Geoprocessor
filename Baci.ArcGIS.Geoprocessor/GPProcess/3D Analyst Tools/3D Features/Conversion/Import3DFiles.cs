using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Import 3D Files</para>
	/// <para>导入 3D 文件</para>
	/// <para>将一个或多个 3D 模型导入到多面体要素类。</para>
	/// </summary>
	public class Import3DFiles : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFiles">
		/// <para>Input Files</para>
		/// <para>一个或多个 3D 模型或文件夹，支持的文件格式为 3D Studio Max (*.3ds)、VRML 和 GeoVRML (*.wrl)、OpenFlight (*.flt)、COLLADA (*.dae) 以及 Wavefront OBJ 模型 (*.obj)。</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output Multipatch Feature Class</para>
		/// <para>从输入文件中创建的多面体。</para>
		/// </param>
		public Import3DFiles(object InFiles, object OutFeatureclass)
		{
			this.InFiles = InFiles;
			this.OutFeatureclass = OutFeatureclass;
		}

		/// <summary>
		/// <para>Tool Display Name : 导入 3D 文件</para>
		/// </summary>
		public override string DisplayName() => "导入 3D 文件";

		/// <summary>
		/// <para>Tool Name : Import3DFiles</para>
		/// </summary>
		public override string ToolName() => "Import3DFiles";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Import3DFiles</para>
		/// </summary>
		public override string ExcuteName() => "3d.Import3DFiles";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "ZDomain", "autoCommit", "configKeyword", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFiles, OutFeatureclass, RootPerFeature!, SpatialReference!, YIsUp!, FileSuffix!, InFeatureclass!, SymbolField! };

		/// <summary>
		/// <para>Input Files</para>
		/// <para>一个或多个 3D 模型或文件夹，支持的文件格式为 3D Studio Max (*.3ds)、VRML 和 GeoVRML (*.wrl)、OpenFlight (*.flt)、COLLADA (*.dae) 以及 Wavefront OBJ 模型 (*.obj)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object InFiles { get; set; }

		/// <summary>
		/// <para>Output Multipatch Feature Class</para>
		/// <para>从输入文件中创建的多面体。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>One Root Per Feature</para>
		/// <para>指明是为每个文件生成一个要素还是为文件中的每个根结点生成一个要素。此选项仅适用于 VRML 模型。</para>
		/// <para>未选中 - 生成的输出将为每个文件包含一个要素。这是默认设置。</para>
		/// <para>选中 - 生成的输出将为文件中的每个根结点包含一个要素。</para>
		/// <para><see cref="RootPerFeatureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? RootPerFeature { get; set; } = "false";

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>输入数据的坐标系。对于大多数格式来说，这是未知的。只有 GeoVRML 格式存储其坐标系，其默认值将从列表中的第一个文件获得，除非在此处指定一个空间参考。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Y Is Up</para>
		/// <para>标识定义输入文件垂直方向的轴。</para>
		/// <para>未选中 - 指示 z 轴向上。这是默认设置。</para>
		/// <para>选中 - 指示 y 轴向上。</para>
		/// <para><see cref="YIsUpEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? YIsUp { get; set; } = "false";

		/// <summary>
		/// <para>File Suffix</para>
		/// <para>从输入文件夹导入的文件的文件扩展名。将至少一个文件夹指定为输入时，此参数为必填项。</para>
		/// <para>所有受支持的文件—所有受支持的文件。这是默认设置。</para>
		/// <para>3D Studio Max (*.3ds)—3D Studio Max</para>
		/// <para>VRML 或 GeoVRML (*.wrl)—VRML 或 GeoVRML</para>
		/// <para>OpenFlight (*.flt)—OpenFlight</para>
		/// <para>Collada (*.dae)—Collada</para>
		/// <para>Wavefront OBJ 格式 (*.obj)—Wavefront OBJ 模型</para>
		/// <para><see cref="FileSuffixEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FileSuffix { get; set; } = "*";

		/// <summary>
		/// <para>Placement Points</para>
		/// <para>其坐标定义输入文件实际位置的点要素。每个输入文件将与基于符号字段中存储的文件名的对应点相匹配。应将坐标系参数定义为与点的空间参考相匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object? InFeatureclass { get; set; }

		/// <summary>
		/// <para>Symbol Field</para>
		/// <para>点要素中的字段，包含与各点相关联的 3D 文件的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("OID", "Short", "Long", "Text", "Float", "Double", "Date")]
		public object? SymbolField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Import3DFiles SetEnviroment(object? XYDomain = null , object? ZDomain = null , int? autoCommit = null , object? configKeyword = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, ZDomain: ZDomain, autoCommit: autoCommit, configKeyword: configKeyword, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>One Root Per Feature</para>
		/// </summary>
		public enum RootPerFeatureEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ONE_FILE_ONE_FEATURE")]
			ONE_FILE_ONE_FEATURE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ONE_ROOT_ONE_FEATURE")]
			ONE_ROOT_ONE_FEATURE,

		}

		/// <summary>
		/// <para>Y Is Up</para>
		/// </summary>
		public enum YIsUpEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("Y_IS_UP")]
			Y_IS_UP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("Z_IS_UP")]
			Z_IS_UP,

		}

		/// <summary>
		/// <para>File Suffix</para>
		/// </summary>
		public enum FileSuffixEnum 
		{
			/// <summary>
			/// <para>3D Studio Max (*.3ds)—3D Studio Max</para>
			/// </summary>
			[GPValue("3DS")]
			[Description("3D Studio Max (*.3ds)")]
			_3DS,

			/// <summary>
			/// <para>VRML 或 GeoVRML (*.wrl)—VRML 或 GeoVRML</para>
			/// </summary>
			[GPValue("WRL")]
			[Description("VRML 或 GeoVRML (*.wrl)")]
			WRL,

			/// <summary>
			/// <para>OpenFlight (*.flt)—OpenFlight</para>
			/// </summary>
			[GPValue("FLT")]
			[Description("OpenFlight (*.flt)")]
			FLT,

			/// <summary>
			/// <para>Collada (*.dae)—Collada</para>
			/// </summary>
			[GPValue("DAE")]
			[Description("Collada (*.dae)")]
			DAE,

			/// <summary>
			/// <para>Wavefront OBJ 格式 (*.obj)—Wavefront OBJ 模型</para>
			/// </summary>
			[GPValue("OBJ")]
			[Description("Wavefront OBJ 格式 (*.obj)")]
			OBJ,

			/// <summary>
			/// <para>所有受支持的文件—所有受支持的文件。这是默认设置。</para>
			/// </summary>
			[GPValue("*")]
			[Description("所有受支持的文件")]
			All_Supported_Files,

		}

#endregion
	}
}
