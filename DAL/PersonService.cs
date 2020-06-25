using MAS_projekt.Models.People;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_projekt.DAL
{
    public class PersonService
    {
        private readonly MasDbContext _context = new MasDbContext();

        public ObservableCollection<Client> GetClients()
        {
            return new ObservableCollection<Client>(_context.Clients.Include(x => x.Person).ToList());
        }

        public void AddClient(int personId)
        {
            var person = _context.People
                .Include(p => p.Client)
                .FirstOrDefault(p => p.Id == personId);
            if (person.Client == null)
            {
                person.Client = new Client(person);
            }
        }

        public void AddEmployee(int personId, double salary)
        {
            var person = _context.People
                .Include(p => p.Employee)
                .FirstOrDefault(p => p.Id == personId);
            if (person.Employee == null)
            {
                person.Employee = new Employee(person, salary);
            }
        }
    }
}
