using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

[RequireComponent(typeof(LocalVolumetricFog)), ExecuteAlways]
public class LocalFogControll : MonoBehaviour
{
    public Color color = Color.white;

    void SetParams( CommandBuffer cmd, ComputeShader compute, int kernelIndex)
    {
        cmd.SetComputeVectorParam(compute, "color", color);
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
