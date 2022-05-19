using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menuu.Migrations
{
    public partial class PopulateSnacks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Snacks (CategoryId, SnackName, ShortDescription, LongDescription, " +
            "Price, ImageUrl, ImageThumbUrl, IsFavorite, InStock) " +
            "VALUES (1, 'Salad Burger', 'Bread, burger, egg, ham, cheese and chips', 'Tasty burger bread with fried egg, " +
            "high quality ham and cheese with delicious potato chips and salad', 9.99, 'https://loja.barracadoze.com.br/wp-content/uploads/sites/5/2020/10/x-egg-com-catupiry.png', " +
            "'https://cdn2.solojavirtual.com/loja/arquivos_loja/56764/Fotos/thumbs3/produto_Foto1_12167407.jpg?cache=',0,1)");

            migrationBuilder.Sql("INSERT INTO Snacks (CategoryId, SnackName, ShortDescription, LongDescription, " +
            "Price, ImageUrl, ImageThumbUrl, IsFavorite, InStock) " +
            "VALUES (1, 'Bacon Burger', 'Bread, burger, cheese and bacon', 'Tasty burger with a lot of bacon and a " +
            "high quality cheddar cheese', 12.99, 'https://burgerx.com.br/assets/img/galeria/burgers/x-bacon.jpg', " +
            "'https://images2.nogueirense.com.br/wp-content/uploads/2020/08/cupom-1596726397.png',0,1)");

            migrationBuilder.Sql("INSERT INTO Snacks (CategoryId, SnackName, ShortDescription, LongDescription, " +
            "Price, ImageUrl, ImageThumbUrl, IsFavorite, InStock) " +
            "VALUES (1, 'Angus Burger', 'Bread, angus burger, cheese, salad and sauce', 'Tasty angus burger with fresh onions salad, " +
            "high quality cheese and a secret sauce', 21.99, 'https://s3-sa-east-1.amazonaws.com/static.standout.com.br/seara/products/img_x2bLwHYl2Um136Sy.jpg', " +
            "'https://thumbs.dreamstime.com/b/angus-burger-91563908.jpg',0,1)");

            migrationBuilder.Sql("INSERT INTO Snacks (CategoryId, SnackName, ShortDescription, LongDescription, " +
            "Price, ImageUrl, ImageThumbUrl, IsFavorite, InStock) " +
            "VALUES (2, 'Vegan Burger', 'Bread, Vegan burger, vegan cheese and salad', '100% vegan burger with fresh salad and " +
            "high quality vegan cheese', 17.99, 'https://assets.epicurious.com/photos/5e4c65cfd57b3b000872c652/4:3/w_3604,h_2703,c_limit/VeggieBurger_RECIPE_IG_021320_516_VOG_final.jpg', " +
            "'https://images.immediate.co.uk/production/volatile/sites/2/2016/06/23929.jpg?quality=90&resize=556,505',0,1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Snacks");
        }
    }
}
