using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimit : MonoBehaviour
{
   public enum limits
    {
        nolimit = 0,
        limit30 = 30,
        limit60 = 60,
        limit120 = 120,
    }

    public limits limit;

    private void Awake()
    {
        Application.targetFrameRate = (int)limit;
    }
}
