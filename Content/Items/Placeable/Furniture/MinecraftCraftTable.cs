using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace MarkMode.Content.Items.Placeable.Furniture
{
    public class MinecraftCraftTable : ModItem
    {
        public override void SetDefaults()
        {
            //what tile to place brooo
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.MinecraftCraftTable>());
            Item.width = 28;
            Item.height = 14;
            Item.value = Item.buyPrice(copper: 10);
        }
        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.CraftingObjects;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 4)
                .Register();
        }
    }
}