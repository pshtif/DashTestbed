/*
 *	Created by:  Peter @sHTiF Stefcek
 */

using System.Threading;
using System.Threading.Tasks;
using Dash;

namespace Examples.Scripts
{
    public class CustomExecuteAsync : ICustomExecuteAsync
    {
        public async Task Execute(NodeFlowData p_flowData)
        {
            await Task.Delay(1000);
        }

        public void Stop()
        {
            
        }
    }
}