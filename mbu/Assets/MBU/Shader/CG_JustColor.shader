//========= 2020 - Copyright Manfred Brill. All rights reserved. ===========

// Cg Shader, der einfach eine Farbe verwendet
Shader "_Shaders/CG/JustColor" 
{
	Properties 
	{
		 _MyColor("Tint Color", Color) = (1.0, 0.0, 0.0, 1.0)
	}
	
	SubShader 
	{
		Tags { "Queue" = "Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		
		Pass
		{
			CGPROGRAM
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			fixed4 _MyColor;
			
			// Datenstruktur für einen Eckpunkt, der von Unity übergeben wird
			struct vertexInput
			{
				float4 vertex : POSITION; // position in object coords.
			};

			// Übergabe von vertex an fragment shader
			struct fragmentInput
			{
				float4 pos : SV_POSITION;
				fixed4  color : COLOR0;
			};

			// Vertex Shader
			fragmentInput vert( vertexInput i )
			{
				fragmentInput o;
				o.pos = UnityObjectToClipPos( i.vertex);
				o.color = _MyColor;
				return o;
			}

			// Fragment Shader
			half4 frag( fragmentInput i ) : COLOR
			{
				return i.color;
			}
			ENDCG
		}	//END Pass
		
	} 	// END SubShader
	FallBack "Diffuse"
}
