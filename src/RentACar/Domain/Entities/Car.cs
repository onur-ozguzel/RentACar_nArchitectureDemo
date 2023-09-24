using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities
{
    public class Car : Entity<Guid>
    {
        public Guid ModelId { get; set; }
        public int Kilometer { get; set; }
        public int ModelYear { get; set; }
        public string? Plate { get; set; }
        public short MinFindexScore { get; set; }
        public CarState CarState { get; set; }

        public virtual Model? Model { get; set; }

        public Car()
        {

        }

        public Car(
            Guid id,
            Guid modelId,
            int kilometer,
            int modelYear,
            string? plate,
            short minFindexScore,
            CarState carState
        ) : this()
        {
            Id = id;
            ModelId = modelId;
            Kilometer = kilometer;
            ModelYear = modelYear;
            Plate = plate;
            MinFindexScore = minFindexScore;
            CarState = carState;
        }
    }
}
