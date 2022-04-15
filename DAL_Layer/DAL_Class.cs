using DAL_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Layer
{
    public class DAL_Class
    {
        pubsEntities _pubsEntities;
        public DAL_Class()
        {
             _pubsEntities = new pubsEntities();

        }
        public List<author> GetAuthers_DAL()
        {

            pubsEntities _pubsEntities = new pubsEntities();
            var auther = _pubsEntities.authors.ToList();
            return auther;
        }
        public void AddAuthors_DAL( author _author)
        {

           _pubsEntities.authors.Add( _author );
            _pubsEntities.SaveChanges();
        }
    }

    
}