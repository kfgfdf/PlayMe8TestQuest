using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; 

public class TakeAvatars : MonoBehaviour
{
    //public string[] URL;
    

    //public Image[] uiImage;

    public CreateSlots mainScript;
    public int count;
    private bool _isStart;

    public void Update()
    {
        if(!_isStart)
        if(mainScript._isComplete)
        {
        StartCoroutine(GetTexture());
        _isStart = true;
        }
    }

    IEnumerator GetTexture()   
    {
        for(count = 0; count < mainScript.TotalElementsInJson; count++)
        {
        //while (count < mainScript.TotalElementsInJson)
        
        //UnityWebRequest www = UnityWebRequestTexture.GetTexture(URL[i]);
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(mainScript.allurlImage[count]);

        yield return www.Send();

            if(www.isNetworkError) 
            {
            Debug.Log(www.error);
            }
            else 
            {
            //Debug.Log("CompleteDownload");

            Texture2D webTexture = ((DownloadHandlerTexture)www.downloadHandler).texture as Texture2D;
            Sprite webSprite = SpriteFromTexture2D (webTexture);
            mainScript.allAvatars[count].sprite = webSprite;
            Debug.Log("SpritePlayerAvatarChange");
            }
        }
    }

    Sprite SpriteFromTexture2D(Texture2D texture) 
    {
        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        Debug.Log("RenderTextureToSprite");
    }
}

