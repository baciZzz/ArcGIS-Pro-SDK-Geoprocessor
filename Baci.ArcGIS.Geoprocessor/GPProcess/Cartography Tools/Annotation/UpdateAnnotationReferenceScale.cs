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
	/// <para>Update Annotation Reference Scale</para>
	/// <para>Update Annotation Reference Scale</para>
	/// <para>Updates the reference scale of an existing annotation or dimension feature class.</para>
	/// </summary>
	public class UpdateAnnotationReferenceScale : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InAnnoFeatures">
		/// <para>Input Annotation Features</para>
		/// <para>The input annotation or dimension features.</para>
		/// </param>
		/// <param name="ReferenceScale">
		/// <para>Reference Scale</para>
		/// <para>The feature class reference scale to be updated.</para>
		/// </param>
		public UpdateAnnotationReferenceScale(object InAnnoFeatures, object ReferenceScale)
		{
			this.InAnnoFeatures = InAnnoFeatures;
			this.ReferenceScale = ReferenceScale;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Annotation Reference Scale</para>
		/// </summary>
		public override string DisplayName() => "Update Annotation Reference Scale";

		/// <summary>
		/// <para>Tool Name : UpdateAnnotationReferenceScale</para>
		/// </summary>
		public override string ToolName() => "UpdateAnnotationReferenceScale";

		/// <summary>
		/// <para>Tool Excute Name : cartography.UpdateAnnotationReferenceScale</para>
		/// </summary>
		public override string ExcuteName() => "cartography.UpdateAnnotationReferenceScale";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InAnnoFeatures, ReferenceScale, UpdatedAnnotation! };

		/// <summary>
		/// <para>Input Annotation Features</para>
		/// <para>The input annotation or dimension features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InAnnoFeatures { get; set; }

		/// <summary>
		/// <para>Reference Scale</para>
		/// <para>The feature class reference scale to be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object ReferenceScale { get; set; }

		/// <summary>
		/// <para>Updated Annotation</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? UpdatedAnnotation { get; set; }

	}
}
