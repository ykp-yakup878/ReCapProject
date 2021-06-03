using Core.Entites;

namespace Entities.Concrete
{
    public class CarFindeks : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int FindeksScore { get; set; }
    }
}
