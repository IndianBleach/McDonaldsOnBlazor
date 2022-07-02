using Dapper;
using McDonaldsOnWeb.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonaldsOnWeb.Application.Data
{
    public static class ApplicationContextEnsureCreated
    {
        public static async Task CreateTables(IDbConnection dbConnection)
        {
            dbConnection.Open();

            int? countTables = await dbConnection.QueryFirstOrDefaultAsync<int>
            ("select count(*) from sys.tables;");

            if (!countTables.HasValue || countTables.Value == 0)
            {
                string createTablesQuery = @"create table MenuItem
                (
                Id int primary key identity(1,1),
                ItemName nvarchar(120) not null,
                ItemDescription nvarchar(220) not null,
                ItemPrice decimal not null,
                ItemImage nvarchar(300) not null
                )

                create table OptionIngredients
                (
                Id int primary key identity(1,1),
                IngredientName nvarchar(120) not null,
                IngredientPrice decimal not null,
                )

                create table OptionIngredientsMenuItems
                (
                Id int primary key identity(1,1),
                IngredientId int not null,
                MenuItemId int not null,
                constraint fk_IngredientsItem_IngredientId foreign key (IngredientId) references OptionIngredients(Id),
                constraint fk_IngredientsItem_MenuItemId foreign key (IngredientId) references OptionIngredients(Id),
                )

                create table MenuItemsCombo
                (
                Id int primary key identity(1,1),
                ComboName nvarchar(120) not null,
                TotalPriceDiscountProcent decimal not null,
                constraint discountProcentCheckValue check(TotalPriceDiscountProcent >= 0 and
                TotalPriceDiscountProcent <= 100),
                )

                create table MenuComboMenuItems
                (
                Id int primary key identity(1,1),
                MenuItemId int not null,
                MenuComboId int not null,
                constraint fk_ItemsCombo_MenuItemId foreign key (MenuItemId) references MenuItem(Id),
                constraint fk_ItemsCombo_MenuComboId foreign key (MenuComboId) references MenuItemsCombo(Id),
                )

                create table MenuItemDiscount
                (
                Id int primary key identity(1,1),
                MenuItemId int not null,
                ItemDiscountProcent decimal not null,
                constraint fk_Discount_MenuItemId foreign key (MenuItemId) references MenuItem(Id),
                )";

                await dbConnection.ExecuteAsync(createTablesQuery);
            }

            dbConnection.Close();
        }
    }
}
