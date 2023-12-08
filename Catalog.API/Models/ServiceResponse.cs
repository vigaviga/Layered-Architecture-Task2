using Carting.Domain.Entities;
using Catalog.Domain.Entities;

namespace Layered_Architecture_Task2.Models
{
    public class ServiceResponse<T> where T : Base
    {
        public T Body { get; set; }
        
        public List<Link> Links { get; set; }
        public ServiceResponse(T body)
        {
            Body = body;
            GenerateLinks();
        }

        private void GenerateLinks()
        {
            Links = new List<Link>();

            switch (Body)
            {
                case Category category:
                    Links.Add(new Link("self", $"/Categories/{Body.Id}"));
                    Links.Add(new Link("delete", $"/Categories/{Body.Id}"));
                    Links.Add(new Link("update", "/Categories"));
                    break;
                case Item item:
                    Links.Add(new Link("self", $"/Items/{Body.Id}"));
                    Links.Add(new Link("delete", $"/Items/{Body.Id}"));
                    Links.Add(new Link("update", "/Items"));
                    break;
            }
        }
    }

    public class Link
    {
        public string Relation { get; set; }
        public string Uri { get; set; }

        public Link (string relation, string uri)
        {
            Relation = relation;
            Uri = uri;
        }
    }
}
