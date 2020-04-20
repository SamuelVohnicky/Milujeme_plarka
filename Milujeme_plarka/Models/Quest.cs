using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Milujeme_plarka.Models
{
    public class Quest
    {
        [Key]
        public int QuestId { get; set; }

        [Required]
        public string QuestQuote { set; get; }
        //bude doděláno přes enum
        [Required]
        public int Role { get; set; }
        [Required]
        public int QuestGamePhase { get; set; }
    }
}
