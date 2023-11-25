#ifndef SCIFI_FUNCTIONS_INCLUDED
#define SCIFI_FUNCTIONS_INCLUDED


// random functions

// zoom
float2 safeZoom(float2 uv, float zoom) {
    uv.x -= 0.5;
    uv.y -= 0.5;
    uv.x *= zoom;
    uv.y *= zoom;
    uv.x += 0.5;
    uv.y += 0.5;
    uv = saturate(uv);
    return uv;
}

// rotate
float2 rotateUV(float2 UV, float2 Center, float Rotation) {
    Rotation = Rotation * (3.1415926f / 180.0f);
    UV -= Center;
    float s = sin(Rotation);
    float c = cos(Rotation);
    float2x2 rMatrix = float2x2(c, -s, s, c);
    rMatrix *= 0.5;
    rMatrix += 0.5;
    rMatrix = rMatrix * 2 - 1;
    UV.xy = mul(UV.xy, rMatrix);
    UV += Center;
    return UV;
}

// pixelate
void doPixelateFloat(inout float2 inputUVs,
    float inputPixelateX, float inputPixelateY)
    {
    // simple, square pixelation that will automatically format for floats :D
    float2 pixelateValues = ceil(abs(float2(inputPixelateX, inputPixelateY)));
    inputUVs = (floor((pixelateValues * inputUVs)) / pixelateValues);
}

// noise functions
float makeNoiseRandomI2O1(float inputSeedX,
float inputSeedY)
{
    return frac(sin(dot(float2(inputSeedX, inputSeedY), float2(12.9898, 78.233))) * 43758.5453);
}

float makeNoiseRandomI2O1(float2 inputSeed)
{
    return frac(sin(dot(inputSeed, float2(12.9898, 78.233))) * 43758.5453);
}

float makeNoiseRandomI1O1(float inputSeed)
{
    return frac(sin(inputSeed) * 43758.5453123);
}

float makeNoiseRandomTwoI2O1(float2 inputSeed)
{
    inputSeed = frac(inputSeed * float2(233.34, 851.73));
    inputSeed += dot(inputSeed, inputSeed + 23.56);
    return float(frac(inputSeed.x * inputSeed.y));
}

float2 makeNoiseRandomTwoI2O2(float2 inputSeed)
{
    float n = makeNoiseRandomTwoI2O1(inputSeed);
    return float2(n, makeNoiseRandomTwoI2O1(inputSeed + n));
}

float2 makeNoiseInverseI2O2(float inputSeedX,
float inputSeedY)
{
    float2 toReturn = float2(inputSeedX, inputSeedY);
    toReturn = float2(dot(toReturn, float2(127.1, 311.7)), dot(toReturn, float2(269.5, 183.3)));
    return float2(-1.0 + 2.0 * frac(sin(toReturn) * 43758.5453));
}

float makeNoiseSinlessI2O1(float2 inputSeed)
{
    inputSeed = frac(inputSeed * float2(233.34, 851.73));
    inputSeed += dot(inputSeed, inputSeed + 23.56);
    return float(frac(inputSeed.x * inputSeed.y));
}

float2 makeNoiseRandomI2O2(float2 inputSeed)
{
    float outputSeed = makeNoiseSinlessI2O1(inputSeed);
    return float2(outputSeed, makeNoiseSinlessI2O1(inputSeed + outputSeed));
}

float doRemap(float inputValue,
    float inputOldLow, float inputOldHigh,
    float inputNewLow, float inputNewHigh) {
    // remaps a value within range X-Y to Z-W, taking ranges as four floats
    return float(inputNewLow + (inputValue - inputOldLow) * (inputNewHigh - inputNewLow) / (inputOldHigh - inputOldLow));
}

float getLuma(float3 inputColors)
{
    // get brightness of pixel
    float3 toLuma = float3(0.29, 0.59, 0.11);
    return float(dot(inputColors, toLuma));
}

// unity's ugly conventions will be the DEATH of me..
float makeNoiseInterpolation(float a,
float b, float t)
{
    // attribution: unity technologies
    return(1.0 - t) * a + (t * b);
}

float makeNoiseSimpleValue(float2 uv)
{
    // attribution: unity technologies
    float2 i = floor(uv);
    float2 f = frac(uv);
    f = f * f * (3.0 - 2.0 * f);
    uv = abs(frac(uv) - 0.5);
    float2 c0 = i + float2(0.0, 0.0);
    float2 c1 = i + float2(1.0, 0.0);
    float2 c2 = i + float2(0.0, 1.0);
    float2 c3 = i + float2(1.0, 1.0);
    float r0 = makeNoiseRandomI2O1(c0);
    float r1 = makeNoiseRandomI2O1(c1);
    float r2 = makeNoiseRandomI2O1(c2);
    float r3 = makeNoiseRandomI2O1(c3);
    float bottomOfGrid = makeNoiseInterpolation(r0, r1, f.x);
    float topOfGrid = makeNoiseInterpolation(r2, r3, f.x);
    float t = makeNoiseInterpolation(bottomOfGrid, topOfGrid, f.y);
    return t;
}

