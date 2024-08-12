using BepInEx;
using System.Security.Permissions;

[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace Spearmaster_Spear_Explosion
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class SpearmasterSpearExplosionMain : BaseUnityPlugin
    {
        public const string PLUGIN_GUID = "watchermagic.sm_spear_explosion";
        public const string PLUGIN_NAME = "Spearmaster Spear Explosion";
        public const string PLUGIN_VERSION = "1.0.0";

        private void OnEnable()
        {

        }
    }
}
