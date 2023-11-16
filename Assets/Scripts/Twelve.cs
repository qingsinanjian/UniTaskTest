using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Twelve : MonoBehaviour
{
    public Button btn;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        //currentTime = Time.realtimeSinceStartup;
        //btn.onClick.AddListener(NormalClick);
        CheckClickInternal(this.GetCancellationTokenOnDestroy()).Forget();
    }


    private void NormalClick()
    {
        if(Time.realtimeSinceStartup - currentTime < 1)
        {
            Debug.Log("双击");
        }
        else
        {
            Debug.Log("单击");
        }
        currentTime = Time.realtimeSinceStartup;
    }

    private async UniTaskVoid CheckClickInternal(CancellationToken token)
    {
        while(true)
        {
            var firstClick = btn.OnClickAsync(token);
            await firstClick;

            var secondClick = btn.OnClickAsync(token);

            int index = await UniTask.WhenAny(secondClick, UniTask.Delay(TimeSpan.FromSeconds(0.35), cancellationToken: token));
            if (index == 0)
            {
                Debug.Log("时间间隔不超过1");
            }
            else
            {
                Debug.Log("时间间隔超过1");
            }
        }      
    }
}