float makeNoiseSimple(float2 inputUVs,
float inputScale)
{
    // attribution: unity technologies
    float t = 0.0;
    float freq = pow(2.0, float(0));
    float amp = pow(0.5, float(3 - 0));
    t += makeNoiseSimpleValue(float2(inputUVs.x * inputScale / freq, inputUVs.y * inputScale / freq)) * amp;
    freq = pow(2.0, float(1));
    amp = pow(0.5, float(3 - 1));
    t += makeNoiseSimpleValue(float2(inputUVs.x * inputScale / freq, inputUVs.y * inputScale / freq)) * amp;
    freq = pow(2.0, float(2));
    amp = pow(0.5, float(3 - 2));
    t += makeNoiseSimpleValue(float2(inputUVs.x * inputScale / freq, inputUVs.y * inputScale / freq)) * amp;
    return t;
}

float2 makeGradientDirection(float2 p)
{
    // attribution: unity technologies
    p = p % 289;
    float x = (34 * p.x + 1) * p.x % 289 + p.y;
    x = (34 * x + 1) * x % 289;
    x = frac(x / 41) * 2 - 1;
    return normalize(float2(x - floor(x + 0.5), abs(x) - 0.5));
}

float makeNoisePerlin(float2 inputUVs,
float inputScale)
{
    // attribution: unity technologies
    inputUVs *= inputScale;
    float2 ip = floor(inputUVs);
    float2 fp = frac(inputUVs);
    float d00 = dot(makeGradientDirection(ip), fp);
    float d01 = dot(makeGradientDirection(ip + float2(0, 1)), fp - float2(0, 1));
    float d10 = dot(makeGradientDirection(ip + float2(1, 0)), fp - float2(1, 0));
    float d11 = dot(makeGradientDirection(ip + float2(1, 1)), fp - float2(1, 1));
    fp = fp * fp * fp * (fp * (fp * 6 - 15) + 10);
    return float(float(lerp(lerp(d00, d01, fp.y), lerp(d10, d11, fp.y), fp.x)) + 0.5);
}

void doDistortFancy(inout float2 inputUVs,
float2 inputPower, float2 inputSpeed)
{
    // fancy trig distortion (~x2 trig + extra calculations)
    float distortX = inputUVs.x * 10 * inputPower.x + (_Time.y * inputSpeed.x);
    float distortY = inputUVs.y * 10 * inputPower.y - (_Time.y * inputSpeed.y);
    inputUVs.x += sin(distortX) * cos(-distortY) * (0.1 * inputPower.x);
    inputUVs.y += sin(-distortY) * cos(distortX) * (0.1 * inputPower.y);
}

float makeShapeSpiralAtan2(float2 inputUVs,
float inputScale, float inputSpeed)
{
    // makes a spiral using atan2 -> sin (length)
    float2 spiralCenter = (inputUVs - float2(0.5, 0.5));
    float spiralAtan2 = atan2(spiralCenter.x, spiralCenter.y);
    float spiralValue = sin((_Time.y * inputSpeed) + spiralAtan2 + length(spiralCenter) * inputScale);
    return spiralValue;
}

float makeScanline(float inputDirection,
    float inputPower, float inputSpeed,
    float inputSize, float inputPosition, 
    float2 inputUVs) {
    // supporting function for scanline, makes a smoothened curve of values
    float scanlineSpeed = frac(_Time.y * inputSpeed);
    // remap scanlineSpeed 0 -> 0.2 and 0.8 -> 1.0 as 0 -> 1 and 1.0 -> 0
    if (scanlineSpeed <= 0.25)
    {
        inputSize *= doRemap(scanlineSpeed, 0, 0.25, 0, 1);
    }
    else if (scanlineSpeed >= 0.75)
    {
        inputSize *= doRemap(scanlineSpeed, 0.75, 1, 1, 0);
    }
    float scanlineValue = (inputPower * (smoothstep((scanlineSpeed - inputSize), scanlineSpeed, inputUVs[inputDirection]) - smoothstep(scanlineSpeed, (scanlineSpeed + inputPower), inputUVs[inputDirection])));
    return scanlineValue;
}

float3 makeRainbowFast(float2 inputUVs,
float inputTime, float inputToggleY,
float inputToggleX, float inputHue,
float inputSat, float inputLight)
{
    // zoom-ly!! rainbow w/ trig!
    // attribution: my adaption of "sinebow" by jim bumgardner (@jbum)
    // note to self: no saturation on fast!
    float sinebowValue = (_Time.y * inputTime);
    sinebowValue += (inputUVs.y * inputToggleY);
    sinebowValue += (inputUVs.x * inputToggleX);
    sinebowValue += inputHue;
    float3 sinebowColor = float3(0.0, 0.0, 0.0);
    sinebowColor = sin(sinebowValue * UNITY_PI + float3(0.0, UNITY_PI / 3.0, UNITY_PI / 1.5));
    return float3((sinebowColor * sinebowColor) * inputLight);
}

