using FargowiltasSouls.Core.Toggler.Content;
using ssm.SOTS.Souls;
using Terraria.ModLoader;

namespace ssm.Content.SoulToggles
{
    internal class SotsSoulHeader : SoulHeader
    {
        public override float Priority => 6.1f;
        public override int Item => ModContent.ItemType<SotsSoul>();
    }
}
