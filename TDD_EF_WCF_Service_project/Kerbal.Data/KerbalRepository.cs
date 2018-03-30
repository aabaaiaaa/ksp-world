using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerbal.Data
{
    public class KerbalRepository : IKerbalRepository
    {
        public KerbalRepository(KerbalDbContext dbContext)
        {
            _context = dbContext;
        }

        private KerbalDbContext _context { get; set; }

        public Kerbal Add(Kerbal entity)
        {
            _context.Kerbals.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Kerbal Get(string name)
        {
            return (from k in _context.Kerbals where k.Name == name select k).FirstOrDefault();
        }

        public IEnumerable<Kerbal> Get(bool onMission)
        {
            return from k in _context.Kerbals where k.OnMission select k;
        }

        public IEnumerable<Kerbal> Get()
        {
            return (from k in _context.Kerbals select k);
        }

        public void Remove(Kerbal entity)
        {
            _context.Kerbals.Remove(entity);
            _context.SaveChanges();
        }

        public Kerbal Update(Kerbal entity)
        {
            // Find the entity in the DB
            var entityToUpdate = from k in _context.Kerbals where k.Name == entity.Name select k;
            // Update each property available to match the entity being passed in
            foreach (var prop in entity.GetType().GetProperties())
            {
                prop.SetValue(entityToUpdate, prop.GetValue(entity));
            }
            // Store changes back to persistence layer
            _context.SaveChanges();
            return entity;
        }
    }
}
