using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fifteen : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        UniTaskCompletionSource<string> uniTaskCompletionSource = new UniTaskCompletionSource<string>();
        UniTask<string> uniTask = uniTaskCompletionSource.Task;

        //uniTaskCompletionSource.TrySetResult("任务完成");
        //string result = await uniTask;
        //Debug.Log(result);

        uniTaskCompletionSource.TrySetCanceled();

        try
        {
            await uniTask;
        }
        catch (OperationCanceledException)
        {
            Debug.Log("任务取消");
        }
    }
}
