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

    public static class ApplicationContextSeed
    {
        public static async Task SeedDatabaseAsync(IDbConnection DbConnection)
        {
            int? existData = await DbConnection.QueryFirstOrDefaultAsync<int>
                ("select count(*) from MenuItem;");

            if (!existData.HasValue || existData.Value <= 0)
            {
                string createTablesQuery = @"insert MenuItem values ('Цезарь Ролл', 'Цезарь ролл обычный, 1 шт.', 129, 'roll.png');
insert MenuItem values ('Цезарь Ролл с Беконом', 'Цезарь ролл обычный, плюс доп бекон, 1 шт.', 169, 'rollbecon.png');
insert MenuItem values ('Ролл', 'Ролл обычный с салатом, 1 шт.', 129, 'droll.png');
insert MenuItem values ('Двойной Гранд', 'Гранд двойной обычный, салат и сыр, 1 шт.', 159, 'dgrand.png');
insert MenuItem values ('Гранд Де Люкс', 'Двойной гранд с сыром и салатом, две котлеты, плюс доп бекон, 1 шт.', 269, 'luxegrand.png');
insert MenuItem values ('Чизбургер', 'Чизбургер обычный с сыром и одной котлетой', 89, 'chiz.png');
insert MenuItem values ('Гамбургер', 'Гамбургер обычный с сыром и одной котлетой', 69, 'gamb.png');
insert MenuItem values ('Чикен Премьер', 'Чикен обычный с сыром и одной котлетой из курицы', 99, 'chikenp.png');
insert MenuItem values ('Чикенбругер', 'Чикен обычный с сыром и одной куриной котлетой плюс салат', 149, 'chikenb.png');
insert MenuItem values ('Креветки', 'Креветки, натуральные, 9шт.', 249, 'krevet.png');
insert MenuItem values ('Куриные Крылышки', 'Крылышки из курицы, натуральные, 9шт.', 349, 'wings.png');
insert MenuItem values ('Нагеттсы', 'Наггетсы из курицы, натуральные, 9шт.', 229, 'nag.png');
insert MenuItem values ('Картофель Фри', 'Картофель, натуральный, маленький набор (200гр.)', 149, 'fr.png');
insert MenuItem values ('Картофель Фри Большой', 'Картофель, натуральный, большой набор (400гр.)', 329, 'frb.png');
insert MenuItem values ('Мороженое Карамельное', 'Карамельное мороженое, натуральное 1шт (200гр.)', 179, 'car.png');
insert MenuItem values ('Кола Средняя', 'Средняя КокаКола (250мл.)', 229, 'cola.png');
insert MenuItem values ('Кофе', 'Кофе на сливках (200мл.)', 196, 'coffee.png');

insert OptionIngredients values ('Слой сыра', 26);
insert OptionIngredients values ('Плюс Котлета', 46);
insert OptionIngredients values ('Бекон', 39);
insert OptionIngredients values ('Огурцы', 33);
insert OptionIngredients values ('Соус Биг Мак', 26);
insert OptionIngredients values ('Соус 1000 Островов', 33);
insert OptionIngredients values ('Соус Сырный', 26);
insert OptionIngredients values ('Соус Чилли', 23);
insert OptionIngredients values ('Соус Барбекю', 26);
insert OptionIngredients values ('Убрать лук', 0);
insert OptionIngredients values ('Убрать сыр', 0);
insert OptionIngredients values ('Убрать салат', 0);

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Слой сыра'),
(select Id from MenuItem where ItemName = 'Цезарь Ролл'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Плюс Котлета'),
(select Id from MenuItem where ItemName = 'Цезарь Ролл'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Огурцы'),
(select Id from MenuItem where ItemName = 'Цезарь Ролл'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Убрать лук'),
(select Id from MenuItem where ItemName = 'Ролл'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Убрать салат'),
(select Id from MenuItem where ItemName = 'Ролл'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Убрать сыр'),
(select Id from MenuItem where ItemName = 'Ролл'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Бекон'),
(select Id from MenuItem where ItemName = 'Ролл'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Бекон'),
(select Id from MenuItem where ItemName = 'Двойной Гранд'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Убрать лук'),
(select Id from MenuItem where ItemName = 'Двойной Гранд'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where
IngredientName = 'Слой сыра'),
(select Id from MenuItem where ItemName = 'Гамбургер'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Плюс Котлета'),
(select Id from MenuItem where ItemName = 'Гамбургер'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Огурцы'),
(select Id from MenuItem where ItemName = 'Гамбургер'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Убрать лук'),
(select Id from MenuItem where ItemName = 'Гамбургер'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Соус 1000 Островов'),
(select Id from MenuItem where ItemName = 'Креветки'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Соус Сырный'),
(select Id from MenuItem where ItemName = 'Креветки'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Соус 1000 Островов'),
(select Id from MenuItem where ItemName = 'Картофель Фри'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Соус Сырный'),
(select Id from MenuItem where ItemName = 'Картофель Фри'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Соус Чилли'),
(select Id from MenuItem where ItemName = 'Картофель Фри'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Соус Барбекю'),
(select Id from MenuItem where ItemName = 'Картофель Фри'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Соус 1000 Островов'),
(select Id from MenuItem where ItemName = 'Картофель Фри Большой'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Соус Сырный'),
(select Id from MenuItem where ItemName = 'Картофель Фри Большой'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Соус Барбекю'),
(select Id from MenuItem where ItemName = 'Картофель Фри Большой'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Соус Чилли'),
(select Id from MenuItem where ItemName = 'Картофель Фри Большой'))


--COMBO
insert MenuItemsCombo values ('Полный Обед', 25);
insert MenuItemsCombo values ('Три в одном', 25);
insert MenuItemsCombo values ('Завтрак', 15);
insert MenuItemsCombo values ('6 в одном', 25);
insert MenuItemsCombo values ('Великий Ужин', 22);


--COMBO-ITEMS
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Гамбургер'),
(select Id from MenuItemsCombo where ComboName = 'Полный Обед'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Кола Средняя'),
(select Id from MenuItemsCombo where ComboName = 'Полный Обед'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Картофель Фри'),
(select Id from MenuItemsCombo where ComboName = 'Полный Обед'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Мороженое Карамельное'),
(select Id from MenuItemsCombo where ComboName = 'Полный Обед'))

insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Чикен Премьер'),
(select Id from MenuItemsCombo where ComboName = 'Три в одном'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Кола Средняя'),
(select Id from MenuItemsCombo where ComboName = 'Три в одном'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Картофель Фри'),
(select Id from MenuItemsCombo where ComboName = 'Три в одном'))

insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Кофе'),
(select Id from MenuItemsCombo where ComboName = 'Завтрак'))
insert MenuComboMenuItems values (
(select Id
from MenuItem where ItemName = 'Мороженое Карамельное'),
(select Id from MenuItemsCombo where ComboName = 'Завтрак'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Чикенбругер'),
(select Id from MenuItemsCombo where ComboName = 'Завтрак'))

insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Чикенбругер'),
(select Id from MenuItemsCombo where ComboName = '6 в одном'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Чикен Премьер'),
(select Id from MenuItemsCombo where ComboName = '6 в одном'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Картофель Фри'),
(select Id from MenuItemsCombo where ComboName = '6 в одном'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Кола Средняя'),
(select Id from MenuItemsCombo where ComboName = '6 в одном'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Мороженое Карамельное'),
(select Id from MenuItemsCombo where ComboName = '6 в одном'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Креветки'),
(select Id from MenuItemsCombo where ComboName = '6 в одном'))

insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Чикен Премьер'),
(select Id from MenuItemsCombo where ComboName = 'Великий Ужин'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Картофель Фри'),
(select Id from MenuItemsCombo where ComboName = 'Великий Ужин'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Гранд Де Люкс'),
(select Id from MenuItemsCombo where ComboName = 'Великий Ужин'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Куриные Крылышки'),
(select Id from MenuItemsCombo where ComboName = 'Великий Ужин'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Креветки'),
(select Id from MenuItemsCombo where ComboName = 'Великий Ужин'))

--DISCOUNT
insert MenuItemDiscount values (
(select Id from MenuItem where ItemName = 'Чизбургер'),
(select floor(rand() * 30)))
insert MenuItemDiscount values (
(select Id from MenuItem where ItemName = 'Гранд Де Люкс'),
(select floor(rand() * 30)))
insert MenuItemDiscount values (
(select Id from MenuItem where ItemName = 'Гамбургер'),
(select floor(rand() * 30)))
insert MenuItemDiscount values (
(select Id from MenuItem where ItemName = 'Чикен Премьер'),
(select floor(rand() * 30)))
insert MenuItemDiscount values (
(select Id from MenuItem where ItemName = 'Цезарь Ролл с Беконом'),
(select floor(rand() * 30)))";

                await DbConnection.ExecuteAsync(createTablesQuery);
            }
        }

        public static async Task SeedDatabaseAsync(IApplicationContext ctx)
        {
            int? existData = await ctx.DbConnection.QueryFirstOrDefaultAsync<int>
                ("select count(*) from MenuItem;");

            if (!existData.HasValue || existData.Value <= 0)
            {
                string createTablesQuery = @"insert MenuItem values ('Цезарь Ролл', 'Цезарь ролл обычный, 1 шт.', 129, 'roll.png');
insert MenuItem values ('Цезарь Ролл с Беконом', 'Цезарь ролл обычный, плюс доп бекон, 1 шт.', 169, 'rollbecon.png');
insert MenuItem values ('Ролл', 'Ролл обычный с салатом, 1 шт.', 129, 'droll.png');
insert MenuItem values ('Двойной Гранд', 'Гранд двойной обычный, салат и сыр, 1 шт.', 159, 'dgrand.png');
insert MenuItem values ('Гранд Де Люкс', 'Двойной гранд с сыром и салатом, две котлеты, плюс доп бекон, 1 шт.', 269, 'luxegrand.png');
insert MenuItem values ('Чизбургер', 'Чизбургер обычный с сыром и одной котлетой', 89, 'chiz.png');
insert MenuItem values ('Гамбургер', 'Гамбургер обычный с сыром и одной котлетой', 69, 'gamb.png');
insert MenuItem values ('Чикен Премьер', 'Чикен обычный с сыром и одной котлетой из курицы', 99, 'chikenp.png');
insert MenuItem values ('Чикенбругер', 'Чикен обычный с сыром и одной куриной котлетой плюс салат', 149, 'chikenb.png');
insert MenuItem values ('Креветки', 'Креветки, натуральные, 9шт.', 249, 'krevet.png');
insert MenuItem values ('Куриные Крылышки', 'Крылышки из курицы, натуральные, 9шт.', 349, 'wings.png');
insert MenuItem values ('Нагеттсы', 'Наггетсы из курицы, натуральные, 9шт.', 229, 'nag.png');
insert MenuItem values ('Картофель Фри', 'Картофель, натуральный, маленький набор (200гр.)', 149, 'fr.png');
insert MenuItem values ('Картофель Фри Большой', 'Картофель, натуральный, большой набор (400гр.)', 329, 'frb.png');
insert MenuItem values ('Мороженое Карамельное', 'Карамельное мороженое, натуральное 1шт (200гр.)', 179, 'car.png');
insert MenuItem values ('Кола Средняя', 'Средняя КокаКола (250мл.)', 229, 'cola.png');
insert MenuItem values ('Кофе', 'Кофе на сливках (200мл.)', 196, 'coffee.png');

insert OptionIngredients values ('Слой сыра', 26);
insert OptionIngredients values ('Плюс Котлета', 46);
insert OptionIngredients values ('Бекон', 39);
insert OptionIngredients values ('Огурцы', 33);
insert OptionIngredients values ('Соус Биг Мак', 26);
insert OptionIngredients values ('Соус 1000 Островов', 33);
insert OptionIngredients values ('Соус Сырный', 26);
insert OptionIngredients values ('Соус Чилли', 23);
insert OptionIngredients values ('Соус Барбекю', 26);
insert OptionIngredients values ('Убрать лук', 0);
insert OptionIngredients values ('Убрать сыр', 0);
insert OptionIngredients values ('Убрать салат', 0);

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Слой сыра'),
(select Id from MenuItem where ItemName = 'Цезарь Ролл'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Плюс Котлета'),
(select Id from MenuItem where ItemName = 'Цезарь Ролл'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Огурцы'),
(select Id from MenuItem where ItemName = 'Цезарь Ролл'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Убрать лук'),
(select Id from MenuItem where ItemName = 'Ролл'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Убрать салат'),
(select Id from MenuItem where ItemName = 'Ролл'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Убрать сыр'),
(select Id from MenuItem where ItemName = 'Ролл'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Бекон'),
(select Id from MenuItem where ItemName = 'Ролл'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Бекон'),
(select Id from MenuItem where ItemName = 'Двойной Гранд'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Убрать лук'),
(select Id from MenuItem where ItemName = 'Двойной Гранд'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where
IngredientName = 'Слой сыра'),
(select Id from MenuItem where ItemName = 'Гамбургер'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Плюс Котлета'),
(select Id from MenuItem where ItemName = 'Гамбургер'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Огурцы'),
(select Id from MenuItem where ItemName = 'Гамбургер'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Убрать лук'),
(select Id from MenuItem where ItemName = 'Гамбургер'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Соус 1000 Островов'),
(select Id from MenuItem where ItemName = 'Креветки'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Соус Сырный'),
(select Id from MenuItem where ItemName = 'Креветки'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Соус 1000 Островов'),
(select Id from MenuItem where ItemName = 'Картофель Фри'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Соус Сырный'),
(select Id from MenuItem where ItemName = 'Картофель Фри'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Соус Чилли'),
(select Id from MenuItem where ItemName = 'Картофель Фри'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Соус Барбекю'),
(select Id from MenuItem where ItemName = 'Картофель Фри'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Соус 1000 Островов'),
(select Id from MenuItem where ItemName = 'Картофель Фри Большой'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Соус Сырный'),
(select Id from MenuItem where ItemName = 'Картофель Фри Большой'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Соус Барбекю'),
(select Id from MenuItem where ItemName = 'Картофель Фри Большой'))

insert OptionIngredientsMenuItems values (
(select Id from OptionIngredients where IngredientName = 'Соус Чилли'),
(select Id from MenuItem where ItemName = 'Картофель Фри Большой'))


--COMBO
insert MenuItemsCombo values ('Полный Обед', 25);
insert MenuItemsCombo values ('Три в одном', 25);
insert MenuItemsCombo values ('Завтрак', 15);
insert MenuItemsCombo values ('6 в одном', 25);
insert MenuItemsCombo values ('Великий Ужин', 22);


--COMBO-ITEMS
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Гамбургер'),
(select Id from MenuItemsCombo where ComboName = 'Полный Обед'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Кола Средняя'),
(select Id from MenuItemsCombo where ComboName = 'Полный Обед'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Картофель Фри'),
(select Id from MenuItemsCombo where ComboName = 'Полный Обед'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Мороженое Карамельное'),
(select Id from MenuItemsCombo where ComboName = 'Полный Обед'))

insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Чикен Премьер'),
(select Id from MenuItemsCombo where ComboName = 'Три в одном'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Кола Средняя'),
(select Id from MenuItemsCombo where ComboName = 'Три в одном'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Картофель Фри'),
(select Id from MenuItemsCombo where ComboName = 'Три в одном'))

insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Кофе'),
(select Id from MenuItemsCombo where ComboName = 'Завтрак'))
insert MenuComboMenuItems values (
(select Id
from MenuItem where ItemName = 'Мороженое Карамельное'),
(select Id from MenuItemsCombo where ComboName = 'Завтрак'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Чикенбругер'),
(select Id from MenuItemsCombo where ComboName = 'Завтрак'))

insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Чикенбругер'),
(select Id from MenuItemsCombo where ComboName = '6 в одном'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Чикен Премьер'),
(select Id from MenuItemsCombo where ComboName = '6 в одном'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Картофель Фри'),
(select Id from MenuItemsCombo where ComboName = '6 в одном'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Кола Средняя'),
(select Id from MenuItemsCombo where ComboName = '6 в одном'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Мороженое Карамельное'),
(select Id from MenuItemsCombo where ComboName = '6 в одном'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Креветки'),
(select Id from MenuItemsCombo where ComboName = '6 в одном'))

insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Чикен Премьер'),
(select Id from MenuItemsCombo where ComboName = 'Великий Ужин'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Картофель Фри'),
(select Id from MenuItemsCombo where ComboName = 'Великий Ужин'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Гранд Де Люкс'),
(select Id from MenuItemsCombo where ComboName = 'Великий Ужин'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Куриные Крылышки'),
(select Id from MenuItemsCombo where ComboName = 'Великий Ужин'))
insert MenuComboMenuItems values (
(select Id from MenuItem where ItemName = 'Креветки'),
(select Id from MenuItemsCombo where ComboName = 'Великий Ужин'))

--DISCOUNT
insert MenuItemDiscount values (
(select Id from MenuItem where ItemName = 'Чизбургер'),
(select floor(rand() * 30)))
insert MenuItemDiscount values (
(select Id from MenuItem where ItemName = 'Гранд Де Люкс'),
(select floor(rand() * 30)))
insert MenuItemDiscount values (
(select Id from MenuItem where ItemName = 'Гамбургер'),
(select floor(rand() * 30)))
insert MenuItemDiscount values (
(select Id from MenuItem where ItemName = 'Чикен Премьер'),
(select floor(rand() * 30)))
insert MenuItemDiscount values (
(select Id from MenuItem where ItemName = 'Цезарь Ролл с Беконом'),
(select floor(rand() * 30)))";

                await ctx.DbConnection.ExecuteAsync(createTablesQuery);
            }            
        }
    }
}
