using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>Iterate Feature Classes</para>
	/// <para>Iterates over feature classes in a workspace or feature dataset.</para>
	/// </summary>
	public class IterateFeatureClasses : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Workspace or Feature Dataset</para>
		/// <para>Workspace or feature dataset which stores the feature classes to iterate. If you define a geodatabase as your input workspace only the feature classes directly under the geodatabase will be iterated over (standalone feature classes). To iterate over all feature classes within a dataset located in the input geodatabase check the recursive option.</para>
		/// </param>
		public IterateFeatureClasses(object InWorkspace)
		{
			this.InWorkspace = InWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : Iterate Feature Classes</para>
		/// </summary>
		public override string DisplayName => "Iterate Feature Classes";

		/// <summary>
		/// <para>Tool Name : IterateFeatureClasses</para>
		/// </summary>
		public override string ToolName => "IterateFeatureClasses";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateFeatureClasses</para>
		/// </summary>
		public override string ExcuteName => "mb.IterateFeatureClasses";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InWorkspace, Wildcard!, FeatureType!, Recursive!, Features!, Name! };

		/// <summary>
		/// <para>Workspace or Feature Dataset</para>
		/// <para>Workspace or feature dataset which stores the feature classes to iterate. If you define a geodatabase as your input workspace only the feature classes directly under the geodatabase will be iterated over (standalone feature classes). To iterate over all feature classes within a dataset located in the input geodatabase check the recursive option.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Wildcard</para>
		/// <para>A combination of * and characters that help to limit the results. The asterisk is the same as specifying ALL. If no wildcard is specified, all inputs will be returned. For example, it can be used to restrict Iteration over input names starting with a certain character or word (for example, A* or Ari* or Land* and so on).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Wildcard { get; set; }

		/// <summary>
		/// <para>Feature Type</para>
		/// <para>The feature type to be used as a filter. Only features of the specified type will be output. Not specifying a feature type means that all features will be output.</para>
		/// <para>Annotation—Only annotation feature classes will be the output.</para>
		/// <para>Dimension—Only dimension feature classes will be the output.</para>
		/// <para>Edge—Only edge feature classes will be the output.</para>
		/// <para>Junction—Only junction feature classes will be the output.</para>
		/// <para>Line— Only line feature classes will be the output.</para>
		/// <para>Point—Only point feature classes will be the output.</para>
		/// <para>Polygon—Only polygon feature classes will be the output.</para>
		/// <para>Multipatch—Only multipatch feature classes will be the output.</para>
		/// <para><see cref="FeatureTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FeatureType { get; set; }

		/// <summary>
		/// <para>Recursive</para>
		/// <para>Determines if the iterator will iterate through all sub-folders in the main workspace.</para>
		/// <para>Checked—Will iterate through all subfolders.</para>
		/// <para>Unchecked—Will not iterate through all subfolders.</para>
		/// <para><see cref="RecursiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Recursive { get; set; } = "false";

		/// <summary>
		/// <para>Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? Features { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? Name { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Feature Type</para>
		/// </summary>
		public enum FeatureTypeEnum 
		{
			/// <summary>
			/// <para>Annotation—Only annotation feature classes will be the output.</para>
			/// </summary>
			[GPValue("ANNOTATION")]
			[Description("Annotation")]
			Annotation,

			/// <summary>
			/// <para>Dimension—Only dimension feature classes will be the output.</para>
			/// </summary>
			[GPValue("DIMENSION")]
			[Description("Dimension")]
			Dimension,

			/// <summary>
			/// <para>Edge—Only edge feature classes will be the output.</para>
			/// </summary>
			[GPValue("EDGE")]
			[Description("Edge")]
			Edge,

			/// <summary>
			/// <para>Junction—Only junction feature classes will be the output.</para>
			/// </summary>
			[GPValue("JUNCTION")]
			[Description("Junction")]
			Junction,

			/// <summary>
			/// <para>Line— Only line feature classes will be the output.</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("Line")]
			Line,

			/// <summary>
			/// <para>Point—Only point feature classes will be the output.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

			/// <summary>
			/// <para>Polygon—Only polygon feature classes will be the output.</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon")]
			Polygon,

			/// <summary>
			/// <para>Multipatch—Only multipatch feature classes will be the output.</para>
			/// </summary>
			[GPValue("MULTIPATCH")]
			[Description("Multipatch")]
			Multipatch,

		}

		/// <summary>
		/// <para>Recursive</para>
		/// </summary>
		public enum RecursiveEnum 
		{
			/// <summary>
			/// <para>Checked—Will iterate through all subfolders.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RECURSIVE")]
			RECURSIVE,

			/// <summary>
			/// <para>Unchecked—Will not iterate through all subfolders.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_RECURSIVE")]
			NOT_RECURSIVE,

		}

#endregion
	}
}