float3 getCamera()
{
    #if UNITY_SINGLE_PASS_STEREO
        return(unity_StereoWorldSpaceCameraPos[0] + unity_StereoWorldSpaceCameraPos[1]) * 0.5;
    #else
        return _WorldSpaceCameraPos;
    #endif
}

float getDistance()
{
    // getting a basic distance away from the center of the object
    return float(distance(getCamera(), mul(unity_ObjectToWorld, float4(0, 0, 0, 1))));
}

float getFalloff(float inputCameraDistance, float inputFalloffStart, float inputFalloffEnd) {
    return float((clamp(inputCameraDistance, inputFalloffStart, inputFalloffEnd) - inputFalloffStart) / (inputFalloffEnd - inputFalloffStart));
}

float getFalloffSmooth(float inputCameraDistance,
    float inputFalloffStart, float inputFalloffEnd) {
    // distance falloff with smoothstep
    return float(smoothstep(1.0, 0.0, getFalloff(inputCameraDistance, inputFalloffStart, inputFalloffEnd)));
}

float3 makeRGBPanel(float inputUVs)
{
    // makes rgb stripes based on uvs
    // hacky workaround so no ifs..
    float sceneTest = floor(inputUVs * 3);
    float4 rgbColors[3];
    rgbColors[0] = float4(1, 0, 0, 1);
    rgbColors[1] = float4(0, 1, 0, 1);
    rgbColors[2] = float4(0, 0, 1, 1);
    return rgbColors[sceneTest];
}

// pattern functions

// patterns for scifi overlay
void scifiHoneycombUVs(inout float2 outputUVs[4], float2 inputUVs) {
    // set up base uvs 
    float2 honeycombCutoff[2] = { inputUVs, inputUVs };
    honeycombCutoff[0] = frac(honeycombCutoff[0] * _ScifiTexAmount);
    honeycombCutoff[1] = frac(honeycombCutoff[1] * _ScifiTexAmount + 0.5);
    // zoom
    honeycombCutoff[0] = safeZoom(honeycombCutoff[0], _ScifiTexWidth * _ScifiTexCell);
    honeycombCutoff[1] = safeZoom(honeycombCutoff[1], _ScifiTexWidth * _ScifiTexCell);
    // now create the base pattern
    float2 honeycombBase[2] = { inputUVs, inputUVs };
    honeycombBase[0] = frac(honeycombBase[0] * _ScifiTexAmount);
    honeycombBase[1] = frac(honeycombBase[1] * _ScifiTexAmount + 0.5);
    // and zoom it
    honeycombBase[0] = safeZoom(honeycombBase[0], _ScifiTexCell);
    honeycombBase[1] = safeZoom(honeycombBase[1], _ScifiTexCell);
    // re-assign
    outputUVs[0] = honeycombCutoff[0];
    outputUVs[1] = honeycombCutoff[1];
    outputUVs[2] = honeycombBase[0];
    outputUVs[3] = honeycombBase[1];
}

void scifiHoneycombUVsInverse(inout float2 outputUVs[4], float2 inputUVs)
{
    // set up base uvs
    float2 honeycombCutoff[2] = {
        inputUVs, inputUVs
    };
    honeycombCutoff[0] = frac(honeycombCutoff[0] * _ScifiTexAmount);
    honeycombCutoff[1] = frac(honeycombCutoff[1] * -_ScifiTexAmount + 0.5);
    // zoom
    honeycombCutoff[0] = safeZoom(honeycombCutoff[0], _ScifiTexWidth * _ScifiTexCell);
    honeycombCutoff[1] = safeZoom(honeycombCutoff[1], _ScifiTexWidth * _ScifiTexCell);
    // now create the base pattern
    float2 honeycombBase[2] = {
        inputUVs, inputUVs
    };
    honeycombBase[0] = frac(honeycombBase[0] * _ScifiTexAmount);
    honeycombBase[1] = frac(honeycombBase[1] * -_ScifiTexAmount + 0.5) * float2(1, -1);
    // and zoom it
    honeycombBase[0] = safeZoom(honeycombBase[0], _ScifiTexCell);
    honeycombBase[1] = safeZoom(honeycombBase[1], _ScifiTexCell);
    // re-assign
    outputUVs[0] = honeycombCutoff[0];
    outputUVs[1] = honeycombCutoff[1];
    outputUVs[2] = honeycombBase[0];
    outputUVs[3] = honeycombBase[1];
}

void scifiHoneycombColor(inout float4 inputColors, float2 inputUVs[4]) {
    // and now combine, can do for inverse and normal iirc
    float4 hexOne = tex2D(_ScifiTex, inputUVs[2]);
    hexOne.rgb = saturate(hexOne.rgb - tex2D(_ScifiTex, inputUVs[0]).rgb);
    float4 hexOneOneMinus = 1.0 - hexOne;
    float4 hexTwo = tex2D(_ScifiTex, inputUVs[3]);
    hexTwo.rgb = saturate(hexTwo.rgb - tex2D(_ScifiTex, inputUVs[1]).rgb);
    inputColors = lerp(hexOne, hexTwo, hexOneOneMinus);
}

