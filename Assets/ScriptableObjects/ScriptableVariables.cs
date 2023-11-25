using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VariablesScriptable", menuName = "ScriptableVariables")]

public class ScriptableVariables : ScriptableObject
{
    [Header("Health Variables")]
    public float healthAmount = 100f;
    [Header("Step Speed")]
    public float TimeBetweenSteps = 4;



}
