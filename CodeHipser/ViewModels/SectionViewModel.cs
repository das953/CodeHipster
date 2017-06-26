using CodeHipser.Models;
using CodeHipser.Models.Dtos;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.ViewModels
{
    public class SectionViewModel
    {
        public SectionDto SectionDto { get; set; }
        public List<SectionTypeDto> ParentForSectionTypes { get; set; }
        public List<SectionDto> Parents { get; set; }

        public SectionViewModel()
        {
            SectionDto = new SectionDto();
            ParentForSectionTypes = new List<SectionTypeDto>();
            Parents = new List<SectionDto>();
        }
    }
}