void scifiHoneycomb(inout float4 inputColors, float2 inputUVs) {
    // set up base uvs 
    float2 honeycombCutoff[2] = { inputUVs, inputUVs };
    honeycombCutoff[0] = frac(honeycombCutoff[0] * _ScifiTexAmount);
    honeycombCutoff[1] = frac(honeycombCutoff[1] * _ScifiTexAmount + 0.5);
    // zoom
    honeycombCutoff[0] = safeZoom(honeycombCutoff[0], _ScifiTexWidth * _ScifiTexCell);
    honeycombCutoff[1] = safeZoom(honeycombCutoff[1], _ScifiTexWidth * _ScifiTexCell);
    // now create the base pattern
    float2 honeycombBase[2] = { inputUVs, inputUVs };
    honeycombBase[0] = frac(honeycombBase[0] * _ScifiTexAmount);
    honeycombBase[1] = frac(honeycombBase[1] * _ScifiTexAmount + 0.5);
    // and zoom it
    honeycombBase[0] = safeZoom(honeycombBase[0], _ScifiTexCell);
    honeycombBase[1] = safeZoom(honeycombBase[1], _ScifiTexCell);
    // and now combine
    float4 hexOne = tex2D(_ScifiTex, honeycombBase[0]);
    hexOne.rgb = saturate(hexOne.rgb - tex2D(_ScifiTex, honeycombCutoff[0]).rgb);
    float4 hexOneOneMinus = 1.0 - hexOne;
    float4 hexTwo = tex2D(_ScifiTex, honeycombBase[1]);
    hexTwo.rgb = saturate(hexTwo.rgb - tex2D(_ScifiTex, honeycombCutoff[1]).rgb);
    inputColors = lerp(hexOne, hexTwo, hexOneOneMinus);
}

void scifiHoneycombInverse(inout float4 inputColors, float2 inputUVs)
{
    // set up base uvs
    float2 honeycombCutoff[2] = {
        inputUVs, inputUVs
    };
    honeycombCutoff[0] = frac(honeycombCutoff[0] * _ScifiTexAmount);
    honeycombCutoff[1] = frac(honeycombCutoff[1] * -_ScifiTexAmount + 0.5);
    // zoom
    honeycombCutoff[0] = safeZoom(honeycombCutoff[0], _ScifiTexWidth * _ScifiTexCell);
    honeycombCutoff[1] = safeZoom(honeycombCutoff[1], _ScifiTexWidth * _ScifiTexCell);
    // now create the base pattern
    float2 honeycombBase[2] = {
        inputUVs, inputUVs
    };
    honeycombBase[0] = frac(honeycombBase[0] * _ScifiTexAmount);
    honeycombBase[1] = frac(honeycombBase[1] * -_ScifiTexAmount + 0.5);
    // and zoom it
    honeycombBase[0] = safeZoom(honeycombBase[0], _ScifiTexCell);
    honeycombBase[1] = safeZoom(honeycombBase[1], _ScifiTexCell);
    // and now combine
    float4 hexOne = tex2D(_ScifiTex, honeycombBase[0]);
    hexOne.rgb = saturate(hexOne.rgb - tex2D(_ScifiTex, honeycombCutoff[0]).rgb);
    float4 hexOneOneMinus = 1.0 - hexOne;
    float4 hexTwo = tex2D(_ScifiTex, honeycombBase[1]);
    hexTwo.rgb = saturate(hexTwo.rgb - tex2D(_ScifiTex, honeycombCutoff[1]).rgb);
    inputColors = lerp(hexOne, hexTwo, hexOneOneMinus);
}

void scifiCardsUVs(inout float2 outputUVs[2], float2 inputUVs) {
    // set up base uvs (0=cutoff, 1=base)
    outputUVs[0] = inputUVs;
    outputUVs[1] = inputUVs;
    if (floor(inputUVs * _ScifiTexAmount).y % 2)
    {

        outputUVs[0].x += _ScifiTexOffset;
        outputUVs[1].x += _ScifiTexOffset;
    }
    outputUVs[0] = frac(outputUVs[0] * _ScifiTexAmount);
    outputUVs[0] = safeZoom(outputUVs[0], _ScifiTexWidth * _ScifiTexCell);
    outputUVs[1] = frac(outputUVs[1] * _ScifiTexAmount);
    outputUVs[1] = safeZoom(outputUVs[1], _ScifiTexCell);
}

