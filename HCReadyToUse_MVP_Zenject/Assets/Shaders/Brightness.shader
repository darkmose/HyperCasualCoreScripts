Shader "Custom/ColorAdjustEffect"
{
    Properties
    {
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _Brightness ("Brightness", Float) = 1 
        _Saturation ("Saturation", Float) = 1 
        _Contrast ("Contast", Float) = 1 
    	_ShadowReceiveIntensity ("Shadow Receive Intensity", Float) = .15
    }
 
        SubShader
        {
            Pass 
            {
			    Lighting Off
			    SetTexture [_MainTex] { combine texture } 
		    }
           
            Pass
            {

                Blend SrcAlpha OneMinusSrcAlpha
                CGPROGRAM
                
     
                            
                #pragma vertex vert
                #pragma fragment frag
                #include "Lighting.cginc"
     
     
                struct appdata_t
                {
                    float4 vertex : POSITION;
                    half4 color : COLOR;
                    float2 uv : TEXCOORD0;
                };
                
                struct v2f
                {
                    float4 pos: SV_POSITION; 
                    float2 uv: TEXCOORD0; 
                    half4 color : COLOR;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                half _Brightness;
                half _Saturation;
                half _Contrast;
                
     
                v2f vert(appdata_t v)
                {
                    v2f o;
                   
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.color = v.color;
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);;
                    
                    return o;
                }
     
     
                fixed4 frag(v2f i) : COLOR
                {
                            
                    fixed4 renderTex = tex2D(_MainTex, i.uv)*i.color;
                    fixed3 finalColor = renderTex * _Brightness;
                    fixed gray = 0.2125 * renderTex.r + 0.7154 * renderTex.g + 0.0721 * renderTex.b;
                    fixed3 grayColor = fixed3(gray, gray, gray);
                    finalColor = lerp(grayColor, finalColor, _Saturation);
                    fixed3 avgColor = fixed3(0.5, 0.5, 0.5);
                    finalColor = lerp(avgColor, finalColor, _Contrast);
                    return fixed4(finalColor, renderTex.a);
                }
                ENDCG
                
            }

        	
            Pass 
			{
				Name "ShadowCaster"
				Tags { "LightMode" = "ShadowCaster" }
				
				Fog {Mode Off}
				ZWrite On ZTest LEqual Cull Off
				Offset 1, 1
		
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile_shadowcaster
				#pragma fragmentoption ARB_precision_hint_fastest
				#include "UnityCG.cginc"
		
				struct v2f { 
					V2F_SHADOW_CASTER;
				};
		
				v2f vert( appdata_base v )
				{
					v2f o;
					TRANSFER_SHADOW_CASTER(o)
					return o;
				}
		
				float4 frag( v2f i ) : COLOR
				{
					SHADOW_CASTER_FRAGMENT(i)
				}
				ENDCG
			}
        	
        	Pass
        	{
        		Blend One One
        		Tags { "LightMode" = "ForwardBase" }
        		
        		CGPROGRAM
        		
        		#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"
				#pragma multi_compile_fwdbase
				#include "AutoLight.cginc"

        		float _ShadowReceiveIntensity;
        		
        		struct v2f
        		{
					float4 pos : SV_POSITION; LIGHTING_COORDS(0,1)
        		};
				v2f vert(appdata_base v)
        		{
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);
					TRANSFER_VERTEX_TO_FRAGMENT(o);
					return o;
        		}
				fixed4 frag(v2f i) : COLOR
        		{
					float attenuation = LIGHT_ATTENUATION(i);
					return attenuation * _ShadowReceiveIntensity;
				} 
        		ENDCG 
            }
        }
}


    

