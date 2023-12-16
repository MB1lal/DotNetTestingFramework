

namespace DotNetTestingFramework.Models.Config_Model
{
    public class Urls
    {
        public string HerokuURL { get; set; }
        public string PetBaseURI { get; set; }

        public Urls()
        {
            HerokuURL = string.Empty;
            PetBaseURI = string.Empty;
        }

    }
}