void scifiCards(inout float4 inputColors, float2 inputUVs) {
    // set up base uvs (0=cutoff, 1=base)
    float2 cardUVs[2] = {
        inputUVs, inputUVs
    };
    if (floor(inputUVs * _ScifiTexAmount).y % 2)
    {

        cardUVs[0].x += _ScifiTexOffset;
        cardUVs[1].x += _ScifiTexOffset;
    }
    cardUVs[0] = frac(cardUVs[0] * _ScifiTexAmount);
    cardUVs[0] = safeZoom(cardUVs[0], _ScifiTexWidth * _ScifiTexCell);
    cardUVs[1] = frac(cardUVs[1] * _ScifiTexAmount);
    cardUVs[1] = safeZoom(cardUVs[1], _ScifiTexCell);
    // combine
    float4 cardOne = tex2D(_ScifiTex, cardUVs[1]);
    cardOne.rgb = saturate(cardOne.rgb - tex2D(_ScifiTex, cardUVs[0]).rgb);
    inputColors = cardOne;
}

void scifiCardsUVsInverse(inout float2 outputUVs[2], float2 inputUVs)
{
    // set up base uvs (0=cutoff, 1=base)
    outputUVs[0] = inputUVs;
    outputUVs[1] = inputUVs;
    if (floor(inputUVs * _ScifiTexAmount).y % 2)
    {
        outputUVs[0] *= -1.0;
        outputUVs[1] *= -1.0;
        outputUVs[0].x += _ScifiTexOffset;
        outputUVs[1].x += _ScifiTexOffset;
    }
    outputUVs[0] = frac(outputUVs[0] * _ScifiTexAmount);
    outputUVs[0] = safeZoom(outputUVs[0], _ScifiTexWidth * _ScifiTexCell);
    outputUVs[1] = frac(outputUVs[1] * _ScifiTexAmount);
    outputUVs[1] = safeZoom(outputUVs[1], _ScifiTexCell);
}

void scifiCardsInverse(inout float4 inputColors, float2 inputUVs)
{
    // set up base uvs (0=cutoff, 1=base)
    float2 cardUVs[2] = {
        inputUVs, inputUVs
    };
    if (floor(inputUVs * _ScifiTexAmount).y % 2)
    {
        cardUVs[0] *= -1.0;
        cardUVs[1] *= -1.0;
        cardUVs[0].x += _ScifiTexOffset;
        cardUVs[1].x += _ScifiTexOffset;
    }
    cardUVs[0] = frac(cardUVs[0] * _ScifiTexAmount);
    cardUVs[0] = safeZoom(cardUVs[0], _ScifiTexWidth * _ScifiTexCell);
    cardUVs[1] = frac(cardUVs[1] * _ScifiTexAmount);
    cardUVs[1] = safeZoom(cardUVs[1], _ScifiTexCell);
    // combine
    float4 cardOne = tex2D(_ScifiTex, cardUVs[1]);
    cardOne.rgb = saturate(cardOne.rgb - tex2D(_ScifiTex, cardUVs[0]).rgb);
    inputColors = cardOne;
}




// uv functions

// if uv 
void initProjUV(inout float2 inputUVs) {
    // scaling and moving
    inputUVs.x *= _ScifiUVScaleX;
    inputUVs.y *= _ScifiUVScaleY;
    inputUVs.x += _ScifiUVOffsetX;
    inputUVs.y += _ScifiUVOffsetY;
    // rotating
    [branch] if (_ScifiUVRotate != 0) {
        [branch] if (_ScifiUVRotateSpeed != 0) {
            _ScifiUVRotate += _Time.y * _ScifiUVRotateSpeed;
        }
        inputUVs = rotateUV(inputUVs, float2(0.5, 0.5), _ScifiUVRotate);
    }
    // scroll
    [branch] if (_ScifiUVScroll != 0) {
        inputUVs.x += frac(_Time.y * _ScifiUVScrollX);
        inputUVs.y += frac(_Time.y * _ScifiUVScrollY);
    }
}

// if triplanar
void outProjTriplanarUVs(inout float2 outUVs[3], inout float3 outBlend,
    float3 inputNormals, float3 inputWorld) {
    // just the uvs!
    float3 worldPosScaled = (inputWorld) * float3(_ScifiTPScaleX, _ScifiTPScaleY, _ScifiTPScaleZ);
    outBlend = normalize(inputNormals) * normalize(inputNormals);
    outBlend /= (outBlend.x + outBlend.y + outBlend.z);
    float2 triplanarUV[3];
    outUVs[0] = worldPosScaled.zy;
    outUVs[1] = worldPosScaled.xz;
    outUVs[2] = worldPosScaled.xy;
}

void outProjTriplanarColor(inout float4 inputColor, 
    float2 inputUVs[3], float3 inputBlend) {
    // just the color!
    inputColor = inputBlend.x * tex2D(_ScifiTex, inputUVs[0]) +
        inputBlend.y * tex2D(_ScifiTex, inputUVs[1]) +
        inputBlend.z * tex2D(_ScifiTex, inputUVs[2]);
}

