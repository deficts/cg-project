Shader "ClaseCG/Coin"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Box("Skybox", Cube) = ""
    }
        SubShader
    {
        Pass {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            uniform samplerCUBE _Box;
            uniform fixed4 _Color;
            
            struct vInput {

                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct vOutput {

                float4 pos : SV_POSITION;
                float3 vNormal : TEXCOORD0;
                float3 vVista : TEXCOORD1;
            };

            vOutput vert(vInput input) {
            
                vOutput resultado;

                resultado.vNormal = normalize(
                    mul(
                        float4(input.normal, 0.0), 
                        unity_WorldToObject).xyz
                    );
                resultado.vVista = mul(unity_ObjectToWorld, input.vertex).xyz
                    - _WorldSpaceCameraPos;
                resultado.pos = UnityObjectToClipPos(input.vertex);
                return resultado;
            }

            float4 frag(vOutput input) : COLOR{

                float3 direccionReflejo =
                    reflect(input.vVista, input.vNormal);
                return texCUBE(_Box, direccionReflejo) * _Color;
            }

            ENDCG
        }
    }
    FallBack "Diffuse"
}
