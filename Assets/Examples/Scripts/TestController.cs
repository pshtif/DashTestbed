using Dash;
using Dash.Attributes;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public Transform test;

    public bool relative = false;
    
    void Start()
    {
        DashTween.DelayedCall(2, () =>
        {
            test.DashMove(new Vector3(5, 5, 5), .5f).SetRelative(relative).SetEase(EaseType.BACK_OUT);
        });
    }
}
