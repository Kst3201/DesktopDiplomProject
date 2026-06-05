using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomDataLibrary.PCComponents.DTO.Components
{
    public class CPUDTO : BaseComponentDTO
    {
        public string Socket { get; set; }
        public int CountCores { get; set; } = 0;
        public int CountThreads { get; set; } = 0;
        public int BaseFrequency { get; set; } = 0;
        public string RAMType { get; set; }

        public CPUDTO(string name, string manufacturer, string model, double price, double totalScore, string socket, string ramType)
            : base(name, manufacturer, model, price, totalScore)
        {
            Socket = socket;
            RAMType = ramType;
        }
    }
}
