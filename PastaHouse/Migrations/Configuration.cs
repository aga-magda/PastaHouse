namespace PastaHouse.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PastaHouse.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            // Add admin account
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var user = new ApplicationUser
            {
                UserName = "admin@pastahouse.pl",
                Email = "admin@pastahouse.pl"
            };

            userManager.Create(user, "qwerty1234");

            // Add tables
            context.Tables.AddOrUpdate(x => x.TableId,
                new Table { TableId = 1, NumberOfSeats = 2 }
                );

            context.Tables.AddOrUpdate(x => x.TableId,
                new Table { TableId = 2, NumberOfSeats = 2 }
                );

            context.Tables.AddOrUpdate(x => x.TableId,
                new Table { TableId = 3, NumberOfSeats = 2 }
                );

            context.Tables.AddOrUpdate(x => x.TableId,
                new Table { TableId = 4, NumberOfSeats = 3 }
                );

            context.Tables.AddOrUpdate(x => x.TableId,
                new Table { TableId = 5, NumberOfSeats = 3 }
                );

            context.Tables.AddOrUpdate(x => x.TableId,
                new Table { TableId = 6, NumberOfSeats = 4 }
                );

            context.Tables.AddOrUpdate(x => x.TableId,
                new Table { TableId = 7, NumberOfSeats = 4 }
                );

            context.Tables.AddOrUpdate(x => x.TableId,
                new Table { TableId = 8, NumberOfSeats = 4 }
                );


            // Add dishes
            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish {
                    DishId = 1,
                    Name = "Vegana",
                    Category = "Œniadania",
                    Subcategory = "Puccia",
                    Ingredients = "rukola, awokado, pomidor, czerwona cebula, karczoychy, czarne oliwki, oliwa bazyliowa",
                    Price = 14.50m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 2,
                    Name = "Prosciutto Crudo",
                    Category = "Œniadania",
                    Subcategory = "Puccia",
                    Ingredients = "rukola, prosciutto crudo, mozzarella, pomidor, pesto bazyliowe",
                    Price = 16.50m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 3,
                    Name = "Vitello Tonnato",
                    Category = "Œniadania",
                    Subcategory = "Puccia",
                    Ingredients = "rukola, gotowana ligawa cielêca, sos tuñczykowy, owoc kapara",
                    Price = 18.50m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 4,
                    Name = "Salmone Affumicato",
                    Category = "Œniadania",
                    Subcategory = "Puccia",
                    Ingredients = "sa³ata rzymska, czerwona cebula, wêdzony ³osoœ, œmietana",
                    Price = 20.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 5,
                    Name = "Tonno e Mozzarella",
                    Category = "Œniadania",
                    Subcategory = "Puccia",
                    Ingredients = "sa³ata rzymska, czerwona cebula, tuñczyk, mozzarella, pomidor, œwie¿a miêta",
                    Price = 21.50m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 6,
                    Name = "Gorgonzola e Salame",
                    Category = "Œniadania",
                    Subcategory = "Puccia",
                    Ingredients = "rukola, w³oskie salami, czerwona cebula, gorgonzola",
                    Price = 22.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 7,
                    Name = "Pancake con Sciroppo d'Acero",
                    Category = "Œniadania",
                    Subcategory = "Pancakes",
                    Ingredients = "syrop klonowy, orzechy w³oskie",
                    Price = 12.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 8,
                    Name = "Pancake con i Mirtilli",
                    Category = "Œniadania",
                    Subcategory = "Pancakes",
                    Ingredients = "borówki, œmietana",
                    Price = 12.50m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 9,
                    Name = "Funghi Finereli e Parmigiano",
                    Category = "Œniadania",
                    Subcategory = "Uova",
                    Ingredients = "z kurkami, porem, parmezanem i œwie¿¹ pietruszk¹",
                    Price = 15.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 10,
                    Name = "Salmone Affumicato",
                    Category = "Œniadania",
                    Subcategory = "Uova",
                    Ingredients = "z wêdzonym ³ososiem i szczypiorkiem",
                    Price = 16.20m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 11, 
                    Name = "Prosciuto Cotto",
                    Category = "Œniadania",
                    Subcategory = "Uova",
                    Ingredients = "z w³osk¹ szynk¹ gotowan¹ i szczypiorkiem",
                    Price = 18.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 12,
                    Name = "Pane",
                    Category = "Przystawki",
                    Subcategory = "Przystawki",
                    Ingredients = "chleb i oliwa",
                    Price = 8.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 13,
                    Name = "Marynowane oliwki",
                    Category = "Przystawki",
                    Subcategory = "Przystawki",
                    Ingredients = "oliwki marynowane w zio³ach",
                    Price = 10.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 14,
                    Name = "Raviolo con ouvo",
                    Category = "Przystawki",
                    Subcategory = "Przystawki",
                    Ingredients = "recznie robione raviolo z ricotta i zó³tkiem, mas³o sza³wiowe, parmezan",
                    Price = 11.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 15,
                    Name = "Gravlax caponata",
                    Category = "Przystawki",
                    Subcategory = "Przystawki",
                    Ingredients = "plastry ³ososia gravlax, caponata warzywna, placek rosti, rukola, pietruszkowe aioli",
                    Price = 13.50m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 16,
                    Name = "Gambi",
                    Category = "Przystawki",
                    Subcategory = "Przystawki",
                    Ingredients = "krewetki, wino, mas³o, pietruszka, czosnek, podawane z chlebem",
                    Price = 18.90m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 17,
                    Name = "Antipasti",
                    Category = "Przystawki",
                    Subcategory = "Przystawki",
                    Ingredients = "wedliny, sery, winogrona, caponata warzywna, oliwki, pieczywo, oliwa",
                    Price = 15.55m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 18,
                    Name = "Aglio aglio",
                    Category = "Makarony",
                    Subcategory = "Makarony",
                    Ingredients = "makaron spaghetti, oliwa, czosnek, peperoncino, pietruszka",
                    Price = 32.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 19,
                    Name = "Pomodoro tradizionale",
                    Category = "Makarony",
                    Subcategory = "Makarony",
                    Ingredients = "makaron tortiglioni, sos pomidorowy, bazylia, parmezan",
                    Price = 31.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 20,
                    Name = "Pesto trapanese",
                    Category = "Makarony",
                    Subcategory = "Makarony",
                    Ingredients = "makaron spaghetti, pesto z pomidorków cherry, czosnku, kaparów,migda³ów, parmezanu, sera pecorino, limonki i bazylii",
                    Price = 29.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 21,
                    Name = "Amatricana",
                    Category = "Makarony",
                    Subcategory = "Makarony",
                    Ingredients = "makaron rigatoni, sos pomidorowy, guanciale, cebula, czerwone wino peperoncino, ser pecorino",
                    Price = 33.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 22,
                    Name = "Carbonara",
                    Category = "Makarony",
                    Subcategory = "Makarony",
                    Ingredients = "makaron spaghetti, guanciale, parmezan, pecorino, jajko, pietruszka",
                    Price = 36.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 23,
                    Name = "Pollo",
                    Category = "Makarony",
                    Subcategory = "Makarony",
                    Ingredients = "makaron rigatoni, kurczak, peperoncino, mascarpone, cytryna,rukola, pomidorki koktajlowe",
                    Price = 40.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 24,
                    Name = "Spinaci e gorgonzola",
                    Category = "Makarony",
                    Subcategory = "Makarony",
                    Ingredients = "makaron tagliatelle, kurczak, szpinak, gorgonzola, suszone pomidory, smietana",
                    Price = 39.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 25,
                    Name = "Ragu alla bolognese",
                    Category = "Makarony",
                    Subcategory = "Makarony",
                    Ingredients = "makaron rigatoni, sos bolognese (mieso wo³owe, pomidory, czosnek, cebula, warzywa, wino, bazylia), parmezan",
                    Price = 25.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 26,
                    Name = "Parma no. 2",
                    Category = "Makarony",
                    Subcategory = "Makarony",
                    Ingredients = "makaron spaghetti, szynka parmenska, pomidorki, rukola, smietana, sok z cytryny, zó³tka, parmezan, estragon",
                    Price = 37.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 27,
                    Name = "Crudo giallo",
                    Category = "Makarony",
                    Subcategory = "Makarony",
                    Ingredients = "makaron tagliatelle, szynka parmenska, kurki, mas³o, sza³wia, parmezan",
                    Price = 29.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 28,
                    Name = "Nero",
                    Category = "Makarony",
                    Subcategory = "Makarony",
                    Ingredients = "makaron czarne tagliatelle, krewetki, czosnek, peperoncino, pietruszka, wino, mas³o, pomidorki koktajlowe",
                    Price = 28.59m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 29,
                    Name = "Frutti di mare",
                    Category = "Makarony",
                    Subcategory = "Makarony",
                    Ingredients = "makaron spaghetti, owoce morza (krewetki, kalmary, ma³ze, osmiorniczki), mas³o, czosnek, pietruszka, pomidorki koktajlowe, wino",
                    Price = 33.30m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 30,
                    Name = "Verde salmon",
                    Category = "Makarony",
                    Subcategory = "Makarony",
                    Ingredients = "makaron zielone rigatoni, ³osos, smietana, groszek, taleggio, botwina",
                    Price = 42.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 31,
                    Name = "Mas³o i Sza³wia",
                    Category = "Dania g³ówne",
                    Subcategory = "Gnocchi",
                    Ingredients = "gnocchi ziemniaczane, mas³o, sza³wia, parmezan",
                    Price = 24.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 32,
                    Name = "Pomidory i Bazylia",
                    Category = "Dania g³ówne",
                    Subcategory = "Gnocchi",
                    Ingredients = "gnocchi ziemniaczane, sos pomidorowy, bazylia, parmezan",
                    Price = 25.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 33,
                    Name = "Chistorra",
                    Category = "Dania g³ówne",
                    Subcategory = "Gnocchi",
                    Ingredients = "gnocchi ziemniaczane, pomidory, kie³baska chistorra, mascarpone, oliwki, kolendra",
                    Price = 27.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 34,
                    Name = "Gorgonzola i Szpinak",
                    Category = "Dania g³ówne",
                    Subcategory = "Gnocchi",
                    Ingredients = "gnocchi ziemniaczane, gorgonzola, szpinak, pomidor suszony, smietana",
                    Price = 27.50m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 35,
                    Name = "Salvia",
                    Category = "Dania g³ówne",
                    Subcategory = "Polenty",
                    Ingredients = "z parmezanem i palonym mas³em sza³wiowym, ricotta i zó³tkiem",
                    Price = 33.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 36,
                    Name = "Vege",
                    Category = "Dania g³ówne",
                    Subcategory = "Polenty",
                    Ingredients = "gnocchi ziemniaczane, mas³o, sza³wia, parmezan",
                    Price = 35.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 37,
                    Name = "Bianco",
                    Category = "Dania g³ówne",
                    Subcategory = "Polenty",
                    Ingredients = "z kurczakiem, pancetta, gorgonzola, smietana, rukola, pomidorkami koktajlowymi i parmezanem",
                    Price = 37.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 38,
                    Name = "Paprika e scampi",
                    Category = "Dania g³ówne",
                    Subcategory = "Polenty",
                    Ingredients = "polenta paprykowa z krewetkami, w sosie z mleczka kokosowego i marakui",
                    Price = 38.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 39,
                    Name = "Acquacotta",
                    Category = "Dania g³ówne",
                    Subcategory = "Zupy",
                    Ingredients = "por, marchewka, pomidor, cebula, jajko, grzanka parmezanowa",
                    Price = 15.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 40,
                    Name = "Genua",
                    Category = "Dania g³ówne",
                    Subcategory = "Zupy",
                    Ingredients = "bulion warzywny, owoce morza, por, cebula, pomidory, smietana, kolendra, bazylia, peperoncino",
                    Price = 17.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 41,
                    Name = "Rurki z malinami",
                    Category = "Dania g³ówne",
                    Subcategory = "Menu dla dzieci",
                    Ingredients = "tortiglioni, mascarpone, maliny, cukier",
                    Price = 10.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 42,
                    Name = "Spaghetti z kurczakiem",
                    Category = "Dania g³ówne",
                    Subcategory = "Menu dla dzieci",
                    Ingredients = "spaghetti, kurczak, smietana, pomidorki",
                    Price = 17.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 43,
                    Name = "Pomidorowe rurki",
                    Category = "Dania g³ówne",
                    Subcategory = "Menu dla dzieci",
                    Ingredients = "sos pomidorowy, parmezan",
                    Price = 19.99m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 44,
                    Name = "Ma³e gnocchi",
                    Category = "Dania g³ówne",
                    Subcategory = "Menu dla dzieci",
                    Ingredients = "gnocchi ziemniaczane, mas³o, parmezan",
                    Price = 20.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 45,
                    Name = "Nespolino Bianco IGT 0,150 | 0,75",
                    Category = "Napoje",
                    Subcategory = "Wino bia³e",
                    Ingredients = "wytrawne, Trebiano-Chardonnay | Emilia Romagna",
                    Price = 45.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 46,
                    Name = "Valle delle Lame DOP 0,150 | 0,75",
                    Category = "Napoje",
                    Subcategory = "Wino bia³e",
                    Ingredients = "wytrawne, Verdicchio | Marche",
                    Price = 60.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 47,
                    Name = "Pagadebit DOC 0,150 | 0,75",
                    Category = "Napoje",
                    Subcategory = "Wino bia³e",
                    Ingredients = "wytrawne, Bombino-Sauvignon Blanc | Emiglia Romagna",
                    Price = 55.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 48,
                    Name = "Dogheria Pinot Bianco IGT 0,150 | 0,75",
                    Category = "Napoje",
                    Subcategory = "Wino bia³e",
                    Ingredients = "wytrawne, Pinot Bianco-Sauvignon Blanc | Emiglia Romagna",
                    Price = 65.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 49,
                    Name = "Paladin Pinot Grigio DOC 0,75",
                    Category = "Napoje",
                    Subcategory = "Wino bia³e",
                    Ingredients = "wytrawne, Fiano-Falanghina-Greco | Apulia",
                    Price = 60.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 50,
                    Name = "Leonardo Prosecco DOC 0,75",
                    Category = "Napoje",
                    Subcategory = "Wino bia³e",
                    Ingredients = "wytrawne, Pinot Grigio | Wenecja",
                    Price = 70.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 51,
                    Name = "Surfine Cuvee 0,75",
                    Category = "Napoje",
                    Subcategory = "Wino bia³e",
                    Ingredients = "musujace wytrawne, Glera | Toskania",
                    Price = 45.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 52,
                    Name = "Mano Bianco IGT 0,150 | 0,75",
                    Category = "Napoje",
                    Subcategory = "Wino bia³e",
                    Ingredients = "musujace wytrawne, Sauvignon-Chardonnay-Glera | Wenecja",
                    Price = 52.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 53,
                    Name = "Nespolino Rosso IGT 0,150 | 0,75",
                    Category = "Napoje",
                    Subcategory = "Wino czerwone",
                    Ingredients = "wytrawne, Sangiovese-Merlot | Emilia Romagna",
                    Price = 55.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 54,
                    Name = "Itynera Primitivo IGT 0,150 | 0,75",
                    Category = "Napoje",
                    Subcategory = "Wino czerwone",
                    Ingredients = "wytrawne, Primitivo | Apulia",
                    Price = 65.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 55,
                    Name = "Leonardo Rubicaia DOC 0,150 | 0,75",
                    Category = "Napoje",
                    Subcategory = "Wino czerwone",
                    Ingredients = "wytrawne, Sangiovese-Merlot | Toskania",
                    Price = 60.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 56,
                    Name = "Baby Barbera d’Asti DOCG 0,150 | 0,75",
                    Category = "Napoje",
                    Subcategory = "Wino czerwone",
                    Ingredients = "wytrawne, Barbera | Piemont",
                    Price = 80.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 57,
                    Name = "A Mano Primitivo IGT 0,150 | 0,75",
                    Category = "Napoje",
                    Subcategory = "Wino czerwone",
                    Ingredients = "wytrawne, Primitivo | Apulia",
                    Price = 77.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 58,
                    Name = "Pian Del Gallo Chianti Classico DOCG",
                    Category = "Napoje",
                    Subcategory = "Wino czerwone",
                    Ingredients = "wytrawne, Sangiovese-Canaiolo-Cabernet | Toskania",
                    Price = 67.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 59,
                    Name = "£omza export 0,3 l | 0,5 l",
                    Category = "Napoje",
                    Subcategory = "Piwo",
                    Ingredients = "",
                    Price = 8.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 60,
                    Name = "Litovel Pszeniczny 0,3 l | 0,5 l",
                    Category = "Napoje",
                    Subcategory = "Piwo",
                    Ingredients = "",
                    Price = 10.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 61,
                    Name = "Bavaria 0,0% 0,33 l klasyczna / pszeniczna",
                    Category = "Napoje",
                    Subcategory = "Piwo",
                    Ingredients = "",
                    Price = 9.50m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 62,
                    Name = "Fortuna Mi³os³awski 0,5 l",
                    Category = "Napoje",
                    Subcategory = "Cydr",
                    Ingredients = "pó³wytrawny, pó³s³odki, jab³kowy",
                    Price = 11.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 63,
                    Name = "Cydr z nalewaka 0,3l | 0,5 l",
                    Category = "Napoje",
                    Subcategory = "Cydr",
                    Ingredients = "pó³s³odki, gruszkowy",
                    Price = 10.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 63,
                    Name = "Coca-Cola, Cola Zero 0,25 l",
                    Category = "Napoje",
                    Subcategory = "Napoje zimne",
                    Ingredients = "",
                    Price = 6.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 64,
                    Name = "Woda 0,33 l",
                    Category = "Napoje",
                    Subcategory = "Napoje zimne",
                    Ingredients = "",
                    Price = 4.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 65,
                    Name = "Sok 0,25 l",
                    Category = "Napoje",
                    Subcategory = "Napoje zimne",
                    Ingredients = "pomaranczowy, jab³kowy, multiwitamina, porzeczkowy, grejpfrutowy",
                    Price = 7.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 66,
                    Name = "Cytryna i Mieta 0,3 l | 1 l",
                    Category = "Napoje",
                    Subcategory = "Lemoniada",
                    Ingredients = "mieta, cytryna, cukier, woda niegazowana",
                    Price = 17.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 67,
                    Name = "Ogórek i Rozmaryn 0,3 l",
                    Category = "Napoje",
                    Subcategory = "Lemoniada",
                    Ingredients = "ogórek, rozmaryn, cukier, cytryna, woda gazowana",
                    Price = 9.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 68,
                    Name = "Domowa Oran¿ada 0,3 l",
                    Category = "Napoje",
                    Subcategory = "Lemoniada",
                    Ingredients = "pomarancza, syrop, woda gazowana",
                    Price = 9.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 69,
                    Name = "Woda Owocowa 0,7 l",
                    Category = "Napoje",
                    Subcategory = "Lemoniada",
                    Ingredients = "woda gazowana / niegazowana, owoce, mieta",
                    Price = 9.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 70,
                    Name = "Espresso | doppio 0,2 l",
                    Category = "Napoje",
                    Subcategory = "Napoje gor¹ce",
                    Ingredients = "",
                    Price = 5.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 71,
                    Name = "Kawa czarna | americano 0,2 l",
                    Category = "Napoje",
                    Subcategory = "Napoje gor¹ce",
                    Ingredients = "",
                    Price = 5.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 72,
                    Name = "Kawa bia³a 0,2 l",
                    Category = "Napoje",
                    Subcategory = "Napoje gor¹ce",
                    Ingredients = "",
                    Price = 5.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 73,
                    Name = "Cappuccino 0,2 l",
                    Category = "Napoje",
                    Subcategory = "Napoje gor¹ce",
                    Ingredients = "",
                    Price = 6.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 74,
                    Name = "Cafe latte 0,2 l",
                    Category = "Napoje",
                    Subcategory = "Napoje gor¹ce",
                    Ingredients = "",
                    Price = 8.00m
                }
                );

            context.Dishes.AddOrUpdate(x => x.DishId,
                new Dish
                {
                    DishId = 75,
                    Name = "Herbata 0,2 l",
                    Category = "Napoje",
                    Subcategory = "Napoje gor¹ce",
                    Ingredients = "wybór herbat przy barze",
                    Price = 3.00m
                }
                );
        }
    }
}
