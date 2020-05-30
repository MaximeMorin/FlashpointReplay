using BattleTech;
using Harmony;
using HBS.Collections;
using System;
using System.Collections.Generic;

namespace Rewin.BattleTech.FlashpointReplay
{

    [HarmonyPatch(typeof(SimGameState), "Rehydrate")]
    public static class SimGameState_Rehydrate_Patch
    {
        public static void Postfix(SimGameState __instance,
            ref List<SimGameMilestoneDef> ___milestones,
            ref List<string> ___ConsumedMilestones,
            ref List<string> ___contractDiscardPile,
            ref List<string> ___mapDiscardPile,
            ref List<string> ___ignoredContractEmployers,
            ref List<string> ___ignoredContractTargets,
            ref List<string> ___availableFlashpointList,
            ref Flashpoint ___activeFlashpoint,
            ref bool ___inFlashpointCooldown,
            ref int ___flashpointCooldownDays,
            ref bool ___needQueuedMilestoneCheck)
        {
            __instance.completedFlashpoints.Clear();
            __instance.flashpointDiscardPile.Clear();
            __instance.AlreadyClickedConversationResponses.Clear();

            ___milestones.Clear();
            ___ConsumedMilestones.Clear();
            ___contractDiscardPile.Clear();
            ___mapDiscardPile.Clear();
            ___ignoredContractEmployers.Clear();
            ___ignoredContractTargets.Clear();
            ___availableFlashpointList.Clear();
            ___activeFlashpoint = null;
            ___inFlashpointCooldown = false;
            ___flashpointCooldownDays = 0;
            ___needQueuedMilestoneCheck = false;            
        }
    }

    [HarmonyPatch(typeof(SimGameState), "InitializeDataFromDefs")]
    public static class SimGameState_InitializeDataFromDefs_Patch
    {
        public static void Postfix(ref List<FlashpointDef> ___initialFlashpointPool)
        {
            ___initialFlashpointPool.Clear();
        }
    }

    [HarmonyPatch(typeof(SimGameState), "CheckForNewFlashpoints")]
    public static class SimGameState__CheckForNewFlashpoints_Patch
    {
        public static void Prefix(ref int ___MaxGenFlashpointsPerDay, ref int ___MaxActiveFlashpoints)
        {
            ___MaxGenFlashpointsPerDay = 10;
            ___MaxActiveFlashpoints = 20;
        }
    }
}