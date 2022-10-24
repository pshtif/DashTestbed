/*
 *	Created by:  Peter @sHTiF Stefcek
 */

using Dash;
using Dash.Attributes;
using Dash.Examples;

// namespace Test.Examples
// {
    [Category(NodeCategoryType.OTHER, "Examples")]
    [OutputCount(2)]
    [OutputLabels("aaa","bbb")]
    [Experimental]
    public class CustomNode : NodeBase<CustomNodeModel>
    {
        protected override void OnExecuteStart(NodeFlowData p_flowData)
        { 
            OnExecuteEnd();
        }
    }
// }