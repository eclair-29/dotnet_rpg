using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Dtos.Character
{
    public class CreateCharacterDto
    {
        public string Name { get; set; } = "Traveller";
        public int HealthPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Agility { get; set; } = 15;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}