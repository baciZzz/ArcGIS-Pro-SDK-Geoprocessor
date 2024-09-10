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
	/// <para>Generate Points Along Lines</para>
	/// <para>Creates point features along lines or polygons at fixed intervals or by percentage of a feature's length.</para>
	/// </summary>
	public class GeneratePointsAlongLines : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>The line or polygon features to be converted into points.</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The point feature class that will be created from the input features.</para>
		/// </param>
		/// <param name="PointPlacement">
		/// <para>Point Placement</para>
		/// <para>Specifies the method used to create points.</para>
		/// <para>By percentage—The Percentage parameter value will be used to place points along the features by percentage.</para>
		/// <para>By distance—The Distance parameter value will be used to place points at fixed distances along the features. This is the default.</para>
		/// <para><see cref="PointPlacementEnum"/></para>
		/// </param>
		public GeneratePointsAlongLines(object InputFeatures, object OutputFeatureClass, object PointPlacement)
		{
			this.InputFeatures = InputFeatures;
			this.OutputFeatureClass = OutputFeatureClass;
			this.PointPlacement = PointPlacement;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Points Along Lines</para>
		/// </summary>
		public override string DisplayName() => "Generate Points Along Lines";

		/// <summary>
		/// <para>Tool Name : GeneratePointsAlongLines</para>
		/// </summary>
		public override string ToolName() => "GeneratePointsAlongLines";

		/// <summary>
		/// <para>Tool Excute Name : management.GeneratePointsAlongLines</para>
		/// </summary>
		public override string ExcuteName() => "management.GeneratePointsAlongLines";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "outputMFlag", "outputZFlag", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatures, OutputFeatureClass, PointPlacement, Distance, Percentage, IncludeEndPoints };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The line or polygon features to be converted into points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline")]
		[FeatureType("Simple")]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The point feature class that will be created from the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Point Placement</para>
		/// <para>Specifies the method used to create points.</para>
		/// <para>By percentage—The Percentage parameter value will be used to place points along the features by percentage.</para>
		/// <para>By distance—The Distance parameter value will be used to place points at fixed distances along the features. This is the default.</para>
		/// <para><see cref="PointPlacementEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PointPlacement { get; set; } = "DISTANCE";

		/// <summary>
		/// <para>Distance</para>
		/// <para>The interval from the beginning of the feature at which points will be placed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object Distance { get; set; }

		/// <summary>
		/// <para>Percentage</para>
		/// <para>The percentage from the beginning of the feature at which points will be placed. For example, if a percentage of 40 is used, points will be placed at 40 percent and 80 percent of the feature's distance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 100)]
		public object Percentage { get; set; }

		/// <summary>
		/// <para>Include End Points</para>
		/// <para>Specifies whether additional points will be included at the start point and end point of the feature.</para>
		/// <para>Checked—Additional points will be included at the start point and end point of the feature.</para>
		/// <para>Unchecked—No additional points will be included at the start point and end point of the feature. This is the default.</para>
		/// <para><see cref="IncludeEndPointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeEndPoints { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GeneratePointsAlongLines SetEnviroment(object configKeyword = null , object outputMFlag = null , object outputZFlag = null , object workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, outputMFlag: outputMFlag, outputZFlag: outputZFlag, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Point Placement</para>
		/// </summary>
		public enum PointPlacementEnum 
		{
			/// <summary>
			/// <para>By percentage—The Percentage parameter value will be used to place points along the features by percentage.</para>
			/// </summary>
			[GPValue("PERCENTAGE")]
			[Description("By percentage")]
			By_percentage,

			/// <summary>
			/// <para>By distance—The Distance parameter value will be used to place points at fixed distances along the features. This is the default.</para>
			/// </summary>
			[GPValue("DISTANCE")]
			[Description("By distance")]
			By_distance,

		}

		/// <summary>
		/// <para>Include End Points</para>
		/// </summary>
		public enum IncludeEndPointsEnum 
		{
			/// <summary>
			/// <para>Checked—Additional points will be included at the start point and end point of the feature.</para>
			/// </summary>
			[GPValue("true")]
			[Description("END_POINTS")]
			END_POINTS,

			/// <summary>
			/// <para>Unchecked—No additional points will be included at the start point and end point of the feature. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_END_POINTS")]
			NO_END_POINTS,

		}

#endregion
	}
}
