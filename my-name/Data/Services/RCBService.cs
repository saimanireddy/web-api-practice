using my_name.Data.Models;
using my_name.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_name.Data.Services
{
    public class RCBService
    {
        private AppDbContext _context;
        public RCBService(AppDbContext context)
        {
            _context = context;
        }

        public void AddRCB(RCBVM rcb)
        {
            var _rcb = new RCB()
            {
                Name = rcb.Name,
                Job = rcb.Job,
                Salary = rcb.Salary
            };
            _context.Add(_rcb);
            _context.SaveChanges();

        }

        public List<RCB> GetRCB()
        {
            return _context.RCBians.ToList();
        }

        public RCB GetRCBbyId(int id) => _context.RCBians.FirstOrDefault(n => n.Id == id);

        public RCB UpdateRCB(int id, RCBVM Rcb)
        {
            var rcb=_context.RCBians.FirstOrDefault(n=>n.Id==id);

            if (rcb != null)
            {
                rcb.Name = Rcb.Name;
                rcb.Salary = Rcb.Salary;
                rcb.Job = Rcb.Job;
                _context.SaveChanges();
            }

            return rcb;

        }

        public void DeleteRCB(int id)
        {
            var rcb=_context.RCBians.FirstOrDefault(n => n.Id == id);
            if (rcb != null)
            {
                _context.RCBians.Remove(rcb);
                _context.SaveChanges();
            }
        }
    }
}
