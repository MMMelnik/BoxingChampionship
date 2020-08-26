using System;
using System.ComponentModel.DataAnnotations;

namespace BoxingChampionship.Models
{
    public class Battle
    {
        public int Id { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public int AmountOfRounds { get; set; }
        public DateTime Date { get; set; }
        public string Winner { get; set; }
        public string Loser { get; set; }
        public int RefereePoints { get; set; }
    }
}