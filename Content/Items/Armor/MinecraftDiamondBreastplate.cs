using Terraria;
using Terraria.ModLoader;
using MarkMode.Content.Buffs;

namespace MarkMode.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class MinecraftDiamondBreastplate : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ModContent.BuffType<DiamondBuff>();
            Item.defense = 20;
        }
        
        public override void UpdateEquip(Player player)
        {
          player.AddBuff(ModContent.BuffType<DiamondBuff>(), 2);
        }

        public override void AddRecipes()
        {
            CreateRecipe().AddIngredient<MinecraftDiamondItem>(10)
                .AddTile<Tiles.Furniture.MinecraftCraftTable>()
                .Register();
        }
    }
}
