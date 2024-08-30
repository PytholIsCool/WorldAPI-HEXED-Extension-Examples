using CoreRuntime.Interfaces;
using CoreRuntime.Manager;
using HexedBase.Patches;
using System.Collections;
using WorldAPIExtentionExample;

namespace HexedBase
{
    public class Entry : HexedCheat
    {
        public override void OnLoad(string[] args)
        {
            // Entry thats getting called by HexedLoader, this is alawys the startpoint of the cheat
            Console.WriteLine("WorldAPI Extention Example Loaded!");

            
            MonoManager.PatchUpdate(typeof(VRCApplication).GetMethod(nameof(VRCApplication.Update))); 
            MonoManager.PatchOnApplicationQuit(typeof(VRCApplicationSetup).GetMethod(nameof(VRCApplicationSetup.OnApplicationQuit))); 

            // Apply our custom Hooked functions
            UnityEngineHWIDPatch.ApplyPatch();

            //After the Hexed Internal Template, do your stuff
            CoroutineManager.RunCoroutine(Example.WaitForQM()); //Since it's an IEnumerator, we use the coroutine manager
        }

        public override void OnApplicationQuit()
        {
            // Function is hooked, so its getting called in our callback
            Console.WriteLine("Game Closed! Bye!");
        }

        public override void OnUpdate()
        {
            //Don't need this for the API example
        }

        public override void OnFixedUpdate()
        {
            // Function is not hooked, won't get called
        }

        public override void OnLateUpdate()
        {
            // Function is not hooked, won't get called
        }

        public override void OnGUI()
        {
            // Function is not hooked, won't get called
        }
    }
}
