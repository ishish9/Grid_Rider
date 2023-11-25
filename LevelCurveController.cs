using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmazingAssets.CurvedWorld;

public class LevelCurveController : MonoBehaviour
{
    [SerializeField] private CurvedWorldController curvedWorld;
    public float Timer = 4;

    public float hCurveStart = 0;
    public float hCurveEnd = 5;

    private float vCurveStart = 0;
    private float vCurveEnd = -5;

    private bool ChangeCurve = false;


    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Timer = 5;
            ChangeCurve = true;
        }
        curvedWorld.bendHorizontalSize = Mathf.Lerp(hCurveStart, hCurveEnd, Timer /5.0f);
        curvedWorld.bendVerticalSize   = Mathf.Lerp(vCurveStart, vCurveEnd, Timer /5.0f);

        /* if (curvedWorld.bendHorizontalSize == hCurveEnd && ChangeCurve)
         {
             hCurveStart = hCurveEnd;
             hCurveEnd = Random.Range(-4, 4);
             ChangeCurve = false;
         }

         if (curvedWorld.bendVerticalSize == vCurveEnd && ChangeCurve)
         {
             vCurveStart = vCurveEnd;
             vCurveEnd = Random.Range(-4, 4);
             ChangeCurve = false;    
         }    */
    }

    // var larpT = Timer / 5.0;
    // var hAngle = Mathf.Lerp(hCurveStart, hCurvEnd, lerpT);
    // var vAngle = Mathf.Lerp(vCurveStart, vCurveEnd, lerpT);
    // string.info = $"StartH:{hCurveStart} EndH:{hCurveEnd} HAngle:{hAngle} StartV:{vCurveStart2} VAngle:{vAngle} lerT:{lerT} Changed: {ChangeCurve}";
    //    debug.Log(info);
    //   curvedWorld.bendHorizontalSize = hAngle;
    //    curvedWorld.bendVerticalSize = vAngle;
    //
    //   if(Mathf.Approximately(hAngle, hCurvedEnd1) && ChangeCurve)
}
