using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;


[RequireComponent(typeof(LocalVolumetricFog)), ExecuteAlways]
public class LocalFogSetTexture : MonoBehaviour
{
    public Texture2D texture;
    public float density = 1;

    void SetParams(CommandBuffer cmd, ComputeShader compute, int kernelIndex)
    {
        RenderTargetIdentifier ri = new RenderTargetIdentifier(texture);
        cmd.SetComputeTextureParam(compute, kernelIndex, "testTexture", ri);
        cmd.SetComputeFloatParam(compute, "density", density);
    }

    private void OnEnable()
    {
        var lvf = GetComponent<LocalVolumetricFog>();
        lvf.setup += SetParams;
    }

    private void OnDisable()
    {
        var lvf = GetComponent<LocalVolumetricFog>();
        lvf.setup -= SetParams;
    }
}
