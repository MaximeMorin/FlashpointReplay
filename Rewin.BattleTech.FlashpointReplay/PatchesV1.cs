using BattleTech;
using Harmony;
using HBS.Collections;
using System;
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

    [HarmonyPatch(typeof(SimGameState), "InitializeDataFromDefs")]
    public static class SimGameState_InitializeDataFromDefs_Patch
    {
        public static void Postfix(ref List<FlashpointDef> ___initialFlashpointPool)
        {
            ___initialFlashpointPool.Clear();
        }
    }

    [HarmonyPatch(typeof(SimGameState), "MeetsRequirements", new Type[] { typeof(RequirementDef[]) })]
    public static class SimGameState_MeetsRequirements_Patch
    {
        public static void Postfix(ref bool __result)
        {
            __result = true;
        }
    }

    [HarmonyPatch(typeof(SimGameState), "MeetsRequirements", new Type[] { typeof(RequirementDef), typeof(SimGameReport.ReportEntry) })]
    public static class SimGameState_MeetsRequirements_WithLogs_Patch
    {
        public static void Postfix(ref bool __result)
        {
            __result = true;
        }
    }

    [HarmonyPatch(typeof(SimGameState), "MeetsRequirements", new Type[] { typeof(TagSet), typeof(TagSet), typeof(List<ComparisonDef>), typeof(TagSet), typeof(StatCollection), typeof(SimGameReport.ReportEntry)})]
    public static class SimGameState_MeetsRequirements_WithTagSet_Patch
    {
        public static void Postfix(ref bool __result)
        {
            __result = true;
        }
    }

    [HarmonyPatch(typeof(SimGameState), "MeetsRequirements", new Type[] { typeof(RequirementDef), typeof(TagSet), typeof(StatCollection), typeof(SimGameReport.ReportEntry)})]
    public static class SimGameState_MeetsRequirements_WithTagSetStats_Patch
    {
        public static void Postfix(ref bool __result)
        {
            __result = true;
        }
    }

    [HarmonyPatch(typeof(SimGameState), "MeetsStatRequirements")]
    public static class SimGameState_MeetsStatRequirements_Patch
    {
        public static void Postfix(ref bool __result)
        {
            __result = true;
        }
    }

    [HarmonyPatch(typeof(SimGameState), "MeetsTagRequirements")]
    public static class SimGameState_MeetsTagRequirements_Patch
    {
        public static void Postfix(ref bool __result)
        {
            __result = true;
        }
    }

    [HarmonyPatch(typeof(SimGameState), "CheckForNewFlashpoints")]
    public static class SimGameState__CheckForNewFlashpoints_Patch
    {
        public static void Prefix(ref int ___MaxGenFlashpointsPerDay)
        {
            ___MaxGenFlashpointsPerDay = 10;
        }
    }
}