Shader "Custom/InvertedCircle"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Center ("Circle Center", Vector) = (0.5, 0.5, 0, 0)
        _Radius ("Circle Radius", Float) = 0.0
        _IsInverted ("Is Inverted", Float) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float2 _Center;
            float _Radius;
            float _IsInverted;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float2 center = float2(_Center.x, _Center.y);
                float dist = distance(uv, center);

                
                
                if(_IsInverted > 0.5){//kuro -> shiro
                   if (dist < _Radius)
                    {
                        half4 color = tex2D(_MainTex, uv);
                        color.rgb = 1.0 - color.rgb;
                        return color;
                    }
                    else
                    {
                        return tex2D(_MainTex, uv);
                    }
                }
                else{//shiro -> kuro
                   if (dist < _Radius)
                    {
                        return tex2D(_MainTex, uv);
                    }
                    else
                    {
                        half4 color = tex2D(_MainTex, uv);
                        color.rgb = 1.0 - color.rgb;
                        return color;
                    }

                 }

/*
                if (dist < _Radius && _IsInverted > 0.5)
                {
                    half4 color = tex2D(_MainTex, uv);
                    color.rgb = 1.0 - color.rgb;
                    return color;
                }
                else
                {
                    return tex2D(_MainTex, uv);
                }
*/
            }
            ENDCG
        }
    }
}