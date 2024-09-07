using BepInEx;
using BepInEx.Logging;
using System.Security.Permissions;

[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace Spearmaster_Spear_Explosion
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class SpearmasterSpearExplosionMain : BaseUnityPlugin
    {
        public const string PLUGIN_GUID = "sm_spear_explosion";
        public const string PLUGIN_NAME = "Spearmaster Spear Explosion";
        public const string PLUGIN_VERSION = "0.1";

        private void OnEnable()
        {
            On.Player.Update += TakeCustomInput;
        }

        private void TakeCustomInput(On.Player.orig_Update orig, Player self, bool eu)
        {

            orig(self, eu);

        }

    }
}
