
namespace DotNetTestingFramework.Models
{
    internal class PetStoreModel
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int Quantity { get; set; }
        public string ShipDate { get; set; }
        public string Status { get; set; }
        public bool Complete { get; set; }

    }
}
