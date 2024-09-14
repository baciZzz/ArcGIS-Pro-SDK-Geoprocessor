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
	/// <para>Apply Visual Specification To Map</para>
	/// <para>Apply Visual Specification To Map</para>
	/// <para>Applies symbols and Arcade expressions to layers in a map based on the symbols and rules defined in a visual specification database.</para>
	/// </summary>
	public class ApplyVisualSpecificationToMap : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input Map</para>
		/// <para>The map containing layers to which symbols and Arcade expressions will be applied.</para>
		/// </param>
		/// <param name="VsWorkspace">
		/// <para>Visual Specification Workspace</para>
		/// <para>The database containing the visual specification rules.</para>
		/// </param>
		/// <param name="Specification">
		/// <para>Visual Specification</para>
		/// <para>The specification rules that will be converted to Arcade and applied to the map layers.</para>
		/// </param>
		public ApplyVisualSpecificationToMap(object InMap, object VsWorkspace, object Specification)
		{
			this.InMap = InMap;
			this.VsWorkspace = VsWorkspace;
			this.Specification = Specification;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Visual Specification To Map</para>
		/// </summary>
		public override string DisplayName() => "Apply Visual Specification To Map";

		/// <summary>
		/// <para>Tool Name : ApplyVisualSpecificationToMap</para>
		/// </summary>
		public override string ToolName() => "ApplyVisualSpecificationToMap";

		/// <summary>
		/// <para>Tool Excute Name : topographic.ApplyVisualSpecificationToMap</para>
		/// </summary>
		public override string ExcuteName() => "topographic.ApplyVisualSpecificationToMap";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMap, VsWorkspace, Specification, InStyleFile, UpdatedMap };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>The map containing layers to which symbols and Arcade expressions will be applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Visual Specification Workspace</para>
		/// <para>The database containing the visual specification rules.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object VsWorkspace { get; set; }

		/// <summary>
		/// <para>Visual Specification</para>
		/// <para>The specification rules that will be converted to Arcade and applied to the map layers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Specification { get; set; }

		/// <summary>
		/// <para>Input Style File</para>
		/// <para>The style file (.stylx) that contains the symbols defined in the visual specification rules.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object InStyleFile { get; set; }

		/// <summary>
		/// <para>Updated Map</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMap()]
		public object UpdatedMap { get; set; }

	}
}
