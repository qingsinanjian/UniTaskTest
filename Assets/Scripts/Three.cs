using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Three : MonoBehaviour
{
    public Transform ball1;
    public Transform ball2;
    // Start is called before the first frame update
    void Start()
    {
        TestWhenAll();
    }

    // Update is called once per frame
    void Update()
    {
        ball1.Translate(Vector3.right * Time.deltaTime);
        ball2.Translate(Vector3.right * Time.deltaTime * 0.5f);
    }

    async void TestWhenAll()
    {
        UniTask task1 = UniTask.WaitUntil(() => ball1.position.x > 1);
        UniTask task2 = UniTask.WaitUntil(() => ball2.position.x > 1);
        await UniTask.WhenAll(task1, task2);
        string str = $"ball1:{ball1.position.x}, ball2:{ball2.position.x}";
        Debug.Log(str);
    }
}
