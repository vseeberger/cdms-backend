namespace WebApi.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApi.Data.WebApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebApi.Data.WebApiContext context)
        {
            #region Seed de produtos
            var produtos = new List<Produto>
                {
                    new Produto { Id = 1, SNome = "Bokken"     , DValor = 415.99m   , SDescricao = "Espada de madeira que simula uma katana ou kodachi."                                                                                                                     , SPathFoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/63/A_daisho_set_of_bokuto.jpg/300px-A_daisho_set_of_bokuto.jpg"                                               },
                    new Produto { Id = 2, SNome = "Katana"     , DValor = 138.53m   , SDescricao = "Espada tradicional japonesa samurai."                                                                                                                                    , SPathFoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/62/Katana_Masamune.jpg/350px-Katana_Masamune.jpg"                                                             },
                    new Produto { Id = 3, SNome = "Kodachi"    , DValor = 75.23m    , SDescricao = "Espada intermediária entre a wakizashi e a katana. Tem aproximadamente 75 cm."                                                                                           , SPathFoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/36/Kodachi-Sword-Hachiya-Nagamitsu-13th-Century.png/300px-Kodachi-Sword-Hachiya-Nagamitsu-13th-Century.png"   },
                    new Produto { Id = 4, SNome = "Ninja-to"   , DValor = 257.75m   , SDescricao = "Espada ninja, reta, um pouco menor que a katana, com um lado cortante e um lado rombo. A lâmina reta é uma representação apenas de filmes sem conexão com a real espada.", SPathFoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Ninto.png/220px-Ninto.png"                                                                                 },
                    new Produto { Id = 5, SNome = "Shinai"     , DValor = 179.90m   , SDescricao = "Espada de treino composta de 4 \"varas\" de bambu, ponta e empunhadura de couro; pode vir equipada com o tsuba (guarda da espada/shinai, geralmente feito de carbono)."  , SPathFoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/80/Shinai.jpg/300px-Shinai.jpg"                                                                               },
                    new Produto { Id = 6, SNome = "Shuriken"   , DValor = 11.37m    , SDescricao = "Arma de arremesso pequena, utilizada por ninjas, muito popularizada no cinema. Por seu formato semelhante a uma estrela é também conhecida como estrela ninja."          , SPathFoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c7/Ninja_Shuriken.jpg/220px-Ninja_Shuriken.jpg"                                                               },
                    new Produto { Id = 7, SNome = "Kunai"      , DValor = 9.47m     , SDescricao = "É uma arma ninja que consiste em uma lâmina de ferro com um grande furo na base, destinado a amarrar cordas, originário da era Tensho no Japão"                          , SPathFoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d1/Kunai05.jpg/200px-Kunai05.jpg"                                                                             }
                };
            produtos.ForEach(s => context.Produtos.AddOrUpdate(i => i.SNome, s));
            context.SaveChanges();
            #endregion
        }
    }
}
