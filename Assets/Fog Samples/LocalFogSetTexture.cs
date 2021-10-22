using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;


[RequireComponent(typeof(LocalVolumetricFog)), ExecuteAlways]
public class LocalFogSetTexture : MonoBehaviour
{
    public string parameterName = "texture";
    public Texture2D texture;

    void SetParams(CommandBuffer cmd, ComputeShader compute, int kernelIndex)
    {
        RenderTargetIdentifier rti = new RenderTargetIdentifier(texture);
        cmd.SetComputeTextureParam(compute, kernelIndex, parameterName, rti);
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
