using AutoMapper;
using CodeHipser.Data;
using CodeHipser.Data.Repositories;
using CodeHipser.Data.Repositories.Abstract;
using CodeHipser.Models;
using CodeHipser.Models.Dtos;
using CodeHipser.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeHipser.Services
{
    public class AdminService
    {
        private IUnitOfWork _context;
        private IMapper _mapper;
        public AdminService(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<CategoryDto> GetMenuItems()
        {
            IEnumerable<Section> sections = _context.Sections.GetOrderedSections();
            return _mapper.Map<IEnumerable<Section>, IEnumerable<CategoryDto>>(sections);
        }

        public void AddSection(SectionDto sectionDto)
        {
            Section section = _mapper.Map<Section>(sectionDto);
            _context.Sections.Add(section);
        }

        public void EditSection(SectionDto sectionDto)
        {
            Section sectionInDb = _context.Sections.GetSectionByIdIncluded(sectionDto.Id);
            if (sectionInDb != null)
                _mapper.Map(sectionDto, sectionInDb);
        }

        public SectionViewModel CreateSectionViewModel(int sectionTypeId, int? parentId = null)
        {
            Section parentSection = parentId==null ? null : _context.Sections.Get((int)parentId);
            SectionViewModel viewModel = new SectionViewModel();
            viewModel.SectionDto.ParentId = parentId;
            var sectionType = _context.SectionTypes.Get(sectionTypeId);
            viewModel.SectionDto.SectionType = _mapper.Map<SectionTypeDto>(sectionType);
            viewModel.SectionDto.SectionTypeId = sectionTypeId;

            if (parentSection != null)
            {
                List<Section> parentSections = GetParents(parentSection).ToList();
                viewModel.Parents = _mapper.Map<List<Section>, List<SectionDto>>(parentSections);
                viewModel.Parents.Add(_mapper.Map<SectionDto>(parentSection));
            }
            return viewModel;
        }

        public SectionViewModel EditSectionViewModel(int id)
        {
            Section section = _context.Sections.GetSectionByIdIncluded(id);
            if (section == null)
                return null;

            foreach (var child in section.Children)
            {
                child.SectionType = _context.SectionTypes.Get(child.SectionTypeId);
            }

            SectionViewModel viewModel = new SectionViewModel();
            viewModel.SectionDto = _mapper.Map<SectionDto>(section);

            List<SectionType> parentForSectionTypes = GetAvailableSectionTypes(id).ToList();
            viewModel.ParentForSectionTypes = _mapper.Map<List<SectionType>, List<SectionTypeDto>>(parentForSectionTypes);

            List<Section> parentSections = GetParents(section).ToList();
            viewModel.Parents = _mapper.Map<List<Section>, List<SectionDto>>(parentSections);
            return viewModel;
        }

        public SectionViewModel EditInvalidSectionViewModel(SectionViewModel sectionViewModel)
        {
            SectionViewModel viewModel = sectionViewModel;
            int? id = viewModel.SectionDto.ParentId;
            Section parentSection = id == null ? null : _context.Sections.GetSectionByIdParentIncluded((int)id);

            if (parentSection != null)
            {
                List<Section> parentSections = GetParents(parentSection).ToList();
                viewModel.Parents = _mapper.Map<List<Section>, List<SectionDto>>(parentSections);
                viewModel.Parents.Add(_mapper.Map<SectionDto>(parentSection));
            }
            return viewModel;
        }

        public int SaveChanges()
        {
            return _context.Complete();
        }

        #region Helpers
        private IEnumerable<Section> GetParents(Section section)
        {
            if (section != null)
            {
                Section parent = section.ParentId == null ? null : _context.Sections.Get((int)section.ParentId);
                if (parent != null)
                {
                    foreach (var item in GetParents(parent))
                    {
                        yield return item;
                    }
                    yield return parent;
                }
            }
        }

        private IEnumerable<SectionType> GetAvailableSectionTypes(int? parentId)
        {
            List<SectionType> sectionTypes = new List<SectionType>();

            if (parentId == null)
            {
                SectionType sectionType = _context.SectionTypes.Get(SectionType.Category);
                sectionTypes.Add(sectionType);
            }
            else
            {
                Section parentSection = parentId == null ? null :_context.Sections.Get((int)parentId);
                if (parentSection == null)
                    return null;
                sectionTypes = _context.SectionTypes.Find(x => x.ParentId == parentSection.SectionTypeId).ToList();
                if (parentSection?.SectionTypeId == SectionType.Category)
                    sectionTypes.Add(_context.SectionTypes.Get(SectionType.Category));
            }
            return sectionTypes;
        }
        #endregion
    }
}
