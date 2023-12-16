
namespace DotNetTestingFramework.Models
{
    internal class PetStoreModel
    {
#pragma warning disable IDE1006 // Naming Styles
        public int id { get; set; }

        public int petId { get; set; }
        public int quantity { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string shipDate { get; set; }

        public string status { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public bool complete { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
