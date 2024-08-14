using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AviationTools
{
	/// <summary>
	/// <para>Generate Aviation Cartographic Features</para>
	/// <para>Creates cartographic copies of features based on the area of interest (AOI) they fall into.</para>
	/// </summary>
	public class GenerateAviationCartographicFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="SourceTargetCartoFeatures">
		/// <para>Source and Target Cartographic Features</para>
		/// <para>Associates source feature classes with the cartographic feature classes in which they will be generating features.</para>
		/// <para>The first row is the source feature class to copy from, and the second row is the target cartographic feature class to copy features to.</para>
		/// </param>
		/// <param name="AoiFeatures">
		/// <para>Area of Interest Features</para>
		/// <para>A layer of AOI polygon features that will be used to spatially filter source features.</para>
		/// </param>
		public GenerateAviationCartographicFeatures(object SourceTargetCartoFeatures, object AoiFeatures)
		{
			this.SourceTargetCartoFeatures = SourceTargetCartoFeatures;
			this.AoiFeatures = AoiFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Aviation Cartographic Features</para>
		/// </summary>
		public override string DisplayName => "Generate Aviation Cartographic Features";

		/// <summary>
		/// <para>Tool Name : GenerateAviationCartographicFeatures</para>
		/// </summary>
		public override string ToolName => "GenerateAviationCartographicFeatures";

		/// <summary>
		/// <para>Tool Excute Name : aviation.GenerateAviationCartographicFeatures</para>
		/// </summary>
		public override string ExcuteName => "aviation.GenerateAviationCartographicFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Aviation Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Aviation Tools";

		/// <summary>
		/// <para>Toolbox Alise : aviation</para>
		/// </summary>
		public override string ToolboxAlise => "aviation";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { SourceTargetCartoFeatures, AoiFeatures, ExtractionQueryTable!, InclusionExclusionTable!, CartoFeatureClasses! };

		/// <summary>
		/// <para>Source and Target Cartographic Features</para>
		/// <para>Associates source feature classes with the cartographic feature classes in which they will be generating features.</para>
		/// <para>The first row is the source feature class to copy from, and the second row is the target cartographic feature class to copy features to.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object SourceTargetCartoFeatures { get; set; }

		/// <summary>
		/// <para>Area of Interest Features</para>
		/// <para>A layer of AOI polygon features that will be used to spatially filter source features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object AoiFeatures { get; set; }

		/// <summary>
		/// <para>Extraction Query Table</para>
		/// <para>A table of where clauses that will be used to further filter source features based on an attribute query.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		[GPTablesDomain()]
		public object? ExtractionQueryTable { get; set; }

		/// <summary>
		/// <para>Cartographic Exceptions Table</para>
		/// <para>A table identifying manually included or excluded source features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		[GPTablesDomain()]
		public object? InclusionExclusionTable { get; set; }

		/// <summary>
		/// <para>Updated Cartographic Feature Classes</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? CartoFeatureClasses { get; set; }

	}
}
