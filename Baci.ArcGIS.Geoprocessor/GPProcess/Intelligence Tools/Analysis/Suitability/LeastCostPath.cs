using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Least Cost Path</para>
	/// <para>Least Cost Path</para>
	/// <para>Finds the shortest path between starting points and ending points across a cost surface.</para>
	/// </summary>
	public class LeastCostPath : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCostSurface">
		/// <para>Input Cost Surface</para>
		/// <para>The input raster used to determine the cost to travel from starting point to ending point. No Data values cannot be crossed.</para>
		/// </param>
		/// <param name="InStartPoint">
		/// <para>Input Starting Point</para>
		/// <para>The input starting point feature. Multiple start points will significantly increase processing time.</para>
		/// </param>
		/// <param name="InEndPoint">
		/// <para>Input Ending Point</para>
		/// <para>The input ending point feature. Multiple end points will increase the number of output lines, as the resulting path will branch into separate paths.</para>
		/// </param>
		/// <param name="OutPathFeatureClass">
		/// <para>Output Path Feature Class</para>
		/// <para>The output path feature class.</para>
		/// </param>
		public LeastCostPath(object InCostSurface, object InStartPoint, object InEndPoint, object OutPathFeatureClass)
		{
			this.InCostSurface = InCostSurface;
			this.InStartPoint = InStartPoint;
			this.InEndPoint = InEndPoint;
			this.OutPathFeatureClass = OutPathFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Least Cost Path</para>
		/// </summary>
		public override string DisplayName() => "Least Cost Path";

		/// <summary>
		/// <para>Tool Name : LeastCostPath</para>
		/// </summary>
		public override string ToolName() => "LeastCostPath";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.LeastCostPath</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.LeastCostPath";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise() => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCostSurface, InStartPoint, InEndPoint, OutPathFeatureClass, HandleZeros, OutStartPoint, OutEndPoint };

		/// <summary>
		/// <para>Input Cost Surface</para>
		/// <para>The input raster used to determine the cost to travel from starting point to ending point. No Data values cannot be crossed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InCostSurface { get; set; }

		/// <summary>
		/// <para>Input Starting Point</para>
		/// <para>The input starting point feature. Multiple start points will significantly increase processing time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InStartPoint { get; set; }

		/// <summary>
		/// <para>Input Ending Point</para>
		/// <para>The input ending point feature. Multiple end points will increase the number of output lines, as the resulting path will branch into separate paths.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InEndPoint { get; set; }

		/// <summary>
		/// <para>Output Path Feature Class</para>
		/// <para>The output path feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPathFeatureClass { get; set; }

		/// <summary>
		/// <para>Zero Cost Handled As</para>
		/// <para>Specifies how zero values in the Input Cost Surface parameter will be handled.</para>
		/// <para>Small positive—All zeros will be changed to a small positive value. This will allow the cells to be traversed. This is the default.</para>
		/// <para>No data—All zeros will be changed to null values. The cells will not be traversed and will be avoided.</para>
		/// <para><see cref="HandleZerosEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object HandleZeros { get; set; } = "SMALL_POSITIVE";

		/// <summary>
		/// <para>Output Start Point</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutStartPoint { get; set; }

		/// <summary>
		/// <para>Output End Point</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutEndPoint { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Zero Cost Handled As</para>
		/// </summary>
		public enum HandleZerosEnum 
		{
			/// <summary>
			/// <para>Small positive—All zeros will be changed to a small positive value. This will allow the cells to be traversed. This is the default.</para>
			/// </summary>
			[GPValue("SMALL_POSITIVE")]
			[Description("Small positive")]
			Small_positive,

			/// <summary>
			/// <para>No data—All zeros will be changed to null values. The cells will not be traversed and will be avoided.</para>
			/// </summary>
			[GPValue("NO_DATA")]
			[Description("No data")]
			No_data,

		}

#endregion
	}
}
