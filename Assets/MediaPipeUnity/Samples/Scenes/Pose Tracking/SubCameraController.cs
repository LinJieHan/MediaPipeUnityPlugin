using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraController : MonoBehaviour
{
  private bool autoTurn = false;
  public void AutoTurn()
  {
    autoTurn = !autoTurn;
  }
  public void TurnLeft()
  {
    gameObject.transform.Rotate(0, 10, 0);
  }

  public void TurnRight()
  {
    gameObject.transform.Rotate(0, -10, 0);
  }
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (autoTurn)
    {
      gameObject.transform.Rotate(0, 0.5f, 0);
    }
  }
}
