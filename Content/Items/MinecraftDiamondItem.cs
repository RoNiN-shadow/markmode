using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using MarkMode.Content.Items.Weapons;

namespace MarkMode.Content.Items
{
    public class MinecraftDiamondItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;

            Item.maxStack = 64;
            Item.value = Item.buyPrice(gold: 5);
        }
        public override void AddRecipes()
        {
            base.AddRecipes();
        }
        public override void OnResearched(bool fullyResearched)
        {
            if (fullyResearched)
            {
                CreativeUI.ResearchItem(ModContent.ItemType<DiamondSword>());
            }
        }
    }
}
