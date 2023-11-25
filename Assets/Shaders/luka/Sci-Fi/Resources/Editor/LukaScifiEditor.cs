#if UNITY_EDITOR

using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class LukaScifiEditor : ShaderGUI {

    // for editor
    private static Texture2D constantTexture = null;
    private static GUIStyle middleStyle = null;
    private static GUIStyle wrapStyle = null;

    // tabs 
    private static bool tabRendering = false;
    private static bool tabLighting = false;
    private static bool tabTextures = false;
    private static bool tabScifi = false;
    private static bool tabAttribution = false;
    private static bool tabLicense = false;
    private static bool tabMore = false;
    private static bool tabAudiolink = false;

    // properties
    // rendering
    private static MaterialProperty prpFadeAway = null;
    private static MaterialProperty prpFadeAwayStart = null;
    private static MaterialProperty prpFadeAwayEnd = null;
    private static MaterialProperty prpCulling = null;
    private static MaterialProperty prpZWrite = null;
    // lighting
    private static MaterialProperty prpMTColor = null;
    private static MaterialProperty prpMTAmbientColor = null;
    private static MaterialProperty prpMTSpecularColor = null;
    private static MaterialProperty prpMTGlossiness = null;
    private static MaterialProperty prpMTRimColor = null;
    private static MaterialProperty prpMTRimPower = null;
    private static MaterialProperty prpMTRimThreshold = null;
    private static MaterialProperty prpMTUseLighting = null;
    private static MaterialProperty prpMTBrighten = null;
    private static MaterialProperty prpMTDarken = null;
    // texture
    private static MaterialProperty prpMainTex = null;
    private static MaterialProperty prpMonitor = null;
    private static MaterialProperty prpMonitorApply = null;
    private static MaterialProperty prpMonitorScale = null;
    private static MaterialProperty prpMonitorDistance = null;
    private static MaterialProperty prpMonitorBlend = null;
    private static MaterialProperty prpNormalsToggle = null;
    private static MaterialProperty prpNormalMap = null;
    private static MaterialProperty prpNormalMapIntensity = null;
    private static MaterialProperty prpNormalMapScale = null;
    // scifi
    private static MaterialProperty prpScifiTex = null;
    private static MaterialProperty prpScifiProjection = null;
    private static MaterialProperty prpScifiOpacity = null;
    private static MaterialProperty prpScifiBlend = null;
    private static MaterialProperty prpScifiTexAmount = null;
    private static MaterialProperty prpScifiTexWidth = null;
    private static MaterialProperty prpScifiTexCell = null;
    private static MaterialProperty prpScifiTexOffset = null;
    private static MaterialProperty prpScifiUVScaleX = null;
    private static MaterialProperty prpScifiUVScaleY = null;
    private static MaterialProperty prpScifiUVOffsetX = null;
    private static MaterialProperty prpScifiUVOffsetY = null;
    private static MaterialProperty prpScifiUVRotate = null;
    private static MaterialProperty prpScifiUVScroll = null;
    private static MaterialProperty prpScifiUVScrollX = null;
    private static MaterialProperty prpScifiUVScrollY = null;
    private static MaterialProperty prpScifiTPScaleX = null;
    private static MaterialProperty prpScifiTPScaleY = null;
    private static MaterialProperty prpScifiTPScaleZ = null;
    private static MaterialProperty prpScifiTPPanX = null;
    private static MaterialProperty prpScifiTPPanY = null;
    private static MaterialProperty prpScifiTPPanZ = null;
    private static MaterialProperty prpScifiTPPan = null;
    private static MaterialProperty prpScifiTPThreshold = null;
    private static MaterialProperty prpScifiTPRotate = null;
    private static MaterialProperty prpScifiWavesStyle = null;
    private static MaterialProperty prpScifiWavesSpeed = null;
    private static MaterialProperty prpScifiWaveNoiseScale = null;
    private static MaterialProperty prpScifiWavesOpacity = null;
    private static MaterialProperty prpScifiWavesOpacityLower = null;
    private static MaterialProperty prpScifiWavesOpacityHigher = null;
    private static MaterialProperty prpScifiWavesWidth = null;
    private static MaterialProperty prpScifiWavesWidthLower = null;
    private static MaterialProperty prpScifiWavesWidthHigher = null;
    // private static MaterialProperty prpScifiWavesBackground = null;
    // private static MaterialProperty prpScifiWavesBackgroundGradientOne = null;
    // private static MaterialProperty prpScifiWavesBackgroundGradientTwo = null;
    private static MaterialProperty prpScifiEmission = null;
    private static MaterialProperty prpScifiEmissionAmount = null;
    private static MaterialProperty prpScifiEmissionColor = null;
    private static MaterialProperty prpScifiTexColorStyle = null;
    private static MaterialProperty prpScifiTexColorOne = null;
    private static MaterialProperty prpScifiTexColorTwo = null;
    private static MaterialProperty prpScifiTexRainbowHue = null;
    private static MaterialProperty prpScifiTexRainbowSat = null;
    private static MaterialProperty prpScifiTexRainbowBri = null;
    private static MaterialProperty prpScifiTexRainbowSpeed = null;
    private static MaterialProperty prpScifiTexPattern = null;
    private static MaterialProperty prpScifiTexBackground = null;
    private static MaterialProperty prpScifiTexBackgroundColor = null;
    private static MaterialProperty prpScifiTexBackgroundRainbowHue = null;
    private static MaterialProperty prpScifiTexBackgroundRainbowSat = null;
    private static MaterialProperty prpScifiTexBackgroundRainbowBri = null;
    private static MaterialProperty prpScifiTexBackgroundRainbowSpeed = null;
    private static MaterialProperty prpScifiUVRotateSpeed = null;
    private static MaterialProperty prpScifiTPRotateSpeed = null;
    private static MaterialProperty prpScifiWavesRotation = null;
    private static MaterialProperty prpScifiWavesSize = null;
    private static MaterialProperty prpScifiWavesPixelation = null;
    private static MaterialProperty prpScifiWavesRotationSpeed = null;
    private static MaterialProperty prpScifiWavesUV = null;
    // audiolink properties
    private static MaterialProperty prpALStyle = null;
    private static MaterialProperty prpALSensitivity = null;
    private static MaterialProperty prpALPower = null;
    private static MaterialProperty prpALTOne = null;
    private static MaterialProperty prpALTTwo = null;

    // arrays
    private static string[] aryProjectionMethod = new string[] { "UVs", "Triplanar" };
    private static string[] aryProjectionStyle = new string[] { "Circles", "Noisey Waves", "Ooze", "Bubbles", "Swirls", "Scanline" };
    private static string[] aryBackgroundStyle = new string[] { "Texture", "Gradient" };
    private static string[] aryToggle = new string[] { "Disabled", "Enabled" };
    private static string[] aryWaveColor = new string[] { "Color", "Gradient", "Rainbow" };
    private static string[] aryPattern = new string[] { "Honeycomb", "Inverse Honeycomb", "Cards", "Inverse Cards"};
    private static string[] aryBackground = new string[] { "Color", "Transparent", "Rainbow" };
    private static string[] aryMonitor = new string[] { "Wave", "Main Texture", "Both" };


    // functions
    private static void makeSimpleTab(ref bool inputBool, string inputTitle, GUIStyle inputStyle)
    {
        inputBool = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), inputBool, GUIContent.none, "box");
        EditorGUILayout.Toggle(inputBool, EditorStyles.foldout, GUILayout.MaxWidth(10));
        EditorGUILayout.LabelField(inputTitle, inputStyle);
        EditorGUILayout.EndHorizontal();
    }

    private static void drawPopup(ref MaterialProperty inoutProperty, string inputText, string[] inputArray)
    {
        // custom popup hee heeeeee
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(inputText);
        inoutProperty.floatValue = EditorGUILayout.Popup((int)inoutProperty.floatValue, inputArray);
        EditorGUILayout.EndHorizontal();
    }

    private static void doLocalKeywordToggle(Material mThis, bool boolState, string inputKeyword)
    {
        if (boolState) mThis.EnableKeyword(inputKeyword); else mThis.DisableKeyword(inputKeyword);
    }

    private static void doKeywordEnumUpdateProjection(Material mThis, string inputProperty)
    {
        // set up the values
        int intKeywordValue = mThis.GetInt(inputProperty);
        bool boolUV = false;
        // bool boolSimple = false;
        bool boolProjekt = false;
        // getting which to set
        switch (intKeywordValue)
        {
            case 0: // one
                boolUV = true;
                break;
            case 1: // three
                boolProjekt = true;
                break;
            default: // end
                break;
        }
        // setting
        doLocalKeywordToggle(mThis, boolUV, "_KEYWORD_USE_PROJECTION_UV");
        // doLocalKeywordToggle(mThis, boolSimple, "_KEYWORD_USE_PROJECTION_SIMPLE_TRIPLANAR");
        doLocalKeywordToggle(mThis, boolProjekt, "_KEYWORD_USE_PROJECTION_PROJEKT_TRIPLANAR");
    }

    private static void doKeywordEnumUpdatePattern(Material mThis, string inputProperty)
    {
        // set up the values
        int intKeywordValue = mThis.GetInt(inputProperty);
        bool boolHoneycomb = false;
        bool boolInverseHoneycomb = false;
        bool boolCards = false;
        bool boolInverseCards = false;
        // getting which to set
        switch (intKeywordValue)
        {
            case 0: // honeycomb
                boolHoneycomb = true;
                break;
            case 1: // inverse honeycomb
                boolInverseHoneycomb = true;
                break;
            case 2: // cards
                boolCards = true;
                break;
            case 3: // inverse cards
                boolInverseCards = true;
                break;
            default: // end
                break;
        }
        // setting
        doLocalKeywordToggle(mThis, boolHoneycomb, "_KEYWORD_PATTERN_HONEYCOMB");
        doLocalKeywordToggle(mThis, boolInverseHoneycomb, "_KEYWORD_PATTERN_INVERSE_HONEYCOMB");
        doLocalKeywordToggle(mThis, boolCards, "_KEYWORD_PATTERN_CARDS");
        doLocalKeywordToggle(mThis, boolInverseCards, "_KEYWORD_PATTERN_INVERSE_CARDS");
    }

    private static void doKeywordEnumUpdateBackground(Material mThis, string inputProperty)
    {
        // set up
        int intKeywordValue = mThis.GetInt(inputProperty);
        bool boolTransparent = false;
        bool boolRainbow = false;
        // getting which to set
        switch (intKeywordValue)
        {
            case 0: // color
                break;
            case 1: // transparent
                boolTransparent = true;
                break;
            case 2: // rainbow
                boolRainbow = true;
                break;
            default: // end
                break;
        }
        // setting
        doLocalKeywordToggle(mThis, boolTransparent, "_KEYWORD_USE_TRANSPARENT_BACKGROUND");
        doLocalKeywordToggle(mThis, boolRainbow, "_KEYWORD_USE_RAINBOW_BACKGROUND");
    }

    private static void doKeywordEnumUpdateWave(Material mThis, string inputProperty)
    {
        // set up
        int intKeywordValue = mThis.GetInt(inputProperty);
        // bool boolCircle = false; circle = 0 = no keyword
        bool boolNoiseyWaves = false;
        bool boolOoze = false;
        bool boolBubbles = false;
        bool boolSwirls = false;
        bool boolScanline = false;
        // getting which to set
        switch (intKeywordValue)
        {
            case 0: // circle
                break;
            case 1: // noisey waves
                boolNoiseyWaves = true;
                break;
            case 2: // ooze
                boolOoze = true;
                break;
            case 3: // bubbles
                boolBubbles = true;
                break;
            case 4: // swirls
                boolSwirls = true;
                break;
            case 5: // scanline
                boolScanline = true;
                break;
            default: // end
                break;
        }
        // setting
        doLocalKeywordToggle(mThis, boolNoiseyWaves, "_KEYWORD_WAVE_NOISEY_WAVES");
        doLocalKeywordToggle(mThis, boolOoze, "_KEYWORD_WAVE_OOZE");
        doLocalKeywordToggle(mThis, boolBubbles, "_KEYWORD_WAVE_BUBBLES");
        doLocalKeywordToggle(mThis, boolSwirls, "_KEYWORD_WAVE_SWIRLS");
        doLocalKeywordToggle(mThis, boolScanline, "_KEYWORD_WAVE_SCANLINE");
    }

    private static void doKeywordUpdateEnumColorStyle(Material mThis, string inputProperty)
    {
        // set up
        int intKeywordValue = mThis.GetInt(inputProperty);
       //  bool boolSolid = false;
        bool boolGradient = false;
        bool boolRainbow = false;
        // getting which to set
        switch (intKeywordValue)
        {
            case 0: // solid
                // define nothing
                break;
            case 1: // gradient
                boolGradient = true;
                break;
            case 2: // rainbow
                boolRainbow = true;
                break;
            default: // end
                break;
        }
        // setting
        // doLocalKeywordToggle(mThis, boolSolid, "_KEYWORD_COLOR_SOLID");
        doLocalKeywordToggle(mThis, boolGradient, "_KEYWORD_USE_COLOR_GRADIENT");
        doLocalKeywordToggle(mThis, boolRainbow, "_KEYWORD_USE_COLOR_RAINBOW");
    }

    // onload
    [InitializeOnLoad]
    public class Startup {
        static Startup() {
            // if unity pro skin
            if (EditorGUIUtility.isProSkin) {
                // set skin
                constantTexture = Resources.Load("Images/Scifi_Dark") as Texture2D;
            } else {
                // set skin
                constantTexture = Resources.Load("Images/Scifi_Light") as Texture2D;
            }
        }
    }

    // ui
    public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
    {

        // setting up
        Material targetMat = materialEditor.target as Material;

        // drawing
        EditorGUILayout.Space();
        EditorGUI.DrawPreviewTexture(GUILayoutUtility.GetRect(0, int.MaxValue / 1, 80, 25), constantTexture, null, ScaleMode.ScaleToFit);
        EditorGUILayout.Space();
        
        // get the name of the shader
        string shaderName = targetMat.shader.name;

        // audiolink
        if (shaderName.Contains("audiolink")) {
            makeSimpleTab(ref tabAudiolink, "AudioLink", EditorStyles.boldLabel);
            if (tabAudiolink) {
                // assigning
                prpALStyle = ShaderGUI.FindProperty("_ALStyle", properties);
                prpALSensitivity = ShaderGUI.FindProperty("_ALSensitivity", properties);
                prpALPower = ShaderGUI.FindProperty("_ALPower", properties);
                prpALTOne = ShaderGUI.FindProperty("_ALTOne", properties);
                prpALTTwo = ShaderGUI.FindProperty("_ALTTwo", properties);
                // ui
                EditorGUILayout.BeginVertical("GroupBox");
                materialEditor.ShaderProperty(prpALStyle, "Style");
                materialEditor.ShaderProperty(prpALSensitivity, "Sensitivity");
                materialEditor.ShaderProperty(prpALPower, "Power");
                if (prpALStyle.floatValue == 2)
                {
                    materialEditor.ShaderProperty(prpALTOne, "Tone One");
                }
                else if (prpALStyle.floatValue == 3)
                {
                    materialEditor.ShaderProperty(prpALTOne, "Tone One");
                    materialEditor.ShaderProperty(prpALTTwo, "Tone Two");
                }
                EditorGUILayout.EndVertical();
            }
        }

        // rendering
        makeSimpleTab(ref tabRendering, "Rendering", EditorStyles.boldLabel);
        if (tabRendering) {
            // assigning
            prpCulling = ShaderGUI.FindProperty("_Culling", properties);
            prpZWrite = ShaderGUI.FindProperty("_ZWrite", properties);
            prpFadeAway = ShaderGUI.FindProperty("_FadeAway", properties);
            prpFadeAwayStart = ShaderGUI.FindProperty("_FadeAwayStart", properties);
            prpFadeAwayEnd = ShaderGUI.FindProperty("_FadeAwayEnd", properties);
            // ui
            EditorGUILayout.BeginVertical("GroupBox");
            materialEditor.ShaderProperty(prpCulling, "Culling");
            materialEditor.ShaderProperty(prpZWrite, "ZWrite");
            materialEditor.ShaderProperty(prpFadeAway, "Distance Fade Waves");
            if (prpFadeAway.floatValue == 1) {
                EditorGUI.indentLevel++;
                materialEditor.ShaderProperty(prpFadeAwayStart, "Fade Away Start");
                materialEditor.ShaderProperty(prpFadeAwayEnd, "Fade Away End");
                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndVertical();
        }

        // lighting
        makeSimpleTab(ref tabLighting, "Lighting", EditorStyles.boldLabel);
        if (tabLighting) {
            // assigning
            prpMTColor = ShaderGUI.FindProperty("_MTColor", properties);
            prpMTAmbientColor = ShaderGUI.FindProperty("_MTAmbientColor", properties);
            prpMTSpecularColor = ShaderGUI.FindProperty("_MTSpecularColor", properties);
            prpMTGlossiness = ShaderGUI.FindProperty("_MTGlossiness", properties);
            prpMTRimColor = ShaderGUI.FindProperty("_MTRimColor", properties);
            prpMTRimPower = ShaderGUI.FindProperty("_MTRimPower", properties);
            prpMTRimThreshold = ShaderGUI.FindProperty("_MTRimThreshold", properties);
            prpMTUseLighting = ShaderGUI.FindProperty("_MTUseLighting", properties);
            prpMTBrighten = ShaderGUI.FindProperty("_MTBrighten", properties);
            prpMTDarken = ShaderGUI.FindProperty("_MTDarken", properties);
            // ui
            EditorGUILayout.BeginVertical("GroupBox");
            materialEditor.ShaderProperty(prpMTColor, "Color");
            materialEditor.ShaderProperty(prpMTAmbientColor, "Ambient Color");
            materialEditor.ShaderProperty(prpMTSpecularColor, "Specular Color");
            materialEditor.ShaderProperty(prpMTGlossiness, "Glossiness");
            materialEditor.ShaderProperty(prpMTRimColor, "Rim Color");
            materialEditor.ShaderProperty(prpMTRimPower, "Rim Power");
            materialEditor.ShaderProperty(prpMTRimThreshold, "Rim Threshold");
            materialEditor.ShaderProperty(prpMTUseLighting, "Use Lighting");
            materialEditor.ShaderProperty(prpMTBrighten, "Brighten");
            materialEditor.ShaderProperty(prpMTDarken, "Darken");
            EditorGUILayout.EndVertical();
        }

        // textures
        makeSimpleTab(ref tabTextures, "Texture Settings", EditorStyles.boldLabel);
        if (tabTextures) {
            // assign
            prpMainTex = ShaderGUI.FindProperty("_MainTex", properties);
            prpMonitor = ShaderGUI.FindProperty("_ScifiMonitor", properties);
            prpMonitorApply = ShaderGUI.FindProperty("_ScifiMonitorApply", properties);
            prpMonitorScale = ShaderGUI.FindProperty("_ScifiMonitorScale", properties);
            prpMonitorDistance = ShaderGUI.FindProperty("_ScifiMonitorDistance", properties);
            prpMonitorBlend = ShaderGUI.FindProperty("_ScifiMonitorBlend", properties);
            prpNormalsToggle = ShaderGUI.FindProperty("_NormalsToggle", properties);
            prpNormalMap = ShaderGUI.FindProperty("_NormalMap", properties);
            prpNormalMapIntensity = ShaderGUI.FindProperty("_NormalMapIntensity", properties);
            prpNormalMapScale = ShaderGUI.FindProperty("_NormalMapScale", properties);
            // ui
            EditorGUILayout.BeginVertical("GroupBox");
            materialEditor.ShaderProperty(prpMainTex, "Main Texture");
            materialEditor.ShaderProperty(prpNormalsToggle, "Use Normal Map");
            if (prpNormalsToggle.floatValue == 1) {
                EditorGUI.indentLevel++;
                materialEditor.ShaderProperty(prpNormalMap, "Normal Map");
                materialEditor.ShaderProperty(prpNormalMapIntensity, "Normal Map Intensity");
                materialEditor.ShaderProperty(prpNormalMapScale, "Normal Map Scale");
                EditorGUI.indentLevel--;
            }
            materialEditor.ShaderProperty(prpMonitor, "Act Like Monitor Up Close");
            if (prpMonitor.floatValue == 1) {
                EditorGUI.indentLevel++;
                drawPopup(ref prpMonitorApply, "Apply Monitor To", aryMonitor);
                materialEditor.ShaderProperty(prpMonitorScale, "Monitor Scale");
                materialEditor.ShaderProperty(prpMonitorDistance, "Monitor Distance");
                materialEditor.ShaderProperty(prpMonitorBlend, "Monitor Blend");
                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndVertical();
        }

        // scifi
        makeSimpleTab(ref tabScifi, "Sci-Fi Grid", EditorStyles.boldLabel);
        if (tabScifi) {
            // assign
            prpScifiTex = ShaderGUI.FindProperty("_ScifiTex", properties);
            prpScifiProjection = ShaderGUI.FindProperty("_ScifiProjection", properties);
            prpScifiOpacity = ShaderGUI.FindProperty("_ScifiOpacity", properties);
            // prpScifiBlend = ShaderGUI.FindProperty("_ScifiBlend", properties);
            prpScifiTexAmount = ShaderGUI.FindProperty("_ScifiTexAmount", properties);
            prpScifiTexWidth = ShaderGUI.FindProperty("_ScifiTexWidth", properties);
            prpScifiTexOffset = ShaderGUI.FindProperty("_ScifiTexOffset", properties);
            prpScifiTexCell = ShaderGUI.FindProperty("_ScifiTexCell", properties);
            prpScifiUVScaleX = ShaderGUI.FindProperty("_ScifiUVScaleX", properties);
            prpScifiUVScaleY = ShaderGUI.FindProperty("_ScifiUVScaleY", properties);
            prpScifiUVOffsetX = ShaderGUI.FindProperty("_ScifiUVOffsetX", properties);
            prpScifiUVOffsetY = ShaderGUI.FindProperty("_ScifiUVOffsetY", properties);
            prpScifiUVRotate = ShaderGUI.FindProperty("_ScifiUVRotate", properties);
            prpScifiUVScroll = ShaderGUI.FindProperty("_ScifiUVScroll", properties);
            prpScifiUVScrollX = ShaderGUI.FindProperty("_ScifiUVScrollX", properties);
            prpScifiUVScrollY = ShaderGUI.FindProperty("_ScifiUVScrollY", properties);
            prpScifiTPScaleX = ShaderGUI.FindProperty("_ScifiTPScaleX", properties);
            prpScifiTPScaleY = ShaderGUI.FindProperty("_ScifiTPScaleY", properties);
            prpScifiTPScaleZ = ShaderGUI.FindProperty("_ScifiTPScaleZ", properties);
            prpScifiTPPanX = ShaderGUI.FindProperty("_ScifiTPPanX", properties);
            prpScifiTPPanY = ShaderGUI.FindProperty("_ScifiTPPanY", properties);
            prpScifiTPPanZ = ShaderGUI.FindProperty("_ScifiTPPanZ", properties);
            prpScifiTPThreshold = ShaderGUI.FindProperty("_ScifiTPThreshold", properties);
            prpScifiTPRotate = ShaderGUI.FindProperty("_ScifiTPRotate", properties);
            prpScifiWavesStyle = ShaderGUI.FindProperty("_ScifiWavesStyle", properties);
            prpScifiWavesSpeed = ShaderGUI.FindProperty("_ScifiWavesSpeed", properties);
            prpScifiWaveNoiseScale = ShaderGUI.FindProperty("_ScifiWaveNoiseScale", properties);
            prpScifiWavesOpacity = ShaderGUI.FindProperty("_ScifiWavesOpacity", properties);
            prpScifiWavesOpacityLower = ShaderGUI.FindProperty("_ScifiWavesOpacityLower", properties);
            prpScifiWavesOpacityHigher = ShaderGUI.FindProperty("_ScifiWavesOpacityHigher", properties);
            prpScifiWavesWidth = ShaderGUI.FindProperty("_ScifiWavesWidth", properties);
            prpScifiWavesWidthLower = ShaderGUI.FindProperty("_ScifiWavesWidthLower", properties);
            prpScifiWavesWidthHigher = ShaderGUI.FindProperty("_ScifiWavesWidthHigher", properties);
            // prpScifiWavesBackground = ShaderGUI.FindProperty("_ScifiWavesBackground", properties);
            // prpScifiWavesBackgroundGradientOne = ShaderGUI.FindProperty("_ScifiWavesBackgroundGradientOne", properties);
            // prpScifiWavesBackgroundGradientTwo = ShaderGUI.FindProperty("_ScifiWavesBackgroundGradientTwo", properties);
            prpScifiEmission = ShaderGUI.FindProperty("_ScifiEmission", properties);
            prpScifiEmissionAmount = ShaderGUI.FindProperty("_ScifiEmissionAmount", properties);
            prpScifiEmissionColor = ShaderGUI.FindProperty("_ScifiEmissionColor", properties);
            prpScifiTPPan = ShaderGUI.FindProperty("_ScifiTPPan", properties);
            prpScifiTexColorStyle = ShaderGUI.FindProperty("_ScifiTexColorStyle", properties);
            prpScifiTexColorOne = ShaderGUI.FindProperty("_ScifiTexColorOne", properties);
            prpScifiTexColorTwo = ShaderGUI.FindProperty("_ScifiTexColorTwo", properties);
            prpScifiTexRainbowHue = ShaderGUI.FindProperty("_ScifiTexRainbowHue", properties);
            prpScifiTexRainbowSat = ShaderGUI.FindProperty("_ScifiTexRainbowSat", properties);
            prpScifiTexRainbowBri = ShaderGUI.FindProperty("_ScifiTexRainbowBri", properties);
            prpScifiTexRainbowSpeed = ShaderGUI.FindProperty("_ScifiTexRainbowSpeed", properties);
            prpScifiTexPattern = ShaderGUI.FindProperty("_ScifiTexPattern", properties);
            prpScifiTexBackground = ShaderGUI.FindProperty("_ScifiTexBackgroundColorStyle", properties);
            prpScifiTexBackgroundColor = ShaderGUI.FindProperty("_ScifiTexBackgroundColor", properties);
            prpScifiTexBackgroundRainbowHue = ShaderGUI.FindProperty("_ScifiTexBackgroundRainbowHue", properties);
            prpScifiTexBackgroundRainbowSat = ShaderGUI.FindProperty("_ScifiTexBackgroundRainbowSat", properties);
            prpScifiTexBackgroundRainbowBri = ShaderGUI.FindProperty("_ScifiTexBackgroundRainbowBri", properties);
            prpScifiTexBackgroundRainbowSpeed = ShaderGUI.FindProperty("_ScifiTexBackgroundRainbowSpeed", properties);
            prpScifiUVRotateSpeed = ShaderGUI.FindProperty("_ScifiUVRotateSpeed", properties);
            prpScifiTPRotateSpeed = ShaderGUI.FindProperty("_ScifiTPRotateSpeed", properties);
            prpScifiWavesRotation = ShaderGUI.FindProperty("_ScifiWavesRotation", properties);
            prpScifiWavesSize = ShaderGUI.FindProperty("_ScifiWavesSize", properties);
            prpScifiWavesPixelation = ShaderGUI.FindProperty("_ScifiWavesPixelation", properties);
            prpScifiWavesRotationSpeed = ShaderGUI.FindProperty("_ScifiWavesRotationSpeed", properties);
            prpScifiWavesUV = ShaderGUI.FindProperty("_ScifiWavesUV", properties);
            // ui
            EditorGUILayout.BeginVertical("GroupBox");
            // background style
            materialEditor.ShaderProperty(prpScifiOpacity, "Scifi Opacity");
            //drawPopup(ref prpScifiWavesBackground, "Scifi Waves Background", aryBackgroundStyle);
            /*EditorGUI.indentLevel++;
            if (prpScifiWavesBackground.floatValue == 0) {
                // texture
            } else {
                // gradient
                materialEditor.ShaderProperty(prpScifiWavesBackgroundGradientOne, "Scifi Waves Background Gradient One");
                materialEditor.ShaderProperty(prpScifiWavesBackgroundGradientTwo, "Scifi Waves Background Gradient Two");
            /
            EditorGUI.indentLevel--;*/
                // texture
                materialEditor.ShaderProperty(prpScifiTex, "Scifi Texture");
            EditorGUI.indentLevel++;
            drawPopup(ref prpScifiTexPattern, "Scifi Texture Pattern", aryPattern);
            materialEditor.ShaderProperty(prpScifiTexAmount, "Scifi Texture Amount");
            materialEditor.ShaderProperty(prpScifiTexWidth, "Scifi Texture Width");
            materialEditor.ShaderProperty(prpScifiTexCell, "Scifi Texture Cell Size");
            if (prpScifiTexPattern.floatValue >= 2) {
                materialEditor.ShaderProperty(prpScifiTexOffset, "Scifi Texture Offset");
            }
            EditorGUI.indentLevel--;
            // color
            drawPopup(ref prpScifiTexColorStyle, "Scifi Texture Color Style", aryWaveColor);
            EditorGUI.indentLevel++;
            if (prpScifiTexColorStyle.floatValue == 0)
            {
                // color
                materialEditor.ShaderProperty(prpScifiTexColorOne, "Color One");
            }
            else if (prpScifiTexColorStyle.floatValue == 1)
            {
                materialEditor.ShaderProperty(prpScifiTexColorOne, "Color One");
                materialEditor.ShaderProperty(prpScifiTexColorTwo, "Color Two");
            }
            else
            {
                // rainbow
                materialEditor.ShaderProperty(prpScifiTexRainbowHue, "Rainbow Hue");
                materialEditor.ShaderProperty(prpScifiTexRainbowSat, "Rainbow Saturation");
                materialEditor.ShaderProperty(prpScifiTexRainbowBri, "Rainbow Brightness");
                materialEditor.ShaderProperty(prpScifiTexRainbowSpeed, "Rainbow Speed");
            }
            EditorGUI.indentLevel--;
            // background 
            drawPopup(ref prpScifiTexBackground, "Scifi Texture Background Style", aryBackground);
            EditorGUI.indentLevel++;
            if (prpScifiTexBackground.floatValue == 0) {
                // color
                materialEditor.ShaderProperty(prpScifiTexBackgroundColor, "Color");
            } else if (prpScifiTexBackground.floatValue == 1) {
                // transparent, nothing
            }
            else
            {
                // rainbow
                materialEditor.ShaderProperty(prpScifiTexBackgroundRainbowHue, "Rainbow Hue");
                materialEditor.ShaderProperty(prpScifiTexBackgroundRainbowSat, "Rainbow Saturation");
                materialEditor.ShaderProperty(prpScifiTexBackgroundRainbowBri, "Rainbow Brightness");
                materialEditor.ShaderProperty(prpScifiTexBackgroundRainbowSpeed, "Rainbow Speed");
            }
            EditorGUI.indentLevel--;
            // uv space 
            drawPopup(ref prpScifiProjection, "Scifi UV Space", aryProjectionMethod);
            EditorGUI.indentLevel++;
            if (prpScifiProjection.floatValue == 0) {
                // normal uv space
                materialEditor.ShaderProperty(prpScifiUVOffsetX, "UV Offset X");
                materialEditor.ShaderProperty(prpScifiUVOffsetY, "UV Offset Y");
                materialEditor.ShaderProperty(prpScifiUVRotate, "UV Rotate");
                materialEditor.ShaderProperty(prpScifiUVRotateSpeed, "UV Rotate Speed");
                materialEditor.ShaderProperty(prpScifiUVScaleX, "UV Scale X");
                materialEditor.ShaderProperty(prpScifiUVScaleY, "UV Scale Y");
                drawPopup(ref prpScifiUVScroll, "Use UV Scrolling", aryToggle);
                if (prpScifiUVScroll.floatValue == 1) {
                    EditorGUI.indentLevel++;
                    materialEditor.ShaderProperty(prpScifiUVScrollX, "UV Scroll X");
                    materialEditor.ShaderProperty(prpScifiUVScrollY, "UV Scroll Y");
                    EditorGUI.indentLevel--;
                }
            } else if (prpScifiProjection.floatValue >= 1) {
                // triplanar
                materialEditor.ShaderProperty(prpScifiTPThreshold, "TP Threshold");
                materialEditor.ShaderProperty(prpScifiTPScaleX, "TP Scale X");
                materialEditor.ShaderProperty(prpScifiTPScaleY, "TP Scale Y");
                materialEditor.ShaderProperty(prpScifiTPScaleZ, "TP Scale Z");
                materialEditor.ShaderProperty(prpScifiTPRotate, "TP Rotate");
                materialEditor.ShaderProperty(prpScifiTPRotateSpeed, "TP Rotate Speed");
                drawPopup(ref prpScifiTPPan, "Use TP Panning", aryToggle);
                if (prpScifiTPPan.floatValue == 1) {
                    EditorGUI.indentLevel++;
                    materialEditor.ShaderProperty(prpScifiTPPanX, "TP Pan X");
                    materialEditor.ShaderProperty(prpScifiTPPanY, "TP Pan Y");
                    materialEditor.ShaderProperty(prpScifiTPPanZ, "TP Pan Z");
                    EditorGUI.indentLevel--;
                }
            }
            EditorGUI.indentLevel--;
            // projection style
            drawPopup(ref prpScifiWavesStyle, "Scifi Waves Style", aryProjectionStyle);
            EditorGUI.indentLevel++;
            if (prpScifiProjection.floatValue != 0) {
                materialEditor.ShaderProperty(prpScifiWavesUV, "Use Mesh UV Instead");
            }
            materialEditor.ShaderProperty(prpScifiWavesSpeed, "Scifi Waves Speed");
            materialEditor.ShaderProperty(prpScifiWaveNoiseScale, "Scifi Waves Scale");
            materialEditor.ShaderProperty(prpScifiWavesSize, "Scifi Waves Size");
            materialEditor.ShaderProperty(prpScifiWavesPixelation, "Scifi Waves Pixelation");
            materialEditor.ShaderProperty(prpScifiWavesRotation, "Scifi Waves Rotation");
            materialEditor.ShaderProperty(prpScifiWavesRotationSpeed, "Scifi Waves Rotation Speed");
            materialEditor.ShaderProperty(prpScifiWavesOpacity, "Scifi Waves Opacity");
            if (prpScifiWavesOpacity.floatValue == 1) {
                materialEditor.ShaderProperty(prpScifiWavesOpacityLower, "Opacity Lower Bounds");
                materialEditor.ShaderProperty(prpScifiWavesOpacityHigher, "Opacity Higher Bounds");
            }
            materialEditor.ShaderProperty(prpScifiWavesWidth, "Scifi Waves Width");
            if (prpScifiWavesWidth.floatValue == 1) {
                materialEditor.ShaderProperty(prpScifiWavesWidthLower, "Width Lower Bounds");
                materialEditor.ShaderProperty(prpScifiWavesWidthHigher, "Width Higher Bounds");
            }
            EditorGUI.indentLevel--;
            materialEditor.ShaderProperty(prpScifiEmission, "Use Scifi Emission");
            if (prpScifiEmission.floatValue == 1) {
                EditorGUI.indentLevel++;
                materialEditor.ShaderProperty(prpScifiEmissionColor, "Scifi Emission Color");
                materialEditor.ShaderProperty(prpScifiEmissionAmount, "Scifi Emission Intensity");
                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndVertical();
            // updating keywords
            doKeywordEnumUpdateProjection(targetMat, "_ScifiProjection");
            doKeywordEnumUpdatePattern(targetMat, "_ScifiTexPattern");
            doKeywordEnumUpdateBackground(targetMat, "_ScifiTexBackgroundColorStyle");
            doKeywordEnumUpdateWave(targetMat, "_ScifiWavesStyle");
            doKeywordUpdateEnumColorStyle(targetMat, "_ScifiTexColorStyle");
        }

        // attribution
        makeSimpleTab(ref tabAttribution, "Attribution", EditorStyles.boldLabel);
        if (tabAttribution)
        {
            EditorGUILayout.BeginVertical("GroupBox");
            wrapStyle = new GUIStyle(GUI.skin.label);
            wrapStyle.wordWrap = true;
            EditorGUILayout.LabelField("Iconmonstr for some of the icons in the examples, others were made by me in Affinity Photo. Roystan for the Unity Toon shader tutorial. Arial is the font used in the example and banner. Llealloo for VRChat.", wrapStyle);
            EditorGUILayout.EndVertical();
        }

        // license
        makeSimpleTab(ref tabLicense, "License", EditorStyles.boldLabel);
        if (tabLicense)
        {
            EditorGUILayout.BeginVertical("GroupBox");
            EditorGUILayout.LabelField("You may not redistribute this in any form, unless in transformative works if a commercial package was purchased. You may not reuse this code in anyway. All code belongs to Luka (Zoey) Song unless stated otherwise.", EditorStyles.label);
            EditorGUILayout.EndVertical();
        }

        // more
        makeSimpleTab(ref tabMore, "More", EditorStyles.boldLabel);
        if (tabMore)
        {
            EditorGUILayout.BeginVertical("GroupBox");
            EditorGUILayout.LabelField("You can also find me on Discord at luka#8375 :)", EditorStyles.label);
            if (GUILayout.Button("Open Website")) {
                Application.OpenURL("http://www.luka.moe");
            }
            if (GUILayout.Button("Open Gumroad Store"))
            {
                Application.OpenURL("https://lukasong.gumroad.com");
            }
            if (GUILayout.Button("Open Booth Store"))
            {
                Application.OpenURL("https://lukasong.booth.pm");
            }
            if (GUILayout.Button("Open Payhip Store"))
            {
                Application.OpenURL("https://payhip.com/lukasong");
            }
            if (GUILayout.Button("Open Github")) {
                Application.OpenURL("https://www.github.com/lukasong");
            }
            if (GUILayout.Button("Open Youtube")) {
                Application.OpenURL("https://www.youtube.com/channel/UCwyJeuxwhgnxre3FaSacEug");
            }
            EditorGUILayout.EndVertical();
        }

        // label 
        middleStyle = new GUIStyle(EditorStyles.boldLabel);
        middleStyle.alignment = TextAnchor.MiddleCenter;
        EditorGUILayout.LabelField("Copyright protected by Luka (Zoey) Song.", middleStyle);
        EditorGUILayout.LabelField("Not for resale.", middleStyle);


    }


}

#endif 