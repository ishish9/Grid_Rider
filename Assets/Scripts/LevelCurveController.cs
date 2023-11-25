using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmazingAssets.CurvedWorld;

public class LevelCurveController : MonoBehaviour
{
    [SerializeField] private CurvedWorldController curvedWorld;
    [SerializeField] private LevelSpeed levelSpeed;
    [SerializeField] private WallSpawner wallSpawner;

    public float Timer = 0;
    public float CurveChangeTime = 1;
    public float hCurveStart = 0;
    public float hCurveEnd = 5;

    public float vCurveStart = 0;
    public float vCurveEnd = -5;

    private bool ChangeCurve = false;


    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > CurveChangeTime)
        {
            Timer = CurveChangeTime;//Clamps timer to change time
            ChangeCurve = true;
        }

        float curve_dt = Timer / CurveChangeTime;

        curvedWorld.bendHorizontalSize = Mathf.Lerp(hCurveStart, hCurveEnd, curve_dt);
        curvedWorld.bendVerticalSize   = Mathf.Lerp(vCurveStart, vCurveEnd, curve_dt);

        if(ChangeCurve)
        {
            levelSpeed.ChangeLevelSpeed(-1);
            wallSpawner.ChangeSpawnRate(-1);
            Timer = 0;
            ChangeCurve = false;

            hCurveStart = curvedWorld.bendHorizontalSize;
            vCurveStart = curvedWorld.bendVerticalSize;

            hCurveEnd = Random.Range(-4, 4);
            vCurveEnd = Random.Range(-4, 4);
        }  
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
