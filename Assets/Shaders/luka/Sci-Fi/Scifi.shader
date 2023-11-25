Shader "luka/Sci-Fi"
{
    Properties {
        // rendering 
        [Toggle(_KEYWORD_FADE_AWAY)] _FadeAway ("Fade Away", Float) = 0
        _FadeAwayStart ("Fade Away Start", Float) = 15
        _FadeAwayEnd ("Fade Away End", Float) = 20
        [Enum(UnityEngine.Rendering.CullMode)] _Culling ("Culling", Float) = 0
        [Enum(UnityEngine.Rendering.ZWrite)] _ZWrite ("Z Write", Float) = 1
        // lighting
        [HDR] _MTColor ("Color", Color) = (1, 1, 1, 1)
        [HDR] _MTAmbientColor ("Ambient Color", Color) = (0.35, 0.35, 0.35, 1)
        [HDR] _MTSpecularColor ("Specular Color", Color) = (0.95, 0.95, 0.95, 1)
        _MTGlossiness ("Glossiness", Float) = 32
        [HDR] _MTRimColor ("Rim Color", Color) = (1, 1, 1, 1)
        _MTRimPower ("Rim Power", Range(0, 1)) = 0.7
        _MTRimThreshold ("Rim Threshold", Range(0, 1)) = 0.1
        _MTUseLighting ("Use Lighting", Range(0, 1)) = 1
        _MTBrighten ("Brighten", Range(0, 1)) = 0
        _MTDarken ("Darken", Range(0, 1)) = 0
        // texture
        _MainTex ("Texture", 2D) = "white" { }
        [Toggle(_KEYWORD_USE_NORMALS)] _NormalsToggle ("Use Use Normal Map", Range(0, 1)) = 0
        _NormalMap ("Normal Map", 2D) = "" { }
        _NormalMapIntensity ("Normal Map Intensity", Range(0, 2)) = 1
        _NormalMapScale ("Normal Map Scale", Range(0.1, 20)) = 1
        // scifi 
        _ScifiTex ("Scifi Texture", 2D) = "white" { }
        [Toggle(_KEYWORD_USE_MONITOR)] _ScifiMonitor ("Monitor Up-Close", Float) = 0
        _ScifiMonitorApply ("Monitor Apply", Float) = 0
        _ScifiMonitorScale ("Monitor Scale", Float) = 50
        _ScifiMonitorDistance ("Monitor Distance", Float) = 2
        _ScifiMonitorBlend ("Monitor Blend", Range(0, 1)) = 0.5
        // scifi blend settings
        _ScifiProjection ("Scifi Projection", Float) = 0.0
        _ScifiOpacity ("Scifi Opacity", Range(0, 10)) = 1.0
        // scifi texture
        [IntRange] _ScifiTexAmount ("Scifi Texture Amount", Range(1, 20)) = 5
        _ScifiTexWidth ("Scifi Texture Width", Range(1, 4)) = 1.08
        _ScifiTexCell ("Scifi Texture Cell", Float) = 1.1
        _ScifiTexOffset ("Scifi Texture Offset", Float) = 0
        _ScifiTexColorStyle ("Scifi Texture Color", Float) = 0
        [HDR] _ScifiTexColorOne ("Scifi Texture Color One", Color) = (1, 1, 1, 1)
        [HDR] _ScifiTexColorTwo ("Scifi Texture Color Two", Color) = (0, 0, 1, 1)
        _ScifiTexRainbowHue ("Scifi Texture Rainbow Hue", Float) = 1
        _ScifiTexRainbowSat ("Scifi Texture Rainbow Sat", Float) = 1
        _ScifiTexRainbowBri ("Scifi Texture Rainbow Bri", Float) = 1
        _ScifiTexRainbowSpeed ("Scifi Texture Rainbow Speed", Float) = 1
        _ScifiTexPattern ("Scifi Texture Pattern", Float) = 0
        _ScifiTexBackgroundColorStyle ("Scifi Texture Background Color", Float) = 1
        _ScifiTexBackgroundColor ("Scifi Texture Background Color", Color) = (0, 0, 0, 1)
        _ScifiTexBackgroundColorTwo ("Scifi Texture Background Color Two", Color) = (0, 0, 1, 1)
        _ScifiTexBackgroundRainbowHue ("Scifi Texture Background Rainbow Hue", Float) = 1
        _ScifiTexBackgroundRainbowSat ("Scifi Texture Background Rainbow Sat", Float) = 1
        _ScifiTexBackgroundRainbowBri ("Scifi Texture Background Rainbow Bri", Float) = 1
        _ScifiTexBackgroundRainbowSpeed ("Scifi Texture Background Rainbow Speed", Float) = 1
        // scifi uv settings
        _ScifiUVScaleX ("Scifi UV Scale X", Float) = 1.0
        _ScifiUVScaleY ("Scifi UV Scale Y", Float) = 1.0
        _ScifiUVOffsetX ("Scifi UV Offset X", Float) = 0.0
        _ScifiUVOffsetY ("Scifi UV Offset Y", Float) = 0.0
        _ScifiUVRotate ("Scifi UV Rotate", Float) = 0.0
        _ScifiUVRotateSpeed ("Scifi UV Rotate Speed", Float) = 0.0
        _ScifiUVScroll ("Scifi UV Scroll", Float) = 0.0
        _ScifiUVScrollX ("Scifi UV Scroll X", Float) = 0.0
        _ScifiUVScrollY ("Scifi UV Scroll Y", Float) = 0.0
        // scifi triplanar settings
        _ScifiTPScaleX ("Scifi Triplanar Scale X", Float) = 1.0
        _ScifiTPScaleY ("Scifi Triplanar Scale Y", Float) = 1.0
        _ScifiTPScaleZ ("Scifi Triplanar Scale Z", Float) = 1.0
        _ScifiTPPan ("Scifi Triplanar Pan", Float) = 0.0
        _ScifiTPPanX ("Scifi Triplanar Pan X", Float) = 0.0
        _ScifiTPPanY ("Scifi Triplanar Pan Y", Float) = 0.0
        _ScifiTPPanZ ("Scifi Triplanar Pan Z", Float) = 0.0
        _ScifiTPThreshold ("Scifi Triplanar Threshold", Range(0, 1)) = 0.25
        _ScifiTPRotate ("Scifi Triplanar Rotate", Float) = 0.0
        _ScifiTPRotateSpeed ("Scifi Triplanar Rotate Speed", Float) = 0.0
        // scifi waves
        _ScifiWavesStyle ("Scifi Waves Style", Float) = 0.0 // 0 = disabled, 1 = circles, 2 = noise waves
        [Toggle(_KEYWORD_USE_SCIFI_FORCE_UV)] _ScifiWavesUV ("Scifi Waves UV", Float) = 0.0
        _ScifiWavesSpeed ("Scifi Waves Speed", Float) = 1
        _ScifiWaveNoiseScale ("Scifi Wave  Noise Scale", Float) = 0.1
        _ScifiWavesSize ("Scifi Wave Size", Float) = 0.1
        _ScifiWavesPixelation ("Scifi Wave Pixelation", Range(0, 1)) = 0
        _ScifiWavesRotation ("Scifi Waves Rotation", Float) = 0.0
        _ScifiWavesRotationSpeed ("Scifi Waves Rotation Speed", Float) = 0.0
        [Toggle(_KEYWORD_USE_SCIFI_OPACITY)] _ScifiWavesOpacity ("Scifi Waves Opacity", Float) = 0.0 // to-do: convert to keyword
        _ScifiWavesOpacityLower ("Scifi Waves Lower", Float) = 0.2
        _ScifiWavesOpacityHigher ("Scifi Waves Higher", Float) = 1.2
        [Toggle(_KEYWORD_USE_SCIFI_WIDTH)] _ScifiWavesWidth ("Scifi Waves Width", Float) = 0.0 // to-do: convert to keywor
        _ScifiWavesWidthLower ("Scifi Waves Lower", Float) = 0.9
        _ScifiWavesWidthHigher ("Scifi Waves Higher", Float) = 1.2
        // [Enum(TEXTURE, 0, GRADIENT, 1)] _ScifiWavesBackground ("Scifi Waves Background", Float) = 0.0 // to-do: convert to keyword
        // _ScifiWavesBackgroundGradientOne ("Scifi Waves Background Gradient One", Color) = (0.0, 0.0, 0.0, 1.0)
        // _ScifiWavesBackgroundGradientTwo ("Scifi Waves Background Gradient Two", Color) = (0.0, 0.0, 0.0, 1.0)
        [Toggle(_KEYWORD_USE_SCIFI_EMISSION)] _ScifiEmission ("Scifi Emission", Float) = 0.0 // to-do: convert to keywor
        _ScifiEmissionAmount ("Scifi Emission Amount", Float) = 0.0
        _ScifiEmissionColor ("Scifi Emission Color", Color) = (0.0, 0.0, 0.0, 1.0)

    }
    SubShader
    {
        Tags 
            { 
            "RenderType"="Opaque" 
            "PassFlags" = "OnlyDirectional"
            }
        LOD 100
        Cull [_Culling]
        ZWrite [_ZWrite]

        Pass
        {

            // unity scheiße 
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment pixel
            #pragma multi_compile_fwdbase
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"

            #pragma shader_feature_local _ _KEYWORD_USE_PROJECTION_UV 
            // #pragma shader_feature_local _ _KEYWORD_USE_PROJECTION_SIMPLE_TRIPLANAR
            #pragma shader_feature_local _ _KEYWORD_USE_PROJECTION_PROJEKT_TRIPLANAR
            #pragma shader_feature_local _ _KEYWORD_PATTERN_HONEYCOMB
            #pragma shader_feature_local _ _KEYWORD_PATTERN_INVERSE_HONEYCOMB
            #pragma shader_feature_local _ _KEYWORD_PATTERN_CARDS
            #pragma shader_feature_local _ _KEYWORD_PATTERN_INVERSE_CARDS
            #pragma shader_feature_local _ _KEYWORD_USE_SCIFI_OPACITY
            #pragma shader_feature_local _ _KEYWORD_USE_SCIFI_WIDTH
            #pragma shader_feature_local _ _KEYWORD_USE_SCIFI_EMISSION
            // #pragma shader_feature_local _ _KEYWORD_USE_COLOR_ONE
            #pragma shader_feature_local _ _KEYWORD_USE_COLOR_GRADIENT
            #pragma shader_feature_local _ _KEYWORD_USE_COLOR_RAINBOW
            #pragma shader_feature_local _ _KEYWORD_USE_TRANSPARENT_BACKGROUND
            #pragma shader_feature_local _ _KEYWORD_USE_RAINBOW_BACKGROUND
            #pragma shader_feature_local _ _KEYWORD_WAVE_NOISEY_WAVES
            #pragma shader_feature_local _ _KEYWORD_WAVE_OOZE
            #pragma shader_feature_local _ _KEYWORD_WAVE_BUBBLES
            #pragma shader_feature_local _ _KEYWORD_WAVE_SWIRLS
            #pragma shader_feature_local _ _KEYWORD_WAVE_SCANLINE
            #pragma shader_feature_local _ _KEYWORD_USE_SCIFI_FORCE_UV
            #pragma shader_feature_local _ _KEYWORD_USE_MONITOR
            #pragma shader_feature_local _ _KEYWORD_USE_NORMALS
            #pragma shader_feature_local _ _KEYWORD_FADE_AWAY

            // good ol c
            struct appdata
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
                #ifdef _KEYWORD_USE_NORMALS
                    float4 tangent : TANGENT;
                #endif 
            };
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
                float3 worldNormal : NORMAL;
                float3 viewDir : TEXCOORD1;
                float3 worldPos : TEXCOORD5;
                float2 uvProjections : TEXCOORD3;
                #ifdef _KEYWORD_USE_MONITOR
                    float distanceMonitor : TEXCOORD4; 
                #endif 
                #ifdef _KEYWORD_USE_NORMALS
                    float3 lightDirection : TEXCOORD6;
                #endif 
                #ifdef _KEYWORD_FADE_AWAY
                    float2 fadeAway : TEXCOORD7;
                #endif 
                SHADOW_COORDS(2)
            };

            // properties
            sampler2D _MainTex;
            float4 _MainTex_ST;

            // scifi
            sampler2D _ScifiTex;
            float4 _ScifiTex_ST;
            float _ScifiProjection;
            float _ScifiBlend, _ScifiOpacity;
            // scifi texture
            float _ScifiTexAmount, _ScifiTexWidth, _ScifiTexCell, _ScifiTexOffset;
            float4 _ScifiTexColorOne;
            #if defined(_KEYWORD_USE_COLOR_GRADIENT)
                float4 _ScifiTexColorTwo;
            #elif defined(_KEYWORD_USE_COLOR_RAINBOW)
                float _ScifiTexRainbowHue, _ScifiTexRainbowSat, _ScifiTexRainbowBri,
                    _ScifiTexRainbowSpeed;
            #endif 
            // scifi uv
            float _ScifiUVScaleX, _ScifiUVScaleY,
                _ScifiUVOffsetX, _ScifiUVOffsetY,
                _ScifiUVRotate, _ScifiUVScroll,
                _ScifiUVScrollX, _ScifiUVScrollY,
                _ScifiUVRotateSpeed;
            // scifi triplanar
            float _ScifiTPScaleX, _ScifiTPScaleY, _ScifiTPScaleZ,
                _ScifiTPPanX, _ScifiTPPanY, _ScifiTPPanZ, _ScifiTPPan,
                _ScifiTPThreshold, _ScifiTPRotate, _ScifiTPRotateSpeed;
            // scifi waves
            float _ScifiWavesStyle, _ScifiWavesSpeed, _ScifiWaveNoiseScale, 
                _ScifiWavesOpacity, _ScifiWavesOpacityLower, _ScifiWavesOpacityHigher, 
                _ScifiWavesWidth, _ScifiWavesWidthLower, _ScifiWavesWidthHigher, 
                _ScifiWavesRotation, _ScifiWavesSize, _ScifiWavesPixelation,
                _ScifiWavesRotationSpeed;
            // scifi emission
            #ifdef _KEYWORD_USE_SCIFI_EMISSION
                float _ScifiEmissionAmount;
                float4 _ScifiEmissionColor;
            #endif
            // scifi background
            #ifdef _KEYWORD_USE_RAINBOW_BACKGROUND
                float _ScifiTexBackgroundRainbowHue, _ScifiTexBackgroundRainbowSat, _ScifiTexBackgroundRainbowBri,
                    _ScifiTexBackgroundRainbowSpeed;
            #else 
                #ifndef _KEYWORD_USE_TRANSPARENT_BACKGROUND
                    float4 _ScifiTexBackgroundColor;
                #endif 
            #endif

            // act like monitor up close
            #ifdef _KEYWORD_USE_MONITOR
                float _ScifiMonitorApply, _ScifiMonitorScale, _ScifiMonitorDistance,
                _ScifiMonitorBlend;
            #endif

            // fade away
            #ifdef _KEYWORD_FADE_AWAY
                float _FadeAwayStart, _FadeAwayEnd;
            #endif 

            // functions (after declarations because... me lazy)
            #include "Resources/Cginc/LukaScifiFunctions.cginc"

            // vertex 
            v2f vert (appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.pos);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.uvProjections = o.uv;
                initProjUV(o.uv);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.worldPos = mul(unity_ObjectToWorld, v.pos).xyz;
                o.viewDir = WorldSpaceViewDir(v.pos);
                #ifdef _KEYWORD_USE_MONITOR
                    o.distanceMonitor = getDistance();
                    o.distanceMonitor = getFalloffSmooth(o.distanceMonitor, 0, _ScifiMonitorDistance);
                #endif 
                #ifdef _KEYWORD_USE_NORMALS
                    TANGENT_SPACE_ROTATION;
                    o.lightDirection = mul(rotation, ObjSpaceLightDir(v.pos));
                #endif 
                #ifdef _KEYWORD_FADE_AWAY
                    o.fadeAway.x= getDistance();
                    o.fadeAway.x = getFalloffSmooth(o.fadeAway.x, _FadeAwayStart, _FadeAwayEnd);
                    if (o.fadeAway.x == 0) {
                        o.fadeAway.y = 1; // shut off
                    } else {
                        o.fadeAway.y = 0; // keep on
                    }
                #endif 
                TRANSFER_SHADOW(o)
                return o;
            }

            // lighting properties
            float4 _MTColor, _MTAmbientColor, _MTSpecularColor, _MTRimColor;
            float _MTGlossiness, _MTRimPower, _MTRimThreshold, _MTUseLighting, _MTBrighten, _MTDarken;

            // normal map properties
            #ifdef _KEYWORD_USE_NORMALS
                sampler2D _NormalMap;
                float4 _NormalMap_ST;
                float _NormalMapIntensity, _NormalMapScale;
            #endif

            // pixel
            float4 pixel (v2f i) : SV_Target
            {

                // create the base color 
                float4 finalColor = tex2D(_MainTex, i.uv);

                #ifdef _KEYWORD_FADE_AWAY
                    // cut off early?
                    if (i.fadeAway.y == 1) return finalColor;
                    // ok then fade out opacity
                    _ScifiOpacity *= i.fadeAway.x;
                #endif 

                // first, create the uv space
                float4 scifiColor = float4(0.0, 0.0, 0.0, 0.0);
                #if defined(_KEYWORD_USE_PROJECTION_UV)
                    // create the uv space
                    float2 projUV = i.uv;
                    initProjUV(projUV);
                    // create the waves (since it will be used to set the width and such)
                    float waveValue = 0;
                    #if defined(_KEYWORD_WAVE_NOISEY_WAVES)
                        waveValue = waveNoiseyWaves(projUV);
                    #elif defined(_KEYWORD_WAVE_OOZE)
                        waveValue = waveOoze(projUV);
                    #elif defined(_KEYWORD_WAVE_BUBBLES)
                        waveValue = waveBubbles(projUV);
                    #elif defined(_KEYWORD_WAVE_SWIRLS)
                        waveValue = waveSwirls(projUV);
                    #elif defined(_KEYWORD_WAVE_SCANLINE)
                        waveValue = waveScanline(projUV);
                    #else 
                        waveValue = waveCircles(projUV);
                    #endif 
                    #ifdef _KEYWORD_USE_SCIFI_WIDTH
                        _ScifiTexWidth *= _ScifiWavesWidthLower + waveValue * _ScifiWavesWidthHigher;
                    #endif
                    #ifdef _KEYWORD_USE_SCIFI_OPACITY
                        _ScifiOpacity *= _ScifiWavesOpacityLower + waveValue * _ScifiWavesOpacityHigher;
                    #endif
                    // and now create the pattern
                    #if defined(_KEYWORD_PATTERN_HONEYCOMB)
                        scifiHoneycomb(scifiColor, projUV);
                    #elif defined(_KEYWORD_PATTERN_INVERSE_HONEYCOMB)
                        scifiHoneycombInverse(scifiColor, projUV);
                    #elif defined(_KEYWORD_PATTERN_CARDS)
                        scifiCards(scifiColor, projUV);
                    #elif defined(_KEYWORD_PATTERN_INVERSE_CARDS)
                        scifiCardsInverse(scifiColor, projUV);
                    #endif  
                // #elif defined(_KEYWORD_USE_PROJECTION_SIMPLE_TRIPLANAR)
                    // dead ~ not gonna use 
                #elif defined(_KEYWORD_USE_PROJECTION_PROJEKT_TRIPLANAR)
                    // create the uv space
                    float3 tpProjektUVs = float3(0, 0, 0);
                    float3 tpProjektBlend = float3(0, 0, 0);
                    outProjTriplanarWitcherUVs(tpProjektUVs, tpProjektBlend, i.worldNormal, i.worldPos);
                    float2 tpProjektWSwivel[3] = {
                        tpProjektUVs.zy, tpProjektUVs.xz, tpProjektUVs.xy
                    };
                    // rotate? has to go here ig..
                    [branch] if (_ScifiTPRotate != 0)
                    {
                        [branch] if (_ScifiTPRotateSpeed != 0)
                        {
                            _ScifiTPRotate += _Time.y * _ScifiTPRotateSpeed;
                        }
                        tpProjektWSwivel[0] = rotateUV(tpProjektWSwivel[0], float2(0.5, 0.5), _ScifiTPRotate);
                        tpProjektWSwivel[1] = rotateUV(tpProjektWSwivel[1], float2(0.5, 0.5), _ScifiTPRotate);
                        tpProjektWSwivel[2] = rotateUV(tpProjektWSwivel[2], float2(0.5, 0.5), _ScifiTPRotate);
                    }
                    // create the waves (since it will be used to set the width and such)
                    float tpProjektWWave[3] = { 0, 0, 0 };
                    #ifdef _KEYWORD_USE_SCIFI_FORCE_UV
                        float tpProjektWaveSingular = 0;
                        #if defined(_KEYWORD_WAVE_NOISEY_WAVES)
                            tpProjektWaveSingular = waveNoiseyWaves(i.uv);
                        #elif defined(_KEYWORD_WAVE_OOZE)
                            tpProjektWaveSingular = waveOoze(i.uv);
                        #elif defined(_KEYWORD_WAVE_BUBBLES)
                            tpProjektWaveSingular = waveBubbles(i.uv);
                        #elif defined(_KEYWORD_WAVE_SWIRLS)
                            tpProjektWaveSingular = waveSwirls(i.uv);
                        #elif defined(_KEYWORD_WAVE_SCANLINE)
                            tpProjektWaveSingular = waveScanline(i.uv);
                        #else
                            tpProjektWaveSingular = waveCircles(i.uv);
                        #endif
                        tpProjektWWave[0] = tpProjektWaveSingular;
                        tpProjektWWave[1] = tpProjektWaveSingular;
                        tpProjektWWave[2] = tpProjektWaveSingular;

                    #else 
                        ftTriplanar(tpProjektWWave, tpProjektWSwivel, 0);
                        ftTriplanar(tpProjektWWave, tpProjektWSwivel, 1);
                        ftTriplanar(tpProjektWWave, tpProjektWSwivel, 2);
 
                    #endif 
                    // set colors 
                    ftTriplanarColor(scifiColor, tpProjektWSwivel, tpProjektBlend, tpProjektWWave);
                #endif

                // emission?
                #ifdef _KEYWORD_USE_SCIFI_EMISSION
                    scifiColor.rgba *= (1.0 + (_ScifiEmissionAmount * _ScifiEmissionColor.rgba));
                #endif 

                // and color style
                #if defined(_KEYWORD_USE_COLOR_GRADIENT)
                    float gradientScale = _ScifiTexAmount;
                    #ifdef _KEYWORD_USE_PROJECTION_PROJEKT_TRIPLANAR
                        gradientScale *= max(max(_ScifiTPScaleY, _ScifiTPScaleX), _ScifiTPScaleZ);
                    #else 
                        gradientScale *= max(_ScifiUVScaleX, _ScifiUVScaleY);
                    #endif 
                    float gradientColor = makeNoiseSimple(i.uv, gradientScale);
                    scifiColor *= lerp(_ScifiTexColorOne, _ScifiTexColorTwo, gradientColor);
                #elif defined(_KEYWORD_USE_COLOR_RAINBOW)
                    float rainbowScale = _ScifiTexAmount;
                    #ifdef _KEYWORD_USE_PROJECTION_PROJEKT_TRIPLANAR
                        rainbowScale *= max(max(_ScifiTPScaleY, _ScifiTPScaleX), _ScifiTPScaleZ);
                    #else
                        rainbowScale *= max(_ScifiUVScaleX, _ScifiUVScaleY);
                    #endif
                    scifiColor.rgb *= makeRainbowFast(i.uv, _ScifiTexRainbowSpeed, 1, 1, makeNoiseSimple(i.uv, rainbowScale * _ScifiTexRainbowHue), _ScifiTexRainbowSat, _ScifiTexRainbowBri);
                #else 
                    scifiColor *= _ScifiTexColorOne;
                #endif
                
                // for use in blending
                float colorLuma = getLuma(scifiColor);

                #ifdef _KEYWORD_USE_MONITOR
                    // split up into rgb cells 
                    float3 monitorPanel = float3(0, 0, 0);
                    float monitorUV = frac(i.uv.x * _ScifiMonitorScale);
                    if (floor(i.uv.y * _ScifiMonitorScale) % 2) {
                        monitorUV.x += 0.2;
                    } else {
                        monitorUV.x -= 0.2;
                    }
                    monitorPanel = makeRGBPanel(monitorUV);
                    // add border to cells
                    float2 borderTest = float2(monitorUV, frac(i.uv.y * _ScifiMonitorScale));
                    if (borderTest.x > 0.95 || borderTest.x < 0.05 || borderTest.y > 0.95 || borderTest.y < 0.05) {
                        monitorPanel = 0;
                    }
                    // 0 = far away, 1 = close
                    [forcecase] switch (_ScifiMonitorApply) {
                        case 0: // wave
                            scifiColor.rgb = lerp(scifiColor, monitorPanel, saturate(i.distanceMonitor * _ScifiMonitorBlend * 2));
                            break;
                        case 1: // tex
                            finalColor.rgb = lerp(finalColor, monitorPanel, i.distanceMonitor * _ScifiMonitorBlend);
                            break;
                        case 2: // both
                            scifiColor.rgb = lerp(scifiColor, monitorPanel, saturate(i.distanceMonitor * _ScifiMonitorBlend * 2));
                            finalColor.rgb = lerp(finalColor, monitorPanel, i.distanceMonitor * _ScifiMonitorBlend);
                            break;
                        default: // end 
                            break; // ? how
                    }
                #endif 

                // and now merge with background
                #if defined(_KEYWORD_USE_TRANSPARENT_BACKGROUND)
                    finalColor.rgb = lerp(finalColor.rgb, scifiColor.rgb, colorLuma * _ScifiOpacity);
                #elif defined(_KEYWORD_USE_RAINBOW_BACKGROUND)
                    float3 rainbowColor = makeRainbowFast(i.uv, _ScifiTexBackgroundRainbowSpeed, 1, 1, makeNoiseSimple(i.uv, _ScifiTexAmount * _ScifiTexBackgroundRainbowHue), _ScifiTexBackgroundRainbowSat, _ScifiTexBackgroundRainbowBri);
                    finalColor.rgb = lerp(rainbowColor.rgb, scifiColor.rgb, colorLuma * _ScifiOpacity);
                #else 
                    finalColor.rgb = lerp(_ScifiTexBackgroundColor.rgb, scifiColor.rgb, colorLuma * _ScifiOpacity);
                #endif 

                // calculate toon lighting    
                float3 normal = normalize(i.worldNormal);
                float3 viewDir = normalize(i.viewDir);
                float NdotL = dot(_WorldSpaceLightPos0, normal);
                float shadow = SHADOW_ATTENUATION(i);
                float lightIntensity = smoothstep(0, 0.01, NdotL * shadow);
                float4 light = lightIntensity * _LightColor0;
                float3 halfVector = normalize(_WorldSpaceLightPos0 + viewDir);
                float NdotH = dot(normal, halfVector);
                float specularIntensity = pow(NdotH * lightIntensity, _MTGlossiness * _MTGlossiness);
                float specularIntensitySmooth = smoothstep(0.005, 0.01, specularIntensity);
                float4 specular = specularIntensitySmooth * _MTSpecularColor;
                float rimDot = 1 - dot(viewDir, normal);
                float rimIntensity = rimDot * pow(NdotL, _MTRimThreshold);
                rimIntensity = smoothstep(_MTRimPower - 0.01, _MTRimPower + 0.01, rimIntensity);
                float4 rim = rimIntensity * _MTRimColor;
                float4 finalColorLit = (light + _MTAmbientColor + specular + rim) * _MTColor * finalColor;
                finalColorLit.rgb = saturate(finalColorLit.rgb * (1.0 + _MTBrighten));
                finalColorLit.rgb = saturate(finalColorLit.rgb - _MTDarken);
                finalColor = lerp(finalColor, finalColorLit, _MTUseLighting);
                
                // normals
                #ifdef _KEYWORD_USE_NORMALS
                    float3 tangentNormal = UnpackNormal(tex2D(_NormalMap, i.uv * _NormalMapScale));
                    float3 tangentLight = normalize(i.lightDirection);
                    fixed3 normalLambertModel = 0.5 * dot(tangentNormal, tangentLight) + 0.5;
                    finalColor.rgb *= lerp(1, normalLambertModel, _NormalMapIntensity);
                #endif 


                return finalColor;
            }
            ENDCG
        }
    }   
    CustomEditor "LukaScifiEditor"
}
