using Exercitii_laborator_17.Models;
using Exercitii_laborator_17.Data;
using Exercitii_laborator_17;


#region Cerinte
/*
    1. Stabiliti relatiile dintre clase
    2. Realizati diagrama uml
    3. Stabiliti relatiile dintre entitati(1-1,1-*,*-*)
    4. Stabiliti Navigation Property-urile si FK-urile necesare
    5. CreeatiDB-ul, DBContext-ul, precum si o functie statica seedDB/resetDB

    Scrieti urmatoarele functii
    • Adaugare de categorie
    • Adaugare de producator
    • Modificarea pretului unui produs
    • Obtinerea valorii totale a stocului magazinului
    • Obtinearea valorii stocului de la un anumit producator oferit ca parametru
    • Obtinerea valorii totale a stocului per categorie

    Suplimentar:
    • Adaugare de produs
        • Va adauga automat si eticheta
    • Obtinerea valorii stocului per categorie per producator
*/
#endregion


#region Manufacturers + Categories

Producer scAgricultorul = new Producer { Name = "SC Agricultorul", Address = "Galati - Romania", UIC = "RO3422" };
Producer samsung = new Producer { Name = "Samsung", Address = "Suwon - South Korea", UIC = "ESS3152" };
Producer scCizmarul = new Producer { Name = "SC Cizmarul", Address = "Brasov - Romania", UIC = "CFR3211" };
Producer goodFood = new Producer { Name = "GoodFood", Address = "Terni - Italy", UIC = "ITA32492" };
Producer zanussi = new Producer { Name = "Zanussi", Address = "Porderone - Italy", UIC = "ITA37991" };
Producer lactoGood = new Producer { Name = "LactoGood", Address = "Suceava - Romania", UIC = "RO91544" };
Producer notZara = new Producer { Name = "NotZara", Address = "Arteixo - Spain", UIC = "SPA043911" };

Producer notApple = new Producer { Name = "NotApple", Address = "Cupertino - USA", UIC = "USA12665" };
Producer milka = new Producer { Name = "Milka", Address = "Lorrach - Germany", UIC = "GE652241" };

Category foods = new Category { Name = "Foods", Image = "http//foods.com" };
Category fashion = new Category { Name = "Fashion", Image = "http//clothes.shoes.com" };
Category appliances = new Category { Name = "Appliances", Image = "http//electro.eu" };

Category sports = new Category { Name = "Sports", Image = "http//sports.com" };

#endregion


ResetDB();

using StoreContextDB context = new StoreContextDB();


DataLayer.AddCategory(sports);

//DataLayer.AddProducer(notApple);
DataLayer.AddProducer(milka);

DataLayer.ChangePrice(4, 12.67);

Console.WriteLine($"Store Stock Value: {DataLayer.StoreStockValue():N2} lei");
Console.WriteLine($"Producer Stock Value: {DataLayer.ProducerStockValue(scCizmarul):N2} lei");
Console.WriteLine($"Producer Stock Value: {DataLayer.ProducerStockValue(notApple):N2} lei");
Console.WriteLine($"Category Stock Value: {DataLayer.CategoryStockValue(sports):N2} lei");
Console.WriteLine($"Category Producer Stock Value: {DataLayer.CategoryProducerStockValue(foods, zanussi):N2} lei");
Console.WriteLine($"Category Producer Stock Value: {DataLayer.CategoryProducerStockValue(appliances, zanussi):N2} lei");


Product nuci = new Product
{
    Name = "Nuts",
    Stock = 23,
    Producer = scAgricultorul,
    Category = foods
};

DataLayer.AddProduct(nuci, 15.88);

context.SaveChanges();


