using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.PCComponents.DTO
{
    public class CPUDTO : BaseComponentDTO
    {
        public string Socket { get; set; }
        public int CountCores { get; set; } = 0;
        public int CountThreads { get; set; } = 0;
        public int BaseFrequency { get; set; } = 0;
        public RAMTypeDTO RAMType { get; set; }

        public CPUDTO(string name, string manufacturer, string model, double price, double totalScore, string socket, RAMTypeDTO ramType)
            : base(name, manufacturer, model, price, totalScore)
        {
            Socket = socket;
            RAMType = ramType;
        }
    }
}
