using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MarkMode.Content.Rarities
{
    public class DiamondRarity : ModRarity
    {
        public override Color RarityColor => new Color(66, 191, 245);

        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            return base.GetPrefixedRarity(offset, valueMult);
        }
    }
}
