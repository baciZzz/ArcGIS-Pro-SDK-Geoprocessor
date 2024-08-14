using ArcGIS.Core.CIM;
using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ArcGIS.Desktop.Catalog;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Core.Geoprocessing;
using ArcGIS.Desktop.Editing;
using ArcGIS.Desktop.Extensions;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Dialogs;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Layouts;
using ArcGIS.Desktop.Mapping;
using Baci.ArcGIS.Geoprocessor.ConversionTools;
using Baci.ArcGIS.Geoprocessor.DataManagementTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project = ArcGIS.Desktop.Core.Project;

namespace ProAppModuleTest.Buttons
{
    internal class ButtonTest : Button
    {
        protected override void OnClick()
        {
            QueuedTask.Run(async () =>
            {
                FeatureLayer featureLayer = MapView.Active.Map.Layers
                .Where(layer => layer is FeatureLayer)
                .Select(c => c as FeatureLayer)
                .FirstOrDefault();

                if (featureLayer is null) return;

                var project = Project.Current;
                var defaultGeodatabasePath = project.DefaultGeodatabasePath;

                IGPResult result = (await new FeatureClassToFeatureClass(featureLayer,
                    defaultGeodatabasePath,
                    "OutputByFcToFcGPTool")
                    .SetEnviroment(outputCoordinateSystem: 4490)
                    .Run()).GPResult;

                SelectLayerByAttribute tool = await new SelectLayerByAttribute(featureLayer)
                {
                    WhereClause = "objectid = 1",
                    //codeValueTypeEnum
                    SelectionType = SelectLayerByAttribute.SelectionTypeEnum.New_selection.Value()
                }.Run();

                result = tool.GPResult;
                //Derived Parameter Reflow
                Console.WriteLine(tool.Count);
            });
        }
    }
}
