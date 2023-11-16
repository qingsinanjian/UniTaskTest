using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Seven : MonoBehaviour
{
    public GameObject ball;

    public Button btn1;
    public Button btn2;

    private CancellationTokenSource cts;
    private CancellationToken token;
    // Start is called before the first frame update
    void Start()
    {
        cts = new CancellationTokenSource();
        token = cts.Token;
        btn1.onClick.AddListener(Click1);
        btn2.onClick.AddListener(Click2);
    }

    private async UniTask<int> Move(Transform transform, CancellationToken token)
    {
        float totalTime = 5f;
        float currentTime = 0;

        while (currentTime < totalTime)
        {
            transform.position += Vector3.right * Time.deltaTime;
            currentTime += Time.deltaTime;
            await UniTask.NextFrame(token);
        }
        return 0;
    }

    private async void Click1()
    {
        try
        {
            await Move(ball.transform, cts.Token);
        }
        catch (OperationCanceledException)
        {
            Debug.Log("²¶»ñµ½Òì³£");
        }
    }

    private void Click2()
    {
        cts.Cancel();
        cts.Dispose();
        cts = new CancellationTokenSource();
    }
}
