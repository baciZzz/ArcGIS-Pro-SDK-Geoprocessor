using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Simplify Building</para>
	/// <para>Simplifies the boundary or footprint of building polygons while maintaining their essential shape and size.</para>
	/// </summary>
	public class SimplifyBuilding : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The building polygons to be simplified.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class to be created.</para>
		/// </param>
		/// <param name="SimplificationTolerance">
		/// <para>Simplification Tolerance</para>
		/// <para>The tolerance for building simplification. A tolerance must be specified, and it must be greater than zero. You can choose a preferred unit; the default is the feature unit.</para>
		/// </param>
		public SimplifyBuilding(object InFeatures, object OutFeatureClass, object SimplificationTolerance)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.SimplificationTolerance = SimplificationTolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : Simplify Building</para>
		/// </summary>
		public override string DisplayName => "Simplify Building";

		/// <summary>
		/// <para>Tool Name : SimplifyBuilding</para>
		/// </summary>
		public override string ToolName => "SimplifyBuilding";

		/// <summary>
		/// <para>Tool Excute Name : cartography.SimplifyBuilding</para>
		/// </summary>
		public override string ExcuteName => "cartography.SimplifyBuilding";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "MDomain", "XYDomain", "XYTolerance", "cartographicPartitions", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, SimplificationTolerance, MinimumArea, ConflictOption, InBarriers, OutPointFeatureClass, CollapsedPointOption };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The building polygons to be simplified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Simplification Tolerance</para>
		/// <para>The tolerance for building simplification. A tolerance must be specified, and it must be greater than zero. You can choose a preferred unit; the default is the feature unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SimplificationTolerance { get; set; }

		/// <summary>
		/// <para>Minimum Area</para>
		/// <para>The minimum area for a simplified building to be retained in feature units. The default value is zero, that is, to keep all buildings. You can specify a preferred unit; the default is the feature unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object MinimumArea { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Check for spatial conflicts</para>
		/// <para>Specifies whether spatial conflicts—that is, overlapping or touching among buildings—will be identified. A SimBldFlag field is added to the output to store conflict flags. A value of 0 means no conflict; a value of 1 means conflict.</para>
		/// <para>Unchecked—Spatial conflicts will not be identified; the resulting buildings may overlap. This is the default.</para>
		/// <para>Checked—Spatial conflicts will be identified and the conflicting buildings will be flagged.</para>
		/// <para><see cref="ConflictOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ConflictOption { get; set; } = "false";

		/// <summary>
		/// <para>Input barrier layers</para>
		/// <para>The input layers containing features to act as barriers for simplification. Resulting simplified buildings will not touch or cross barrier features. For example, when simplifying buildings, the resulting simplified building areas do not cross road features defined as barriers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InBarriers { get; set; }

		/// <summary>
		/// <para>Polygons Collapsed To Zero Area</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutPointFeatureClass { get; set; } = "output_feature_class_Pnt";

		/// <summary>
		/// <para>Keep collapsed points</para>
		/// <para>Specifies whether an output point feature class will be created to store the centers of any buildings that are removed because they are smaller than the Minimum Area parameter value. The point output is derived, is named the same as the output feature class specified in the Output Feature Class parameter but with a _Pnt suffix, and is located in the same folder.</para>
		/// <para>Checked—A derived output point feature class will be created to store the centers of buildings that are removed.</para>
		/// <para>Unchecked— An output point class will not be created. This is the default.</para>
		/// <para><see cref="CollapsedPointOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CollapsedPointOption { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SimplifyBuilding SetEnviroment(object MDomain = null , object XYDomain = null , object XYTolerance = null , object cartographicPartitions = null , object extent = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, XYDomain: XYDomain, XYTolerance: XYTolerance, cartographicPartitions: cartographicPartitions, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Check for spatial conflicts</para>
		/// </summary>
		public enum ConflictOptionEnum 
		{
			/// <summary>
			/// <para>Checked—Spatial conflicts will be identified and the conflicting buildings will be flagged.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CHECK_CONFLICTS")]
			CHECK_CONFLICTS,

			/// <summary>
			/// <para>Unchecked—Spatial conflicts will not be identified; the resulting buildings may overlap. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CHECK")]
			NO_CHECK,

		}

		/// <summary>
		/// <para>Keep collapsed points</para>
		/// </summary>
		public enum CollapsedPointOptionEnum 
		{
			/// <summary>
			/// <para>Checked—A derived output point feature class will be created to store the centers of buildings that are removed.</para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_COLLAPSED_POINTS")]
			KEEP_COLLAPSED_POINTS,

			/// <summary>
			/// <para>Unchecked— An output point class will not be created. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_KEEP")]
			NO_KEEP,

		}

#endregion
	}
}