void outProjTriplanarWitcherUVs(inout float3 outUVs, inout float3 blend,
    float3 inputNormals, float3 inputWorld) {
        // just the uvs, adapted from witcher technique
        float3 worldPosScaled = (inputWorld) * float3(_ScifiTPScaleX, _ScifiTPScaleY, _ScifiTPScaleZ);
        [branch] if (_ScifiTPPan == 1) {
            worldPosScaled.x += frac(_Time.y * _ScifiTPPanX);
            worldPosScaled.y += frac(_Time.y * _ScifiTPPanY);
            worldPosScaled.z += frac(_Time.y * _ScifiTPPanZ);
        }
        float3 toBlend = pow(abs(inputNormals), 3.0);
        toBlend /= dot(toBlend, 1.0);
        float3 triplanarWeights = float3(0.0, 0.0, 0.0);
        if (toBlend.x >= _ScifiTPThreshold)
        {
            triplanarWeights.x = toBlend.x;
        }
        if (toBlend.y >= _ScifiTPThreshold)
        {
            triplanarWeights.y = toBlend.y;
        }
        if (toBlend.z >= _ScifiTPThreshold)
        {
            triplanarWeights.z = toBlend.z;
        }
        triplanarWeights /= (triplanarWeights.x + triplanarWeights.y + triplanarWeights.z);
        outUVs = worldPosScaled;
        blend = triplanarWeights;
}

void outProjTriplanarWitcherColors(inout float4 inputColor, 
    float3 inputUVs, float3 inputBlend) {
    // just the color, adapted from witcher technique
    float4 toReturnTriplanar = float4(0.0, 0.0, 0.0, 1.0);
    if (inputBlend.x > 0)
    {
        toReturnTriplanar.rgb += inputBlend.x * tex2D(_ScifiTex, inputUVs.zy);
    }
    if (inputBlend.y > 0)
    {
        toReturnTriplanar.rgb += inputBlend.y * tex2D(_ScifiTex, inputUVs.xz);
    }
    if (inputBlend.z > 0)
    {
        toReturnTriplanar.rgb += inputBlend.z * tex2D(_ScifiTex, inputUVs.xy);
    }
    inputColor = toReturnTriplanar;
}

void outProjTriplanar(inout float4 inputColors, float3 inputNormals,
    float3 inputWorld) {
    // im so tired..
    float3 worldPosScaled = (inputWorld) * float3(_ScifiTPScaleX, _ScifiTPScaleY, _ScifiTPScaleZ);
    float3 toBlend = normalize(inputNormals) * normalize(inputNormals);
    toBlend /= (toBlend.x + toBlend.y + toBlend.z);
    float2 triplanarUV[3];
    triplanarUV[0] = worldPosScaled.zy;
    triplanarUV[1] = worldPosScaled.xz;
    triplanarUV[2] = worldPosScaled.xy;
    float4 toReturnTriplanar = toBlend.x * tex2D(_ScifiTex, triplanarUV[0]) +
    toBlend.y * tex2D(_ScifiTex, triplanarUV[1]) +
    toBlend.z * tex2D(_ScifiTex, triplanarUV[2]);
    inputColors = toReturnTriplanar;
}

void outProjTriplanarWitcher(inout float4 inputColors, float3 inputNormals,
    float3 inputWorld) {
    // adapted from witcher technique
    float3 worldPosScaled = (inputWorld) * float3(_ScifiTPScaleX, _ScifiTPScaleY, _ScifiTPScaleZ);
    float3 toBlend = pow(abs(inputNormals), 3.0);
    toBlend /= dot(toBlend, 1.0);
    float3 triplanarWeights = float3(0.0, 0.0, 0.0);
    float4 toReturnTriplanar = float4(0.0, 0.0, 0.0, 1.0);
    if (toBlend.x >= _ScifiTPThreshold) {
        triplanarWeights.x = toBlend.x;
    }
    if (toBlend.y >= _ScifiTPThreshold) {
        triplanarWeights.y = toBlend.y;
    }
    if (toBlend.z >= _ScifiTPThreshold) {
        triplanarWeights.z = toBlend.z;
    }
    triplanarWeights /= (triplanarWeights.x + triplanarWeights.y + triplanarWeights.z);
    if (triplanarWeights.x > 0) {
        toReturnTriplanar.rgb += triplanarWeights.x * tex2D(_ScifiTex, worldPosScaled.zy);
    }
    if (triplanarWeights.y > 0) {
        toReturnTriplanar.rgb += triplanarWeights.y * tex2D(_ScifiTex, worldPosScaled.xz);
    }
    if (triplanarWeights.z > 0) {
        toReturnTriplanar.rgb += triplanarWeights.z * tex2D(_ScifiTex, worldPosScaled.xy);
    }
    inputColors = toReturnTriplanar;
}







