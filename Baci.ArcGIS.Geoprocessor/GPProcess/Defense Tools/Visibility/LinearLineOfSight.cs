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
	/// <para>Linear Line Of Sight</para>
	/// <para>Creates lines of sight between observers and targets.</para>
	/// </summary>
	public class LinearLineOfSight : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InObserverFeatures">
		/// <para>Observers</para>
		/// <para>The input observer points.</para>
		/// </param>
		/// <param name="InTargetFeatures">
		/// <para>Targets</para>
		/// <para>The input target points.</para>
		/// </param>
		/// <param name="InSurface">
		/// <para>Input Elevation Surface</para>
		/// <para>The input elevation raster surface.</para>
		/// </param>
		/// <param name="OutLosFeatureClass">
		/// <para>Output Line Of Sight Feature Class</para>
		/// <para>The output feature class showing lines of visible and nonvisible surface areas.</para>
		/// </param>
		/// <param name="OutSightLineFeatureClass">
		/// <para>Output Sight Line Feature Class</para>
		/// <para>The output line feature class showing the direct line of sight between observer and target.</para>
		/// </param>
		/// <param name="OutObserverFeatureClass">
		/// <para>Output Observer Feature Class</para>
		/// <para>The output observer point feature class.</para>
		/// </param>
		/// <param name="OutTargetFeatureClass">
		/// <para>Output Target Feature Class</para>
		/// <para>The output target point feature class.</para>
		/// </param>
		public LinearLineOfSight(object InObserverFeatures, object InTargetFeatures, object InSurface, object OutLosFeatureClass, object OutSightLineFeatureClass, object OutObserverFeatureClass, object OutTargetFeatureClass)
		{
			this.InObserverFeatures = InObserverFeatures;
			this.InTargetFeatures = InTargetFeatures;
			this.InSurface = InSurface;
			this.OutLosFeatureClass = OutLosFeatureClass;
			this.OutSightLineFeatureClass = OutSightLineFeatureClass;
			this.OutObserverFeatureClass = OutObserverFeatureClass;
			this.OutTargetFeatureClass = OutTargetFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Linear Line Of Sight</para>
		/// </summary>
		public override string DisplayName => "Linear Line Of Sight";

		/// <summary>
		/// <para>Tool Name : LinearLineOfSight</para>
		/// </summary>
		public override string ToolName => "LinearLineOfSight";

		/// <summary>
		/// <para>Tool Excute Name : defense.LinearLineOfSight</para>
		/// </summary>
		public override string ExcuteName => "defense.LinearLineOfSight";

		/// <summary>
		/// <para>Toolbox Display Name : Defense Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Defense Tools";

		/// <summary>
		/// <para>Toolbox Alise : defense</para>
		/// </summary>
		public override string ToolboxAlise => "defense";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InObserverFeatures, InTargetFeatures, InSurface, OutLosFeatureClass, OutSightLineFeatureClass, OutObserverFeatureClass, OutTargetFeatureClass, InObstructionFeatures, ObserverHeightAboveSurface, TargetHeightAboveSurface, AddProfileAttachment };

		/// <summary>
		/// <para>Observers</para>
		/// <para>The input observer points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InObserverFeatures { get; set; }

		/// <summary>
		/// <para>Targets</para>
		/// <para>The input target points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InTargetFeatures { get; set; }

		/// <summary>
		/// <para>Input Elevation Surface</para>
		/// <para>The input elevation raster surface.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Line Of Sight Feature Class</para>
		/// <para>The output feature class showing lines of visible and nonvisible surface areas.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutLosFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Sight Line Feature Class</para>
		/// <para>The output line feature class showing the direct line of sight between observer and target.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutSightLineFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Observer Feature Class</para>
		/// <para>The output observer point feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutObserverFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Target Feature Class</para>
		/// <para>The output target point feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutTargetFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Obstruction Features</para>
		/// <para>The input multipatch feature that may obstruct the lines of sight.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[Category("Visibility Options")]
		public object InObstructionFeatures { get; set; }

		/// <summary>
		/// <para>Observer Height Above Surface (meters)</para>
		/// <para>The height added to the surface elevation of the observer. The default is 2.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Visibility Options")]
		public object ObserverHeightAboveSurface { get; set; } = "2";

		/// <summary>
		/// <para>Target Height Above Surface (meters)</para>
		/// <para>The height added to the surface elevation of the target. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Visibility Options")]
		public object TargetHeightAboveSurface { get; set; } = "0";

		/// <summary>
		/// <para>Add Profile Graph Attachment To Sight Line</para>
		/// <para>Specifies whether the tool will add an attachment to the feature with the profile (cross section terrain graph) between observer and target.</para>
		/// <para>No profile graph—A profile graph will not be added. This is the default.</para>
		/// <para>Adds a profile graph—A profile graph will be added.</para>
		/// <para><see cref="AddProfileAttachmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Visibility Options")]
		public object AddProfileAttachment { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LinearLineOfSight SetEnviroment(object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Add Profile Graph Attachment To Sight Line</para>
		/// </summary>
		public enum AddProfileAttachmentEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_PROFILE_GRAPH")]
			ADD_PROFILE_GRAPH,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PROFILE_GRAPH")]
			NO_PROFILE_GRAPH,

		}

#endregion
	}
}
