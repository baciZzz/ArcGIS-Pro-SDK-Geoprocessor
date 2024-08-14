using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MaritimeTools
{
	/// <summary>
	/// <para>Generate Depth Areas</para>
	/// <para>Creates depth area polygon features using a TIN to query depth information to find whether a closed contour is trending deeper or shallower.</para>
	/// </summary>
	public class GenerateDepthAreas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>The TIN surface from which the nodes will be queried to attribute the depth polygons. It is recommended that you use the same TIN surface that was used to generate the contours.</para>
		/// </param>
		/// <param name="InContours">
		/// <para>Input Contour Features</para>
		/// <para>The depth contours features.</para>
		/// </param>
		/// <param name="ContourDepthField">
		/// <para>Depth Field</para>
		/// <para>The field that will store the depth value in the depth contours feature.</para>
		/// </param>
		/// <param name="DepthDirection">
		/// <para>Depth Direction</para>
		/// <para>Specifies whether the depth direction is positive upward or positive downward. The direction must be the same as that of the input TIN and contour features for the values of the minimum and maximum depth for the generated depth area polygons to be accurate.</para>
		/// <para>Positive Up—The input contour values, maximum depth, and minimum depth must be negative with drying heights as positive. This is the default.</para>
		/// <para>Positive Down—The input contour values, maximum depth, and minimum depth must be positive with drying heights as negative.</para>
		/// <para><see cref="DepthDirectionEnum"/></para>
		/// </param>
		/// <param name="TargetWorkspace">
		/// <para>Target Workspace</para>
		/// <para>The geodatabase where the depth polygons will be written. The workspace is expected to be a nautical workspace with either the S-57 or S-101 schemas.</para>
		/// </param>
		/// <param name="MinDepth">
		/// <para>Minimum Depth</para>
		/// <para>A value used to populate the minimum depth of polygons shallower than the shallowest contour value.</para>
		/// </param>
		/// <param name="MaxDepth">
		/// <para>Maximum Depth</para>
		/// <para>A value used to populate the maximum depth of polygons deeper than the deepest contour value.</para>
		/// </param>
		public GenerateDepthAreas(object InTin, object InContours, object ContourDepthField, object DepthDirection, object TargetWorkspace, object MinDepth, object MaxDepth)
		{
			this.InTin = InTin;
			this.InContours = InContours;
			this.ContourDepthField = ContourDepthField;
			this.DepthDirection = DepthDirection;
			this.TargetWorkspace = TargetWorkspace;
			this.MinDepth = MinDepth;
			this.MaxDepth = MaxDepth;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Depth Areas</para>
		/// </summary>
		public override string DisplayName => "Generate Depth Areas";

		/// <summary>
		/// <para>Tool Name : GenerateDepthAreas</para>
		/// </summary>
		public override string ToolName => "GenerateDepthAreas";

		/// <summary>
		/// <para>Tool Excute Name : maritime.GenerateDepthAreas</para>
		/// </summary>
		public override string ExcuteName => "maritime.GenerateDepthAreas";

		/// <summary>
		/// <para>Toolbox Display Name : Maritime Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Maritime Tools";

		/// <summary>
		/// <para>Toolbox Alise : maritime</para>
		/// </summary>
		public override string ToolboxAlise => "maritime";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTin, InContours, ContourDepthField, DepthDirection, TargetWorkspace, MinDepth, MaxDepth, InExtentPolygon!, UpdatedDepthAreas! };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>The TIN surface from which the nodes will be queried to attribute the depth polygons. It is recommended that you use the same TIN surface that was used to generate the contours.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

		/// <summary>
		/// <para>Input Contour Features</para>
		/// <para>The depth contours features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InContours { get; set; }

		/// <summary>
		/// <para>Depth Field</para>
		/// <para>The field that will store the depth value in the depth contours feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object ContourDepthField { get; set; }

		/// <summary>
		/// <para>Depth Direction</para>
		/// <para>Specifies whether the depth direction is positive upward or positive downward. The direction must be the same as that of the input TIN and contour features for the values of the minimum and maximum depth for the generated depth area polygons to be accurate.</para>
		/// <para>Positive Up—The input contour values, maximum depth, and minimum depth must be negative with drying heights as positive. This is the default.</para>
		/// <para>Positive Down—The input contour values, maximum depth, and minimum depth must be positive with drying heights as negative.</para>
		/// <para><see cref="DepthDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DepthDirection { get; set; } = "POSITIVE_UP";

		/// <summary>
		/// <para>Target Workspace</para>
		/// <para>The geodatabase where the depth polygons will be written. The workspace is expected to be a nautical workspace with either the S-57 or S-101 schemas.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object TargetWorkspace { get; set; }

		/// <summary>
		/// <para>Minimum Depth</para>
		/// <para>A value used to populate the minimum depth of polygons shallower than the shallowest contour value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object MinDepth { get; set; }

		/// <summary>
		/// <para>Maximum Depth</para>
		/// <para>A value used to populate the maximum depth of polygons deeper than the deepest contour value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object MaxDepth { get; set; }

		/// <summary>
		/// <para>Extent Polygon Features</para>
		/// <para>The extent polygons within which the depth area polygons will be generated. If not specified, the TIN domain will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object? InExtentPolygon { get; set; }

		/// <summary>
		/// <para>Updated Depth Areas</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedDepthAreas { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Depth Direction</para>
		/// </summary>
		public enum DepthDirectionEnum 
		{
			/// <summary>
			/// <para>Positive Up—The input contour values, maximum depth, and minimum depth must be negative with drying heights as positive. This is the default.</para>
			/// </summary>
			[GPValue("POSITIVE_UP")]
			[Description("Positive Up")]
			Positive_Up,

			/// <summary>
			/// <para>Positive Down—The input contour values, maximum depth, and minimum depth must be positive with drying heights as negative.</para>
			/// </summary>
			[GPValue("POSITIVE_DOWN")]
			[Description("Positive Down")]
			Positive_Down,

		}

#endregion
	}
}
