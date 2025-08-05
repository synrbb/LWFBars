using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;

namespace LWFBars
{
    [HarmonyPatch(typeof(XUiC_ToolbeltWindow))]
    class Patch_XUiC_ToolbeltWindow
    {
        [HarmonyTranspiler]
        [HarmonyPatch(nameof(XUiC_ToolbeltWindow.Update))]
        static IEnumerable<CodeInstruction> Update(IEnumerable<CodeInstruction> instructions)
        {
            var localPlayerField = typeof(XUiC_ToolbeltWindow).GetField(nameof(XUiC_ToolbeltWindow.localPlayer));
            var attachToEntityField = typeof(Entity).GetField(nameof(Entity.AttachedToEntity));
            var matches = new CodeMatch[] {
                new(OpCodes.Ldarg_0),
                new(OpCodes.Ldfld, localPlayerField),
                new(OpCodes.Ldfld, attachToEntityField),
                new(OpCodes.Ldnull),
                new(OpCodes.Call),
                CodeMatch.WithOpcodes(new HashSet<OpCode>{ OpCodes.Brfalse, OpCodes.Brfalse_S }),
                new(OpCodes.Ldarg_0),
                new(OpCodes.Ldfld, localPlayerField),
                new(OpCodes.Ldfld, attachToEntityField),
                new(OpCodes.Isinst, typeof(EntityVehicle)),
                CodeMatch.WithOpcodes(new HashSet<OpCode>{ OpCodes.Brtrue, OpCodes.Brtrue_S }),
            };
            return new CodeMatcher(instructions)
                .MatchStartForward(matches)
                .ThrowIfInvalid("failed to match")
                .RemoveInstructions(matches.Length)
                .Instructions();
        }
    }
}
