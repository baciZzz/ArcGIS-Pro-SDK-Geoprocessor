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
	/// <para>Copy Features</para>
	/// <para>复制要素</para>
	/// <para>将输入要素类或图层中的要素复制到新要素类。</para>
	/// </summary>
	public class CopyFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要复制的要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将创建的要素类以及将要素复制到的要素类。</para>
		/// </param>
		public CopyFeatures(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 复制要素</para>
		/// </summary>
		public override string DisplayName() => "复制要素";

		/// <summary>
		/// <para>Tool Name : CopyFeatures</para>
		/// </summary>
		public override string ToolName() => "CopyFeatures";

		/// <summary>
		/// <para>Tool Excute Name : management.CopyFeatures</para>
		/// </summary>
		public override string ExcuteName() => "management.CopyFeatures";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "maintainAttachments", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "preserveGlobalIds", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, ConfigKeyword!, SpatialGrid1!, SpatialGrid2!, SpatialGrid3! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要复制的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将创建的要素类以及将要素复制到的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>如果输出为地理数据库，则将应用地理数据库配置关键字。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Output Spatial Grid 1</para>
		/// <para>已在 ArcGIS Pro 中弃用此参数。 将忽略您输入的任何值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SpatialGrid1 { get; set; }

		/// <summary>
		/// <para>Output Spatial Grid 2</para>
		/// <para>已在 ArcGIS Pro 中弃用此参数。 将忽略您输入的任何值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SpatialGrid2 { get; set; }

		/// <summary>
		/// <para>Output Spatial Grid 3</para>
		/// <para>已在 ArcGIS Pro 中弃用此参数。 将忽略您输入的任何值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SpatialGrid3 { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CopyFeatures SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , bool? maintainAttachments = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , bool? preserveGlobalIds = null , bool? qualifiedFieldNames = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainAttachments: maintainAttachments, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, preserveGlobalIds: preserveGlobalIds, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
