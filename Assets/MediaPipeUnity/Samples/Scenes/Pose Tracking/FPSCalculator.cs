using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class FPSCalculator : MonoBehaviour
{
  [DllImport("TestDll")]
  public static extern int add(int num1, int num2);
  [DllImport("TestDll")]
  public static extern int multiply(int num1, int num2);
  [DllImport("TestDll")]
  public static extern int substract(int num1, int num2);
  [DllImport("TestDll")]
  public static extern int divide(int num1, int num2);
  // private const string DllFilePath = @"C:\Users\John\source\repos\Dll2\Debug\Dll2.dll";

  // [DllImport(DllFilePath, CallingConvention = CallingConvention.Cdecl)]
  // private extern static int test(int number);


  public int fpsTarget;  //通常設30 ~ 60
  public float updateInterval = 0.5f;  //每幾秒算一次
  private float lastInterval;
  private int frames = 0;
  private float fps;
  public Text FPS_text; //讓UITEXT放進來

  public Text position_text;

  public GameObject pointList;


  void Start()
  {
    Application.targetFrameRate = 300;  //固定幀數
    lastInterval = Time.realtimeSinceStartup;  //自遊戲開始時間
    frames = 0;  //初始frames =0
  }

  // 每一幀都會呼叫update()
  void Update()
  {
    frames++;
    float timeNow = Time.realtimeSinceStartup;
    if (timeNow >= lastInterval + updateInterval)  //每0.5秒更新一次
    {
      fps = frames / (timeNow - lastInterval); //幀數= 每幀/每幀間隔毫秒 
      frames = 0;
      lastInterval = timeNow;
    }

    GameObject nose = null;
    nose = pointList.transform.GetChild(15).gameObject;
    if (pointList.transform.GetChild(15) != null)
    {
      position_text.text = nose.transform.position.x.ToString("0.0") + ", " + nose.transform.position.y.ToString("0.0") + ", " + nose.transform.position.z.ToString("0.0");
      //position_text.text = add(frames, frames).ToString();
    }
    else
    {
      position_text.text = add(frames, frames).ToString();
    }
    //Debug.Log(add(3, 2));
  }

  void OnGUI()
  {
    FPS_text.text = ((int)fps).ToString(); //在UI上顯示幀數
  }
}
