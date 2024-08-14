using ArcGIS.Desktop.Core.Geoprocessing;
using Baci.ArcGIS.Geoprocessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System
{
    public static class IGPProcessExtension
    {
        public static async Task<T> Run<T>(this T gPProcess, CancellationTokenSource cancellationTokenSource = null,
            bool showResultDig = false, GPToolExecuteEventHandler gPToolExecuteEventHandler = null,
            GPExecuteToolFlags gPExecuteToolFlags = GPExecuteToolFlags.None) where T : IGPProcess
        {
            var parameterInfo = Geoprocessing.MakeValueArray(gPProcess.Parameters);

            var result = await Baci.ArcGIS._Geoprocessor.ExcuteAsync(gPProcess.ExcuteName, parameterInfo, gPProcess.Environments,
                cancellationTokenSource, gPToolExecuteEventHandler, gPExecuteToolFlags);

            gPProcess.GPResult = result;

            DerivedParameterReflow(gPProcess, result);

            return gPProcess;
        }

        /// <summary>
        /// Derived Parameter Reflow
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gPProcess"></param>
        /// <param name="result"></param>
        private static void DerivedParameterReflow<T>(T gPProcess, IGPResult result) where T : IGPProcess
        {
            var ps = result.Parameters?.ToList();

            if (ps == null)
                return;

            for (int i = 0; i < ps.Count(); i++)
            {
                var tp = ps[i];

                if (tp.Item4)
                    continue;

                if (string.IsNullOrEmpty(tp.Item3))
                    continue;

                try
                {
                    string propertyName = ToolParamNameFix(tp.Item1);

                    var type = gPProcess.GetType();

                    var property = type.GetProperty($"{propertyName}");

                    if (property is null)
                    {
                        throw new Exception($"Can't Find Property ：{propertyName}");
                    }

                    property.SetValue(gPProcess, tp.Item3);
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }


            }

            string ToolParamNameFix(string text)
            {
                if (text.Contains("_") || text.Contains("-"))
                {
                    return string.Join("", text.Split('_', '-').Select(c => Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(c)));
                }
                return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(text);
            }
        }
    }
}
