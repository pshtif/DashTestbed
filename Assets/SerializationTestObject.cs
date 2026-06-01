using System;
using Dash;
using OdinSerializer;
using Unity.VisualScripting;
using UnityEngine;

//[SerializedId("Test", 0)]
public class SerializationTestObject : MonoBehaviour
{
    public DashController controller;
    
    private void Update()
    {
        Debug.Log(controller.Graph.CurrentExecutionCount);
    }
}
