using HarmonyLib;

namespace LWFBars
{
    public class ModInit : IModApi
    {
        public void InitMod(Mod _modInstance)
        {
            var harmony = new Harmony("io.github.synrbb.LWFBars");
            harmony.PatchAll();
        }
    }
}
