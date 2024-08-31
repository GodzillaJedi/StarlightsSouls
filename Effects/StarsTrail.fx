matrix transformMatrix;
texture sampleTexture;
texture gradientTexture;
float2 worldSize;
float uTime;
float uExchange;

sampler2D samplerTex = sampler_state
{
    texture = <sampleTexture>;
    magfilter = LINEAR;
    minfilter = LINEAR;
    mipfilter = LINEAR;
    AddressU = wrap;
    AddressV = wrap;
};

sampler2D gradientTex = sampler_state
{
    texture = <gradientTexture>;
    magfilter = LINEAR;
    minfilter = LINEAR;
    mipfilter = LINEAR;
    AddressU = wrap;
    AddressV = wrap;
};

struct VertexShaderInput
{
    float4 Position : SV_POSITION;
    float2 TexCoords : TEXCOORD0;
    float4 Color : COLOR0;
};

struct VertexShaderOutput
{
    float4 Position : SV_POSITION;
    float2 TexCoords : TEXCOORD0;
    //float4 NewPosition : POSITION1;
    float4 Color : COLOR0;
};

VertexShaderOutput VertexShaderFunction(VertexShaderInput input)
{
    VertexShaderOutput output;
    
    output.Color = input.Color;
    output.TexCoords = input.TexCoords;
    output.Position = mul(input.Position, transformMatrix);
    //output.Position = output.NewPosition;
    return output;
}

#define rot(a) float2x2(cos(a),-sin(a),sin(a),cos(a))

float3 mod(float3 x, float y)
{
    return x - y * floor(x / y);
}

float4 PixelShaderFunction(VertexShaderOutput input) : COLOR0
{
    float2 coords = input.TexCoords;

    float4 tc = tex2D(samplerTex, coords);
    
    float4 color2 = tex2D(gradientTex, float2(input.TexCoords.y, 0)).xyzw;
    float3 bright = tc.xyz /** (1.0 + color.x * 2.0)*/ * color2.xyz;

    if (tc.r < uExchange)
    {
        return float4(bright, input.Color.w * tc.r);
    }
    
    
    float4 O = float4(0, 0, 0, 0);
    O -= O;
    float t = uTime * .01 + .25, s = .6, f = 2, a, l;

    float2 R = worldSize; /*float2(800, 450);*/ 
    float3 p,
	      D = float3((input.Position.xy - .5 * R.xy) / R.x * .4, .5),
          //M = 2. * iMouse.xyz / R,
          o = float3(1, .5, .5) + float3(t + t, t, -2);
    //O -= O;
    D.xy /= 3.0;
    float2x2 r1 = rot(.5+1.0/*M.x*/),
	     r2 = rot(.8+1.0/*M.y*/);
    D.xz = mul(D.xz, r1);
    o.xz = mul(o.xz, r1);
    D.xy = mul(D.xy, r2);
    o.xy = mul(o.xy, r2);
    //D.xz *= r1;
    //o.xz *= r1;
    //D.xy *= r2;
    //o.xy *= r2;
	
    for (int i, r = 0; r++ < 4; f *= .93, s += .1)
    {
        p = abs(mod(o + s * D, 1.7) - .85);
        a = t = 0.;
        for (i = 0; i++ < 15; t = l)
            l = length(p = abs(p) / dot(p, p) - .53),
			a += abs(l - t);

        a *= a * a;
        r > 7 ? f *= min(1., .7 + a * a * .001) : f;
        O.rgb += float3(f, f, f) + s * float3(0.3, 0, s * s * s) * a * .0015 * f;
    }
	
    float y = .0015 * length(O);
    O = .0085 * O + float4(y, y, y, y);
    O = float4(lerp(bright, O.xyz, clamp(((tc.r - uExchange) / 0.05f), 0, 1)), O.a);
    
    return float4(O.xyz, input.Color.a);
}

technique Technique1
{
    pass StarsTrailPass
    {
        VertexShader = compile vs_3_0 VertexShaderFunction();
        PixelShader = compile ps_3_0 PixelShaderFunction();
    }
};