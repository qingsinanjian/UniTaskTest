using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Nine : MonoBehaviour
{
    public Button btn1;
    public Button btn2;

    public Text text1;
    public Text text2;

    public string url1 = "https://www.baidu.com/";
    public string url2 = "https://www.google.com";

    // Start is called before the first frame update
    void Start()
    {
        btn1.onClick.AddListener(() => OnClickTest(url1, text1).Forget());
        btn2.onClick.AddListener(() => OnClickTest(url2, text2).Forget());
    }

    private async UniTask<string> VisitWeb(string url, float timeOut)
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        cts.CancelAfterSlim(TimeSpan.FromSeconds(timeOut));
        var(failed, result) = await UnityWebRequest.Get(url).SendWebRequest().WithCancellation(cts.Token).SuppressCancellationThrow();
        if(!failed)
        {
            return result.downloadHandler.text.Substring(20);
        }
        return "³¬Ê±";
    }

    private async UniTaskVoid OnClickTest(string url, Text text)
    {
        var res = await VisitWeb(url, 2);
        text.text = res;
    }
}
