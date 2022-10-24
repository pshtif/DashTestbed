
using Dash;
using OdinSerializer.Utilities;
using UnityEngine;
using UnityEngine.UI;

public class TestHandler : MonoBehaviour
{
    
    void Start()
    {
        DashCore.Instance.AddListener("TestEvent", OnTest);
    }

    void OnTest(NodeFlowData p_data)
    {
        Debug.Log("Test");
    }
}