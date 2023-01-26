
namespace MVC.ApiRequest
{
    public class Offre
    {
        public string Name { get; set; } = String.Empty;

        private string description;

        public string Description
        {
            get { return description; }
            set {
                if (value.Length < 140)
                    description = value;
                else
                {
                    description = value.Substring(0,140)+"...";
                }
            }
        }


        public string Localisation { get; set; } = String.Empty;

        public string Link { get; set; } = String.Empty;

        public Offre(string name, string description, string localisation, string link)
        {
            Name = name;
            Description = description;
            Localisation = localisation;
            Link = link;
        }
    }
}
