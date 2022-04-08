using System;

namespace dataAccess.DAPPER.Models
{
    public class Category : Modelbase
    {
        public Category(Guid id, string title, string url, string summary, int order, string description, bool featured)
            : base (id)
        {
            Title = title;
            Url = url;
            Summary = summary;
            Order = order;
            Description = description;
            Featured = featured;
        }
        protected Category() {} // uso do dapper
       // public Guid Id {get; private set;}
        public string Title {get; private set;}
        public string Url {get; private set;}
        public string Summary { get; private set; }
        public int Order { get; private set; }
        public string Description {get; private set;}
        public bool Featured {get; private set;}
    }
}