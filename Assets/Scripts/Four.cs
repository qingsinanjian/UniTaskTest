using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Four : MonoBehaviour
{
    public Button btn1;
    public Button btn2;
    public bool isClick1;
    public bool isClick2;
    // Start is called before the first frame update
    void Start()
    {
        btn1.onClick.AddListener(Click1);
        btn2.onClick.AddListener(Click2);
        //AllBtnClick();
        AnyBtnClick();
    }

    private void Click1()
    {
        isClick1 = true;
    }

    private void Click2()
    {
        isClick2 = true;
    }

    async void AllBtnClick()
    {
        UniTask task1 = UniTask.WaitUntil(() => isClick1);
        UniTask task2 = UniTask.WaitUntil(() => isClick2);
        await UniTask.WhenAll(task1, task2);
        Debug.Log("都点击了");
    }

    async void AnyBtnClick()
    {
        UniTask task1 = UniTask.WaitUntil(() => isClick1);
        UniTask task2 = UniTask.WaitUntil(() => isClick2);
        await UniTask.WhenAny(task1, task2);
        Debug.Log("点击了");
    }
}
