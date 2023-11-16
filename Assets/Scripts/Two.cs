using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Two : MonoBehaviour
{
    public GameObject ball;
    void Start()
    {
        WaitUntilTest();
        WaitUntilValueChangeTest();
    }

    void Update()
    {
        ball.transform.Translate(Vector3.right * Time.deltaTime);
    }

    async void WaitUntilTest()
    {
        Debug.Log("Start:" + Time.time);
        await UniTask.WaitUntil(() => isBallFarTanOne());
        Debug.Log("End:" + Time.time);
        ball.GetComponent<Renderer>().material.color = Color.red;
    }

    private bool isBallFarTanOne()
    {
        if(ball.transform.position.x > 1)
        {
            return true;
        }
        return false;
    }

    async void WaitUntilValueChangeTest()
    {
        await UniTask.WaitUntilValueChanged(ball.transform, x => x.position);
        Debug.Log("小球位置发生变化");
    }
}
