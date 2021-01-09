using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Networking;
using TMPro;

public class CreateSlots : MonoBehaviour
{
    //public TextMeshProUGUI tnameslot, tnick, tcount, tprice;


    public string url;


    public string DataJson;

    public GameObject SlotPref, BGimage;
    private GameObject newSlot;

    public int TotalElementsInJson;

    private float plus1, plus2, plus3;

    private GameObject[] allSlots, allNicksGO, allPriceGO, allNameSlotGO, allCountGO, allAvatarsGO, allTovarIconGO, allPlayerExpGO;
    private TextMeshProUGUI[] allNicks, allPrice, allNameSlot, allCount, allPlayerExp;
    public string[] allurlImage;
    public Image[] allAvatars;

    private SpriteRenderer[] allTovarIcon;
    public Sprite Wheat, Mushrooms, Corn, Butter;

    public bool _isComplete;
    public GameObject PreStartBut, MarketCanvas, PreStartCanvas, DadyGO;

    public StopScrollLeft TriggerLeft;
    public StopScrollRight TriggerRight;

    private Vector2 startPos, startPosDady, curPosDady;
    public Camera camera;
    public float curPos, nicePos, mathfPos;

    private bool RightBut;
    private int NapravlenTouch;

    public Scrollbar scrol;

    void Start()
    {
        StartCoroutine(LoadTextFromServer(url,""));
    }
    void Update()
    {
        // if (Input.touchCount > 0)
        // {
        // if (Input.GetTouch(0).phase == TouchPhase.Moved)
        // {
        //     Debug.Log("Touch phase = Moved");
        //     if(Input.GetTouch(0).position.x > 0)
        //     NapravlenTouch = 1;
        //     else if(Input.GetTouch(0).position.x < 0)
        //     NapravlenTouch = -1;
        // }
        // if (Input.GetTouch(0).phase == TouchPhase.Ended)
        // {
        //    // DadyGO.transform.localPosition = new Vector2(DadyGO.transform.localPosition.x + (4.5f * NapravlenTouch), 0);
        //    if(NapravlenTouch > 0 && !TriggerLeft._isEmptyLeft)
        //  {
        //   foreach (GameObject slots in allSlots)
        //   {
        //       slots.transform.localPosition = new Vector2(slots.transform.localPosition.x + 4.5f, slots.transform.localPosition.y);
        //   }
        //  }
        //  if(NapravlenTouch < 0 && !TriggerRight._isEmptyRight)
        //  {
        //   foreach (GameObject slots in allSlots)
        //   {
        //       slots.transform.localPosition = new Vector2(slots.transform.localPosition.x - 4.5f, slots.transform.localPosition.y);
        //   }
        //  }
        // }
        // }



        // if(Input.GetMouseButtonDown(0))
        // {
        // startPos = camera.ScreenToWorldPoint(Input.mousePosition);
        // startPosDady = DadyGO.transform.localPosition;
        // }
        // else if(Input.GetMouseButton(0))
        // {
        //     curPos = camera.ScreenToWorldPoint(Input.mousePosition).x - startPos.x;
        //     DadyGO.transform.localPosition = new Vector3(DadyGO.transform.localPosition.x - curPos * 0.01f, DadyGO.transform.localPosition.y, DadyGO.transform.localPosition.z);
        //     curPosDady = DadyGO.transform.localPosition;
        //     ViewSlots();
        // }
        // else if(Input.GetMouseButtonUp(0))
        // {
        //     if(DadyGO.transform.localPosition.x % 4.5f != 0)
        //     nicePos = Mathf.Round(DadyGO.transform.localPosition.x / 4.5f);
        //     if(!RightBut)
        //     DadyGO.transform.localPosition = new Vector3(nicePos * 4.5f, DadyGO.transform.localPosition.y, DadyGO.transform.localPosition.z);
        // }

        // if(Input.GetMouseButtonDown(0))
        // {
        // startPos = camera.ScreenToWorldPoint(Input.mousePosition);
        // //startPosDady = DadyGO.transform.localPosition;
        // }
        // else if(Input.GetMouseButton(0))
        // {
        //     curPos = camera.ScreenToWorldPoint(Input.mousePosition).x - startPos.x;
        //     //DadyGO.transform.localPosition = new Vector3(DadyGO.transform.localPosition.x - curPos * 0.01f, DadyGO.transform.localPosition.y, DadyGO.transform.localPosition.z);
        //     //curPosDady = DadyGO.transform.localPosition;
        //     //ViewSlots();
        // }
        // else if(Input.GetMouseButtonUp(0))
        // {
        //     if(curPos > 0 && !TriggerLeft._isEmptyLeft)
        //     {
        //         foreach (GameObject slots in allSlots)
        //       {
        //          slots.transform.localPosition = new Vector2(slots.transform.localPosition.x + 4.5f, slots.transform.localPosition.y);
        //       }
        //       ViewSlots();
        //     }
        //     else if(curPos < 0 && !TriggerRight._isEmptyRight)
        //     {
        //         foreach (GameObject slots in allSlots)
        //       {
        //          slots.transform.localPosition = new Vector2(slots.transform.localPosition.x - 4.5f, slots.transform.localPosition.y);
        //       }
        //       ViewSlots();
        //     }
        //}
    }

