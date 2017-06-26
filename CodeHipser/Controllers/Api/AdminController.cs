using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodeHipser.Data;
using AutoMapper;
using CodeHipser.Models.Dtos;
using CodeHipser.Models;
using Microsoft.EntityFrameworkCore;
using CodeHipser.Models.EntityBase;

namespace CodeHipser.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public AdminController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                Section section = _context.Sections.SingleOrDefault(x => x.Id == id);
                if (section == null)
                    NotFound();
                RecursiveDelete(section.Id);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var section = ex.Entries.Single();
                var databaseValues = section?.GetDatabaseValues();
                if(databaseValues!=null)
                {
                    section.OriginalValues.SetValues(section.GetDatabaseValues());
                    _context.SaveChanges();
                }
            }
        }

        private void RecursiveDelete(int id)
        {
            var children = _context.Sections.Where(x => x.ParentId == id);
            if (children!=null && children.Any())
            {
                foreach (var child in children)
                {
                    RecursiveDelete(child.Id);
                    _context.Sections.Remove(child);
                }
            }

            _context.Sections.RemoveRange(_context.Sections.Where(x => x.Id == id));
        }
    }
}