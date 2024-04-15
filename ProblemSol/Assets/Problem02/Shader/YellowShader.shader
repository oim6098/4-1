Shader "Unlit/YellowShader"
{
    Properties
    {
        _DiffuseColor("DiffuseColor", Color) = (1,0,0,1) // 빨간색으로 변경
        _LightDirection("LightDirection", Vector) = (1,-1,-1,0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
           
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
            };

            float4 _DiffuseColor;
            float4 _LightDirection;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = v.normal;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float3 lightDir = normalize(_LightDirection.xyz);
                float lightIntensity = max(dot(i.normal, lightDir), 0);

                // 카툰 쉐이딩 효과 추가
                if (lightIntensity > 0.5)
                {
                    lightIntensity = 1.0; // 밝은 부분
                }
                else
                {
                    lightIntensity = 0.5; // 어두운 부분
                }

                float4 col = _DiffuseColor * lightIntensity;

                return col;
            }
            ENDCG
        }
    }
}