    IEnumerator LoadTextFromServer(string url, string response)
{
    Debug.Log("StartDownloadJson");
    while(true)
        {
    var request = UnityWebRequest.Get(url);

    yield return request.SendWebRequest();

    if (!request.isHttpError && !request.isNetworkError)
    { 
        response = request.downloadHandler.text;   
    }
    else
    {
    	Debug.LogErrorFormat("error request [{0}, {1}]", url, request.error);
       
        response = null;
    }
    DataJson = response;
    //Spawning();
    PreStartBut.SetActive(true);
    request.Dispose();
    StopAllCoroutines();
    //StopCoroutine(LoadTextFromServer(url,""));
        }
}

    public void Testing()
    {
        DataSlotCreating[] myObject = JsonHelper.FromJson<DataSlotCreating>(DataJson);
        TotalElementsInJson = myObject.Length;
        for(int cindex = 0; cindex < TotalElementsInJson; cindex++)
        {
        //Debug.Log(myObject[cindex].playerNickName);
        allNicks[cindex].text = myObject[cindex].playerNickName.ToString();
        allPrice[cindex].text = myObject[cindex].price.ToString();
        allNameSlot[cindex].text = myObject[cindex].NameSlot.ToString();
        allCount[cindex].text = "x" + myObject[cindex].count.ToString();
        allurlImage[cindex] = myObject[cindex].urlImage;
        allPlayerExp[cindex].text = myObject[cindex].EXP.ToString();
        }

        for(int c = 0; c < TotalElementsInJson; c++)
        {
            if(myObject[c].NameSlot == "Пшеница")
            allTovarIcon[c].sprite = Wheat;
            
            if(myObject[c].NameSlot == "Грибы")
            allTovarIcon[c].sprite = Mushrooms;

            if(myObject[c].NameSlot == "Кукуруза")
            allTovarIcon[c].sprite = Corn;

            if(myObject[c].NameSlot == "Масло")
            allTovarIcon[c].sprite = Butter;
        }
        Debug.Log("MainCodeComplete");
        //Spawning();
        _isComplete = true;
    }


