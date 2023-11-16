using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One : MonoBehaviour
{
    async void Start()
    {
        //Time.timeScale = 0;
        //Debug.Log("Start:" + Time.time);
        //await UniTask.Delay(TimeSpan.FromSeconds(1));
        //await UniTask.Delay(1000);
        //await UniTask.Delay(1000, true);
        //Debug.Log("End:" + Time.time);

        Debug.Log("Start:" + Time.frameCount);
        //await UniTask.DelayFrame(100);
        await UniTask.NextFrame();
        Debug.Log("End:" + Time.frameCount);
    }

}
