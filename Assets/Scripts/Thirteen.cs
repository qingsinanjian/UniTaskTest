using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Thirteen : MonoBehaviour
{
    public Button btn1;
    public Button btn2;
    // Start is called before the first frame update
    void Start()
    {
        TripleClick(this.GetCancellationTokenOnDestroy()).Forget();
        TestClick(this.GetCancellationTokenOnDestroy()).Forget();
    }


    // 使用异步LINQ
    //async UniTask TripleClick(CancellationToken token)
    //{
    //    await btn.OnClickAsAsyncEnumerable().Take(3).Last();
    //    Debug.Log("Three times clicked");
    //}

    // 使用异步LINQ
    async UniTask TripleClick(CancellationToken token)
    {
        await btn1.OnClickAsAsyncEnumerable().Take(3).ForEachAsync(_ =>
        {
            Debug.Log("Every clicked");
        });
        Debug.Log("Three times clicked, complete.");
    }

    async UniTaskVoid TestClick(CancellationToken token)
    {
        var task = btn2.OnClickAsAsyncEnumerable();
        await task.Take(3).ForEachAsync((_,index) =>
        {
            if(token.IsCancellationRequested) return;
            if(index == 0)
            {
                Debug.Log(0);
            }
            else if(index == 1)
            {
                Debug.Log(1);
            }
            else if(index == 2)
            {
                Debug.Log(2);
            }
        },token);
        Debug.Log("All");
    }
}
