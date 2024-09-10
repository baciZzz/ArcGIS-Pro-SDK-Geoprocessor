using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Core.Geoprocessing;
using ArcGIS.Desktop.Internal.Core.Conda;
using Baci.ArcGIS.Geoprocessor.Models;
using Newtonsoft.Json.Linq;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Baci.ArcGIS
{
    /// <summary>
    /// 
    /// </summary>
    public static class _Geoprocessor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tooName"></param>
        /// <param name="parameters"></param>
        /// <param name="environments"></param>
        /// <param name="cancellationTokenSource"></param>
        /// <param name="gPToolExecuteEventHandler"></param>
        /// <param name="gPExecuteToolFlags"></param>
        /// <returns></returns>
        public static async Task<IGPResult> ExcuteAsync(string tooName, IReadOnlyList<string> parameters,
            IEnumerable<KeyValuePair<string, string>> environments = null,
            CancellationTokenSource cancellationTokenSource = null,
            GPToolExecuteEventHandler gPToolExecuteEventHandler = null,
            GPExecuteToolFlags gPExecuteToolFlags = GPExecuteToolFlags.Default)
        {
            IGPResult GPResult = await ExcuteAsync(tooName, parameters, cancellationTokenSource, environments, gPToolExecuteEventHandler, gPExecuteToolFlags);
            
            return GPResult;


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tooName"></param>
        /// <param name="parameters"></param>
        /// <param name="cancellationTokenSource"></param>
        /// <param name="environments"></param>
        /// <param name="gPToolExecuteEventHandler"></param>
        /// <param name="gPExecuteToolFlags"></param>
        /// <returns></returns>
        public static async Task<IGPResult> ExcuteAsync(string tooName, IReadOnlyList<string> parameters, CancellationTokenSource cancellationTokenSource,
            IEnumerable<KeyValuePair<string, string>> environments, GPToolExecuteEventHandler gPToolExecuteEventHandler, GPExecuteToolFlags gPExecuteToolFlags = GPExecuteToolFlags.Default)
        {
            return await Geoprocessing.ExecuteToolAsync(tooName, parameters, environments, cancellationTokenSource?.Token,
              gPToolExecuteEventHandler, gPExecuteToolFlags);
        }
    }


}
