using System.Collections.Generic;
using BoxingChampionship.Models;

namespace BoxingChampionship.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BoxingChampionship.Models.ChampionshipContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BoxingChampionship.Models.ChampionshipContext context)
        {
            var battles = new List<Battle>
            {
                new Battle
                {
                    Date = DateTime.Today.AddDays(-1), AmountOfRounds = 3, Winner = "Shakhobidin Zoirov",
                    Loser = "Amit Panghal", RefereePoints = 10
                },
                new Battle
                {
                    Date = DateTime.Today.AddDays(-3), AmountOfRounds = 3, Winner = "Mirazizbek Mirzakhalilov",
                    Loser = "Lázaro Álvarez", RefereePoints = 5
                },
                new Battle
                {
                    Date = DateTime.Today.AddDays(-5), AmountOfRounds = 3, Winner = "Andy Cruz",
                    Loser = "Keyshawn Davis", RefereePoints = 6
                },
                new Battle
                {
                    Date = DateTime.Today.AddDays(-30), AmountOfRounds = 3, Winner = "Andrey Zamkovoy",
                    Loser = "Pat McCormack", RefereePoints = 7
                },
                new Battle
                {
                    Date = DateTime.Today.AddDays(-7), AmountOfRounds = 3, Winner = "Gleb Bakshi",
                    Loser = "Eumir Marcial", RefereePoints = 9
                }
            };

            battles.ForEach(b => context.Battles.AddOrUpdate(p => p.Id, b));
            context.SaveChanges();
        }
    }
}
