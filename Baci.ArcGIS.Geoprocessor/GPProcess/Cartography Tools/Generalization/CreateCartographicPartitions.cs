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
	/// <para>Create Cartographic Partitions</para>
	/// <para>Creates a mesh of polygon features that cover the input feature class in which each output polygon encloses no more than a specified number of  input features or input vertices. as determined by the density and distribution of the input features.</para>
	/// </summary>
	public class CreateCartographicPartitions : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input feature classes or layers with feature distribution and density, or vertex distribution and density, that determine the size and arrangement of output polygons. The input features are typically destined for subsequent processing with other geoprocessing tools. Typically, the input features, when considered simultaneously, would exceed memory limitations of other tools, so partitions are created to subdivide inputs for processing.</para>
		/// </param>
		/// <param name="OutFeatures">
		/// <para>Output Features</para>
		/// <para>The output polygon feature class of partitions each of which encloses a manageable number of input features or manageable number of input vertices not exceeding the number specified by the Feature Count parameter.</para>
		/// </param>
		/// <param name="FeatureCount">
		/// <para>Feature Count</para>
		/// <para>The ideal number of features or vertices (depending on the Partition Method parameter value) to be enclosed by each polygon in the output feature class. The recommended count for features is 50,000, which is the default value. For vertices, 1 million vertices will consume approximately 0.5 GB of memory depending on the tool using the partitions. The feature count cannot be less than 500.</para>
		/// </param>
		public CreateCartographicPartitions(object InFeatures, object OutFeatures, object FeatureCount)
		{
			this.InFeatures = InFeatures;
			this.OutFeatures = OutFeatures;
			this.FeatureCount = FeatureCount;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Cartographic Partitions</para>
		/// </summary>
		public override string DisplayName() => "Create Cartographic Partitions";

		/// <summary>
		/// <para>Tool Name : CreateCartographicPartitions</para>
		/// </summary>
		public override string ToolName() => "CreateCartographicPartitions";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CreateCartographicPartitions</para>
		/// </summary>
		public override string ExcuteName() => "cartography.CreateCartographicPartitions";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise() => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatures, FeatureCount, PartitionMethod };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input feature classes or layers with feature distribution and density, or vertex distribution and density, that determine the size and arrangement of output polygons. The input features are typically destined for subsequent processing with other geoprocessing tools. Typically, the input features, when considered simultaneously, would exceed memory limitations of other tools, so partitions are created to subdivide inputs for processing.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output polygon feature class of partitions each of which encloses a manageable number of input features or manageable number of input vertices not exceeding the number specified by the Feature Count parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Feature Count</para>
		/// <para>The ideal number of features or vertices (depending on the Partition Method parameter value) to be enclosed by each polygon in the output feature class. The recommended count for features is 50,000, which is the default value. For vertices, 1 million vertices will consume approximately 0.5 GB of memory depending on the tool using the partitions. The feature count cannot be less than 500.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain(Min = 500, Max = 2147483647)]
		public object FeatureCount { get; set; } = "50000";

		/// <summary>
		/// <para>Partition Method</para>
		/// <para>Specifies whether the Feature Count parameter references the ideal number of features or the ideal number of vertices in each output polygon.</para>
		/// <para>Features—Partitioning considers the number and density of individual features. This method is applicable in most cases and is the default.</para>
		/// <para>Vertices—Partitioning considers the number and density of vertices. This method is used in cases in which the input data contains a relatively small number of very complex features, such as high-resolution country polygons, or when very long features are likely to cross multiple partition boundaries, such as contour lines.</para>
		/// <para><see cref="PartitionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PartitionMethod { get; set; } = "FEATURES";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateCartographicPartitions SetEnviroment(object outputCoordinateSystem = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Partition Method</para>
		/// </summary>
		public enum PartitionMethodEnum 
		{
			/// <summary>
			/// <para>Features—Partitioning considers the number and density of individual features. This method is applicable in most cases and is the default.</para>
			/// </summary>
			[GPValue("FEATURES")]
			[Description("Features")]
			Features,

			/// <summary>
			/// <para>Vertices—Partitioning considers the number and density of vertices. This method is used in cases in which the input data contains a relatively small number of very complex features, such as high-resolution country polygons, or when very long features are likely to cross multiple partition boundaries, such as contour lines.</para>
			/// </summary>
			[GPValue("VERTICES")]
			[Description("Vertices")]
			Vertices,

		}

#endregion
	}
}
