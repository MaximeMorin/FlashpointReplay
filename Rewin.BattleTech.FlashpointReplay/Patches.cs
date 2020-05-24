using BattleTech;
using Harmony;
using System.Collections.Generic;

namespace Rewin.BattleTech.FlashpointReplay
{
    [HarmonyPatch(typeof(SimGameState), "CompleteFlashpoint")]
    public static class SimGameState_CompleteFlashpoint_Patch
    {
        public static void Postfix(SimGameState __instance)
        {
            __instance.completedFlashpoints = new List<string>();
        }
    }

    [HarmonyPatch(typeof(SimGameState), "Rehydrate")]
    public static class SimGameState_Rehydrate_Patch
    {
        public static void Postfix(SimGameState __instance)
        {
            __instance.completedFlashpoints = new List<string>();
        }
    }
}