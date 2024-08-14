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
	/// <para>Find Highest Or Lowest Point</para>
	/// <para>Finds the highest or lowest point  of the input surface within a defined area.</para>
	/// </summary>
	public class FindHighestLowestPoint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>The input elevation raster surface.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class containing the output highest or lowest point.</para>
		/// </param>
		/// <param name="HighLowOperationType">
		/// <para>Highest or Lowest Point</para>
		/// <para>Specifies the type of operation the tool will perform.</para>
		/// <para>Highest points—The highest points will be found. This is the default.</para>
		/// <para>Lowest points—The lowest points will be found.</para>
		/// <para><see cref="HighLowOperationTypeEnum"/></para>
		/// </param>
		public FindHighestLowestPoint(object InSurface, object OutFeatureClass, object HighLowOperationType)
		{
			this.InSurface = InSurface;
			this.OutFeatureClass = OutFeatureClass;
			this.HighLowOperationType = HighLowOperationType;
		}

		/// <summary>
		/// <para>Tool Display Name : Find Highest Or Lowest Point</para>
		/// </summary>
		public override string DisplayName => "Find Highest Or Lowest Point";

		/// <summary>
		/// <para>Tool Name : FindHighestLowestPoint</para>
		/// </summary>
		public override string ToolName => "FindHighestLowestPoint";

		/// <summary>
		/// <para>Tool Excute Name : defense.FindHighestLowestPoint</para>
		/// </summary>
		public override string ExcuteName => "defense.FindHighestLowestPoint";

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
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InSurface, OutFeatureClass, HighLowOperationType, InFeature! };

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>The input elevation raster surface.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class containing the output highest or lowest point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Highest or Lowest Point</para>
		/// <para>Specifies the type of operation the tool will perform.</para>
		/// <para>Highest points—The highest points will be found. This is the default.</para>
		/// <para>Lowest points—The lowest points will be found.</para>
		/// <para><see cref="HighLowOperationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object HighLowOperationType { get; set; } = "HIGHEST";

		/// <summary>
		/// <para>Input Area</para>
		/// <para>The input polygon feature class within which the highest or lowest point will be found.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		public object? InFeature { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindHighestLowestPoint SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Highest or Lowest Point</para>
		/// </summary>
		public enum HighLowOperationTypeEnum 
		{
			/// <summary>
			/// <para>Highest points—The highest points will be found. This is the default.</para>
			/// </summary>
			[GPValue("HIGHEST")]
			[Description("Highest points")]
			Highest_points,

			/// <summary>
			/// <para>Lowest points—The lowest points will be found.</para>
			/// </summary>
			[GPValue("LOWEST")]
			[Description("Lowest points")]
			Lowest_points,

		}

#endregion
	}
}
