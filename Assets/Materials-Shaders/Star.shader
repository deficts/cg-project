Shader "Custom/Estrella"
{
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

   struct appdata
   {
    float4 vertex : POSITION;
    float2 uv : TEXCOORD0;
   };

   struct v2f
   {
    float2 uv : TEXCOORD0;
    float4 vertex : SV_POSITION;
   };

   
   v2f vert (appdata v)
   {
    v2f o;
    o.vertex = UnityObjectToClipPos(v.vertex);
    o.uv = v.uv;
    return o;
   }
   
   fixed4 frag (v2f i) : SV_Target
   {
    
    fixed2 p = -1.0f + 2.0f * i.uv.xy; 
    fixed x = p.x;
    fixed y = p.y;
    fixed mov0 = x+y+cos(sin(_Time.y)*2.0)*100.+sin(x/100.)*1000.;
    fixed mov1 = y / 0.9 +  _Time.y;
    fixed mov2 = x / 0.2;
    fixed c1 = abs(sin(mov1+_Time.y)/2.+mov2/2.-mov1-mov2+_Time.y);
    fixed c2 = abs(sin(c1+sin(mov0/1000.+_Time.y)+sin(y/40.+_Time.y)+sin((x+y)/100.)*3.));
    fixed c3 = abs(sin(c2+cos(mov1+mov2+c2)+cos(mov2)+sin(x/1000.)));
    return fixed4(1-c1,1-c2,1-c3,1);
   }
   ENDCG
  }
 }
}