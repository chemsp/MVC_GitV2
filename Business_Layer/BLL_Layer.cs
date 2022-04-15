
using AutoMapper;
using Business_Layer.Models;
using DAL_Layer;
using DAL_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
     public class BLL_Layer
    {
        MapperConfiguration config;
        IMapper mapper;
        DAL_Class _dAL_Class;
        
        public BLL_Layer()
        {
            _dAL_Class = new DAL_Class();
             config = new MapperConfiguration(cfg =>
             {
                 cfg.CreateMap<author, Author_DTO>();
                 cfg.CreateMap<Author_DTO, author>();

             });
             mapper = config.CreateMapper();

        }
        public List <Author_DTO> GetAuthors_BLL()
        {
            
            List<author> _authors =  _dAL_Class.GetAuthers_DAL();
            
            List<Author_DTO> _authors_DTO = mapper.Map<List<author>, List<Author_DTO>>(_authors);
           
            return _authors_DTO;
        }

        public void AddAuthors_BLL( Author_DTO author)
        {
                   
            var _author = mapper.Map<Author_DTO, author>(author);

            _dAL_Class.AddAuthors_DAL(_author);
        }
    }
}
