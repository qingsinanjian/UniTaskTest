using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Eight : MonoBehaviour
{
    private CancellationTokenSource cts;
    private CancellationToken token;

    // Start is called before the first frame update
    void Start()
    {
        cts = new CancellationTokenSource();
        token = cts.Token;
        ClickA();
        //cts.Cancel();
        cts.CancelAfterSlim(TimeSpan.FromSeconds(3));
    }

    async UniTask<int> TestCancelAfter(CancellationToken token)
    {
        for(int i = 0; i < 5; i++)
        {
            Debug.Log($"Working...{i + 1}");
            await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken:token);
        }
        return 0;
    }

    async UniTaskVoid ClickA()
    {
        try
        {
            await TestCancelAfter(cts.Token);
        }catch(OperationCanceledException)
        {
            Debug.Log("stop");
        }
    }
}
