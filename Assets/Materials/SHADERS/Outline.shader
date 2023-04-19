Shader "Custom/Outline" {
    Properties {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _OutlineWidth ("Outline Width", Range(0, 0.1)) = 0.005
    }

    CGINCLUDE
    #include "UnityCG.cginc"

    struct appdata {
        float4 vertex : POSITION;
        float2 uv : TEXCOORD0;
    };

    struct v2f {
        float2 uv : TEXCOORD0;
        float4 vertex : SV_POSITION;
    };

    sampler2D _MainTex;
    float _OutlineWidth;
    float4 _OutlineColor;

    v2f vert(appdata v) {
        v2f o;
        o.vertex = UnityObjectToClipPos(v.vertex);
        o.uv = v.uv;
        return o;
    }

    fixed4 frag(v2f i) : SV_Target {
        float2 uv = i.uv;

        // Outline effect
        float alpha = tex2D(_MainTex, uv).a;
        float outline = 1 - tex2D(_MainTex, uv + float2(_OutlineWidth, 0)).a;
        outline += 1 - tex2D(_MainTex, uv + float2(-_OutlineWidth, 0)).a;
        outline += 1 - tex2D(_MainTex, uv + float2(0, _OutlineWidth)).a;
        outline += 1 - tex2D(_MainTex, uv + float2(0, -_OutlineWidth)).a;

        // Outline color
        fixed4 col = _OutlineColor;
        col.a = min(outline, 1) * alpha;
        return col;
    }
    ENDCG

    SubShader {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        LOD 100
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #include "UnityCG.cginc"
        ENDCG
    }
    FallBack "Diffuse"
}
