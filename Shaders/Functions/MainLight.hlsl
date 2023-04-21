// Get Main Light Direction and Color with Built-in Renderer

#ifndef MAIN_LIGHT_INCLUDED
#define MAIN_LIGHT_INCLUDED

void MainLight_float(out float3 direction, out float4 color) {
    #if SHADERGRAPH_PREVIEW
        direction = float3(0.5, 0.5, 0);
        color = float4(1, 1, 1, 1);
    #else
        direction = _WorldSpaceLightPos0;
        color = _LightColor0;
    #endif
}

#endif
