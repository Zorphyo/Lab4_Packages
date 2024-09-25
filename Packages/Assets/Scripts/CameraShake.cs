using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Threading;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin cbmcp;
    private float shakeIntensity = 3.0f;
    private float shakeTime = 0.35f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        cbmcp = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                StopShake();
            }
        }
    }

    public void ShakeCamera()
    {
        cbmcp.m_AmplitudeGain = shakeIntensity;
        timer = shakeTime;
    }

    void StopShake()
    {
        cbmcp.m_AmplitudeGain = 0f;
        timer = 0;
    }
}
