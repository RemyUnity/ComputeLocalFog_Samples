using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

[RequireComponent(typeof(LocalVolumetricFog)), ExecuteAlways]
public class LocalFogSetColor : MonoBehaviour
{
    public string parameterName = "color";
    public Color color = Color.white;

    void SetParams( CommandBuffer cmd, ComputeShader compute, int kernelIndex)
    {
        cmd.SetComputeVectorParam(compute, parameterName, color);
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