// new space
// wave functions here!
float waveCircles(float2 inputUVs) {
    float ringRadius = frac(_Time.y * _ScifiWavesSpeed);
    float ringThickness = _ScifiWavesSize;
    [branch] if (_ScifiWavesPixelation != 0) {
        float pixelateValue = lerp(100, 1, _ScifiWavesPixelation);
        doPixelateFloat(inputUVs, pixelateValue, pixelateValue);
    }
    float pxDist = distance(inputUVs, float2(0.5, 0.5));
    pxDist = frac(pxDist * _ScifiWaveNoiseScale);
    float innerColor = smoothstep(ringRadius, ringRadius - ringThickness, pxDist);
    float outColor = smoothstep(ringRadius, ringRadius + ringThickness, pxDist);
    return saturate((1.0 - (outColor + innerColor)));
}

float waveNoiseyWaves(float2 inputUVs) {
    [branch] if (_ScifiWavesPixelation != 0) {
        float pixelateValue = lerp(100, 1, _ScifiWavesPixelation);
        doPixelateFloat(inputUVs, pixelateValue, pixelateValue);
    }
    [branch] if (_ScifiWavesRotation != 0) {
        [branch] if (_ScifiWavesRotationSpeed != 0) {
            _ScifiWavesRotation += _Time.y * _ScifiWavesRotationSpeed;
        }
        inputUVs = rotateUV(inputUVs, float2(0.5, 0.5), _ScifiWavesRotation);
    }
    doDistortFancy(inputUVs, float2(1, 1), float2(_ScifiWavesSpeed, _ScifiWavesSpeed));
    return saturate(makeNoiseSimple(inputUVs, _ScifiWaveNoiseScale) + _ScifiWavesSize);
}

float waveOoze(float2 inputUVs) {
    [branch] if (_ScifiWavesPixelation != 0)
    {
        float pixelateValue = lerp(100, 1, _ScifiWavesPixelation);
        doPixelateFloat(inputUVs, pixelateValue, pixelateValue);
    }
    [branch] if (_ScifiWavesRotation != 0) {
        [branch] if (_ScifiWavesRotationSpeed != 0) {
            _ScifiWavesRotation += _Time.y * _ScifiWavesRotationSpeed;
        }
        inputUVs = rotateUV(inputUVs, float2(0.5, 0.5), _ScifiWavesRotation);
    }
    doDistortFancy(inputUVs, float2(1, 1), float2(1, 1));
    return makeNoiseSimple(inputUVs + float2(0, _Time.y * _ScifiWavesSpeed), _ScifiWaveNoiseScale / 2) + (_ScifiWavesSize * 0.1);
}

float waveBubbles(float2 inputUVs)
{
    [branch] if (_ScifiWavesPixelation != 0)
    {
        float pixelateValue = lerp(100, 1, _ScifiWavesPixelation);
        doPixelateFloat(inputUVs, pixelateValue, pixelateValue);
    }
    [branch] if (_ScifiWavesRotation != 0) {
        [branch] if (_ScifiWavesRotationSpeed != 0) {
            _ScifiWavesRotation += _Time.y * _ScifiWavesRotationSpeed;
        }
        inputUVs = rotateUV(inputUVs, float2(0.5, 0.5), _ScifiWavesRotation);
    }
    // ok well mathematical approach did not work so lets do naive
    doDistortFancy(inputUVs, _ScifiWaveNoiseScale, 1);
    float noiseVal = makeNoiseSimple(inputUVs, 5 + _ScifiWaveNoiseScale);
    return saturate(noiseVal + _ScifiWavesSize);
}

float waveSwirls(float2 inputUVs)
{
    [branch] if (_ScifiWavesPixelation != 0)
    {
        float pixelateValue = lerp(100, 1, _ScifiWavesPixelation);
        doPixelateFloat(inputUVs, pixelateValue, pixelateValue);
    }
    [branch] if (_ScifiWavesRotation != 0) {
        [branch] if (_ScifiWavesRotationSpeed != 0) {
            _ScifiWavesRotation += _Time.y * _ScifiWavesRotationSpeed;
        }
        inputUVs = rotateUV(inputUVs, float2(0.5, 0.5), _ScifiWavesRotation);
    }
    return saturate(_ScifiWavesSize + makeShapeSpiralAtan2(inputUVs, _ScifiWaveNoiseScale, _ScifiWavesSpeed));
}

float waveScanline(float2 inputUVs) {
    [branch] if (_ScifiWavesPixelation != 0)
    {
        float pixelateValue = lerp(100, 1, _ScifiWavesPixelation);
        doPixelateFloat(inputUVs, pixelateValue, pixelateValue);
    }
    [branch] if (_ScifiWavesRotation != 0)
    {
        [branch] if (_ScifiWavesRotationSpeed != 0)
        {
            _ScifiWavesRotation += _Time.y * _ScifiWavesRotationSpeed;
        }
        inputUVs = rotateUV(inputUVs, float2(0.5, 0.5), _ScifiWavesRotation);
    }
    return makeScanline(0, _ScifiWavesSize, _ScifiWavesSpeed, _ScifiWaveNoiseScale, 0, inputUVs);
}

