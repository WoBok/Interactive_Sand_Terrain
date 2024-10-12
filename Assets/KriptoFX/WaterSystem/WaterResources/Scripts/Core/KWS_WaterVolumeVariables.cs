using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace KWS
{
    internal class KWS_WaterVolumeVariables
    {
#if KWS_DEBUG
        [GenerateHLSL(PackingRules.Exact, needAccessors : false,  sourcePath = @"Assets\KriptoFX\WaterSystem\WaterResources\Shaders\Resources\Common\KWS_WaterVolumeVariables")]
#endif
        internal struct WaterVolumeData
        {
            public Vector3   Position;
            public float     WaterLevel;

            public Matrix4x4 Rotation;

            public Vector3   Size;
            public uint      InstanceID;

            public float Transparent;
            public Color WaterColor;
            public Color TurbidityColor;
            public float Turbidity;

            public float VolumetricLightDirLightIntensityMultiplier;
            public float VolumetricLightAdditionalLightsIntensityMultiplier;
            public float VolumetricLightOverWaterCausticStrength;
            public float VolumetricLightUnderWaterCausticStrength;
            
        }

    }
}