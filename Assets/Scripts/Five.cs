using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Five : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        //UniTask.Void(async () =>
        //{
        //    Debug.Log("Start:" + Time.frameCount);
        //    //await UniTask.DelayFrame(100);
        //    await UniTask.NextFrame();
        //    Debug.Log("End:" + Time.frameCount);
        //});

        await UniTask.Defer(async () =>
        {
            Debug.Log("Start:" + Time.frameCount);
            //await UniTask.DelayFrame(100);
            await UniTask.NextFrame();
            Debug.Log("End:" + Time.frameCount);
        });
    }
}
