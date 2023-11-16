using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class Six : MonoBehaviour
{
    public Button btn1;
    public Text text1;

    public Button btn2;
    public Text text2;
    // Start is called before the first frame update
    void Start()
    {
        btn1.onClick.AddListener(() => StartCoroutine(ResNormal()));
        btn2.onClick.AddListener(() => ResUniTask());
    }

    public IEnumerator ResNormal()
    {
        ResourceRequest res = Resources.LoadAsync<TextAsset>("1");
        while (!res.isDone)
        {
            yield return null;
        }

        if(res.asset != null)
        {
            text1.text = ((TextAsset)res.asset).text;
        }
    }

    public async void ResUniTask()
    {
        ResourceRequest res = Resources.LoadAsync<TextAsset>("1");
        var resource = await res;
        text2.text = ((TextAsset)resource).text;
    }
}
