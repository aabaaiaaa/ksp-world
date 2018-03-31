using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerbal.Data
{
    public class KerbalRepository : IKerbalRepository, IKerbalMissionRepository
    {
        // Dependency Injection
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

        public Mission GetMission(string missionRef)
        {
            return (from km in _context.Kerbals where km.LastCompletedMission.Ref == missionRef select km.LastCompletedMission).FirstOrDefault();
        }

        public IEnumerable<Mission> GetMissions()
        {
            return (from km in _context.Kerbals select km.LastCompletedMission);
        }

        public IEnumerable<Mission> GetMissions(string targetPlanet)
        {
            return (from km in _context.Kerbals where km.LastCompletedMission.TargetPlanet == targetPlanet select km.LastCompletedMission);
        }

        public void Remove(Kerbal entity)
        {
            _context.Kerbals.Remove(entity);
            _context.SaveChanges();
        }

        public Kerbal Update(Kerbal entity)
        {
            // Find the entity in the DB
            var entityToUpdate = (from k in _context.Kerbals where k.Name == entity.Name select k).FirstOrDefault();
            // When null throw argument exception
            if(entityToUpdate == null)
            {
                throw new ArgumentException("cannot update a non-existing record");
            }
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
