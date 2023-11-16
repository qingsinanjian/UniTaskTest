using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Eleven : MonoBehaviour
{
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        //ClickN().Forget();
        ClickNA(this.GetCancellationTokenOnDestroy()).Forget();
    }

    private async UniTaskVoid ClickN()
    {
        await btn.OnClickAsync();
        Debug.Log(Time.time);
    }

    private async UniTaskVoid ClickNA(CancellationToken token)
    {
        while (true)
        {
            var click = btn.OnClickAsync(token);
            await click;
            Debug.Log(Time.time);
        }    
    }
}
