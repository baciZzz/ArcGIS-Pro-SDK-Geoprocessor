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
	/// <para>If Data Exists</para>
	/// <para>If Data Exists</para>
	/// <para>Evaluates if the specified data exists.</para>
	/// </summary>
	public class DataExistsIfThenElse : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		public DataExistsIfThenElse()
		{
		}

		/// <summary>
		/// <para>Tool Display Name : If Data Exists</para>
		/// </summary>
		public override string DisplayName() => "If Data Exists";

		/// <summary>
		/// <para>Tool Name : DataExistsIfThenElse</para>
		/// </summary>
		public override string ToolName() => "DataExistsIfThenElse";

		/// <summary>
		/// <para>Tool Excute Name : mb.DataExistsIfThenElse</para>
		/// </summary>
		public override string ExcuteName() => "mb.DataExistsIfThenElse";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise() => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InData, DataType, True, False };

		/// <summary>
		/// <para>Input Data Element</para>
		/// <para>Input data element to be evaluated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPType()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Data Type</para>
		/// <para>The data type of the data element being evaluated. The only time you need to provide a value is when a geodatabase contains a feature dataset and a feature class or table with the same name. In this case, you need to select the data type (feature dataset, feature class or table) of the item you want to evaluate.</para>
		/// <para>Any—Any Value. This is the default.</para>
		/// <para>Feature Dataset—Feature Dataset</para>
		/// <para>Feature Class—Feature Class</para>
		/// <para>Table—Table</para>
		/// <para>View—View</para>
		/// <para>Relationship Class—Relationship Class</para>
		/// <para>Raster Dataset—Raster Dataset</para>
		/// <para>Mosaic Dataset—Mosaic Dataset</para>
		/// <para>Toolbox—Toolbox</para>
		/// <para>Topology—Topology</para>
		/// <para><see cref="DataTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DataType { get; set; } = "ANY";

		/// <summary>
		/// <para>True</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object True { get; set; } = "false";

		/// <summary>
		/// <para>False</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object False { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Data Type</para>
		/// </summary>
		public enum DataTypeEnum 
		{
			/// <summary>
			/// <para>Any—Any Value. This is the default.</para>
			/// </summary>
			[GPValue("ANY")]
			[Description("Any")]
			Any,

			/// <summary>
			/// <para>Feature Dataset—Feature Dataset</para>
			/// </summary>
			[GPValue("DEFeatureDataset")]
			[Description("Feature Dataset")]
			Feature_Dataset,

			/// <summary>
			/// <para>Feature Class—Feature Class</para>
			/// </summary>
			[GPValue("DEFeatureClass")]
			[Description("Feature Class")]
			Feature_Class,

			/// <summary>
			/// <para>Table—Table</para>
			/// </summary>
			[GPValue("DETable")]
			[Description("Table")]
			Table,

			/// <summary>
			/// <para>View—View</para>
			/// </summary>
			[GPValue("DEView")]
			[Description("View")]
			View,

			/// <summary>
			/// <para>Relationship Class—Relationship Class</para>
			/// </summary>
			[GPValue("DERelationshipClass")]
			[Description("Relationship Class")]
			Relationship_Class,

			/// <summary>
			/// <para>Raster Dataset—Raster Dataset</para>
			/// </summary>
			[GPValue("DERasterDataset")]
			[Description("Raster Dataset")]
			Raster_Dataset,

			/// <summary>
			/// <para>Mosaic Dataset—Mosaic Dataset</para>
			/// </summary>
			[GPValue("DEMosaicDataset")]
			[Description("Mosaic Dataset")]
			Mosaic_Dataset,

			/// <summary>
			/// <para>Toolbox—Toolbox</para>
			/// </summary>
			[GPValue("DEToolbox")]
			[Description("Toolbox")]
			Toolbox,

			/// <summary>
			/// <para>Topology—Topology</para>
			/// </summary>
			[GPValue("DETopology")]
			[Description("Topology")]
			Topology,

		}

#endregion
	}
}
