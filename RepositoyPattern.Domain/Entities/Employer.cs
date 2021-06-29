using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoyPattern.Domain.Entities
{
    public class Employer
    {
        public Employer( string name, string email, string document)
        {
            Id = new Guid();
            Name = name;
            Email = email;
            Document = document;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
    }
}
