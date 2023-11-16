using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fourteen : MonoBehaviour
{
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        TestCol().Forget();
        TestClick().Forget();
    }

    // Update is called once per frame
    void Update()
    {
        ball.transform.Translate(Vector3.right * Time.deltaTime);
    }

    async UniTaskVoid TestCol()
    {
        var col = ball.GetAsyncCollisionEnterTrigger();
        await col.OnCollisionEnterAsync();
        Debug.Log("撞到了");
    }

    private async UniTaskVoid TestClick()
    {
        var click = ball.GetAsyncMouseDownTrigger();
        await click.OnMouseDownAsync();
        Debug.Log("点击了小球");
    }
}
