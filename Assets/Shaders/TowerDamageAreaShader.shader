Shader "Custom/TransparentSingleColorShader" {
  Properties {
    _Color ("Color", Color) = (1.0, 1.0, 1.0, 0.05)
  }
  SubShader {
    Tags { "RenderType" = "Transparent" "IgnoreProjector"="True"  "Queue" = "Transparent" }
    Blend SrcAlpha OneMinusSrcAlpha
    ZWrite On
    LOD 100
 
    Pass{
    	Lighting Off
    	Color [_Color]
    }
  }
  //FallBack "Diffuse"
}