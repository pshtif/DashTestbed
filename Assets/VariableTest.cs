using System.Collections;
using System.Collections.Generic;
using Dash;
using UnityEngine;

public class VariableTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log(GetComponent<DashController>().Graph.variables.GetVariable<Vector2>("position"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
