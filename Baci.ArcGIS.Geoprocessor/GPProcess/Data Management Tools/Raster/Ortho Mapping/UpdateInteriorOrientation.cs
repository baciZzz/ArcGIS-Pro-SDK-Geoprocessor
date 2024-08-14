using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Update Interior Orientation</para>
	/// <para>Refines the interior orientation for each image in the mosaic dataset by constructing an affine transformation from a fiducial table.</para>
	/// </summary>
	public class UpdateInteriorOrientation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>The mosaic dataset that is created from scanned aerial photos using the scanned raster type or frame camera raster type.</para>
		/// </param>
		public UpdateInteriorOrientation(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Interior Orientation</para>
		/// </summary>
		public override string DisplayName => "Update Interior Orientation";

		/// <summary>
		/// <para>Tool Name : UpdateInteriorOrientation</para>
		/// </summary>
		public override string ToolName => "UpdateInteriorOrientation";

		/// <summary>
		/// <para>Tool Excute Name : management.UpdateInteriorOrientation</para>
		/// </summary>
		public override string ExcuteName => "management.UpdateInteriorOrientation";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InMosaicDataset, WhereClause!, FiducialTable!, FilmCoordinateSystem!, UpdateFootprints!, OutMosaicDataset! };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>The mosaic dataset that is created from scanned aerial photos using the scanned raster type or frame camera raster type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>A query definition string that defines a subset of rasters for computing fiducials.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Fiducial Table</para>
		/// <para>The fiducial table created using the Compute Fiducials tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object? FiducialTable { get; set; }

		/// <summary>
		/// <para>Film Coordinate System</para>
		/// <para>Defines the film coordinate system of the scanned aerial photograph. It is used in computing fiducial information and affine transformation construction.</para>
		/// <para>No change—Maintain the coordinate system of the mosaic dataset. Do not change the film coordinate system of the scanned aerial photograph. Maintain the coordinate system of the mosaic dataset.</para>
		/// <para>X right, Y up—The origin of the scanned photo&apos;s coordinate system is the center, and positive X points right and positive Y points up.</para>
		/// <para>X up, Y left—The origin of the scanned photo&apos;s coordinate system is the center, and positive X points up and positive Y points left.</para>
		/// <para>X left, Y down—The origin of the scanned photo&apos;s coordinate system is the center, and positive X points left and positive Y points down.</para>
		/// <para>X down, Y right—The origin of the scanned photo&apos;s coordinate system is the center, and positive X points down and positive Y points right.</para>
		/// <para><see cref="FilmCoordinateSystemEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FilmCoordinateSystem { get; set; } = "NO_CHANGE";

		/// <summary>
		/// <para>Update Footprints</para>
		/// <para>Generates or updates the footprints of the digital photos in the mosaic dataset.</para>
		/// <para>Checked—The footprints will be generated or updated.</para>
		/// <para>Unchecked—The footprints will not be generated or updated. This is the default</para>
		/// <para><see cref="UpdateFootprintsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UpdateFootprints { get; set; } = "false";

		/// <summary>
		/// <para>Output Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutMosaicDataset { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Film Coordinate System</para>
		/// </summary>
		public enum FilmCoordinateSystemEnum 
		{
			/// <summary>
			/// <para>No change—Maintain the coordinate system of the mosaic dataset. Do not change the film coordinate system of the scanned aerial photograph. Maintain the coordinate system of the mosaic dataset.</para>
			/// </summary>
			[GPValue("NO_CHANGE")]
			[Description("No change")]
			No_change,

			/// <summary>
			/// <para>X right, Y up—The origin of the scanned photo&apos;s coordinate system is the center, and positive X points right and positive Y points up.</para>
			/// </summary>
			[GPValue("X_RIGHT_Y_UP")]
			[Description("X right, Y up")]
			X_RIGHT_Y_UP,

			/// <summary>
			/// <para>X up, Y left—The origin of the scanned photo&apos;s coordinate system is the center, and positive X points up and positive Y points left.</para>
			/// </summary>
			[GPValue("X_UP_Y_LEFT")]
			[Description("X up, Y left")]
			X_UP_Y_LEFT,

			/// <summary>
			/// <para>X left, Y down—The origin of the scanned photo&apos;s coordinate system is the center, and positive X points left and positive Y points down.</para>
			/// </summary>
			[GPValue("X_LEFT_Y_DOWN")]
			[Description("X left, Y down")]
			X_LEFT_Y_DOWN,

			/// <summary>
			/// <para>X down, Y right—The origin of the scanned photo&apos;s coordinate system is the center, and positive X points down and positive Y points right.</para>
			/// </summary>
			[GPValue("X_DOWN_Y_RIGHT")]
			[Description("X down, Y right")]
			X_DOWN_Y_RIGHT,

		}

		/// <summary>
		/// <para>Update Footprints</para>
		/// </summary>
		public enum UpdateFootprintsEnum 
		{
			/// <summary>
			/// <para>Checked—The footprints will be generated or updated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE")]
			UPDATE,

			/// <summary>
			/// <para>Unchecked—The footprints will not be generated or updated. This is the default</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UPDATE")]
			NO_UPDATE,

		}

#endregion
	}
}