void ResetDB()
{
    using var context = new StoreContextDB();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();


    #region Products
    context.Add(
        new Product
        {
            Name = "Green Apples",
            Stock = 100,
            Producer = scAgricultorul,
            Category = foods,
            Label = new Label { Price = 1.45 }
        });

    context.Add(
        new Product
        {
            Name = "Red Apples",
            Stock = 150,
            Producer = scAgricultorul,
            Category = foods,
            Label = new Label { Price = 2.45 }
        });

    context.Add(
        new Product
        {
            Name = "Peaches",
            Stock = 120,
            Producer = scAgricultorul,
            Category = foods,
            Label = new Label { Price = 4.86 }
        });

    context.Add(
        new Product
        {
            Name = "Pears",
            Stock = 50,
            Producer = scAgricultorul,
            Category = foods,
            Label = new Label { Price = 7.95 }
        });

    context.Add(
        new Product
        {
            Name = "Tomatoes",
            Stock = 160,
            Producer = scAgricultorul,
            Category = foods,
            Label = new Label { Price = 5.55 }
        });

    context.Add(
        new Product
        {
            Name = "Cucumbers",
            Stock = 210,
            Producer = scAgricultorul,
            Category = foods,
            Label = new Label { Price = 3.05 }
        });

    context.Add(
        new Product
        {
            Name = "Cabbage",
            Stock = 90,
            Producer = scAgricultorul,
            Category = foods,
            Label = new Label { Price = 1.10 }
        });

    context.Add(
        new Product
        {
            Name = "Smartphone",
            Stock = 10,
            Producer = samsung,
            Category = appliances,
            Label = new Label { Price = 3500 }
        });

    context.Add(
        new Product
        {
            Name = "TV",
            Stock = 17,
            Producer = samsung,
            Category = appliances,
            Label = new Label { Price = 2150 }
        });
    context.Add(
        new Product
        {
            Name = "Toaster",
            Stock = 23,
            Producer = samsung,
            Category = appliances,
            Label = new Label { Price = 100 }
        });

    context.Add(
        new Product
        {
            Name = "AC",
            Stock = 7,
            Producer = samsung,
            Category = appliances,
            Label = new Label { Price = 4500 }
        });

    context.Add(
        new Product
        {
            Name = "Washing Machine",
            Stock = 14,
            Producer = samsung,
            Category = appliances,
            Label = new Label { Price = 1450 }
        });


    context.Add(
        new Product
        {
            Name = "Washing Machine",
            Stock = 21,
            Producer = zanussi,
            Category = appliances,
            Label = new Label { Price = 1300 }
        });

    context.Add(
        new Product
        {
            Name = "Toaster",
            Stock = 15,
            Producer = zanussi,
            Category = appliances,
            Label = new Label { Price = 75 }
        });

    context.Add(
        new Product
        {
            Name = "Lightbulb",
            Stock = 50,
            Producer = zanussi,
            Category = appliances,
            Label = new Label { Price = 4.6 }
        });

    context.Add(
        new Product
        {
            Name = "Microwave Oven",
            Stock = 25,
            Producer = zanussi,
            Category = appliances,
            Label = new Label { Price = 325 }
        });

    context.Add(
        new Product
        {
            Name = "Biscuits",
            Stock = 40,
            Producer = goodFood,
            Category = foods,
            Label = new Label { Price = 3.3 }
        });

    context.Add(
        new Product
        {
            Name = "Cheesecake",
            Stock = 10,
            Producer = goodFood,
            Category = foods,
            Label = new Label { Price = 25 }
        });

    context.Add(
        new Product
        {
            Name = "Lollipops",
            Stock = 20,
            Producer = goodFood,
            Category = foods,
            Label = new Label { Price = 1.2 }
        });

    context.Add(
        new Product
        {
            Name = "Fresh Milk",
            Stock = 30,
            Producer = lactoGood,
            Category = foods,
            Label = new Label { Price = 7 }
        });

    context.Add(
        new Product
        {
            Name = "Fat Yogurt",
            Stock = 35,
            Producer = lactoGood,
            Category = foods,
            Label = new Label { Price = 5 }
        });

    context.Add(
        new Product
        {
            Name = "Cheese",
            Stock = 23,
            Producer = lactoGood,
            Category = foods,
            Label = new Label { Price = 26.68 }
        });

    context.Add(
        new Product
        {
            Name = "Dresses",
            Stock = 7,
            Producer = notZara,
            Category = fashion,
            Label = new Label { Price = 350 }
        });

    context.Add(
        new Product
        {
            Name = "Summer Shoes",
            Stock = 17,
            Producer = notZara,
            Category = fashion,
            Label = new Label { Price = 150 }
        });

    context.Add(
        new Product
        {
            Name = "Shirts",
            Stock = 11,
            Producer = notZara,
            Category = fashion,
            Label = new Label { Price = 110 }
        });

    context.Add(
        new Product
        {
            Name = "Jeans",
            Stock = 15,
            Producer = notZara,
            Category = fashion,
            Label = new Label { Price = 250 }
        });

    context.Add(
        new Product
        {
            Name = "Elegant Shoes",
            Stock = 7,
            Producer = notZara,
            Category = fashion,
            Label = new Label { Price = 450 }
        });

    context.Add(
        new Product
        {
            Name = "Man Shoes",
            Stock = 17,
            Producer = scCizmarul,
            Category = fashion,
            Label = new Label { Price = 250 }
        });

    context.Add(
        new Product
        {
            Name = "Beach Slippers",
            Stock = 23,
            Producer = scCizmarul,
            Category = fashion,
            Label = new Label { Price = 50 }
        });

    context.Add(
        new Product
        {
            Name = "Sport Shoes",
            Stock = 13,
            Producer = scCizmarul,
            Category = fashion,
            Label = new Label { Price = 298 }
        });
#endregion

    context.SaveChanges();
}

