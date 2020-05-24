using Harmony;
using System.Reflection;

namespace Rewin.BattleTech.FlashpointReplay
{
    public static class Runner
    {

        public static void Init()
        {
            var harmony = HarmonyInstance.Create("ca.rewin.battletech.flashpoint-replay");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