    public void Spawning()
    {
        MarketCanvas.SetActive(true);
        PreStartCanvas.SetActive(false);

       // for(int a = 0; a < 34; a++)
       for(int a = 0; a < 17; a++)
        {
            for(int c = 0; c < 3; c++)
            {
            //for(int i = 0; i < 3; i ++)
            for(int i = 0; i < 2; i ++)
            {
                // newSlot = Instantiate(SlotPref, DadyGO.transform)as GameObject;
                // newSlot.transform.localPosition = new Vector2(-3 + plus2, 1.6f - plus1);
                // plus1 += 1.5f;
                newSlot = Instantiate(SlotPref, DadyGO.transform)as GameObject;
                newSlot.transform.localScale = new Vector2(230, 200);
                //newSlot.transform.localPosition = new Vector2(-550 + plus1, 370f - plus2);
                newSlot.transform.localPosition = new Vector2(-18450 + plus1, 370f - plus2);
                plus1 += 1100f;
            }
        plus1 -= 2200f;
        //plus2 += 4.5f;
        plus2 += 370f;
        }
        plus2 = 0;
        plus1 += 2200f;
        }



        DataSlotCreating[] myObject = JsonHelper.FromJson<DataSlotCreating>(DataJson);
        TotalElementsInJson = myObject.Length;


        allSlots = GameObject.FindGameObjectsWithTag("Slot");
        allNicksGO = GameObject.FindGameObjectsWithTag("NickName");
        allPriceGO = GameObject.FindGameObjectsWithTag("Price");
        allNameSlotGO = GameObject.FindGameObjectsWithTag("NameSlot");
        allCountGO = GameObject.FindGameObjectsWithTag("CountTov");
        allAvatarsGO = GameObject.FindGameObjectsWithTag("imgAvatar");
        allTovarIconGO = GameObject.FindGameObjectsWithTag("iconTovar");
        allPlayerExpGO = GameObject.FindGameObjectsWithTag("playerEXP");
        //allNicks = GameObject.FindGameObjectsWithTag("NickName").GetComponent<TextMeshProUGUI>();
        //foreach (GameObject nicksGO in allNicksGO)
        var LengthNicks = allNicksGO.Length;
        //TextMeshProUGUI[] nickss = new TextMeshProUGUI[LengthNicks];
        allNicks = new TextMeshProUGUI[LengthNicks];
        allPrice = new TextMeshProUGUI[LengthNicks];
        allNameSlot = new TextMeshProUGUI[LengthNicks];
        allCount = new TextMeshProUGUI[LengthNicks];
        allAvatars = new Image[LengthNicks];
        allurlImage = new string[TotalElementsInJson];
        allTovarIcon = new SpriteRenderer[LengthNicks];
        allPlayerExp = new TextMeshProUGUI[LengthNicks];
        for(int c = 0; c < LengthNicks; c++)
        {
            allNicks[c] = allNicksGO[c].GetComponent<TextMeshProUGUI>();
            allPrice[c] = allPriceGO[c].GetComponent<TextMeshProUGUI>();
            allNameSlot[c] = allNameSlotGO[c].GetComponent<TextMeshProUGUI>();
            allCount[c] = allCountGO[c].GetComponent<TextMeshProUGUI>();
            allAvatars[c] = allAvatarsGO[c].GetComponent<Image>();
            allTovarIcon[c] = allTovarIconGO[c].GetComponent<SpriteRenderer>();
            allPlayerExp[c] = allPlayerExpGO[c].GetComponent<TextMeshProUGUI>();
        }

        ViewSlots();
        Testing();
    }

    public void ViewSlots()
    {
        //   foreach (GameObject slots in allSlots)
        //   {
        //       //if(slots.transform.localPosition.x >= 1.8f || slots.transform.localPosition.x < -3.2f)
        //       if(slots.transform.localPosition.x >= 100f || slots.transform.localPosition.x < -200f)
        //       slots.SetActive(false);
        //       else
        //       slots.SetActive(true);
        //  }
    }

    public void ArrowLeft()
    {
        //  if(!TriggerLeft._isEmptyLeft)
        //  {
        //   foreach (GameObject slots in allSlots)
        //   {
        //       slots.transform.localPosition = new Vector2(slots.transform.localPosition.x + 4.5f, slots.transform.localPosition.y);
        //   }

        scrol.value += 0.0307f;
        // RightBut = true;
        // Invoke("ButTime", 1);
        // DadyGO.transform.localPosition = new Vector2(DadyGO.transform.localPosition.x + 4.5f, 0);
        ViewSlots();
         //}
    }
    public void ArrowRight()
    {
        //  if(!TriggerRight._isEmptyRight)
        //  {
        //   foreach (GameObject slots in allSlots)
        //   {
        //       slots.transform.localPosition = new Vector2(slots.transform.localPosition.x - 4.5f, slots.transform.localPosition.y);
        //   }

        scrol.value -= 0.0307f;
        // RightBut = true;
        // Invoke("ButTime", 1);
        // DadyGO.transform.localPosition = new Vector2(DadyGO.transform.localPosition.x - 4.5f, 0);

        ViewSlots();
         //}
    }
    public void ButTime()
    {
        RightBut = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}



