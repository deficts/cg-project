Shader "Custom/Alterations"
{
    Properties
    {
        _Ambientecito ("Color ambiente", Color) = (1,1,1,1)
        _Difusito("Color difuso",Color) = (1,0,0,1)
        _Especularcito("Color especular", Color) = (1,1,1,1)
        _Brillito("Coeficiente de brillo", Float) = 10
        
    }
    SubShader
    {
        pass{
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            uniform float4 _Ambientecito;

            struct vInput {
                float4 pos : POSITION;

                float3 normal : NORMAL;
            };


            float4 vert(vInput input) : SV_POSITION {
                            float4 result = UnityObjectToClipPos(input.pos);
                float3 normal = normalize(UnityObjectToClipPos(input.normal));
                float val=sin(_Time.x*5);
                
                    return float4(result.x,result.y,result.z*(input.normal.x-input.normal.y)*val*5,result.w);
                   
                    //return float4 (result.x+normal.x*val*val, 
                    //result.y +(1-(normal.x-normal.z)*val), result.z+normal.z*val*val, result.w);
                
                
                    return float4(result.x,result.y,result.z*(input.normal.x-input.normal.y)*val*5,result.w);
                
                    //return float4(result.x, 
                   // result.y+normal.y*(-val) , result.z, result.w);
                
                
                

            }

            float4 frag() : COLOR {
                return _Ambientecito;
            }

            ENDCG
        }
    }
    FallBack "Diffuse"
}
