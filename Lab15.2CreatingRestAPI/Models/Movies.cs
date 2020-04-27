using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab15._2CreatingRestAPI.Models
{
    public class Movies
    {
        private int id;
        private string title;
        private string category;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Category { get => category; set => category = value; }


    }
}
