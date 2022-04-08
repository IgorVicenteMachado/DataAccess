using System;

namespace dataAccess.DAPPER.Models
{
    public abstract class Modelbase    // abstract class can't be tracked by dapper
    {
        protected Modelbase(Guid id)
        {
            Id = id;
        }
        protected Modelbase() {}

        public Guid Id { get; set; }
    }
}