using System;
using UnityEditor;
#if UNITY_2017_2_OR_NEWER
#elif UNITY_5_6_OR_NEWER
using UnityEngine.VR;
using XRSettings = UnityEngine.VR.VRSettings;
#endif

namespace UnityEngine.Experimental.Rendering
{
    [Serializable]
    public class XRGraphics
    { // XRGraphics insulates SRP from API changes across platforms, Editor versions, and as XR transitions into XR SDK

        public enum StereoRenderingMode
        {
            MultiPass = 0,
            SinglePass,
            SinglePassInstanced,
            SinglePassMultiView
        };

        public static float eyeTextureResolutionScale
        {
            get
            {
                return 1.0f;
            }
        }

        public static float renderViewportScale
        {
            get
            {
                return 1.0f;
            }
        }
                
#if UNITY_EDITOR
        public static bool tryEnable
        { // TryEnable gets updated before "play" is pressed- we use this for updating GUI only. 
            get { return PlayerSettings.virtualRealitySupported; }
        }
#endif
        
        public static bool enabled
        { // SRP should use this to safely determine whether XR is enabled at runtime.
            get
            {
#if ENABLE_VR
                return false;
#else
                return false;
#endif
            }
        }

        public static bool isDeviceActive
        {
            get
            {
                return false;
            }
        }

        public static string loadedDeviceName
        {
            get
            {
                return "No XR device loaded";
            }
        }

        public static string[] supportedDevices
        {
            get
            {
                return new string[1];
            }
        }

        public static StereoRenderingMode stereoRenderingMode
        {
            get
            {
                if (!enabled)
                    return StereoRenderingMode.SinglePass;
#if UNITY_2018_3_OR_NEWER
                return StereoRenderingMode.SinglePass;
#else // Reverse engineer it
                if (!enabled)
                    return StereoRenderingMode.SinglePassMultiView;
                if (eyeTextureDesc.vrUsage == VRTextureUsage.TwoEyes)
                {
                    if (eyeTextureDesc.dimension == UnityEngine.Rendering.TextureDimension.Tex2DArray)
                        return StereoRenderingMode.SinglePassInstanced;
                    return StereoRenderingMode.SinglePassDoubleWide;
                }
                else
                    return StereoRenderingMode.MultiPass;
#endif
            }
        }
        public static uint GetPixelOffset(uint eye)
        {
                return 0;
        }

        public static RenderTextureDescriptor eyeTextureDesc
        {
            get
            {
                    return new RenderTextureDescriptor(0, 0);
            }
        }

        public static int eyeTextureWidth
        {
            get
            {
                    return 0;
            }
        }
        public static int eyeTextureHeight
        {
            get
            {
                    return 0;
            }
        }

    }
}
