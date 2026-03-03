using UnityEngine;

public class FrameTimingScript : MonoBehaviour
{
    public float intervalSeconds = 1f;

    private readonly FrameTiming[] _timings = new FrameTiming[1];

    private double _cpuSumMs;
    private int _cpuSamples;

    private double _gpuSumMs;
    private int _gpuSamples;

    private float _frameTimeSumSeconds;
    private int _frameCount;

    private float _lastLogTime;

    void OnEnable()
    {
        _lastLogTime = Time.realtimeSinceStartup;
        ResetAccumulators();
    }

    void ResetAccumulators()
    {
        _cpuSumMs = 0;
        _cpuSamples = 0;

        _gpuSumMs = 0;
        _gpuSamples = 0;

        _frameTimeSumSeconds = 0f;
        _frameCount = 0;
    }

    void Update()
    {
        _frameTimeSumSeconds += Time.unscaledDeltaTime;
        _frameCount++;

        FrameTimingManager.CaptureFrameTimings();
        uint samples = FrameTimingManager.GetLatestTimings(1, _timings);

        if (samples > 0)
        {
            double cpuMs = _timings[0].cpuMainThreadFrameTime;
            if (cpuMs > 0.0)
            {
                _cpuSumMs += cpuMs;
                _cpuSamples++;
            }

            double gpuMs = _timings[0].gpuFrameTime;
            if (gpuMs > 0.0)
            {
                _gpuSumMs += gpuMs;
                _gpuSamples++;
            }
        }

        float now = Time.realtimeSinceStartup;
        float window = now - _lastLogTime;

        if (window >= intervalSeconds)
        {
            double avgCpuMs = (_cpuSamples > 0) ? (_cpuSumMs / _cpuSamples) : double.NaN;
            double avgGpuMs = (_gpuSamples > 0) ? (_gpuSumMs / _gpuSamples) : double.NaN;

            double avgFrameMs = (_frameCount > 0) ? ((_frameTimeSumSeconds / _frameCount) * 1000.0) : double.NaN;
            double fps = (window > 0f) ? (_frameCount / window) : double.NaN;

            string cpuText = (_cpuSamples > 0) ? $"{avgCpuMs:F2}ms" : "n/a";
            string gpuText = (_gpuSamples > 0) ? $"{avgGpuMs:F2}ms" : "n/a";

            Debug.Log($"CPU {cpuText} | GPU {gpuText} | Frame {avgFrameMs:F2}ms | FPS {fps:F1}");

            _lastLogTime = now;
            ResetAccumulators();
        }
    }
}