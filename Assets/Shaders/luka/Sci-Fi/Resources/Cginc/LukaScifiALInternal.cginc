#ifndef LUKA_SCIFI_AL_INTERNAL
#define LUKA_SCIFI_AL_INTERNAL

void doAudioLink(inout float audiolink) {
    float audioLinkValues[2] = {
        0, 0
    };
    // power, raw value, cache to work with (removed for now)
    [forcecase] switch(_ALStyle)
    {
        case 0: // simple (?) lerped to be smoother
        audioLinkValues[1] = AudioLinkLerp(ALPASS_AUTOCORRELATOR + float2(_ALSensitivity * AUDIOLINK_WIDTH, 0.)).x;
        break;
        case 1: // raw (?) jagged
        audioLinkValues[1] = AudioLinkData(ALPASS_AUDIOLINK + float2(_ALSensitivity * AUDIOLINK_WIDTH, 0.)).x;
        break;
        case 2: // amplitude at frequency
        audioLinkValues[1] = AudioLinkGetAmplitudeAtFrequency(_ALTOne).x;
        break;
        case 3: // amplitude at note
        audioLinkValues[1] = AudioLinkGetAmplitudeAtNote(_ALTOne, _ALTTwo).x;
        break;
        default: // end
        break;
    }
    audioLinkValues[0] *= _ALSensitivity;
    audiolink *= lerp(audiolink, audioLinkValues[0] * audiolink, _ALPower);
}

#endif 