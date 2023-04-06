using _IL2CPP;
using BSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FlipScreenPlugin
{
    [BManager.Attributes.ModuleInfo("FlipScreen", "1.0", "BlazeBest")]
    unsafe public class Plugin : BManager.VRModule
    {
        public static GameObject gameObject = null;
        public static void Main()
        {

            gameObject = new GameObject("FlipScreen");
            gameObject.RegisterCustomComponent<FlipScreen>();
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
        }

    }

    public class FlipScreen: MonoBehaviour
    {
        public FlipScreen() : base(IntPtr.Zero) { }

        public void Update()
        {
            if (!Input.GetKey(KeyCode.LeftControl)) return;
            
            Camera camera = Camera.main;
            if (camera == null) return;

            float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
            if (mouseWheel > 0.1)
            {
                Quaternion quaternion = camera.transform.rotation;
                Vector3 euler = quaternion.eulerAngles;
                euler -= Vector3.forward;
                camera.transform.rotation = Quaternion.Euler(euler);
            }
            else if (mouseWheel < -0.1)
            {
                Quaternion quaternion = camera.transform.rotation;
                Vector3 euler = quaternion.eulerAngles;
                euler += Vector3.forward;
                camera.transform.rotation = Quaternion.Euler(euler);
            }
        }
    }
}
