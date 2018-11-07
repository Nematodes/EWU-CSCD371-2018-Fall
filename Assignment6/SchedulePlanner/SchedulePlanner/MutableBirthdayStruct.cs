namespace BrianBosAssignmentSix
{
    public struct MutableBirthdayStruct : IBirthday
    {
        private double _CollisionProbability;
        public double CollisionProbability
        {
            get
            {
                return _CollisionProbability;
            }

            set
            {
                if (value > 1.0)
                {
                    _CollisionProbability = 1;
                }
                else if (value < 0.0)
                {
                    _CollisionProbability = 0;
                }
                else
                {
                    _CollisionProbability = value;
                }
            }
        }

        public uint CandleCount { get; set; }

        public bool IsCakeReady { get; set; }

        public MutableBirthdayStruct(double collisionProbability, uint candleCount, bool isCakeReady)
        {
            _CollisionProbability = default(double);
            CandleCount = candleCount;
            IsCakeReady = isCakeReady;

            CollisionProbability = collisionProbability;
        }
    }
}