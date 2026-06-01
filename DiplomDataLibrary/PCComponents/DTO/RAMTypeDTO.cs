namespace DiplomDataLibrary.PCComponents.DTO
{
    public class RAMTypeDTO : BaseComponentUnitDTO
    {
        public double ScoreOne { get; set; }
        public double ScoreTwo { get; set; }
        public double ScoreThree { get; set; }
        public double ScoreFour { get; set; }
        public double ScoreFive { get; set; }
        public double TotalScore { get; set; }

        public RAMTypeDTO(string name, double scoreOne, double scoreTwo, double scoreThree, double scoreFour, double scoreFive, double totalScore) : base(name)
        {
            ScoreOne = scoreOne;
            ScoreTwo = scoreTwo;
            ScoreThree = scoreThree;
            ScoreFour = scoreFour;
            ScoreFive = scoreFive;
            TotalScore = totalScore;
        }
    }
}
