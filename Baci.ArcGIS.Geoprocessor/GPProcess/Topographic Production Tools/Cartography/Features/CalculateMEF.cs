using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Calculate Max Elevation Figures</para>
	/// <para>Calculate Max Elevation Figures</para>
	/// <para>Calculates the maximum elevation figures (MEF) for each polygon cell or quadrangle in a polygon layer.  These values are used as labels for the MEF feature layer.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class CalculateMEF : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetMefFeatures">
		/// <para>Target Max Elevation Figures Features</para>
		/// <para>The input polygon features representing the quadrangle or cell that will be updated with MEF values.</para>
		/// </param>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>The input terrain that will be used to determine elevation values in an MEF feature cell. If a point feature layer is used, elevation values are obtained from the field defined in the Terrain Elevation Field parameter.</para>
		/// </param>
		/// <param name="ObstructionFeatures">
		/// <para>Vertical Obstruction Features</para>
		/// <para>The layers that will be used to identify the highest human-made structure in a cell. This is a value table defining features, elevation fields, and elevation units.</para>
		/// </param>
		/// <param name="MefField">
		/// <para>Max Elevation Figures Field</para>
		/// <para>The existing field in the Target Max Elevation Figures Features layer where the maximum elevation figure value will be stored.</para>
		/// </param>
		/// <param name="MaxVoField">
		/// <para>Max Vertical Obstruction Field</para>
		/// <para>The field in the Target Max Elevation Figures Features layer where the maximum vertical obstruction value will be stored.</para>
		/// </param>
		/// <param name="MaxTerrainField">
		/// <para>Max Terrain Field</para>
		/// <para>The field in the Target Max Elevation Figures Features layer where the maximum elevation values from the terrain layer will be stored.</para>
		/// </param>
		/// <param name="Specification">
		/// <para>Specification</para>
		/// <para>Specifies the specification that will be used to calculate maximum elevation figures.</para>
		/// <para>JOG-MIL-J-89100—The Joint Operations Graphic specification will be used.</para>
		/// <para>ONC-MIL-O-89102—The Operational Navigation Chart specification will be used.</para>
		/// <para>TPC-MIL-T-89101—The Tactical Pilotage Chart will be used.</para>
		/// <para>STANAG-3591-ED6—The NATO Standard Agreement will be used.</para>
		/// <para><see cref="SpecificationEnum"/></para>
		/// </param>
		public CalculateMEF(object TargetMefFeatures, object InTerrain, object ObstructionFeatures, object MefField, object MaxVoField, object MaxTerrainField, object Specification)
		{
			this.TargetMefFeatures = TargetMefFeatures;
			this.InTerrain = InTerrain;
			this.ObstructionFeatures = ObstructionFeatures;
			this.MefField = MefField;
			this.MaxVoField = MaxVoField;
			this.MaxTerrainField = MaxTerrainField;
			this.Specification = Specification;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Max Elevation Figures</para>
		/// </summary>
		public override string DisplayName() => "Calculate Max Elevation Figures";

		/// <summary>
		/// <para>Tool Name : CalculateMEF</para>
		/// </summary>
		public override string ToolName() => "CalculateMEF";

		/// <summary>
		/// <para>Tool Excute Name : topographic.CalculateMEF</para>
		/// </summary>
		public override string ExcuteName() => "topographic.CalculateMEF";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise() => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetMefFeatures, InTerrain, ObstructionFeatures, MefField, MaxVoField, MaxTerrainField, Specification, TerrainElevField!, VoAllowance!, VoAccuracy!, TerrainAccuracy!, UpdatedMefFeatures! };

		/// <summary>
		/// <para>Target Max Elevation Figures Features</para>
		/// <para>The input polygon features representing the quadrangle or cell that will be updated with MEF values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPLayerDomain()]
		[GeometryType("Polygon")]
		public object TargetMefFeatures { get; set; }

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>The input terrain that will be used to determine elevation values in an MEF feature cell. If a point feature layer is used, elevation values are obtained from the field defined in the Terrain Elevation Field parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Vertical Obstruction Features</para>
		/// <para>The layers that will be used to identify the highest human-made structure in a cell. This is a value table defining features, elevation fields, and elevation units.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object ObstructionFeatures { get; set; }

		/// <summary>
		/// <para>Max Elevation Figures Field</para>
		/// <para>The existing field in the Target Max Elevation Figures Features layer where the maximum elevation figure value will be stored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double", "Long", "Float", "Short")]
		public object MefField { get; set; }

		/// <summary>
		/// <para>Max Vertical Obstruction Field</para>
		/// <para>The field in the Target Max Elevation Figures Features layer where the maximum vertical obstruction value will be stored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double", "Long", "Float", "Short")]
		public object MaxVoField { get; set; }

		/// <summary>
		/// <para>Max Terrain Field</para>
		/// <para>The field in the Target Max Elevation Figures Features layer where the maximum elevation values from the terrain layer will be stored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double", "Long", "Float", "Short")]
		public object MaxTerrainField { get; set; }

		/// <summary>
		/// <para>Specification</para>
		/// <para>Specifies the specification that will be used to calculate maximum elevation figures.</para>
		/// <para>JOG-MIL-J-89100—The Joint Operations Graphic specification will be used.</para>
		/// <para>ONC-MIL-O-89102—The Operational Navigation Chart specification will be used.</para>
		/// <para>TPC-MIL-T-89101—The Tactical Pilotage Chart will be used.</para>
		/// <para>STANAG-3591-ED6—The NATO Standard Agreement will be used.</para>
		/// <para><see cref="SpecificationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Specification { get; set; }

		/// <summary>
		/// <para>Terrain Elevation Field</para>
		/// <para>A field in the Input Terrain value that represents the elevation values for each feature. If a point feature layer is used for the Input Terrain parameter value, this parameter is required. This parameter is inactive if a raster or mosaic layer is used as input for the Input Terrain parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double", "Long", "Float", "Short")]
		public object? TerrainElevField { get; set; }

		/// <summary>
		/// <para>Vertical Obstruction Allowance</para>
		/// <para>A vertical allowance value that will be added to each calculated MEF value. The value accounts for nonrepresented natural or manufactured features. The default is 150 feet.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? VoAllowance { get; set; } = "150 Feet";

		/// <summary>
		/// <para>Vertical Obstruction Accuracy</para>
		/// <para>The accuracy of the vertical obstruction feature layer within a specified number of units. The default is 20 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? VoAccuracy { get; set; } = "20 Meters";

		/// <summary>
		/// <para>Terrain Accuracy</para>
		/// <para>The accuracy of the terrain layer within a specified number of units. The default is 20 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? TerrainAccuracy { get; set; } = "20 Meters";

		/// <summary>
		/// <para>Updated Max Elevation Figures Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object? UpdatedMefFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateMEF SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Specification</para>
		/// </summary>
		public enum SpecificationEnum 
		{
			/// <summary>
			/// <para>JOG-MIL-J-89100—The Joint Operations Graphic specification will be used.</para>
			/// </summary>
			[GPValue("JOG_MIL_J_89100")]
			[Description("JOG-MIL-J-89100")]
			JOG_MIL_J_89100,

			/// <summary>
			/// <para>ONC-MIL-O-89102—The Operational Navigation Chart specification will be used.</para>
			/// </summary>
			[GPValue("ONC_MIL_O_89102")]
			[Description("ONC-MIL-O-89102")]
			ONC_MIL_O_89102,

			/// <summary>
			/// <para>TPC-MIL-T-89101—The Tactical Pilotage Chart will be used.</para>
			/// </summary>
			[GPValue("TPC_MIL_T_89101")]
			[Description("TPC-MIL-T-89101")]
			TPC_MIL_T_89101,

			/// <summary>
			/// <para>STANAG-3591-ED6—The NATO Standard Agreement will be used.</para>
			/// </summary>
			[GPValue("STANAG_3591_ED6")]
			[Description("STANAG-3591-ED6")]
			STANAG_3591_ED6,

		}

#endregion
	}
}
