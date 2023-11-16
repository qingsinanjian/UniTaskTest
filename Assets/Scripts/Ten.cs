using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Ten : MonoBehaviour
{
    public Image image1;
    public Image image2;

    public Button button1;
    public Button button2;

    string url = "https://www.baidu.com/img/PCtm_d9c8750bed0b3c7d089fa7d55720d6cf.png";
    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(() => StartCoroutine(Normal()));
        button2.onClick.AddListener(() => UniTaskGetImg().Forget());
    }

    private IEnumerator Normal()
    {
        UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url);
        yield return webRequest.SendWebRequest();
        if(webRequest.isHttpError || webRequest.isNetworkError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            if (webRequest.isDone)
            {
                var texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
                Sprite sprite = Sprite.Create(texture, new Rect(Vector2.zero, new Vector2(texture.width, texture.height)), new Vector2(0.5f, 0.5f));
                image1.sprite = sprite;
            }
        }
    }

    private async UniTaskVoid UniTaskGetImg()
    {
        UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url);
        await webRequest.SendWebRequest();
        var texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
        Sprite sprite = Sprite.Create(texture, new Rect(Vector2.zero, new Vector2(texture.width, texture.height)), new Vector2(0.5f, 0.5f));
        image2.sprite = sprite;
    }
}
