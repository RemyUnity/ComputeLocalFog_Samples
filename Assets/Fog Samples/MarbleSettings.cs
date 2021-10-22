using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;


[RequireComponent(typeof(LocalVolumetricFog)), ExecuteAlways]
public class MarbleSettings : MonoBehaviour
{
    public float a = 0.7f;
    public float b = 0.7f;
    public float c = -19f;

    void SetParams(CommandBuffer cmd, ComputeShader compute, int kernelIndex)
    {
        cmd.SetComputeFloatParam(compute, "marble_a", a);
        cmd.SetComputeFloatParam(compute, "marble_b", b);
        cmd.SetComputeFloatParam(compute, "marble_c", c);
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
