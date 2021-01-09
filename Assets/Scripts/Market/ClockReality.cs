using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class ClockReality : MonoBehaviour 
{
//public Text Times;
public TextMeshProUGUI watch;

void Update () 
{

DateTime time = DateTime.Now;
watch.text = time.Hour.ToString("00") + ":" + time.Minute.ToString("00") + ":" + time.Second.ToString("00");
  }
}