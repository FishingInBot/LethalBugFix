using BepInEx;
using BepInEx.Logging;
using GameNetcodeStuff;
using HarmonyLib;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LethalBugFix.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class LightningPatch
    {
        [HarmonyPatch("GrabObject")]
        [HarmonyPostfix]
        static void deathByObject(ref int ___health, ref PlayerControllerB __instance, ref GrabbableObject ___currentlyGrabbingObject)
        {
            if (___currentlyGrabbingObject == null) //LITERALLY REPLACE NULL WITH BEHIVE AND THIS SHOULD WORK! :)
            {
                ManualLogSource logSource = BepInEx.Logging.Logger.CreateLogSource("afsdghsertfdhbersthn");
                logSource.LogInfo("We trying ta kill ya.");
                __instance.KillPlayer(Vector3.zero);
            }
        }
    }
}