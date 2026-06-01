using Dash;
using UnityEngine;
using UnityEngine.Profiling;

public class TestController : MonoBehaviour
{

    public DashController controller;

    public DashGraph graph;
    
    public void Test()
    {
        controller?.ChangeGraph(graph);
    }
}