// fucking triplanar
void ftTriplanar(inout float inputWave[3], float2 inputUVs[3], 
    float inputIndex) {
    #if defined(_KEYWORD_WAVE_NOISEY_WAVES)
        inputWave[inputIndex] = waveNoiseyWaves(inputUVs[inputIndex]);
    #elif defined(_KEYWORD_WAVE_OOZE)
        inputWave[inputIndex] = waveOoze(inputUVs[inputIndex]);
    #elif defined(_KEYWORD_WAVE_BUBBLES)
        inputWave[inputIndex] = waveBubbles(inputUVs[inputIndex]);
    #elif defined(_KEYWORD_WAVE_SWIRLS)
        inputWave[inputIndex] = waveSwirls(inputUVs[inputIndex]);
    #elif defined(_KEYWORD_WAVE_SCANLINE)
        inputWave[inputIndex] = waveScanline(inputUVs[inputIndex]);
    #else
        inputWave[inputIndex] = waveCircles(inputUVs[inputIndex]);
    #endif
}

void ftTriplanarColor(inout float4 inputColor,
    float2 inputUVs[3], float3 inputBlend,
    float inputWaves[3]) {
    float storeWaveWidth = _ScifiTexWidth;
    float storeWaveOpacity = _ScifiOpacity;
    if (inputBlend.x > 0)
    {
        #ifdef _KEYWORD_USE_SCIFI_WIDTH
            _ScifiTexWidth *= _ScifiWavesWidthLower + inputWaves[0] * _ScifiWavesWidthHigher;
        #endif
        #ifdef _KEYWORD_USE_SCIFI_OPACITY
            _ScifiOpacity *= _ScifiWavesOpacityLower + inputWaves[0] * _ScifiWavesOpacityHigher;
        #endif
        float4 xColor = float4(0, 0, 0, 1);
        #if defined(_KEYWORD_PATTERN_HONEYCOMB)
            scifiHoneycomb(xColor, inputUVs[0]);
        #elif defined(_KEYWORD_PATTERN_INVERSE_HONEYCOMB)
            scifiHoneycombInverse(xColor, inputUVs[0]);
        #elif defined(_KEYWORD_PATTERN_CARDS)
            scifiCards(xColor, inputUVs[0]);
        #elif defined(_KEYWORD_PATTERN_INVERSE_CARDS)
            scifiCardsInverse(xColor, inputUVs[0]);
        #endif
        inputColor.rgb += inputBlend.x * xColor.rgb;
    }
    _ScifiTexWidth = storeWaveWidth;
    if (inputBlend.y > 0)
    {
        #ifdef _KEYWORD_USE_SCIFI_WIDTH
            _ScifiTexWidth *= _ScifiWavesWidthLower + inputWaves[1] * _ScifiWavesWidthHigher;
        #endif
        #ifdef _KEYWORD_USE_SCIFI_OPACITY
            _ScifiOpacity *= _ScifiWavesOpacityLower + inputWaves[1] * _ScifiWavesOpacityHigher;
        #endif
        float4 yColor = float4(0, 0, 0, 1);
        #if defined(_KEYWORD_PATTERN_HONEYCOMB)
            scifiHoneycomb(yColor, inputUVs[1]);
        #elif defined(_KEYWORD_PATTERN_INVERSE_HONEYCOMB)
            scifiHoneycombInverse(yColor, inputUVs[1]);
        #elif defined(_KEYWORD_PATTERN_CARDS)
            scifiCards(yColor, inputUVs[1]);
        #elif defined(_KEYWORD_PATTERN_INVERSE_CARDS)
            scifiCardsInverse(yColor, inputUVs[1]);
        #endif
        inputColor.rgb += inputBlend.y * yColor.rgb;
    }
    _ScifiTexWidth = storeWaveWidth;
    if (inputBlend.z > 0)
    {
        #ifdef _KEYWORD_USE_SCIFI_WIDTH
            _ScifiTexWidth *= _ScifiWavesWidthLower + inputWaves[2] * _ScifiWavesWidthHigher;
        #endif
        #ifdef _KEYWORD_USE_SCIFI_OPACITY
            _ScifiOpacity *= _ScifiWavesOpacityLower + inputWaves[2] * _ScifiWavesOpacityHigher;
        #endif
        float4 zColor = float4(0, 0, 0, 1);
        #if defined(_KEYWORD_PATTERN_HONEYCOMB)
            scifiHoneycomb(zColor, inputUVs[2]);
        #elif defined(_KEYWORD_PATTERN_INVERSE_HONEYCOMB)
            scifiHoneycombInverse(zColor, inputUVs[2]);
        #elif defined(_KEYWORD_PATTERN_CARDS)
            scifiCards(zColor, inputUVs[2]);
        #elif defined(_KEYWORD_PATTERN_INVERSE_CARDS)
            scifiCardsInverse(zColor, inputUVs[2]);
        #endif
        inputColor.rgb += inputBlend.z * zColor.rgb;
    }
}



#endif